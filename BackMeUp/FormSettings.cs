using System;
using System.Windows.Forms;

namespace BackMeUp
{
	public partial class FormSettings : Form
	{
		public FormSettings()
		{
			InitializeComponent();
			Properties.Settings set  = Properties.Settings.Default;
			textBoxRsyncExePath.Text = set.rsync ?? string.Empty;
		}

		private void buttonRsyncExePath_Click( object sender, EventArgs e )
		{
			try
			{
				OpenFileDialog fd = new OpenFileDialog();
				fd.CheckFileExists = true;
				fd.CheckPathExists = true;
				fd.DefaultExt = "exe";
				fd.Filter = "Executable files (*.exe)|*.exe|All files (*.*)|*.*";
				fd.FilterIndex = 1;
				fd.Multiselect = false;
				fd.RestoreDirectory = true;
				fd.Title = "Select location of rsync.exe";

				string path = textBoxRsyncExePath.Text.Trim();
				if( string.IsNullOrEmpty( path ) )
				{
					fd.FileName         = string.Empty;
					fd.InitialDirectory = System.Environment.SpecialFolder.MyComputer.ToString();
				}
				else
				{
					path                = System.IO.Path.GetFullPath( path );
					fd.FileName         = System.IO.Path.GetFileName( path );
					fd.InitialDirectory = System.IO.Path.GetDirectoryName( path );
				}

				if( fd.ShowDialog() == System.Windows.Forms.DialogResult.OK )
				{
					textBoxRsyncExePath.Text = fd.FileName;
				}
			}
			catch( Exception ex )
			{
				MessageBox.Show( ex.ToString(), "Exception Occured" );
			}
		}

		private void buttonOk_Click( object sender, EventArgs e )
		{
			try
			{
				Properties.Settings set = Properties.Settings.Default;
				bool commit = false;
				if( set.rsync != textBoxRsyncExePath.Text.Trim() )
				{
					set.rsync = textBoxRsyncExePath.Text.Trim();
					commit = true;
				}
				if( set.cygdrive != textBoxCygdrivePath.Text.Trim() )
				{
					set.cygdrive = textBoxCygdrivePath.Text.Trim();
					commit = true;
				}
				if( commit )
				{
					set.Save();
				}
			}
			catch( Exception ex )
			{
				MessageBox.Show( ex.ToString(), "Exception Occured" );
			}
			finally
			{
				this.Close();
			}
		}
	}
}
