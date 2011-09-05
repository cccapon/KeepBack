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
using System.Windows.Forms;



/*  Current
 * ---------------------------------------
 */


/*  Quick Notes
 * ---------------------------------------
 */


/*  Bug
 * ---------------------------------------
 * - track down "already exists" bug
 *   - new idea, see if the underlying 8.3 filenames are in conflict
 *     - problem occurs during a FileMove operation so it is possible that while the long file names are
 *       different, the short file names might still be the same and are in conflict.
 * - Adding a folder to a new archive
 *   - select folder with directory browser
 *   - change name
 *   - exit without saving, Yes to save changes
 *   - does not retain folder changes
 *   - happens for archive path as well
 * - when a folder is excluded using a filter and that folder already exists in the backup, it will not be cleared out properly by history.
 * - find a better way to detect if file system is case sensitive or not.
 * - Add new "exclude folder" to existing archive
 *   - when exclude folder is added, the file exclude icon is displayed rather than folder exclude
 * - When backup drive is just 'E' instead of 'E:' then a folder is created called E\backup\directory rather than E:\backup\directory
 *   - verify that all drive numbers end with the ':' character.
 *   - maybe the separation of drive letter and path should be rethought, it isn't that difficult to change a drive letter programatically.
 *   - if path is E:\ and root is E:\ then paths have two drive prefixes : E:\E:\
 *		- should have parsing rules for these fields
 * - remove default pattern
 *   - default pattern of "*" matches everything and on an exclude is disasterous
 *   - make default pattern "" instead
 *   - automatically remove "" patterns when the pattern dialog is closed.
 * 
 */

/*
 *  Mike Capon ideas
 * ---------------------------------------
 *   - include files which are part of an excluded folder (ie: exclude the folder but include one file it contains)
 *     - this would require some sort of nesting option
 *     - should includes and excludes have children so they can recursively include something that was excluded and vice-versa?
 *     - nestable include/exclude option
 *       - must alternate - includes can have excludes but not other includes, excludes can have includes but not excludes
 *       - multiple entries at each nest level
 *       - some sort if display indicator that there are levels below when  displayed in the tree
 *   - compression option for people with limited space
 * - find a clean way to detect if file exists on destination
 *   - need to handle all sorts of case/case insensitive situations
 *     - backup drive may not be case sensitive where source drive may be
 *   - fix merge as well as backup
 * - new status trackers
 *   - Created, Modified, Deleted
 *   - skipped or locked files (can't be backed up but should have)
 *   - bytes backed up, bytes removed, total space left on backup drive
 *   - percentage remaining
 *     - size of items in operations queue (total bytes)
 *   - elapsed time, time remaining, estimated completion time
 * - no dependancy on GUI
 *   - output should be able to drive a console application
 * - include, history, exclude
 *   - treat include and history the same way logically
 *     - if include or history are specified then current folder must be under at least one of them
 *     - if exclude is specified, then current folder can not be under any of them
 * - patterns
 *   - directory characters (\) and (/) are added to beginning and end of pattern by radio buttons
 *   - check the pattern to decide which to use
 *   - nearest one to the beginning is used for the beginning
 *   - nearest one to the end is used for the end
 *   - if none present, pick (\) for Windows and (/) for Linux (maybe just Path.DirectoryChar will do)
 * - 
 * 
 */

/*
 *  History Browser structures
 * ---------------------------------------
 * 
 * Item
 *  	filename
 *  	size
 *  	history-size
 *  	history (byte[])
 * ItemFile : Item
 *  	date-modified
 * ItemFolder : Item
 *  	file-count
 *  	history-count
 *  	children (Item[])
 * 
 * history
 * 	- byte array
 * 	- sized depending on the number of history folders
 * 		(folders + 7) / 8
 *         ((8 - 1) + folders) / 8
 *         (8 + (folders - 1)) / 8
 *         (8 / 8) + ((folders - 1) / 8)
 *         1 + ((folders - 1) / 8)
 * 
 * children
 *  	- null     = hasn't been scanned yet
 *  	- not-null = list of child Item's (directories first), sorted
 * file-count
 *  	- >= 0  = count of all files under folder
 *  	-  < 0  = incomplete count, some children haven't fully been scanned
 * history-count
 *  	- for directories, it tracks sum of history of all children
 *  	- for files, history count is derrived from history (byte[])
 */


