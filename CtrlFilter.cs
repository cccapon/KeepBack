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

namespace KeepBack
{
	public class CtrlFilter
	{
		//--- define ----------------------------

		public enum ActionType
		{
			Include,
			Exclude,
			History,
		}

		//--- field -----------------------------


		ActionType  action        = ActionType.Exclude;
		string      pattern       = null;

		//--- property --------------------------

		[XmlAttribute(AttributeName="action")]
		public ActionType  Action     { get { return action; } set { action = value; } }

		[XmlText]
		public string      Pattern    { get { return pattern; } set { pattern = value; } }

		[XmlIgnore]
		public bool        IsAbsolute { get { return MatchPath.StartsWithDirectorySeparator( pattern ); } }

		[XmlIgnore]
		public bool        IsFolder   { get { return MatchPath.EndsWithDirectorySeparator  ( pattern ); } }

		//--- method ----------------------------

		public override string ToString()
		{
			return action.ToString() + "\t" + (string.IsNullOrEmpty( pattern ) ? string.Empty : pattern);
		}

		//--- end -------------------------------
	}
}
