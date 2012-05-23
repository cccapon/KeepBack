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
namespace KeepBack
{
	partial class FormExplore
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormExplore));
			this.treeViewFolders = new System.Windows.Forms.TreeView();
			this.listViewFolder = new System.Windows.Forms.ListView();
			this.columnHeaderFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderModified = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.menuStripMain = new System.Windows.Forms.MenuStrip();
			this.toolStripMain = new System.Windows.Forms.ToolStrip();
			this.statusStripInfo = new System.Windows.Forms.StatusStrip();
			this.splitContainerFolder = new System.Windows.Forms.SplitContainer();
			this.labelFolders = new System.Windows.Forms.Label();
			this.labelHistory = new System.Windows.Forms.Label();
			this.labelFolder = new System.Windows.Forms.Label();
			this.listViewHistory = new System.Windows.Forms.ListView();
			this.columnHeaderDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.splitContainerFolder.Panel1.SuspendLayout();
			this.splitContainerFolder.Panel2.SuspendLayout();
			this.splitContainerFolder.SuspendLayout();
			this.SuspendLayout();
			// 
			// treeViewFolders
			// 
			this.treeViewFolders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.treeViewFolders.FullRowSelect = true;
			this.treeViewFolders.HideSelection = false;
			this.treeViewFolders.ImageIndex = 0;
			this.treeViewFolders.ImageList = this.imageList;
			this.treeViewFolders.Location = new System.Drawing.Point(3, 25);
			this.treeViewFolders.Name = "treeViewFolders";
			this.treeViewFolders.SelectedImageIndex = 0;
			this.treeViewFolders.Size = new System.Drawing.Size(306, 423);
			this.treeViewFolders.TabIndex = 0;
			this.treeViewFolders.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewFolders_AfterSelect);
			this.treeViewFolders.Enter += new System.EventHandler(this.treeViewFolders_Enter);
			// 
			// listViewFolder
			// 
			this.listViewFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listViewFolder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderFileName,
            this.columnHeaderSize,
            this.columnHeaderCount,
            this.columnHeaderModified});
			this.listViewFolder.HideSelection = false;
			this.listViewFolder.Location = new System.Drawing.Point(3, 25);
			this.listViewFolder.MultiSelect = false;
			this.listViewFolder.Name = "listViewFolder";
			this.listViewFolder.Size = new System.Drawing.Size(478, 423);
			this.listViewFolder.SmallImageList = this.imageList;
			this.listViewFolder.TabIndex = 1;
			this.listViewFolder.UseCompatibleStateImageBehavior = false;
			this.listViewFolder.View = System.Windows.Forms.View.Details;
			this.listViewFolder.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewFolder_ItemSelectionChanged);
			this.listViewFolder.DoubleClick += new System.EventHandler(this.listViewFolder_DoubleClick);
			this.listViewFolder.Enter += new System.EventHandler(this.listViewFolder_Enter);
			// 
			// columnHeaderFileName
			// 
			this.columnHeaderFileName.Text = "Filename";
			this.columnHeaderFileName.Width = 230;
			// 
			// columnHeaderSize
			// 
			this.columnHeaderSize.Text = "Size";
			this.columnHeaderSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// columnHeaderCount
			// 
			this.columnHeaderCount.Text = "Count";
			this.columnHeaderCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// columnHeaderModified
			// 
			this.columnHeaderModified.Text = "Modified";
			this.columnHeaderModified.Width = 105;
			// 
			// menuStripMain
			// 
			this.menuStripMain.Location = new System.Drawing.Point(0, 0);
			this.menuStripMain.Name = "menuStripMain";
			this.menuStripMain.Size = new System.Drawing.Size(938, 24);
			this.menuStripMain.TabIndex = 2;
			this.menuStripMain.Text = "menuStrip1";
			// 
			// toolStripMain
			// 
			this.toolStripMain.Location = new System.Drawing.Point(0, 24);
			this.toolStripMain.Name = "toolStripMain";
			this.toolStripMain.Size = new System.Drawing.Size(938, 25);
			this.toolStripMain.TabIndex = 3;
			this.toolStripMain.Text = "toolStrip1";
			// 
			// statusStripInfo
			// 
			this.statusStripInfo.Location = new System.Drawing.Point(0, 506);
			this.statusStripInfo.Name = "statusStripInfo";
			this.statusStripInfo.Size = new System.Drawing.Size(938, 22);
			this.statusStripInfo.TabIndex = 4;
			this.statusStripInfo.Text = "statusStrip1";
			// 
			// splitContainerFolder
			// 
			this.splitContainerFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainerFolder.Location = new System.Drawing.Point(0, 52);
			this.splitContainerFolder.Name = "splitContainerFolder";
			// 
			// splitContainerFolder.Panel1
			// 
			this.splitContainerFolder.Panel1.Controls.Add(this.labelFolders);
			this.splitContainerFolder.Panel1.Controls.Add(this.treeViewFolders);
			// 
			// splitContainerFolder.Panel2
			// 
			this.splitContainerFolder.Panel2.Controls.Add(this.labelHistory);
			this.splitContainerFolder.Panel2.Controls.Add(this.labelFolder);
			this.splitContainerFolder.Panel2.Controls.Add(this.listViewHistory);
			this.splitContainerFolder.Panel2.Controls.Add(this.listViewFolder);
			this.splitContainerFolder.Size = new System.Drawing.Size(938, 451);
			this.splitContainerFolder.SplitterDistance = 312;
			this.splitContainerFolder.TabIndex = 5;
			// 
			// labelFolders
			// 
			this.labelFolders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelFolders.Location = new System.Drawing.Point(3, 4);
			this.labelFolders.Name = "labelFolders";
			this.labelFolders.Size = new System.Drawing.Size(306, 18);
			this.labelFolders.TabIndex = 1;
			this.labelFolders.Text = "Folders";
			this.labelFolders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelHistory
			// 
			this.labelHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelHistory.Location = new System.Drawing.Point(484, 4);
			this.labelHistory.Name = "labelHistory";
			this.labelHistory.Size = new System.Drawing.Size(135, 18);
			this.labelHistory.TabIndex = 4;
			this.labelHistory.Text = "History";
			this.labelHistory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelFolder
			// 
			this.labelFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelFolder.AutoEllipsis = true;
			this.labelFolder.Location = new System.Drawing.Point(3, 4);
			this.labelFolder.Name = "labelFolder";
			this.labelFolder.Size = new System.Drawing.Size(478, 18);
			this.labelFolder.TabIndex = 3;
			this.labelFolder.Text = "Folder";
			this.labelFolder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// listViewHistory
			// 
			this.listViewHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listViewHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderDate});
			this.listViewHistory.Location = new System.Drawing.Point(487, 25);
			this.listViewHistory.Name = "listViewHistory";
			this.listViewHistory.Size = new System.Drawing.Size(132, 423);
			this.listViewHistory.TabIndex = 2;
			this.listViewHistory.UseCompatibleStateImageBehavior = false;
			this.listViewHistory.View = System.Windows.Forms.View.Details;
			// 
			// columnHeaderDate
			// 
			this.columnHeaderDate.Text = "Date";
			this.columnHeaderDate.Width = 109;
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "FolderClose.png");
			this.imageList.Images.SetKeyName(1, "FolderOpen.png");
			this.imageList.Images.SetKeyName(2, "File.png");
			// 
			// FormExplore
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(938, 528);
			this.Controls.Add(this.splitContainerFolder);
			this.Controls.Add(this.statusStripInfo);
			this.Controls.Add(this.toolStripMain);
			this.Controls.Add(this.menuStripMain);
			this.MainMenuStrip = this.menuStripMain;
			this.Name = "FormExplore";
			this.Text = "Archive History Browser";
			this.Shown += new System.EventHandler(this.FormExplore_Shown);
			this.splitContainerFolder.Panel1.ResumeLayout(false);
			this.splitContainerFolder.Panel2.ResumeLayout(false);
			this.splitContainerFolder.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TreeView treeViewFolders;
		private System.Windows.Forms.ListView listViewFolder;
		private System.Windows.Forms.MenuStrip menuStripMain;
		private System.Windows.Forms.ToolStrip toolStripMain;
		private System.Windows.Forms.StatusStrip statusStripInfo;
		private System.Windows.Forms.SplitContainer splitContainerFolder;
		private System.Windows.Forms.ListView listViewHistory;
		private System.Windows.Forms.ColumnHeader columnHeaderDate;
		private System.Windows.Forms.ColumnHeader columnHeaderFileName;
		private System.Windows.Forms.ColumnHeader columnHeaderSize;
		private System.Windows.Forms.ColumnHeader columnHeaderCount;
		private System.Windows.Forms.ColumnHeader columnHeaderModified;
		private System.Windows.Forms.Label labelFolders;
		private System.Windows.Forms.Label labelHistory;
		private System.Windows.Forms.Label labelFolder;
		private System.Windows.Forms.ImageList imageList;

	}
}