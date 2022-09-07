namespace Mir3DClientEditor
{
    partial class FSyncClientTexts
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
            this.TextLatestClientPath = new System.Windows.Forms.TextBox();
            this.ButtonSelectLatestClientPath = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ButtonSelectOldClientPath = new System.Windows.Forms.Button();
            this.TextOldClientPath = new System.Windows.Forms.TextBox();
            this.ButtonSyncronizeTexts = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TextLatestClientPath
            // 
            this.TextLatestClientPath.Location = new System.Drawing.Point(12, 27);
            this.TextLatestClientPath.Name = "TextLatestClientPath";
            this.TextLatestClientPath.Size = new System.Drawing.Size(374, 23);
            this.TextLatestClientPath.TabIndex = 0;
            // 
            // ButtonSelectLatestClientPath
            // 
            this.ButtonSelectLatestClientPath.Location = new System.Drawing.Point(392, 27);
            this.ButtonSelectLatestClientPath.Name = "ButtonSelectLatestClientPath";
            this.ButtonSelectLatestClientPath.Size = new System.Drawing.Size(75, 23);
            this.ButtonSelectLatestClientPath.TabIndex = 1;
            this.ButtonSelectLatestClientPath.Text = "Select Folder";
            this.ButtonSelectLatestClientPath.UseVisualStyleBackColor = true;
            this.ButtonSelectLatestClientPath.Click += new System.EventHandler(this.ButtonSelectLatestClientPath_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Latest Client Path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Old Client Path";
            // 
            // ButtonSelectOldClientPath
            // 
            this.ButtonSelectOldClientPath.Location = new System.Drawing.Point(392, 84);
            this.ButtonSelectOldClientPath.Name = "ButtonSelectOldClientPath";
            this.ButtonSelectOldClientPath.Size = new System.Drawing.Size(75, 23);
            this.ButtonSelectOldClientPath.TabIndex = 4;
            this.ButtonSelectOldClientPath.Text = "Select Folder";
            this.ButtonSelectOldClientPath.UseVisualStyleBackColor = true;
            this.ButtonSelectOldClientPath.Click += new System.EventHandler(this.ButtonSelectOldClientPath_Click);
            // 
            // TextOldClientPath
            // 
            this.TextOldClientPath.Location = new System.Drawing.Point(12, 84);
            this.TextOldClientPath.Name = "TextOldClientPath";
            this.TextOldClientPath.Size = new System.Drawing.Size(374, 23);
            this.TextOldClientPath.TabIndex = 3;
            // 
            // ButtonSyncronizeTexts
            // 
            this.ButtonSyncronizeTexts.Location = new System.Drawing.Point(12, 131);
            this.ButtonSyncronizeTexts.Name = "ButtonSyncronizeTexts";
            this.ButtonSyncronizeTexts.Size = new System.Drawing.Size(455, 37);
            this.ButtonSyncronizeTexts.TabIndex = 6;
            this.ButtonSyncronizeTexts.Text = "Copy texts";
            this.ButtonSyncronizeTexts.UseVisualStyleBackColor = true;
            this.ButtonSyncronizeTexts.Click += new System.EventHandler(this.ButtonSyncronizeTexts_Click);
            // 
            // FSyncClientTexts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 180);
            this.Controls.Add(this.ButtonSyncronizeTexts);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ButtonSelectOldClientPath);
            this.Controls.Add(this.TextOldClientPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ButtonSelectLatestClientPath);
            this.Controls.Add(this.TextLatestClientPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FSyncClientTexts";
            this.Text = "FSyncClientTexts";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox TextLatestClientPath;
        private Button ButtonSelectLatestClientPath;
        private Label label1;
        private Label label2;
        private Button ButtonSelectOldClientPath;
        private TextBox TextOldClientPath;
        private Button ButtonSyncronizeTexts;
    }
}