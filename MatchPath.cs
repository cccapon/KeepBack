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
using System.Text.RegularExpressions;

namespace KeepBack
{
	class MatchPath
	{
		/*
		 * Match filenames and paths with a file pattern string.
		 *    *      = match zero or more characters
		 *    ?      = match zero or one character
		 *    /      = match a directory path character
		 *    \      = match a directory path character
		 *    /.../  = match any number of intermediate directory levels
		 * Patterns that start with a directory character must match entire path, otherwise
		 *   they only have to match the end of the path.  So pattern:
		 *      /abc/file.txt
		 *   matches
		 *      /abc/file.txt
		 *   but not
		 *      /hello/abc/file.txt
		 * Patterns will only match complete files or directories.  So, a pattern like:
		 *      fred/file.txt
		 *   will match
		 *      /abc/fred/file.txt
		 *   but will not match
		 *      /abc/defred/file.txt
		 *   To match the above example, here is a pattern that would work:
		 *      *fred/file.txt
		 * Patterns that end with a directory character will be compared against directories
		 *   only.  Otherwise they will be compared against files only.  The ending directory
		 *   character is not part of the pattern matching and is removed.
		 * Include patterns
		 *   If none are provided then all files and folders are matched.
		 *   If '*' is the only pattern then all files are matched but empty folders are not.
		 */

