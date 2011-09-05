/*
    Copyright 2008,2009,2010,2011 Chris Capon.

    This file is part of KeepBack.

    KeepBack is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    KeepBack is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with KeepBack.  If not, see <http://www.gnu.org/licenses/>.

*/

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;

namespace KeepBack
{
	public class Archive : IDisposable
	{
		/* Backup proceedure
		 * -----------------
		 * - An Archive is a folder with a list of dated folders underneath.
		 *   - each dated folder represents one backup
		 *   - the most recent dated folder holds a complete backup of everything
		 *   - all previous dated folders contain just the delta differences
		 *     for files and folders which changed or were deleted between the
		 *     times of the two backups.
		 * - When a backup is processed:
		 *   - "history" is set to the most recent dated folder (if one exists)
		 *   - "current" is set to the name of a new dated folder based on the current time.
		 *   - "history" is renamed to "current".
		 */

		//--- define ----------------------------

		public const string  ARCHIVE_PATTERN = @"????-??-??-????";
		       const string  SECTION_DETAIL  = @"           ";
		       const char    BLANK           = '-';

		public enum Action
		{
			Info,
			Directory,
			File,
			Change,
			Skip,
		}
		public enum Reason
		{
			Created   = 1,
			Modified  = 2,
			Deleted   = 3,
		}
		public enum MergeLevel
		{
			Year,
			Month,
			Day,
			Hour,
			Minute,
		}
		enum Function
		{
			TD, //TestDrive
			LD, //ListDirectories
			LF, //ListFiles
			DC, //DirectoryCreate
			DM, //DirectoryMove
			DD, //DirectoryDelete
			FC, //FileCopy
			FM, //FileMove
			FD, //FileDelete
			FI, //FileInfo
		}

		public delegate void ActionDelegate( Action action, string text );

		//--- field -----------------------------
	
		ActionDelegate    action;
		CtrlArchive       archive;
		StreamWriter      log           = null;

		bool              debug         = false;
		bool              cancel        = false;

		bool              caseSensitive = false;             //indicates whether archive filesystem distinguishes between upper and lower case or not
		DateTime          minDateUtc    = DateTime.MinValue; //minimum LastWriteUDC date the archive filesystem will accept
		DateTime          maxDateUtc    = DateTime.MaxValue; //maximum LastWriteUDC date the archive filesystem will accept

		DateTime          start         = DateTime.MinValue;
		string            current       = null;
		string            history       = null;

		string            curr          = null;
		string            hist          = null;
		string            fold          = null;

		MatchSet          inc           = null;
		MatchSet          exc           = null;
		MatchSet          his           = null;

		readonly string[] ReasonNames   = Enum.GetNames ( typeof(Reason          ) );
		readonly Array    ReasonValues  = Enum.GetValues( typeof(Reason          ) );
		readonly string[] MatchNames    = Enum.GetNames ( typeof(MatchSet.SetType) );
		readonly Array    MatchValues   = Enum.GetValues( typeof(MatchSet.SetType) );

		//--- property --------------------------

		public bool Cancel { get { return cancel; } set { cancel = value; } }

		//--- constructor -----------------------

		public Archive( ActionDelegate action, CtrlArchive archive, bool create, bool debug )
		{
			this.action   = action;
			this.archive  = archive;
			this.debug    = debug;

			this.start    = DateTime.Now;

			if( create && ! _DirectoryCreateDirectory( archive.FullPath ) )
			{
				LogInfo( "Can not create archive path [ " + archive.FullPath + " ]." );
			}
			if( Directory.Exists( archive.FullPath ) )
			{
				this.log = new StreamWriter( Path.Combine( archive.FullPath, _DateFolderSecond( start ) + ".log" ), false, Encoding.ASCII );
			}
			LogInfo( "---------------" );
			LogInfo( Status( "Archive", archive.FullPath ) );
		}

		//--- method ----------------------------

