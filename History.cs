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
	/*
	 * Scanning
	 * - Scan each history folder from most current to least current
	 * - Store history folders in reverse order
	 * - the history bits in root folder are used to track which history folders have been scanned
	 * - the history bits in folders under root indicate if they have been scanned for that history level yet
	 */
	public class History
	{
		//--- field -----------------------------
		string         archive;
		string[]       history  = null;
		ushort         bytes    = 0;
		HistoryFolder  root     = new HistoryFolder();
		//--- constructor -----------------------
		public History( string archive )
		{
			this.archive  = Path.GetFullPath( archive );
		}
		//--- method ----------------------------

		public void Reset()
		{
			List<string> a = new List<string>();
			foreach( string x in Directory.GetDirectories( this.archive, Archive.ARCHIVE_PATTERN + "*" ) )
			{
				a.Add( Path.GetFileName( x ) );
			}
			a.Sort();

			this.history  = a.ToArray();
			this.bytes    = (ushort)((this.history.Length + 7) / 8);
			this.root     = new HistoryFolder();
		}
		public void Scan()
		{
			if( this.root.history == null )
			{
				this.root.history = NewHistory();
			}

		}

		byte[] NewHistory()
		{
			byte[] b = new byte[bytes];
			Array.Clear( b, 0, b.Length );
			return b;
		}




		//--- end -------------------------------
	}
}
