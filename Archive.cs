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

		       const string  SECTION_DETAIL  = @"                    ";
		public const string  ARCHIVE_PATTERN = @"????-??-??-????";
		       const char    BLANK           = '-';

		public enum Action
		{
			Info,
			Directory,
			File,
			Change,
			Skip,
			Attribute,
		}
		public enum Reason
		{
			Created   = 0x01 << 0,
			Deleted   = 0x01 << 1,
			Attribute = 0x01 << 2,
			Written   = 0x01 << 3,
			Length    = 0x01 << 4,
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
			DirectoryGetDirectories,
			DirectoryGetFiles,
			DirectoryCreateDirectory,
			DirectoryMove,
			DirectoryDelete,
			FileCopy,
			FileMove,
			FileDelete,
			FileInfo,
		}

		const FileAttributes FILE_ATTRIBUTES_IGNORE = FileAttributes.Normal | FileAttributes.Archive | FileAttributes.Compressed | FileAttributes.NotContentIndexed | FileAttributes.ReparsePoint;

		public delegate void ActionDelegate( Action action, string text );

		//--- field -----------------------------
	
		ActionDelegate    action;
		CtrlArchive       archive;
		StreamWriter      log           = null;

		bool              cancel        = false;
#if false
		bool              ignoreCase    = false;
