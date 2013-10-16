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

namespace KeepBack.v1
{
	[XmlRoot(ElementName="keepback",Namespace=Ctrl.XmlNamespace)]
	public class Ctrl
	{
		//--- define ----------------------------

		public const string XmlNamespace = "http://keepback.org/2008-09/keepback";

		//--- field -----------------------------

		CtrlArchive[]   archives  = null;

		//--- property --------------------------

		[XmlArray(ElementName="archives")] [XmlArrayItem(ElementName="archive")]
		public CtrlArchive[]   Archives  { get { return archives; } set { archives = value; } }

		//--- method ----------------------------

		public KeepBack.Ctrl Upgrade()
		{
			KeepBack.Ctrl c = new KeepBack.Ctrl();
			if( (archives != null) && (archives.Length > 0) )
			{
				int i = 0;
				if( archives.Length > 1 )
				{
					List<string> list = new List<string>();
					foreach( CtrlArchive a in archives )
					{
						list.Add( a.Name );
					}
					v1.FormSelectArchive f = new v1.FormSelectArchive( list.ToArray() );
					if( f.ShowDialog() == DialogResult.OK )
					{
						int j = f.SelectedArchive();
						i = (j >= 0) ? j : i;
					}
				}
				CtrlArchive archive = archives[i];
				archive.Upgrade( c.ArchiveCreate() );
				MessageBox.Show(
					"Upgrading control file...\r\n\r\n"
					+ "Archive path:\r\n\r\n"
					+ "      " + archive.FullPath + "\r\n\r\n"
					+ "The archive path is not kept in the control file any more.  Instead,\r\n"
					+ "the control file is saved in the same folder as the archive.\r\n\r\n"
					+ "When you save the upgraded control file, save it to the folder above."
					, "Upgrade Wizard"
					, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1 
					);
			}
			return c;
		}

		//--- end -------------------------------
	}
}
