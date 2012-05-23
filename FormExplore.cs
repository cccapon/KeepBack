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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace KeepBack
{
	public partial class FormExplore : Form
	{
		//--- define ----------------------------

		struct HistoryFolder : IComparable<HistoryFolder>
		{
			public string           name    ; // filename
			public ulong            size    ; // total size of all files in all sub folders of the most current date folder
			public ulong            hsize   ; // total size of all files in all sub folders of all history date folders
			public ulong            count   ; // total count of all files in all sub folders of the most current date folder
			public ulong            hcount  ; // total count of all files in all sub folders of all history date folders
			public BitArray         history ; // bits indicating which history date folders this folder appears in
			public HistoryFolder[]  folders ; // list of immediate child folders from all history date folders
			public HistoryFile  []  files   ; // list of immediate child files from all history date folders

			public HistoryFolder( int histories, string name )
			{
				this.name    = name;
				this.size    = 0;
				this.hsize   = 0;
				this.count   = 0;
				this.hcount  = 0;
				this.folders = null;
				this.files   = null;
				this.history = new BitArray( histories );
			}
			public int CompareTo( HistoryFolder other )
			{
				return name.CompareTo( other.name );
			}
			public int FolderFind( string name )
			{
				if( folders == null )
				{
					return ~0;
				}
				HistoryFolder folder = new HistoryFolder( history.Count, name );
				return Array.BinarySearch<HistoryFolder>( folders, folder );
			}
			public void FolderInsert( int index, HistoryFolder folder )
			{
				List<HistoryFolder> a = (folders != null) ? new List<HistoryFolder>( folders ) : new List<HistoryFolder>();
				a.Insert( (index >= 0) ? index : ~index, folder );
				folders = a.ToArray();
			}
			public int FileFind( string name )
			{
				if( files == null )
				{
					return ~0;
				}
				HistoryFile file = new HistoryFile( history.Count, name );
				return Array.BinarySearch<HistoryFile>( files, file );
			}
			public void FileInsert( int index, HistoryFile file )
			{
				List<HistoryFile> a = (files != null) ? new List<HistoryFile>( files ) : new List<HistoryFile>();
				a.Insert( (index >= 0) ? index : ~index, file );
				files = a.ToArray();
			}
		}
		struct HistoryFile : IComparable<HistoryFile>
		{
			public string      name     ; // filename
			public ulong       size     ; // size of file in bytes
			public ulong       hsize    ; // total size of all versions of this file in all history date folders
			public DateTime    modified ; // most recent modified date from most current date folder
			public BitArray    history  ; // bits indicating which history date folders this folder appears in

			public bool Current { get { return history[0]; } }

			public HistoryFile( int histories, string name )
			{
				this.name      = name;
				this.size      = 0;
				this.hsize     = 0;
				this.modified  = DateTime.MinValue;
				this.history   = new BitArray( histories );
			}
			public int CompareTo( HistoryFile other )
			{
				return name.CompareTo( other.name );
			}

			public int Histories()
			{
				int c = 0;
				for( int i = 1; i < history.Count; ++i )
				{
					if( history[i] )
					{
						++c;
					}
				}
				return c;
			}

		}

		//--- field -----------------------------

		Ctrl           ctrl;

		//--- constructor -----------------------

		public FormExplore( Ctrl ctrl )
		{
			this.ctrl  = ctrl;
			InitializeComponent();
		}

		//--- method ----------------------------

		void Scan()
		{
			try
			{
				if( (ctrl != null) && (ctrl.Archive != null) )
				{
					List<string> a = new List<string>( ctrl.Archive.ArchiveList() );
					a.Sort( new Comparison<string>( InvertStrings ) );

					//scan folders
					string path = ctrl.Archive.FullPath;
					HistoryFolder root = new HistoryFolder( a.Count, "" );
					listViewHistory.Items.Clear();
					for( int i = 0; i < a.Count; ++i )
					{
						string s = a[i];
						root = Scan( root, Path.Combine( path, s ), i );
						ListViewItem li = listViewHistory.Items.Add( CtrlArchive.ArchiveDisplay( s ) );
						li.Tag = s;
					}

					//build tree view
					treeViewFolders.Nodes.Clear();
					TreeNode n = treeViewFolders.Nodes.Add( "(archive)" );
					BuildTree( n, root );
					treeViewFolders.SelectedNode = n;
				}
			}
			catch( Exception )
			{
			}
		}
		static int InvertStrings( string a, string b )
		{
			return b.CompareTo( a );
		}
		HistoryFolder Scan( HistoryFolder folder, string path, int history )
		{
			try
			{
				if( ! folder.history[history] && Directory.Exists( path ) )
				{
					//folders
					foreach( string p in Directory.GetDirectories( path ) )
					{
						string        s = Path.GetFileName( p );
						int           i = folder.FolderFind( s );
						HistoryFolder f = (i >= 0) ? folder.folders[i] : new HistoryFolder( folder.history.Count, s );
						f = Scan( f, Path.Combine( path, s ), history );
						if( i >= 0 )
						{
							folder.folders[i] = f;
						}
						else
						{
							folder.FolderInsert( i, f );
						}
					}
					//files
					foreach( string p in Directory.GetFiles( path ) )
					{
						FileInfo    fi = new FileInfo( p );
						string      s  = Path.GetFileName( p );
						int         i  = folder.FileFind( s );
						HistoryFile f  = (i >= 0) ? folder.files[i] : new HistoryFile( folder.history.Count, s );
						f.history[history] = true;
						if( f.modified < fi.LastWriteTime )
						{
							f.modified = fi.LastWriteTime;
						}
						if( history == 0 )
						{
							f.size = (ulong)fi.Length;
						}
						else
						{
							f.hsize += (ulong)fi.Length;
						}
						if( i >= 0 )
						{
							folder.files[i] = f;
						}
						else
						{
							folder.FileInsert( i, f );
						}
					}
					folder.history[history] = true;
				}
			}
			catch( Exception )
			{
			}
			return folder;
		}
		HistoryFolder BuildTree( TreeNode node, HistoryFolder folder )
		{
			try
			{
				folder.size   = 0;
				folder.hsize  = 0;
				folder.count  = 0;
				folder.hcount = 0;
				if( folder.folders != null )
				{
					for( int i = 0; i < folder.folders.Length; ++i )
					{
						HistoryFolder f = folder.folders[i];
						TreeNode n = node.Nodes.Add( f.name );
						n.ImageIndex = 0;
						n.SelectedImageIndex = 1;
						f = BuildTree( n, f );
						folder.size   += f.size;
						folder.hsize  += f.hsize;
						folder.count  += f.count;
						folder.hcount += f.hcount;
						folder.folders[i] = f;
					}
				}
				if( folder.files != null )
				{
					foreach( HistoryFile f in folder.files )
					{
						folder.size  += f.size;
						folder.hsize += f.hsize;
						if( f.Current )
						{
							folder.count++;
						}
						folder.hcount += (ulong)f.Histories();
					}
				}
				node.Tag = folder;
			}
			catch( Exception )
			{
			}
			return folder;
		}
		void HistorySelect( BitArray history )
		{
			int j = listViewHistory.Items.Count;
			int i = 0;
			while( i < history.Count )
			{
				listViewHistory.Items[i].ForeColor = history[i] ? Color.Black : Color.LightGray;
				++i;
			}
			while( i < j )
			{
				listViewHistory.Items[i].ForeColor = Color.GhostWhite;
			}
		}

		private void FormExplore_Shown( object sender, EventArgs e )
		{
			Scan();

		}

		private void treeViewFolders_AfterSelect( object sender, TreeViewEventArgs e )
		{
			try
			{
				if( (e.Node != null) && (e.Node.Tag != null) )
				{
					TreeNode      node   = e.Node;
					HistoryFolder folder = (HistoryFolder)node.Tag;

					// Select the entries under history in which this folder appears.
					HistorySelect( folder.history );

					// Fill folder list view of this folders contents.
					listViewFolder.Tag = node;
					listViewFolder.Items.Clear();
					if( folder.folders != null )
					{
						foreach( HistoryFolder f in folder.folders )
						{
							ListViewItem li = listViewFolder.Items.Add( /*"... " + Path.DirectorySeparatorChar + " " +*/ f.name );
							li.ImageIndex = 0;
							li.SubItems.Add( DisplayNumber( f.size  + f.hsize , SizeType.Kilo ) );
							li.SubItems.Add( DisplayNumber( f.count + f.hcount, SizeType.Byte ) );
							li.SubItems.Add( "" );
							li.Tag = f;
						}
					}
					if( folder.files != null )
					{
						foreach( HistoryFile f in folder.files )
						{
							ListViewItem li = listViewFolder.Items.Add( f.name );
							li.ImageIndex = 2;
							li.SubItems.Add( DisplayNumber( f.size + f.hsize, SizeType.Kilo ) );
							li.SubItems.Add( DisplayNumber( (ulong)((f.Current ? 1 : 0) + f.Histories()), SizeType.Byte ) );
							li.SubItems.Add( f.modified.ToString( "yyyy-MM-dd (HH:mm)" ) );
							li.Tag = f;
						}
					}

					// update the path displayed at the top of the folder contents list.
					string path = folder.name;
					while( ((node = node.Parent) != null) && (node.Tag != null) )
					{
						folder = (HistoryFolder)node.Tag;
						path = Path.Combine( folder.name, path );
					}
					labelFolder.Text = path;
				}
			}
			catch( Exception )
			{
			}
		}

		enum SizeType : int
		{
			Byte  = 0,
			Kilo  = 1,
			Mega  = 2,
			Giga  = 3,
		}

		string DisplayNumber( ulong val, SizeType size )
		{
			return val.ToString( "#,##0" + ",,,".Substring( 0, (int)size ) );
		}

		private void listViewFolder_ItemSelectionChanged( object sender, ListViewItemSelectionChangedEventArgs e )
		{
			if( e.IsSelected )
			{
				ListViewItem li = e.Item;
				object       o  = li.Tag;
				if( o is HistoryFolder )
				{
					HistorySelect( ((HistoryFolder)o).history );
				}
				else if( o is HistoryFile )
				{
					HistorySelect( ((HistoryFile)o).history );
				}
			}
		}

		private void listViewFolder_DoubleClick( object sender, EventArgs e )
		{
			if( listViewFolder.SelectedItems.Count == 1 )
			{
				ListViewItem li    = listViewFolder.SelectedItems[0];
				object       o     = li.Tag;
				TreeNode     node  = listViewFolder.Tag as TreeNode;
				if( (o is HistoryFolder) && (node != null) )
				{
					HistoryFolder fl  = (HistoryFolder)o;
					foreach( TreeNode n in node.Nodes )
					{
						HistoryFolder ft = (HistoryFolder)n.Tag;
						if( fl.name.CompareTo( ft.name ) == 0 )
						{
							treeViewFolders.SelectedNode = n;
							break;
						}
					}
				}
			}
		}

		private void treeViewFolders_Enter( object sender, EventArgs e )
		{
			listViewFolder.HideSelection = true;
		}

		private void listViewFolder_Enter( object sender, EventArgs e )
		{
			listViewFolder.HideSelection = false;
		}

		//--- end -------------------------------
	}
}