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


/*
History Browser structures

Item
	filename
	size
	history-size
	history (byte[])
ItemFile : Item
	date-modified
ItemFolder : Item
	file-count
	history-count
	children (Item[])

history
	- byte array
	- sized depending on the number of history folders
		(folders + 7) / 8
        ((8 - 1) + folders) / 8
        (8 + (folders - 1)) / 8
        (8 / 8) + ((folders - 1) / 8)
        1 + ((folders - 1) / 8)
 * 
 * 
children
	- null     = hasn't been scanned yet
	- not-null = list of child Item's (directories first), sorted
file-count
	- >= 0  = count of all files under folder
	-  < 0  = incomplete count, some children haven't fully been scanned
history-count
	- for directories, it tracks sum of history of all children
	- for files, history count is derrived from history (byte[])


 */



/*  Underway
 * ---------------------------------------
 * - when removing a folder from an archive set
 *   - folder is not moved to history on next backup
 *   - have solved this and am testing it now
 * - missing keep file
 *   - create archive with no folders
 *   - do backup
 *   - add new folder to archive
 *   - do backup
 *   - remove folder within same minute
 *   - do backup
 *   - wait a minute
 *   - do backup
 *   - in history folder, .keep file is missing
 *   - trying to find this bug right now
 */



/*  Bug
 * ---------------------------------------
 * - Adding a folder to a new archive
 *   - select folder with directory browser
 *   - change name
 *   - exit without saving, Yes to save changes
 *   - does not retain folder changes
 *   - happens for archive path as well
 * - when a folder is excluded using a filter and that folder already exists in the backup, it will not be cleared out properly by history.
 * - find a better way to detect if file system is case sensitive or not.
 * - this bug occurs when a folder is added to an archive but no path is specified
		Folder-1             
		System.ArgumentNullException: Value cannot be null.
		Parameter name: path1
		   at System.IO.Path.Combine(String path1, String path2)
		   at KeepBack.Archive.CopyFolder(String path, Boolean include) in C:\Documents and Settings\cc\My Documents\KeepBack\Archive.cs:line 641
		   at KeepBack.Archive.BackupCompareFolder(String path, Boolean include, Boolean history) in C:\Documents and Settings\cc\My Documents\KeepBack\Archive.cs:line 264
		   at KeepBack.Archive.Backup(CtrlFolder folder) in C:\Documents and Settings\cc\My Documents\KeepBack\Archive.cs:line 251
		   at KeepBack.Archive.Backup(String archiveFilePath) in C:\Documents and Settings\cc\My Documents\KeepBack\Archive.cs:line 219
		   at KeepBack.FormMain.Launch(Object parm) in C:\Documents and Settings\cc\My Documents\KeepBack\FormMain.cs:line 221
 * 
 * - Add new "exclude folder" to existing archive
 *   - when exclude folder is added, the file exclude icon is displayed rather than folder exclude
 * 
 */



/*  Enhancement
 * ---------------------------------------
 * - display warnings for low disk space
 *   - better: display a meter which shows how much space is used/free
 *     - could this be a running display while the backup proceeds?
 *       - warn as it gets close
 *     - if we run out of space, can backup pause and wait for user to clear space?
 *       - make history browser available for cleanup?
 *       - allow options to change merge criteria
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



/*  History
 * ---------------------------------------
 * 2011-01-20  v1.03
 *   - changed .keep XML to indent text (make it more human readable)
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
		const string version = "v1.03";

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