#endif

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

		public Archive( ActionDelegate action, CtrlArchive archive, bool create )
		{
			this.action   = action;
			this.archive  = archive;

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
#if false
			{
				/* Check if filesystem is case sensitive or not
				 * by creating a temporary file then attempting
				 * to access it using a different case name.
				 */
				string p = Path.Combine( archive.FullPath, "__TemporaryFile__.txt" );
				if( File.Exists( p.ToLower() ) )
				{
					File.Delete( p.ToLower() );
				}
				using( StreamWriter sw = File.CreateText( p ) )
				{
					sw.WriteLine( p );
				}
				this.ignoreCase = File.Exists( p.ToLower() );
				File.Delete( p );
				Log( "  filesystem " + (this.ignoreCase ? "is not" : "is") + " case sensitive." );
			}
#endif
			Log( "" );
			LogLegend();
			{
				/* move copy of control file in to backup folder
				 */
				string fp = Path.GetDirectoryName( archiveFilePath );
				string n  = Path.GetFileName     ( archiveFilePath );
				_BackupFile( fp, current, history, n, n, true );
				foreach( string s in _DirectoryGetFiles( current ) )
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
				List<string> a = new List<string>( _DirectoryGetDirectories( current ) );
				if( archive.Folders != null )
				{
					foreach( CtrlFolder folder in archive.Folders )
					{
						if( cancel ) { break; }
						Log( "" );
						Log( "Folder" );
						LogInfo( Status( folder.Name, folder.Path ) );
						_Backup( folder );
						foreach( string s in _DirectoryGetDirectories( current, folder.Name ) )
						{
							a.Remove( s );
						}
					}
				}
				if( ! cancel && (a.Count > 0) )
				{
					/* move any existing folders not in archive set to history
					 */
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
			LogInfo( Status( ".." + (cancel ? "cancelled" : "done     "), x.ToString() ) );
		}

		void _Backup( CtrlFolder folder )
		{
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
			if( ! include && inc.MatchDirectory( path ) ) { include = true ; }
			if(              exc.MatchDirectory( path ) ) { return    false; }
			if(   history && his.MatchDirectory( path ) ) { history = false; }

			if( cancel ) { return include; }
			string cp = Path.Combine( curr, path );
			if( ! Directory.Exists( cp ) )
			{
				//..if directory doesn't exist in current, then simply copy entire tree from folder.
				_CopyFolder( path, include );
				return include;
			}
			List<string> a = new List<string>( _DirectoryGetDirectories( cp ) );
			string fp = Path.Combine( fold, path );
			string hp = (hist == null) ? null : Path.Combine( hist, path );
			foreach( string n in _DirectoryGetDirectories( fp ) )
			{
				if( cancel ) { return include; }
				//..check each sub-directory in folder.
				if( _BackupCompareFolder( Path.Combine( path, n ), include, history ) )
				{
					foreach( string s in _DirectoryGetDirectories( cp, n ) )
					{
						a.Remove( s );
					}
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
						if( cancel ) { return include; }
						action( Action.File, n );
						string pn = Path.Combine( path, n );
						if( ! history || his.MatchDirectory( pn ) )
						{
							LogReason( Reason.Deleted, pn, _DirectoryDelete( Path.Combine( cp, n ) ) );
						}
						else
						{
							LogReason( Reason.Deleted, pn, _DirectoryMove( Path.Combine( cp, n ), Path.Combine( hp, n ) ) );
						}
					}
				}
			}

			a = new List<string>( _DirectoryGetFiles( cp ) );
			foreach( string n in _DirectoryGetFiles( fp ) )
			{
				if( cancel ) { return include; }
				string  pn  = Path.Combine( path, n );
				if( (include || inc.MatchFile( pn )) && ! exc.MatchFile( pn ) )
				{
					foreach( string s in _DirectoryGetFiles( cp, n ) )
					{
						a.Remove( s );
					}
					_BackupFile( fp, cp, hp, pn, n, history && ! his.MatchFile( pn ) );
				}
			}
			if( a.Count > 0 )
			{
				//..move deleted, renamed or excluded files from current to history.
				if( ! history || ((hp != null) && _DirectoryCreateDirectory( hp )) )
				{
					foreach( string n in a )
					{
						if( cancel ) { return include; }
						string pn = Path.Combine( path, n );
						if( ! _RemoveFile( cp, hp, pn, n, history && ! his.MatchFile( pn ) ) )
						{
							LogInfo( "History failure on file [" + n + "]" );
						}
					}
				}
			}
			return include;
		}

		void _BackupFile( string fp, string cp, string hp, string pn, string n, bool history )
		{
			string   cpn  = Path.Combine( cp, n );
			string   fpn  = Path.Combine( fp, n );

			FileInfo cfi  = _FileInfo( cpn );
			FileInfo ffi  = _FileInfo( fpn );
			if( (cfi == null) || (ffi == null) )
			{
				return;
			}
			if( ! cfi.Exists )
			{
				//..file does not exist in current, simply copy
				action( Action.File, n );
				LogReason( Reason.Created, pn, _FileCopy( fpn, cpn ) );
				return;
			}
			//..check for file property changes
			Reason r = 0;
			FileAttributes fa = (FileAttributes)((cfi.Attributes ^ ffi.Attributes) & ~(FILE_ATTRIBUTES_IGNORE));
			if( fa                   != 0                    ) { r |= Reason.Attribute; }
			if( cfi.LastWriteTimeUtc != ffi.LastWriteTimeUtc ) { r |= Reason.Written  ; }
			if( cfi.Length           != ffi.Length           ) { r |= Reason.Length   ; }
			if( r == 0 )
			{
				//..file has not changed, ignore
				return;
			}
			action( Action.File, n );
			if( fa != 0 )
			{
				action( Action.Attribute, fa.ToString() );
			}
#if false
			StringBuilder sb = new StringBuilder();
			if( cfi.Attributes        != ffi.Attributes        ) { sb.Append( " A["   +     cfi.Attributes.ToString() + "][" +     ffi.Attributes.ToString() + "]" ); }
			if( cfi.CreationTime      != ffi.CreationTime      ) { sb.Append( " C["   + dd( cfi.CreationTime )        + "][" + dd( ffi.CreationTime )        + "]" ); }
			if( cfi.CreationTimeUtc   != ffi.CreationTimeUtc   ) { sb.Append( " CU["  + dd( cfi.CreationTimeUtc )     + "][" + dd( ffi.CreationTimeUtc )     + "]" ); }
			if( cfi.IsReadOnly        != ffi.IsReadOnly        ) { sb.Append( " RO["  +     cfi.IsReadOnly.ToString() + "][" +     ffi.IsReadOnly.ToString() + "]" ); }
			if( cfi.LastAccessTime    != ffi.LastAccessTime    ) { sb.Append( " LA["  + dd( cfi.LastAccessTime )      + "][" + dd( ffi.LastAccessTime )      + "]" ); }
			if( cfi.LastAccessTimeUtc != ffi.LastAccessTimeUtc ) { sb.Append( " LAU[" + dd( cfi.LastAccessTimeUtc )   + "][" + dd( ffi.LastAccessTimeUtc )   + "]" ); }
			if( cfi.LastWriteTime     != ffi.LastWriteTime     ) { sb.Append( " LW["  + dd( cfi.LastWriteTime )       + "][" + dd( ffi.LastWriteTime )       + "]" ); }
			if( cfi.LastWriteTimeUtc  != ffi.LastWriteTimeUtc  ) { sb.Append( " LWU[" + dd( cfi.LastWriteTimeUtc )    + "][" + dd( ffi.LastWriteTimeUtc )    + "]" ); }
			if( cfi.Length            != ffi.Length            ) { sb.Append( " L["   +     cfi.Length.ToString()     + "][" +     ffi.Length.ToString()     + "]" ); }
			Log( sb.ToString() );
#endif

			//?? Is there a better way to do this combination that tests if a file can be copied first ??
			//..perhaps copy to a different file name first, move old file to history, rename copied file

			//..move old file from current to history
			if( ! history )
			{
				//..remove old file from current
				if( ! _FileDelete( cpn ) )
				{
					LogInfo( "failed to delete previous backup [" + cpn + "]" );
					action( Action.Skip, "" );
					return;
				}
				//..copy file to current
				LogReason( r, pn, _FileCopy( fpn, cpn ) );
				return;
			}
			if( (hp == null) || ! _DirectoryCreateDirectory( hp ) )
			{
				return;
			}
			//..move old file from current to history
			string hpn = Path.Combine( hp, n );
			if( ! _FileMove( cpn, hpn ) )
			{
				LogInfo( "failed moving current [" + cpn + "] to history [" + hpn + "]" );
				action( Action.Skip, "" );
				return;
			}
			//..copy new file from folder to current
			if( _FileCopy( fpn, cpn ) )
			{
				LogReason( r, pn, true );
				return;
			}
			//..if the file can not be copied, restore the old file from history to current
			if( ! _FileMove( hpn, cpn ) )
			{
				LogInfo( "failed moving history [" + hpn + "] back to current [" + cpn + "]" );
			}
			action( Action.Skip, "" );
		}
		bool _RemoveFile( string cp, string hp, string pn, string n, bool history )
		{
			action( Action.File, n );
			if( ! history )
			{
				LogReason( Reason.Deleted, pn, _FileDelete( Path.Combine( cp, n ) ) );
				return true;
			}
			if( (hp == null) || ! _DirectoryCreateDirectory( hp ) )
			{
				return true;
			}
			string hpn = Path.Combine( hp, n );
			if( File.Exists( hpn ) )
			{
				LogInfo( "file exists in history [" + hpn + "], replacing" );
				_FileDelete( hpn );
			}
			if( _FileMove( Path.Combine( cp, n ), hpn ) )
			{
				LogReason( Reason.Deleted, pn, true );
				return true;
			}
			LogInfo( "failed removing current [" + Path.Combine( cp, n ) + "] to history [" + Path.Combine( hp, n ) + "]" );
			action( Action.Skip, "" );
			return false;
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
			LogInfo( Status( ".." + (cancel ? "cancelled" : "done     "), x.ToString() ) );
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
				LogInfo( "Destination folder missing : " + dp );
				return false;
			}
			if( ! Directory.Exists( sp ) )
			{
				LogInfo( "Source folder missing : " + dp );
				return false;
			}
			bool ret = true;
			foreach( string n in _DirectoryGetDirectories( sp ) )
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
			foreach( string n in _DirectoryGetFiles( sp ) )
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
			if( ret )
			{
				ret &= _DirectoryDelete( sp );
			}
			return ret;
		}







		/// <summary>
		///		Copy a folder and all sub-folders as quickly as possible without
		///		checking their contents first.
		///		Before calling this function, make sure the destination folder
		///		does not already exist.
		/// </summary>
		void _CopyFolder( string path, bool include )
		{
			if( cancel ) { return; }
			if( ! include && inc.MatchDirectory( path ) ) { include = true; }
			if(              exc.MatchDirectory( path ) ) { return;         }
			string cp = Path.Combine( curr, path );
			LogReason( Reason.Created, path, true );
			if( ! include || _DirectoryCreateDirectory( cp ) )
			{
				string fp = Path.Combine( fold, path );
				foreach( string n in _DirectoryGetDirectories( fp ) )
				{
					if( cancel ) { return; }
					string p = Path.Combine( path, n );
					_CopyFolder( p, include );
				}
				action( Action.Directory, path );
//				action( Action.File, "" );
				foreach( string n in _DirectoryGetFiles( fp ) )
				{
					if( cancel ) { return; }
					string pn = Path.Combine( path, n );
					if( (include || inc.MatchFile( pn )) && ! exc.MatchFile( pn ) )
					{
						if( include || _DirectoryCreateDirectory( cp ) )
						{
							action( Action.File, n );
							LogReason( Reason.Created, pn, _FileCopy( Path.Combine( fp, n ), Path.Combine( cp, n ) ) );
						}
					}
				}
			}
		}

		string[] _ArchiveList()
		{
			if( Directory.Exists( archive.FullPath ) )
			{
				List<string> a = new List<string>( _DirectoryGetDirectories( archive.FullPath, ARCHIVE_PATTERN + @"*" ) );
				a.Sort();
				return a.ToArray();
			}
			return new string[] { };
		}
		string[] _ArchiveLogList()
		{
			if( Directory.Exists( archive.FullPath ) )
			{
				List<string> a = new List<string>( _DirectoryGetFiles( archive.FullPath, ARCHIVE_PATTERN + @"*.log" ) );
				a.Sort();
				return a.ToArray();
			}
			return new string[] { };
		}

		string[] _DirectoryGetDirectories( string dir )
		{
			return _DirectoryGetDirectories( dir, @"*" );
		}
		string[] _DirectoryGetDirectories( string dir, string pattern )
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
				LogException( Function.DirectoryGetDirectories, dir, ex );
			}
			return new string[] { };
		}
		string[] _DirectoryGetFiles( string dir )
		{
			return _DirectoryGetFiles( dir, @"*" );
		}
		string[] _DirectoryGetFiles( string dir, string pattern )
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
				LogException( Function.DirectoryGetFiles, dir, ex );
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
				LogException( Function.DirectoryCreateDirectory, dir, ex );
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
					_DirectoryDelete( dst );
				}
