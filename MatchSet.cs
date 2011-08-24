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
	class MatchSet : IEnumerable<MatchPath>
	{
		//--- define ----------------------------
		public enum SetType : int
		{
			Include  = 1,
			Exclude  = 2,
			History  = 3,
		}
		public delegate void MatchDelegate( SetType type, MatchPath pattern, string path );
		//--- field -----------------------------
		SetType        type;
		MatchPath[]    list;
		MatchDelegate  match;
		//--- property --------------------------
		public MatchPath[] List { get { return list; } }
		//--- constructor -----------------------
		public MatchSet( SetType type, CtrlPattern[] list, MatchDelegate match )
		{
			List<MatchPath> a = new List<MatchPath>();
			if( list != null )
			{
				foreach( CtrlPattern p in list )
				{
					string s = p.Pattern;
					if( ! string.IsNullOrEmpty( s ) && ! string.IsNullOrEmpty( s.Trim() ) )
					{
						a.Add( new MatchPath( s, p.Debug, p.CaseSensitive ) );
					}
				}
			}
			this.type  = type;
			this.list  = a.ToArray();
			this.match = match;
		}
		//--- method ----------------------------
		public bool MatchDirectory( string path )
		{
			return IsMatch( path, true );
		}
		public bool MatchFile( string path )
		{
			return IsMatch( path, false );
		}
		bool IsMatch( string path, bool directory )
		{
			if( list.Length <= 0 )
			{
				return (type == SetType.Include) ? true : false;
			}
			foreach( MatchPath mp in list )
			{
				if( (mp.IsDirectory == directory) && mp.Matches( path ) )
				{
					if( mp.Debug && (match != null) )
					{
						match( type, mp, path );
					}
					return true;
				}
			}
			return false;
		}
		//--- interface -------------------------
		#region IEnumerable<MatchPath> Members

		public IEnumerator<MatchPath> GetEnumerator()
		{
			return ((IEnumerable<MatchPath>)this.list).GetEnumerator();
		}

		#endregion
		#region IEnumerable Members

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return this.list.GetEnumerator();
		}

		#endregion
		//--- end -------------------------------
	}
}
