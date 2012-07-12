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
using System.Text;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace KeepBack.V1
{
	public class CtrlFolder
	{
		//--- field -----------------------------

		string         name     = null;
		string         path     = null;
		CtrlPattern[]  include  = null;
		CtrlPattern[]  exclude  = null;
		CtrlPattern[]  history  = null;

		//--- property --------------------------

		[XmlAttribute(AttributeName="name")]
		public string         Name     { get { return name; } set { name = value; } }

		[XmlAttribute(AttributeName="path")]
		public string         Path     { get { return path; } set { path = value; } }

		[XmlArray(ElementName="includes")] [XmlArrayItem(ElementName="include")]
		public CtrlPattern[]  Include  { get { return include; } set { include = value; } }

		[XmlArray(ElementName="excludes")] [XmlArrayItem(ElementName="exclude")]
		public CtrlPattern[]  Exclude  { get { return exclude; } set { exclude = value; } }

		[XmlArray(ElementName="histories")] [XmlArrayItem(ElementName="history")]
		public CtrlPattern[]  History  { get { return history; } set { history = value; } }

		//--- end -------------------------------
	}
}
