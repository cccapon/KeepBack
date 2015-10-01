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
using System.IO;
using System.Text;

namespace KeepBack
{
	class MatchSet
	{
		//--- field -----------------------------

		MatchPath[]    includeFolder;
		MatchPath[]    includeFile;
		MatchPath[]    historyFolder;
		MatchPath[]    historyFile;

		//--- constructor -----------------------

		public MatchSet( CtrlFilter[] list, bool isCaseSensitive )
		{
			List<MatchPath> ifo = new List<MatchPath>();
			List<MatchPath> ifi = new List<MatchPath>();
			List<MatchPath> hfo = new List<MatchPath>();
			List<MatchPath> hfi = new List<MatchPath>();
			if( list != null )
			{
				foreach( CtrlFilter f in list )
				{
					string s = f.Pattern;
					if( ! string.IsNullOrEmpty( s ) )
					{
						s = s.Trim();
						if( ! string.IsNullOrEmpty( s ) )
						{
							MatchPath mp = new MatchPath( f.Action, s, isCaseSensitive );
							switch( f.Action )
							{
								case CtrlFilter.ActionType.Include:  if( mp.IsDirectory ) { ifo.Add( mp ); } else { ifi.Add( mp ); } break;
								case CtrlFilter.ActionType.Exclude:  if( mp.IsDirectory ) { ifo.Add( mp ); } else { ifi.Add( mp ); } break;
								case CtrlFilter.ActionType.History:  if( mp.IsDirectory ) { hfo.Add( mp ); } else { hfi.Add( mp ); } break;
							}
						}
					}
				}
			}
			this.includeFolder  = ifo.ToArray();
			this.includeFile    = ifi.ToArray();
			this.historyFolder  = hfo.ToArray();
			this.historyFile    = hfi.ToArray();
		}

		//--- method ----------------------------

		public bool IsHistoryFolder( string path )
		{
			return IsHistory( historyFolder, path );
		}
		public bool IsHistoryFile( string path )
		{
			return IsHistory( historyFile, path );
		}
		bool IsHistory( MatchPath[] list, string path )
		{
			foreach( MatchPath mp in list )
			{
				if( mp.Matches( path ) )
				{
					//..no history is kept for this folder/file
					return false;
				}
			}
			//..history will be maintained for this folder/file
			return true;
		}

		public bool IsIncludedFolder( string path )
		{
			return IsIncluded( includeFolder, path );
		}
		public bool IsIncludedFile( string path )
		{
			return IsIncluded( includeFile, path );
		}
		bool IsIncluded( MatchPath[] list, string path )
		{
			bool b = true;  //..if no patterns match, assume folder/file is included
			foreach( MatchPath mp in list )
			{
				if( mp.Matches( path ) )
				{
					switch( mp.Action )
					{
						//..all patterns are applied in order.  The result is based on the last match.
						case CtrlFilter.ActionType.Include:  b = true ;  break;
						case CtrlFilter.ActionType.Exclude:  b = false;  break;
					}
				}
			}
			return b;
		}

		//--- end -------------------------------
	}
}
