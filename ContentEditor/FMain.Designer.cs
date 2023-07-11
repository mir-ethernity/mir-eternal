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
            pictureBox1 = new PictureBox();
            statusStrip1 = new StatusStrip();
            lblMouseCoords = new ToolStripStatusLabel();
            ddbZoom = new ToolStripDropDownButton();
            set20ToolStripMenuItem = new ToolStripMenuItem();
            set40ToolStripMenuItem = new ToolStripMenuItem();
            set60ToolStripMenuItem = new ToolStripMenuItem();
            set80ToolStripMenuItem = new ToolStripMenuItem();
            set100ToolStripMenuItem = new ToolStripMenuItem();
            set120ToolStripMenuItem = new ToolStripMenuItem();
            set140ToolStripMenuItem = new ToolStripMenuItem();
            set160ToolStripMenuItem = new ToolStripMenuItem();
            set180ToolStripMenuItem = new ToolStripMenuItem();
            lblSelectedPoint = new ToolStripStatusLabel();
            MapInfoLabel = new ToolStripStatusLabel();
            menuStrip1 = new MenuStrip();
            MenuFile = new ToolStripMenuItem();
            changeMapToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            statusStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ActiveCaptionText;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(400, 400);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = SystemColors.ActiveCaption;
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblMouseCoords, ddbZoom, lblSelectedPoint, MapInfoLabel });
            statusStrip1.Location = new Point(0, 425);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(405, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblMouseCoords
            // 
            lblMouseCoords.Name = "lblMouseCoords";
            lblMouseCoords.Size = new Size(51, 17);
            lblMouseCoords.Text = "X: 0, Y: 0";
            // 
            // ddbZoom
            // 
            ddbZoom.DisplayStyle = ToolStripItemDisplayStyle.Text;
            ddbZoom.DropDownItems.AddRange(new ToolStripItem[] { set20ToolStripMenuItem, set40ToolStripMenuItem, set60ToolStripMenuItem, set80ToolStripMenuItem, set100ToolStripMenuItem, set120ToolStripMenuItem, set140ToolStripMenuItem, set160ToolStripMenuItem, set180ToolStripMenuItem });
            ddbZoom.Image = (Image)resources.GetObject("ddbZoom.Image");
            ddbZoom.ImageTransparentColor = Color.Magenta;
            ddbZoom.Name = "ddbZoom";
            ddbZoom.Size = new Size(86, 20);
            ddbZoom.Text = "Zoom: 100%";
            // 
            // set20ToolStripMenuItem
            // 
            set20ToolStripMenuItem.Name = "set20ToolStripMenuItem";
            set20ToolStripMenuItem.Size = new Size(121, 22);
            set20ToolStripMenuItem.Text = "Set 20%";
            // 
            // set40ToolStripMenuItem
            // 
            set40ToolStripMenuItem.Name = "set40ToolStripMenuItem";
            set40ToolStripMenuItem.Size = new Size(121, 22);
            set40ToolStripMenuItem.Text = "Set 40%";
            // 
            // set60ToolStripMenuItem
            // 
            set60ToolStripMenuItem.Name = "set60ToolStripMenuItem";
            set60ToolStripMenuItem.Size = new Size(121, 22);
            set60ToolStripMenuItem.Text = "Set 60%";
            // 
            // set80ToolStripMenuItem
            // 
            set80ToolStripMenuItem.Name = "set80ToolStripMenuItem";
            set80ToolStripMenuItem.Size = new Size(121, 22);
            set80ToolStripMenuItem.Text = "Set 80%";
            // 
            // set100ToolStripMenuItem
            // 
            set100ToolStripMenuItem.Name = "set100ToolStripMenuItem";
            set100ToolStripMenuItem.Size = new Size(121, 22);
            set100ToolStripMenuItem.Text = "Set 100%";
            // 
            // set120ToolStripMenuItem
            // 
            set120ToolStripMenuItem.Name = "set120ToolStripMenuItem";
            set120ToolStripMenuItem.Size = new Size(121, 22);
            set120ToolStripMenuItem.Text = "Set 120%";
            // 
            // set140ToolStripMenuItem
            // 
            set140ToolStripMenuItem.Name = "set140ToolStripMenuItem";
            set140ToolStripMenuItem.Size = new Size(121, 22);
            set140ToolStripMenuItem.Text = "Set 140%";
            // 
            // set160ToolStripMenuItem
            // 
            set160ToolStripMenuItem.Name = "set160ToolStripMenuItem";
            set160ToolStripMenuItem.Size = new Size(121, 22);
            set160ToolStripMenuItem.Text = "Set 160%";
            // 
            // set180ToolStripMenuItem
            // 
            set180ToolStripMenuItem.Name = "set180ToolStripMenuItem";
            set180ToolStripMenuItem.Size = new Size(121, 22);
            set180ToolStripMenuItem.Text = "Set 180%";
            // 
            // lblSelectedPoint
            // 
            lblSelectedPoint.Name = "lblSelectedPoint";
            lblSelectedPoint.Size = new Size(100, 17);
            lblSelectedPoint.Text = "Selected (X:0, Y:0)";
            // 
            // MapInfoLabel
            // 
            MapInfoLabel.Name = "MapInfoLabel";
            MapInfoLabel.Size = new Size(80, 17);
            MapInfoLabel.Text = "MapInfoLabel";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { MenuFile });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(405, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // MenuFile
            // 
            MenuFile.DropDownItems.AddRange(new ToolStripItem[] { changeMapToolStripMenuItem });
            MenuFile.Name = "MenuFile";
            MenuFile.Size = new Size(43, 20);
            MenuFile.Text = "Map";
            // 
            // changeMapToolStripMenuItem
            // 
            changeMapToolStripMenuItem.Name = "changeMapToolStripMenuItem";
            changeMapToolStripMenuItem.Size = new Size(142, 22);
            changeMapToolStripMenuItem.Text = "Change map";
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 24);
            panel1.Name = "panel1";
            panel1.Size = new Size(405, 401);
            panel1.TabIndex = 3;
            // 
            // FMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(405, 447);
            Controls.Add(panel1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FMain";
            Text = "Content Editor";
            Load += FMain_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private ToolStripStatusLabel MapInfoLabel;
    }
}