		bool TestArchiveDriveProperties( string path )
		{
			try
			{
				/* Check if filesystem is case sensitive or not
				 * by creating a temporary file then attempting
				 * to access it using a different case name.
				 */
				string p = Path.Combine( path, "__TemporaryFile__.txt" );
				if( File.Exists( p.ToLower() ) )
				{
					File.Delete( p.ToLower() );
				}
				using( StreamWriter sw = File.CreateText( p ) )
				{
					sw.WriteLine( p );
				}
				this.caseSensitive = ! File.Exists( p.ToLower() );

				/* Find the supported date range for file LastWriteTimeUtc.
				 * Use a binary search to find the min and max dates allowed.
				 */
				DateTime lo = DateTime.MinValue;
				DateTime hi = DateTime.UtcNow;
				while( (minDateUtc = hi.AddTicks( (lo.Ticks - hi.Ticks) / 2 )) < hi )
				{
					try
					{
						File.SetLastWriteTimeUtc( p, minDateUtc );
						hi = minDateUtc;
					}
					catch( Exception )
					{
						lo = minDateUtc;
					}
				}
				lo = DateTime.UtcNow;
				hi = DateTime.MaxValue;
				while( (maxDateUtc = lo.AddTicks( (hi.Ticks - lo.Ticks) / 2 )) > lo )
				{
					try
					{
						File.SetLastWriteTimeUtc( p, maxDateUtc );
						lo = maxDateUtc;
					}
					catch( Exception )
					{
						hi = maxDateUtc;
					}
				}

				File.Delete( p );
				if( debug )
				{
					Log( "  filesystem " + (this.caseSensitive ? "distinguishes" : "does not distinguish") + " between upper and lower case." );
					Log( "  filesystem date range is from " + DisplayDate( minDateUtc ) + " to " + DisplayDate( maxDateUtc ) + "." );
				}
				return true;
			}
			catch( Exception ex )
			{
				LogException( Function.TD, DisplayDirectory( path ), ex );
			}
			return false;
		}

		public void _Backup( string archiveFilePath )
		{
			Log( "" );
			LogInfo( "Backup..." );
			if( ! Directory.Exists( archive.FullPath ) )
			{
				LogInfo( "The archive path [ " + archive.FullPath + " ] is not accessible." );
				return;
			}
			current = _DateFolderMinute( start );
			history = null;
			{
				string[] a = _ArchiveList();
				if( a.Length > 0 )
				{
					history = a[a.Length - 1];
					if( string.Compare( current, history, true ) <= 0 )
					{
						current = _DateFolderSecond( start );
						if( string.Compare( current, history, true ) <= 0 )
						{
							LogInfo( "A backup was started at " + current + " which is earlier than your previous backup at " + history + ".  Please try again later." );
							return;
						}
					}
				}
			}
			current = Path.Combine( archive.FullPath, current );
			if( history != null )
			{
				history = Path.Combine( archive.FullPath, history );
				LogInfo( Status( "  previous", history ) );
				if( ! _DirectoryMove( history, current ) )
				{
					LogInfo( "The latest backup folder can not be renamed.  Maybe another application is using it." );
					return;
				}
			}
			else
			{
				if( ! _DirectoryCreateDirectory( current ) )
				{
					LogInfo( "A folder for this backup can not be created at [ " + current + " ]." );
					return;
				}
			}
			LogInfo( Status( "  current", current ) );

			if( ! TestArchiveDriveProperties( archive.FullPath ) )
			{
				LogInfo( "Was not able to test archive filesystem properties." );
				return;
			}

			Log( "" );
			LogLegend();
			Log( "" );
			{
				/* move copy of control file in to backup folder
				 */
				string fp = Path.GetDirectoryName( archiveFilePath );
				string n  = Path.GetFileName     ( archiveFilePath );
				_BackupFile( fp, current, history, n, n, true );
				foreach( string s in _ListFiles( current ) )
				{
					if( string.Compare( s, n, true ) != 0 )
					{
						_RemoveFile( current, history, s, s, true );
					}
				}
			}

			{
				/* backup each folder in archive set
				 */
				List<string> a = new List<string>( _ListDirectories( current ) );
				if( archive.Folders != null )
				{
					foreach( CtrlFolder folder in archive.Folders )
					{
						if( cancel ) { break; }
						Log( "" );
						Log( "Folder" );
						LogInfo( Status( folder.Name, folder.Path ) );
						_Backup( folder );
						foreach( string s in _ListDirectories( current, folder.Name ) )
						{
							a.Remove( s );
						}
					}
				}
				if( ! cancel && (a.Count > 0) && (history != null) )
				{
					/* move any existing folders not in archive set to history
					 */
					Log( "" );
					Log( "Remove" );
					_DirectoryCreateDirectory( history );
					foreach( string n in a )
					{
						LogReason( Reason.Deleted, n, _DirectoryMove( Path.Combine( current, n ), Path.Combine( history, n ) ) );
					}
				}
			}

			action( Action.Directory, "" );
			action( Action.File, "" );
			TimeSpan x = DateTime.Now - start;
			Log( "" );
			LogInfo( Status( ".." + (cancel ? "cancelled" : "done     "), DisplayTime( x ) ) );
		}

