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
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;

namespace KeepBack
{
	public class Except
	{
		//--- method ----------------------------

		static string ToString( object o )
		{
			return (o == null) ? string.Empty : o.ToString();
		}

		public static string ToQuoteString( object o )
		{
			string s = ToString( o );
			for( int i = 0; i < s.Length; ++i )
			{
				if( char.IsWhiteSpace( s, i ) )
				{
					return string.Format( "\"{0}\"", s );
				}
			}
			return s;
		}

		public static string ToString( Exception ex, bool debug )
		{
			StringBuilder sb = new StringBuilder();
			do
			{
				if( sb.Length > 0 )
				{
					sb.AppendLine("---");
				}
				Type type = ex.GetType();
				sb.AppendFormat( "{0}: {1}", type.FullName, ex.Message );
				sb.AppendLine();

				if( ex is System.IO.FileNotFoundException )
				{
					System.IO.FileNotFoundException x = (System.IO.FileNotFoundException)ex;
					sb.AppendFormat( "   Filename: {0}", ToQuoteString( x.FileName ) );
					sb.AppendLine();
				}

				if( ex is System.IO.IOException )
				{
					PropertyInfo pi = type.GetProperty( "HResult", BindingFlags.Instance | BindingFlags.NonPublic );
					uint         hr = (pi == null) ? 0 : (uint)(int)pi.GetValue( ex, null );
					if( hr > 0 )
					{
						string       s;
						switch( hr )
						{
							//VS Documentation: lookup "error codes [Win32]"

							case 0x80070005:  s = "access denied"       ;  break; //(Win32:  5) Access is denied.
							case 0x8007001F:  s = "fault"               ;  break; //(Win32: 31) A device attached to the system is not functioning.
							case 0x80070020:  s = "in use"              ;  break; //(Win32: 32) The process cannot access the file because it is being used by another process.
							case 0x80070057:  s = "invalid parameter"   ;  break; //(Win32: 87) The parameter is incorrect.
							case 0x80070091:  s = "directory not empty" ;  break; //(Win32:145) The directory is not empty.
							case 0x800700B7:  s = "file exists"         ;  break; //(Win32:183) Cannot create a file when that file already exists.
							default        :  s = string.Format( "0x{0}", hr.ToString( "X" ) );  break;
						}
						sb.AppendFormat( "   Win32: {0}", ToQuoteString( s ) );
						sb.AppendLine();
					}
				}

				foreach( DictionaryEntry de in ex.Data )
				{
					sb.AppendFormat( "   {0}: {1}", ToString( de.Key ), ToQuoteString( de.Value ) );
					sb.AppendLine();
				}

				if( debug )
				{
					sb.Append( ex.StackTrace );
					sb.AppendLine();
				}
			}
			while( (ex = ex.InnerException) != null );
			return sb.ToString().Trim();
		}


		//--- end -------------------------------
	}
}
