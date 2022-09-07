namespace Mir3DClientEditor.FormValueEditors
{
    partial class FPropertyEditor
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
            this.GridEditor = new Mir3DClientEditor.FormValueEditors.PropertyGridEditorControl();
            this.SuspendLayout();
            // 
            // GridEditor
            // 
            this.GridEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridEditor.Location = new System.Drawing.Point(0, 0);
            this.GridEditor.Name = "GridEditor";
            this.GridEditor.Size = new System.Drawing.Size(882, 504);
            this.GridEditor.TabIndex = 0;
            // 
            // FPropertyEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 504);
            this.Controls.Add(this.GridEditor);
            this.Name = "FPropertyEditor";
            this.Text = "FArrayEditor";
            this.ResumeLayout(false);

        }

        #endregion

        private PropertyGridEditorControl GridEditor;
    }
}