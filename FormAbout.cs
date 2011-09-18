using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace KeepBack
{
	public partial class FormAbout : Form
	{
		public FormAbout()
		{
			InitializeComponent();
			this.labelTitle       .Text = Program.AssemblyTitle;
			this.labelDescription .Text = Program.AssemblyDescription;
			this.labelProduct     .Text = Program.AssemblyProduct;
			this.labelVersion     .Text = Program.AssemblyVersion;
			this.labelCopyright   .Text = Program.AssemblyCopyright;
		}

		private void linkLabelSite_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
		{
			try
			{
				if( sender is LinkLabel )
				{
					LinkLabel x = (LinkLabel)sender;
					x.LinkVisited = true;
					System.Diagnostics.Process.Start( x.Text );
				}
			}
			catch( Exception )
			{
			}
		}

	}
}
