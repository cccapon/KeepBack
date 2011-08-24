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
using System.Windows.Forms;

namespace KeepBack
{
	public partial class FormEdit : Form
	{
		//--- define ----------------------------
		const int IMAGE_SET             = 0;
		const int IMAGE_ARCHIVE         = 1;
		const int IMAGE_FOLDER          = 2;
		const int IMAGE_INCLUDE_FILE    = 3;
		const int IMAGE_INCLUDE_FOLDER  = 4;
		const int IMAGE_EXCLUDE_FILE    = 5;
		const int IMAGE_EXCLUDE_FOLDER  = 6;
		const int IMAGE_HISTORY_FILE    = 7;
		const int IMAGE_HISTORY_FOLDER  = 8;
		//--- field -----------------------------
		Ctrl  ctrl;
		bool  modified           = false;
		bool  ignoreChangeState  = false;
		//--- constructor -----------------------
		public FormEdit( Ctrl ctrl )
		{
			this.ctrl  = ctrl;
			InitializeComponent();
		}


		/* ------------------
		 *    Form
		 * ------------------
		 */

		private void FormEdit_Shown( object sender, EventArgs e )
		{
			Rectangle r = splitContainer.Panel2.ClientRectangle;
			AnchorStyles st = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			panelRoot   .SetBounds( r.X, r.Y, r.Width, r.Height );  panelRoot   .Anchor = st;
			panelArchive.SetBounds( r.X, r.Y, r.Width, r.Height );  panelArchive.Anchor = st;
			panelFolder .SetBounds( r.X, r.Y, r.Width, r.Height );  panelFolder .Anchor = st;
			panelPattern.SetBounds( r.X, r.Y, r.Width, r.Height );  panelPattern.Anchor = st;
			TreeUpdate( null );
		}