		void _Backup( CtrlFolder folder )
		{
			if( string.IsNullOrEmpty( folder.Name ) || string.IsNullOrEmpty( folder.Path ) )
			{
				LogInfo( "  incomplete folder definition" );
				return;
			}
			this.curr  = Path.Combine( current, folder.Name );
			this.hist  = (history == null) ? null : Path.Combine( history, folder.Name );
			this.fold  = folder.Path;
			MatchSet.MatchDelegate md = new MatchSet.MatchDelegate( LogMatch );
			this.inc   = new MatchSet( MatchSet.SetType.Include, folder.Include, md );
			this.exc   = new MatchSet( MatchSet.SetType.Exclude, folder.Exclude, md );
			this.his   = new MatchSet( MatchSet.SetType.History, folder.History, md );
			_BackupCompareFolder( "", false, true );
		}
		bool _BackupCompareFolder( string path, bool include, bool history )
		{
			/* The 'include' flag indicates an item has specifically been included
			 * by a filter.
			 * The 'history' flag indicates an item has specifically been marked for
			 * a single backup only (no historical copies).
			 * If a folder is specifically excluded with a filter, then no further
			 * analysis is done on it.
			 * If the folder has not specifically been included or excluded, then a
			 * deeper analysis is done.  The folder and its descendants are scanned
			 * for files and folders which do match an include filter.
			 */
			if( ! include && inc.MatchDirectory( path ) ) { include = true ; }
			if(              exc.MatchDirectory( path ) ) { return    false; }
			if(   history && his.MatchDirectory( path ) ) { history = false; }

			if( cancel ) { return include; }
			string cp = Path.Combine( curr, path );
			if( ! Directory.Exists( cp ) )
			{
				//..if directory doesn't exist in current, then the entire tree can simply be copied.
				return _CopyFolder( path, include );
			}
			bool         rc = include;
			List<string> a  = new List<string>( _ListDirectories( cp ) );
			string       fp = Path.Combine( fold, path );
			string       hp = (hist == null) ? null : Path.Combine( hist, path );
			foreach( string n in _ListDirectories( fp ) )
			{
				if( cancel ) { return rc; }
				//..check each sub-directory in folder.
				if( _BackupCompareFolder( Path.Combine( path, n ), include, history ) )
				{
					foreach( string s in _ListDirectories( cp, n ) )
					{
						a.Remove( s );
					}
					rc = true;
				}
			}
			action( Action.Directory, path );
//			action( Action.File, "" );
			if( a.Count > 0 )
			{
				//..move deleted, renamed or excluded directories from current to history.
				if( ! history || ((hp != null) && _DirectoryCreateDirectory( hp )) )
				{
					foreach( string n in a )
					{
						if( cancel ) { return rc; }
						action( Action.File, DisplayDirectory( n ) );
						string pn = Path.Combine( path, n );
						if( ! history || his.MatchDirectory( pn ) )
						{
							LogReason( Reason.Deleted, DisplayDirectory( pn ), _DirectoryDelete( Path.Combine( cp, n ), true ) );
						}
						else
						{
							LogReason( Reason.Deleted, DisplayDirectory( pn ), _DirectoryMove( Path.Combine( cp, n ), Path.Combine( hp, n ) ) );
						}
					}
				}
			}

			a = new List<string>( _ListFiles( cp ) );
			foreach( string n in _ListFiles( fp ) )
			{
				if( cancel ) { return rc; }
				string  pn  = Path.Combine( path, n );
				if( (include || inc.MatchFile( pn )) && ! exc.MatchFile( pn ) )
				{
					foreach( string s in _ListFiles( cp, n ) )
					{
						a.Remove( s );
					}
					_BackupFile( fp, cp, hp, pn, n, history && ! his.MatchFile( pn ) );
					rc = true;
				}
			}
			if( a.Count > 0 )
			{
				//..move deleted, renamed or excluded files from current to history.
				if( ! history || ((hp != null) && _DirectoryCreateDirectory( hp )) )
				{
					foreach( string n in a )
					{
						if( cancel ) { return rc; }
						string pn = Path.Combine( path, n );
						_RemoveFile( cp, hp, pn, n, history && ! his.MatchFile( pn ) );
					}
				}
			}
			return rc;
		}

