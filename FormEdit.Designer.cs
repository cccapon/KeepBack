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
			this.groupBoxAction = new System.Windows.Forms.GroupBox();
			this.radioButtonActionHistory = new System.Windows.Forms.RadioButton();
			this.radioButtonActionInclude = new System.Windows.Forms.RadioButton();
			this.radioButtonActionExclude = new System.Windows.Forms.RadioButton();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.labelPattern5Tag = new System.Windows.Forms.Label();
			this.labelPattern4Tag = new System.Windows.Forms.Label();
			this.labelPattern3Description = new System.Windows.Forms.Label();
			this.labelPattern3Tag = new System.Windows.Forms.Label();
			this.labelPattern2Description = new System.Windows.Forms.Label();
			this.labelPattern2Tag = new System.Windows.Forms.Label();
			this.labelPattern1Description = new System.Windows.Forms.Label();
			this.labelPattern1Tag = new System.Windows.Forms.Label();
			this.labelPattern5Description = new System.Windows.Forms.Label();
			this.labelPattern4Description = new System.Windows.Forms.Label();
			this.buttonPatternPrevious = new System.Windows.Forms.Button();
			this.groupBoxPatternMatch = new System.Windows.Forms.GroupBox();
			this.radioButtonMatchFolder = new System.Windows.Forms.RadioButton();
			this.radioButtonMatchFile = new System.Windows.Forms.RadioButton();
			this.groupBoxPatternApply = new System.Windows.Forms.GroupBox();
			this.radioButtonApplyAbsolute = new System.Windows.Forms.RadioButton();
			this.radioButtonApplyRelative = new System.Windows.Forms.RadioButton();
			this.textBoxPatternPattern = new System.Windows.Forms.TextBox();
			this.labelPatternPattern = new System.Windows.Forms.Label();
			this.labelFilter = new System.Windows.Forms.Label();
			this.panelFolder = new System.Windows.Forms.Panel();
			this.buttonFolderPrevious = new System.Windows.Forms.Button();
			this.buttonFolderPath = new System.Windows.Forms.Button();
			this.labelListFilter = new System.Windows.Forms.Label();
			this.buttonFilterDelete = new System.Windows.Forms.Button();
			this.buttonFilterAdd = new System.Windows.Forms.Button();
			this.listBoxFilter = new System.Windows.Forms.ListBox();
			this.textBoxFolderPath = new System.Windows.Forms.TextBox();
			this.labelFolderPath = new System.Windows.Forms.Label();
			this.textBoxFolderName = new System.Windows.Forms.TextBox();
			this.labelFolderName = new System.Windows.Forms.Label();
			this.labelFolder = new System.Windows.Forms.Label();
			this.panelArchive = new System.Windows.Forms.Panel();
			this.textBoxArchiveFullPath = new System.Windows.Forms.TextBox();
			this.textBoxLogsDays = new System.Windows.Forms.TextBox();
			this.labelLogsDays = new System.Windows.Forms.Label();
			this.labelLogsHistory = new System.Windows.Forms.Label();
			this.labelArrowSeconds = new System.Windows.Forms.Label();
			this.labelArrowMinutes = new System.Windows.Forms.Label();
			this.labelArrowHours = new System.Windows.Forms.Label();
			this.labelArrowMonths = new System.Windows.Forms.Label();
			this.labelArrowDays = new System.Windows.Forms.Label();
			this.textBoxArchiveSecond = new System.Windows.Forms.TextBox();
			this.labelArchiveSecond = new System.Windows.Forms.Label();
			this.textBoxArchiveYear = new System.Windows.Forms.TextBox();
			this.labelArchiveYear = new System.Windows.Forms.Label();
			this.buttonSave = new System.Windows.Forms.Button();
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
			this.labelArchivePath = new System.Windows.Forms.Label();
			this.labelArchive = new System.Windows.Forms.Label();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.panelPattern.SuspendLayout();
			this.groupBoxAction.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.groupBoxPatternMatch.SuspendLayout();
			this.groupBoxPatternApply.SuspendLayout();
			this.panelFolder.SuspendLayout();
			this.panelArchive.SuspendLayout();
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
			this.treeViewControl.Margin = new System.Windows.Forms.Padding(4);
			this.treeViewControl.Name = "treeViewControl";
			this.treeViewControl.SelectedImageIndex = 0;
			this.treeViewControl.Size = new System.Drawing.Size(258, 608);
			this.treeViewControl.TabIndex = 0;
			this.treeViewControl.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewControl_AfterSelect);
			// 
			// imageListTree
			// 
			this.imageListTree.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListTree.ImageStream")));
			this.imageListTree.TransparentColor = System.Drawing.Color.Transparent;
			this.imageListTree.Images.SetKeyName(0, "Archive.png");
			this.imageListTree.Images.SetKeyName(1, "FolderOpen.png");
			this.imageListTree.Images.SetKeyName(2, "IncludeFile.png");
			this.imageListTree.Images.SetKeyName(3, "IncludeFolder.png");
			this.imageListTree.Images.SetKeyName(4, "ExcludeFile.png");
			this.imageListTree.Images.SetKeyName(5, "ExcludeFolder.png");
			this.imageListTree.Images.SetKeyName(6, "HistoryFile.png");
			this.imageListTree.Images.SetKeyName(7, "HistoryFolder.png");
			// 
			// splitContainer
			// 
			this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer.Location = new System.Drawing.Point(1, 2);
			this.splitContainer.Margin = new System.Windows.Forms.Padding(4);
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
			this.splitContainer.Size = new System.Drawing.Size(937, 613);
			this.splitContainer.SplitterDistance = 241;
			this.splitContainer.SplitterWidth = 5;
			this.splitContainer.TabIndex = 1;
			// 
			// panelPattern
			// 
			this.panelPattern.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelPattern.Controls.Add(this.groupBoxAction);
			this.panelPattern.Controls.Add(this.tableLayoutPanel1);
			this.panelPattern.Controls.Add(this.buttonPatternPrevious);
			this.panelPattern.Controls.Add(this.groupBoxPatternMatch);
			this.panelPattern.Controls.Add(this.groupBoxPatternApply);
			this.panelPattern.Controls.Add(this.textBoxPatternPattern);
			this.panelPattern.Controls.Add(this.labelPatternPattern);
			this.panelPattern.Controls.Add(this.labelFilter);
			this.panelPattern.Location = new System.Drawing.Point(661, 544);
			this.panelPattern.Margin = new System.Windows.Forms.Padding(4);
			this.panelPattern.Name = "panelPattern";
			this.panelPattern.Size = new System.Drawing.Size(643, 390);
			this.panelPattern.TabIndex = 3;
			// 
			// groupBoxAction
			// 
			this.groupBoxAction.Controls.Add(this.radioButtonActionHistory);
			this.groupBoxAction.Controls.Add(this.radioButtonActionInclude);
			this.groupBoxAction.Controls.Add(this.radioButtonActionExclude);
			this.groupBoxAction.Location = new System.Drawing.Point(112, 26);
			this.groupBoxAction.Margin = new System.Windows.Forms.Padding(4);
			this.groupBoxAction.Name = "groupBoxAction";
			this.groupBoxAction.Padding = new System.Windows.Forms.Padding(4);
			this.groupBoxAction.Size = new System.Drawing.Size(358, 57);
			this.groupBoxAction.TabIndex = 1;
			this.groupBoxAction.TabStop = false;
			this.groupBoxAction.Text = "Action";
			// 
			// radioButtonActionHistory
			// 
			this.radioButtonActionHistory.AutoSize = true;
			this.radioButtonActionHistory.Location = new System.Drawing.Point(232, 23);
			this.radioButtonActionHistory.Margin = new System.Windows.Forms.Padding(4);
			this.radioButtonActionHistory.Name = "radioButtonActionHistory";
			this.radioButtonActionHistory.Size = new System.Drawing.Size(73, 21);
			this.radioButtonActionHistory.TabIndex = 2;
			this.radioButtonActionHistory.TabStop = true;
			this.radioButtonActionHistory.Text = "History";
			this.toolTip.SetToolTip(this.radioButtonActionHistory, "Matching items will be a part of the backup but no revisions will be kept.");
			this.radioButtonActionHistory.UseVisualStyleBackColor = true;
			// 
			// radioButtonActionInclude
			// 
			this.radioButtonActionInclude.AutoSize = true;
			this.radioButtonActionInclude.Location = new System.Drawing.Point(8, 23);
			this.radioButtonActionInclude.Margin = new System.Windows.Forms.Padding(4);
			this.radioButtonActionInclude.Name = "radioButtonActionInclude";
			this.radioButtonActionInclude.Size = new System.Drawing.Size(74, 21);
			this.radioButtonActionInclude.TabIndex = 0;
			this.radioButtonActionInclude.TabStop = true;
			this.radioButtonActionInclude.Text = "Include";
			this.toolTip.SetToolTip(this.radioButtonActionInclude, "Matching items will be part of the backup set.");
			this.radioButtonActionInclude.UseVisualStyleBackColor = true;
			// 
			// radioButtonActionExclude
			// 
			this.radioButtonActionExclude.AutoSize = true;
			this.radioButtonActionExclude.Location = new System.Drawing.Point(118, 23);
			this.radioButtonActionExclude.Margin = new System.Windows.Forms.Padding(4);
			this.radioButtonActionExclude.Name = "radioButtonActionExclude";
			this.radioButtonActionExclude.Size = new System.Drawing.Size(78, 21);
			this.radioButtonActionExclude.TabIndex = 1;
			this.radioButtonActionExclude.TabStop = true;
			this.radioButtonActionExclude.Text = "Exclude";
			this.toolTip.SetToolTip(this.radioButtonActionExclude, "Matching items will not be a part of the backup.");
			this.radioButtonActionExclude.UseVisualStyleBackColor = true;
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
			this.tableLayoutPanel1.Location = new System.Drawing.Point(112, 222);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 5;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(492, 134);
			this.tableLayoutPanel1.TabIndex = 42;
			// 
			// labelPattern5Tag
			// 
			this.labelPattern5Tag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPattern5Tag.Location = new System.Drawing.Point(4, 109);
			this.labelPattern5Tag.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelPattern5Tag.Name = "labelPattern5Tag";
			this.labelPattern5Tag.Size = new System.Drawing.Size(103, 25);
			this.labelPattern5Tag.TabIndex = 8;
			this.labelPattern5Tag.Text = "/.../";
			this.labelPattern5Tag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelPattern4Tag
			// 
			this.labelPattern4Tag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPattern4Tag.Location = new System.Drawing.Point(4, 76);
			this.labelPattern4Tag.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelPattern4Tag.Name = "labelPattern4Tag";
			this.labelPattern4Tag.Size = new System.Drawing.Size(103, 28);
			this.labelPattern4Tag.TabIndex = 6;
			this.labelPattern4Tag.Text = "/";
			this.labelPattern4Tag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelPattern3Description
			// 
			this.labelPattern3Description.Location = new System.Drawing.Point(116, 46);
			this.labelPattern3Description.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelPattern3Description.Name = "labelPattern3Description";
			this.labelPattern3Description.Size = new System.Drawing.Size(372, 30);
			this.labelPattern3Description.TabIndex = 5;
			this.labelPattern3Description.Text = "matches a directory path character";
			this.labelPattern3Description.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelPattern3Tag
			// 
			this.labelPattern3Tag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPattern3Tag.Location = new System.Drawing.Point(4, 46);
			this.labelPattern3Tag.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelPattern3Tag.Name = "labelPattern3Tag";
			this.labelPattern3Tag.Size = new System.Drawing.Size(103, 28);
			this.labelPattern3Tag.TabIndex = 4;
			this.labelPattern3Tag.Text = "\\";
			this.labelPattern3Tag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelPattern2Description
			// 
			this.labelPattern2Description.Location = new System.Drawing.Point(116, 23);
			this.labelPattern2Description.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelPattern2Description.Name = "labelPattern2Description";
			this.labelPattern2Description.Size = new System.Drawing.Size(372, 23);
			this.labelPattern2Description.TabIndex = 3;
			this.labelPattern2Description.Text = "matches zero or one character";
			this.labelPattern2Description.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelPattern2Tag
			// 
			this.labelPattern2Tag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPattern2Tag.Location = new System.Drawing.Point(4, 23);
			this.labelPattern2Tag.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelPattern2Tag.Name = "labelPattern2Tag";
			this.labelPattern2Tag.Size = new System.Drawing.Size(103, 23);
			this.labelPattern2Tag.TabIndex = 2;
			this.labelPattern2Tag.Text = "?";
			this.labelPattern2Tag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelPattern1Description
			// 
			this.labelPattern1Description.Location = new System.Drawing.Point(116, 0);
			this.labelPattern1Description.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelPattern1Description.Name = "labelPattern1Description";
			this.labelPattern1Description.Size = new System.Drawing.Size(372, 23);
			this.labelPattern1Description.TabIndex = 1;
			this.labelPattern1Description.Text = "matches zero or more characters";
			this.labelPattern1Description.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelPattern1Tag
			// 
			this.labelPattern1Tag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPattern1Tag.Location = new System.Drawing.Point(4, 0);
			this.labelPattern1Tag.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelPattern1Tag.Name = "labelPattern1Tag";
			this.labelPattern1Tag.Size = new System.Drawing.Size(103, 23);
			this.labelPattern1Tag.TabIndex = 0;
			this.labelPattern1Tag.Text = "*";
			this.labelPattern1Tag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelPattern5Description
			// 
			this.labelPattern5Description.Location = new System.Drawing.Point(116, 109);
			this.labelPattern5Description.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelPattern5Description.Name = "labelPattern5Description";
			this.labelPattern5Description.Size = new System.Drawing.Size(372, 25);
			this.labelPattern5Description.TabIndex = 9;
			this.labelPattern5Description.Text = "match any number of intermediate directory levels";
			this.labelPattern5Description.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelPattern4Description
			// 
			this.labelPattern4Description.Location = new System.Drawing.Point(116, 76);
			this.labelPattern4Description.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelPattern4Description.Name = "labelPattern4Description";
			this.labelPattern4Description.Size = new System.Drawing.Size(372, 33);
			this.labelPattern4Description.TabIndex = 7;
			this.labelPattern4Description.Text = "matches a directory path character";
			this.labelPattern4Description.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// buttonPatternPrevious
			// 
			this.buttonPatternPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonPatternPrevious.AutoSize = true;
			this.buttonPatternPrevious.FlatAppearance.BorderSize = 0;
			this.buttonPatternPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonPatternPrevious.Image = global::KeepBack.Properties.Resources.Previous;
			this.buttonPatternPrevious.Location = new System.Drawing.Point(604, 4);
			this.buttonPatternPrevious.Margin = new System.Windows.Forms.Padding(4);
			this.buttonPatternPrevious.Name = "buttonPatternPrevious";
			this.buttonPatternPrevious.Size = new System.Drawing.Size(32, 30);
			this.buttonPatternPrevious.TabIndex = 6;
			this.buttonPatternPrevious.UseVisualStyleBackColor = true;
			this.buttonPatternPrevious.Click += new System.EventHandler(this.buttonPatternPrevious_Click);
			// 
			// groupBoxPatternMatch
			// 
			this.groupBoxPatternMatch.Controls.Add(this.radioButtonMatchFolder);
			this.groupBoxPatternMatch.Controls.Add(this.radioButtonMatchFile);
			this.groupBoxPatternMatch.Location = new System.Drawing.Point(344, 123);
			this.groupBoxPatternMatch.Margin = new System.Windows.Forms.Padding(4);
			this.groupBoxPatternMatch.Name = "groupBoxPatternMatch";
			this.groupBoxPatternMatch.Padding = new System.Windows.Forms.Padding(4);
			this.groupBoxPatternMatch.Size = new System.Drawing.Size(115, 84);
			this.groupBoxPatternMatch.TabIndex = 5;
			this.groupBoxPatternMatch.TabStop = false;
			this.groupBoxPatternMatch.Text = "Matches only";
			// 
			// radioButtonMatchFolder
			// 
			this.radioButtonMatchFolder.AutoSize = true;
			this.radioButtonMatchFolder.Location = new System.Drawing.Point(8, 23);
			this.radioButtonMatchFolder.Margin = new System.Windows.Forms.Padding(4);
			this.radioButtonMatchFolder.Name = "radioButtonMatchFolder";
			this.radioButtonMatchFolder.Size = new System.Drawing.Size(76, 21);
			this.radioButtonMatchFolder.TabIndex = 0;
			this.radioButtonMatchFolder.TabStop = true;
			this.radioButtonMatchFolder.Text = "Folders";
			this.radioButtonMatchFolder.UseVisualStyleBackColor = true;
			this.radioButtonMatchFolder.CheckedChanged += new System.EventHandler(this.radioButtonMatchFolder_CheckedChanged);
			// 
			// radioButtonMatchFile
			// 
			this.radioButtonMatchFile.AutoSize = true;
			this.radioButtonMatchFile.Location = new System.Drawing.Point(8, 52);
			this.radioButtonMatchFile.Margin = new System.Windows.Forms.Padding(4);
			this.radioButtonMatchFile.Name = "radioButtonMatchFile";
			this.radioButtonMatchFile.Size = new System.Drawing.Size(58, 21);
			this.radioButtonMatchFile.TabIndex = 1;
			this.radioButtonMatchFile.TabStop = true;
			this.radioButtonMatchFile.Text = "Files";
			this.radioButtonMatchFile.UseVisualStyleBackColor = true;
			this.radioButtonMatchFile.CheckedChanged += new System.EventHandler(this.radioButtonMatchFile_CheckedChanged);
			// 
			// groupBoxPatternApply
			// 
			this.groupBoxPatternApply.Controls.Add(this.radioButtonApplyAbsolute);
			this.groupBoxPatternApply.Controls.Add(this.radioButtonApplyRelative);
			this.groupBoxPatternApply.Location = new System.Drawing.Point(112, 123);
			this.groupBoxPatternApply.Margin = new System.Windows.Forms.Padding(4);
			this.groupBoxPatternApply.Name = "groupBoxPatternApply";
			this.groupBoxPatternApply.Padding = new System.Windows.Forms.Padding(4);
			this.groupBoxPatternApply.Size = new System.Drawing.Size(140, 84);
			this.groupBoxPatternApply.TabIndex = 4;
			this.groupBoxPatternApply.TabStop = false;
			this.groupBoxPatternApply.Text = "Applies only to";
			// 
			// radioButtonApplyAbsolute
			// 
			this.radioButtonApplyAbsolute.AutoSize = true;
			this.radioButtonApplyAbsolute.Location = new System.Drawing.Point(8, 23);
			this.radioButtonApplyAbsolute.Margin = new System.Windows.Forms.Padding(4);
			this.radioButtonApplyAbsolute.Name = "radioButtonApplyAbsolute";
			this.radioButtonApplyAbsolute.Size = new System.Drawing.Size(102, 21);
			this.radioButtonApplyAbsolute.TabIndex = 0;
			this.radioButtonApplyAbsolute.TabStop = true;
			this.radioButtonApplyAbsolute.Text = "Fixed Paths";
			this.radioButtonApplyAbsolute.UseVisualStyleBackColor = true;
			this.radioButtonApplyAbsolute.CheckedChanged += new System.EventHandler(this.radioButtonApplyAbsolute_CheckedChanged);
			// 
			// radioButtonApplyRelative
			// 
			this.radioButtonApplyRelative.AutoSize = true;
			this.radioButtonApplyRelative.Location = new System.Drawing.Point(8, 52);
			this.radioButtonApplyRelative.Margin = new System.Windows.Forms.Padding(4);
			this.radioButtonApplyRelative.Name = "radioButtonApplyRelative";
			this.radioButtonApplyRelative.Size = new System.Drawing.Size(120, 21);
			this.radioButtonApplyRelative.TabIndex = 1;
			this.radioButtonApplyRelative.TabStop = true;
			this.radioButtonApplyRelative.Text = "Relative Paths";
			this.radioButtonApplyRelative.UseVisualStyleBackColor = true;
			this.radioButtonApplyRelative.CheckedChanged += new System.EventHandler(this.radioButtonApplyRelative_CheckedChanged);
			// 
			// textBoxPatternPattern
			// 
			this.textBoxPatternPattern.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxPatternPattern.Location = new System.Drawing.Point(112, 91);
			this.textBoxPatternPattern.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxPatternPattern.Name = "textBoxPatternPattern";
			this.textBoxPatternPattern.Size = new System.Drawing.Size(523, 22);
			this.textBoxPatternPattern.TabIndex = 3;
			this.textBoxPatternPattern.TextChanged += new System.EventHandler(this.textBoxPatternPattern_TextChanged);
			// 
			// labelPatternPattern
			// 
			this.labelPatternPattern.AutoSize = true;
			this.labelPatternPattern.Location = new System.Drawing.Point(5, 95);
			this.labelPatternPattern.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelPatternPattern.Name = "labelPatternPattern";
			this.labelPatternPattern.Size = new System.Drawing.Size(54, 17);
			this.labelPatternPattern.TabIndex = 2;
			this.labelPatternPattern.Text = "Pattern";
			// 
			// labelFilter
			// 
			this.labelFilter.AutoSize = true;
			this.labelFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelFilter.Location = new System.Drawing.Point(4, 4);
			this.labelFilter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelFilter.Name = "labelFilter";
			this.labelFilter.Size = new System.Drawing.Size(45, 17);
			this.labelFilter.TabIndex = 0;
			this.labelFilter.Text = "Filter";
			// 
			// panelFolder
			// 
			this.panelFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelFolder.Controls.Add(this.buttonFolderPrevious);
			this.panelFolder.Controls.Add(this.buttonFolderPath);
			this.panelFolder.Controls.Add(this.labelListFilter);
			this.panelFolder.Controls.Add(this.buttonFilterDelete);
			this.panelFolder.Controls.Add(this.buttonFilterAdd);
			this.panelFolder.Controls.Add(this.listBoxFilter);
			this.panelFolder.Controls.Add(this.textBoxFolderPath);
			this.panelFolder.Controls.Add(this.labelFolderPath);
			this.panelFolder.Controls.Add(this.textBoxFolderName);
			this.panelFolder.Controls.Add(this.labelFolderName);
			this.panelFolder.Controls.Add(this.labelFolder);
			this.panelFolder.Location = new System.Drawing.Point(654, 11);
			this.panelFolder.Margin = new System.Windows.Forms.Padding(4);
			this.panelFolder.Name = "panelFolder";
			this.panelFolder.Size = new System.Drawing.Size(643, 496);
			this.panelFolder.TabIndex = 0;
			// 
			// buttonFolderPrevious
			// 
			this.buttonFolderPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonFolderPrevious.AutoSize = true;
			this.buttonFolderPrevious.FlatAppearance.BorderSize = 0;
			this.buttonFolderPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonFolderPrevious.Image = global::KeepBack.Properties.Resources.Previous;
			this.buttonFolderPrevious.Location = new System.Drawing.Point(605, 4);
			this.buttonFolderPrevious.Margin = new System.Windows.Forms.Padding(4);
			this.buttonFolderPrevious.Name = "buttonFolderPrevious";
			this.buttonFolderPrevious.Size = new System.Drawing.Size(32, 30);
			this.buttonFolderPrevious.TabIndex = 10;
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
			this.buttonFolderPath.Location = new System.Drawing.Point(607, 78);
			this.buttonFolderPath.Margin = new System.Windows.Forms.Padding(4);
			this.buttonFolderPath.Name = "buttonFolderPath";
			this.buttonFolderPath.Size = new System.Drawing.Size(32, 30);
			this.buttonFolderPath.TabIndex = 5;
			this.buttonFolderPath.UseVisualStyleBackColor = true;
			this.buttonFolderPath.Click += new System.EventHandler(this.buttonFolderPath_Click);
			// 
			// labelListFilter
			// 
			this.labelListFilter.AutoSize = true;
			this.labelListFilter.Location = new System.Drawing.Point(5, 116);
			this.labelListFilter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelListFilter.Name = "labelListFilter";
			this.labelListFilter.Size = new System.Drawing.Size(490, 17);
			this.labelListFilter.TabIndex = 6;
			this.labelListFilter.Text = "Filters   (actions associated with directories or file names matching a pattern)";
			// 
			// buttonFilterDelete
			// 
			this.buttonFilterDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonFilterDelete.AutoSize = true;
			this.buttonFilterDelete.FlatAppearance.BorderSize = 0;
			this.buttonFilterDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonFilterDelete.Image = global::KeepBack.Properties.Resources.Delete;
			this.buttonFilterDelete.Location = new System.Drawing.Point(607, 171);
			this.buttonFilterDelete.Margin = new System.Windows.Forms.Padding(4);
			this.buttonFilterDelete.Name = "buttonFilterDelete";
			this.buttonFilterDelete.Size = new System.Drawing.Size(32, 30);
			this.buttonFilterDelete.TabIndex = 9;
			this.buttonFilterDelete.Tag = "";
			this.toolTip.SetToolTip(this.buttonFilterDelete, "Delete a filter pattern selected in the list.");
			this.buttonFilterDelete.UseVisualStyleBackColor = true;
			this.buttonFilterDelete.Click += new System.EventHandler(this.buttonFilterDelete_Click);
			// 
			// buttonFilterAdd
			// 
			this.buttonFilterAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonFilterAdd.AutoSize = true;
			this.buttonFilterAdd.FlatAppearance.BorderSize = 0;
			this.buttonFilterAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonFilterAdd.Image = global::KeepBack.Properties.Resources.Add;
			this.buttonFilterAdd.Location = new System.Drawing.Point(607, 135);
			this.buttonFilterAdd.Margin = new System.Windows.Forms.Padding(4);
			this.buttonFilterAdd.Name = "buttonFilterAdd";
			this.buttonFilterAdd.Size = new System.Drawing.Size(32, 30);
			this.buttonFilterAdd.TabIndex = 8;
			this.toolTip.SetToolTip(this.buttonFilterAdd, "Add a new filter pattern to the list.");
			this.buttonFilterAdd.UseVisualStyleBackColor = true;
			this.buttonFilterAdd.Click += new System.EventHandler(this.buttonFilterAdd_Click);
			// 
			// listBoxFilter
			// 
			this.listBoxFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBoxFilter.FormattingEnabled = true;
			this.listBoxFilter.ItemHeight = 16;
			this.listBoxFilter.Location = new System.Drawing.Point(8, 133);
			this.listBoxFilter.Margin = new System.Windows.Forms.Padding(4);
			this.listBoxFilter.Name = "listBoxFilter";
			this.listBoxFilter.Size = new System.Drawing.Size(596, 276);
			this.listBoxFilter.TabIndex = 7;
			this.listBoxFilter.DoubleClick += new System.EventHandler(this.listBoxFilter_DoubleClick);
			// 
			// textBoxFolderPath
			// 
			this.textBoxFolderPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxFolderPath.Location = new System.Drawing.Point(68, 81);
			this.textBoxFolderPath.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxFolderPath.Name = "textBoxFolderPath";
			this.textBoxFolderPath.Size = new System.Drawing.Size(537, 22);
			this.textBoxFolderPath.TabIndex = 4;
			// 
			// labelFolderPath
			// 
			this.labelFolderPath.AutoSize = true;
			this.labelFolderPath.Location = new System.Drawing.Point(5, 85);
			this.labelFolderPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelFolderPath.Name = "labelFolderPath";
			this.labelFolderPath.Size = new System.Drawing.Size(37, 17);
			this.labelFolderPath.TabIndex = 3;
			this.labelFolderPath.Text = "Path";
			// 
			// textBoxFolderName
			// 
			this.textBoxFolderName.Location = new System.Drawing.Point(68, 49);
			this.textBoxFolderName.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxFolderName.Name = "textBoxFolderName";
			this.textBoxFolderName.Size = new System.Drawing.Size(249, 22);
			this.textBoxFolderName.TabIndex = 2;
			this.textBoxFolderName.TextChanged += new System.EventHandler(this.textBoxFolderName_TextChanged);
			// 
			// labelFolderName
			// 
			this.labelFolderName.AutoSize = true;
			this.labelFolderName.Location = new System.Drawing.Point(5, 53);
			this.labelFolderName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelFolderName.Name = "labelFolderName";
			this.labelFolderName.Size = new System.Drawing.Size(45, 17);
			this.labelFolderName.TabIndex = 1;
			this.labelFolderName.Text = "Name";
			// 
			// labelFolder
			// 
			this.labelFolder.AutoSize = true;
			this.labelFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelFolder.Location = new System.Drawing.Point(5, 4);
			this.labelFolder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelFolder.Name = "labelFolder";
			this.labelFolder.Size = new System.Drawing.Size(54, 17);
			this.labelFolder.TabIndex = 0;
			this.labelFolder.Text = "Folder";
			// 
			// panelArchive
			// 
			this.panelArchive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelArchive.Controls.Add(this.textBoxArchiveFullPath);
			this.panelArchive.Controls.Add(this.textBoxLogsDays);
			this.panelArchive.Controls.Add(this.labelLogsDays);
			this.panelArchive.Controls.Add(this.labelLogsHistory);
			this.panelArchive.Controls.Add(this.labelArrowSeconds);
			this.panelArchive.Controls.Add(this.labelArrowMinutes);
			this.panelArchive.Controls.Add(this.labelArrowHours);
			this.panelArchive.Controls.Add(this.labelArrowMonths);
			this.panelArchive.Controls.Add(this.labelArrowDays);
			this.panelArchive.Controls.Add(this.textBoxArchiveSecond);
			this.panelArchive.Controls.Add(this.labelArchiveSecond);
			this.panelArchive.Controls.Add(this.textBoxArchiveYear);
			this.panelArchive.Controls.Add(this.labelArchiveYear);
			this.panelArchive.Controls.Add(this.buttonSave);
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
			this.panelArchive.Controls.Add(this.labelArchivePath);
			this.panelArchive.Controls.Add(this.labelArchive);
			this.panelArchive.Location = new System.Drawing.Point(10, 549);
			this.panelArchive.Margin = new System.Windows.Forms.Padding(4);
			this.panelArchive.Name = "panelArchive";
			this.panelArchive.Size = new System.Drawing.Size(643, 370);
			this.panelArchive.TabIndex = 1;
			// 
			// textBoxArchiveFullPath
			// 
			this.textBoxArchiveFullPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxArchiveFullPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBoxArchiveFullPath.Location = new System.Drawing.Point(9, 49);
			this.textBoxArchiveFullPath.Name = "textBoxArchiveFullPath";
			this.textBoxArchiveFullPath.ReadOnly = true;
			this.textBoxArchiveFullPath.Size = new System.Drawing.Size(596, 22);
			this.textBoxArchiveFullPath.TabIndex = 2;
			// 
			// textBoxLogsDays
			// 
			this.textBoxLogsDays.Location = new System.Drawing.Point(131, 185);
			this.textBoxLogsDays.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxLogsDays.Name = "textBoxLogsDays";
			this.textBoxLogsDays.Size = new System.Drawing.Size(40, 22);
			this.textBoxLogsDays.TabIndex = 24;
			this.textBoxLogsDays.Text = "90";
			this.textBoxLogsDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolTip.SetToolTip(this.textBoxLogsDays, "After this number of days, old log files will be deleted.");
			this.textBoxLogsDays.TextChanged += new System.EventHandler(this.textBoxArchive_TextChanged);
			// 
			// labelLogsDays
			// 
			this.labelLogsDays.AutoSize = true;
			this.labelLogsDays.Location = new System.Drawing.Point(57, 188);
			this.labelLogsDays.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelLogsDays.Name = "labelLogsDays";
			this.labelLogsDays.Size = new System.Drawing.Size(40, 17);
			this.labelLogsDays.TabIndex = 23;
			this.labelLogsDays.Text = "Days";
			this.labelLogsDays.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// labelLogsHistory
			// 
			this.labelLogsHistory.AutoSize = true;
			this.labelLogsHistory.Location = new System.Drawing.Point(5, 163);
			this.labelLogsHistory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelLogsHistory.Name = "labelLogsHistory";
			this.labelLogsHistory.Size = new System.Drawing.Size(441, 17);
			this.labelLogsHistory.TabIndex = 22;
			this.labelLogsHistory.Text = "Log files will be deleted after a certain number of days.  (0 = Disable)";
			// 
			// labelArrowSeconds
			// 
			this.labelArrowSeconds.Image = global::KeepBack.Properties.Resources.LeftArrow;
			this.labelArrowSeconds.Location = new System.Drawing.Point(467, 131);
			this.labelArrowSeconds.Name = "labelArrowSeconds";
			this.labelArrowSeconds.Size = new System.Drawing.Size(17, 17);
			this.labelArrowSeconds.TabIndex = 18;
			// 
			// labelArrowMinutes
			// 
			this.labelArrowMinutes.Image = global::KeepBack.Properties.Resources.LeftArrow;
			this.labelArrowMinutes.Location = new System.Drawing.Point(374, 131);
			this.labelArrowMinutes.Name = "labelArrowMinutes";
			this.labelArrowMinutes.Size = new System.Drawing.Size(17, 17);
			this.labelArrowMinutes.TabIndex = 15;
			// 
			// labelArrowHours
			// 
			this.labelArrowHours.Image = global::KeepBack.Properties.Resources.LeftArrow;
			this.labelArrowHours.Location = new System.Drawing.Point(281, 131);
			this.labelArrowHours.Name = "labelArrowHours";
			this.labelArrowHours.Size = new System.Drawing.Size(17, 17);
			this.labelArrowHours.TabIndex = 12;
			// 
			// labelArrowMonths
			// 
			this.labelArrowMonths.Image = global::KeepBack.Properties.Resources.LeftArrow;
			this.labelArrowMonths.Location = new System.Drawing.Point(95, 131);
			this.labelArrowMonths.Name = "labelArrowMonths";
			this.labelArrowMonths.Size = new System.Drawing.Size(17, 17);
			this.labelArrowMonths.TabIndex = 6;
			// 
			// labelArrowDays
			// 
			this.labelArrowDays.Image = global::KeepBack.Properties.Resources.LeftArrow;
			this.labelArrowDays.Location = new System.Drawing.Point(188, 131);
			this.labelArrowDays.Name = "labelArrowDays";
			this.labelArrowDays.Size = new System.Drawing.Size(17, 17);
			this.labelArrowDays.TabIndex = 9;
			// 
			// textBoxArchiveSecond
			// 
			this.textBoxArchiveSecond.Enabled = false;
			this.textBoxArchiveSecond.Location = new System.Drawing.Point(503, 128);
			this.textBoxArchiveSecond.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxArchiveSecond.Name = "textBoxArchiveSecond";
			this.textBoxArchiveSecond.Size = new System.Drawing.Size(40, 22);
			this.textBoxArchiveSecond.TabIndex = 20;
			this.textBoxArchiveSecond.Text = "60";
			this.textBoxArchiveSecond.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolTip.SetToolTip(this.textBoxArchiveSecond, "After this number of seconds, second-by-second backups are merged together into m" +
        "inutes.");
			// 
			// labelArchiveSecond
			// 
			this.labelArchiveSecond.AutoSize = true;
			this.labelArchiveSecond.Location = new System.Drawing.Point(500, 107);
			this.labelArchiveSecond.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelArchiveSecond.Name = "labelArchiveSecond";
			this.labelArchiveSecond.Size = new System.Drawing.Size(63, 17);
			this.labelArchiveSecond.TabIndex = 19;
			this.labelArchiveSecond.Text = "Seconds";
			this.labelArchiveSecond.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// textBoxArchiveYear
			// 
			this.textBoxArchiveYear.Enabled = false;
			this.textBoxArchiveYear.Location = new System.Drawing.Point(38, 128);
			this.textBoxArchiveYear.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxArchiveYear.Name = "textBoxArchiveYear";
			this.textBoxArchiveYear.Size = new System.Drawing.Size(40, 22);
			this.textBoxArchiveYear.TabIndex = 5;
			this.textBoxArchiveYear.Text = "99";
			this.textBoxArchiveYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolTip.SetToolTip(this.textBoxArchiveYear, "Years are never merged.");
			// 
			// labelArchiveYear
			// 
			this.labelArchiveYear.AutoSize = true;
			this.labelArchiveYear.Location = new System.Drawing.Point(35, 107);
			this.labelArchiveYear.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelArchiveYear.Name = "labelArchiveYear";
			this.labelArchiveYear.Size = new System.Drawing.Size(45, 17);
			this.labelArchiveYear.TabIndex = 4;
			this.labelArchiveYear.Text = "Years";
			this.labelArchiveYear.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// buttonSave
			// 
			this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSave.Enabled = false;
			this.buttonSave.Location = new System.Drawing.Point(536, 4);
			this.buttonSave.Margin = new System.Windows.Forms.Padding(4);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(100, 28);
			this.buttonSave.TabIndex = 0;
			this.buttonSave.Text = "Save";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// buttonFolderDelete
			// 
			this.buttonFolderDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonFolderDelete.AutoSize = true;
			this.buttonFolderDelete.FlatAppearance.BorderSize = 0;
			this.buttonFolderDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonFolderDelete.Image = global::KeepBack.Properties.Resources.Delete;
			this.buttonFolderDelete.Location = new System.Drawing.Point(607, 269);
			this.buttonFolderDelete.Margin = new System.Windows.Forms.Padding(4);
			this.buttonFolderDelete.Name = "buttonFolderDelete";
			this.buttonFolderDelete.Size = new System.Drawing.Size(32, 30);
			this.buttonFolderDelete.TabIndex = 28;
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
			this.buttonFolderAdd.Location = new System.Drawing.Point(607, 234);
			this.buttonFolderAdd.Margin = new System.Windows.Forms.Padding(4);
			this.buttonFolderAdd.Name = "buttonFolderAdd";
			this.buttonFolderAdd.Size = new System.Drawing.Size(32, 30);
			this.buttonFolderAdd.TabIndex = 27;
			this.buttonFolderAdd.UseVisualStyleBackColor = true;
			this.buttonFolderAdd.Click += new System.EventHandler(this.buttonFolderAdd_Click);
			// 
			// labelListFolders
			// 
			this.labelListFolders.AutoSize = true;
			this.labelListFolders.Location = new System.Drawing.Point(5, 214);
			this.labelListFolders.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelListFolders.Name = "labelListFolders";
			this.labelListFolders.Size = new System.Drawing.Size(255, 17);
			this.labelListFolders.TabIndex = 25;
			this.labelListFolders.Text = "Folders to be backed up to the archive.";
			// 
			// listBoxFolders
			// 
			this.listBoxFolders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBoxFolders.FormattingEnabled = true;
			this.listBoxFolders.ItemHeight = 16;
			this.listBoxFolders.Location = new System.Drawing.Point(9, 234);
			this.listBoxFolders.Margin = new System.Windows.Forms.Padding(4);
			this.listBoxFolders.Name = "listBoxFolders";
			this.listBoxFolders.Size = new System.Drawing.Size(596, 132);
			this.listBoxFolders.TabIndex = 26;
			this.listBoxFolders.DoubleClick += new System.EventHandler(this.listBoxFolders_DoubleClick);
			// 
			// textBoxArchiveMinute
			// 
			this.textBoxArchiveMinute.Location = new System.Drawing.Point(410, 128);
			this.textBoxArchiveMinute.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxArchiveMinute.Name = "textBoxArchiveMinute";
			this.textBoxArchiveMinute.Size = new System.Drawing.Size(40, 22);
			this.textBoxArchiveMinute.TabIndex = 17;
			this.textBoxArchiveMinute.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolTip.SetToolTip(this.textBoxArchiveMinute, "After this number of minutes, minute-by-minute backups are merged together into h" +
        "ours.");
			this.textBoxArchiveMinute.TextChanged += new System.EventHandler(this.textBoxArchive_TextChanged);
			// 
			// labelArchiveMinute
			// 
			this.labelArchiveMinute.AutoSize = true;
			this.labelArchiveMinute.Location = new System.Drawing.Point(407, 107);
			this.labelArchiveMinute.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelArchiveMinute.Name = "labelArchiveMinute";
			this.labelArchiveMinute.Size = new System.Drawing.Size(57, 17);
			this.labelArchiveMinute.TabIndex = 16;
			this.labelArchiveMinute.Text = "Minutes";
			this.labelArchiveMinute.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// textBoxArchiveHour
			// 
			this.textBoxArchiveHour.Location = new System.Drawing.Point(317, 128);
			this.textBoxArchiveHour.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxArchiveHour.Name = "textBoxArchiveHour";
			this.textBoxArchiveHour.Size = new System.Drawing.Size(40, 22);
			this.textBoxArchiveHour.TabIndex = 14;
			this.textBoxArchiveHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolTip.SetToolTip(this.textBoxArchiveHour, "After this number of hours, hourly backups are merged together into days.");
			this.textBoxArchiveHour.TextChanged += new System.EventHandler(this.textBoxArchive_TextChanged);
			// 
			// labelArchiveHour
			// 
			this.labelArchiveHour.AutoSize = true;
			this.labelArchiveHour.Location = new System.Drawing.Point(314, 107);
			this.labelArchiveHour.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelArchiveHour.Name = "labelArchiveHour";
			this.labelArchiveHour.Size = new System.Drawing.Size(46, 17);
			this.labelArchiveHour.TabIndex = 13;
			this.labelArchiveHour.Text = "Hours";
			this.labelArchiveHour.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// textBoxArchiveDay
			// 
			this.textBoxArchiveDay.Location = new System.Drawing.Point(224, 128);
			this.textBoxArchiveDay.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxArchiveDay.Name = "textBoxArchiveDay";
			this.textBoxArchiveDay.Size = new System.Drawing.Size(40, 22);
			this.textBoxArchiveDay.TabIndex = 11;
			this.textBoxArchiveDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolTip.SetToolTip(this.textBoxArchiveDay, "After this number of days, daily backups are merged together into months.");
			this.textBoxArchiveDay.TextChanged += new System.EventHandler(this.textBoxArchive_TextChanged);
			// 
			// labelArchiveDay
			// 
			this.labelArchiveDay.AutoSize = true;
			this.labelArchiveDay.Location = new System.Drawing.Point(221, 107);
			this.labelArchiveDay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelArchiveDay.Name = "labelArchiveDay";
			this.labelArchiveDay.Size = new System.Drawing.Size(40, 17);
			this.labelArchiveDay.TabIndex = 10;
			this.labelArchiveDay.Text = "Days";
			this.labelArchiveDay.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// labelArchiveHistory
			// 
			this.labelArchiveHistory.AutoSize = true;
			this.labelArchiveHistory.Location = new System.Drawing.Point(5, 83);
			this.labelArchiveHistory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelArchiveHistory.Name = "labelArchiveHistory";
			this.labelArchiveHistory.Size = new System.Drawing.Size(526, 17);
			this.labelArchiveHistory.TabIndex = 3;
			this.labelArchiveHistory.Text = "Over time, historical backups will be merged together to save space.  (0 = Disabl" +
    "e)";
			// 
			// textBoxArchiveMonth
			// 
			this.textBoxArchiveMonth.Location = new System.Drawing.Point(131, 128);
			this.textBoxArchiveMonth.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxArchiveMonth.Name = "textBoxArchiveMonth";
			this.textBoxArchiveMonth.Size = new System.Drawing.Size(40, 22);
			this.textBoxArchiveMonth.TabIndex = 8;
			this.textBoxArchiveMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolTip.SetToolTip(this.textBoxArchiveMonth, "After this number of months, monthly backups are merged together into years.");
			this.textBoxArchiveMonth.TextChanged += new System.EventHandler(this.textBoxArchive_TextChanged);
			// 
			// labelArchiveMonth
			// 
			this.labelArchiveMonth.AutoSize = true;
			this.labelArchiveMonth.Location = new System.Drawing.Point(128, 107);
			this.labelArchiveMonth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelArchiveMonth.Name = "labelArchiveMonth";
			this.labelArchiveMonth.Size = new System.Drawing.Size(54, 17);
			this.labelArchiveMonth.TabIndex = 7;
			this.labelArchiveMonth.Text = "Months";
			this.labelArchiveMonth.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// labelArchivePath
			// 
			this.labelArchivePath.AutoSize = true;
			this.labelArchivePath.Location = new System.Drawing.Point(6, 29);
			this.labelArchivePath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelArchivePath.Name = "labelArchivePath";
			this.labelArchivePath.Size = new System.Drawing.Size(66, 17);
			this.labelArchivePath.TabIndex = 1;
			this.labelArchivePath.Text = "Location:";
			// 
			// labelArchive
			// 
			this.labelArchive.AutoSize = true;
			this.labelArchive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelArchive.Location = new System.Drawing.Point(5, 4);
			this.labelArchive.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelArchive.Name = "labelArchive";
			this.labelArchive.Size = new System.Drawing.Size(62, 17);
			this.labelArchive.TabIndex = 0;
			this.labelArchive.Text = "Archive";
			// 
			// toolTip
			// 
			this.toolTip.AutoPopDelay = 15000;
			this.toolTip.InitialDelay = 100;
			this.toolTip.IsBalloon = true;
			this.toolTip.ReshowDelay = 100;
			// 
			// FormEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(940, 617);
			this.Controls.Add(this.splitContainer);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MinimumSize = new System.Drawing.Size(640, 47);
			this.Name = "FormEdit";
			this.Text = "Backup Selection";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEdit_FormClosing);
			this.Load += new System.EventHandler(this.FormEdit_Load);
			this.Shown += new System.EventHandler(this.FormEdit_Shown);
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.panelPattern.ResumeLayout(false);
			this.panelPattern.PerformLayout();
			this.groupBoxAction.ResumeLayout(false);
			this.groupBoxAction.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.groupBoxPatternMatch.ResumeLayout(false);
			this.groupBoxPatternMatch.PerformLayout();
			this.groupBoxPatternApply.ResumeLayout(false);
			this.groupBoxPatternApply.PerformLayout();
			this.panelFolder.ResumeLayout(false);
			this.panelFolder.PerformLayout();
			this.panelArchive.ResumeLayout(false);
			this.panelArchive.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TreeView treeViewControl;
		private System.Windows.Forms.SplitContainer splitContainer;
		private System.Windows.Forms.Panel panelPattern;
		private System.Windows.Forms.Panel panelFolder;
		private System.Windows.Forms.Panel panelArchive;
		private System.Windows.Forms.ImageList imageListTree;
		private System.Windows.Forms.Label labelArchive;
		private System.Windows.Forms.Label labelArchivePath;
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
		private System.Windows.Forms.TextBox textBoxFolderPath;
		private System.Windows.Forms.Label labelFolderPath;
		private System.Windows.Forms.TextBox textBoxFolderName;
		private System.Windows.Forms.Label labelFolderName;
		private System.Windows.Forms.Label labelFolder;
		private System.Windows.Forms.Label labelListFilter;
		private System.Windows.Forms.Button buttonFilterDelete;
		private System.Windows.Forms.Button buttonFilterAdd;
		private System.Windows.Forms.ListBox listBoxFilter;
		private System.Windows.Forms.TextBox textBoxPatternPattern;
		private System.Windows.Forms.Label labelPatternPattern;
		private System.Windows.Forms.Label labelFilter;
		private System.Windows.Forms.RadioButton radioButtonApplyRelative;
		private System.Windows.Forms.RadioButton radioButtonApplyAbsolute;
		private System.Windows.Forms.RadioButton radioButtonMatchFile;
		private System.Windows.Forms.RadioButton radioButtonMatchFolder;
		private System.Windows.Forms.GroupBox groupBoxPatternMatch;
		private System.Windows.Forms.GroupBox groupBoxPatternApply;
		private System.Windows.Forms.Button buttonFolderPath;
		private System.Windows.Forms.Button buttonFolderPrevious;
		private System.Windows.Forms.Button buttonPatternPrevious;
		private System.Windows.Forms.Button buttonSave;
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
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.TextBox textBoxArchiveYear;
		private System.Windows.Forms.Label labelArchiveYear;
		private System.Windows.Forms.TextBox textBoxArchiveSecond;
		private System.Windows.Forms.Label labelArchiveSecond;
		private System.Windows.Forms.Label labelArrowDays;
		private System.Windows.Forms.Label labelArrowSeconds;
		private System.Windows.Forms.Label labelArrowMinutes;
		private System.Windows.Forms.Label labelArrowHours;
		private System.Windows.Forms.Label labelArrowMonths;
		private System.Windows.Forms.GroupBox groupBoxAction;
		private System.Windows.Forms.RadioButton radioButtonActionInclude;
		private System.Windows.Forms.RadioButton radioButtonActionExclude;
		private System.Windows.Forms.RadioButton radioButtonActionHistory;
		private System.Windows.Forms.TextBox textBoxLogsDays;
		private System.Windows.Forms.Label labelLogsDays;
		private System.Windows.Forms.Label labelLogsHistory;
		private System.Windows.Forms.TextBox textBoxArchiveFullPath;
	}
}