/*  Enhancement
 * ---------------------------------------
 * - History browser
 *   - sort by
 *     - total diskspace used by all history versions
 *     - frequency of changes over history (number of times item appears in history sets)
 * - Dealing with large files which change frequently over time
 *   - typically E-Mail archives
 *   - can we store a delta?
 *     - maybe there is existing code to track changes to binary files
 *     - most recent file must be the master file to which delta's are applied
 *     - it must be possible to merge deltas when backup sets are merged
 *     - how does the software deal with interuption?
 *     - what if the file is open for write at backup time?
 * - display warnings for low disk space
 *   - better: display a meter which shows how much space is used/free
 *     - could this be a running display while the backup proceeds?
 *       - warn as it gets close
 *     - if we run out of space, can backup pause and wait for user to clear space?
 *       - make history browser available for cleanup?
 *       - allow options to change merge criteria
 *    - should all file copies check to see if the destination has space?  Could then free some up if necessary.
 * 
 * - history browser
 *   - allow option to spontaneously merge two or more adjacent backup incrementals
 * - create proper file menu and toolbar for buttons
 * - make folder text box double height for when path wraps due to length
 * - handle out-of-disk-space errors better.  
 *   - currently exception is thrown and app aborts
 * - display warning/error counter as part of statistics
 *   - offer to display reduced (no files that didn't produce errors) or full log file if there were warnings or errors
 * - multithreaded backup
 *   - reader thread
 *     - scan for changes, queue up files which must be backed up
 *   - writer thread
 *     - archive old files
 *     - copy over new files
 *     - delete files being removed
 * - separate filenames from log
 *   - log top should contain all error and status messages
 *   - list of files backed up should be at the bottom or in a separate file
 *   - write the file list in such a way that in the future there could be options to rollback files or even folders to a specific point in time.
 * - add autostart backup option
 *   - from command line, add option to auto start the backup when a .keep file is provided
 *   - so no user intervention is required
 * - disk usage
 *   - provide a summary at the end showing free space on hard drive from begin and end of backup
 * - pause  backup
 *   - option to pause current backup then resume operation from current location.
 * - duplicate files
 *   - history option to help locate large files which are duplicates
 *   - needed to help clean up system
 *   - when large files are moved they can fill the backup archive
 *     - locate duplicates and give easy options for eliminating historical versions which are in old folders.
 * - when adding a new folder, leave name empty
 *   - if browser selects folder and name is empty, set name = foldername of path
 *   - if we leave the folder without naming it, automatically set name = foldername of path
 * - dated directory names
 *   - when there are no conflicting names, allow merge to rename date/time folders to just date folders
 *     eg: 2010-11-05-1903  to  2010-11-05
 *     especially the monthly merge if not the daily
 *     handle smooth transitions from 2010-11-05-190321 to 2010-11-05-1903 to 2010-11-05
 * - configuration
 *   - no two archives should have the same destination path
 *   - no two folders should have the same archive name
 * - force full backup
 *   - have checkbox flag on main screen.  When checked (remember last state?) is passed along to backup
 *   - backup does not rename history folder
 *   - archive is new folder name as usual
 *   - history remains NULL
 *   - full backup takes place and no history interaction takes place
 *   - then its business as usual
 * - History flag vulnerability
 *   - when history option selected, backing up a file means the previous copy is being overwritten
 *   - if the copy fails, the old file will be lost
 *   - should we rename the file first then copy the new file, then delete the old file?
 * 
 * - check for empty paths
 * 
 * - Include, Exclude, History
 *   - test all combinations
 *     - file, directory
 *       - include, exclude, history
 *         - existing, new, deleted
 * - control file editor/creator
 *   - always sort include/exclude/history lists (directories first)
 * - what is causing   [FM] file exists   errors
 * - add version number and track history
 * - add option to apply include/exclude/history rules when merging
 * - backup history browser
 *   - shows merger tree of all history folders combined
 *   - shows file count and total size of all folders for all history versions
 *     - show separate counts for most recent vs all history versions
 *   - tool to apply backup filters to a dated folder (or group of dated folders)
 *     - if they select a file/folder from either tree or list view then apply filters to all history levels
 *     - if they select a history date instead, only apply filter to that date
 *     - allow multi-select in all views
 *   - option to review log files
 * - provide an easy way to move the backup destination
 *   - USB drives could end up being mounted in a variety of places
 *   - when control file is run, a test is made to see if the destination path
 *     exists.  If not, then two options are presented:
 *        - create destination
 *        - search for destination
 *          - search could be automatic, hunt each valid root for /folder/name
 *            - skip floppy drives if possible
 * 
 * - registry backup
 *   - registry is always locked for current user
 *   - windows only
 * 
 * - system tray tool
 *   - monitor file system
 *     - record changes to file system
 *     - feed just the changed files to the backup program once per hour
 *   - monitor removable drives
 *     - when drive shows up which contains backup set
 *       - automatically start backup
 *       - optionally, unmount removable drive after backup completes
 *       - called zero-touch backup
 *   - scheduling
 *     - keep track of specific backup.keep files
 *       - when were they last seen
 *     - remember frequency each backup set is expected to be run
 *     - if backup set is overdue, display pop-up indicating which drives should be attached
 *     - when drive appears, trigger backup then record completion date
 *     - if drive is already mounted and scheduled backup occurs, initiate backup but don't auto eject
 * 
 * - write a service app to scan for file properties
 *   - can scan a single file or whole file system
 *   - looks for any information which can be derrived from a file
 *   - will report anything new or unknown to the console.
 *     - attributes, file dates, properties, security information, size, accessibility, permissions, etc.
 *   - try to identify files which should never be backed up
 *     - devices, links, pipes
 */

