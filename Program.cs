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
using System.Reflection;
using System.Windows.Forms;

namespace KeepBack
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main( string[] args )
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault( false );
			FormMain f = new FormMain();
			if( args.Length > 0 )
			{
				f.Filename = args[0];
			}
			Application.Run( f );
		}

		public static string AssemblyTitle
		{
			get
			{
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes( typeof( AssemblyTitleAttribute ), false );
				if( attributes.Length > 0 )
				{
					AssemblyTitleAttribute title = (AssemblyTitleAttribute)attributes[0];
					if( title.Title != "" )
					{
						return title.Title;
					}
				}
				return System.IO.Path.GetFileNameWithoutExtension( Assembly.GetExecutingAssembly().CodeBase );
			}
		}

		public static string AssemblyDescription
		{
			get
			{
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes( typeof( AssemblyDescriptionAttribute ), false );
				return (attributes.Length == 0) ? "" : ((AssemblyDescriptionAttribute)attributes[0]).Description;
			}
		}

		public static string AssemblyProduct
		{
			get
			{
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes( typeof( AssemblyProductAttribute ), false );
				return (attributes.Length == 0) ? "" : ((AssemblyProductAttribute)attributes[0]).Product;
			}
		}

		public static string AssemblyVersion
		{
			get
			{
				Version version = Assembly.GetExecutingAssembly().GetName().Version;
				return string.Format( "{0}.{1:D2}", version.Major, version.Minor );
			}
		}

		public static string AssemblyCopyright
		{
			get
			{
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes( typeof( AssemblyCopyrightAttribute ), false );
				return (attributes.Length == 0) ? "" : ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
			}
		}
	}
}
