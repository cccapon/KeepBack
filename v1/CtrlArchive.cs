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
using System.Xml.Serialization;
using System.Windows.Forms;

namespace KeepBack.V1
{
	public class CtrlArchive
	{
		//--- field -----------------------------

		string        root      = "";
		string        path      = "";
		string        name      = "";
		int           month     = 0;
		int           day       = 0;
		int           hour      = 0;
		int           minute    = 0;
		CtrlFolder[]  folders   = null;

		//--- property --------------------------

		[XmlAttribute(AttributeName="root")]
		public string       Root      { get { return root   ; } set { root    = value; } }

		[XmlAttribute(AttributeName="path")]
		public string       Path      { get { return path   ; } set { path    = value; } }

		[XmlAttribute(AttributeName="name")]
		public string       Name      { get { return name   ; } set { name    = value; } }

		[XmlIgnore]
		public string       FullPath  { get { return System.IO.Path.Combine( root, System.IO.Path.Combine( path, name ) ); } }

		[XmlAttribute(AttributeName="month")]
		public int          Month     { get { return month  ; } set { month   = value; } }

		[XmlAttribute(AttributeName="day")]
		public int          Day       { get { return day    ; } set { day     = value; } }

		[XmlAttribute(AttributeName="hour")]
		public int          Hour      { get { return hour   ; } set { hour    = value; } }

		[XmlAttribute(AttributeName="minute")]
		public int          Minute    { get { return minute ; } set { minute  = value; } }

		[XmlArray(ElementName="folders")] [XmlArrayItem(ElementName="folder")]
		public CtrlFolder[] Folders { get { return folders; } set { folders = value; } }


		//--- method ----------------------------

		public void Upgrade( KeepBack.CtrlArchive archive )
		{
			archive.Month   = Month;
			archive.Day     = Day;
			archive.Hour    = Hour;
			archive.Minute  = Minute;
			foreach( CtrlFolder f in folders )
			{
				f.Upgrade( archive.FolderAdd() );
			}
		}

		//--- end -------------------------------
	}
}
