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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace KeepBack
{
	public partial class FormMain : Form
	{
		string          version          = "";
		string          filename         = null;

		Thread          thread           = null;
		Archive         current          = null;

		long            created          = 0;
		long            modified         = 0;
		long            deleted          = 0;
		long            skipped          = 0;


		public string Version
		{
			set
			{
				version = value;
				SetHeader();
			}
		}
		public string Filename
		{
			get 
			{
				return filename;
			}
			set
			{
				filename = value;
				SetHeader();
			}
		}
		void SetHeader()
		{
			this.Text = "KeepBack";
			if( ! string.IsNullOrEmpty( version ) )
			{
				this.Text += " " + version;
			}
			if( ! string.IsNullOrEmpty( filename ) )
			{
				filename = Path.GetFullPath( filename );
				this.Text += " - " + filename;
			}
			ButtonEnable( true );
		}

		public FormMain()
		{
			InitializeComponent();
		}

		private void FormMain_Load( object sender, EventArgs e )
		{
			SetHeader();
		}




		private void MenuNew_Click( object sender, EventArgs e )
		{
			SaveFileDialog f = new SaveFileDialog();
			f.AddExtension = true;
			f.CheckPathExists = true;
			f.CreatePrompt = false;
			f.DefaultExt = "ctrl";
			f.Filter           = "control files (*.keep)|*.keep";
			f.FilterIndex      = 1;
			f.InitialDirectory = System.Environment.GetFolderPath( System.Environment.SpecialFolder.MyDocuments );
			f.OverwritePrompt = true;
			f.RestoreDirectory = true;
			f.Title = "Where should the new control file be saved?";
			if( f.ShowDialog() == DialogResult.OK )
			{
				Filename = f.FileName;
				try
				{
					Ctrl ctrl = new Ctrl();
					ctrl.Export( Filename );
				}
				catch( Exception ex )
				{
#if DEBUG
					MessageBox.Show( ex.ToString() );
#else
					MessageBox.Show( ex.Message );
#endif
				}
			}
		}

		private void MenuOpen_Click( object sender, EventArgs e )
		{
			OpenFileDialog f = new OpenFileDialog();
			f.CheckFileExists  = true;
			f.InitialDirectory = System.Environment.GetFolderPath( System.Environment.SpecialFolder.MyDocuments );
			f.Filter           = "control files (*.keep)|*.keep|All files (*.*)|*.*";
			f.FilterIndex      = 1;
			f.RestoreDirectory = true;
			f.Title = "Select a backup control file to work with.";
			if( f.ShowDialog() == DialogResult.OK )
			{
				Filename = f.FileName;
			}
		}

		private void MenuClose_Click( object sender, EventArgs e )
		{
			Filename = "";
		}

		private void MenuExit_Click( object sender, EventArgs e )
		{
			this.Close();
		}

		private void MenuEdit_Click( object sender, EventArgs e )
		{
			try
			{
				FormEdit f = new FormEdit( Ctrl.Import( filename ) );
				f.ShowDialog();
			}
			catch( Exception ex )
			{
#if DEBUG
				MessageBox.Show( ex.ToString() );
#else
				MessageBox.Show( ex.Message );
#endif
			}
		}

		private void MenuExplore_Click( object sender, EventArgs e )
		{
			try
			{
				FormHistory f = new FormHistory();
				f.ShowDialog();
			}
			catch( Exception ex )
			{
#if DEBUG
				MessageBox.Show( ex.ToString() );
#else
				MessageBox.Show( ex.Message );
#endif
			}
		}

		private void MenuMerge_Click( object sender, EventArgs e )
		{
			if( ! string.IsNullOrEmpty( filename ) )
			{
				ClearValues();
				thread = new Thread( new ParameterizedThreadStart( this.Launch ) );
				thread.Start( "Merge" );
			}
		}

		private void MenuBackup_Click( object sender, EventArgs e )
		{
			if( newToolStripMenuItem.Enabled )
			{
				if( ! string.IsNullOrEmpty( filename ) )
				{
					ClearValues();
					thread = new Thread( new ParameterizedThreadStart( this.Launch ) );
					thread.Start( "Backup" );
				}
			}
			else
			{
				Archive a = current;
				if( a != null )
				{
					a.Cancel = true;
				}
			}
		}

		private void MenuAbout_Click( object sender, EventArgs e )
		{
			try
			{
				FormAbout f = new FormAbout();
				f.Version = version;
				f.ShowDialog();
			}
			catch( Exception ex )
			{
#if DEBUG
				MessageBox.Show( ex.ToString() );
#else
				MessageBox.Show( ex.Message );
#endif
			}
		}

		void ClearValues()
		{
			labelCreated   .Text = "";
			labelModified  .Text = "";
			labelDeleted   .Text = "";
			labelSkipped   .Text = "";
		}

		private void Launch( object parm )
		{
			try
			{
				string s = (string)parm;
				current = null;
				ButtonEnable( false );

				ArchiveAction(Archive.Action.Info, "" );
				ArchiveAction(Archive.Action.Info, "==== Begin ====" );
				ArchiveAction(Archive.Action.Info, "Control File   " + filename );

				created              = 0;
				modified             = 0;
				deleted              = 0;
				skipped              = 0;

				Ctrl c = Ctrl.Import( filename );
				if( c.Archives != null )
				{
					foreach( CtrlArchive ca in c.Archives )
					{
						using( current = new Archive( new Archive.ActionDelegate( this.ArchiveAction ), ca, true, debugToolStripMenuItem.Checked ) )
						{
							switch( s )
							{
								case "Backup":  current._Merge(); current._Backup( filename );  break;
								case "Merge" :  current._Merge();                    break;
							}
							if( current.Cancel )
							{
								break;
							}
						}
						current = null;
					}
				}
				ArchiveAction(Archive.Action.Info, "===== End =====" );
				ArchiveAction(Archive.Action.Info, "" );
			}
			catch( Exception ex )
			{
				ArchiveAction( Archive.Action.Info, ex.ToString() );
			}
			finally
			{
				ButtonEnable( true );
			}
		}

		delegate void ButtonEnableCallback( bool enable );
		private void ButtonEnable( bool enable )
		{
			if( this.InvokeRequired )
			{
				this.Invoke( new ButtonEnableCallback( ButtonEnable ), enable );
				return;
			}
			bool fn = ! string.IsNullOrEmpty( filename );

			//File
			newToolStripMenuItem    .Enabled = enable;
			openToolStripMenuItem   .Enabled = enable;
			closeToolStripMenuItem  .Enabled = enable && fn;

			//Tools
			editToolStripMenuItem   .Enabled = enable && fn;
			exploreToolStripMenuItem.Enabled = enable && fn;
			mergeToolStripMenuItem  .Enabled = enable && fn;
			backupToolStripMenuItem .Enabled = enable && fn;
			debugToolStripMenuItem  .Enabled = enable;

			buttonBackup  .Text    = enable ? "Backup" : "Cancel";
			buttonBackup  .Enabled = fn;
		}

		delegate void ArchiveActionCallback( Archive.Action action, string message );
		private void ArchiveAction( Archive.Action action, string message )
		{
			if( this.InvokeRequired )
			{
				this.Invoke( new ArchiveActionCallback( ArchiveAction ), action, message );
				return;
			}
			switch( action )
			{
				case Archive.Action.Info:
				{
					richTextBoxInfo.AppendText( message + "\r\n" );
					richTextBoxInfo.ScrollToCaret();
					break;
				}
				case Archive.Action.Directory:
				{
					labelCurrentDirectory.Text = message;
					break;
				}
				case Archive.Action.File:
				{
					labelCurrentFile.Text = message;
					break;
				}
				case Archive.Action.Change:
				{
					Archive.Reason reason = (Archive.Reason)Enum.Parse( typeof(Archive.Reason), message );
					if( (reason & Archive.Reason.Created   ) == Archive.Reason.Created   ) { ++created  ;  labelCreated  .Text = created  .ToString(); }
					if( (reason & Archive.Reason.Modified  ) == Archive.Reason.Modified  ) { ++modified ;  labelModified .Text = modified .ToString(); }
					if( (reason & Archive.Reason.Deleted   ) == Archive.Reason.Deleted   ) { ++deleted  ;  labelDeleted  .Text = deleted  .ToString(); }
					break;
				}
				case Archive.Action.Skip:
				{
					++skipped;
					labelSkipped.Text = skipped.ToString();
					break;
				}
			}
		}


	}
}
