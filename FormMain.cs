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
		string          filename         = null;
		Backup          backup           = null;

#if false
		Thread          thread           = null;
		Archive         current          = null;
#endif

		long            created          = 0;
		long            modified         = 0;
		long            deleted          = 0;
		long            skipped          = 0;


		public string Filename   { get { return filename; } set { filename = value; SetHeader(); } }
		public bool   IsFilename { get { return ! string.IsNullOrEmpty( filename ); } }
		public bool   IsDebug    { get { return debugToolStripMenuItem.Checked; } }

		public FormMain()
		{
			InitializeComponent();
			SetHeader();
		}

		private void FormMain_Load( object sender, EventArgs e )
		{
			SetHeader();
		}


		void SetHeader()
		{
			this.Text = Program.AssemblyTitle + " " + Program.AssemblyVersion;
			if( IsFilename )
			{
				filename = Path.GetFullPath( filename );
				this.Text += " - " + filename;
			}
			ButtonEnable( true );
		}


		private void MenuNew_Click( object sender, EventArgs e )
		{
			try
			{
				string ext = System.IO.Path.GetExtension( Ctrl.ArchiveFilename );
				SaveFileDialog f = new SaveFileDialog();
				f.AddExtension     = true;
				f.CheckPathExists  = true;
				f.CreatePrompt     = false;
				f.DefaultExt       = ext;
				f.FileName         = Ctrl.ArchiveFilename;
				f.Filter           = "control files (*" + ext + ")|*" + ext;
				f.FilterIndex      = 1;
				f.InitialDirectory = System.Environment.GetFolderPath( System.Environment.SpecialFolder.MyDocuments );
				f.OverwritePrompt = true;
				f.RestoreDirectory = true;
				f.Title = "Where should the new control file be saved?";
				if( f.ShowDialog() == DialogResult.OK )
				{
					Ctrl ctrl = new Ctrl();
					ctrl.Filename = Filename = f.FileName;
					ctrl.Export();
				}
			}
			catch( Exception ex )
			{
				Info( ex );
			}
		}

		private void MenuOpen_Click( object sender, EventArgs e )
		{
			try
			{
				string ext = System.IO.Path.GetExtension( Ctrl.ArchiveFilename );
				OpenFileDialog f = new OpenFileDialog();
				f.CheckFileExists  = true;
				f.DefaultExt       = ext;
				f.InitialDirectory = System.Environment.GetFolderPath( System.Environment.SpecialFolder.MyDocuments );
				f.Filter           = "control files (*" + ext + ")|*" + ext;
				f.FilterIndex      = 1;
				f.RestoreDirectory = true;
				f.Title = "Select a backup control file to work with.";
				if( f.ShowDialog() == DialogResult.OK )
				{
					Filename = f.FileName;
				}
			}
			catch( Exception ex )
			{
				Info( ex );
			}
		}

		private void MenuClose_Click( object sender, EventArgs e )
		{
			try
			{
				Filename = "";
			}
			catch( Exception ex )
			{
				Info( ex );
			}
		}

		private void MenuExit_Click( object sender, EventArgs e )
		{
			try
			{
				this.Close();
			}
			catch( Exception )
			{
			}
		}

		private void MenuEdit_Click( object sender, EventArgs e )
		{
			try
			{
				if( IsFilename )
				{
					FormEdit f = new FormEdit( Ctrl.Import( filename ) );
					f.ShowDialog();
					Filename = f.Filename;
				}
			}
			catch( Exception ex )
			{
				Info( ex );
			}
		}

		private void MenuExplore_Click( object sender, EventArgs e )
		{
			try
			{
				if( IsFilename )
				{
					Ctrl c = Ctrl.Import( filename );
					if( (c != null) && (c.Archive != null) )
					{
						FormExplore f = new FormExplore( c );
						f.ShowDialog();
					}
				}
			}
			catch( Exception ex )
			{
				Info( ex );
			}
		}

		private void MenuLogs_Click( object sender, EventArgs e )
		{
			try
			{
				if( IsFilename )
				{
					Ctrl c = Ctrl.Import( filename );
					if( (c != null) && (c.Archive != null) )
					{
						FormLog f = new FormLog( c );
						f.ShowDialog();
					}
				}
			}
			catch( Exception ex )
			{
				Info( ex );
			}
		}


		private void MenuMerge_Click( object sender, EventArgs e )
		{
			try
			{
				if( IsFilename )
				{
#if false
					ClearValues();
					thread = new Thread( new ParameterizedThreadStart( this.Launch ) );
					thread.Start( "Merge" );
#endif
				}
			}
			catch( Exception ex )
			{
				Info( ex );
			}
		}

		private void MenuBackup_Click( object sender, EventArgs e )
		{
			try
			{
				if( newToolStripMenuItem.Enabled )
				{
					if( IsFilename )
					{
#if false
						ClearValues();
						thread = new Thread( new ParameterizedThreadStart( this.Launch ) );
						thread.Start( "Backup" );
#endif
					}
				}
				else
				{
#if false
					Archive a = current;
					if( a != null )
					{
						a.Cancel = true;
					}
#endif
				}
			}
			catch( Exception ex )
			{
				Info( ex );
			}
		}
		private void buttonTest_Click( object sender, EventArgs e )
		{
			Backup bk = backup;
			if( bk == null )
			{
				bk = backup = new Backup( new Backup.MessageDelegate( Msg ) );
			}
			try
			{
				if( bk.IsFinished )
				{
					Ctrl c = GetControl();
					if( c != null )
					{
						labelArchive.Text = c.Path;
						Msg( string.Empty );
						Msg( "==== Backup ====" );
						Msg( "Control File : {0}", c.Filename );
						if( bk.Process( c, IsDebug ) )
						{
							timerRefresh.Start();
						}
					}
				}
				else
				{
					Msg( "..cancelling backup" );
					bk.Cancel();
				}
			}
			catch( Exception ex )
			{
				Msg( "Backup: {0}", Except.ToString( ex, IsDebug ) );
				bk.Terminate();
			}
		}




		private void MenuAbout_Click( object sender, EventArgs e )
		{
			try
			{
				new FormAbout().ShowDialog();
			}
			catch( Exception ex )
			{
				Info( ex );
			}
		}