		/// <summary>
		///		Copy a folder and all sub-folders as quickly as possible without
		///		checking their contents first.
		///		Before calling this function, make sure the destination folder
		///		does not already exist.
		/// </summary>
		bool _CopyFolder( string path, bool include )
		{
			if( cancel ) { return include; }
			if( ! include && inc.MatchDirectory( path ) ) { include = true; }
			if(              exc.MatchDirectory( path ) ) { return false; }
			bool   rc = include;
			string cp = Path.Combine( curr, path );
			if( ! include || _DirectoryCreateDirectory( cp ) )
			{
				if( include )
				{
					LogReason( Reason.Created, DisplayDirectory( path ), true );
					rc = true;
				}
				string fp = Path.Combine( fold, path );
				foreach( string n in _ListDirectories( fp ) )
				{
					if( cancel ) { return rc; }
					string p = Path.Combine( path, n );
					rc |= _CopyFolder( p, include );
				}
				action( Action.Directory, path );
//				action( Action.File, "" );
				foreach( string n in _ListFiles( fp ) )
				{
					if( cancel ) { return rc; }
					string pn = Path.Combine( path, n );
					if( (include || inc.MatchFile( pn )) && ! exc.MatchFile( pn ) )
					{
						if( include || _DirectoryCreateDirectory( cp ) )
						{
							action( Action.File, n );
							LogReason( Reason.Created, pn, _FileCopy( Path.Combine( fp, n ), Path.Combine( cp, n ), false ) );
							rc = true;
						}
					}
				}
			}
			return rc;
		}

		void _BackupFile( string fp, string cp, string hp, string pn, string n, bool history )
		{
			string   fpn  = Path.Combine( fp, n );
			string   cpn  = Path.Combine( cp, n );

			FileInfo ffi  = _FileInfo( fpn );
			FileInfo cfi  = _FileInfo( cpn );
			if( (ffi == null) || (cfi == null) )
			{
				return;
			}
			if( ! cfi.Exists )
			{
				//..file does not exist in current, simply copy
				action( Action.File, n );
				LogReason( Reason.Created, pn, _FileCopy( fpn, cpn, false ) );
				return;
			}
			/* ..check for file property changes
			 * The date of the file is adjusted to fit within the min and max dates the archive filesystem can support.
			 * The dates are checked to be within 1 second of each other to avoid slight inconsistencies at the millisecond level.
			 * The file length must match.
			 */
			if( 
				   DateCompare( DateAdjust( ffi.LastWriteTimeUtc ), DateAdjust( cfi.LastWriteTimeUtc ) )
				&& (ffi.Length == cfi.Length )
				)
			{
				//..file has not changed, ignore
				return;
			}
			action( Action.File, n );

			if( debug )
			{
				StringBuilder sbf = new StringBuilder();
				StringBuilder sbc = new StringBuilder();
				if( ffi.CreationTime      != cfi.CreationTime      ) { sbf.Append(  " CR[" + DisplayDate( ffi.CreationTime                ) + "]" ); sbc.Append(  " CR[" + DisplayDate( cfi.CreationTime                ) + "]" ); }
				if( ffi.CreationTimeUtc   != cfi.CreationTimeUtc   ) { sbf.Append( " CRU[" + DisplayDate( ffi.CreationTimeUtc             ) + "]" ); sbc.Append( " CRU[" + DisplayDate( cfi.CreationTimeUtc             ) + "]" ); }
				if( ffi.LastAccessTime    != cfi.LastAccessTime    ) { sbf.Append(  " LA[" + DisplayDate( ffi.LastAccessTime              ) + "]" ); sbc.Append(  " LA[" + DisplayDate( cfi.LastAccessTime              ) + "]" ); }
				if( ffi.LastAccessTimeUtc != cfi.LastAccessTimeUtc ) { sbf.Append( " LAU[" + DisplayDate( ffi.LastAccessTimeUtc           ) + "]" ); sbc.Append( " LAU[" + DisplayDate( cfi.LastAccessTimeUtc           ) + "]" ); }
				if( ffi.LastWriteTime     != cfi.LastWriteTime     ) { sbf.Append(  " LW[" + DisplayDate( ffi.LastWriteTime               ) + "]" ); sbc.Append(  " LW[" + DisplayDate( cfi.LastWriteTime               ) + "]" ); }
				if( ffi.LastWriteTimeUtc  != cfi.LastWriteTimeUtc  ) { sbf.Append( " LWU[" + DisplayDate( ffi.LastWriteTimeUtc            ) + "]" ); sbc.Append( " LWU[" + DisplayDate( cfi.LastWriteTimeUtc            ) + "]" ); }
				if( ffi.Length            != cfi.Length            ) { sbf.Append( " LEN[" +              ffi.Length            .ToString() + "]" ); sbc.Append( " LEN[" +              cfi.Length            .ToString() + "]" ); }
				if( ffi.Attributes        != cfi.Attributes        ) { sbf.Append(  " AT[" +              ffi.Attributes        .ToString() + "]" ); sbc.Append(  " AT[" +              cfi.Attributes        .ToString() + "]" ); }
				if( ffi.IsReadOnly        != cfi.IsReadOnly        ) { sbf.Append(  " RO[" +              ffi.IsReadOnly        .ToString() + "]" ); sbc.Append(  " RO[" +              cfi.IsReadOnly        .ToString() + "]" ); }
				Log( "" );
				LogStatus( "   file"  , sbf.ToString() );
				LogStatus( "  archive", sbc.ToString() );
			}

			//?? Is there a better way to do this combination that tests if a file can be copied first ??
			//..perhaps copy to a different file name first, move old file to history, rename copied file

			bool replace = false;

			//..move old file from current to history
			if( ! history )
			{
				//..remove old file from current

				if( ! _FileDelete( cpn ) )
				{
					LogInfo( "Backup. failed to delete previous backup file" );
					replace = true;
				}
				//..copy file to current
				LogReason( Reason.Modified, pn, _FileCopy( fpn, cpn, replace ) );
				return;
			}
			if( (hp == null) || ! _DirectoryCreateDirectory( hp ) )
			{
				return;
			}
			//..move old file from current to history
			string hpn = Path.Combine( hp, n );
#if true //history bug
			if( File.Exists( hpn ) )
			{
				LogInfo( "Backup. file already exists in history [" + hpn + "], replacing" );
				_FileDelete( hpn );
			}
#endif
			if( ! _FileMove( cpn, hpn ) )
			{
				LogInfo( "Backup. failed moving current to history" );
				replace = true;
			}
			//..copy new file from folder to current
			if( ! _FileCopy( fpn, cpn, replace ) )
			{
				action( Action.Skip, "" );
				return;
			}
			LogReason( Reason.Modified, pn, true );
			return;
		}
		void _RemoveFile( string cp, string hp, string pn, string n, bool history )
		{
			action( Action.File, n );
			string cpn = Path.Combine( cp, n );
			if( history )
			{
				if( (hp == null) || ! _DirectoryCreateDirectory( hp ) )
				{
					return;
				}
				string hpn = Path.Combine( hp, n );
#if true //history bug
				if( File.Exists( hpn ) )
				{
					LogInfo( "Remove. file already exists in history [" + hpn + "], replacing" );
					_FileDelete( hpn );
				}
#endif
				if( _FileMove( cpn, hpn ) )
				{
					LogReason( Reason.Deleted, pn, true );
					return;
				}
				LogInfo( "Remove. failed moving current to history" );
			}
			LogReason( Reason.Deleted, pn, _FileDelete( cpn ) );
		}