		private void FormEdit_FormClosing(object sender, FormClosingEventArgs e)
		{
			if( modified )
			{
				if( MessageBox.Show( "Settings have changed.\r\n\r\nWould you like them saved?", "Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2 ) == DialogResult.Yes )
				{
					Save();
				}
			}
		}

		private void TreeUpdate( object select )
		{
			if( ctrl != null )
			{
				this.Text = ctrl.Path;
				this.treeViewControl.Nodes.Clear();
				TreeNode set = new TreeNode( "Backup Set", IMAGE_SET, IMAGE_SET );
				set.Tag = ctrl;
				this.treeViewControl.Nodes.Add( set );
				if( ctrl.Archives != null )
				{
					ctrl.ArchiveSort();
					foreach( CtrlArchive a in ctrl.Archives )
					{
						TreeNode archive = new TreeNode( a.Name, IMAGE_ARCHIVE, IMAGE_ARCHIVE );
						archive.Tag = a;
						set.Nodes.Add( archive );
						if( a.Folders != null )
						{
							a.FolderSort();
							foreach( CtrlFolder f in a.Folders )
							{
								TreeNode folder = new TreeNode( f.Name, IMAGE_FOLDER, IMAGE_FOLDER );
								folder.Tag = f;
								archive.Nodes.Add( folder );
								f.PatternSort();
								if( f.Include != null )
								{
									foreach( CtrlPattern p in f.Include )
									{
										int i = p.IsFolder ? IMAGE_INCLUDE_FOLDER : IMAGE_INCLUDE_FILE;
										TreeNode include = new TreeNode( p.Pattern, i, i );
										include.Tag = p;
										folder.Nodes.Add( include );
									}
								}
								if( f.Exclude != null )
								{
									foreach( CtrlPattern p in f.Exclude )
									{
										int i = p.IsFolder ? IMAGE_EXCLUDE_FOLDER : IMAGE_EXCLUDE_FILE;
										TreeNode exclude = new TreeNode( p.Pattern, i, i );
										exclude.Tag = p;
										folder.Nodes.Add( exclude );
									}
								}
								if( f.History != null )
								{
									foreach( CtrlPattern p in f.History )
									{
										int i = p.IsFolder ? IMAGE_HISTORY_FOLDER : IMAGE_HISTORY_FILE;
										TreeNode history = new TreeNode( p.Pattern, i, i );
										history.Tag = p;
										folder.Nodes.Add( history );
									}
								}
							}
						}
					}
				}
				this.treeViewControl.ExpandAll();
				TreeSelect( (select == null) ? ctrl : select );
			}
		}
		private void TreeSelect( object select )
		{
			TreeNode n = TreeFind( select );
			if( n != null )
			{
				this.treeViewControl.SelectedNode = n;
			}
		}
		private void TreeSelectParent( object select )
		{
			TreeNode n = TreeFind( select );
			if( (n != null) && (n.Parent != null) )
			{
				this.treeViewControl.SelectedNode = n.Parent;
			}
		}
		private void TreeText( object select, string text )
		{
			TreeNode n = TreeFind( select );
			if( n != null )
			{
				n.Text = text;
			}
		}
		private TreeNode TreeFind( object select )
		{
			foreach( TreeNode n in this.treeViewControl.Nodes )
			{
				TreeNode f = TreeFind( n, select );
				if( f != null )
				{
					return f;
				}
			}
			return null;
		}
		private TreeNode TreeFind( TreeNode node, object select )
		{
			if( node.Tag == select )
			{
				return node;
			}
			foreach( TreeNode n in node.Nodes )
			{
				TreeNode f = TreeFind( n, select );
				if( f != null )
				{
					return f;
				}
			}
			return null;
		}



		private void treeViewControl_AfterSelect( object sender, TreeViewEventArgs e )
		{
			this.panelRoot    .Visible  = false;
			this.panelArchive .Visible  = false;
			this.panelFolder  .Visible  = false;
			this.panelPattern .Visible  = false;

			Accept();

			this.panelRoot    .Tag      = null;
			this.panelArchive .Tag      = null;
			this.panelFolder  .Tag      = null;
			this.panelPattern .Tag      = null;

			TreeNode node = this.treeViewControl.SelectedNode;
			if( (node != null) && (node.Tag != null) )
			{
				Type t = node.Tag.GetType();
				if( t == typeof(Ctrl) )
				{
					this.panelRoot.Visible = true;
					this.listBoxArchives.Items.Clear();
					Ctrl x = (Ctrl)node.Tag;
					this.panelRoot.Tag = x;
					buttonSave.Enabled = modified;
					if( x.Archives != null )
					{
						this.listBoxArchives.Items.AddRange( x.Archives );
					}
				}
				else if( t == typeof(CtrlArchive) )
				{
					this.panelArchive.Visible = true;
					this.listBoxFolders.Items.Clear();
					CtrlArchive a = (CtrlArchive)node.Tag;
					this.panelArchive.Tag = a;
					textBoxArchiveRoot  .Text  = a.Root             ;
					textBoxArchivePath  .Text  = a.Path             ;
					textBoxArchiveName  .Text  = a.Name             ;
					textBoxArchiveMonth .Text  = a.Month .ToString();
					textBoxArchiveDay   .Text  = a.Day   .ToString();
					textBoxArchiveHour  .Text  = a.Hour  .ToString();
					textBoxArchiveMinute.Text  = a.Minute.ToString();
					if( a.Folders != null ) { this.listBoxFolders.Items.AddRange( a.Folders ); }
				}
				else if( t == typeof(CtrlFolder) )
				{
					this.panelFolder.Visible = true;
					this.listBoxInclude.Items.Clear();
					this.listBoxExclude.Items.Clear();
					this.listBoxHistory.Items.Clear();
					CtrlFolder f = (CtrlFolder)node.Tag;
					this.panelFolder.Tag = f;
					textBoxFolderName.Text = f.Name;
					textBoxFolderPath.Text = f.Path;
					if( f.Include != null ) { this.listBoxInclude.Items.AddRange( f.Include ); }
					if( f.Exclude != null ) { this.listBoxExclude.Items.AddRange( f.Exclude ); }
					if( f.History != null ) { this.listBoxHistory.Items.AddRange( f.History ); }
				}
				else if( t == typeof(CtrlPattern) )
				{
					this.panelPattern.Visible = true;
					switch( node.ImageIndex )
					{
						case IMAGE_INCLUDE_FILE:  case IMAGE_INCLUDE_FOLDER:  labelPattern.Text = "Include";  break;
						case IMAGE_EXCLUDE_FILE:  case IMAGE_EXCLUDE_FOLDER:  labelPattern.Text = "Exclude";  break;
						case IMAGE_HISTORY_FILE:  case IMAGE_HISTORY_FOLDER:  labelPattern.Text = "History";  break;
						default:                                              labelPattern.Text = "Pattern";  break;
					}
					CtrlPattern p = (CtrlPattern)node.Tag;
					this.panelPattern.Tag = p;
					checkBoxPatternDebug    .Checked =   p.Debug;
					textBoxPatternPattern   .Text    =   p.Pattern;
					radioButtonCaseSensitive.Checked =   p.CaseSensitive;
					radioButtonCaseIgnore   .Checked = ! p.CaseSensitive;
					PatternSetRadioButtons();
				}
			}
		}
		private void Accept()
		{
			AcceptRoot();
			AcceptArchive();
			AcceptFolder();
			AcceptPattern();
		}
		private void Save()
		{
			try
			{
				if( ctrl != null )
				{
					ctrl.Export( ctrl.Path );
				}
				modified = false;
				buttonSave.Enabled = false;
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


		/* ------------------
		 *    PanelRoot
		 * ------------------
		 */
		private void AcceptRoot()
		{
			Ctrl x = this.panelRoot.Tag as Ctrl;
			if( x != null )
			{
				//nothing to accept on this panel
			}
		}

		private void buttonSave_Click( object sender, EventArgs e )
		{
			Save();
		}

		private void buttonArchiveAdd_Click( object sender, EventArgs e )
		{
			Ctrl x = this.panelRoot.Tag as Ctrl;
			if( x != null )
			{
				int    i = 0;
				int    j;
				string s;
				do
				{
					++i;
					s = @"Archive-" + i;
					j = (x.Archives == null) ? 0 : x.Archives.Length;
					while( (--j >= 0) && (s != x.Archives[j].Name) )
					{
					}
				}
				while( j >= 0 );
				CtrlArchive a = x.ArchiveAdd();
				a.Name   = s ;
				a.Month  =  6;
				a.Day    = 15;
				a.Hour   = 24;
				a.Minute = 60;
				modified = true;
				TreeUpdate( a );
			}
		}

		private void buttonArchiveDelete_Click( object sender, EventArgs e )
		{
			Ctrl        x = this.panelRoot.Tag as Ctrl;
			CtrlArchive a = this.listBoxArchives.SelectedItem as CtrlArchive;
			if( (x != null) && (a != null) )
			{
				if( MessageBox.Show( "Delete Archive:\r\n\r\n" + a.Name + "\r\n" + a.FullPath + "\r\n\r\nAre you Sure?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2 ) == DialogResult.Yes )
				{
					x.ArchiveDelete( a );
					modified = true;
					TreeUpdate( x );
				}
			}
		}

		private void listBoxArchives_DoubleClick( object sender, EventArgs e )
		{
			CtrlArchive a = this.listBoxArchives.SelectedItem as CtrlArchive;
			if( a != null )
			{
				TreeSelect( a );
			}
		}


		/* ------------------
		 *    PanelArchive
		 * ------------------
		 */
		private void AcceptArchive()
		{
			CtrlArchive a = this.panelArchive.Tag as CtrlArchive;
			if( a != null )
			{
				string s;
				int    i;
				s = textBoxArchiveRoot  .Text.Trim(); if( s != a.Root ) { if( ! string.IsNullOrEmpty( s ) ) { a.Root =                    s; modified = true; }                          }
				s = textBoxArchivePath  .Text.Trim(); if( s != a.Path ) {                                     a.Path = (s == null) ? "" : s; modified = true;                            } 
				s = textBoxArchiveName  .Text.Trim(); if( s != a.Name ) { if( ! string.IsNullOrEmpty( s ) ) { a.Name =                    s; modified = true; } TreeText( a, a.Name ); }
				s = textBoxArchiveMonth .Text.Trim(); if( ! string.IsNullOrEmpty( s ) ) { try { i = int.Parse( s ); if( i != a.Month  ) { a.Month  = i; modified = true; } } catch { } }
				s = textBoxArchiveDay   .Text.Trim(); if( ! string.IsNullOrEmpty( s ) ) { try { i = int.Parse( s ); if( i != a.Day    ) { a.Day    = i; modified = true; } } catch { } }
				s = textBoxArchiveHour  .Text.Trim(); if( ! string.IsNullOrEmpty( s ) ) { try { i = int.Parse( s ); if( i != a.Hour   ) { a.Hour   = i; modified = true; } } catch { } }
				s = textBoxArchiveMinute.Text.Trim(); if( ! string.IsNullOrEmpty( s ) ) { try { i = int.Parse( s ); if( i != a.Minute ) { a.Minute = i; modified = true; } } catch { } }
			}
		}

		private void buttonArchivePrevious_Click( object sender, EventArgs e )
		{
			TreeSelectParent( this.panelArchive.Tag );
		}

		private void buttonArchivePath_Click( object sender, EventArgs e )
		{
			FolderBrowserDialog f = new FolderBrowserDialog();
			f.Description = "Select drive and path where archive will be stored.";
			f.ShowNewFolderButton = true;
			try
			{
				f.SelectedPath = Path.Combine( Path.Combine( textBoxArchiveRoot.Text, textBoxArchivePath.Text ), textBoxArchiveName.Text );
			}
			catch
			{
			}
			if( f.ShowDialog() == DialogResult.OK )
			{
				string s = Path.GetFullPath( f.SelectedPath );
				string r = Path.GetPathRoot     ( s );
				string p = Path.GetDirectoryName( s );
				string n = Path.GetFileName     ( s );
				p = (p.StartsWith( r ) ? p.Substring( r.Length ) : p);
				textBoxArchiveRoot.Text = r;
				textBoxArchivePath.Text = p;
				textBoxArchiveName.Text = n;
			}
		}

		private void textBoxArchiveName_TextChanged( object sender, EventArgs e )
		{
			if( ! ignoreChangeState )
			{
				TreeText( this.panelArchive.Tag, textBoxArchiveName.Text );
			}
		}

		private void buttonFolderAdd_Click( object sender, EventArgs e )
		{
			CtrlArchive a = this.panelArchive.Tag as CtrlArchive;
			if( a != null )
			{
				int    i = 0;
				int    j;
				string s;
				do
				{
					++i;
					s = @"Folder-" + i;
					j = (a.Folders == null) ? 0 : a.Folders.Length;
					while( (--j >= 0) && (s != a.Folders[j].Name) )
					{
					}
				}
				while( j >= 0 );
				CtrlFolder f = a.FolderAdd();
				f.Name = s;
				modified = true;
				TreeUpdate( f );
			}
		}

		private void buttonFolderDelete_Click( object sender, EventArgs e )
		{
			CtrlArchive a = this.panelArchive.Tag as CtrlArchive;
			CtrlFolder  f = this.listBoxFolders.SelectedItem as CtrlFolder;
			if( (a != null) && (f != null) )
			{
				if( MessageBox.Show( "Delete Folder:\r\n\r\n" + f.Name + "\r\n" + f.Path + "\r\n\r\nAre you Sure?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2 ) == DialogResult.Yes )
				{
					a.FolderDelete( f );
					modified = true;
					TreeUpdate( a );
				}
			}
		}

		private void listBoxFolders_DoubleClick( object sender, EventArgs e )
		{
			CtrlFolder f = this.listBoxFolders.SelectedItem as CtrlFolder;
			if( f != null )
			{
				TreeSelect( f );
			}
		}


		/* ------------------
		 *    PanelFolder
		 * ------------------
		 */
		private void AcceptFolder()
		{
			CtrlFolder f = this.panelFolder.Tag as CtrlFolder;
			if( f != null )
			{
				string s;
				//Name
				s = textBoxFolderName.Text.Trim();  if( s != f.Name ) { if( ! string.IsNullOrEmpty( s ) ) { f.Name = s; modified = true; } TreeText( f, f.Name ); }
				s = textBoxFolderPath.Text.Trim();  if( s != f.Path ) { if( ! string.IsNullOrEmpty( s ) ) { f.Path = s; modified = true; }                          }
			}
		}

		private void buttonFolderPrevious_Click( object sender, EventArgs e )
		{
			TreeSelectParent( this.panelFolder.Tag );
		}

		private void buttonFolderPath_Click( object sender, EventArgs e )
		{
			FolderBrowserDialog f = new FolderBrowserDialog();
			f.Description = "Select folder to be backed up to archive.";
			f.ShowNewFolderButton = false;
			try
			{
				f.SelectedPath = Path.GetFullPath( textBoxFolderPath.Text.Trim() );
			}
			catch
			{
			}
			if( f.ShowDialog() == DialogResult.OK )
			{
				textBoxFolderPath.Text = Path.GetFullPath( f.SelectedPath );
			}
		}

		private void textBoxFolderName_TextChanged(object sender, EventArgs e)
		{
			if( ! ignoreChangeState )
			{
				TreeText( this.panelFolder.Tag, textBoxFolderName.Text );
			}
		}

		private void buttonIncludeAdd_Click( object sender, EventArgs e )
		{
			CtrlFolder f = this.panelFolder.Tag as CtrlFolder;
			if( f != null )
			{
				CtrlPattern p = f.IncludeAdd();
				p.Pattern = @"*";
				modified = true;
				TreeUpdate( p );
			}
		}
		private void buttonExcludeAdd_Click( object sender, EventArgs e )
		{
			CtrlFolder f = this.panelFolder.Tag as CtrlFolder;
			if( f != null )
			{
				CtrlPattern p = f.ExcludeAdd();
				p.Pattern = @"*";
				modified = true;
				TreeUpdate( p );
			}
		}
		private void buttonHistoryAdd_Click( object sender, EventArgs e )
		{
			CtrlFolder f = this.panelFolder.Tag as CtrlFolder;
			if( f != null )
			{
				CtrlPattern p = f.HistoryAdd();
				p.Pattern = @"*";
				modified = true;
				TreeUpdate( p );
			}
		}

		private void buttonIncludeDelete_Click( object sender, EventArgs e )
		{
			CtrlFolder  f = this.panelFolder.Tag as CtrlFolder;
			CtrlPattern p = this.listBoxInclude.SelectedItem as CtrlPattern;
			if( (f != null) && (p != null) )
			{
				if( MessageBox.Show( "Delete Include Pattern:\r\n\r\n" + p.Pattern + "\r\n\r\nAre you Sure?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2 ) == DialogResult.Yes )
				{
					f.IncludeDelete( p );
					modified = true;
					TreeUpdate( f );
				}
			}
		}
		private void buttonExcludeDelete_Click( object sender, EventArgs e )
		{
			CtrlFolder  f = this.panelFolder.Tag as CtrlFolder;
			CtrlPattern p = this.listBoxExclude.SelectedItem as CtrlPattern;
			if( (f != null) && (p != null) )
			{
				if( MessageBox.Show( "Delete Exclude Pattern:\r\n\r\n" + p.Pattern + "\r\n\r\nAre you Sure?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2 ) == DialogResult.Yes )
				{
					f.ExcludeDelete( p );
					modified = true;
					TreeUpdate( f );
				}
			}
		}
		private void buttonHistoryDelete_Click( object sender, EventArgs e )
		{
			CtrlFolder  f = this.panelFolder.Tag as CtrlFolder;
			CtrlPattern p = this.listBoxHistory.SelectedItem as CtrlPattern;
			if( (f != null) && (p != null) )
			{
				if( MessageBox.Show( "Delete History Pattern:\r\n\r\n" + p.Pattern + "\r\n\r\nAre you Sure?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2 ) == DialogResult.Yes )
				{
					f.HistoryDelete( p );
					modified = true;
					TreeUpdate( f );
				}
			}
		}

		private void listBoxInclude_DoubleClick( object sender, EventArgs e )
		{
			CtrlPattern p = this.listBoxInclude.SelectedItem as CtrlPattern;
			if( p != null )
			{
				TreeSelect( p );
			}
		}
		private void listBoxExclude_DoubleClick( object sender, EventArgs e )
		{
			CtrlPattern p = this.listBoxExclude.SelectedItem as CtrlPattern;
			if( p != null )
			{
				TreeSelect( p );
			}
		}
		private void listBoxHistory_DoubleClick( object sender, EventArgs e )
		{
			CtrlPattern p = this.listBoxHistory.SelectedItem as CtrlPattern;
			if( p != null )
			{
				TreeSelect( p );
			}
		}


		/* ------------------
		 *    PanelPattern
		 * ------------------
		 */
		private void AcceptPattern()
		{
			CtrlPattern p = this.panelPattern.Tag as CtrlPattern;
			if( p != null )
			{
				string s;
				s = textBoxPatternPattern.Text.Trim();
				if( s != p.Pattern )
				{
					if( ! string.IsNullOrEmpty( s ) )
					{
						p.Pattern = s;
						modified = true;
					}
					TreeText( p, p.Pattern );
				}
				if( p.Debug != checkBoxPatternDebug.Checked )
				{
					p.Debug = checkBoxPatternDebug.Checked;
					modified = true;
				}
				if( p.CaseSensitive != radioButtonCaseSensitive.Checked )
				{
					p.CaseSensitive = radioButtonCaseSensitive.Checked;
					modified = true;
				}
			}
		}

		private void buttonPatternPrevious_Click( object sender, EventArgs e )
		{
			TreeSelectParent( this.panelPattern.Tag );
		}

		private void textBoxPatternPattern_TextChanged( object sender, EventArgs e )
		{
			if( ! ignoreChangeState )
			{
				TreeText( this.panelPattern.Tag, textBoxPatternPattern.Text );
				PatternSetRadioButtons();
			}
		}

		private void radioButtonApplyAbsolute_CheckedChanged( object sender, EventArgs e )
		{
			if( ! ignoreChangeState )
			{
				string s = textBoxPatternPattern.Text.Trim();
				if( ! MatchPath.StartsWithDirectorySeparator( s ) )
				{
					textBoxPatternPattern.Text = Path.DirectorySeparatorChar.ToString() + s;
				}
				PatternSetRadioButtons();
			}
		}

		private void radioButtonApplyRelative_CheckedChanged( object sender, EventArgs e )
		{
			if( ! ignoreChangeState )
			{
				string s = textBoxPatternPattern.Text.Trim();
				if( MatchPath.StartsWithDirectorySeparator( s ) )
				{
					textBoxPatternPattern.Text = s.Substring( 1 );
				}
				PatternSetRadioButtons();
			}
		}

		private void radioButtonMatchFolder_CheckedChanged( object sender, EventArgs e )
		{
			if( ! ignoreChangeState )
			{
				string s = textBoxPatternPattern.Text.Trim();
				if( ! MatchPath.EndsWithDirectorySeparator( s ) )
				{
					textBoxPatternPattern.Text = s + Path.DirectorySeparatorChar.ToString();
				}
				PatternSetRadioButtons();
			}
		}

		private void radioButtonMatchFile_CheckedChanged( object sender, EventArgs e )
		{
			if( ! ignoreChangeState )
			{
				string s = textBoxPatternPattern.Text.Trim();
				if( MatchPath.EndsWithDirectorySeparator( s ) )
				{
					textBoxPatternPattern.Text = s.Substring( 0, s.Length - 1 );
				}
				PatternSetRadioButtons();
			}
		}

		private void PatternSetRadioButtons()
		{
			try
			{
				ignoreChangeState = true;
				string s = textBoxPatternPattern.Text.Trim();
				bool   b;
				
				b = MatchPath.StartsWithDirectorySeparator( s );

				radioButtonApplyAbsolute.Checked  =   b;
				radioButtonApplyRelative.Checked  = ! b;

				b = MatchPath.EndsWithDirectorySeparator( s );

				radioButtonMatchFolder  .Checked  =   b;
				radioButtonMatchFile    .Checked  = ! b;
			}
			finally
			{
				ignoreChangeState = false;
			}
		}

		//--- end -------------------------------
	}
}