#if false
		void ClearValues()
		{
			labelUpdateCreated   .Text = "";
			labelUpdateModified  .Text = "";
			labelUpdateDeleted   .Text = "";
			labelUpdateSkipped   .Text = "";
		}

		private void Launch( object parm )
		{
			try
			{
				string s = (string)parm;
				current = null;
				ButtonEnable( false );

				Info( "" );
				Info( "==== Begin ====" );
				Info( "Control File   " + filename );

				created              = 0;
				modified             = 0;
				deleted              = 0;
				skipped              = 0;

				if( IsFilename )
				{
					Ctrl c = Ctrl.Import( filename );
					if( c.IsUpgraded )
					{
						MessageBox.Show(
							"Your control file has been upgraded from a previous version.\r\n\r\n"
							+ "Before running a backup, please verify the settings using the\r\n"
							+ "configuration editor and save the file to the archive folder."
							, "Upgrade Wizard"
							, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1 
							);
					}
					else if( c.Archive != null )
					{
						using( current = new Archive( new Archive.ActionDelegate( this.ArchiveAction ), c, IsDebug ) )
						{
							if( current != null )
							{
								switch( s )
								{
									case "Backup":  current.Merge(); current.Backup( filename );  break;
									case "Merge" :  current.Merge();                              break;
								}
							}
						}
					}
				}
				current = null;
				Info( "===== End =====" );
				Info( "" );
			}
			catch( Exception ex )
			{
				Info( ex );
			}
			finally
			{
				ButtonEnable( true );
			}
		}
#endif

		delegate void ButtonEnableCallback( bool enable );
		private void ButtonEnable( bool enable )
		{
			if( this.InvokeRequired )
			{
				this.Invoke( new ButtonEnableCallback( ButtonEnable ), enable );
				return;
			}
			bool fn = IsFilename;

			//File
			newToolStripMenuItem    .Enabled = enable;
			openToolStripMenuItem   .Enabled = enable;
			closeToolStripMenuItem  .Enabled = enable && fn;

			//Tools
			editToolStripMenuItem   .Enabled = enable && fn;
			exploreToolStripMenuItem.Enabled = enable && fn;
			logsToolStripMenuItem   .Enabled = enable && fn;
			mergeToolStripMenuItem  .Enabled = enable && fn;
			backupToolStripMenuItem .Enabled = enable && fn;
			debugToolStripMenuItem  .Enabled = enable;

			buttonBackup  .Text    = enable ? "Backup" : "Cancel";
			buttonBackup  .Enabled = fn;
		}

		void Info( Exception ex )
		{
			if( IsDebug )
			{
				Info( ex.ToString() );
			}
			else
			{
				StringBuilder sb = new StringBuilder( ex.Message );
				while( (ex = ex.InnerException) != null )
				{
					sb.AppendFormat( "\r\n{0}", ex.Message );
				}
				Info( sb.ToString() );
			}
		}
		delegate void InfoCallback( string message );
		void Info( string message )
		{
			if( this.InvokeRequired )
			{
				this.Invoke( new InfoCallback( Info ), message );
				return;
			}
			richTextBoxInfo.AppendText( message + "\r\n" );
			richTextBoxInfo.ScrollToCaret();
		}

