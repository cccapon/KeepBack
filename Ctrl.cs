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
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace KeepBack
{
	[XmlRoot(ElementName="keepback",Namespace=Ctrl.XmlNamespace)]
	public class Ctrl
	{
		//--- define ----------------------------

		public enum DateFolderLevel : int
		{
			/* Date Folder names
			 * 012345678901234567890
			 * ---------------------
			 * 2011                    year
			 * 2011-09                 month
			 * 2011-09-23              day
			 * 2011-09-23-11           hour
			 * 2011-09-23-1145         minute
			 * 2011-09-23-114528       second
			 * 2011-09-23-114528.log   log filename
			 * ----------------------
			 */
			Year     =  4,
			Month    =  7,
			Day      = 10,
			Hour     = 13,
			Minute   = 15,
			Second   = 17,
		}

		public const string XmlNamespace           = "urn:keepback:schema:2013-02";
		public const string LogFolder              = "logs";
		public const string ArchiveFilename        = "Archive.keep";
		
		const string        ExPath                 = "Ctrl.Path";
		const string        ExFilename             = "Ctrl.Filename";
		const int           Date_Variance_Seconds  = 3; //maximum # of seconds a files date can be different from the archive date


		//--- field -----------------------------

		static TimeSpan   dateVariance    = new TimeSpan( 0, 0, Date_Variance_Seconds );

		string            filename        = null;
		CtrlArchive       archive         = null;

		bool              isUpgraded      = false;             //indicates if the control file was upgraded from an old version.
		bool              isCaseSensitive = false;             //indicates whether archive filesystem distinguishes between upper and lower case or not
		DateTime          minDateUtc      = DateTime.MinValue; //minimum LastWriteUDC date the archive filesystem will accept
		DateTime          maxDateUtc      = DateTime.MaxValue; //maximum LastWriteUDC date the archive filesystem will accept

		//--- property --------------------------

		[XmlIgnore]
		public string        Filename
		{
			get
			{
				return filename;
			}
			set
			{
				try
				{
					filename = System.IO.Path.GetFullPath( value );
				}
				catch( Exception ex )
				{
					ex.Data[ExFilename] = value;
					throw;
				}
			}
		}

		[XmlIgnore]
		public string        Name
		{
			get
			{
				try
				{
					return System.IO.Path.GetFileNameWithoutExtension( filename );
				}
				catch( Exception ex )
				{
					ex.Data[ExFilename] = filename;
					throw;
				}
			}
		}

		[XmlIgnore]
		public string        Path
		{
			get
			{
				try
				{
					return System.IO.Path.GetDirectoryName( filename );
				}
				catch( Exception ex )
				{
					ex.Data[ExFilename] = filename;
					throw;
				}
			}
		}

		[XmlIgnore]
		public bool          IsUpgraded      { get { return isUpgraded; } }

		[XmlIgnore]
		public bool          IsCaseSensitive { get { return isCaseSensitive; } }

		[XmlIgnore]
		public DateTime      MinDateUtc      { get { return minDateUtc; } }

		[XmlIgnore]
		public DateTime      MaxDateUtc      { get { return maxDateUtc; } }

		[XmlElement(ElementName="archive")]
		public CtrlArchive   Archive         { get { return archive ; } set { archive  = value; } }

		//--- method ----------------------------

		public static Ctrl Import( string filename )
		{
			try
			{
				filename = System.IO.Path.GetFullPath( filename );
				if( ! File.Exists( filename ) )
				{
					throw new FileNotFoundException( "Import control file", filename );
				}
				using( XmlReader r = XmlReader.Create( filename ) )
				{
					Ctrl c;
					switch( r.IsStartElement() ? r.NamespaceURI : string.Empty )
					{
						case Ctrl.XmlNamespace:
						{
							c = (Ctrl)(new XmlSerializer( typeof(Ctrl) )).Deserialize( r );
							c.Filename = filename;
							break;
						}
						case v1.Ctrl.XmlNamespace:
						{
							v1.Ctrl c1 = (v1.Ctrl)(new XmlSerializer( typeof(v1.Ctrl) )).Deserialize( r );
							c = c1.Upgrade();
							c.isUpgraded = true;
							break;
						}
						default:
						{
							c = new Ctrl();
							c.Filename = filename;
							break;
						}
					}
					return c;
				}
			}
			catch( Exception ex )
			{
				ex.Data[ExFilename] = filename;
				throw;
			}
		}

		public void Export()
		{
			try
			{
				XmlSerializer     x = new XmlSerializer( typeof(Ctrl) );
				XmlWriterSettings s = new XmlWriterSettings();
				s.Indent = true;
				using( XmlWriter w = XmlWriter.Create( Filename, s ) )
				{
					x.Serialize( w, this );
				}
			}
			catch( Exception ex )
			{
				ex.Data[ExFilename] = filename;
				throw;
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

		public void TestArchiveDriveProperties()
		{
			string tmpfile = null;
			try
			{
				/* Check that the archive folder exists.
				 */
				if( ! Directory.Exists( Path ) )
				{
					throw new DirectoryNotFoundException( "Archive folder not found." );
				}

				/* Check if filesystem is case sensitive or not
				 * by creating a temporary file with a mixed case,
				 * then attempting to access it using a different
				 * case name.
				 */
				tmpfile = System.IO.Path.Combine( Path, "__TemporaryFile__.txt" );
				//..remove the file if it already exists
				if( File.Exists( tmpfile.ToLower() ) )
				{
					File.Delete( tmpfile.ToLower() );
				}
				using( StreamWriter sw = File.CreateText( tmpfile ) )
				{
					sw.WriteLine( tmpfile );
				}
				this.isCaseSensitive = ! File.Exists( tmpfile.ToLower() );

				/* Find the supported date range for file LastWriteTimeUtc.
				 * Use a binary search to find the min and max dates allowed.
				 */
				DateTime lo = DateTime.MinValue;
				DateTime hi = DateTime.UtcNow;
				while( (this.minDateUtc = hi.AddTicks( (lo.Ticks - hi.Ticks) / 2 )) < hi )
				{
					try
					{
						File.SetLastWriteTimeUtc( tmpfile, this.minDateUtc );
						hi = this.minDateUtc;
					}
					catch( Exception )
					{
						lo = this.minDateUtc;
					}
				}
				lo = DateTime.UtcNow;
				hi = DateTime.MaxValue;
				while( (this.maxDateUtc = lo.AddTicks( (hi.Ticks - lo.Ticks) / 2 )) > lo )
				{
					try
					{
						File.SetLastWriteTimeUtc( tmpfile, this.maxDateUtc );
						lo = this.maxDateUtc;
					}
					catch( Exception )
					{
						hi = this.maxDateUtc;
					}
				}

				//..remove the temporary file
				File.Delete( tmpfile );
			}
			catch( Exception ex )
			{
				ex.Data[ExPath] = Path;
				if( tmpfile != null ) { ex.Data[ExFilename] = tmpfile; }
				throw;
			}
		}

		public string[] HistoryFolders()
		{
			try
			{
				if( ! Directory.Exists( Path ) )
				{
					return new string[] { };
				}
				List<string> a = new List<string>();
				foreach( string x in ListDirectories( Path ) )
				{
					if( IsDateFolder( x ) )
					{
						a.Add( x );
					}
				}
				return a.ToArray();
			}
			catch( Exception ex )
			{
				ex.Data[ExPath] = Path;
				throw;
			}
		}

		public StreamWriter CreateLogFile( DateTime start )
		{
			string logs    = null;
			string logfile = null;
			try
			{
				if( ! Directory.Exists( Path ) )
				{
					throw new DirectoryNotFoundException( "Archive folder not found." );
				}
				logs = System.IO.Path.Combine( Path, LogFolder );
				if( ! Directory.Exists( logs ) )
				{
					Directory.CreateDirectory( logs );
				}
				string st = DateFolder( start, DateFolderLevel.Second );
				logfile = System.IO.Path.Combine( logs, st + ".log" );
				StreamWriter log = new StreamWriter( logfile, false, Encoding.ASCII );
				log.WriteLine( "{0} - {1}", st, Path );
				log.WriteLine();
				return log;
			}
			catch( Exception ex )
			{
				ex.Data[ExPath] = logs ?? Path;
				if( logfile != null ) { ex.Data[ExFilename] = logfile; }
				throw;
			}
		}

		public string LogFullPath( string name )
		{
			try
			{
				return System.IO.Path.Combine( Path, LogFolder, name );
			}
			catch( Exception ex )
			{
				ex.Data[ExFilename] = name;
				throw;
			}
		}

		public string[] LogFiles()
		{
			string logs = null;
			try
			{
				logs = System.IO.Path.Combine( Path, LogFolder );
				if( ! Directory.Exists( logs ) )
				{
					return new string[] { };
				}
				List<string> a = new List<string>();
				foreach( string x in ListFiles( logs ) )
				{
					if( IsDateFolder( x ) )
					{
						a.Add( x );
					}
				}
				return a.ToArray();
			}
			catch( Exception ex )
			{
				ex.Data[ExPath] = logs ?? Path;
				throw;
			}
		}

		public static List<string> ListDirectories( string path )
		{
			try
			{
				List<string> a = new List<string>();
				foreach( string x in Directory.GetDirectories( path ) )
				{
					a.Add( System.IO.Path.GetFileName( x ) );
				}
				a.Sort();
				return a;
			}
			catch( Exception ex )
			{
				ex.Data[ExPath] = path;
				throw;
			}
		}

		public static List<string> ListFiles( string path )
		{
			try
			{
				List<string> a = new List<string>();
				foreach( string x in Directory.GetFiles( path ) )
				{
					a.Add( System.IO.Path.GetFileName( x ) );
				}
				a.Sort();
				return a;
			}
			catch( Exception ex )
			{
				ex.Data[ExPath] = path;
				throw;
			}
		}

		public static string FormatDateFilename( string filename )
		{
			/* 012345678901234567890
			 * 2011     | | | |
			 * 2011-09  | | | |
			 * 2011-09-23 | | |
			 * 2011-09-23-11| |
			 * 2011-09-23-1145|
			 * 2011-09-23-114528
			 * 2011-09-23-114528.log
			 * ----------------------
			 * 2011-09-23 11:45:28
			 */
			filename = filename.ToLower().Replace( ".log", "" );
			if( filename.Length > (int)DateFolderLevel.Day )
			{
				if( filename.Length > (int)DateFolderLevel.Minute ) { filename = filename.Insert( (int)DateFolderLevel.Minute, ":" ); }
				if( filename.Length > (int)DateFolderLevel.Hour   ) { filename = filename.Insert( (int)DateFolderLevel.Hour  , ":" ); }
				filename = filename.Remove( (int)DateFolderLevel.Day, 1 ).Insert( (int)DateFolderLevel.Day, "  " );
			}
			return filename;
		}
		public static string FormatTimeSpan( TimeSpan ts )
		{
			return ts.ToString( (ts.Days > 0) ? @"d\.\ hh\:mm\:ss" : @"hh\:mm\:ss" );
		}

		public static string DateFolder( DateTime date, DateFolderLevel level )
		{
			return date.ToString( @"yyyy-MM-dd-HHmmss", DateTimeFormatInfo.InvariantInfo ).Substring( 0, (int)level );
		}
		public static bool IsDateFolder( string path )
		{
			try
			{
				path = System.IO.Path.GetFileNameWithoutExtension( path );
				switch( path.Length )
				{
					case (int)DateFolderLevel.Year  : return IsDateFolder( path, "####"              );
					case (int)DateFolderLevel.Month : return IsDateFolder( path, "####-##"           );
					case (int)DateFolderLevel.Day   : return IsDateFolder( path, "####-##-##"        );
					case (int)DateFolderLevel.Hour  : return IsDateFolder( path, "####-##-##-##"     );
					case (int)DateFolderLevel.Minute: return IsDateFolder( path, "####-##-##-####"   );
					case (int)DateFolderLevel.Second: return IsDateFolder( path, "####-##-##-######" );
				}
				return false;
			}
			catch( Exception ex )
			{
				ex.Data[ExPath] = path;
				throw;
			}
		}
		static bool IsDateFolder( string filename, string pattern )
		{
			int len = pattern.Length;
			while( --len >= 0 )
			{
				switch( pattern[len] )
				{
					case '#':  if( ! char.IsDigit( filename, len ) ) { return false; }  break;
					case '-':  if( filename[len] != '-'            ) { return false; }  break;
					default :                                          return false;
				}
			}
			return true;
		}

		public bool FileDateMatches( DateTime a, DateTime b )
		{
			/* the dates are checked to see if they are within a variance of each other.
			 * this allows for differences in date handling for different filesystems.
			 * up to 2 seconds difference has been observed going from NTFS to FAT32.
			 */
			a = DateAdjust( a );
			b = DateAdjust( b );
			TimeSpan ts = (a >= b) ? (a - b) : (b - a);
			return (ts < dateVariance);
		}

		DateTime DateAdjust( DateTime date )
		{
			// dates are adjusted to fit within the min and max bounds the archive file system supports.
			return (date < minDateUtc) ? minDateUtc : ((date > maxDateUtc) ? maxDateUtc : date);
		}


		//--- end -------------------------------
	}
}
