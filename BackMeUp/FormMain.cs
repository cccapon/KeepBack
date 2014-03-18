using System;
using System.Windows.Forms;

namespace BackMeUp
{
	public partial class FormMain : Form
	{
		Archive  archive  = null;
		Backup   backup   = null;
		bool     cancel   = false;
		int      folder   = 0;

		public FormMain()
		{
			InitializeComponent();

			Properties.Settings set = Properties.Settings.Default;
			if( ! string.IsNullOrEmpty( set.last ) )
			{
				OpenArchive( set.last );
			}
		}

		private void newToolStripMenuItem_Click( object sender, EventArgs e )
		{

		}

		private void openToolStripMenuItem_Click( object sender, EventArgs e )
		{
			try
			{
				Properties.Settings set = Properties.Settings.Default;
				OpenFileDialog      fd  = new OpenFileDialog();
				fd.CheckFileExists = true;
				fd.CheckPathExists = true;
				fd.DefaultExt      = Archive.DEFAULT_EXT;
				fd.Filter = string.Format( "BackMeUp files (*.{0})|*.{0}|All files (*.*)|*.*", Archive.DEFAULT_EXT );
				fd.FilterIndex = 0;
				fd.InitialDirectory = string.IsNullOrEmpty( set.last ) ? System.Environment.SpecialFolder.Desktop.ToString() : System.IO.Path.GetDirectoryName( System.IO.Path.GetFullPath( set.last ) );
				fd.Multiselect = false;
				fd.Title = "Select Back Me Up configuration file...";

				if( fd.ShowDialog() == System.Windows.Forms.DialogResult.OK )
				{
					OpenArchive( fd.FileName );
				}
			}
			catch( Exception ex )
			{
				MessageBox.Show( ex.ToString(), "Exception Occured" );
			}
		}

		private void saveAsToolStripMenuItem_Click( object sender, EventArgs e )
		{

		}

		private void exitToolStripMenuItem_Click( object sender, EventArgs e )
		{
			this.Close();
		}

		private void settingsToolStripMenuItem_Click( object sender, EventArgs e )
		{
			FormSettings fs = new FormSettings();
			fs.ShowDialog();
		}

		private void buttonExecute_Click( object sender, EventArgs e )
		{
			try
			{
				if( backup == null )
				{
					if( archive == null )
					{
						return;
					}
					Properties.Settings set = Properties.Settings.Default;
					if( set.last != archive.filename )
					{
						set.last = archive.filename;
						set.Save();
					}
					ControlState( true );
					backup = new Backup( set.rsync, set.cygdrive, new Backup.FolderEncountered( FolderUpdate ), new Backup.ProcessExit( ProcessNext ) );
					cancel = false;
					try
					{
						backup.Initialize( archive );
						folder = -1;
						ProcessNext();
					}
					catch( Exception )
					{
						backup.Complete( true );
						backup = null;
						ControlState( false );
						throw;
					}
				}
				else
				{
					if( backup != null )
					{
						cancel = true;
						backup.Cancel();
						return;
					}
					ControlState( false );
				}
			}
			catch( Exception ex )
			{
				MessageBox.Show( ex.ToString(), "Exception Occured" );
			}
		}

		void OpenArchive( string filename )
		{
			try
			{
				archive = Archive.Parse( filename );
			}
			catch( Exception ex )
			{
				archive = null;
				MessageBox.Show( ex.Message, "Archive - " + filename, MessageBoxButtons.OK, MessageBoxIcon.Error );
			}
			ControlState( false );
		}

		void ControlState( bool active )
		{
			this.Text = "Back Me Up" + ((archive == null) ? string.Empty : (" - " + archive.filename));
			labelArchivePath.Text = (archive == null) ? string.Empty : archive.path;
			buttonEdit        .Enabled  = (archive != null) && ! active;
			buttonBackup      .Enabled  = (archive != null);
			buttonBackup      .Text     = active ? "Cancel" : "Backup";
			labelFolder       .Visible  = active;
			labelFolderName   .Visible  = active;
			labelFolderPath   .Visible  = active;
			labelCurrent      .Visible  = active;
			labelCurrentPath  .Visible  = active;

			labelFolderName   .Text     = string.Empty;
			labelFolderPath   .Text     = string.Empty;
			labelCurrentPath  .Text     = string.Empty;
		}

		delegate void ProcessNextCallback();

		private void ProcessNext()
		{
			if( this.InvokeRequired )
			{
				this.Invoke( new ProcessNextCallback( ProcessNext ) );
				return;
			}
			++folder;
			if( backup != null )
			{
				Archive arch = backup.Archive;
				if( ! cancel && (arch != null) && (arch.folders.Length > folder) )
				{
					try
					{
						labelFolderName.Text = arch.folders[folder].tag;
						labelFolderPath.Text = arch.folders[folder].path ?? string.Empty;
						backup.Launch( folder );
						return;
					}
					catch( Exception ex )
					{
						MessageBox.Show( ex.ToString(), string.Format( "Launch failed for folder {0}.", folder ), MessageBoxButtons.OK, MessageBoxIcon.Stop );
						cancel = true;
					}
				}
				backup.Complete( cancel );
				backup = null;
				ControlState( false );
			}
		}

		delegate void FolderUpdateCallback( string path );

		private void FolderUpdate( string path )
		{
			if( this.InvokeRequired )
			{
				this.Invoke( new FolderUpdateCallback( FolderUpdate ), path );
				return;
			}
			labelCurrentPath.Text = path;
		}



	}
}
