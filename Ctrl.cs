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
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace KeepBack
{
	[XmlRoot(ElementName="keepback",Namespace=Ctrl.XmlNamespace)]
	public class Ctrl
	{
		//--- define ----------------------------

		public const string XmlNamespace         = "urn:keepback:schema:2013-02";
		public const string HistoryFolderPattern = @"????-??-??-????";


		//--- field -----------------------------

		bool          upgraded  = false;
		string        filename  = null;
		CtrlArchive   archive   = null;

		//--- property --------------------------

		[XmlIgnore]
		public bool          Upgraded  { get { return upgraded; }                          }

		[XmlIgnore]
		public string        Path      { get { return System.IO.Path.GetDirectoryName( filename ); } }

		[XmlIgnore]
		public string        Name      { get { return System.IO.Path.GetFileNameWithoutExtension( filename ); } }

		[XmlIgnore]
		public string        FileName  { get { return filename; } set { filename = System.IO.Path.GetFullPath( value ); } }

		[XmlElement(ElementName="archive")]
		public CtrlArchive   Archive   { get { return archive ; } set { archive  = value; } }

		//--- method ----------------------------

		public static string RelativePath( string root, string path )
		{
			if( string.IsNullOrEmpty( path ) )
			{
				return root;
			}
			return (string.IsNullOrEmpty( root ) || System.IO.Path.IsPathRooted( path )) ? path : System.IO.Path.Combine( root, path );
		}

		public static Ctrl Import( string filename )
		{
			filename = System.IO.Path.GetFullPath( filename );
			if( ! File.Exists( filename ) )
			{
				throw new ApplicationException( "File not found: " + filename );
			}
			try
			{
				using( XmlReader r = XmlReader.Create( filename ) )
				{
					Ctrl c;
					switch( r.IsStartElement() ? r.NamespaceURI : string.Empty )
					{
						case Ctrl.XmlNamespace:
						{
							c = (Ctrl)(new XmlSerializer( typeof(Ctrl) )).Deserialize( r );
							break;
						}
						case v1.Ctrl.XmlNamespace:
						{
							v1.Ctrl c1 = (v1.Ctrl)(new XmlSerializer( typeof(v1.Ctrl) )).Deserialize( r );
							c = c1.Upgrade();
							c.upgraded = true;
							break;
						}
						default:
						{
							c = new Ctrl();
							break;
						}
					}
					c.FileName = filename;
					return c;
				}
			}
			catch( Exception ex )
			{
				throw new ApplicationException( "Control file: " + filename, ex );
			}
		}

		public void Export( string filename )
		{
			try
			{
				XmlSerializer x = new XmlSerializer( typeof(Ctrl) );
				XmlWriterSettings s = new XmlWriterSettings();
				s.Indent = true;
				using( XmlWriter w = XmlWriter.Create( filename, s ) )
				{
					x.Serialize( w, this );
				}
			}
			catch( Exception ex )
			{
				throw new ApplicationException( "Control file: " + filename, ex );
			}
		}

		public CtrlArchive ArchiveCreate()
		{
			archive = new CtrlArchive();
			return archive;
		}
		public void ArchiveDelete()
		{
			archive = null;
		}

		public string[] HistoryFolders()
		{
			if( Directory.Exists( Path ) )
			{
				try
				{
					List<string> a = new List<string>();
					foreach( string x in Directory.GetDirectories( Path, HistoryFolderPattern + @"*" ) )
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
		public string[] HistoryLogFiles()
		{
			if( Directory.Exists( Path ) )
			{
				try
				{
					List<string> a = new List<string>();
					foreach( string x in Directory.GetFiles( Path, HistoryFolderPattern + @"*.log" ) )
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

		public static string HistoryNameFormatted( string folder )
		{
			/*  012345678901234567890
			 * "2011-09-23-1145"
			 * "2011-09-23-114528"
			 * "2011-09-23-114528.log"
			 * 
			 * "2011-09-23 (11:45:28)"
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
