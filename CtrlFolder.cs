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

namespace KeepBack
{
	public class CtrlFolder : IComparable<CtrlFolder>
	{
		//--- field -----------------------------

		string         name     = null;
		string         path     = null;
		CtrlFilter[]   filters  = null;

		//--- property --------------------------

		[XmlAttribute(AttributeName="name")]
		public string         Name     { get { return name; } set { name = value; } }

		[XmlAttribute(AttributeName="path")]
		public string         Path     { get { return path; } set { path = value; } }

		[XmlArray(ElementName="filters")] [XmlArrayItem(ElementName="filter")]
		public CtrlFilter[]   Filters  { get { return filters; } set { filters = value; } }

		//--- method ----------------------------

		public override string ToString()
		{
			return string.IsNullOrEmpty( name ) ? "" : name;
		}

		public CtrlFilter FilterAdd()
		{
			CtrlFilter f = new CtrlFilter();
			List<CtrlFilter> list = (filters == null) ? new List<CtrlFilter>() : new List<CtrlFilter>( filters );
			list.Add( f );
			filters = list.ToArray();
			return f;
		}
		public bool FilterDelete( CtrlFilter filter )
		{
			bool b = false;
			if( filters != null )
			{
				List<CtrlFilter> list = new List<CtrlFilter>( filters );
				b = list.Remove( filter );
				filters = (list.Count > 0) ? list.ToArray() : null;
			}
			return b;
		}
		public bool Validate()
		{
			bool b = false;
			if( filters != null )
			{
				List<CtrlFilter> list = new List<CtrlFilter>( filters );
				int i = list.Count;
				while( --i >= 0 )
				{
					if( string.IsNullOrEmpty( list[i].Pattern ) )
					{
						list.RemoveAt( i );
						b = true;
					}
				}
				if( b )
				{
					filters = (list.Count > 0) ? list.ToArray() : null;
				}
			}
			return b;
		}

		//--- interface -------------------------

		#region IComparable<CtrlFolder> Members

		public int CompareTo( CtrlFolder other )
		{
			return string.Compare( this.name, other.Name );
		}

		#endregion

		//--- end -------------------------------
	}
}
