namespace Mir3DClientEditor
{
    partial class FSearch
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
            this.SearchText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // SearchText
            // 
            this.SearchText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SearchText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SearchText.Location = new System.Drawing.Point(0, 0);
            this.SearchText.Name = "SearchText";
            this.SearchText.Size = new System.Drawing.Size(305, 22);
            this.SearchText.TabIndex = 0;
            // 
            // FSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 22);
            this.Controls.Add(this.SearchText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FSearch";
            this.Text = "Search";
            this.Load += new System.EventHandler(this.FSearch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox SearchText;
    }
}