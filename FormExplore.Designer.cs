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
			this.treeViewFolders = new System.Windows.Forms.TreeView();
			this.listViewFolder = new System.Windows.Forms.ListView();
			this.menuStripMain = new System.Windows.Forms.MenuStrip();
			this.toolStripMain = new System.Windows.Forms.ToolStrip();
			this.statusStripInfo = new System.Windows.Forms.StatusStrip();
			this.splitContainerFolder = new System.Windows.Forms.SplitContainer();
			this.listViewHistory = new System.Windows.Forms.ListView();
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
			this.treeViewFolders.Location = new System.Drawing.Point(3, 3);
			this.treeViewFolders.Name = "treeViewFolders";
			this.treeViewFolders.Size = new System.Drawing.Size(306, 445);
			this.treeViewFolders.TabIndex = 0;
			// 
			// listViewFolder
			// 
			this.listViewFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.listViewFolder.Location = new System.Drawing.Point(3, 3);
			this.listViewFolder.Name = "listViewFolder";
			this.listViewFolder.Size = new System.Drawing.Size(478, 445);
			this.listViewFolder.TabIndex = 1;
			this.listViewFolder.UseCompatibleStateImageBehavior = false;
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
			this.splitContainerFolder.Panel1.Controls.Add(this.treeViewFolders);
			// 
			// splitContainerFolder.Panel2
			// 
			this.splitContainerFolder.Panel2.Controls.Add(this.listViewHistory);
			this.splitContainerFolder.Panel2.Controls.Add(this.listViewFolder);
			this.splitContainerFolder.Size = new System.Drawing.Size(938, 451);
			this.splitContainerFolder.SplitterDistance = 312;
			this.splitContainerFolder.TabIndex = 5;
			// 
			// listViewHistory
			// 
			this.listViewHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.listViewHistory.Location = new System.Drawing.Point(487, 3);
			this.listViewHistory.Name = "listViewHistory";
			this.listViewHistory.Size = new System.Drawing.Size(132, 445);
			this.listViewHistory.TabIndex = 2;
			this.listViewHistory.UseCompatibleStateImageBehavior = false;
			// 
			// FormHistory
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(938, 528);
			this.Controls.Add(this.splitContainerFolder);
			this.Controls.Add(this.statusStripInfo);
			this.Controls.Add(this.toolStripMain);
			this.Controls.Add(this.menuStripMain);
			this.MainMenuStrip = this.menuStripMain;
			this.Name = "FormHistory";
			this.Text = "Archive History Browser";
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

	}
}