		//--- field -----------------------------
		string  pattern;
		Regex   reg;
		bool    debug;
		bool    isDirectory;
		bool    isFullPath;
		//--- property --------------------------
		public string Pattern     { get { return pattern    ; } }
		public Regex  Regex       { get { return reg        ; } }
		public bool   Debug       { get { return debug      ; } }
		public bool   IsDirectory { get { return isDirectory; } }
		public bool   IsFullPath  { get { return isFullPath ; } }
		//--- constructor -----------------------
		public MatchPath( string pattern, bool debug, bool caseSensitive )
		{
			this.pattern = pattern;
			this.debug   = debug;
			//..we use a directory separator test a lot, so prepare the sequence
			string ds = Regex.Escape( Path.DirectorySeparatorChar.ToString() + Path.AltDirectorySeparatorChar.ToString() );
			string dsY = @"[" + ds + @"]";
			string dsN = @"[^" + ds + @"]";
			//..if a pattern ends with a folder character, it is intended to only match a directory
			//..otherwise, it is only intended to match a file
			if( isDirectory = EndsWithDirectorySeparator( pattern ) )
			{
				//..remove ending directory character
				pattern = pattern.Substring( 0, pattern.Length - 1 );
			}
			//..if a pattern starts with a folder character we assume it must match the entire path.
			//..if a pattern doesn't start with a folder character, we add one to ensure the pattern doesn't match only the latter part of a folder name.
			//..preceed special characters with the '\' escape character
			isFullPath = StartsWithDirectorySeparator( pattern );
			string s = isFullPath ? (@"^" + Regex.Escape( pattern )) : Regex.Escape( Path.DirectorySeparatorChar.ToString() + pattern );

			//..switch alternate directory separator characters to regular directory separator characters
			s = s.Replace( Regex.Escape( Path.AltDirectorySeparatorChar.ToString() ), Regex.Escape( Path.DirectorySeparatorChar.ToString() ) );
			//..switch directory separator characters for a pattern which matches either directory separator
			s = s.Replace( Regex.Escape( Path.DirectorySeparatorChar.ToString() ), dsY );
			//..check for the ... elipse
			s = s.Replace( dsY + Regex.Escape( @"..." ) + dsY, dsY + @"(.*" + dsY + @")*" );
			//..convert '?' character
			s = s.Replace( Regex.Escape( @"?" ), dsN + @"?" );
			//..convert '*' character
			s = s.Replace( Regex.Escape( @"*" ), dsN + @"*" );
			//..all patterns have to match the end of string
			s = s + @"$";

			RegexOptions opts = RegexOptions.Compiled | RegexOptions.Singleline;
			if( ! caseSensitive )
			{
				opts |= RegexOptions.IgnoreCase;
			}

			reg = new Regex( s, opts );
		}
		//--- method ----------------------------
		public bool Matches( string text )
		{
			if( ! StartsWithDirectorySeparator( text ) )
			{
				text = Path.DirectorySeparatorChar.ToString() + text;
			}
			return reg.IsMatch( text );
		}
		public static bool StartsWithDirectorySeparator( string text )
		{
			char c = string.IsNullOrEmpty( text ) ? '\0' : text[0];
			return ((c == Path.DirectorySeparatorChar) || (c == Path.AltDirectorySeparatorChar));
		}
		public static bool EndsWithDirectorySeparator( string text )
		{
			char c = string.IsNullOrEmpty( text ) ? '\0' : text[text.Length - 1];
			return ((c == Path.DirectorySeparatorChar) || (c == Path.AltDirectorySeparatorChar));
		}
		public static string[] Test()
		{
			List<string> err = new List<string>();
			MatchPath p;

			p = new MatchPath( @"*.txt", false, false );
			{
				Test( err, p, @"abc.txt", true );
				Test( err, p, @"/abc/def.txt", true );
			}
			p = new MatchPath( @"d*e.txt", false, false );
			{
				Test( err, p, @"/abc/de.txt", true );
				Test( err, p, @"/abc/dfg/hie.txt", false );
			}
			p = new MatchPath( @"fred/Bar?ney.*", false, false );
			{
				Test( err, p, @"/abc/fred/Barney.pdf", true );
				Test( err, p, @"/abc/def/ghfred/Barney.txt", false );
				Test( err, p, @"/abc/def/fred/BarZney.txt", true );
				Test( err, p, @"/abc/def/fred/BarZZney.txt", false );
				Test( err, p, @"\abc\def\fred\Barney.txt", true );
			}
			p = new MatchPath( @"*fred/Bar?ney.*", false, false );
			{
				Test( err, p, @"/abc/fred/Barney.pdf", true );
				Test( err, p, @"/abc/def/ghfred/Barney.txt", true );
			}
			p = new MatchPath( @"/fred/Bar?ney.*", false, false );
			{
				Test( err, p, @"/abc/fred/Barney.pdf", false );
				Test( err, p, @"/fred/Barney.txt", true );
			}
			p = new MatchPath( @"/hello/.../fred/Bar?ney.*", false, false );
			{
				Test( err, p, @"/hello/there/fred/Barney.pdf", true );
				Test( err, p, @"/hello/there/how/are/you/fred/Barney.txt", true );
				Test( err, p, @"/hello/fred/Barney.txt", true );
			}
			p = new MatchPath( @"/hello/.../there/.../fred/Bar?ney.*", false, false );
			{
				Test( err, p, @"/hello/there/fred/Barney.pdf", true );
				Test( err, p, @"/hello/there/how/are/you/fred/Barney.txt", true );
				Test( err, p, @"/hello/fred/Barney.txt", false );
				Test( err, p, @"/hello/fred/there/Barney.txt", false );
			}
			p = new MatchPath( @"/hello/.../there/.../fred/Bar?ney.*", false, false );
			{
				Test( err, p, @"/hello/hi/there/way/fred/Barney.pdf", true );
				Test( err, p, @"/hello/hi/how/there/how/are/you/fred/Barney.txt", true );
				Test( err, p, @"/hello/there/fred/Barney.txt", true );
			}

			return err.ToArray();
		}
		static void Test( List<string> err, MatchPath p, string txt, bool match )
		{
			if( p.Matches( txt ) != match )
			{
				err.Add( "\"" + p.Pattern + "\" --> \"" + p.Regex + "\" --> \"" + txt + "\" --> expect " + match );
			}
		}
		//--- end -------------------------------
	}
}
