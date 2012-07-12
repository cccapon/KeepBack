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

namespace KeepBack.V1
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
			if( archives != null )
			{
				foreach( CtrlArchive a in archives )
				{
					a.Upgrade( c );
				}
			}
			return c;
		}

		//--- end -------------------------------
	}
}
