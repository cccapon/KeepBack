# KeepBack
A simple backup solution which preserves personal files and their history.

Author: Chris Capon

KeepBack is licensed under the GPL (see License.txt).

For installation instructions, please refer to the PDF documentation included.  For further information, please visit:

   https://github.com/cccapon/KeepBack/

KeepBack is a small backup application.  It is used to archive files and directories to USB hard drives or to Network Attached Storage (NAS) drives.

KeepBack is intended for the home user and has these features:

## Keeps historical copies:
Extra copies of all of your documents are maintained going back in time.  If disaster strikes and your current file becomes corrupt, an older copy may save the day.

## Reverse incremental backups:
With KeepBack, the most recent backup is a complete replica of all your current files.  Older backups only have copies of files that changed from one backup to the next.

## Can be safely interrupted:
While underway, backups can be stopped at any time without concern and restarted at a later date.  Files already preserved, stay preserved.  Only outstanding changed files will be backed up when KeepBack is launched again.

## Automatic maintenance of backup sets:
KeepBack has a system in place to merge older backups to conserve disk space. This is done over time based on a schedule you set.

## Portable across platforms:
Written in C#, KeepBack can be run on any system which supports the .NET platform.  This includes systems which support the Mono run-time environment. KeepBack has run successfully on Windows XP, Vista, Windows 7 and Debian GNU/Linux.

