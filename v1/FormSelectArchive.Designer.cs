namespace KeepBack.v1
{
	partial class FormSelectArchive
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
			this.listBoxArchive = new System.Windows.Forms.ListBox();
			this.buttonContinue = new System.Windows.Forms.Button();
			this.labelInformation = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// listBoxArchive
			// 
			this.listBoxArchive.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBoxArchive.FormattingEnabled = true;
			this.listBoxArchive.ItemHeight = 16;
			this.listBoxArchive.Location = new System.Drawing.Point(13, 13);
			this.listBoxArchive.Name = "listBoxArchive";
			this.listBoxArchive.Size = new System.Drawing.Size(433, 100);
			this.listBoxArchive.TabIndex = 0;
			// 
			// buttonContinue
			// 
			this.buttonContinue.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonContinue.Location = new System.Drawing.Point(305, 187);
			this.buttonContinue.Name = "buttonContinue";
			this.buttonContinue.Size = new System.Drawing.Size(141, 23);
			this.buttonContinue.TabIndex = 1;
			this.buttonContinue.Text = "Continue";
			this.buttonContinue.UseVisualStyleBackColor = true;
			// 
			// labelInformation
			// 
			this.labelInformation.AutoSize = true;
			this.labelInformation.Location = new System.Drawing.Point(12, 116);
			this.labelInformation.Name = "labelInformation";
			this.labelInformation.Size = new System.Drawing.Size(426, 68);
			this.labelInformation.TabIndex = 2;
			this.labelInformation.Text = "Your backup set is being upgraded from an older version.\r\nNewer versions do not s" +
    "upport more than one archive per backup.\r\n\r\nPlease choose an archive to work wit" +
    "h.";
			// 
			// FormSelectArchive
			// 
			this.AcceptButton = this.buttonContinue;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(458, 221);
			this.ControlBox = false;
			this.Controls.Add(this.labelInformation);
			this.Controls.Add(this.buttonContinue);
			this.Controls.Add(this.listBoxArchive);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormSelectArchive";
			this.Text = "Select Archive";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox listBoxArchive;
		private System.Windows.Forms.Button buttonContinue;
		private System.Windows.Forms.Label labelInformation;
	}
}