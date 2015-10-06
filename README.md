# KeepBack

__A backup tool which preserves personal files and their history.__

For installation instructions, please refer to the __PDF__ documentation included.
For further information, please visit:

   https://github.com/cccapon/KeepBack/

_KeepBack_ is a small backup application.  It is used to archive files and directories to USB hard drives or to Network Attached Storage (NAS) drives.

## Features

_KeepBack_ is intended for the home user and has these features:

* __Keeps historical copies:__

Extra copies of all of your documents are maintained going back in time.  If disaster strikes and your current file becomes corrupt, an older copy may save the day.

* __Reverse incremental backups:__

With _KeepBack_, the most recent backup is a complete replica of all your current files.  Older backups only have copies of files that changed from one backup to the next.

* __Can be safely interrupted:__
 
While underway, backups can be stopped at any time without concern and restarted at a later date.  Files already preserved, stay preserved.  Only outstanding changed files will be backed up when KeepBack is launched again.

* __Automatic maintenance of backup sets:__

_KeepBack_ has a system in place to merge older backups to conserve disk space. This is done over time based on a schedule you set.

* __Portable across platforms:__

Written in __C#__, _KeepBack_ can be run on any system which supports the __.NET platform__.  This includes systems which support the Mono run-time environment. KeepBack has run successfully on __Windows XP__, __Vista__, __Windows 7__ and __Debian GNU/Linux__.


_KeepBack_ is licensed under the __GPL__ (see __*License*__).

Author: Chris Capon