#endif
				Directory.Move( src, dst );
				return true;
			}
			catch( Exception ex )
			{
				LogException( Function.DirectoryMove, src, ex );
			}
			return false;
		}
		bool _DirectoryDelete( string dir )
		{
			try
			{
				Directory.Delete( dir );
				return true;
			}
			catch( Exception ex )
			{
				LogException( Function.DirectoryDelete, dir, ex );
			}
			return false;
		}
		bool _FileCopy( string src, string dst )
		{
			try
			{
				File.Copy( src, dst );
#if true //this is only necessary under Linux, not Windows
				FileInfo fi = new FileInfo( dst );
				DateTime at = File.GetLastWriteTimeUtc( src );
				if( fi.LastWriteTimeUtc != at )
				{
					bool b = fi.IsReadOnly;
					if( b ) { fi.IsReadOnly = false; }
					fi.LastWriteTimeUtc = at;
					if( b ) { fi.IsReadOnly = true ; }
				}
#endif
				return true;
			}
			catch( Exception ex )
			{
				LogException( Function.FileCopy, src, ex );
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
					LogInfo( "File already exists at destination [ " + dst + " ]" );
					_FileDelete( dst );
				}
#endif
				File.Move( src, dst );
				return true;
			}
			catch( Exception ex )
			{
				LogException( Function.FileMove, src, ex );
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
				LogException( Function.FileDelete, path, ex );
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
				LogException( Function.FileInfo, path, ex );
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
			// yyyy-MM-dd HHmmss
			//    |  |  |  | | |
			// 12345678901234567
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
			string fn;
			switch( function )
			{
				case Function.DirectoryGetDirectories :  fn = "LD";  break;
				case Function.DirectoryGetFiles       :  fn = "LF";  break;
				case Function.DirectoryCreateDirectory:  fn = "DC";  break;
				case Function.DirectoryMove           :  fn = "DM";  break;
				case Function.DirectoryDelete         :  fn = "DD";  break;
				case Function.FileCopy                :  fn = "FC";  break;
				case Function.FileMove                :  fn = "FM";  break;
				case Function.FileDelete              :  fn = "FD";  break;
				case Function.FileInfo                :  fn = "FI";  break;
				default                               :  fn = "??";  break;
			}
			string msg;
			switch( ex.GetType().FullName )
			{
				case "System.UnauthorizedAccessException":
				{
					msg = "not authorized";
					break;
				}
				case "System.IO.PathTooLongException":
				{
					msg = "too long";
					break;
				}
				case "System.IO.FileNotFoundException":
				{
					msg = "missing";
					break;
				}
				case "System.IO.IOException":
				{
					PropertyInfo pi = ex.GetType().GetProperty( "HResult", BindingFlags.Instance | BindingFlags.NonPublic );
					uint         hr = (pi == null) ? 0 : (uint)(int)pi.GetValue( ex, null );
					switch( hr )
					{
						//VS Documentation: lookup "error codes [Win32]"

						case 0x80070005:  //(Win32:5) Access is denied.
							msg = "access denied";  break;
						case 0x8007001F:  //(Win32:31) A device attached to the system is not functioning.
							msg = "fault";  break;
						case 0x80070020:  //(Win32:32) The process cannot access the file because it is being used by another process.
							msg = "in use";  break;
						case 0x800700B7:  //(Win32:183) Cannot create a file when that file already exists.
							msg = "file exists";  break;
						default:
							msg = "0x" + hr.ToString( "X" ) + ": " + ex.Message;  break;
					}
					break;
				}
				default:
				{
					msg = ex.GetType().FullName + ": " + ex.Message;
					break;
				}
			}
			Log( Status( "[" + fn + "] " + msg, path ) );
		}
		void LogDump( string status, string[] list )
		{
			foreach( string s in list )
			{
				Log( Status( "[" + status + "]", s ) );
			}
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
				Log( Status( (Reason)ReasonValues.GetValue( i ), 0, ReasonNames[i] ) );
			}
			for( int i = 0; i < MatchValues.Length; ++i )
			{
				Log( Status( 0, (MatchSet.SetType)MatchValues.GetValue( i ), MatchNames[i] ) );
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
				sb.Append( ((reason & r) == r) ? ReasonNames[i][0] : BLANK );
			}
			sb.Append( "  " );
			sb.Append( (type == 0) ? BLANK : (char)type );
			return Status( sb.ToString(), filename );
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