		public void _Merge()
		{
			Log( "" );
			LogInfo( "Merge..." );
			if( ! Directory.Exists( archive.FullPath ) )
			{
				LogInfo( "The archive path [ " + archive.FullPath + " ] is not accessible." );
				return;
			}
			_Merge( MergeLevel.Minute );
			_Merge( MergeLevel.Hour   );
			_Merge( MergeLevel.Day    );
			_Merge( MergeLevel.Month  );
			_Merge( MergeLevel.Year   );

			//..remove old log files
			string[] a = _ArchiveList();
			string   s = _DateFolderSkipCurrent( MergeLevel.Minute );
			int      z = _DateFolderLength     ( MergeLevel.Minute );
			foreach( string f in _ArchiveLogList() )
			{
				int i = a.Length;
				do
				{
					--i;
					if( i < 0 )
					{
						if( string.Compare( f, s, true ) < 0 )
						{
							_FileDelete( Path.Combine( archive.FullPath, f ) );
						}
						break;
					}
				}
				while( string.Compare( f, 0, a[i], 0, z, true ) != 0 );
			}

			TimeSpan x = DateTime.Now - start;
			LogInfo( Status( ".." + (cancel ? "cancelled" : "done     "), DisplayTime( x ) ) );
		}

		void _Merge( MergeLevel level )
		{
			if( cancel ) { return; }
			string  s = _DateFolderSkipCurrent  ( level );
			int     z = _DateFolderLength       ( level );
			if( ! string.IsNullOrEmpty( s ) && (z > 0) )
			{
				//..merge directories
				string[] a  = _ArchiveList();
				int      i  = a.Length;
				do
				{
					--i;
				}
				while( (i > 0) && (string.Compare( a[i], s, true ) >= 0 ) );
				while( i > 0 )
				{
					int j = i;
					int x = 0x00;
					while( (--i >= 0) && (string.Compare( a[i], 0, a[j], 0, z, true ) == 0) )
					{
						if( x == 0x00 )
						{
							LogInfo( Status( "  " + level.ToString(), a[j] ) );
							x |= 0x01;
						}
						LogInfo( Status( "  ..remove/merge", a[i] ) );
						if( ! _Merge( a[i], a[j] ) )
						{
							LogInfo( "  merge failed" );
							x |= 0x02;
						}
					}
					//rename minute folders which have seconds on them
					if( (x <= 0x01) && (level == MergeLevel.Minute) && (a[j].Length > z) )
					{
						string t = a[j].Substring( 0, z );
						LogInfo( Status( "  ..rename", a[j] + "   " + t ) );
						_DirectoryMove( Path.Combine( archive.FullPath, a[j] ), Path.Combine( archive.FullPath, t ) );
					}
				}
			}
		}
		bool _Merge( string src, string dst )
		{
			if( cancel ) { return false; }
			string sp = Path.Combine( archive.FullPath, src );
			string dp = Path.Combine( archive.FullPath, dst );
			if( ! Directory.Exists( dp ) )
			{
				LogInfo( "Destination folder missing : " + DisplayDirectory( dp ) );
				return false;
			}
			if( ! Directory.Exists( sp ) )
			{
				LogInfo( "Source folder missing : " + DisplayDirectory( dp ) );
				return false;
			}
			bool ret = true;
			foreach( string n in _ListDirectories( sp ) )
			{
				if( cancel ) { return false; }
				string dpn = Path.Combine( dp, n );
				if( Directory.Exists( dpn ) )
				{
					ret &= _Merge( Path.Combine( src, n ), Path.Combine( dst, n ) );
				}
				else
				{
					ret &= _DirectoryMove( Path.Combine( sp, n ), dpn );
				}
			}
			foreach( string n in _ListFiles( sp ) )
			{
				if( cancel ) { return false; }
				string dpn = Path.Combine( dp, n );
				if( File.Exists( dpn ) )
				{
					ret &= _FileDelete( Path.Combine( sp, n ) );
				}
				else
				{
					bool b = _FileMove( Path.Combine( sp, n ), dpn );
					if( ! b )
					{
						LogInfo( "failed moving source [" + Path.Combine( sp, n ) + "] to destination [" + Path.Combine( dp, n ) + "]" );
					}
					ret &= b;
				}
			}
			if( ! cancel && ret )
			{
				//..if all opperations were successful then remove source folder
				ret &= _DirectoryDelete( sp, true );
			}
			return ret;
		}







