namespace Mir3DClientEditor.Dialogs
{
    partial class FImageViewerDialog
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
            this.MainLayout = new System.Windows.Forms.SplitContainer();
            this.ActiveImage = new System.Windows.Forms.PictureBox();
            this.ReplaceImageButton = new System.Windows.Forms.Button();
            this.BtnNextMipmap = new System.Windows.Forms.Button();
            this.LblCurrentImage = new System.Windows.Forms.Label();
            this.BtnPrevMipmap = new System.Windows.Forms.Button();
            this.ButtonExportImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MainLayout)).BeginInit();
            this.MainLayout.Panel1.SuspendLayout();
            this.MainLayout.Panel2.SuspendLayout();
            this.MainLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ActiveImage)).BeginInit();
            this.SuspendLayout();
            // 
            // MainLayout
            // 
            this.MainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainLayout.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.MainLayout.Location = new System.Drawing.Point(0, 0);
            this.MainLayout.Name = "MainLayout";
            this.MainLayout.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MainLayout.Panel1
            // 
            this.MainLayout.Panel1.AutoScroll = true;
            this.MainLayout.Panel1.Controls.Add(this.ActiveImage);
            // 
            // MainLayout.Panel2
            // 
            this.MainLayout.Panel2.Controls.Add(this.ButtonExportImage);
            this.MainLayout.Panel2.Controls.Add(this.ReplaceImageButton);
            this.MainLayout.Panel2.Controls.Add(this.BtnNextMipmap);
            this.MainLayout.Panel2.Controls.Add(this.LblCurrentImage);
            this.MainLayout.Panel2.Controls.Add(this.BtnPrevMipmap);
            this.MainLayout.Size = new System.Drawing.Size(727, 482);
            this.MainLayout.SplitterDistance = 439;
            this.MainLayout.TabIndex = 0;
            // 
            // ActiveImage
            // 
            this.ActiveImage.Location = new System.Drawing.Point(0, 0);
            this.ActiveImage.Name = "ActiveImage";
            this.ActiveImage.Size = new System.Drawing.Size(248, 168);
            this.ActiveImage.TabIndex = 0;
            this.ActiveImage.TabStop = false;
            // 
            // ReplaceImageButton
            // 
            this.ReplaceImageButton.Location = new System.Drawing.Point(118, 7);
            this.ReplaceImageButton.Name = "ReplaceImageButton";
            this.ReplaceImageButton.Size = new System.Drawing.Size(108, 23);
            this.ReplaceImageButton.TabIndex = 3;
            this.ReplaceImageButton.Text = "Replace Image";
            this.ReplaceImageButton.UseVisualStyleBackColor = true;
            this.ReplaceImageButton.Click += new System.EventHandler(this.ReplaceImageButton_Click);
            // 
            // BtnNextMipmap
            // 
            this.BtnNextMipmap.Location = new System.Drawing.Point(80, 7);
            this.BtnNextMipmap.Name = "BtnNextMipmap";
            this.BtnNextMipmap.Size = new System.Drawing.Size(32, 23);
            this.BtnNextMipmap.TabIndex = 2;
            this.BtnNextMipmap.Text = ">";
            this.BtnNextMipmap.UseVisualStyleBackColor = true;
            this.BtnNextMipmap.Click += new System.EventHandler(this.BtnNextMipmap_Click);
            // 
            // LblCurrentImage
            // 
            this.LblCurrentImage.AutoSize = true;
            this.LblCurrentImage.Location = new System.Drawing.Point(50, 11);
            this.LblCurrentImage.Name = "LblCurrentImage";
            this.LblCurrentImage.Size = new System.Drawing.Size(24, 15);
            this.LblCurrentImage.TabIndex = 1;
            this.LblCurrentImage.Text = "1/1";
            // 
            // BtnPrevMipmap
            // 
            this.BtnPrevMipmap.Location = new System.Drawing.Point(12, 7);
            this.BtnPrevMipmap.Name = "BtnPrevMipmap";
            this.BtnPrevMipmap.Size = new System.Drawing.Size(32, 23);
            this.BtnPrevMipmap.TabIndex = 0;
            this.BtnPrevMipmap.Text = "<";
            this.BtnPrevMipmap.UseVisualStyleBackColor = true;
            this.BtnPrevMipmap.Click += new System.EventHandler(this.BtnPrevMipmap_Click);
            // 
            // ButtonExportImage
            // 
            this.ButtonExportImage.Location = new System.Drawing.Point(232, 7);
            this.ButtonExportImage.Name = "ButtonExportImage";
            this.ButtonExportImage.Size = new System.Drawing.Size(108, 23);
            this.ButtonExportImage.TabIndex = 4;
            this.ButtonExportImage.Text = "Export Image";
            this.ButtonExportImage.UseVisualStyleBackColor = true;
            this.ButtonExportImage.Click += new System.EventHandler(this.ButtonExportImage_Click);
            // 
            // FImageViewerDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 482);
            this.Controls.Add(this.MainLayout);
            this.Name = "FImageViewerDialog";
            this.Text = "FImageViewerDialog";
            this.MainLayout.Panel1.ResumeLayout(false);
            this.MainLayout.Panel2.ResumeLayout(false);
            this.MainLayout.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainLayout)).EndInit();
            this.MainLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ActiveImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer MainLayout;
        private PictureBox ActiveImage;
        private Button button1;
        private Button BtnPrevMipmap;
        private Button BtnNextMipmap;
        private Label LblCurrentImage;
        private Button ReplaceImageButton;
        private Button ButtonExportImage;
    }
}