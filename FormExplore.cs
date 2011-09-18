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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KeepBack
{
	public partial class FormExplore : Form
	{
		struct HistoryFile
		{
			BitArray history;
			ulong    size;
			string   name;

			public HistoryFile( int histories, string name )
			{
				this.history = new BitArray( histories );
				this.size    = 0;
				this.name    = name;
			}
		}
		struct HistoryFolder
		{
			BitArray        history;
			ulong           count;
			ulong           size;
			string          name;
			HistoryFolder[] folders;
			HistoryFile  [] files;

			public HistoryFolder( int histories, string name )
			{
				this.history = new BitArray( histories );
				this.count   = 0;
				this.size    = 0;
				this.name    = name;
				this.folders = null;
				this.files   = null;
			}
		}

		HistoryFolder  root;


		public FormExplore()
		{
			InitializeComponent();
		}

		void Scan( string path )
		{


		}

	}
}