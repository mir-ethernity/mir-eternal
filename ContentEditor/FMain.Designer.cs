namespace ContentEditor
{
    partial class FMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMain));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblMouseCoords = new System.Windows.Forms.ToolStripStatusLabel();
            this.ddbZoom = new System.Windows.Forms.ToolStripDropDownButton();
            this.set20ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.set40ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.set60ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.set80ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.set100ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.set120ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.set140ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.set160ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.set180ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblSelectedPoint = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.changeMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(685, 485);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMouseCoords,
            this.ddbZoom,
            this.lblSelectedPoint});
            this.statusStrip1.Location = new System.Drawing.Point(0, 656);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1001, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblMouseCoords
            // 
            this.lblMouseCoords.Name = "lblMouseCoords";
            this.lblMouseCoords.Size = new System.Drawing.Size(51, 17);
            this.lblMouseCoords.Text = "X: 0, Y: 0";
            // 
            // ddbZoom
            // 
            this.ddbZoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ddbZoom.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.set20ToolStripMenuItem,
            this.set40ToolStripMenuItem,
            this.set60ToolStripMenuItem,
            this.set80ToolStripMenuItem,
            this.set100ToolStripMenuItem,
            this.set120ToolStripMenuItem,
            this.set140ToolStripMenuItem,
            this.set160ToolStripMenuItem,
            this.set180ToolStripMenuItem});
            this.ddbZoom.Image = ((System.Drawing.Image)(resources.GetObject("ddbZoom.Image")));
            this.ddbZoom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ddbZoom.Name = "ddbZoom";
            this.ddbZoom.Size = new System.Drawing.Size(86, 20);
            this.ddbZoom.Text = "Zoom: 100%";
            // 
            // set20ToolStripMenuItem
            // 
            this.set20ToolStripMenuItem.Name = "set20ToolStripMenuItem";
            this.set20ToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.set20ToolStripMenuItem.Text = "Set 20%";
            // 
            // set40ToolStripMenuItem
            // 
            this.set40ToolStripMenuItem.Name = "set40ToolStripMenuItem";
            this.set40ToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.set40ToolStripMenuItem.Text = "Set 40%";
            // 
            // set60ToolStripMenuItem
            // 
            this.set60ToolStripMenuItem.Name = "set60ToolStripMenuItem";
            this.set60ToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.set60ToolStripMenuItem.Text = "Set 60%";
            // 
            // set80ToolStripMenuItem
            // 
            this.set80ToolStripMenuItem.Name = "set80ToolStripMenuItem";
            this.set80ToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.set80ToolStripMenuItem.Text = "Set 80%";
            // 
            // set100ToolStripMenuItem
            // 
            this.set100ToolStripMenuItem.Name = "set100ToolStripMenuItem";
            this.set100ToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.set100ToolStripMenuItem.Text = "Set 100%";
            // 
            // set120ToolStripMenuItem
            // 
            this.set120ToolStripMenuItem.Name = "set120ToolStripMenuItem";
            this.set120ToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.set120ToolStripMenuItem.Text = "Set 120%";
            // 
            // set140ToolStripMenuItem
            // 
            this.set140ToolStripMenuItem.Name = "set140ToolStripMenuItem";
            this.set140ToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.set140ToolStripMenuItem.Text = "Set 140%";
            // 
            // set160ToolStripMenuItem
            // 
            this.set160ToolStripMenuItem.Name = "set160ToolStripMenuItem";
            this.set160ToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.set160ToolStripMenuItem.Text = "Set 160%";
            // 
            // set180ToolStripMenuItem
            // 
            this.set180ToolStripMenuItem.Name = "set180ToolStripMenuItem";
            this.set180ToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.set180ToolStripMenuItem.Text = "Set 180%";
            // 
            // lblSelectedPoint
            // 
            this.lblSelectedPoint.Name = "lblSelectedPoint";
            this.lblSelectedPoint.Size = new System.Drawing.Size(100, 17);
            this.lblSelectedPoint.Text = "Selected (X:0, Y:0)";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFile});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1001, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuFile
            // 
            this.MenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeMapToolStripMenuItem});
            this.MenuFile.Name = "MenuFile";
            this.MenuFile.Size = new System.Drawing.Size(43, 20);
            this.MenuFile.Text = "Map";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1001, 632);
            this.panel1.TabIndex = 3;
            // 
            // changeMapToolStripMenuItem
            // 
            this.changeMapToolStripMenuItem.Name = "changeMapToolStripMenuItem";
            this.changeMapToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.changeMapToolStripMenuItem.Text = "Change map";
            // 
            // FMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1001, 678);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FMain";
            this.Text = "Content Editor";
            this.Load += new System.EventHandler(this.FMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private StatusStrip statusStrip1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem MenuFile;
        private ToolStripStatusLabel lblMouseCoords;
        private Panel panel1;
        private ToolStripDropDownButton ddbZoom;
        private ToolStripMenuItem set20ToolStripMenuItem;
        private ToolStripMenuItem set40ToolStripMenuItem;
        private ToolStripMenuItem set60ToolStripMenuItem;
        private ToolStripMenuItem set80ToolStripMenuItem;
        private ToolStripMenuItem set100ToolStripMenuItem;
        private ToolStripMenuItem set120ToolStripMenuItem;
        private ToolStripMenuItem set140ToolStripMenuItem;
        private ToolStripMenuItem set160ToolStripMenuItem;
        private ToolStripMenuItem set180ToolStripMenuItem;
        private ToolStripStatusLabel lblSelectedPoint;
        private ToolStripMenuItem changeMapToolStripMenuItem;
    }
}