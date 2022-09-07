namespace Mir3DClientEditor
{
    partial class FMainEditor
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
            this.MainEditor = new Mir3DClientEditor.MainEditorControl();
            this.SuspendLayout();
            // 
            // MainEditor
            // 
            this.MainEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainEditor.Location = new System.Drawing.Point(0, 0);
            this.MainEditor.Name = "MainEditor";
            this.MainEditor.Size = new System.Drawing.Size(800, 450);
            this.MainEditor.TabIndex = 0;
            // 
            // FMainEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MainEditor);
            this.Name = "FMainEditor";
            this.Text = "FMainEditor";
            this.ResumeLayout(false);

        }

        #endregion

        private MainEditorControl MainEditor;
    }
}