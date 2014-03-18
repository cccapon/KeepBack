using System;
using System.Diagnostics;
using System.IO;
using System.Text;

/* rsync.exe
 * 
 * Main options:
 *		--archive   ( --recursive --links --perms --times --group --owner --devices --specials )
 *		--itemize-changes
 *		--delete
 *		--delete-excluded
 *		--backup
 *		--backup-dir {folder}
 *		--password-file {filename}
 *		--exclude-from {filename}
 *		--include-from {filename}
 *		--compress
 *		--verbose
 *		
 * 
 *      --safe-links
 *      --hard-links
 *      --relative --safe-links --super --one-file-system --dry-run --out-format="%i|%n|"
 *      --cvs-exclude
 *      --checksum --human-readable --stats 
 *      --rsh 'ssh -p 2222'
 *		

	Usage: rsync [OPTION]... SRC [SRC]... DEST
	  or   rsync [OPTION]... SRC [SRC]... [USER@]HOST:DEST
	  or   rsync [OPTION]... SRC [SRC]... [USER@]HOST::DEST
	  or   rsync [OPTION]... SRC [SRC]... rsync://[USER@]HOST[:PORT]/DEST
	  or   rsync [OPTION]... [USER@]HOST:SRC [DEST]
	  or   rsync [OPTION]... [USER@]HOST::SRC [DEST]
	  or   rsync [OPTION]... rsync://[USER@]HOST[:PORT]/SRC [DEST]
	The ':' usages connect via remote shell, while '::' & 'rsync://' usages connect
	to an rsync daemon, and require SRC or DEST to start with a module name.

	Options
	 -v, --verbose               increase verbosity
	 -q, --quiet                 suppress non-error messages
		 --no-motd               suppress daemon-mode MOTD (see manpage caveat)
	 -c, --checksum              skip based on checksum, not mod-time & size
	 -a, --archive               archive mode; equals -rlptgoD (no -H,-A,-X)
		 --no-OPTION             turn off an implied OPTION (e.g. --no-D)
	 -r, --recursive             recurse into directories
	 -R, --relative              use relative path names
		 --no-implied-dirs       don't send implied dirs with --relative
	 -b, --backup                make backups (see --suffix & --backup-dir)
		 --backup-dir=DIR        make backups into hierarchy based in DIR
		 --suffix=SUFFIX         set backup suffix (default ~ w/o --backup-dir)
	 -u, --update                skip files that are newer on the receiver
		 --inplace               update destination files in-place (SEE MAN PAGE)
		 --append                append data onto shorter files
		 --append-verify         like --append, but with old data in file checksum
	 -d, --dirs                  transfer directories without recursing
	 -l, --links                 copy symlinks as symlinks
	 -L, --copy-links            transform symlink into referent file/dir
		 --copy-unsafe-links     only "unsafe" symlinks are transformed
		 --safe-links            ignore symlinks that point outside the source tree
	 -k, --copy-dirlinks         transform symlink to a dir into referent dir
	 -K, --keep-dirlinks         treat symlinked dir on receiver as dir
	 -H, --hard-links            preserve hard links
	 -p, --perms                 preserve permissions
	 -E, --executability         preserve the file's executability
		 --chmod=CHMOD           affect file and/or directory permissions
	 -A, --acls                  preserve ACLs (implies --perms)
	 -o, --owner                 preserve owner (super-user only)
	 -g, --group                 preserve group
		 --devices               preserve device files (super-user only)
		 --specials              preserve special files
	 -D                          same as --devices --specials
	 -t, --times                 preserve modification times
	 -O, --omit-dir-times        omit directories from --times
		 --super                 receiver attempts super-user activities
	 -S, --sparse                handle sparse files efficiently
	 -n, --dry-run               perform a trial run with no changes made
	 -W, --whole-file            copy files whole (without delta-xfer algorithm)
	 -x, --one-file-system       don't cross filesystem boundaries
	 -B, --block-size=SIZE       force a fixed checksum block-size
	 -e, --rsh=COMMAND           specify the remote shell to use
		 --rsync-path=PROGRAM    specify the rsync to run on the remote machine
		 --existing              skip creating new files on receiver
		 --ignore-existing       skip updating files that already exist on receiver
		 --remove-source-files   sender removes synchronized files (non-dirs)
		 --del                   an alias for --delete-during
		 --delete                delete extraneous files from destination dirs
		 --delete-before         receiver deletes before transfer, not during
		 --delete-during         receiver deletes during the transfer
		 --delete-delay          find deletions during, delete after
		 --delete-after          receiver deletes after transfer, not during
		 --delete-excluded       also delete excluded files from destination dirs
		 --ignore-errors         delete even if there are I/O errors
		 --force                 force deletion of directories even if not empty
		 --max-delete=NUM        don't delete more than NUM files
		 --max-size=SIZE         don't transfer any file larger than SIZE
		 --min-size=SIZE         don't transfer any file smaller than SIZE
		 --partial               keep partially transferred files
		 --partial-dir=DIR       put a partially transferred file into DIR
		 --delay-updates         put all updated files into place at transfer's end
	 -m, --prune-empty-dirs      prune empty directory chains from the file-list
		 --numeric-ids           don't map uid/gid values by user/group name
		 --timeout=SECONDS       set I/O timeout in seconds
		 --contimeout=SECONDS    set daemon connection timeout in seconds
	 -I, --ignore-times          don't skip files that match in size and mod-time
		 --size-only             skip files that match in size
		 --modify-window=NUM     compare mod-times with reduced accuracy
	 -T, --temp-dir=DIR          create temporary files in directory DIR
	 -y, --fuzzy                 find similar file for basis if no dest file
		 --compare-dest=DIR      also compare destination files relative to DIR
		 --copy-dest=DIR         ... and include copies of unchanged files
		 --link-dest=DIR         hardlink to files in DIR when unchanged
	 -z, --compress              compress file data during the transfer
		 --compress-level=NUM    explicitly set compression level
		 --skip-compress=LIST    skip compressing files with a suffix in LIST
	 -C, --cvs-exclude           auto-ignore files the same way CVS does
	 -f, --filter=RULE           add a file-filtering RULE
	 -F                          same as --filter='dir-merge /.rsync-filter'
								 repeated: --filter='- .rsync-filter'
		 --exclude=PATTERN       exclude files matching PATTERN
		 --exclude-from=FILE     read exclude patterns from FILE
		 --include=PATTERN       don't exclude files matching PATTERN
		 --include-from=FILE     read include patterns from FILE
		 --files-from=FILE       read list of source-file names from FILE
	 -0, --from0                 all *-from/filter files are delimited by 0s
	 -s, --protect-args          no space-splitting; only wildcard special-chars
		 --address=ADDRESS       bind address for outgoing socket to daemon
		 --port=PORT             specify double-colon alternate port number
		 --sockopts=OPTIONS      specify custom TCP options
		 --blocking-io           use blocking I/O for the remote shell
		 --stats                 give some file-transfer stats
	 -8, --8-bit-output          leave high-bit chars unescaped in output
	 -h, --human-readable        output numbers in a human-readable format
		 --progress              show progress during transfer
	 -P                          same as --partial --progress
	 -i, --itemize-changes       output a change-summary for all updates
		 --out-format=FORMAT     output updates using the specified FORMAT
		 --log-file=FILE         log what we're doing to the specified FILE
		 --log-file-format=FMT   log updates using the specified FMT
		 --password-file=FILE    read daemon-access password from FILE
		 --list-only             list the files instead of copying them
		 --bwlimit=KBPS          limit I/O bandwidth; KBytes per second
		 --write-batch=FILE      write a batched update to FILE
		 --only-write-batch=FILE like --write-batch but w/o updating destination
		 --read-batch=FILE       read a batched update from FILE
		 --protocol=NUM          force an older protocol version to be used
		 --iconv=CONVERT_SPEC    request charset conversion of filenames
	 -4, --ipv4                  prefer IPv4
	 -6, --ipv6                  prefer IPv6
		 --version               print version number
	(-h) --help                  show this help (-h is --help only if used alone)

*/