		string[] _ArchiveList()
		{
			if( Directory.Exists( archive.FullPath ) )
			{
				List<string> a = new List<string>( _ListDirectories( archive.FullPath, ARCHIVE_PATTERN + @"*" ) );
				a.Sort();
				return a.ToArray();
			}
			return new string[] { };
		}
		string[] _ArchiveLogList()
		{
			if( Directory.Exists( archive.FullPath ) )
			{
				List<string> a = new List<string>( _ListFiles( archive.FullPath, ARCHIVE_PATTERN + @"*.log" ) );
				a.Sort();
				return a.ToArray();
			}
			return new string[] { };
		}

		string[] _ListDirectories( string dir )
		{
			return _ListDirectories( dir, @"*" );
		}
		string[] _ListDirectories( string dir, string pattern )
		{
			try
			{
				List<string> a = new List<string>();
				foreach( string x in Directory.GetDirectories( dir, pattern ) )
				{
					a.Add( Path.GetFileName( x ) );
				}
				return a.ToArray();
			}
			catch( Exception ex )
			{
				LogException( Function.LD, DisplayDirectory( dir ), ex );
			}
			return new string[] { };
		}
		string[] _ListFiles( string dir )
		{
			return _ListFiles( dir, @"*" );
		}
		string[] _ListFiles( string dir, string pattern )
		{
			try
			{
				List<string> a = new List<string>();
				foreach( string x in Directory.GetFiles( dir, pattern ) )
				{
					a.Add( Path.GetFileName( x ) );
				}
				return a.ToArray();
			}
			catch( Exception ex )
			{
				LogException( Function.LF, DisplayDirectory( dir ), ex );
			}
			return new string[] { };
		}
		bool _DirectoryCreateDirectory( string dir )
		{
			try
			{
				if( ! Directory.Exists( dir ) )
				{
					Directory.CreateDirectory( dir );
				}
				return true;
			}
			catch( Exception ex )
			{
				LogException( Function.DC, DisplayDirectory( dir ), ex );
			}
			return false;
		}
		bool _DirectoryMove( string src, string dst )
		{
			try
			{
#if true //tracking a bug in history processing
				if( Directory.Exists( dst ) )
				{
					LogInfo( "Directory already exists at destination [ " + dst + " ]" );
					_DirectoryDelete( dst, true );
				}
#endif
				Directory.Move( src, dst );
				return true;
			}
			catch( Exception ex )
			{
				LogException( Function.DM, DisplayCombined( DisplayDirectory( src ), DisplayDirectory( dst ) ), ex );
			}
			return false;
		}
		bool _DirectoryDelete( string dir, bool recursive )
		{
			try
			{
				Directory.Delete( dir, recursive );
				return true;
			}
			catch( Exception ex )
			{
				LogException( Function.DD, DisplayDirectory( dir ), ex );
			}
			return false;
		}
		bool _FileCopy( string src, string dst, bool replace )
		{
			try
			{
				File.Copy( src, dst, replace );

				//make sure the destination LastWriteTimeUtc matches the source (at least for the way we compare them).
				FileInfo fi = new FileInfo( dst );
				DateTime at = DateAdjust( File.GetLastWriteTimeUtc( src ) );
				if( ! DateCompare( DateAdjust( fi.LastWriteTimeUtc ), at ) )
				{
					bool b = fi.IsReadOnly;
					if( b ) { fi.IsReadOnly = false; }
					fi.LastWriteTimeUtc = at;
					if( b ) { fi.IsReadOnly = true ; }
				}
				return true;
			}
			catch( Exception ex )
			{
				LogException( Function.FC, DisplayCombined( src, dst ), ex );
			}
			return false;
		}
		bool _FileMove( string src, string dst )
		{
			try
			{
#if true //tracking a bug in history processing
				if( File.Exists( dst ) )
				{
					LogInfo( "FileMove. file already exists at destination " + DisplayCombined( src, dst ) + ", replacing" );
					_FileDelete( dst );
				}
#endif
				File.Move( src, dst );
				return true;
			}
			catch( Exception ex )
			{
				LogException( Function.FM, DisplayCombined( src, dst ), ex );
			}
			return false;
		}
		bool _FileDelete( string path )
		{
			try
			{
				{
					//check for read-only files
					FileInfo fi = new FileInfo( path );
					if( ! fi.Exists )
					{
						return true;
					}
					if( fi.IsReadOnly )
					{
						fi.IsReadOnly = false;
					}
				}
				File.Delete( path );
				return true;
			}
			catch( Exception ex )
			{
				LogException( Function.FD, path, ex );
			}
			return false;
		}
		FileInfo _FileInfo( string path )
		{
			try
			{
				return new FileInfo( path );
			}
			catch( Exception ex )
			{
				LogException( Function.FI, path, ex );
			}
			return null;
		}

