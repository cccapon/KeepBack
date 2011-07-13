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
using System.Text;

namespace KeepBack
{
	public struct HistoryFile
	{
		public string      name     ; // filename
		public ulong       size     ; // size of file in bytes
		public ulong       hsize    ; // total size of all versions of this file in all history date folders
		public DateTime    modified ; // most recent modified date from most current date folder
		public byte    []  history  ; // bits indicating which history date folders this folder appears in
	}
}