namespace BackMeUp
{

	public class Backup
	{
		string             rsync;           // path to rsync.exe
		string             cygdrive;        // path to Cygwin /cygdrive root.  Location of all mapped drives in Windows.

		FolderEncountered  folder   = null;
		ProcessExit        exit     = null;

		string             logpath  = null;
		StreamWriter       log      = null;
		DateTime           start    = DateTime.MinValue;
		Archive            archive  = null;
		string             current  = string.Empty;
		string             history  = string.Empty;

		Process            process  = null;
		DateTime           clock    = DateTime.MinValue;
		string             excl     = string.Empty;
		string             passwd   = string.Empty;
		string             fold     = string.Empty;

		public delegate void FolderEncountered( string folder );
		public delegate void ProcessExit();

		public Archive Archive { get { return archive; } }

		public Backup( string rsync, string cygdrive, FolderEncountered folder, ProcessExit exit )
		{
			this.rsync    = rsync;
			this.cygdrive = cygdrive;
			this.folder   = folder;
			this.exit     = exit;
		}

		public void Initialize( Archive archive )
		{
			this.archive = archive;
			start = DateTime.Now;
			current = "current";
			history = start.ToString( "yyyy-MM-dd-HHmmss", System.Globalization.DateTimeFormatInfo.InvariantInfo );
			string cp = Path.Combine( archive.path, current );
			string hp = Path.Combine( archive.path, history );
			logpath = Path.Combine( Path.GetDirectoryName( Path.GetFullPath( archive.filename ) ), history + ".log" );
			log = new StreamWriter( logpath );
			log.WriteLine( "{0}", start.ToString( "yyyy-MM-dd HH:mm:ss", System.Globalization.DateTimeFormatInfo.InvariantInfo ) );
			log.WriteLine( "\n---[config]-----------------------------------\n" );
			archive.Write( log );
		}