/* 
 *  2.0 ideas
 * ---------------------------------------
 * - multithreaded
 *   - queue based
 *   - one thread monitors GUI
 *     - display status, update progress bar, show time elapsed and time remaining
 *   - one thread scans directories looking for work
 *     - compare directories
 *     - should essentially be just reading directories
 *     - add items to operations queue as necessary
 *   - one thread handles all file operations (move, copy, delete)
 *     - must handle all situations
 *       - file or folder may exist at destination, move them to history, if exist in history (maybe case
 *         collision) must move history to another folder somehow
 *         - maybe automatically create a 2nd history folder with the same name but append -01 or something.
 *           - keep creating sibling history folders for each collision so our backup can complete and no
 *             lost data.
 *           - merge should be adjusted to handle these backups and keep the most recent history file given
 *             a choice.
 *     - overly long paths >256 cause exceptions
 *       - trap exception and use fallback logic
 *       - cd to source folder level
 *         - if cd fails with overly long path then recursively cd to parent directory then current directory
 *       - copy file to temp name on destination drive
 *       - recursively move temp file down destination drive path until at required directory level
 *       - rename file to match name of file
 *       - do some similar renaming when moving to history folder
 *       - test with really long folder names as well as file names
 *     - what happens when files change between scan thread finding them and the archive thread moving them?
 *   - interuptable
 *     - GUI can stop worker threads at their next opportunity
 *   - use queue for merge as well
 *   - handle file and folder permission issues
 *     - maybe can't read a file or folder to back it up
 *     - automatic elevation to administrator?
 *     - if a file is currently open, is there a way to back it up anyway?
 *       - if not we should keep the last backup file and not move it to history
 *          FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, System.IO.FileShare.ReadWrite)
 * - queue processing
 *   - since all actions are now stored in a list, if any can't be processed they can still be in the list, flagged as incomplete
 *   - for files that are locked
 *     - show a list of locked files while still running the backup.
 *     - a message indicates that if a locked file is released then the backup will still process the file
 *     - check periodically if the file is unlocked.
 *     - have an option to automatically exclude locked files by adding a custom filter to the Folder.
 * - handling files or folders which move
 *   - on source drive, if files or folders are moved from one backup to the next, currently, the files will be duplicated:
 *     one copy in the history folder and one in the current folder
 *   - is there a way with the multi-threading to identify files and folders which have moved and where their new locations are?
 *     - Would probably have to let the scan finish before determining this.
 *   - if located, then one copy is kept in the current folder and no versions kept in the history folder
 * - handling files which have been moved
 *   - a moved file disappears from one location and appears in another
 *   - results in redundantly copying the new location and historically archiving the old
 *   - when scanning for work, we could defer file create and deletes until the end
 *   - when created files are found, they could be compared against the current deletes list and vice versa
 *   - matching files would then simply be moved in the archive
 *   - this is probably not a good idea since no one would be able to find historical versions of files in the
 *     old locations.
 *   - what about maintaining a CRC of every file
 *     - as files change, a new CRC is generated
 *     - new CRC's can be compared against list of known CRC's for all files
 *       - if found, check if old file is gone
 *         - if gone, assume file has moved
 * 
 */







