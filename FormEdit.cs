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
		const int IMAGE_ARCHIVE         = 0;
		const int IMAGE_FOLDER          = 1;
		const int IMAGE_INCLUDE_FILE    = 2;
		const int IMAGE_INCLUDE_FOLDER  = 3;
		const int IMAGE_EXCLUDE_FILE    = 4;
		const int IMAGE_EXCLUDE_FOLDER  = 5;
		const int IMAGE_HISTORY_FILE    = 6;
		const int IMAGE_HISTORY_FOLDER  = 7;

		class FolderPattern
		{
			public CtrlFolder   folder;
			public CtrlFilter   filter;
			public FolderPattern( CtrlFolder folder, CtrlFilter filter )
			{
				this.folder  = folder;
				this.filter  = filter;
			}
		}
		//--- field -----------------------------
		Ctrl  ctrl;
		bool  modified           = false;
		bool  ignoreChangeState  = false;
		//--- property --------------------------
		public string Filename { get { return (ctrl == null) ? string.Empty : ctrl.Filename; } }
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
			panelArchive.SetBounds( r.X, r.Y, r.Width, r.Height );  panelArchive.Anchor = st;
			panelFolder .SetBounds( r.X, r.Y, r.Width, r.Height );  panelFolder .Anchor = st;
			panelPattern.SetBounds( r.X, r.Y, r.Width, r.Height );  panelPattern.Anchor = st;

			if( ctrl.IsUpgraded )
			{
				MessageBox.Show( ctrl.Filename + "\r\n\r\nThis KeepBack file has been upgraded from an earlier version.\r\nPlease verify the settings before saving the file.", "Upgrade Wizard", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1 );
				modified = true;
			}

			TreeUpdate( null );
		}

		private void FormEdit_FormClosing( object sender, FormClosingEventArgs e )
		{
			Accept();
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
			treeViewControl.Nodes.Clear();
			if( ctrl != null )
			{
				this.Text = ctrl.Name;

				CtrlArchive a;
				if( ctrl.Archive == null )
				{
					a = ctrl.ArchiveCreate();
					a.Month  =  6;
					a.Day    = 15;
					a.Hour   = 24;
					a.Minute = 60;
					a.Logs   = 90;
					modified = true;
				}
				a = ctrl.Archive;
				TreeNode archive = new TreeNode( ctrl.Name, IMAGE_ARCHIVE, IMAGE_ARCHIVE );
				archive.Tag = a;
				this.treeViewControl.Nodes.Add( archive );
				if( a.Folders != null )
				{
					foreach( CtrlFolder fo in a.Folders )
					{
						TreeNode folder = new TreeNode( fo.Name, IMAGE_FOLDER, IMAGE_FOLDER );
						folder.Tag = fo;
						archive.Nodes.Add( folder );
						if( fo.Filters != null )
						{
							foreach( CtrlFilter fi in fo.Filters )
							{
								int i = FilterImage( fi );
								TreeNode n = new TreeNode( fi.Pattern, i, i );
								n.Tag = fi;
								folder.Nodes.Add( n );
							}
						}
					}
				}
				this.treeViewControl.ExpandAll();
				TreeSelect( (select == null) ? ctrl.Archive : select );
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
		private void TreeImage( object select, int i )
		{
			TreeNode n = TreeFind( select );
			if( n != null )
			{
				n.ImageIndex         = i;
				n.SelectedImageIndex = i;
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
			this.panelArchive .Visible  = false;
			this.panelFolder  .Visible  = false;
			this.panelPattern .Visible  = false;

			TreeNode node = this.treeViewControl.SelectedNode;

			object o = Accept();
			if( o != null )
			{
				o = ((node != null) && (node.Tag != null)) ? node.Tag : o;
				TreeUpdate( o );
				return;
			}

			this.panelArchive .Tag      = null;
			this.panelFolder  .Tag      = null;
			this.panelPattern .Tag      = null;

			if( (node != null) && (node.Tag != null) )
			{
				Type t = node.Tag.GetType();
				if( t == typeof(CtrlArchive) )
				{
					this.panelArchive.Visible = true;
					this.listBoxFolders.Items.Clear();
					CtrlArchive a = (CtrlArchive)node.Tag;
					this.panelArchive.Tag = a;
					buttonSave.Enabled = modified;
					textBoxArchiveFullPath.Text  = ctrl.Path;
					textBoxArchiveMonth   .Text  = a.Month .ToString();
					textBoxArchiveDay     .Text  = a.Day   .ToString();
					textBoxArchiveHour    .Text  = a.Hour  .ToString();
					textBoxArchiveMinute  .Text  = a.Minute.ToString();
					textBoxLogsDays       .Text  = a.Logs  .ToString();
					if( a.Folders != null ) { this.listBoxFolders.Items.AddRange( a.Folders ); }
				}
				else if( t == typeof(CtrlFolder) )
				{
					this.panelFolder.Visible = true;
					this.listBoxFilter.Items.Clear();
					CtrlFolder f = (CtrlFolder)node.Tag;
					this.panelFolder.Tag = f;
					textBoxFolderName.Text = f.Name;
					textBoxFolderPath.Text = f.Path;
					if( f.Filters != null ) { this.listBoxFilter.Items.AddRange( f.Filters ); }
				}
				else if( t == typeof(CtrlFilter) )
				{
					this.panelPattern.Visible = true;
					CtrlFilter  p = (CtrlFilter)node.Tag;
					CtrlFolder  f = (CtrlFolder)node.Parent.Tag;
					this.panelPattern.Tag = new FolderPattern( f, p );
					radioButtonActionInclude.Checked = (p.Action == CtrlFilter.ActionType.Include);
					radioButtonActionExclude.Checked = (p.Action == CtrlFilter.ActionType.Exclude);
					radioButtonActionHistory.Checked = (p.Action == CtrlFilter.ActionType.History);
					textBoxPatternPattern.Text    =   p.Pattern;
					PatternSetRadioButtons();
				}
			}
		}
		private object Accept()
		{
			/* Accept() returns an object when one of the panels
			 * has changed the tree structure (because it deleted
			 * something).  The object returned is the parent of
			 * the deleted item.  The deleted TreeNode must have
			 * its .Tag set to null as well.
			 */
			object o = null;
			object x;
			x = AcceptArchive();  o = o ?? x;
			x = AcceptFolder ();  o = o ?? x;
			x = AcceptPattern();  o = o ?? x;
			return o;
		}
		private bool Save()
		{
			try
			{
				if( ctrl != null )
				{
					if( ctrl.IsUpgraded )
					{
						SaveFileDialog f = new SaveFileDialog();
						f.AddExtension = true;
						f.CheckPathExists = true;
						f.DefaultExt = Path.GetExtension( Ctrl.ArchiveFilename );
						f.FileName = Path.GetFileName( ctrl.Filename );
						f.Filter = "KeepBack files (" + Ctrl.ArchiveFilename + ")|" + Ctrl.ArchiveFilename;
						f.FilterIndex = 0;
						f.InitialDirectory = Path.GetDirectoryName( ctrl.Filename );
						f.OverwritePrompt = true;
						f.RestoreDirectory = true;
						f.Title = "Save upgraded KeepBack file.";
						if( f.ShowDialog() != System.Windows.Forms.DialogResult.OK )
						{
							return false;
						}
						ctrl.Filename = f.FileName;
					}
					ctrl.Export();
				}
				modified = false;
				buttonSave.Enabled = false;
				return true;
			}
			catch( Exception ex )
			{
#if DEBUG
				MessageBox.Show( ex.ToString() );
#else
				MessageBox.Show( ex.Message );
#endif
				return false;
			}
		}


		/* ------------------
		 *    PanelArchive
		 * ------------------
		 */
		private object AcceptArchive()
		{
			CtrlArchive a = this.panelArchive.Tag as CtrlArchive;
			if( a != null )
			{
				string s;
				int    i;
//				s = textBoxArchivePath  .Text.Trim(); if( s != a.Path ) { if( ! string.IsNullOrEmpty( s ) ) { a.Path = s; modified = true; } TreeText( a, a.Name ); }
				s = textBoxArchiveMonth .Text.Trim(); if( ! string.IsNullOrEmpty( s ) ) { try { i = int.Parse( s ); if( i != a.Month  ) { a.Month  = i; modified = true; } } catch { } }
				s = textBoxArchiveDay   .Text.Trim(); if( ! string.IsNullOrEmpty( s ) ) { try { i = int.Parse( s ); if( i != a.Day    ) { a.Day    = i; modified = true; } } catch { } }
				s = textBoxArchiveHour  .Text.Trim(); if( ! string.IsNullOrEmpty( s ) ) { try { i = int.Parse( s ); if( i != a.Hour   ) { a.Hour   = i; modified = true; } } catch { } }
				s = textBoxArchiveMinute.Text.Trim(); if( ! string.IsNullOrEmpty( s ) ) { try { i = int.Parse( s ); if( i != a.Minute ) { a.Minute = i; modified = true; } } catch { } }
				s = textBoxLogsDays     .Text.Trim(); if( ! string.IsNullOrEmpty( s ) ) { try { i = int.Parse( s ); if( i != a.Logs   ) { a.Logs   = i; modified = true; } } catch { } }
			}
			return null;
		}

		private void buttonSave_Click( object sender, EventArgs e )
		{
			Accept();
			Save();
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
				a.FolderDelete( f );
				modified = true;
				TreeUpdate( a );
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
		private object AcceptFolder()
		{
			CtrlFolder f = this.panelFolder.Tag as CtrlFolder;
			if( f != null )
			{
				string s;
				//Name
				s = textBoxFolderName.Text.Trim();  if( s != f.Name ) { if( ! string.IsNullOrEmpty( s ) ) { f.Name = s; modified = true; } TreeText( f, f.Name ); }
				s = textBoxFolderPath.Text.Trim();  if( s != f.Path ) { if( ! string.IsNullOrEmpty( s ) ) { f.Path = s; modified = true; }                          }
			}
			return null;
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

		private void buttonFilterAdd_Click( object sender, EventArgs e )
		{
			CtrlFolder f = this.panelFolder.Tag as CtrlFolder;
			if( f != null )
			{
				CtrlFilter p = f.FilterAdd();
				p.Action  = CtrlFilter.ActionType.Exclude;
				p.Pattern = string.Empty;
				modified = true;
				TreeUpdate( p );
			}
		}

		private void buttonFilterDelete_Click( object sender, EventArgs e )
		{
			CtrlFolder f = this.panelFolder.Tag as CtrlFolder;
			CtrlFilter p = this.listBoxFilter.SelectedItem as CtrlFilter;
			if( (f != null) && (p != null) )
			{
				f.FilterDelete( p );
				modified = true;
				TreeUpdate( f );
			}
		}

		private void listBoxFilter_DoubleClick( object sender, EventArgs e )
		{
			CtrlFilter p = this.listBoxFilter.SelectedItem as CtrlFilter;
			if( p != null )
			{
				TreeSelect( p );
			}
		}


		/* ------------------
		 *    PanelPattern
		 * ------------------
		 */
		private object AcceptPattern()
		{
			FolderPattern fp = this.panelPattern.Tag as FolderPattern;
			if( fp != null )
			{
				CtrlFolder f = fp.folder;
				CtrlFilter p = fp.filter;
				CtrlFilter.ActionType t = radioButtonActionInclude.Checked ? CtrlFilter.ActionType.Include : (radioButtonActionHistory.Checked ? CtrlFilter.ActionType.History : CtrlFilter.ActionType.Exclude);
				if( p.Action != t )
				{
					p.Action = t;
					modified = true;
				}
				string s;
				s = textBoxPatternPattern.Text.Trim();
				if( string.IsNullOrEmpty( s ) )
				{
					modified |= f.FilterDelete( p );
					this.panelPattern.Tag = null;
					return f;
				}
				if( s != p.Pattern )
				{
					p.Pattern = s;
					modified = true;
				}
				TreeImage( p, FilterImage( p ) );
				TreeText( p, p.Pattern );
			}
			return null;
		}

		private void buttonPatternPrevious_Click( object sender, EventArgs e )
		{
			TreeSelectParent( ((FolderPattern)this.panelPattern.Tag).filter );
		}

		private void textBoxPatternPattern_TextChanged( object sender, EventArgs e )
		{
			if( ! ignoreChangeState )
			{
				TreeText( ((FolderPattern)this.panelPattern.Tag).filter, textBoxPatternPattern.Text );
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

		private int FilterImage( CtrlFilter fi )
		{
			switch( fi.Action )
			{
				case CtrlFilter.ActionType.Include:  return fi.IsFolder ? IMAGE_INCLUDE_FOLDER : IMAGE_INCLUDE_FILE;
				case CtrlFilter.ActionType.Exclude:  return fi.IsFolder ? IMAGE_EXCLUDE_FOLDER : IMAGE_EXCLUDE_FILE;
				case CtrlFilter.ActionType.History:  return fi.IsFolder ? IMAGE_HISTORY_FOLDER : IMAGE_HISTORY_FILE;
			}
			return IMAGE_FOLDER;
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