		public void Complete( bool cancelled )
		{
			clock   = DateTime.MinValue;
			history = string.Empty;
			current = string.Empty;
			archive = null;
			if( log != null )
			{
				log.WriteLine( "\n---[end]--------------------------------------" );
				TimeSpan x = DateTime.Now - start;
				log.WriteLine( "{0} - {1}\n", x, cancelled ? "cancelled!" : "completed." );
				log.Close();
				log.Dispose();
				log = null;
			}
		}


		
		public void Launch( int index )
		{
			if( (archive == null) || (index < 0) || (index >= archive.folders.Length) )
			{
				throw new Exception( string.Format( "Invalid folder index {0} provided.", index ) );
			}
			Archive.Folder f = archive.folders[index];

			clock    = DateTime.Now;
			excl     = string.Empty;
			passwd   = string.Empty;
			fold     = string.Empty;

			StringBuilder sb = new StringBuilder();
			sb.Append( " --archive" );
			sb.Append( " --itemize-changes" );
			if( ! string.IsNullOrEmpty( history ) )
			{
				sb.Append( " --compress" );
				sb.Append( " --delete" );
				sb.Append( " --delete-after" );
				sb.Append( " --delete-excluded" );
				sb.Append( " --backup" );
				sb.AppendFormat( " --backup-dir \"../../{0}/{1}\"", history, f.tag );
			}
			if( f.excludes.Length > 0 )
			{
				excl = Path.GetTempFileName();
				using( StreamWriter sw = new StreamWriter( excl ) )
				{
					foreach( string e in f.excludes )
					{
						sw.WriteLine( e.Replace( '\\', '/' ) );
					}
				}
				sb.AppendFormat( " --exclude-from \"{0}\"", MapCygwinFullPath( excl, cygdrive, false ) );
			}
			if( ! string.IsNullOrEmpty( archive.password ) )
			{
				passwd = Path.GetTempFileName();
				using( StreamWriter sw = new StreamWriter( passwd ) )
				{
					sw.WriteLine( archive.password );
				}
				sb.AppendFormat( " --password-file \"{0}\"", MapCygwinFullPath( passwd, cygdrive, false ) );
			}
			sb.AppendFormat( " \"{0}\"", MapCygwinFullPath( Path.GetFullPath( f.path ?? string.Empty ), cygdrive, true ) );
			sb.AppendFormat( " \"{0}\"", MapCygwinFullPath( string.Format( "{0}/{1}/{2}", archive.path, current, f.tag ), cygdrive, false ) );

			if( log != null )
			{
				log.WriteLine( "\n---[folder]-----------------------------------" );
				log.WriteLine( "\n[{0}]  {1}", f.tag, f.path ?? string.Empty );
				log.WriteLine( "{0}", clock.ToString( "yyyy-MM-dd HH:mm:ss", System.Globalization.DateTimeFormatInfo.InvariantInfo ) );
				log.WriteLine( "\nrsync: {0}", sb.ToString() );
				log.WriteLine();
			}

			process = new Process();
			ProcessStartInfo si = process.StartInfo;
			si.FileName = rsync;
			si.Arguments = sb.ToString();
			si.RedirectStandardError = true;
			si.RedirectStandardInput = false;
			si.RedirectStandardOutput = true;
			si.UseShellExecute = false;
			si.WindowStyle = ProcessWindowStyle.Hidden;
			si.CreateNoWindow = true;
			process.EnableRaisingEvents = true;
			process.Exited += new EventHandler( this.Exited );
			process.OutputDataReceived += new DataReceivedEventHandler( this.DataReceivedHandler );
			process.ErrorDataReceived  += new DataReceivedEventHandler( this.DataReceivedHandler );

			process.Start();

			process.BeginOutputReadLine();
			process.BeginErrorReadLine();
		}