/*  History
 * ---------------------------------------
 * 2011-08-24  v1.04
 *   - alter interface to show Created, Modified, Deleted.  Removed Changed, Attribute, Written and Length.
 *   - no longer check attributes as indicator of a changed file.
 *   - reverse order of History and Exclude filters in Folder panel of Edit window.
 *   - bug in directory processing with filters.  if an input filter is specified which includes files
 *     in a folder, but does not specify the folder, then the folder would be moved to history.  later it
 *     would be copied again, then moved to history leading to a cyclic pattern and the Directory Exists bug.
 *   - if a folder was added to an archive, but no path was specified then an exception was thrown when
 *     a backup was run.  this now displays a warning message instead.
 *   - directory names in the log file now have a '\' appended to the name to distinguish them from files.
 *   - a date range check is performed on the archive filesystem and used when validating file dates.  if
 *     the source filesystem allows a greater range of file dates than the destination, the file date will
 *     be adjusted to match that of the archive file system.  this is to solve a bug where corrupt dates in
 *     the source filesystem caused files to endlessly be archived (their dates were always different).  it 
 *     may also help solve the "file exists" bug which was caused when KeepBack attempted to move the history
 *     file back after a failed copy.  the copy hadn't actually failed, it was the code which sets the file
 *     date that failed.
 *   - if a file is moved to a history folder and the latest version of that file can not be copied to the
 *     archive, no attempt is made to move the history version back to the current archive.  in the past we
 *     tried to put the file back, which lead to problems like the date range bug above.  now, the archive
 *     more accurately represents the accessability of the filesystem.
 *   - added a debug menu option to add extra messages to the log file.
 *   - add list of wild card characters to pattern screen in edit window.
 *   - added about box.
 *   - a bug in the DirectoryDelete operation required the folder to be empty for delete to take place.
 * 2011-01-20  v1.03
 *   - changed .keep XML to indent text (make it more human readable).
 *   - when backup operation was cancelled, any unprocessed folders in the current archive would be moved to the history
 *     folder inadvertently.  Now fixed.
 * 2010-11-14  v1.02
 *   - disable Explore button for release to SourceForge.
 * 2009-12-12  v1.01
 *   - fixed bug in history and merging where some filenames have changed case and were not matched with each other.
 *     - we now detect the case support of the file system automatically.
 *     - it isn't a very good method, would like to find a better / faster way.
 * 2009-03-28  v1.0
 *   - added Edit interface for managing control files.
 *   - added New button to create new control file.
 *   - changed control file extension from .ctrl to .keep
 * 2009-01-13
 *   - added counter for skipped files
 *   - the control file is preserved in the dated backup folder now.  Old control files
 *     will be preserved historically when they change.
 *   - more cleanup of logged messages
 *   - added history browser form, has no functional code yet, just a design prototype
 *   - reorganized the main panel to clean things up a little
 *   - check for and ignore empty patterns
 *   - now check for prior history and that history path exists before moving files there
 * 2009-01-05
 *   - fixed bug in history maintenance, it was trying to delete the old file from history
 *     rather than current before moving new file in to current.
 *   - cleaned up log messages and added a status legend to log file
 *   - control file archive block now identifies separately, root=, folder= and name=
 *     rather than path=.  This is to facilitate moving the archive location at a later
 *     date.  When USB drives are plugged in, the drive letter is uncertain each time.
 *     Same under Linux.  This will be the root= portion.  Folder can also change which
 *     is the place the archive is located under the root.  Name stays the same and is
 *     the name of the final directory in which everything is stored.
 * 2009-01-03
 *   - Log files are now written to the Archive backup directory and have dated names.
 *     - log files are maintained by the Merge facility the same way that directories
 *       are merged.  When a folder no longer exists, its log files are removed as well.
 *     - separate log files on a per-archive basis are created rather than one single log
 *       file as before.
 *   - Include, Exclude and History paths are now fully supported.
 *     - Includes are checked before Excludes.
 *   - Patterns that end with a directory character only match directories.
 *   - Patterns that do not end with a directory character only match files.
 *   - Excluded directories will not be scanned further for deeper Included directories.
 *   - Included directories include all files and subfolders by default.
 *     - subfolders can be excluded with an Exclude pattern.
 *   - debug messages have been added to try to locate where the FileMove failure is occuring.
 *   - dated backup folder names have been changed to remove the space in them.
 *   - Patterns now have a Debug option to allow their effect to be traced.
 *   - the <log> section has been removed from .ctrl files.
 * 
 */



namespace KeepBack
{
	static class Program
	{
		const string version = "v1.04";

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main( string[] args )
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault( false );
			FormMain f = new FormMain();
			f.Version = version;
			if( args.Length > 0 )
			{
				f.Filename = args[0];
			}
			Application.Run( f );
		}
	}
}