#if false
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
					Info( message );
					break;
				}
				case Archive.Action.Directory:
				{
					labelScanCurrent.Text = message;
					break;
				}
				case Archive.Action.File:
				{
					labelUpdateCurrent.Text = message;
					break;
				}
				case Archive.Action.Change:
				{
					Archive.Reason reason = (Archive.Reason)Enum.Parse( typeof(Archive.Reason), message );
					if( (reason & Archive.Reason.Created   ) == Archive.Reason.Created   ) { ++created  ;  labelUpdateCreated  .Text = created  .ToString(); }
					if( (reason & Archive.Reason.Modified  ) == Archive.Reason.Modified  ) { ++modified ;  labelUpdateModified .Text = modified .ToString(); }
					if( (reason & Archive.Reason.Deleted   ) == Archive.Reason.Deleted   ) { ++deleted  ;  labelUpdateDeleted  .Text = deleted  .ToString(); }
					break;
				}
				case Archive.Action.Skip:
				{
					++skipped;
					labelUpdateSkipped.Text = skipped.ToString();
					break;
				}
			}
		}
#endif

		//-----------------------------------------------------------------------


		private void timerRefresh_Tick( object sender, EventArgs e )
		{
			Backup              bk = backup;

			if( bk != null )
			{
				try
				{
					Backup.BackupStatus st = bk.Status;

					toolStripElapsed   .Text = Ctrl.FormatTimeSpan( bk.Elapsed );

					labelScanCurrent   .Text = st.scan  .current ?? string.Empty;
					labelScanFolders   .Text = st.ToString( st.scan.folders );
					labelScanFiles     .Text = st.ToString( st.scan.files   );

					labelUpdateCurrent .Text = st.update.current ?? string.Empty;
					labelUpdatePending .Text = st.ToString( bk.Pending );
					labelUpdateCreated .Text = st.ToString( st.update.created  );
					labelUpdateModified.Text = st.ToString( st.update.modified );
					labelUpdateDeleted .Text = st.ToString( st.update.deleted  );
					labelUpdateSkipped .Text = st.ToString( st.update.skipped  );

					if( bk.IsFinished )
					{
						timerRefresh.Stop();
						toolStripStatus.Text = "Ready.";
						backup.Finished();
					}
					else
					{
						toolStripStatus.Text = "Working " + ". . . . . . ".Substring( 0, 2 * (DateTime.Now.Second % 6) );
					}
				}
				catch( Exception ex )
				{
					Msg( "Timer: {0}", Except.ToString( ex, IsDebug ) );
					bk.Terminate();
					if( bk.IsFinished )
					{
						timerRefresh.Stop();
					}
				}
			}
		}

		Ctrl GetControl()
		{
			try
			{
				if( IsFilename )
				{
					Ctrl c = Ctrl.Import( filename );
					if( c.IsUpgraded )
					{
						MessageBox.Show(
							"Your control file has been upgraded from a previous version.\r\n\r\n"
							+ "Before running a backup, please verify the settings using the\r\n"
							+ "configuration editor and save the file to the archive folder."
							, "Upgrade Wizard"
							, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1 
							);
					}
					else if( c.Archive != null )
					{
						return c;
					}
				}
			}
			catch( Exception ex )
			{
				Msg( Except.ToString( ex, IsDebug ) );
			}
			return null;
		}

		void Msg( string fmt, params object[] args )
		{
			Msg( string.Format( fmt, args ) );
		}
		delegate void MsgCallback( string message );
		void Msg( string message )
		{
			if( this.InvokeRequired )
			{
				this.Invoke( new MsgCallback( Msg ), message );
				return;
			}
			richTextBoxInfo.AppendText( (richTextBoxInfo.TextLength > 0) ? ("\r\n" + message) : message );
			richTextBoxInfo.ScrollToCaret();
		}


	}
}