		public void Cancel()
		{
			if( process != null )
			{
				process.Kill();
			}
		}

		void DataReceivedHandler( object sender, DataReceivedEventArgs args )
		{
			string text = args.Data;
			if( (log != null) && (text != null) )
			{
				log.WriteLine( text );
				if( (folder != null) && (text.Length > 11) && (text[11] == ' ') )
				{
					switch( text[0] )
					{
						case '<': case '>': case 'c': case 'h': case '.':
						{
							switch( text[1] )
							{
								case 'd': case 'f':
								{
									string f = text.Substring( 11 ).Trim();
									int    i = f.LastIndexOf( '/' );
									if( i >= 0 )
									{
										f = f.Substring( 0, i );
									}
									if( (f != null) && (string.Compare( f, fold, true ) != 0) )
									{
										folder( fold = f );
									}
									break;
								}
							}
							break;
						}
					}
				}
			}
		}

		void Exited( object sender, EventArgs e )
		{
			if( process != null )
			{
				process.WaitForExit( 10 * 1000 );
				process.CancelErrorRead();
				process.CancelOutputRead();
				process.Close();
				process = null;
			}
			if( ! string.IsNullOrEmpty( excl ) )
			{
				Files.FileDelete( excl );
				excl = string.Empty;
			}
			if( ! string.IsNullOrEmpty( passwd ) )
			{
				Files.FileDelete( passwd );
				passwd = string.Empty;
			}
			if( log != null )
			{
				TimeSpan x = DateTime.Now - clock;
				log.WriteLine( "\n{0}", x );
			}
			exit();
		}

		public static string MapCygwinFullPath( string path, string cygdrive, bool trailing )
		{
			// look for a path in the form -->  C:\something
			if( (path.Length > 2) && (path[1] == ':') )
			{
				char c = path[0];
				if( ((c >= 'a') && (c <= 'z')) || ((c >= 'A') && (c <= 'Z')) )
				{
					string cd = string.IsNullOrEmpty( cygdrive.Trim() ) ? "cygdrive" : cygdrive.Trim();
					path = string.Format( "/{0}/{1}", cd, path.Remove( 1, 1 ) ).Replace( "//", "/" );
				}
			}
			path = path.Replace( @"\", "/" );
			bool b = path.EndsWith( "/" );
			return trailing ? (b ? path : (path + "/") ) : (b ? path.Substring( 0, path.Length - 1 ) : path);
		}

	}
}
