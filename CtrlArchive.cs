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

namespace KeepBack
{
	public class CtrlArchive
	{
		//--- define ----------------------------

		public const string  ARCHIVE_PATTERN = @"????-??-??-????";

		//--- field -----------------------------

		string        path      = "";
		int           month     = 0;
		int           day       = 0;
		int           hour      = 0;
		int           minute    = 0;
		CtrlFolder[]  folders   = null;

		//--- property --------------------------

		[XmlIgnore]
		public string       Name      { get { return System.IO.Path.GetFileName( path ?? "" ); } }

		[XmlAttribute(AttributeName="path")]
		public string       Path      { get { return path   ; } set { path    = value; } }

		[XmlIgnore]
		public string       FullPath  { get { return System.IO.Path.GetFullPath( path ?? "" ); } }

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

		public override string ToString()
		{
			return Name;
		}
		public void FolderSort()
		{
			if( folders != null )
			{
				Array.Sort<CtrlFolder>( folders );
			}
		}
		public CtrlFolder FolderAdd()
		{
			CtrlFolder f = new CtrlFolder();
			List<CtrlFolder> list = (folders == null) ? new List<CtrlFolder>() : new List<CtrlFolder>( folders );
			list.Add( f );
			folders = list.ToArray();
			return f;
		}
		public void FolderDelete( CtrlFolder folder )
		{
			if( folders != null )
			{
				List<CtrlFolder> list = new List<CtrlFolder>( folders );
				list.Remove( folder );
				folders = (list.Count > 0) ? list.ToArray() : null;
			}
		}


		public string[] ArchiveList()
		{
			if( Directory.Exists( FullPath ) )
			{
				try
				{
					List<string> a = new List<string>();
					foreach( string x in Directory.GetDirectories( FullPath, ARCHIVE_PATTERN + @"*" ) )
					{
						a.Add( System.IO.Path.GetFileName( x ) );
					}
					a.Sort();
					return a.ToArray();
				}
				catch( Exception )
				{
				}
			}
			return new string[] { };
		}
		public string[] ArchiveLogList()
		{
			if( Directory.Exists( FullPath ) )
			{
				try
				{
					List<string> a = new List<string>();
					foreach( string x in Directory.GetFiles( FullPath, ARCHIVE_PATTERN + @"*.log" ) )
					{
						a.Add( System.IO.Path.GetFileName( x ) );
					}
					a.Sort();
					return a.ToArray();
				}
				catch( Exception )
				{
				}
			}
			return new string[] { };
		}

		public static string ArchiveDisplay( string folder )
		{
			/*  012345678901234567890
			 * "2011-09-23-1145"
			 * "2011-09-23-114528"
			 * "2011-09-23-114528.log"
			 */
			folder = folder.ToLower().Replace( ".log", "" );
			if( folder.Length > 15 )
			{
				folder = folder.Insert( 15, ":" );
			}
			return folder.Insert( 13, ":" ).Remove( 10, 1 ).Insert( 10, " (" ) + ")";
		}

		//--- end -------------------------------
	}
}
