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
	partial class FormEdit
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEdit));
			this.treeViewControl = new System.Windows.Forms.TreeView();
			this.imageListTree = new System.Windows.Forms.ImageList(this.components);
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.panelPattern = new System.Windows.Forms.Panel();
			this.groupBoxCase = new System.Windows.Forms.GroupBox();
			this.radioButtonCaseSensitive = new System.Windows.Forms.RadioButton();
			this.radioButtonCaseIgnore = new System.Windows.Forms.RadioButton();
			this.checkBoxPatternDebug = new System.Windows.Forms.CheckBox();
			this.buttonPatternPrevious = new System.Windows.Forms.Button();
			this.groupBoxPatternMatch = new System.Windows.Forms.GroupBox();
			this.radioButtonMatchFolder = new System.Windows.Forms.RadioButton();
			this.radioButtonMatchFile = new System.Windows.Forms.RadioButton();
			this.groupBoxPatternApply = new System.Windows.Forms.GroupBox();
			this.radioButtonApplyAbsolute = new System.Windows.Forms.RadioButton();
			this.radioButtonApplyRelative = new System.Windows.Forms.RadioButton();
			this.textBoxPatternPattern = new System.Windows.Forms.TextBox();
			this.labelPatternPattern = new System.Windows.Forms.Label();
			this.labelPattern = new System.Windows.Forms.Label();
			this.panelFolder = new System.Windows.Forms.Panel();
			this.buttonFolderPrevious = new System.Windows.Forms.Button();
			this.buttonFolderPath = new System.Windows.Forms.Button();
			this.labelListHistory = new System.Windows.Forms.Label();
			this.buttonHistoryDelete = new System.Windows.Forms.Button();
			this.buttonHistoryAdd = new System.Windows.Forms.Button();
			this.listBoxHistory = new System.Windows.Forms.ListBox();
			this.labelListExclude = new System.Windows.Forms.Label();
			this.buttonExcludeDelete = new System.Windows.Forms.Button();
			this.buttonExcludeAdd = new System.Windows.Forms.Button();
			this.listBoxExclude = new System.Windows.Forms.ListBox();
			this.labelListInclude = new System.Windows.Forms.Label();
			this.buttonIncludeDelete = new System.Windows.Forms.Button();
			this.buttonIncludeAdd = new System.Windows.Forms.Button();
			this.listBoxInclude = new System.Windows.Forms.ListBox();
			this.textBoxFolderPath = new System.Windows.Forms.TextBox();
			this.labelFolderPath = new System.Windows.Forms.Label();
			this.textBoxFolderName = new System.Windows.Forms.TextBox();
			this.labelFolderName = new System.Windows.Forms.Label();
			this.labelFolder = new System.Windows.Forms.Label();
			this.panelArchive = new System.Windows.Forms.Panel();
			this.buttonArchivePrevious = new System.Windows.Forms.Button();
			this.buttonArchivePath = new System.Windows.Forms.Button();
			this.buttonFolderDelete = new System.Windows.Forms.Button();
			this.buttonFolderAdd = new System.Windows.Forms.Button();
			this.labelListFolders = new System.Windows.Forms.Label();
			this.listBoxFolders = new System.Windows.Forms.ListBox();
			this.textBoxArchiveMinute = new System.Windows.Forms.TextBox();
			this.labelArchiveMinute = new System.Windows.Forms.Label();
			this.textBoxArchiveHour = new System.Windows.Forms.TextBox();
			this.labelArchiveHour = new System.Windows.Forms.Label();
			this.textBoxArchiveDay = new System.Windows.Forms.TextBox();
			this.labelArchiveDay = new System.Windows.Forms.Label();
			this.labelArchiveHistory = new System.Windows.Forms.Label();
			this.textBoxArchiveMonth = new System.Windows.Forms.TextBox();
			this.labelArchiveMonth = new System.Windows.Forms.Label();
			this.textBoxArchiveName = new System.Windows.Forms.TextBox();
			this.textBoxArchivePath = new System.Windows.Forms.TextBox();
			this.labelName = new System.Windows.Forms.Label();
			this.labelArchivePath = new System.Windows.Forms.Label();
			this.textBoxArchiveRoot = new System.Windows.Forms.TextBox();
			this.C = new System.Windows.Forms.Label();
			this.labelArchive = new System.Windows.Forms.Label();
			this.panelRoot = new System.Windows.Forms.Panel();
			this.buttonSave = new System.Windows.Forms.Button();
			this.labelRoot = new System.Windows.Forms.Label();
			this.labelListArchive = new System.Windows.Forms.Label();
			this.buttonArchiveDelete = new System.Windows.Forms.Button();
			this.buttonArchiveAdd = new System.Windows.Forms.Button();
			this.listBoxArchives = new System.Windows.Forms.ListBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.labelPattern1Tag = new System.Windows.Forms.Label();
			this.labelPattern1Description = new System.Windows.Forms.Label();
			this.labelPattern2Tag = new System.Windows.Forms.Label();
			this.labelPattern2Description = new System.Windows.Forms.Label();
			this.labelPattern3Tag = new System.Windows.Forms.Label();
			this.labelPattern3Description = new System.Windows.Forms.Label();
			this.labelPattern4Tag = new System.Windows.Forms.Label();
			this.labelPattern5Description = new System.Windows.Forms.Label();
			this.labelPattern5Tag = new System.Windows.Forms.Label();
			this.labelPattern4Description = new System.Windows.Forms.Label();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.panelPattern.SuspendLayout();
			this.groupBoxCase.SuspendLayout();
			this.groupBoxPatternMatch.SuspendLayout();
			this.groupBoxPatternApply.SuspendLayout();
			this.panelFolder.SuspendLayout();
			this.panelArchive.SuspendLayout();
			this.panelRoot.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// treeViewControl
			// 
			this.treeViewControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.treeViewControl.FullRowSelect = true;
			this.treeViewControl.HideSelection = false;
			this.treeViewControl.ImageIndex = 0;
			this.treeViewControl.ImageList = this.imageListTree;
			this.treeViewControl.Location = new System.Drawing.Point(0, 0);
			this.treeViewControl.Name = "treeViewControl";
			this.treeViewControl.SelectedImageIndex = 0;
			this.treeViewControl.Size = new System.Drawing.Size(265, 495);
			this.treeViewControl.TabIndex = 0;
			this.treeViewControl.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewControl_AfterSelect);
			// 
			// imageListTree
			// 
			this.imageListTree.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListTree.ImageStream")));
			this.imageListTree.TransparentColor = System.Drawing.Color.Transparent;
			this.imageListTree.Images.SetKeyName(0, "Control.png");
			this.imageListTree.Images.SetKeyName(1, "Archive.png");
			this.imageListTree.Images.SetKeyName(2, "FolderOpen.png");
			this.imageListTree.Images.SetKeyName(3, "IncludeFile.png");
			this.imageListTree.Images.SetKeyName(4, "IncludeFolder.png");
			this.imageListTree.Images.SetKeyName(5, "ExcludeFile.png");
			this.imageListTree.Images.SetKeyName(6, "ExcludeFolder.png");
			this.imageListTree.Images.SetKeyName(7, "HistoryFile.png");
			this.imageListTree.Images.SetKeyName(8, "HistoryFolder.png");
			// 
			// splitContainer
			// 
			this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer.Location = new System.Drawing.Point(1, 2);
			this.splitContainer.Name = "splitContainer";
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.Controls.Add(this.treeViewControl);
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.panelPattern);
			this.splitContainer.Panel2.Controls.Add(this.panelFolder);
			this.splitContainer.Panel2.Controls.Add(this.panelArchive);
			this.splitContainer.Panel2.Controls.Add(this.panelRoot);
			this.splitContainer.Size = new System.Drawing.Size(805, 498);
			this.splitContainer.SplitterDistance = 268;
			this.splitContainer.TabIndex = 1;
			// 
			// panelPattern
			// 
			this.panelPattern.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelPattern.Controls.Add(this.tableLayoutPanel1);
			this.panelPattern.Controls.Add(this.groupBoxCase);
			this.panelPattern.Controls.Add(this.checkBoxPatternDebug);
			this.panelPattern.Controls.Add(this.buttonPatternPrevious);
			this.panelPattern.Controls.Add(this.groupBoxPatternMatch);
			this.panelPattern.Controls.Add(this.groupBoxPatternApply);
			this.panelPattern.Controls.Add(this.textBoxPatternPattern);
			this.panelPattern.Controls.Add(this.labelPatternPattern);
			this.panelPattern.Controls.Add(this.labelPattern);
			this.panelPattern.Location = new System.Drawing.Point(4, 170);
			this.panelPattern.Name = "panelPattern";
			this.panelPattern.Size = new System.Drawing.Size(483, 317);
			this.panelPattern.TabIndex = 3;
			// 
			// groupBoxCase
			// 
			this.groupBoxCase.Controls.Add(this.radioButtonCaseSensitive);
			this.groupBoxCase.Controls.Add(this.radioButtonCaseIgnore);
			this.groupBoxCase.Location = new System.Drawing.Point(343, 66);
			this.groupBoxCase.Name = "groupBoxCase";
			this.groupBoxCase.Size = new System.Drawing.Size(110, 68);
			this.groupBoxCase.TabIndex = 26;
			this.groupBoxCase.TabStop = false;
			this.groupBoxCase.Text = "Character Case";
			// 
			// radioButtonCaseSensitive
			// 
			this.radioButtonCaseSensitive.AutoSize = true;
			this.radioButtonCaseSensitive.Location = new System.Drawing.Point(6, 19);
			this.radioButtonCaseSensitive.Name = "radioButtonCaseSensitive";
			this.radioButtonCaseSensitive.Size = new System.Drawing.Size(68, 17);
			this.radioButtonCaseSensitive.TabIndex = 21;
			this.radioButtonCaseSensitive.TabStop = true;
			this.radioButtonCaseSensitive.Text = "Sensitive";
			this.radioButtonCaseSensitive.UseVisualStyleBackColor = true;
			// 
			// radioButtonCaseIgnore
			// 
			this.radioButtonCaseIgnore.AutoSize = true;
			this.radioButtonCaseIgnore.Location = new System.Drawing.Point(6, 42);
			this.radioButtonCaseIgnore.Name = "radioButtonCaseIgnore";
			this.radioButtonCaseIgnore.Size = new System.Drawing.Size(55, 17);
			this.radioButtonCaseIgnore.TabIndex = 22;
			this.radioButtonCaseIgnore.TabStop = true;
			this.radioButtonCaseIgnore.Text = "Ignore";
			this.radioButtonCaseIgnore.UseVisualStyleBackColor = true;
			// 
			// checkBoxPatternDebug
			// 
			this.checkBoxPatternDebug.AutoSize = true;
			this.checkBoxPatternDebug.Location = new System.Drawing.Point(90, 140);
			this.checkBoxPatternDebug.Name = "checkBoxPatternDebug";
			this.checkBoxPatternDebug.Size = new System.Drawing.Size(310, 17);
			this.checkBoxPatternDebug.TabIndex = 41;
			this.checkBoxPatternDebug.Text = "Log all matches of this filter pattern (for diagnostic purposes).";
			this.checkBoxPatternDebug.UseVisualStyleBackColor = true;
			// 
			// buttonPatternPrevious
			// 
			this.buttonPatternPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonPatternPrevious.AutoSize = true;
			this.buttonPatternPrevious.FlatAppearance.BorderSize = 0;
			this.buttonPatternPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonPatternPrevious.Image = global::KeepBack.Properties.Resources.Previous;
			this.buttonPatternPrevious.Location = new System.Drawing.Point(453, 3);
			this.buttonPatternPrevious.Name = "buttonPatternPrevious";
			this.buttonPatternPrevious.Size = new System.Drawing.Size(24, 24);
			this.buttonPatternPrevious.TabIndex = 40;
			this.buttonPatternPrevious.UseVisualStyleBackColor = true;
			this.buttonPatternPrevious.Click += new System.EventHandler(this.buttonPatternPrevious_Click);
			// 
			// groupBoxPatternMatch
			// 
			this.groupBoxPatternMatch.Controls.Add(this.radioButtonMatchFolder);
			this.groupBoxPatternMatch.Controls.Add(this.radioButtonMatchFile);
			this.groupBoxPatternMatch.Location = new System.Drawing.Point(222, 66);
			this.groupBoxPatternMatch.Name = "groupBoxPatternMatch";
			this.groupBoxPatternMatch.Size = new System.Drawing.Size(86, 68);
			this.groupBoxPatternMatch.TabIndex = 25;
			this.groupBoxPatternMatch.TabStop = false;
			this.groupBoxPatternMatch.Text = "Matches only";
			// 
			// radioButtonMatchFolder
			// 
			this.radioButtonMatchFolder.AutoSize = true;
			this.radioButtonMatchFolder.Location = new System.Drawing.Point(6, 19);
			this.radioButtonMatchFolder.Name = "radioButtonMatchFolder";
			this.radioButtonMatchFolder.Size = new System.Drawing.Size(59, 17);
			this.radioButtonMatchFolder.TabIndex = 21;
			this.radioButtonMatchFolder.TabStop = true;
			this.radioButtonMatchFolder.Text = "Folders";
			this.radioButtonMatchFolder.UseVisualStyleBackColor = true;
			this.radioButtonMatchFolder.CheckedChanged += new System.EventHandler(this.radioButtonMatchFolder_CheckedChanged);
			// 
			// radioButtonMatchFile
			// 
			this.radioButtonMatchFile.AutoSize = true;
			this.radioButtonMatchFile.Location = new System.Drawing.Point(6, 42);
			this.radioButtonMatchFile.Name = "radioButtonMatchFile";
			this.radioButtonMatchFile.Size = new System.Drawing.Size(46, 17);
			this.radioButtonMatchFile.TabIndex = 22;
			this.radioButtonMatchFile.TabStop = true;
			this.radioButtonMatchFile.Text = "Files";
			this.radioButtonMatchFile.UseVisualStyleBackColor = true;
			this.radioButtonMatchFile.CheckedChanged += new System.EventHandler(this.radioButtonMatchFile_CheckedChanged);
			// 
			// groupBoxPatternApply
			// 
			this.groupBoxPatternApply.Controls.Add(this.radioButtonApplyAbsolute);
			this.groupBoxPatternApply.Controls.Add(this.radioButtonApplyRelative);
			this.groupBoxPatternApply.Location = new System.Drawing.Point(84, 66);
			this.groupBoxPatternApply.Name = "groupBoxPatternApply";
			this.groupBoxPatternApply.Size = new System.Drawing.Size(105, 68);
			this.groupBoxPatternApply.TabIndex = 24;
			this.groupBoxPatternApply.TabStop = false;
			this.groupBoxPatternApply.Text = "Applies only to";
			// 
			// radioButtonApplyAbsolute
			// 
			this.radioButtonApplyAbsolute.AutoSize = true;
			this.radioButtonApplyAbsolute.Location = new System.Drawing.Point(6, 19);
			this.radioButtonApplyAbsolute.Name = "radioButtonApplyAbsolute";
			this.radioButtonApplyAbsolute.Size = new System.Drawing.Size(80, 17);
			this.radioButtonApplyAbsolute.TabIndex = 18;
			this.radioButtonApplyAbsolute.TabStop = true;
			this.radioButtonApplyAbsolute.Text = "Fixed Paths";
			this.radioButtonApplyAbsolute.UseVisualStyleBackColor = true;
			this.radioButtonApplyAbsolute.CheckedChanged += new System.EventHandler(this.radioButtonApplyAbsolute_CheckedChanged);
			// 
			// radioButtonApplyRelative
			// 
			this.radioButtonApplyRelative.AutoSize = true;
			this.radioButtonApplyRelative.Location = new System.Drawing.Point(6, 42);
			this.radioButtonApplyRelative.Name = "radioButtonApplyRelative";
			this.radioButtonApplyRelative.Size = new System.Drawing.Size(94, 17);
			this.radioButtonApplyRelative.TabIndex = 19;
			this.radioButtonApplyRelative.TabStop = true;
			this.radioButtonApplyRelative.Text = "Relative Paths";
			this.radioButtonApplyRelative.UseVisualStyleBackColor = true;
			this.radioButtonApplyRelative.CheckedChanged += new System.EventHandler(this.radioButtonApplyRelative_CheckedChanged);
			// 
			// textBoxPatternPattern
			// 
			this.textBoxPatternPattern.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxPatternPattern.Location = new System.Drawing.Point(84, 40);
			this.textBoxPatternPattern.Name = "textBoxPatternPattern";
			this.textBoxPatternPattern.Size = new System.Drawing.Size(393, 20);
			this.textBoxPatternPattern.TabIndex = 17;
			this.textBoxPatternPattern.TextChanged += new System.EventHandler(this.textBoxPatternPattern_TextChanged);
			// 
			// labelPatternPattern
			// 
			this.labelPatternPattern.AutoSize = true;
			this.labelPatternPattern.Location = new System.Drawing.Point(4, 43);
			this.labelPatternPattern.Name = "labelPatternPattern";
			this.labelPatternPattern.Size = new System.Drawing.Size(41, 13);
			this.labelPatternPattern.TabIndex = 16;
			this.labelPatternPattern.Text = "Pattern";
			// 
			// labelPattern
			// 
			this.labelPattern.AutoSize = true;
			this.labelPattern.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPattern.Location = new System.Drawing.Point(3, 3);
			this.labelPattern.Name = "labelPattern";
			this.labelPattern.Size = new System.Drawing.Size(48, 13);
			this.labelPattern.TabIndex = 7;
			this.labelPattern.Text = "Pattern";
			// 
			// panelFolder
			// 
			this.panelFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelFolder.Controls.Add(this.buttonFolderPrevious);
			this.panelFolder.Controls.Add(this.buttonFolderPath);
			this.panelFolder.Controls.Add(this.labelListHistory);
			this.panelFolder.Controls.Add(this.buttonHistoryDelete);
			this.panelFolder.Controls.Add(this.buttonHistoryAdd);
			this.panelFolder.Controls.Add(this.listBoxHistory);
			this.panelFolder.Controls.Add(this.labelListExclude);
			this.panelFolder.Controls.Add(this.buttonExcludeDelete);
			this.panelFolder.Controls.Add(this.buttonExcludeAdd);
			this.panelFolder.Controls.Add(this.listBoxExclude);
			this.panelFolder.Controls.Add(this.labelListInclude);
			this.panelFolder.Controls.Add(this.buttonIncludeDelete);
			this.panelFolder.Controls.Add(this.buttonIncludeAdd);
			this.panelFolder.Controls.Add(this.listBoxInclude);
			this.panelFolder.Controls.Add(this.textBoxFolderPath);
			this.panelFolder.Controls.Add(this.labelFolderPath);
			this.panelFolder.Controls.Add(this.textBoxFolderName);
			this.panelFolder.Controls.Add(this.labelFolderName);
			this.panelFolder.Controls.Add(this.labelFolder);
			this.panelFolder.Location = new System.Drawing.Point(493, 3);
			this.panelFolder.Name = "panelFolder";
			this.panelFolder.Size = new System.Drawing.Size(483, 342);
			this.panelFolder.TabIndex = 2;
			// 
			// buttonFolderPrevious
			// 
			this.buttonFolderPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonFolderPrevious.AutoSize = true;
			this.buttonFolderPrevious.FlatAppearance.BorderSize = 0;
			this.buttonFolderPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonFolderPrevious.Image = global::KeepBack.Properties.Resources.Previous;
			this.buttonFolderPrevious.Location = new System.Drawing.Point(454, 3);
			this.buttonFolderPrevious.Name = "buttonFolderPrevious";
			this.buttonFolderPrevious.Size = new System.Drawing.Size(24, 24);
			this.buttonFolderPrevious.TabIndex = 39;
			this.buttonFolderPrevious.UseVisualStyleBackColor = true;
			this.buttonFolderPrevious.Click += new System.EventHandler(this.buttonFolderPrevious_Click);
			// 
			// buttonFolderPath
			// 
			this.buttonFolderPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonFolderPath.AutoSize = true;
			this.buttonFolderPath.FlatAppearance.BorderSize = 0;
			this.buttonFolderPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonFolderPath.Image = global::KeepBack.Properties.Resources.FolderOpen;
			this.buttonFolderPath.Location = new System.Drawing.Point(453, 38);
			this.buttonFolderPath.Name = "buttonFolderPath";
			this.buttonFolderPath.Size = new System.Drawing.Size(24, 24);
			this.buttonFolderPath.TabIndex = 37;
			this.buttonFolderPath.UseVisualStyleBackColor = true;
			this.buttonFolderPath.Click += new System.EventHandler(this.buttonFolderPath_Click);
			// 
			// labelListHistory
			// 
			this.labelListHistory.AutoSize = true;
			this.labelListHistory.Location = new System.Drawing.Point(4, 174);
			this.labelListHistory.Name = "labelListHistory";
			this.labelListHistory.Size = new System.Drawing.Size(309, 13);
			this.labelListHistory.TabIndex = 36;
			this.labelListHistory.Text = "Backup Once: File and Folder patterns (no History is maintained)";
			// 
			// buttonHistoryDelete
			// 
			this.buttonHistoryDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonHistoryDelete.AutoSize = true;
			this.buttonHistoryDelete.FlatAppearance.BorderSize = 0;
			this.buttonHistoryDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonHistoryDelete.Image = global::KeepBack.Properties.Resources.Delete;
			this.buttonHistoryDelete.Location = new System.Drawing.Point(455, 219);
			this.buttonHistoryDelete.Name = "buttonHistoryDelete";
			this.buttonHistoryDelete.Size = new System.Drawing.Size(24, 24);
			this.buttonHistoryDelete.TabIndex = 35;
			this.buttonHistoryDelete.Tag = "";
			this.buttonHistoryDelete.UseVisualStyleBackColor = true;
			this.buttonHistoryDelete.Click += new System.EventHandler(this.buttonHistoryDelete_Click);
			// 
			// buttonHistoryAdd
			// 
			this.buttonHistoryAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonHistoryAdd.AutoSize = true;
			this.buttonHistoryAdd.FlatAppearance.BorderSize = 0;
			this.buttonHistoryAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonHistoryAdd.Image = global::KeepBack.Properties.Resources.Add;
			this.buttonHistoryAdd.Location = new System.Drawing.Point(455, 190);
			this.buttonHistoryAdd.Name = "buttonHistoryAdd";
			this.buttonHistoryAdd.Size = new System.Drawing.Size(24, 24);
			this.buttonHistoryAdd.TabIndex = 34;
			this.buttonHistoryAdd.UseVisualStyleBackColor = true;
			this.buttonHistoryAdd.Click += new System.EventHandler(this.buttonHistoryAdd_Click);
			// 
			// listBoxHistory
			// 
			this.listBoxHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBoxHistory.FormattingEnabled = true;
			this.listBoxHistory.Location = new System.Drawing.Point(7, 190);
			this.listBoxHistory.Name = "listBoxHistory";
			this.listBoxHistory.Size = new System.Drawing.Size(448, 56);
			this.listBoxHistory.TabIndex = 33;
			this.listBoxHistory.DoubleClick += new System.EventHandler(this.listBoxHistory_DoubleClick);
			// 
			// labelListExclude
			// 
			this.labelListExclude.AutoSize = true;
			this.labelListExclude.Location = new System.Drawing.Point(4, 254);
			this.labelListExclude.Name = "labelListExclude";
			this.labelListExclude.Size = new System.Drawing.Size(285, 13);
			this.labelListExclude.TabIndex = 32;
			this.labelListExclude.Text = "Exclude: File and Folder patterns (will not be in the backup)";
			// 
			// buttonExcludeDelete
			// 
			this.buttonExcludeDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonExcludeDelete.AutoSize = true;
			this.buttonExcludeDelete.FlatAppearance.BorderSize = 0;
			this.buttonExcludeDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonExcludeDelete.Image = global::KeepBack.Properties.Resources.Delete;
			this.buttonExcludeDelete.Location = new System.Drawing.Point(455, 299);
			this.buttonExcludeDelete.Name = "buttonExcludeDelete";
			this.buttonExcludeDelete.Size = new System.Drawing.Size(24, 24);
			this.buttonExcludeDelete.TabIndex = 31;
			this.buttonExcludeDelete.Tag = "";
			this.buttonExcludeDelete.UseVisualStyleBackColor = true;
			this.buttonExcludeDelete.Click += new System.EventHandler(this.buttonExcludeDelete_Click);
			// 
			// buttonExcludeAdd
			// 
			this.buttonExcludeAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonExcludeAdd.AutoSize = true;
			this.buttonExcludeAdd.FlatAppearance.BorderSize = 0;
			this.buttonExcludeAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonExcludeAdd.Image = global::KeepBack.Properties.Resources.Add;
			this.buttonExcludeAdd.Location = new System.Drawing.Point(455, 270);
			this.buttonExcludeAdd.Name = "buttonExcludeAdd";
			this.buttonExcludeAdd.Size = new System.Drawing.Size(24, 24);
			this.buttonExcludeAdd.TabIndex = 30;
			this.buttonExcludeAdd.UseVisualStyleBackColor = true;
			this.buttonExcludeAdd.Click += new System.EventHandler(this.buttonExcludeAdd_Click);
			// 
			// listBoxExclude
			// 
			this.listBoxExclude.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBoxExclude.FormattingEnabled = true;
			this.listBoxExclude.Location = new System.Drawing.Point(7, 270);
			this.listBoxExclude.Name = "listBoxExclude";
			this.listBoxExclude.Size = new System.Drawing.Size(448, 56);
			this.listBoxExclude.TabIndex = 29;
			this.listBoxExclude.DoubleClick += new System.EventHandler(this.listBoxExclude_DoubleClick);
			// 
			// labelListInclude
			// 
			this.labelListInclude.AutoSize = true;
			this.labelListInclude.Location = new System.Drawing.Point(4, 94);
			this.labelListInclude.Name = "labelListInclude";
			this.labelListInclude.Size = new System.Drawing.Size(264, 13);
			this.labelListInclude.TabIndex = 28;
			this.labelListInclude.Text = "Include: File and Folder patterns (will be in the backup)";
			// 
			// buttonIncludeDelete
			// 
			this.buttonIncludeDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonIncludeDelete.AutoSize = true;
			this.buttonIncludeDelete.FlatAppearance.BorderSize = 0;
			this.buttonIncludeDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonIncludeDelete.Image = global::KeepBack.Properties.Resources.Delete;
			this.buttonIncludeDelete.Location = new System.Drawing.Point(455, 139);
			this.buttonIncludeDelete.Name = "buttonIncludeDelete";
			this.buttonIncludeDelete.Size = new System.Drawing.Size(24, 24);
			this.buttonIncludeDelete.TabIndex = 27;
			this.buttonIncludeDelete.Tag = "";
			this.buttonIncludeDelete.UseVisualStyleBackColor = true;
			this.buttonIncludeDelete.Click += new System.EventHandler(this.buttonIncludeDelete_Click);
			// 
			// buttonIncludeAdd
			// 
			this.buttonIncludeAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonIncludeAdd.AutoSize = true;
			this.buttonIncludeAdd.FlatAppearance.BorderSize = 0;
			this.buttonIncludeAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonIncludeAdd.Image = global::KeepBack.Properties.Resources.Add;
			this.buttonIncludeAdd.Location = new System.Drawing.Point(455, 110);
			this.buttonIncludeAdd.Name = "buttonIncludeAdd";
			this.buttonIncludeAdd.Size = new System.Drawing.Size(24, 24);
			this.buttonIncludeAdd.TabIndex = 26;
			this.buttonIncludeAdd.UseVisualStyleBackColor = true;
			this.buttonIncludeAdd.Click += new System.EventHandler(this.buttonIncludeAdd_Click);
			// 
			// listBoxInclude
			// 
			this.listBoxInclude.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBoxInclude.FormattingEnabled = true;
			this.listBoxInclude.Location = new System.Drawing.Point(7, 110);
			this.listBoxInclude.Name = "listBoxInclude";
			this.listBoxInclude.Size = new System.Drawing.Size(448, 56);
			this.listBoxInclude.TabIndex = 25;
			this.listBoxInclude.DoubleClick += new System.EventHandler(this.listBoxInclude_DoubleClick);
			// 
			// textBoxFolderPath
			// 
			this.textBoxFolderPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxFolderPath.Location = new System.Drawing.Point(84, 66);
			this.textBoxFolderPath.Name = "textBoxFolderPath";
			this.textBoxFolderPath.Size = new System.Drawing.Size(393, 20);
			this.textBoxFolderPath.TabIndex = 15;
			// 
			// labelFolderPath
			// 
			this.labelFolderPath.AutoSize = true;
			this.labelFolderPath.Location = new System.Drawing.Point(4, 69);
			this.labelFolderPath.Name = "labelFolderPath";
			this.labelFolderPath.Size = new System.Drawing.Size(29, 13);
			this.labelFolderPath.TabIndex = 14;
			this.labelFolderPath.Text = "Path";
			// 
			// textBoxFolderName
			// 
			this.textBoxFolderName.Location = new System.Drawing.Point(84, 40);
			this.textBoxFolderName.Name = "textBoxFolderName";
			this.textBoxFolderName.Size = new System.Drawing.Size(188, 20);
			this.textBoxFolderName.TabIndex = 13;
			this.textBoxFolderName.TextChanged += new System.EventHandler(this.textBoxFolderName_TextChanged);
			// 
			// labelFolderName
			// 
			this.labelFolderName.AutoSize = true;
			this.labelFolderName.Location = new System.Drawing.Point(4, 43);
			this.labelFolderName.Name = "labelFolderName";
			this.labelFolderName.Size = new System.Drawing.Size(35, 13);
			this.labelFolderName.TabIndex = 12;
			this.labelFolderName.Text = "Name";
			// 
			// labelFolder
			// 
			this.labelFolder.AutoSize = true;
			this.labelFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelFolder.Location = new System.Drawing.Point(4, 3);
			this.labelFolder.Name = "labelFolder";
			this.labelFolder.Size = new System.Drawing.Size(42, 13);
			this.labelFolder.TabIndex = 6;
			this.labelFolder.Text = "Folder";
			// 
			// panelArchive
			// 
			this.panelArchive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelArchive.Controls.Add(this.buttonArchivePrevious);
			this.panelArchive.Controls.Add(this.buttonArchivePath);
			this.panelArchive.Controls.Add(this.buttonFolderDelete);
			this.panelArchive.Controls.Add(this.buttonFolderAdd);
			this.panelArchive.Controls.Add(this.labelListFolders);
			this.panelArchive.Controls.Add(this.listBoxFolders);
			this.panelArchive.Controls.Add(this.textBoxArchiveMinute);
			this.panelArchive.Controls.Add(this.labelArchiveMinute);
			this.panelArchive.Controls.Add(this.textBoxArchiveHour);
			this.panelArchive.Controls.Add(this.labelArchiveHour);
			this.panelArchive.Controls.Add(this.textBoxArchiveDay);
			this.panelArchive.Controls.Add(this.labelArchiveDay);
			this.panelArchive.Controls.Add(this.labelArchiveHistory);
			this.panelArchive.Controls.Add(this.textBoxArchiveMonth);
			this.panelArchive.Controls.Add(this.labelArchiveMonth);
			this.panelArchive.Controls.Add(this.textBoxArchiveName);
			this.panelArchive.Controls.Add(this.textBoxArchivePath);
			this.panelArchive.Controls.Add(this.labelName);
			this.panelArchive.Controls.Add(this.labelArchivePath);
			this.panelArchive.Controls.Add(this.textBoxArchiveRoot);
			this.panelArchive.Controls.Add(this.C);
			this.panelArchive.Controls.Add(this.labelArchive);
			this.panelArchive.Location = new System.Drawing.Point(493, 351);
			this.panelArchive.Name = "panelArchive";
			this.panelArchive.Size = new System.Drawing.Size(483, 305);
			this.panelArchive.TabIndex = 1;
			// 
			// buttonArchivePrevious
			// 
			this.buttonArchivePrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonArchivePrevious.AutoSize = true;
			this.buttonArchivePrevious.FlatAppearance.BorderSize = 0;
			this.buttonArchivePrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonArchivePrevious.Image = global::KeepBack.Properties.Resources.Previous;
			this.buttonArchivePrevious.Location = new System.Drawing.Point(453, 3);
			this.buttonArchivePrevious.Name = "buttonArchivePrevious";
			this.buttonArchivePrevious.Size = new System.Drawing.Size(24, 24);
			this.buttonArchivePrevious.TabIndex = 41;
			this.buttonArchivePrevious.UseVisualStyleBackColor = true;
			this.buttonArchivePrevious.Click += new System.EventHandler(this.buttonArchivePrevious_Click);
			// 
			// buttonArchivePath
			// 
			this.buttonArchivePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonArchivePath.AutoSize = true;
			this.buttonArchivePath.FlatAppearance.BorderSize = 0;
			this.buttonArchivePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonArchivePath.Image = global::KeepBack.Properties.Resources.FolderOpen;
			this.buttonArchivePath.Location = new System.Drawing.Point(453, 36);
			this.buttonArchivePath.Name = "buttonArchivePath";
			this.buttonArchivePath.Size = new System.Drawing.Size(24, 24);
			this.buttonArchivePath.TabIndex = 25;
			this.buttonArchivePath.UseVisualStyleBackColor = true;
			this.buttonArchivePath.Click += new System.EventHandler(this.buttonArchivePath_Click);
			// 
			// buttonFolderDelete
			// 
			this.buttonFolderDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonFolderDelete.AutoSize = true;
			this.buttonFolderDelete.FlatAppearance.BorderSize = 0;
			this.buttonFolderDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonFolderDelete.Image = global::KeepBack.Properties.Resources.Delete;
			this.buttonFolderDelete.Location = new System.Drawing.Point(455, 232);
			this.buttonFolderDelete.Name = "buttonFolderDelete";
			this.buttonFolderDelete.Size = new System.Drawing.Size(24, 24);
			this.buttonFolderDelete.TabIndex = 24;
			this.buttonFolderDelete.Tag = "";
			this.buttonFolderDelete.UseVisualStyleBackColor = true;
			this.buttonFolderDelete.Click += new System.EventHandler(this.buttonFolderDelete_Click);
			// 
			// buttonFolderAdd
			// 
			this.buttonFolderAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonFolderAdd.AutoSize = true;
			this.buttonFolderAdd.FlatAppearance.BorderSize = 0;
			this.buttonFolderAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonFolderAdd.Image = global::KeepBack.Properties.Resources.Add;
			this.buttonFolderAdd.Location = new System.Drawing.Point(455, 203);
			this.buttonFolderAdd.Name = "buttonFolderAdd";
			this.buttonFolderAdd.Size = new System.Drawing.Size(24, 24);
			this.buttonFolderAdd.TabIndex = 23;
			this.buttonFolderAdd.UseVisualStyleBackColor = true;
			this.buttonFolderAdd.Click += new System.EventHandler(this.buttonFolderAdd_Click);
			// 
			// labelListFolders
			// 
			this.labelListFolders.AutoSize = true;
			this.labelListFolders.Location = new System.Drawing.Point(4, 187);
			this.labelListFolders.Name = "labelListFolders";
			this.labelListFolders.Size = new System.Drawing.Size(193, 13);
			this.labelListFolders.TabIndex = 22;
			this.labelListFolders.Text = "Folders to be backed up to the archive.";
			// 
			// listBoxFolders
			// 
			this.listBoxFolders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBoxFolders.FormattingEnabled = true;
			this.listBoxFolders.Location = new System.Drawing.Point(7, 203);
			this.listBoxFolders.Name = "listBoxFolders";
			this.listBoxFolders.Size = new System.Drawing.Size(448, 95);
			this.listBoxFolders.TabIndex = 21;
			this.listBoxFolders.DoubleClick += new System.EventHandler(this.listBoxFolders_DoubleClick);
			// 
			// textBoxArchiveMinute
			// 
			this.textBoxArchiveMinute.Location = new System.Drawing.Point(385, 152);
			this.textBoxArchiveMinute.Name = "textBoxArchiveMinute";
			this.textBoxArchiveMinute.Size = new System.Drawing.Size(31, 20);
			this.textBoxArchiveMinute.TabIndex = 20;
			this.textBoxArchiveMinute.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// labelArchiveMinute
			// 
			this.labelArchiveMinute.AutoSize = true;
			this.labelArchiveMinute.Location = new System.Drawing.Point(340, 155);
			this.labelArchiveMinute.Name = "labelArchiveMinute";
			this.labelArchiveMinute.Size = new System.Drawing.Size(44, 13);
			this.labelArchiveMinute.TabIndex = 19;
			this.labelArchiveMinute.Text = "Minutes";
			this.labelArchiveMinute.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// textBoxArchiveHour
			// 
			this.textBoxArchiveHour.Location = new System.Drawing.Point(277, 152);
			this.textBoxArchiveHour.Name = "textBoxArchiveHour";
			this.textBoxArchiveHour.Size = new System.Drawing.Size(31, 20);
			this.textBoxArchiveHour.TabIndex = 18;
			this.textBoxArchiveHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// labelArchiveHour
			// 
			this.labelArchiveHour.AutoSize = true;
			this.labelArchiveHour.Location = new System.Drawing.Point(241, 155);
			this.labelArchiveHour.Name = "labelArchiveHour";
			this.labelArchiveHour.Size = new System.Drawing.Size(35, 13);
			this.labelArchiveHour.TabIndex = 17;
			this.labelArchiveHour.Text = "Hours";
			this.labelArchiveHour.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// textBoxArchiveDay
			// 
			this.textBoxArchiveDay.Location = new System.Drawing.Point(169, 152);
			this.textBoxArchiveDay.Name = "textBoxArchiveDay";
			this.textBoxArchiveDay.Size = new System.Drawing.Size(31, 20);
			this.textBoxArchiveDay.TabIndex = 16;
			this.textBoxArchiveDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// labelArchiveDay
			// 
			this.labelArchiveDay.AutoSize = true;
			this.labelArchiveDay.Location = new System.Drawing.Point(137, 155);
			this.labelArchiveDay.Name = "labelArchiveDay";
			this.labelArchiveDay.Size = new System.Drawing.Size(31, 13);
			this.labelArchiveDay.TabIndex = 15;
			this.labelArchiveDay.Text = "Days";
			this.labelArchiveDay.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// labelArchiveHistory
			// 
			this.labelArchiveHistory.AutoSize = true;
			this.labelArchiveHistory.Location = new System.Drawing.Point(4, 129);
			this.labelArchiveHistory.Name = "labelArchiveHistory";
			this.labelArchiveHistory.Size = new System.Drawing.Size(406, 13);
			this.labelArchiveHistory.TabIndex = 14;
			this.labelArchiveHistory.Text = "After a period of time, historical backups are merged.  History is merged at four" +
    " levels.";
			// 
			// textBoxArchiveMonth
			// 
			this.textBoxArchiveMonth.Location = new System.Drawing.Point(61, 152);
			this.textBoxArchiveMonth.Name = "textBoxArchiveMonth";
			this.textBoxArchiveMonth.Size = new System.Drawing.Size(31, 20);
			this.textBoxArchiveMonth.TabIndex = 13;
			this.textBoxArchiveMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// labelArchiveMonth
			// 
			this.labelArchiveMonth.AutoSize = true;
			this.labelArchiveMonth.Location = new System.Drawing.Point(18, 155);
			this.labelArchiveMonth.Name = "labelArchiveMonth";
			this.labelArchiveMonth.Size = new System.Drawing.Size(42, 13);
			this.labelArchiveMonth.TabIndex = 12;
			this.labelArchiveMonth.Text = "Months";
			this.labelArchiveMonth.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// textBoxArchiveName
			// 
			this.textBoxArchiveName.Location = new System.Drawing.Point(84, 88);
			this.textBoxArchiveName.Name = "textBoxArchiveName";
			this.textBoxArchiveName.Size = new System.Drawing.Size(188, 20);
			this.textBoxArchiveName.TabIndex = 11;
			this.textBoxArchiveName.TextChanged += new System.EventHandler(this.textBoxArchiveName_TextChanged);
			// 
			// textBoxArchivePath
			// 
			this.textBoxArchivePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxArchivePath.Location = new System.Drawing.Point(84, 62);
			this.textBoxArchivePath.Name = "textBoxArchivePath";
			this.textBoxArchivePath.Size = new System.Drawing.Size(393, 20);
			this.textBoxArchivePath.TabIndex = 10;
			// 
			// labelName
			// 
			this.labelName.AutoSize = true;
			this.labelName.Location = new System.Drawing.Point(4, 91);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(74, 13);
			this.labelName.TabIndex = 9;
			this.labelName.Text = "Archive Name";
			// 
			// labelArchivePath
			// 
			this.labelArchivePath.AutoSize = true;
			this.labelArchivePath.Location = new System.Drawing.Point(4, 65);
			this.labelArchivePath.Name = "labelArchivePath";
			this.labelArchivePath.Size = new System.Drawing.Size(29, 13);
			this.labelArchivePath.TabIndex = 8;
			this.labelArchivePath.Text = "Path";
			// 
			// textBoxArchiveRoot
			// 
			this.textBoxArchiveRoot.Location = new System.Drawing.Point(84, 36);
			this.textBoxArchiveRoot.Name = "textBoxArchiveRoot";
			this.textBoxArchiveRoot.Size = new System.Drawing.Size(55, 20);
			this.textBoxArchiveRoot.TabIndex = 7;
			// 
			// C
			// 
			this.C.AutoSize = true;
			this.C.Location = new System.Drawing.Point(4, 39);
			this.C.Name = "C";
			this.C.Size = new System.Drawing.Size(58, 13);
			this.C.TabIndex = 6;
			this.C.Text = "Root Drive";
			// 
			// labelArchive
			// 
			this.labelArchive.AutoSize = true;
			this.labelArchive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelArchive.Location = new System.Drawing.Point(4, 3);
			this.labelArchive.Name = "labelArchive";
			this.labelArchive.Size = new System.Drawing.Size(50, 13);
			this.labelArchive.TabIndex = 5;
			this.labelArchive.Text = "Archive";
			// 
			// panelRoot
			// 
			this.panelRoot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelRoot.Controls.Add(this.buttonSave);
			this.panelRoot.Controls.Add(this.labelRoot);
			this.panelRoot.Controls.Add(this.labelListArchive);
			this.panelRoot.Controls.Add(this.buttonArchiveDelete);
			this.panelRoot.Controls.Add(this.buttonArchiveAdd);
			this.panelRoot.Controls.Add(this.listBoxArchives);
			this.panelRoot.Location = new System.Drawing.Point(4, 3);
			this.panelRoot.Name = "panelRoot";
			this.panelRoot.Size = new System.Drawing.Size(482, 161);
			this.panelRoot.TabIndex = 0;
			this.panelRoot.Tag = "";
			// 
			// buttonSave
			// 
			this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSave.Enabled = false;
			this.buttonSave.Location = new System.Drawing.Point(378, 3);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 5;
			this.buttonSave.Text = "Save";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// labelRoot
			// 
			this.labelRoot.AutoSize = true;
			this.labelRoot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelRoot.Location = new System.Drawing.Point(2, 2);
			this.labelRoot.Name = "labelRoot";
			this.labelRoot.Size = new System.Drawing.Size(73, 13);
			this.labelRoot.TabIndex = 4;
			this.labelRoot.Text = "Backup Set";
			// 
			// labelListArchive
			// 
			this.labelListArchive.AutoSize = true;
			this.labelListArchive.Location = new System.Drawing.Point(3, 27);
			this.labelListArchive.Name = "labelListArchive";
			this.labelListArchive.Size = new System.Drawing.Size(97, 13);
			this.labelListArchive.TabIndex = 3;
			this.labelListArchive.Text = "Archives in this Set";
			// 
			// buttonArchiveDelete
			// 
			this.buttonArchiveDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonArchiveDelete.AutoSize = true;
			this.buttonArchiveDelete.FlatAppearance.BorderSize = 0;
			this.buttonArchiveDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonArchiveDelete.Image = global::KeepBack.Properties.Resources.Delete;
			this.buttonArchiveDelete.Location = new System.Drawing.Point(453, 72);
			this.buttonArchiveDelete.Name = "buttonArchiveDelete";
			this.buttonArchiveDelete.Size = new System.Drawing.Size(24, 24);
			this.buttonArchiveDelete.TabIndex = 2;
			this.buttonArchiveDelete.Tag = "";
			this.buttonArchiveDelete.UseVisualStyleBackColor = true;
			this.buttonArchiveDelete.Click += new System.EventHandler(this.buttonArchiveDelete_Click);
			// 
			// buttonArchiveAdd
			// 
			this.buttonArchiveAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonArchiveAdd.AutoSize = true;
			this.buttonArchiveAdd.FlatAppearance.BorderSize = 0;
			this.buttonArchiveAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonArchiveAdd.Image = global::KeepBack.Properties.Resources.Add;
			this.buttonArchiveAdd.Location = new System.Drawing.Point(453, 43);
			this.buttonArchiveAdd.Name = "buttonArchiveAdd";
			this.buttonArchiveAdd.Size = new System.Drawing.Size(24, 24);
			this.buttonArchiveAdd.TabIndex = 1;
			this.buttonArchiveAdd.UseVisualStyleBackColor = true;
			this.buttonArchiveAdd.Click += new System.EventHandler(this.buttonArchiveAdd_Click);
			// 
			// listBoxArchives
			// 
			this.listBoxArchives.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBoxArchives.FormattingEnabled = true;
			this.listBoxArchives.Location = new System.Drawing.Point(6, 43);
			this.listBoxArchives.Name = "listBoxArchives";
			this.listBoxArchives.Size = new System.Drawing.Size(447, 108);
			this.listBoxArchives.TabIndex = 0;
			this.listBoxArchives.DoubleClick += new System.EventHandler(this.listBoxArchives_DoubleClick);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.76423F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.23577F));
			this.tableLayoutPanel1.Controls.Add(this.labelPattern5Tag, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.labelPattern4Tag, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.labelPattern3Description, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.labelPattern3Tag, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.labelPattern2Description, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.labelPattern2Tag, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.labelPattern1Description, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.labelPattern1Tag, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.labelPattern5Description, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.labelPattern4Description, 1, 3);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(84, 180);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 5;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(369, 109);
			this.tableLayoutPanel1.TabIndex = 42;
			// 
			// labelPattern1Tag
			// 
			this.labelPattern1Tag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPattern1Tag.Location = new System.Drawing.Point(3, 0);
			this.labelPattern1Tag.Name = "labelPattern1Tag";
			this.labelPattern1Tag.Size = new System.Drawing.Size(77, 19);
			this.labelPattern1Tag.TabIndex = 0;
			this.labelPattern1Tag.Text = "*";
			this.labelPattern1Tag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelPattern1Description
			// 
			this.labelPattern1Description.Location = new System.Drawing.Point(86, 0);
			this.labelPattern1Description.Name = "labelPattern1Description";
			this.labelPattern1Description.Size = new System.Drawing.Size(280, 19);
			this.labelPattern1Description.TabIndex = 1;
			this.labelPattern1Description.Text = "matches zero or more characters";
			this.labelPattern1Description.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelPattern2Tag
			// 
			this.labelPattern2Tag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPattern2Tag.Location = new System.Drawing.Point(3, 19);
			this.labelPattern2Tag.Name = "labelPattern2Tag";
			this.labelPattern2Tag.Size = new System.Drawing.Size(77, 19);
			this.labelPattern2Tag.TabIndex = 2;
			this.labelPattern2Tag.Text = "?";
			this.labelPattern2Tag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelPattern2Description
			// 
			this.labelPattern2Description.Location = new System.Drawing.Point(86, 19);
			this.labelPattern2Description.Name = "labelPattern2Description";
			this.labelPattern2Description.Size = new System.Drawing.Size(280, 19);
			this.labelPattern2Description.TabIndex = 3;
			this.labelPattern2Description.Text = "matches zero or one character";
			this.labelPattern2Description.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelPattern3Tag
			// 
			this.labelPattern3Tag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPattern3Tag.Location = new System.Drawing.Point(3, 38);
			this.labelPattern3Tag.Name = "labelPattern3Tag";
			this.labelPattern3Tag.Size = new System.Drawing.Size(77, 23);
			this.labelPattern3Tag.TabIndex = 4;
			this.labelPattern3Tag.Text = "\\";
			this.labelPattern3Tag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelPattern3Description
			// 
			this.labelPattern3Description.Location = new System.Drawing.Point(86, 38);
			this.labelPattern3Description.Name = "labelPattern3Description";
			this.labelPattern3Description.Size = new System.Drawing.Size(280, 24);
			this.labelPattern3Description.TabIndex = 5;
			this.labelPattern3Description.Text = "matches a directory path character";
			this.labelPattern3Description.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelPattern4Tag
			// 
			this.labelPattern4Tag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPattern4Tag.Location = new System.Drawing.Point(3, 62);
			this.labelPattern4Tag.Name = "labelPattern4Tag";
			this.labelPattern4Tag.Size = new System.Drawing.Size(77, 23);
			this.labelPattern4Tag.TabIndex = 6;
			this.labelPattern4Tag.Text = "/";
			this.labelPattern4Tag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelPattern5Description
			// 
			this.labelPattern5Description.Location = new System.Drawing.Point(86, 89);
			this.labelPattern5Description.Name = "labelPattern5Description";
			this.labelPattern5Description.Size = new System.Drawing.Size(280, 20);
			this.labelPattern5Description.TabIndex = 7;
			this.labelPattern5Description.Text = "match any number of intermediate directory levels";
			this.labelPattern5Description.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelPattern5Tag
			// 
			this.labelPattern5Tag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPattern5Tag.Location = new System.Drawing.Point(3, 89);
			this.labelPattern5Tag.Name = "labelPattern5Tag";
			this.labelPattern5Tag.Size = new System.Drawing.Size(77, 20);
			this.labelPattern5Tag.TabIndex = 8;
			this.labelPattern5Tag.Text = "/.../";
			this.labelPattern5Tag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelPattern4Description
			// 
			this.labelPattern4Description.Location = new System.Drawing.Point(86, 62);
			this.labelPattern4Description.Name = "labelPattern4Description";
			this.labelPattern4Description.Size = new System.Drawing.Size(280, 27);
			this.labelPattern4Description.TabIndex = 9;
			this.labelPattern4Description.Text = "matches a directory path character";
			this.labelPattern4Description.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// FormEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(807, 501);
			this.Controls.Add(this.splitContainer);
			this.Name = "FormEdit";
			this.Text = "Backup Selection";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEdit_FormClosing);
			this.Shown += new System.EventHandler(this.FormEdit_Shown);
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			this.splitContainer.ResumeLayout(false);
			this.panelPattern.ResumeLayout(false);
			this.panelPattern.PerformLayout();
			this.groupBoxCase.ResumeLayout(false);
			this.groupBoxCase.PerformLayout();
			this.groupBoxPatternMatch.ResumeLayout(false);
			this.groupBoxPatternMatch.PerformLayout();
			this.groupBoxPatternApply.ResumeLayout(false);
			this.groupBoxPatternApply.PerformLayout();
			this.panelFolder.ResumeLayout(false);
			this.panelFolder.PerformLayout();
			this.panelArchive.ResumeLayout(false);
			this.panelArchive.PerformLayout();
			this.panelRoot.ResumeLayout(false);
			this.panelRoot.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TreeView treeViewControl;
		private System.Windows.Forms.SplitContainer splitContainer;
		private System.Windows.Forms.Panel panelPattern;
		private System.Windows.Forms.Panel panelFolder;
		private System.Windows.Forms.Panel panelArchive;
		private System.Windows.Forms.Panel panelRoot;
		private System.Windows.Forms.ListBox listBoxArchives;
		private System.Windows.Forms.Button buttonArchiveAdd;
		private System.Windows.Forms.Button buttonArchiveDelete;
		private System.Windows.Forms.ImageList imageListTree;
		private System.Windows.Forms.Label labelListArchive;
		private System.Windows.Forms.Label labelRoot;
		private System.Windows.Forms.Label C;
		private System.Windows.Forms.Label labelArchive;
		private System.Windows.Forms.TextBox textBoxArchiveRoot;
		private System.Windows.Forms.Label labelArchivePath;
		private System.Windows.Forms.TextBox textBoxArchiveName;
		private System.Windows.Forms.TextBox textBoxArchivePath;
		private System.Windows.Forms.Label labelName;
		private System.Windows.Forms.TextBox textBoxArchiveMonth;
		private System.Windows.Forms.Label labelArchiveMonth;
		private System.Windows.Forms.Label labelArchiveHistory;
		private System.Windows.Forms.TextBox textBoxArchiveMinute;
		private System.Windows.Forms.Label labelArchiveMinute;
		private System.Windows.Forms.TextBox textBoxArchiveHour;
		private System.Windows.Forms.Label labelArchiveHour;
		private System.Windows.Forms.TextBox textBoxArchiveDay;
		private System.Windows.Forms.Label labelArchiveDay;
		private System.Windows.Forms.Label labelListFolders;
		private System.Windows.Forms.ListBox listBoxFolders;
		private System.Windows.Forms.Button buttonFolderDelete;
		private System.Windows.Forms.Button buttonFolderAdd;
		private System.Windows.Forms.Button buttonArchivePath;
		private System.Windows.Forms.TextBox textBoxFolderPath;
		private System.Windows.Forms.Label labelFolderPath;
		private System.Windows.Forms.TextBox textBoxFolderName;
		private System.Windows.Forms.Label labelFolderName;
		private System.Windows.Forms.Label labelFolder;
		private System.Windows.Forms.Label labelListInclude;
		private System.Windows.Forms.Button buttonIncludeDelete;
		private System.Windows.Forms.Button buttonIncludeAdd;
		private System.Windows.Forms.ListBox listBoxInclude;
		private System.Windows.Forms.Label labelListExclude;
		private System.Windows.Forms.Button buttonExcludeDelete;
		private System.Windows.Forms.Button buttonExcludeAdd;
		private System.Windows.Forms.ListBox listBoxExclude;
		private System.Windows.Forms.Label labelListHistory;
		private System.Windows.Forms.Button buttonHistoryDelete;
		private System.Windows.Forms.Button buttonHistoryAdd;
		private System.Windows.Forms.ListBox listBoxHistory;
		private System.Windows.Forms.TextBox textBoxPatternPattern;
		private System.Windows.Forms.Label labelPatternPattern;
		private System.Windows.Forms.Label labelPattern;
		private System.Windows.Forms.RadioButton radioButtonApplyRelative;
		private System.Windows.Forms.RadioButton radioButtonApplyAbsolute;
		private System.Windows.Forms.RadioButton radioButtonMatchFile;
		private System.Windows.Forms.RadioButton radioButtonMatchFolder;
		private System.Windows.Forms.GroupBox groupBoxPatternMatch;
		private System.Windows.Forms.GroupBox groupBoxPatternApply;
		private System.Windows.Forms.Button buttonFolderPath;
		private System.Windows.Forms.Button buttonFolderPrevious;
		private System.Windows.Forms.Button buttonArchivePrevious;
		private System.Windows.Forms.Button buttonPatternPrevious;
		private System.Windows.Forms.CheckBox checkBoxPatternDebug;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.GroupBox groupBoxCase;
		private System.Windows.Forms.RadioButton radioButtonCaseSensitive;
		private System.Windows.Forms.RadioButton radioButtonCaseIgnore;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label labelPattern5Description;
		private System.Windows.Forms.Label labelPattern4Tag;
		private System.Windows.Forms.Label labelPattern3Description;
		private System.Windows.Forms.Label labelPattern3Tag;
		private System.Windows.Forms.Label labelPattern2Description;
		private System.Windows.Forms.Label labelPattern2Tag;
		private System.Windows.Forms.Label labelPattern1Description;
		private System.Windows.Forms.Label labelPattern1Tag;
		private System.Windows.Forms.Label labelPattern5Tag;
		private System.Windows.Forms.Label labelPattern4Description;
	}
}