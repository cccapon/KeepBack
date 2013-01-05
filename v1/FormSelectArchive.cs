using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KeepBack.v1
{
	public partial class FormSelectArchive : Form
	{
		public FormSelectArchive( string[] archives )
		{
			InitializeComponent();
			listBoxArchive.Items.AddRange( archives );
			listBoxArchive.SelectedIndex = 0;
		}
		public int SelectedArchive()
		{
			return listBoxArchive.SelectedIndex;
		}
	}
}
