using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BackMeUp
{
	public class Archive
	{
		public const string DEFAULT_EXT = "bkme";

		public class Folder
		{
			public string    tag;
			public string    path      = string.Empty;
			public string[]  excludes  = new string[] { };
			public string    comment   = string.Empty;

			internal Folder( string tag )
			{
				this.tag  = tag;
			}
		}

		public string    filename;                // archive configuration file.

		public string    path     = string.Empty; // location of archive, may be any rsync connection path
		public string    password = string.Empty; // rsync server password
		public string    comment  = string.Empty; // comments
		public Folder[]  folders  = new Folder[] { };

		public Archive( string filename )
		{
			this.filename = filename;
		}

		static public Archive Parse( string filename )
		{
			using( StreamReader sr = new StreamReader( filename ) )
			{
				Archive archive = new Archive( filename );
				string  text;
				// skip blank lines
				do
				{
					text = ReadLine( sr );
				}
				while( (text != null) && (text == string.Empty) );
				// archive section
				text = Section( text );
				if( text != "archive" )
				{
					throw new Exception( string.Format( "Expected section [archive] at '[{0}]'", text ) );
				}
				// archive fields
				while( (text = ReadLine( sr )) != null )
				{
					if( text != string.Empty )
					{
						if( text.StartsWith( "[" ) )
						{
							// next section
							break;
						}
						string label = Label( ref text );
						if( label == "comment" )
						{
							archive.comment = Comment( ref text, sr );
							break;
						}
						switch( label )
						{
							case "path"    :  archive.path     = text;  break;
							case "password":  archive.password = text;  break;
							default:
							{
								throw new Exception( string.Format( "Unknown archive value '{0}' at '{0}={1}'", label, text ) );
							}
						}
					}
				}
				// folders
				while( text != null )
				{
					// next folder
					Folder f = new Folder( Section( text ) );
					{
						List<Folder> a = new List<Folder>( archive.folders );
						a.Add( f );
						archive.folders = a.ToArray();
					}
					// folder fields
					while( (text = ReadLine( sr )) != null )
					{
						if( text != string.Empty )
						{
							if( text.StartsWith( "[" ) )
							{
								// next section
								break;
							}
							string label = Label( ref text );
							if( label == "comment" )
							{
								f.comment = Comment( ref text, sr );
								break;
							}
							switch( label )
							{
								case "path"   :  f.path  = text;  break;
								case "exclude":
								{
									List<string> a = new List<string>( f.excludes );
									a.Add( text );
									f.excludes = a.ToArray();
									break;
								}
								default:
								{
									throw new Exception( string.Format( "Unknown folder [{0}] value '{1}' at '{1}={2}'", f.tag, label, text ) );
								}
							}
						}
					}
				}
				return archive;
			}
		}

		public void Write( StreamWriter sw )
		{
			sw.WriteLine( "[archive]" );
			if( ! string.IsNullOrEmpty( path     ) ) { sw.WriteLine( "path={0}"    , this.path     ); }
			if( ! string.IsNullOrEmpty( password ) ) { sw.WriteLine( "password={0}", this.password ); }
			if( ! string.IsNullOrEmpty( comment  ) ) { sw.WriteLine( "comment={0}" , this.comment  ); }
			sw.WriteLine();

			// folders
			foreach( Folder f in folders )
			{
				sw.WriteLine( "[{0}]", f.tag );
				if( ! string.IsNullOrEmpty( f.path ) ) { sw.WriteLine( "path={0}", f.path ); }
				foreach( string e in f.excludes )
				{
					sw.WriteLine( "exclude={0}", e );
				}
				if( ! string.IsNullOrEmpty( comment ) ) { sw.WriteLine( "comment={0}", f.comment ); }
				sw.WriteLine();
			}
		}

		static string Comment( ref string text, StreamReader sr )
		{
			StringBuilder sb = new StringBuilder( text );
			while( (text = ReadLine( sr )) != null )
			{
				if( text.StartsWith( "[" ) )
				{
					break;
				}
				if( sb.Length > 0 )
				{
					sb.Append( "\n" );
				}
				sb.Append( text );
			}
			return sb.ToString().Trim();
		}
		static ushort Number( string text )
		{
			try
			{
				return ushort.Parse( text );
			}
			catch( Exception ex )
			{
				throw new Exception( string.Format( "Expected decimal number at '{0}'", text ), ex );
			}
		}
		static string Label( ref string text )
		{
			// label=value
			int i = text.IndexOf( '=' );
			if( i < 0 )
			{
				throw new Exception( string.Format( "Expected label=value at '{0}'", text ) );
			}
			string label = text.Substring( 0, i ).Trim();
			text = text.Substring( i + 1 ).Trim();
			return label;
		}
		static string Section( string text )
		{
			text = text.Trim();
			if( ! text.StartsWith( "[" ) || ! text.EndsWith( "]" ) )
			{
				throw new Exception( string.Format( "Expected [section] at '{0}'", text ) );
			}
			return text.Substring( 1, text.Length - 2 ).Trim();
		}
		static string ReadLine( StreamReader sr )
		{
			string text = sr.ReadLine();
			if( text != null )
			{
				text.Trim();
				if( text.StartsWith( "#" ) )
				{
					text = string.Empty;
				}
			}
			return text;
		}
	}
}
