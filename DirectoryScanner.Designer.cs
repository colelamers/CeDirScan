namespace DirectoryScanner
{
    partial class DirectoryScanner
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
            this.btnBrowse = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.ofdBrowse = new System.Windows.Forms.OpenFileDialog();
            this.rbSortByFileType = new System.Windows.Forms.RadioButton();
            this.rbSortByName = new System.Windows.Forms.RadioButton();
            this.rbSortByFilePath = new System.Windows.Forms.RadioButton();
            this.tbDirectory = new System.Windows.Forms.TextBox();
            this.gbRadioButtons = new System.Windows.Forms.GroupBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.sfdSaveFile = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip1.SuspendLayout();
            this.gbRadioButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(377, 10);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(84, 23);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 321);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(471, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslStatus
            // 
            this.tsslStatus.Name = "tsslStatus";
            this.tsslStatus.Size = new System.Drawing.Size(100, 17);
            this.tsslStatus.Text = "Wating For User...";
            // 
            // ofdBrowse
            // 
            this.ofdBrowse.FileName = "C:\\";
            // 
            // rbSortByFileType
            // 
            this.rbSortByFileType.AutoSize = true;
            this.rbSortByFileType.Location = new System.Drawing.Point(6, 42);
            this.rbSortByFileType.Name = "rbSortByFileType";
            this.rbSortByFileType.Size = new System.Drawing.Size(68, 17);
            this.rbSortByFileType.TabIndex = 2;
            this.rbSortByFileType.Text = "File Type";
            this.rbSortByFileType.UseVisualStyleBackColor = true;
            // 
            // rbSortByName
            // 
            this.rbSortByName.AutoSize = true;
            this.rbSortByName.Location = new System.Drawing.Point(6, 65);
            this.rbSortByName.Name = "rbSortByName";
            this.rbSortByName.Size = new System.Drawing.Size(53, 17);
            this.rbSortByName.TabIndex = 3;
            this.rbSortByName.Text = "Name";
            this.rbSortByName.UseVisualStyleBackColor = true;
            // 
            // rbSortByFilePath
            // 
            this.rbSortByFilePath.AutoSize = true;
            this.rbSortByFilePath.Checked = true;
            this.rbSortByFilePath.Location = new System.Drawing.Point(6, 19);
            this.rbSortByFilePath.Name = "rbSortByFilePath";
            this.rbSortByFilePath.Size = new System.Drawing.Size(66, 17);
            this.rbSortByFilePath.TabIndex = 4;
            this.rbSortByFilePath.TabStop = true;
            this.rbSortByFilePath.Text = "File Path";
            this.rbSortByFilePath.UseVisualStyleBackColor = true;
            // 
            // tbDirectory
            // 
            this.tbDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDirectory.Location = new System.Drawing.Point(12, 12);
            this.tbDirectory.Name = "tbDirectory";
            this.tbDirectory.Size = new System.Drawing.Size(359, 20);
            this.tbDirectory.TabIndex = 5;
            // 
            // gbRadioButtons
            // 
            this.gbRadioButtons.Controls.Add(this.rbSortByName);
            this.gbRadioButtons.Controls.Add(this.rbSortByFileType);
            this.gbRadioButtons.Controls.Add(this.rbSortByFilePath);
            this.gbRadioButtons.Location = new System.Drawing.Point(12, 38);
            this.gbRadioButtons.Name = "gbRadioButtons";
            this.gbRadioButtons.Size = new System.Drawing.Size(200, 97);
            this.gbRadioButtons.TabIndex = 6;
            this.gbRadioButtons.TabStop = false;
            this.gbRadioButtons.Text = "Sorting Options";
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(375, 39);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(84, 23);
            this.btnGo.TabIndex = 7;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // DirectoryScanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 343);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.gbRadioButtons);
            this.Controls.Add(this.tbDirectory);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnBrowse);
            this.Name = "DirectoryScanner";
            this.Text = "Directory Scanner";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.gbRadioButtons.ResumeLayout(false);
            this.gbRadioButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslStatus;
        private System.Windows.Forms.OpenFileDialog ofdBrowse;
        private System.Windows.Forms.RadioButton rbSortByFileType;
        private System.Windows.Forms.RadioButton rbSortByName;
        private System.Windows.Forms.RadioButton rbSortByFilePath;
        private System.Windows.Forms.TextBox tbDirectory;
        private System.Windows.Forms.GroupBox gbRadioButtons;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.SaveFileDialog sfdSaveFile;
    }
}

