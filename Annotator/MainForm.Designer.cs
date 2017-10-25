namespace Annotator
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtImageFolder = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.FBD = new System.Windows.Forms.FolderBrowserDialog();
            this.lblMouseX = new System.Windows.Forms.Label();
            this.lblMouseY = new System.Windows.Forms.Label();
            this.SFD = new System.Windows.Forms.SaveFileDialog();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsSaveAs = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsExport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsOptions = new System.Windows.Forms.ToolStripButton();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Image Folder";
            // 
            // txtImageFolder
            // 
            this.txtImageFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImageFolder.Location = new System.Drawing.Point(15, 44);
            this.txtImageFolder.Name = "txtImageFolder";
            this.txtImageFolder.Size = new System.Drawing.Size(711, 23);
            this.txtImageFolder.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(732, 41);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 29);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpen.Location = new System.Drawing.Point(813, 41);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 29);
            this.btnOpen.TabIndex = 3;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(651, 559);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 29);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevious.Location = new System.Drawing.Point(570, 559);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 29);
            this.btnPrevious.TabIndex = 6;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // lblMouseX
            // 
            this.lblMouseX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMouseX.AutoSize = true;
            this.lblMouseX.Location = new System.Drawing.Point(15, 559);
            this.lblMouseX.Name = "lblMouseX";
            this.lblMouseX.Size = new System.Drawing.Size(0, 16);
            this.lblMouseX.TabIndex = 9;
            // 
            // lblMouseY
            // 
            this.lblMouseY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMouseY.AutoSize = true;
            this.lblMouseY.Location = new System.Drawing.Point(78, 559);
            this.lblMouseY.Name = "lblMouseY";
            this.lblMouseY.Size = new System.Drawing.Size(0, 16);
            this.lblMouseY.TabIndex = 10;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsSave,
            this.toolStripSeparator1,
            this.tsSaveAs,
            this.toolStripSeparator2,
            this.tsExport,
            this.toolStripSeparator3,
            this.tsOptions});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(900, 25);
            this.toolStrip1.TabIndex = 11;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsSave
            // 
            this.tsSave.Image = global::Annotator.Properties.Resources.Save_16x;
            this.tsSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSave.Name = "tsSave";
            this.tsSave.Size = new System.Drawing.Size(51, 22);
            this.tsSave.Text = "&Save";
            this.tsSave.Click += new System.EventHandler(this.tsSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsSaveAs
            // 
            this.tsSaveAs.Image = global::Annotator.Properties.Resources.SaveAs_16x;
            this.tsSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSaveAs.Name = "tsSaveAs";
            this.tsSaveAs.Size = new System.Drawing.Size(76, 22);
            this.tsSaveAs.Text = "Save &As...";
            this.tsSaveAs.Click += new System.EventHandler(this.tsSaveAs_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsExport
            // 
            this.tsExport.Image = global::Annotator.Properties.Resources.Text_16x;
            this.tsExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsExport.Name = "tsExport";
            this.tsExport.Size = new System.Drawing.Size(69, 22);
            this.tsExport.Text = "&Export...";
            this.tsExport.Click += new System.EventHandler(this.tsExport_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsOptions
            // 
            this.tsOptions.Image = global::Annotator.Properties.Resources.Settings_Inverse_16x;
            this.tsOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsOptions.Name = "tsOptions";
            this.tsOptions.Size = new System.Drawing.Size(78, 22);
            this.tsOptions.Text = "&Options...";
            this.tsOptions.Click += new System.EventHandler(this.tsOptions_Click);
            // 
            // picBox
            // 
            this.picBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.picBox.Location = new System.Drawing.Point(15, 74);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(711, 479);
            this.picBox.TabIndex = 8;
            this.picBox.TabStop = false;
            this.picBox.Paint += new System.Windows.Forms.PaintEventHandler(this.picBox_Paint);
            this.picBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picBox_MouseDown);
            this.picBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picBox_MouseMove);
            this.picBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picBox_MouseUp);
            this.picBox.Resize += new System.EventHandler(this.picBox_Resize);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.lblMouseY);
            this.Controls.Add(this.lblMouseX);
            this.Controls.Add(this.picBox);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtImageFolder);
            this.Controls.Add(this.label1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::Annotator.Properties.Settings.Default, "FormLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.KeyPreview = true;
            this.Location = global::Annotator.Properties.Settings.Default.FormLocation;
            this.MinimumSize = new System.Drawing.Size(480, 360);
            this.Name = "MainForm";
            this.Text = "Annotator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtImageFolder;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.FolderBrowserDialog FBD;
        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.Label lblMouseX;
        private System.Windows.Forms.Label lblMouseY;
        private System.Windows.Forms.SaveFileDialog SFD;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsExport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsOptions;
    }
}

