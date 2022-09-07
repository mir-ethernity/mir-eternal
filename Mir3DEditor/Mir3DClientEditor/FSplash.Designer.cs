namespace Mir3DClientEditor
{
    partial class FSplash
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
            this.OpenPaypal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(37, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(764, 96);
            this.label1.TabIndex = 0;
            this.label1.Text = "This application is totally free. \r\nIf you liked it, please, do not forget to mak" +
    "e a small contribution \r\nto guarantee the continuous maintenance.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OpenPaypal
            // 
            this.OpenPaypal.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.OpenPaypal.Location = new System.Drawing.Point(285, 151);
            this.OpenPaypal.Name = "OpenPaypal";
            this.OpenPaypal.Size = new System.Drawing.Size(288, 67);
            this.OpenPaypal.TabIndex = 1;
            this.OpenPaypal.Text = "Donate from PayPal";
            this.OpenPaypal.UseVisualStyleBackColor = true;
            this.OpenPaypal.Click += new System.EventHandler(this.OpenPaypal_Click);
            // 
            // FSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 249);
            this.Controls.Add(this.OpenPaypal);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FSplash";
            this.Text = "Mir3D Client Editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button OpenPaypal;
    }
}