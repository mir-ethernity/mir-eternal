namespace Mir3DClientEditor.Dialogs
{
    partial class CustomMessageBox
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
            MessageLabel = new Label();
            splitContainer1 = new SplitContainer();
            ButtonsPanel = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // MessageLabel
            // 
            MessageLabel.Dock = DockStyle.Fill;
            MessageLabel.Location = new Point(0, 0);
            MessageLabel.Name = "MessageLabel";
            MessageLabel.Size = new Size(429, 55);
            MessageLabel.TabIndex = 0;
            MessageLabel.Text = "MessageLabel";
            MessageLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel2;
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(MessageLabel);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(ButtonsPanel);
            splitContainer1.Size = new Size(429, 104);
            splitContainer1.SplitterDistance = 55;
            splitContainer1.TabIndex = 1;
            // 
            // ButtonsPanel
            // 
            ButtonsPanel.Dock = DockStyle.Fill;
            ButtonsPanel.Location = new Point(0, 0);
            ButtonsPanel.Name = "ButtonsPanel";
            ButtonsPanel.Size = new Size(429, 45);
            ButtonsPanel.TabIndex = 0;
            // 
            // CustomMessageBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(429, 104);
            Controls.Add(splitContainer1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "CustomMessageBox";
            Text = "CustomMessageBox";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label MessageLabel;
        private SplitContainer splitContainer1;
        private FlowLayoutPanel ButtonsPanel;
    }
}