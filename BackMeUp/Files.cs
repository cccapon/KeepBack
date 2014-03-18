using System;
using System.IO;

namespace BackMeUp
{
	public class Files
	{
		public static void DirectoryCreate( string path )
		{
			try
			{
				Directory.CreateDirectory( path );
			}
			catch( Exception ex )
			{
				throw new Exception( string.Format( "Can not create Folder \"{0}\"", path ), ex );
			}
		}
		public static void DirectoryMove( string from, string to )
		{
			try
			{
				Directory.Move( from, to );
			}
			catch( Exception ex )
			{
				throw new Exception( string.Format( "Can not move Folder \"{0}\" to \"{1}\"", from, to ), ex );
			}
		}
		public static void FileMove( string from, string to )
		{
			try
			{
				File.Move( from, to );
			}
			catch( Exception ex )
			{
				throw new Exception( string.Format( "Can not move File \"{0}\" to \"{1}\"", from, to ), ex );
			}
		}
		public static bool FileDelete( string path )
		{
			try
			{
				if( File.Exists( path ) )
				{
					File.Delete( path );
				}
				return true;
			}
			catch( Exception )
			{
				return false;
			}
		}

	}
}