		string _DateFolderMinute( DateTime date )
		{
			return date.ToString( @"yyyy-MM-dd-HHmm", DateTimeFormatInfo.InvariantInfo );
		}
		string _DateFolderSecond( DateTime date )
		{
			return date.ToString( @"yyyy-MM-dd-HHmmss", DateTimeFormatInfo.InvariantInfo );
		}
		int _DateFolderLength( MergeLevel level )
		{
			/* Separate out the parts of a DateFolder filename
			 * based on the merge level.
			 * 
			 *   yyyy-MM-dd HHmmss
			 *      |  |  |  | | |
			 *   12345678901234567
			 */
			switch( level )
			{
				case MergeLevel.Year  :  return  4;
				case MergeLevel.Month :  return  7;
				case MergeLevel.Day   :  return 10;
				case MergeLevel.Hour  :  return 13;
				case MergeLevel.Minute:  return 15;
				default               :  return 17;
			}
		}
		string _DateFolderSkipCurrent( MergeLevel level )
		{
			DateTime dt = DateTime.MinValue;
			switch( level )
			{
				case MergeLevel.Year  :  if( archive.Month  > 0 ) { dt = start.AddMonths  ( 0 - archive.Month  ); } break;
				case MergeLevel.Month :  if( archive.Day    > 0 ) { dt = start.AddDays    ( 0 - archive.Day    ); } break;
				case MergeLevel.Day   :  if( archive.Hour   > 0 ) { dt = start.AddHours   ( 0 - archive.Hour   ); } break;
				case MergeLevel.Hour  :  if( archive.Minute > 0 ) { dt = start.AddMinutes ( 0 - archive.Minute ); } break;
				case MergeLevel.Minute:  dt = start;                                                                break;
			}
			return (dt == DateTime.MinValue) ? null : _DateFolderSecond( dt );
		}



