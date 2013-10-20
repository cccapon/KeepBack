using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KeepBack
{
	public partial class FormLog : Form
	{
		//--- field -----------------------------

		Ctrl  ctrl;

		//--- constructor -----------------------

		public FormLog( Ctrl ctrl )
		{
			this.ctrl  = ctrl;
			InitializeComponent();
		}

		//--- method ----------------------------

		private void FormLog_Shown( object sender, EventArgs e )
		{
			try
			{
				Rectangle r = this.ClientRectangle;
				AnchorStyles st = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
				panelList .SetBounds( r.X, r.Y, r.Width, r.Height );  panelList .Anchor = st;  panelList.Visible = true;
				panelLog  .SetBounds( r.X, r.Y, r.Width, r.Height );  panelLog  .Anchor = st;  panelLog .Visible = false;

				listViewLogs.Clear();
				if( (ctrl != null) && (ctrl.Archive != null) )
				{
					this.Text = "Log Files - " + ctrl.Path;
					foreach( string s in ctrl.HistoryLogFiles() )
					{
						// "2011-09-23-114528.log"
						ListViewItem li = listViewLogs.Items.Add( Ctrl.HistoryNameFormatted( s ) );
						li.Tag = s;
					}
					listViewLogs.Sorting = SortOrder.Descending;
					listViewLogs.Sort();
				}
			}
			catch( Exception )
			{
			}
		}

		private void listViewLogs_ItemActivate( object sender, EventArgs e )
		{
			try
			{
				panelList.Visible = false;
				panelLog .Visible = true;

				if( listViewLogs.SelectedItems.Count == 1 )
				{
					ListViewItem li = listViewLogs.SelectedItems[0];
					string       s  = li.Tag.ToString();
					if( ! string.IsNullOrEmpty( s ) )
					{
						labelLog.Text = li.Text;
						richTextBoxLog.LoadFile( Archive.PathCombine( ctrl.Path, s ), RichTextBoxStreamType.PlainText );
					}
				}
			}
			catch( Exception )
			{
			}
		}

		private void buttonPrevious_Click( object sender, EventArgs e )
		{
			try
			{
				richTextBoxLog.Clear();
				panelList.Visible = true;
				panelLog .Visible = false;
			}
			catch( Exception )
			{
			}
		}

		//--- end -------------------------------
	}
}
