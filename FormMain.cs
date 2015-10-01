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
		int             timer_kick       = 0;


		public string Filename   { get { return filename; } set { filename = value; SetHeader(); } }
		public bool   IsFilename { get { return ! string.IsNullOrEmpty( filename ); } }
		public bool   IsDebug    { get { return debugToolStripMenuItem.Checked; } }


		public FormMain()
		{
			InitializeComponent();
			try
			{
				SetHeader();
			}
			catch( Exception ex )
			{
				Msg( ex );
			}

		}

		private void FormMain_Load( object sender, EventArgs e )
		{
			try
			{
				SetHeader();
			}
			catch( Exception ex )
			{
				Msg( ex );
			}
		}

		void SetHeader()
		{
			this.Text = Program.AssemblyTitle + " " + Program.AssemblyVersion;
			if( IsFilename )
			{
				filename = Path.GetFullPath( filename );
				this.Text += " - " + filename;
			}
			ControlActivation();
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
				Msg( ex );
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
				Msg( ex );
			}
		}

		private void MenuClose_Click( object sender, EventArgs e )
		{
			try
			{
				Filename = string.Empty;
			}
			catch( Exception ex )
			{
				Msg( ex );
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
				Msg( ex );
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
				Msg( ex );
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
				Msg( ex );
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
				Msg( ex );
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
				Msg( ex );
			}
		}

		private void MenuBackup_Click( object sender, EventArgs e )
		{
			try
			{
				Backup bk = backup;
				if( bk == null )
				{
					bk = backup = new Backup( new Backup.MessageDelegate( Msg ) );
				}
				if( ! bk.IsRunning )
				{
					Ctrl c = GetControl();
					if( c != null )
					{
						labelArchive.Text = c.Path;
						richTextBoxInfo.Clear();
						labelTagScan.Text = "Scan";
						labelTagUpdate.Visible = true;
						Msg( string.Empty );
						Msg( "==== Backup ====" );
						Msg( "Control File : {0}", c.Filename );
						bk.Process( Backup.Operation.Backup, c, IsDebug );
						ControlActivation();
						timer_kick = -1;
						timerRefresh.Start();
					}
				}
				else
				{
					Msg( "..cancelling" );
					bk.Cancel();
					buttonMerge .ForeColor = buttonBackup.ForeColor;
					buttonBackup.Enabled   = false;
					buttonMerge .Enabled   = false;
				}
			}
			catch( Exception ex )
			{
				Msg( ex );
			}
		}

		private void buttonMerge_Click( object sender, EventArgs e )
		{
			try
			{
				Backup bk = backup;
				if( bk == null )
				{
					bk = backup = new Backup( new Backup.MessageDelegate( Msg ) );
				}
				if( ! bk.IsRunning )
				{
					Ctrl c = GetControl();
					if( c != null )
					{
						labelArchive.Text = c.Path;
						richTextBoxInfo.Clear();
						labelTagScan.Text = "Merge";
						labelTagUpdate.Visible = false;
						Msg( string.Empty );
						Msg( "==== Merge ====" );
						Msg( "Control File : {0}", c.Filename );
						bk.Process( Backup.Operation.Merge, c, IsDebug );
						ControlActivation();
						timer_kick = -1;
						timerRefresh.Start();
					}
				}
				else
				{
					bk.Pause();
					buttonMerge.Text      = bk.IsPaused ? "Resume" : "Pause";
					buttonMerge.ForeColor = buttonBackup.ForeColor;
				}
			}
			catch( Exception ex )
			{
				Msg( ex );
			}
		}

		private void timerRefresh_Tick( object sender, EventArgs e )
		{
			Backup bk = backup;

			if( bk != null )
			{
				try
				{
					Backup.BackupStatus st   = bk.Status;

					toolStripElapsed   .Text = Ctrl.FormatTimeSpan( bk.Elapsed );

					labelScanCurrent   .Text = bk.IsScanAlive ? (st.scan.current ?? string.Empty) : (bk.IsMergeAlive ? (st.merge.current ?? string.Empty) : string.Empty);
					labelScanFolders   .Text = st.ToString( st.scan.folders );
					labelScanFiles     .Text = st.ToString( st.scan.files   );

					labelUpdateCurrent .Text = st.update.current ?? string.Empty;
					labelUpdatePending .Text = st.ToString( bk.Pending         );
					labelUpdateCreated .Text = st.ToString( st.update.created  );
					labelUpdateModified.Text = st.ToString( st.update.modified );
					labelUpdateDeleted .Text = st.ToString( st.update.deleted  );
					labelUpdateSkipped .Text = st.ToString( st.update.skipped  );

					pictureBoxScan  .Image   = (bk.IsScanWorking || bk.IsMergeWorking) ? Properties.Resources.Working : Properties.Resources.Sleep;
					pictureBoxUpdate.Image   = bk.IsUpdateWorking ? Properties.Resources.Working : Properties.Resources.Sleep;
					pictureBoxScan  .Refresh();
					pictureBoxUpdate.Refresh();
					pictureBoxScan  .Visible = (bk.IsScanAlive || bk.IsMergeAlive);
					pictureBoxUpdate.Visible = bk.IsUpdateAlive;

					if( bk.IsPaused )
					{
						buttonMerge.ForeColor = ((timer_kick % 2) == 0) ? buttonMerge.BackColor : buttonBackup.ForeColor;
					}

					toolStripStatusLabelScanState  .Text = bk.IsScanAlive ? bk.ScanState.ToString() : (bk.IsMergeAlive ? bk.MergeState.ToString() : string.Empty);
					toolStripStatusLabelUpdateState.Text = bk.IsUpdateAlive ? bk.UpdateState.ToString() : string.Empty;
					toolStripStatusLabelLogs       .Text = st.ToString( bk.LogCount );

					++timer_kick;
					if( ! bk.IsRunning )
					{
						timerRefresh.Stop();
						toolStripStatus.Text = "Ready.";
						Msg( "===== End =====" );
						Msg( "" );
						ControlActivation();
					}
					else
					{
						toolStripStatus.Text = "Working " + ". . . . . . ".Substring( 0, 2 * (timer_kick % 6) );
					}
				}
				catch( Exception ex )
				{
					Msg( "Timer: {0}", Except.ToString( ex, IsDebug ) );
				}
			}
		}

		delegate void ControlActivationCallback();
		private void ControlActivation()
		{
			if( this.InvokeRequired )
			{
				this.Invoke( new ControlActivationCallback( ControlActivation ) );
				return;
			}
			Backup bk   = backup;
			bool   idle = (bk == null) ? true : ! bk.IsRunning;
			bool   fn   = IsFilename;

			//File
			newToolStripMenuItem    .Enabled = idle;
			openToolStripMenuItem   .Enabled = idle;
			closeToolStripMenuItem  .Enabled = idle && fn;

			//Tools
			editToolStripMenuItem   .Enabled = idle && fn;
			exploreToolStripMenuItem.Enabled = idle && fn;
			logsToolStripMenuItem   .Enabled = idle && fn;
			mergeToolStripMenuItem  .Enabled = idle && fn;
			backupToolStripMenuItem .Enabled = idle && fn;
			debugToolStripMenuItem  .Enabled = idle;

			//Buttons
			buttonBackup  .Text      = idle ? "Begin Backup"  : "Cancel";
			buttonBackup  .Enabled   = fn;
			buttonMerge   .Text      = idle ? "Merge History" : "Pause";
			buttonMerge   .Enabled   = fn;
			buttonMerge   .ForeColor = buttonBackup.ForeColor;

			//Display
			Color c = idle ? System.Drawing.SystemColors.Control : System.Drawing.SystemColors.Info;
			labelArchive      .BackColor = c;
			labelScanCurrent  .BackColor = c;
			labelUpdateCurrent.BackColor = c;

			Font f = labelTagArchive.Font;
			f = new System.Drawing.Font( f, idle ? FontStyle.Regular : FontStyle.Italic );
			labelTagArchive.Font = f;
			labelTagScan   .Font = f;
			labelTagUpdate .Font = f;

			pictureBoxScan  .Visible = false;
			pictureBoxUpdate.Visible = false;

			this.Refresh();
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
				Msg( ex );
			}
			return null;
		}


		void Msg( Exception ex )
		{
			Msg( Except.ToString( ex, IsDebug ) );
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
