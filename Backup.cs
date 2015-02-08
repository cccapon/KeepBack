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

/*
	When compiling under Mono - include reference to Mono.Posix
*/

#if true //tracking a bug in history processing
#define CHECK_HISTORY_BUG
#endif

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace KeepBack
{
	public class Backup
	{
		//--- define ----------------------------

		const int Maximum_Items_In_Queue = 999; //maximum # of files and folders waiting to be updated at a time
		const int Thread_Cancel_Timeout  =  60; //# of seconds to await for threads to respond to cancellation

		const string        ExArchiveRoot          = "Backup.Archive.Root";
		const string        ExCurrentRoot          = "Backup.Current.Root";
		const string        ExCurrentPath          = "Backup.Current.Path";
		const string        ExCurrentFilename      = "Backup.Current.Filename";
		const string        ExHistoryRoot          = "Backup.History.Root";
		const string        ExHistoryPath          = "Backup.History.Path";
		const string        ExHistoryFilename      = "Backup.History.Filename";
		const string        ExFolderName           = "Backup.Folder.Name";
		const string        ExFolderRoot           = "Backup.Folder.Root";
		const string        ExFolderPath           = "Backup.Folder.Path";
		const string        ExFolderFilename       = "Backup.Folder.Filename";
		const string        ExPath                 = "Backup.Path";
		const string        ExFilename             = "Backup.Filename";
		const string        ExUpdateAction         = "Backup.Update.Action";
		const string        ExUpdatePath           = "Backup.Update.Path";
		const string        ExUpdateFilename       = "Backup.Update.Filename";

		enum ActionType
		{
			None = 0,
			Copy,
			Delete,
		}

		enum StatusType : int
		{
			Created  = 0,
			Modified = 1,
			Deleted  = 2,
			Skipped  = 3,
		}

		class FolderInfo
		{
			string   name;
			string   root;
			MatchSet filters = null;

			public string Name { get { return name; } }
			public string Root { get { return root; } }

			public FolderInfo( string name, string root )
			{
				this.name = name;
				this.root = root;
			}
			public FolderInfo( CtrlFolder f, bool isCaseSensitive ) : this( f.Name, f.Path )
			{
				filters = new MatchSet( f.Filters, isCaseSensitive );
			}
			public bool IsHistoryFolder ( string path ) { return (filters != null) ? filters.IsHistoryFolder ( path ) : true; }
			public bool IsHistoryFile   ( string path ) { return (filters != null) ? filters.IsHistoryFile   ( path ) : true; }
			public bool IsIncludedFolder( string path ) { return (filters != null) ? filters.IsIncludedFolder( path ) : true; }
			public bool IsIncludedFile  ( string path ) { return (filters != null) ? filters.IsIncludedFile  ( path ) : true; }
		}

		struct UpdateRequest
		{
			public ActionType      action;
			public FolderInfo      folder;
			public string          path;
			public string          filename;

			public UpdateRequest( ActionType action, FolderInfo folder, string path, string filename )
			{
				this.action     = action;
				this.folder     = folder;
				this.path       = path;
				this.filename   = filename;
			}
		}

		public class BackupStatus
		{
			public struct Scan
			{
				public string  current;
				public long    folders;
				public long    files;
			}
			public struct Update
			{
				public string  current;
				public long    created;
				public long    modified;
				public long    deleted;
				public long    skipped;
			}
			public Scan   scan;
			public Update update;

			public string ToString( long val )
			{
				return (val <= 0) ? string.Empty : val.ToString( "N0" );
			}
		}

		public delegate void MessageDelegate( string msg );

		//--- field -----------------------------

		MessageDelegate                   message;

		Ctrl                              ctrl            = null;
		bool                              debug           = false;
		BlockingCollection<UpdateRequest> queue           = null;
		BackupStatus                      status          = null;
		CancellationTokenSource           cancel          = null;
		DateTime                          start           = DateTime.MinValue;

		StreamWriter                      log             = null;
		string                            current         = null;
		string                            history         = null;

		Thread                            scan            = null;
		Thread                            update          = null;

		char[]                            InvalidFilenameCharacters = System.IO.Path.GetInvalidFileNameChars();
		char[]                            InvalidPathCharacters     = System.IO.Path.GetInvalidPathChars();

		//--- property --------------------------

		public TimeSpan     Elapsed  { get { return DateTime.Now - start; } }
		public BackupStatus Status   { get { return status; } }
		public int          Pending  { get { return queue.Count; } }
		public bool         IsFinished { get { return ((scan == null) && (update == null)); } }

		//--- constructor -----------------------

		public Backup( MessageDelegate message )
		{
			this.message  = message;
		}

		//--- method ----------------------------

		public bool Process( Ctrl ctrl, bool debug )
		{
			try
			{
				this.queue   = new BlockingCollection<UpdateRequest>( Maximum_Items_In_Queue );
				this.ctrl    = ctrl;
				this.debug   = debug;
				this.status  = new BackupStatus();
				this.cancel  = new CancellationTokenSource();
				this.start   = DateTime.Now;

				this.log     = null;
				this.current = null;
				this.history = null;

				this.scan    = new Thread( new ThreadStart( ScanHandler   ) );
				this.update  = new Thread( new ThreadStart( UpdateHandler ) );
				this.scan  .Name     = "Scan";
				this.update.Name     = "Change";
				this.scan  .Priority = ThreadPriority.BelowNormal;
				this.update.Priority = ThreadPriority.BelowNormal;
				this.scan  .Start();
				this.update.Start();
				return true;
			}
			catch( Exception ex )
			{
				Msg( "Process: {0}", Except.ToString( ex, debug ) );
				Terminate();
			}
			return false;
		}

		public void Terminate()
		{
			Cancel();
			Finished();
		}

		public void Cancel()
		{
			if( cancel != null )
			{
				try
				{
					cancel.Cancel();
					Msg( "..operation cancelled" );
				}
				catch( Exception ex )
				{
					Msg( "Cancel: {0}", Except.ToString( ex, debug ) );
				}
			}
		}

		public void Finished()
		{
			try
			{
				if( log != null )
				{
					Log( string.Empty );
					Log( "{0} - Elapsed", Ctrl.FormatTimeSpan( Elapsed ) );

					Log( "Scanned  {0:N0} folders, {1:N0} files", status.scan.folders, status.scan.files );
					Log( "Updated  {0:N0} created, {1:N0} modified, {2:N0} deleted, {3:N0} skipped", status.update.created, status.update.modified, status.update.deleted, status.update.skipped );

					log.Close();
					log.Dispose();
					log = null;
					Msg( "Finished: log closed." );
				}
			}
			catch( Exception ex )
			{
				Msg( "Finished: {0}", Except.ToString( ex, debug ) );
			}
		}


		//--- method ----------------------------

		void ScanHandler()
		{
			try
			{
				Msg( "Scan: begins" );
				Scan();
			}
			catch( Exception ex )
			{
				Msg( "Scan: {0}", Except.ToString( ex, debug ) );
				Cancel();
			}
			finally
			{
				scan = null;
				queue.CompleteAdding();
				Msg( "Scan: {0}", cancel.IsCancellationRequested ? "cancelled" : "complete" );
			}
		}

		void Scan()
		{
			try
			{
				//..create a log file for this backup
				log = ctrl.CreateLogFile( start );
				Msg( "Archive: {0}", ctrl.Path );
				//..check the archive path's drive properties
				ctrl.TestArchiveDriveProperties();
				//..create a date/time based folder name for this backup
				current = Ctrl.DateFolder( start, Ctrl.DateFolderLevel.Second );
				{
					//..find the most recent date/time backup history folder
					string[] a = ctrl.HistoryFolders();
					//..if none exist, invent one for a time 1 second prior to our current folder
					history = (a.Length > 0) ? a[a.Length -1] : Ctrl.DateFolder( start.AddSeconds( -1.0 ), Ctrl.DateFolderLevel.Second );
					//..make sure the new backup folder is more recent than the last one
					if( string.Compare( current, history ) <= 0 )
					{
						throw new Exception( "Scan: current folder is not newer than history folder" );
					}
				}
				Msg( "History: {0}", history );
				Msg( "Current: {0}", current );
				current = PathCombine( ctrl.Path, current );
				history = PathCombine( ctrl.Path, history );
				if( debug )
				{
					Log( ".s.current folder [{0}]", current );
					Log( ".s.history folder [{0}]", history );
				}
				if( DirectoryExists( history ) )
				{
					try
					{
						if( debug ) { Log( ".s.move history to current" ); }
						DirectoryMove( history, current );
					}
					catch( Exception ex )
					{
						throw new Exception( "Scan: can not rename history folder to current", ex );
					}
				}

				//..check Archive.keep for changes, submit a copy request if changed.
				try
				{
					string n = PathFilename( ctrl.Filename );
					FileInfo fi = new FileInfo( ctrl.Filename );
					FileInfo ci = new FileInfo( PathCombine( current, n ) );
					if( debug ) { Log( ".s.check if control file has been updated [{0}]", fi.FullName ); }
					if( ! ci.Exists || ! ctrl.FileDateMatches( fi.LastWriteTimeUtc, ci.LastWriteTimeUtc ) || (fi.Length != ci.Length) )
					{
						if( debug ) { Log( ".s.control file changed" ); }
						FolderInfo fo = new FolderInfo( string.Empty, ctrl.Path );
						ScanQueue( ActionType.Copy, fo, string.Empty, n );
					}
				}
				catch( Exception ex )
				{
					ex.Data[ExCurrentRoot] = current;
					ex.Data[ExFilename] = ctrl.Filename;
					throw new Exception( "Scan: failed while checking archive control file", ex );
				}

				CtrlArchive archive = ctrl.Archive;
				if( archive != null )
				{
					bool b = true;
					//..backup each folder in archive set
					if( debug ) { Log( ".s.build list of existing folders in current" ); }
					List<string> a = DirectoryExists( current ) ? Ctrl.ListDirectories( current ) : new List<string>();
					if( archive.Folders != null )
					{
						foreach( CtrlFolder f in archive.Folders )
						{
							try
							{
								Scan( f );
								ListFilenameRemove( a, f.Name );
							}
							catch( Exception ex )
							{
								string s = string.Format( "Scan: {0}", Except.ToString( ex, debug ) );
								Msg( s );
								b = false;
							}
						}
					}

					//..move folders which are no longer part of the backup folder set to history
					if( b && ! cancel.IsCancellationRequested && (a.Count > 0) )
					{
						if( debug ) { Log( ".s.remove folders from current which are not part of backup set" ); }
						foreach( string n in a )
						{
							if( debug ) { Log( "  .s.remove [{0}]", n ); }
							FolderInfo f = new FolderInfo( n, null );
							Log( string.Empty );
							Msg( "Folder: {0}", f.Name );
							//..delete/archive folders which are no longer part of the backup set
							ScanQueue( ActionType.Delete, f, string.Empty, null );
						}
					}
				}
			}
			catch( Exception ex )
			{
				ex.Data[ExArchiveRoot] = ctrl.Path;
				ex.Data[ExCurrentRoot] = current;
				ex.Data[ExHistoryRoot] = history;
				throw;
			}
			finally
			{
				status.scan.current = string.Empty;
			}
		}

		void Scan( CtrlFolder folder )
		{
			try
			{
				FolderInfo	f = new FolderInfo( folder, ctrl.IsCaseSensitive );
				Log( string.Empty );
				Msg( "Folder: {0} : {1}", f.Name, f.Root );
				if( string.IsNullOrEmpty( f.Name ) )
				{
					throw new Exception( "Folder name is empty." );
				}
				if( f.Name.IndexOfAny( InvalidFilenameCharacters ) >= 0 )
				{
					throw new Exception( "Folder name contains invalid characters." );
				}
				if( string.IsNullOrEmpty( f.Root ) )
				{
					throw new Exception( "Folder path is empty." );
				}
				if( f.Root.IndexOfAny( InvalidPathCharacters ) >= 0 )
				{
					throw new Exception( "Folder path contains invalid characters." );
				}
				ScanFolder( f, string.Empty );
			}
			catch( Exception ex )
			{
				ex.Data[ExArchiveRoot]    = ctrl.Path;
				ex.Data[ExCurrentRoot]    = current;
				ex.Data[ExHistoryRoot]    = history;
				ex.Data[ExFolderName]     = folder.Name;
				ex.Data[ExFolderRoot]     = folder.Path;
				throw;
			}
		}

		void ScanFolder( FolderInfo folder, string path )
		{
			try
			{
				//..record current location
				string s = MatchPath.AbsoluteDirectoryPath( path ?? string.Empty );
				status.scan.current = folder.Name + ":" + s;
				if( debug ) { Log( ".s.scan path [{0}]", s ); }
				Interlocked.Increment( ref status.scan.folders );

				//..check if cancelled
				if( cancel.IsCancellationRequested )
				{
					throw new Exception( "Scan cancelled." );
				}
				if( ! folder.IsIncludedFolder( path ) )
				{
					if( debug ) { Log( "  .s.not included" ); }
					return;
				}

				//..find out if folder path exists
				string fp = PathCombine( folder.Root, path );
				if( debug ) { Log( ".s.folder path [{0}]", fp ); }
				try
				{
#if __MonoCS__
					{
						Mono.Unix.UnixSymbolicLinkInfo i = new Mono.Unix.UnixSymbolicLinkInfo( fp );
						if( ! i.Exists || ! i.IsDirectory )
						{
							return;
						}
					}
#endif
					if( ! DirectoryExists( fp ) )
					{
						throw new DirectoryNotFoundException( "Folder path does not exist." );
					}

					//..find out if path exists in current
					string cp = PathCombine( current, folder.Name, path );
					if( debug ) { Log( ".s.current path [{0}]", cp ); }
					try
					{
						if( ! DirectoryExists( cp ) ) 
						{
							if( debug ) { Log( ".s.current path absent, copy everything" ); }
							//..when the folder does not exist in current, copy everything without comparing
							ScanQueue( ActionType.Copy, folder, path, null );
							return;
						}

						List<string> a;

						//..scan files first
						if( debug ) { Log( ".s.-----> files [{0}]", MatchPath.AbsoluteDirectoryPath( path ?? string.Empty ) ); }
						a = new List<string>( Ctrl.ListFiles( cp ) );
						foreach( string n in Ctrl.ListFiles( fp ) )
						{
							try
							{
								if( cancel.IsCancellationRequested )
								{
									throw new Exception( "Scan cancelled." );
								}
								Interlocked.Increment( ref status.scan.files );
								string pn = PathCombine( path, n );
								if( debug ) { Log( ".s.file [{0}]", pn ); }
								if( folder.IsIncludedFile( pn ) )
								{
									if( debug ) { Log( ".s.is included" ); }
									string fpn = PathCombine( fp, n );
									try
									{
#if __MonoCS__
										Mono.Unix.UnixSymbolicLinkInfo i = new Mono.Unix.UnixSymbolicLinkInfo( fpn );
										if( i.Exists && i.IsRegularFile )
#endif
										{
											string cpn = PathCombine( cp, n );
											try
											{
												FileInfo fi = new FileInfo( fpn );
												FileInfo ci = new FileInfo( cpn );
												if( debug ) { Log( ".s.compare folder file [{0}]\n          with current [{1}]", fpn, cpn ); }
												if( ! ci.Exists || ! ctrl.FileDateMatches( fi.LastWriteTimeUtc, ci.LastWriteTimeUtc ) || (fi.Length != ci.Length) )
												{
													if( debug ) { Log( ".s.file has changed" ); }
													ScanQueue( ActionType.Copy, folder, path, n );
												}
												ListFilenameRemove( a, n );
											}
											catch( Exception ex )
											{
												ex.Data[ExFolderFilename ] = fpn;
												ex.Data[ExCurrentFilename] = cpn;
												Log( "Scan {0}", Except.ToString( ex, debug ) );
												Interlocked.Increment( ref status.update.skipped );
												LogStatus( StatusType.Skipped, folder.Name, path, n );
											}
										}
									}
									catch( Exception ex )
									{
										ex.Data[ExFolderFilename] = fpn;
										throw;
									}
								}
							}
							catch( Exception ex )
							{
								ex.Data[ExFilename] = n;
								throw;
							}
						}
						if( a.Count > 0 )
						{
							if( debug ) { Log( ".s.flag deleted files for removal" ); }
							foreach( string n in a )
							{
								if( debug ) { Log( ".s.deleted file [{0}]", n ); }
								ScanQueue( ActionType.Delete, folder, path, n );
							}
						}

						//..scan folders second
						if( debug ) { Log( ".s.-----> directories [{0}]", MatchPath.AbsoluteDirectoryPath( path ?? string.Empty ) ); }
						a = new List<string>( Ctrl.ListDirectories( cp ) );
						foreach( string n in Ctrl.ListDirectories( fp ) )
						{
							if( cancel.IsCancellationRequested )
							{
								throw new Exception( "Scan cancelled." );
							}
							string pn = PathCombine( path, n );
							if( debug ) { Log( ".s.directory [{0}]", pn ); }
							ScanFolder( folder, pn );
							ListFilenameRemove( a, n );
						}
						if( a.Count > 0 )
						{
							if( debug ) { Log( ".s.flag deleted directories for removal" ); }
							foreach( string n in a )
							{
								if( debug ) { Log( ".s.deleted directory [{0}]", n ); }
								ScanQueue( ActionType.Delete, folder, PathCombine( path, n ), null );
							}
						}
					}
					catch( Exception ex )
					{
						ex.Data[ExCurrentPath] = cp;
						throw;
					}
				}
				catch( Exception ex )
				{
					ex.Data[ExFolderPath] = fp;
					throw;
				}
			}
			catch( Exception ex )
			{
				ex.Data[ExPath] = path;
				Msg( "Scan: {0}", Except.ToString( ex, debug ) );
			}
		}

		void ScanQueue( ActionType action, FolderInfo folder, string path, string filename )
		{
			queue.Add( new UpdateRequest( action, folder, path, filename ), cancel.Token );
		}


		//--- method ----------------------------

		void UpdateHandler()
		{
			try
			{
				Msg( "Update: waiting" );
				for( ;; )
				{
					UpdateRequest ur = queue.Take( cancel.Token );
					try
					{
						Update( ur );
					}
					catch( Exception ex )
					{
						ex.Data[ExArchiveRoot] = ctrl.Path;
						ex.Data[ExCurrentRoot] = current;
						ex.Data[ExHistoryRoot] = history;
						Msg( "Update: {0}", Except.ToString( ex, debug ) );
					}
				}
			}
			catch( InvalidOperationException ex )
			{
				if( ! queue.IsCompleted )
				{
					Msg( "Update: {0}", Except.ToString( ex, debug ) );
					Cancel();
				}
			}
			catch( Exception ex )
			{
				Msg( "Update: {0}", Except.ToString( ex, debug ) );
				Cancel();
			}
			finally
			{
				if( ! string.IsNullOrEmpty( history ) && DirectoryExists( history ) )
				{
					if( debug ) { Log( ".u.remove empty history folders [{0}]", history ); }
					RemoveEmptyHistoryFolder( string.Empty );
				}
				status.update.current = string.Empty;
				update = null;
				Msg( "Update: {0}", (cancel.IsCancellationRequested || ! queue.IsCompleted) ? "cancelled" : "complete" );
			}
		}

		void Update( UpdateRequest ur )
		{
			try
			{
				FolderInfo folder = ur.folder;
				status.update.current = folder.Name + ":" + MatchPath.AbsoluteDirectoryPath( ur.path ?? string.Empty ) + (ur.filename ?? string.Empty);
				if( debug ) { Log( ".u.update operation: {0} [{1}:{2}] [{3}{4}]", ur.action, ur.folder.Name ?? string.Empty, ur.folder.Root ?? string.Empty, MatchPath.AbsoluteDirectoryPath( ur.path ?? string.Empty ), ur.filename ?? string.Empty ); }
				string cp = PathCombine( current, folder.Name, ur.path );
				string hp = PathCombine( history, folder.Name, ur.path );
				if( debug )
				{
					Log( ".u.current path [{0}]", cp );
					Log( ".u.history path [{0}]", hp );
				}
				try
				{
					bool   bc = Directory.Exists( cp );

					if( string.IsNullOrEmpty( ur.filename ) )
					{
						//..process folder
						if( bc )
						{
							string p = PathDirectory( hp );
							if( debug ) { Log( ".u.create history folder" ); }
							DirectoryCreate( p );
							if( DirectoryExists( hp ) )
							{
								if( debug ) { Log( ".u.delete history folder" ); }
								DirectoryDelete( hp, true );
							}
							if( debug ) { Log( ".u.move current to history" ); }
							DirectoryMove( cp, hp );
						}
						switch( ur.action )
						{
							case ActionType.Copy:
							{
								if( debug ) { Log( ".u.recursive copy [{0}:{1}] path [{2}] to current.", folder.Name, folder.Root, ur.path ); }
								RecursiveCopy( folder, ur.path );
								break;
							}
							case ActionType.Delete:
							{
								if( bc )
								{
									if( debug ) { Log( ".u.recursive delete history [{0}]", hp ); }
									RecursiveDelete( folder, ur.path );
								}
								break;
							}
						}
						if( bc && ! folder.IsHistoryFolder( ur.path ) )
						{
							if( debug ) { Log( ".u.delete history folder" ); }
							DirectoryDelete( hp, true );
						}
					}
					else
					{
						//..process file
						string cpn = PathCombine( cp, ur.filename );
						string hpn = PathCombine( hp, ur.filename );
						if( debug ) { Log( ".u.current file [{0}]", cpn ); }
						if( debug ) { Log( ".u.history file [{0}]", hpn ); }
						try
						{
							bool bcf = false;
							if( bc )
							{
								bcf = FileExists( cpn );
								if( bcf )
								{
									if( debug ) { Log( ".u.create history folder" ); }
									DirectoryCreate( hp );
									if( debug ) { Log( " .u.delete history file" ); }
									FileDelete( hpn );
									if( debug ) { Log( " .u.move current to history" ); }
									FileMove( cpn, hpn );
								}
							}
							switch( ur.action )
							{
								case ActionType.Copy:
								{
									if( ! bc )
									{
										if( debug ) { Log( ".u.create current folder" ); }
										DirectoryCreate( cp );
									}
									string n = PathCombine( folder.Root, ur.path, ur.filename );
									if( debug ) { Log( " .u.copy file to current" ); }
									try
									{
										FileCopy( n, cpn );
										if( bcf )
										{
											Interlocked.Increment( ref status.update.modified );
											LogStatus( StatusType.Modified, folder.Name, ur.path, ur.filename );
										}
										else
										{
											Interlocked.Increment( ref status.update.created );
											LogStatus( StatusType.Created, folder.Name, ur.path, ur.filename );
										}
									}
									catch( Exception ex )
									{
										Log( "Update {0}", Except.ToString( ex, debug ) );
										Interlocked.Increment( ref status.update.skipped );
										LogStatus( StatusType.Skipped, folder.Name, ur.path, ur.filename );
									}
									break;
								}
								case ActionType.Delete:
								{
									if( bcf )
									{
										Interlocked.Increment( ref status.update.deleted );
										LogStatus( StatusType.Deleted, folder.Name, ur.path, ur.filename );
									}
									break;
								}
							}
							if( bcf && ! folder.IsHistoryFile( PathCombine( ur.path, ur.filename ) ) )
							{
								if( debug ) { Log( ".u.delete history" ); }
								FileDelete( hpn );
							}
						}
						catch( Exception ex )
						{
							ex.Data[ExCurrentFilename] = cpn;
							ex.Data[ExHistoryFilename] = hpn;
							throw;
						}
					}
				}
				catch( Exception ex )
				{
					ex.Data[ExCurrentPath] = cp;
					ex.Data[ExHistoryPath] = hp;
					throw;
				}
			}
			catch( Exception ex )
			{
				if( ur.action != ActionType.None )
				{
					ex.Data[ExUpdateAction]   = ur.action;
					ex.Data[ExUpdatePath]     = ur.path;
					ex.Data[ExUpdateFilename] = ur.filename;
					if( ur.folder != null )
					{
						ex.Data[ExFolderName]     = ur.folder.Name;
						ex.Data[ExFolderRoot]     = ur.folder.Root;
					}
				}
				throw;
			}
		}

		void RemoveEmptyHistoryFolder( string path )
		{
			try
			{
				if( debug ) { Log( ".u.check folder [{0}]", path ); }
				string fp = PathCombine( history, path );
				foreach( string s in Ctrl.ListDirectories( fp ) )
				{
					RemoveEmptyHistoryFolder( PathCombine( path, s ) );
				}
				DirectoryInfo di = new DirectoryInfo( fp );
				if( di.GetFileSystemInfos().Length <= 0 )
				{
					if( debug ) { Log( ".u.folder [{0}] is empty", path ); }
					di.Delete();
				}
			}
			catch( Exception ex )
			{
				ex.Data[ExHistoryRoot] = history;
				ex.Data[ExPath] = path;
				Msg( "Update: remove empty folders: {0}", Except.ToString( ex, debug ) );
			}
		}

		void RecursiveCopy( FolderInfo folder, string path )
		{
			try
			{
				string s = folder.Name + ":" + MatchPath.AbsoluteDirectoryPath( path ?? string.Empty );
				status.update.current = s;
				if( debug ) { Log( ".u.recursive copy [{0}]", s ); }

				//..check if cancelled
				if( cancel.IsCancellationRequested )
				{
					throw new Exception( "Update cancelled." );
				}
				if( ! folder.IsIncludedFolder( path ) )
				{
					if( debug ) { Log( ".u.not included", path ); }
					return;
				}
				string fp = PathCombine( folder.Root, path );
				if( debug ) { Log( ".u.folder path [{0}]", fp ); }
				try
				{
#if __MonoCS__
					{
						Mono.Unix.UnixSymbolicLinkInfo i = new Mono.Unix.UnixSymbolicLinkInfo( fp );
						if( ! i.Exists || ! i.IsDirectory )
						{
							return;
						}
					}
#endif
					if( ! DirectoryExists( fp ) )
					{
						throw new Exception( "Folder path does not exist." );
					}

					string cp = PathCombine( current, folder.Name, path );
					if( debug ) { Log( ".u.current path [{0}]", cp ); }
					try
					{
						if( debug ) { Log( ".u.create current directory" ); }
						DirectoryCreate( cp );

						//..copy all included files at this level
						if( debug ) { Log( ".u.-----> files [{0}]", MatchPath.AbsoluteDirectoryPath( path ?? string.Empty ) ); }
						foreach( string n in Ctrl.ListFiles( fp ) )
						{
							try
							{
								status.update.current = folder.Name + ":" + MatchPath.AbsoluteDirectoryPath( path ?? string.Empty ) + n;
								if( cancel.IsCancellationRequested )
								{
									throw new Exception( "Update cancelled." );
								}
								string pn = PathCombine( path, n );
								if( debug ) { Log( ".u.file [{0}]", pn ); }
								if( folder.IsIncludedFile( pn ) )
								{
									if( debug ) { Log( ".u.is included" ); }
									string fpn = PathCombine( fp, n );
									try
									{
#if __MonoCS__
										Mono.Unix.UnixSymbolicLinkInfo i = new Mono.Unix.UnixSymbolicLinkInfo( fpn );
										if( i.Exists && i.IsRegularFile )
#endif
										{
											string cpn = PathCombine( cp, n );
											try
											{
												if( debug ) { Log( ".u.copy folder file to current" ); }
												FileCopy( fpn, cpn );
												LogStatus( StatusType.Created, folder.Name, path, n );
												Interlocked.Increment( ref status.update.created );
											}
											catch( Exception ex )
											{
												ex.Data[ExCurrentFilename] = cpn;
												Log( "Update {0}", Except.ToString( ex, debug ) );
												Interlocked.Increment( ref status.update.skipped );
												LogStatus( StatusType.Skipped, folder.Name, path, n );
											}
										}
									}
									catch( Exception ex )
									{
										ex.Data[ExFolderFilename] = fpn;
										throw;
									}
								}
							}
							catch( Exception ex )
							{
								ex.Data[ExFilename] = n;
								throw;
							}
						}

						//..recursively copy all subdirectories at this level
						if( debug ) { Log( ".u.-----> directories [{0}]", MatchPath.AbsoluteDirectoryPath( path ?? string.Empty ) ); }
						foreach( string n in Ctrl.ListDirectories( fp ) )
						{
							string pn = PathCombine( path, n );
							if( debug ) { Log( ".u.directory [{0}]", pn ); }
							RecursiveCopy( folder, pn );
						}
					}
					catch( Exception ex )
					{
						ex.Data[ExCurrentPath] = cp;
						throw;
					}
				}
				catch( Exception ex )
				{
					ex.Data[ExFolderPath] = fp;
					throw;
				}
			}
			catch( Exception ex )
			{
				ex.Data[ExPath] = path;
				Msg( "Update: {0}", Except.ToString( ex, debug ) );
			}
		}

		void RecursiveDelete( FolderInfo folder, string path )
		{
			/* This method does not actually delete files, it merely counts the number of files
			 * moved from Current to History - as in, flagged for deletion
			 */
			try
			{
				string s = folder.Name + ":" + MatchPath.AbsoluteDirectoryPath( path ?? string.Empty );
				status.update.current = s;
				if( debug ) { Log( ".u.recursive delete [{0}]", s ); }

				//..check if cancelled
				if( cancel.IsCancellationRequested )
				{
					throw new Exception( "Update cancelled." );
				}
				string hp = PathCombine( history, folder.Name, path );
				if( debug ) { Log( ".u.history path [{0}]", hp ); }
				try
				{
#if __MonoCS__
					{
						Mono.Unix.UnixSymbolicLinkInfo i = new Mono.Unix.UnixSymbolicLinkInfo( hp );
						if( ! i.Exists || ! i.IsDirectory )
						{
							return;
						}
					}
#endif
					if( ! DirectoryExists( hp ) )
					{
						if( debug ) { Log( ".u.history path does not exist" ); }
						return;
					}

					//..flag as deleted the number of files in the folder
					if( debug ) { Log( ".u.-----> files [{0}]", MatchPath.AbsoluteDirectoryPath( path ?? string.Empty ) ); }
					foreach( string n in Ctrl.ListFiles( hp ) )
					{
						string pn = PathCombine( path, n );
						if( debug ) { Log( ".u.file [{0}]", pn ); }
						LogStatus( StatusType.Deleted, folder.Name, path, n );
						Interlocked.Increment( ref status.update.deleted );
					}

					//..recurse into all subdirectories
					if( debug ) { Log( ".u.-----> directories [{0}]", MatchPath.AbsoluteDirectoryPath( path ?? string.Empty ) ); }
					foreach( string n in Ctrl.ListDirectories( hp ) )
					{
						string pn = PathCombine( path, n );
						if( debug ) { Log( ".u.directory [{0}]", pn ); }
						RecursiveDelete( folder, pn );
					}
				}
				catch( Exception ex )
				{
					ex.Data[ExHistoryPath] = hp;
					throw;
				}
			}
			catch( Exception ex )
			{
				ex.Data[ExPath] = path;
				throw;
			}
		}

		//--- method ----------------------------


		void ListFilenameRemove( List<string> a, string filename )
		{
			StringBuilder sb = null;
			if( debug ) { sb = new StringBuilder(); sb.AppendFormat( "..completed [{0}]", filename ); }
			int i = a.Count;
			while( --i >= 0 )
			{
				if( string.Compare( a[i], filename, ! ctrl.IsCaseSensitive ) == 0 )
				{
					if( debug ) { sb.Append( " ..marked" ); }
					a.RemoveAt( i );
				}
			}
			if( debug ) { Log( sb.ToString() ); }
		}

		string PathCombine( string root, string path )
		{
			try
			{
				return System.IO.Path.Combine( root, path );
			}
			catch( Exception ex )
			{
				ex.Data[ExPath]     = root;
				ex.Data[ExFilename] = path;
				throw;
			}
		}
		string PathCombine( string root, string path, string filename )
		{
			return PathCombine( PathCombine( root, path ), filename );
		}
		string PathDirectory( string path )
		{
			try
			{
				return System.IO.Path.GetDirectoryName( path );
			}
			catch( Exception ex )
			{
				ex.Data[ExPath] = path;
				throw;
			}
		}
		string PathFilename( string path )
		{
			try
			{
				return System.IO.Path.GetFileName( path );
			}
			catch( Exception ex )
			{
				ex.Data[ExPath] = path;
				throw;
			}
		}

		bool DirectoryExists( string path )
		{
			try
			{
				bool b = Directory.Exists( path );
				if( debug ) { Log( "..directory [{0}] ..{1}", path, b ? "exists" : "absent" ); }
				return b;
			}
			catch( Exception ex )
			{
				ex.Data[ExPath] = path;
				throw;
			}
		}
		void DirectoryCreate( string path )
		{
			try
			{
				StringBuilder sb = null;
				if( debug ) { sb = new StringBuilder(); sb.AppendFormat( "..directory create [{0}]", path ); }
				if( ! Directory.Exists( path ) )
				{
					if( debug ) { sb.Append( " ..absent, creating" ); }
					Directory.CreateDirectory( path );
				}
				if( debug ) { Log( sb.ToString() ); }
			}
			catch( Exception ex )
			{
				ex.Data[ExPath] = path;
				throw;
			}
		}
		void DirectoryMove( string src, string dst )
		{
			try
			{
				if( debug ) { Log( "..directory move [{0}]\n              to [{1}]", src, dst ); }
				Directory.Move( src, dst );
			}
			catch( Exception ex )
			{
				ex.Data[ExPath] = string.Format( "{0} --> {1}", Except.ToQuoteString( src ), Except.ToQuoteString( dst ) );
				throw;
			}
		}
		void DirectoryDelete( string path, bool recursive )
		{
			try
			{
				StringBuilder sb = null;
				if( debug ) { sb = new StringBuilder(); sb.AppendFormat( "..directory delete [{0}] ..{1}", path, recursive ? "and contents" : "if empty" ); }
				if( Directory.Exists( path ) )
				{
					if( debug ) { sb.Append( " ..exists, removing" ); }
					Directory.Delete( path, recursive );
				}
				if( debug ) { Log( sb.ToString() ); }
			}
			catch( Exception ex )
			{
				ex.Data[ExPath] = path;
				throw;
			}
		}

		bool FileExists( string path )
		{
			try
			{
				bool b = File.Exists( path );
				if( debug ) { Log( "..file [{0}] {1}", path, b ? "exists" : "absent" ); }
				return b;
			}
			catch( Exception ex )
			{
				ex.Data[ExFilename] = path;
				throw;
			}
		}
		void FileCopy( string src, string dst )
		{
			try
			{
				if( debug ) { Log( "..file copy [{0}]\n         to [{1}]", src, dst ); }
				File.Copy( src, dst );
			}
			catch( Exception ex )
			{
				ex.Data[ExFilename] = string.Format( "{0} --> {1}", Except.ToQuoteString( src ), Except.ToQuoteString( dst ) );
				throw;
			}
		}
		void FileMove( string src, string dst )
		{
			try
			{
				if( debug ) { Log( "..file move [{0}]\n         to [{1}]", src, dst ); }
				File.Move( src, dst );
			}
			catch( Exception ex )
			{
				ex.Data[ExFilename] = string.Format( "{0} --> {1}", Except.ToQuoteString( src ), Except.ToQuoteString( dst ) );
				throw;
			}
		}
		void FileDelete( string path )
		{
			try
			{
				StringBuilder sb = null;
				if( debug ) { sb = new StringBuilder(); sb.AppendFormat( "..file delete [{0}]", path ); }
				if( File.Exists( path ) )
				{
					if( debug ) { sb.Append( " ..exists, removing" ); }
					File.Delete( path );
				}
				if( debug ) { Log( sb.ToString() ); }
			}
			catch( Exception ex )
			{
				ex.Data[ExFilename] = path;
				throw;
			}
		}

		void LogStatus( StatusType status, string name, string path, string filename )
		{
			StringBuilder st = new StringBuilder( "----" );
			st[(int)status] = char.ToUpper( status.ToString()[0] );
			st.AppendFormat( " {0}:", name ?? string.Empty );
			st.Append( MatchPath.AbsoluteDirectoryPath( path ?? string.Empty ) );
			st.Append( filename ?? string.Empty );
			Log( st.ToString() );
		}
		void Log( string fmt, params object[] args )
		{
			Log( string.Format( fmt, args ) );
		}
		void Log( string msg )
		{
			if( log != null )
			{
				lock( log )
				{
					log.WriteLine( msg );
				}
			}
		}

		void Msg( string fmt, params object[] args )
		{
			Msg( string.Format( fmt, args ) );
		}
		void Msg( string msg )
		{
			lock( message )
			{
				message( msg );
			}
			Log( msg );
		}

		//--- end -------------------------------
	}
}
