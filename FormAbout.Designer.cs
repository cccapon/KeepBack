namespace KeepBack
{
	partial class FormAbout
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if( disposing && (components != null) )
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.buttonOk = new System.Windows.Forms.Button();
			this.labelTitle = new System.Windows.Forms.Label();
			this.labelVersion = new System.Windows.Forms.Label();
			this.labelCopyright = new System.Windows.Forms.Label();
			this.labelSiteTag = new System.Windows.Forms.Label();
			this.tableLayoutPanelInfo = new System.Windows.Forms.TableLayoutPanel();
			this.linkLabelSite1 = new System.Windows.Forms.LinkLabel();
			this.labelCopyrightTag = new System.Windows.Forms.Label();
			this.labelVersionTag = new System.Windows.Forms.Label();
			this.labelProductTag = new System.Windows.Forms.Label();
			this.labelProduct = new System.Windows.Forms.Label();
			this.labelDescription = new System.Windows.Forms.Label();
			this.tableLayoutPanelInfo.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonOk
			// 
			this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOk.Location = new System.Drawing.Point(295, 153);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 23);
			this.buttonOk.TabIndex = 0;
			this.buttonOk.Text = "OK";
			this.buttonOk.UseVisualStyleBackColor = true;
			// 
			// labelTitle
			// 
			this.labelTitle.AutoSize = true;
			this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelTitle.Location = new System.Drawing.Point(17, 9);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(53, 25);
			this.labelTitle.TabIndex = 1;
			this.labelTitle.Text = "Title";
			// 
			// labelVersion
			// 
			this.labelVersion.AutoSize = true;
			this.labelVersion.Location = new System.Drawing.Point(78, 20);
			this.labelVersion.Name = "labelVersion";
			this.labelVersion.Size = new System.Drawing.Size(41, 13);
			this.labelVersion.TabIndex = 2;
			this.labelVersion.Text = "version";
			// 
			// labelCopyright
			// 
			this.labelCopyright.AutoSize = true;
			this.labelCopyright.Location = new System.Drawing.Point(78, 40);
			this.labelCopyright.Name = "labelCopyright";
			this.labelCopyright.Size = new System.Drawing.Size(50, 13);
			this.labelCopyright.TabIndex = 3;
			this.labelCopyright.Text = "copyright";
			// 
			// labelSiteTag
			// 
			this.labelSiteTag.AutoSize = true;
			this.labelSiteTag.Location = new System.Drawing.Point(3, 60);
			this.labelSiteTag.Name = "labelSiteTag";
			this.labelSiteTag.Size = new System.Drawing.Size(28, 13);
			this.labelSiteTag.TabIndex = 4;
			this.labelSiteTag.Text = "Site:";
			// 
			// tableLayoutPanelInfo
			// 
			this.tableLayoutPanelInfo.ColumnCount = 2;
			this.tableLayoutPanelInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.21212F));
			this.tableLayoutPanelInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.78788F));
			this.tableLayoutPanelInfo.Controls.Add(this.labelProductTag, 0, 0);
			this.tableLayoutPanelInfo.Controls.Add(this.labelProduct, 1, 0);
			this.tableLayoutPanelInfo.Controls.Add(this.labelVersionTag, 0, 1);
			this.tableLayoutPanelInfo.Controls.Add(this.labelVersion, 1, 1);
			this.tableLayoutPanelInfo.Controls.Add(this.labelCopyrightTag, 0, 2);
			this.tableLayoutPanelInfo.Controls.Add(this.labelCopyright, 1, 2);
			this.tableLayoutPanelInfo.Controls.Add(this.labelSiteTag, 0, 3);
			this.tableLayoutPanelInfo.Controls.Add(this.linkLabelSite1, 1, 3);
			this.tableLayoutPanelInfo.Location = new System.Drawing.Point(16, 62);
			this.tableLayoutPanelInfo.Name = "tableLayoutPanelInfo";
			this.tableLayoutPanelInfo.RowCount = 4;
			this.tableLayoutPanelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanelInfo.Size = new System.Drawing.Size(354, 85);
			this.tableLayoutPanelInfo.TabIndex = 5;
			// 
			// linkLabelSite1
			// 
			this.linkLabelSite1.AutoSize = true;
			this.linkLabelSite1.Location = new System.Drawing.Point(78, 60);
			this.linkLabelSite1.Name = "linkLabelSite1";
			this.linkLabelSite1.Size = new System.Drawing.Size(168, 13);
			this.linkLabelSite1.TabIndex = 7;
			this.linkLabelSite1.TabStop = true;
			this.linkLabelSite1.Text = "http://keepback.sourceforge.net/";
			this.linkLabelSite1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelSite_LinkClicked);
			// 
			// labelCopyrightTag
			// 
			this.labelCopyrightTag.AutoSize = true;
			this.labelCopyrightTag.Location = new System.Drawing.Point(3, 40);
			this.labelCopyrightTag.Name = "labelCopyrightTag";
			this.labelCopyrightTag.Size = new System.Drawing.Size(54, 13);
			this.labelCopyrightTag.TabIndex = 6;
			this.labelCopyrightTag.Text = "Copyright:";
			// 
			// labelVersionTag
			// 
			this.labelVersionTag.AutoSize = true;
			this.labelVersionTag.Location = new System.Drawing.Point(3, 20);
			this.labelVersionTag.Name = "labelVersionTag";
			this.labelVersionTag.Size = new System.Drawing.Size(45, 13);
			this.labelVersionTag.TabIndex = 5;
			this.labelVersionTag.Text = "Version:";
			// 
			// labelProductTag
			// 
			this.labelProductTag.AutoSize = true;
			this.labelProductTag.Location = new System.Drawing.Point(3, 0);
			this.labelProductTag.Name = "labelProductTag";
			this.labelProductTag.Size = new System.Drawing.Size(47, 13);
			this.labelProductTag.TabIndex = 9;
			this.labelProductTag.Text = "Product:";
			// 
			// labelProduct
			// 
			this.labelProduct.AutoSize = true;
			this.labelProduct.Location = new System.Drawing.Point(78, 0);
			this.labelProduct.Name = "labelProduct";
			this.labelProduct.Size = new System.Drawing.Size(43, 13);
			this.labelProduct.TabIndex = 10;
			this.labelProduct.Text = "product";
			// 
			// labelDescription
			// 
			this.labelDescription.AutoSize = true;
			this.labelDescription.Location = new System.Drawing.Point(19, 34);
			this.labelDescription.Name = "labelDescription";
			this.labelDescription.Size = new System.Drawing.Size(58, 13);
			this.labelDescription.TabIndex = 11;
			this.labelDescription.Text = "description";
			// 
			// FormAbout
			// 
			this.AcceptButton = this.buttonOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(382, 185);
			this.Controls.Add(this.tableLayoutPanelInfo);
			this.Controls.Add(this.labelTitle);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.labelDescription);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormAbout";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "About";
			this.tableLayoutPanelInfo.ResumeLayout(false);
			this.tableLayoutPanelInfo.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.Label labelVersion;
		private System.Windows.Forms.Label labelCopyright;
		private System.Windows.Forms.Label labelSiteTag;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelInfo;
		private System.Windows.Forms.Label labelCopyrightTag;
		private System.Windows.Forms.Label labelVersionTag;
		private System.Windows.Forms.LinkLabel linkLabelSite1;
		private System.Windows.Forms.Label labelProductTag;
		private System.Windows.Forms.Label labelProduct;
		private System.Windows.Forms.Label labelDescription;
	}
}