		void LogException( Function function, string path, Exception ex )
		{
			Log( Status( "[" + function + "] " + ExceptionMessage( ex ), path ) );
		}
		string ExceptionMessage( Exception ex )
		{
			switch( ex.GetType().FullName )
			{
				case "System.UnauthorizedAccessException":  return "not authorized";
				case "System.IO.PathTooLongException"    :  return "too long";
				case "System.IO.FileNotFoundException"   :  return "missing";
				case "System.IO.IOException"             :
				{
					PropertyInfo pi = ex.GetType().GetProperty( "HResult", BindingFlags.Instance | BindingFlags.NonPublic );
					uint         hr = (pi == null) ? 0 : (uint)(int)pi.GetValue( ex, null );
					switch( hr )
					{
						//VS Documentation: lookup "error codes [Win32]"

						case 0x80070005:  return "access denied"      ; //(Win32:  5) Access is denied.
						case 0x8007001F:  return "fault"              ; //(Win32: 31) A device attached to the system is not functioning.
						case 0x80070020:  return "in use"             ; //(Win32: 32) The process cannot access the file because it is being used by another process.
						case 0x80070057:  return "invalid parameter"  ; //(Win32: 87) The parameter is incorrect.
						case 0x80070091:  return "directory not empty"; //(Win32:145) The directory is not empty.
						case 0x800700B7:  return "file exists"        ; //(Win32:183) Cannot create a file when that file already exists.
						default        :  return "0x" + hr.ToString( "X" ) + ": " + ex.Message;
					}
				}
				default:  return ex.GetType().FullName + ": " + ex.Message;
			}
		}
		void LogDump( string status, string[] list )
		{
			foreach( string s in list )
			{
				LogStatus( "[" + status + "]", s );
			}
		}
		void LogStatus( string status, string filename )
		{
			Log( Status( status, filename ) );
		}
		void LogMatch( MatchSet.SetType type, MatchPath pattern, string path )
		{
			if( pattern.Debug )
			{
				path += "   (" + pattern.Pattern + ")";
			}
			Log( Status( 0, type, path ) );
		}
		void LogReason( Reason reason, string filename, bool occured )
		{
			if( occured )
			{
				Log( Status( reason, 0, filename ) );
				action( Action.Change, reason.ToString() );
			}
			else
			{
				action( Action.Skip, "" );
			}
		}
		void LogLegend()
		{
			Log( "Legend.." );
			for( int i = 0; i < ReasonValues.Length; ++i )
			{
				Log( Status( (Reason)ReasonValues.GetValue( i ), 0, "File " + ReasonNames[i] ) );
			}
			for( int i = 0; i < MatchValues.Length; ++i )
			{
				Log( Status( 0, (MatchSet.SetType)MatchValues.GetValue( i ), "Filter " + MatchNames[i] ) );
			}
		}
		void LogInfo( string message )
		{
			Log( message );
			action( Action.Info, message );
		}
		void Log( string message )
		{
			if( log != null )
			{
				log.WriteLine( message );
			}
		}


		string Status( string status, string filename )
		{
			if( status.Length < SECTION_DETAIL.Length )
			{
				status = (status + SECTION_DETAIL).Substring( 0, SECTION_DETAIL.Length );
			}
			return status + " " + filename;
		}
		string Status( Reason reason, MatchSet.SetType type, string filename )
		{

			StringBuilder sb = new StringBuilder();
			sb.Append( "  " );
			for( int i = 0; i < ReasonValues.Length; ++i )
			{
				Reason r = (Reason)ReasonValues.GetValue( i );
				sb.Append( (reason == r) ? ReasonNames[i][0] : BLANK );
			}
			sb.Append( "  " );
			for( int i = 0; i < MatchValues.Length; ++i )
			{
				MatchSet.SetType t = (MatchSet.SetType)MatchValues.GetValue( i );
				sb.Append( (type == t) ? MatchNames[i][0] : BLANK );
			}
			return Status( sb.ToString(), filename );
		}


		string DisplayDirectory( string path )
		{
			return MatchPath.EndsWithDirectorySeparator( path ) ? path : (path + Path.DirectorySeparatorChar.ToString() );
		}
		string DisplayCombined( string src, string dst )
		{
			return "[" + src + "] --> [" + dst + "]";
		}
		string DisplayDate( DateTime date )
		{
			return date.ToString( @"yyyy-MM-dd HH:mm:ss.ffff", DateTimeFormatInfo.InvariantInfo );
		}
		string DisplayTime( TimeSpan time )
		{
			return string.Format( "{0:D2}:{1:D2}:{2:D2}", time.Hours, time.Minutes, time.Seconds );
		}

		bool DateCompare( DateTime a, DateTime b )
		{
			/* the dates are checked to see if they are within 1 second of each other.
			 * this allows for differences in date handling for different filesystems.
			 */
			return (a.AddSeconds( -1 ) < b) && (a.AddSeconds( 1 ) > b);
		}
		DateTime DateAdjust( DateTime date )
		{
			// dates are adjusted to fit within the min and max bounds the archive file system supports.
			return (date < minDateUtc) ? minDateUtc : ((date > maxDateUtc) ? maxDateUtc : date);
		}

		//--- interface -------------------------

		#region IDisposable Members

		public void Dispose()
		{
			if( log != null )
			{
				log.Dispose();
				log = null;
			}
		}

		#endregion

		//--- end -------------------------------
	}
}
