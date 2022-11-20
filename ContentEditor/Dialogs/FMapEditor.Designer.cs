namespace ContentEditor
{
    partial class FMapEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMapEditor));
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.uiSplitContainer1 = new Sunny.UI.UISplitContainer();
            this.TerrainAttributes = new Sunny.UI.UICheckBoxGroup();
            this.MapAttrStallArea = new Sunny.UI.UICheckBox();
            this.MapAttrFreeZone = new Sunny.UI.UICheckBox();
            this.MapAttrSafeZone = new Sunny.UI.UICheckBox();
            this.groupLayers = new Sunny.UI.UICheckBoxGroup();
            this.LayerGates = new Sunny.UI.UICheckBox();
            this.LayerGuards = new Sunny.UI.UICheckBox();
            this.LayerAreas = new Sunny.UI.UICheckBox();
            this.LayerSpawns = new Sunny.UI.UICheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiSplitContainer1)).BeginInit();
            this.uiSplitContainer1.Panel1.SuspendLayout();
            this.uiSplitContainer1.Panel2.SuspendLayout();
            this.uiSplitContainer1.SuspendLayout();
            this.TerrainAttributes.SuspendLayout();
            this.groupLayers.SuspendLayout();
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
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.uiSplitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1001, 656);
            this.panel1.TabIndex = 3;
            // 
            // uiSplitContainer1
            // 
            this.uiSplitContainer1.CollapsePanel = Sunny.UI.UISplitContainer.UICollapsePanel.None;
            this.uiSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiSplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.uiSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.uiSplitContainer1.MinimumSize = new System.Drawing.Size(20, 20);
            this.uiSplitContainer1.Name = "uiSplitContainer1";
            // 
            // uiSplitContainer1.Panel1
            // 
            this.uiSplitContainer1.Panel1.Controls.Add(this.TerrainAttributes);
            this.uiSplitContainer1.Panel1.Controls.Add(this.groupLayers);
            // 
            // uiSplitContainer1.Panel2
            // 
            this.uiSplitContainer1.Panel2.AutoScroll = true;
            this.uiSplitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.uiSplitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.uiSplitContainer1.Size = new System.Drawing.Size(1001, 656);
            this.uiSplitContainer1.SplitterDistance = 224;
            this.uiSplitContainer1.SplitterWidth = 11;
            this.uiSplitContainer1.TabIndex = 1;
            this.uiSplitContainer1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // TerrainAttributes
            // 
            this.TerrainAttributes.Controls.Add(this.MapAttrStallArea);
            this.TerrainAttributes.Controls.Add(this.MapAttrFreeZone);
            this.TerrainAttributes.Controls.Add(this.MapAttrSafeZone);
            this.TerrainAttributes.FillColor = System.Drawing.SystemColors.WindowFrame;
            this.TerrainAttributes.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TerrainAttributes.Location = new System.Drawing.Point(13, 14);
            this.TerrainAttributes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TerrainAttributes.MinimumSize = new System.Drawing.Size(1, 1);
            this.TerrainAttributes.Name = "TerrainAttributes";
            this.TerrainAttributes.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.TerrainAttributes.SelectedIndexes = ((System.Collections.Generic.List<int>)(resources.GetObject("TerrainAttributes.SelectedIndexes")));
            this.TerrainAttributes.Size = new System.Drawing.Size(196, 115);
            this.TerrainAttributes.Style = Sunny.UI.UIStyle.Custom;
            this.TerrainAttributes.TabIndex = 2;
            this.TerrainAttributes.Text = "Terrain Attributes";
            this.TerrainAttributes.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.TerrainAttributes.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // MapAttrStallArea
            // 
            this.MapAttrStallArea.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MapAttrStallArea.Location = new System.Drawing.Point(6, 73);
            this.MapAttrStallArea.MinimumSize = new System.Drawing.Size(1, 1);
            this.MapAttrStallArea.Name = "MapAttrStallArea";
            this.MapAttrStallArea.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.MapAttrStallArea.Size = new System.Drawing.Size(174, 29);
            this.MapAttrStallArea.Style = Sunny.UI.UIStyle.Custom;
            this.MapAttrStallArea.TabIndex = 2;
            this.MapAttrStallArea.Text = "Stall Area";
            this.MapAttrStallArea.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // MapAttrFreeZone
            // 
            this.MapAttrFreeZone.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MapAttrFreeZone.Location = new System.Drawing.Point(6, 49);
            this.MapAttrFreeZone.MinimumSize = new System.Drawing.Size(1, 1);
            this.MapAttrFreeZone.Name = "MapAttrFreeZone";
            this.MapAttrFreeZone.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.MapAttrFreeZone.Size = new System.Drawing.Size(174, 29);
            this.MapAttrFreeZone.Style = Sunny.UI.UIStyle.Custom;
            this.MapAttrFreeZone.TabIndex = 1;
            this.MapAttrFreeZone.Text = "Free Zone";
            this.MapAttrFreeZone.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // MapAttrSafeZone
            // 
            this.MapAttrSafeZone.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MapAttrSafeZone.Location = new System.Drawing.Point(6, 26);
            this.MapAttrSafeZone.MinimumSize = new System.Drawing.Size(1, 1);
            this.MapAttrSafeZone.Name = "MapAttrSafeZone";
            this.MapAttrSafeZone.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.MapAttrSafeZone.Size = new System.Drawing.Size(174, 29);
            this.MapAttrSafeZone.Style = Sunny.UI.UIStyle.Custom;
            this.MapAttrSafeZone.TabIndex = 0;
            this.MapAttrSafeZone.Text = "Safe Zone";
            this.MapAttrSafeZone.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // groupLayers
            // 
            this.groupLayers.Controls.Add(this.LayerSpawns);
            this.groupLayers.Controls.Add(this.LayerGates);
            this.groupLayers.Controls.Add(this.LayerGuards);
            this.groupLayers.Controls.Add(this.LayerAreas);
            this.groupLayers.FillColor = System.Drawing.SystemColors.WindowFrame;
            this.groupLayers.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupLayers.Location = new System.Drawing.Point(13, 139);
            this.groupLayers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupLayers.MinimumSize = new System.Drawing.Size(1, 1);
            this.groupLayers.Name = "groupLayers";
            this.groupLayers.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.groupLayers.SelectedIndexes = ((System.Collections.Generic.List<int>)(resources.GetObject("groupLayers.SelectedIndexes")));
            this.groupLayers.Size = new System.Drawing.Size(196, 144);
            this.groupLayers.Style = Sunny.UI.UIStyle.Custom;
            this.groupLayers.TabIndex = 0;
            this.groupLayers.Text = "Layers";
            this.groupLayers.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.groupLayers.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // LayerGates
            // 
            this.LayerGates.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LayerGates.Location = new System.Drawing.Point(6, 74);
            this.LayerGates.MinimumSize = new System.Drawing.Size(1, 1);
            this.LayerGates.Name = "LayerGates";
            this.LayerGates.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.LayerGates.Size = new System.Drawing.Size(174, 29);
            this.LayerGates.Style = Sunny.UI.UIStyle.Custom;
            this.LayerGates.TabIndex = 2;
            this.LayerGates.Text = "Gates";
            this.LayerGates.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // LayerGuards
            // 
            this.LayerGuards.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LayerGuards.Location = new System.Drawing.Point(6, 49);
            this.LayerGuards.MinimumSize = new System.Drawing.Size(1, 1);
            this.LayerGuards.Name = "LayerGuards";
            this.LayerGuards.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.LayerGuards.Size = new System.Drawing.Size(174, 29);
            this.LayerGuards.Style = Sunny.UI.UIStyle.Custom;
            this.LayerGuards.TabIndex = 1;
            this.LayerGuards.Text = "Guards";
            this.LayerGuards.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // LayerAreas
            // 
            this.LayerAreas.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LayerAreas.Location = new System.Drawing.Point(6, 26);
            this.LayerAreas.MinimumSize = new System.Drawing.Size(1, 1);
            this.LayerAreas.Name = "LayerAreas";
            this.LayerAreas.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.LayerAreas.Size = new System.Drawing.Size(174, 29);
            this.LayerAreas.Style = Sunny.UI.UIStyle.Custom;
            this.LayerAreas.TabIndex = 0;
            this.LayerAreas.Text = "Areas";
            this.LayerAreas.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // LayerSpawns
            // 
            this.LayerSpawns.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LayerSpawns.Location = new System.Drawing.Point(6, 100);
            this.LayerSpawns.MinimumSize = new System.Drawing.Size(1, 1);
            this.LayerSpawns.Name = "LayerSpawns";
            this.LayerSpawns.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.LayerSpawns.Size = new System.Drawing.Size(174, 29);
            this.LayerSpawns.Style = Sunny.UI.UIStyle.Custom;
            this.LayerSpawns.TabIndex = 3;
            this.LayerSpawns.Text = "Spawns";
            this.LayerSpawns.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // FMapEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(1001, 678);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "FMapEditor";
            this.Text = "Map Editor";
            this.Load += new System.EventHandler(this.FMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.uiSplitContainer1.Panel1.ResumeLayout(false);
            this.uiSplitContainer1.Panel2.ResumeLayout(false);
            this.uiSplitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiSplitContainer1)).EndInit();
            this.uiSplitContainer1.ResumeLayout(false);
            this.TerrainAttributes.ResumeLayout(false);
            this.groupLayers.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private StatusStrip statusStrip1;
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
        private Sunny.UI.UISplitContainer uiSplitContainer1;
        private Sunny.UI.UICheckBoxGroup groupLayers;
        private Sunny.UI.UICheckBox LayerGuards;
        private Sunny.UI.UICheckBox LayerAreas;
        private Sunny.UI.UICheckBoxGroup TerrainAttributes;
        private Sunny.UI.UICheckBox MapAttrFreeZone;
        private Sunny.UI.UICheckBox MapAttrSafeZone;
        private Sunny.UI.UICheckBox MapAttrStallArea;
        private Sunny.UI.UICheckBox LayerGates;
        private Sunny.UI.UICheckBox LayerSpawns;
    }
}