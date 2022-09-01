namespace ClientPacketSnifferApp
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.LabelSelectedDevice = new System.Windows.Forms.ToolStripStatusLabel();
            this.LabelClientPackets = new System.Windows.Forms.ToolStripStatusLabel();
            this.LabelServerPackets = new System.Windows.Forms.ToolStripStatusLabel();
            this.LabelCaptureSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ButtonCaptureToggle = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ButtonChangeDevice = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ButtonConfig = new System.Windows.Forms.ToolStripButton();
            this.PacketsList = new System.Windows.Forms.ListBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ButtonOpenRaw = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LabelSelectedDevice,
            this.LabelClientPackets,
            this.LabelServerPackets,
            this.LabelCaptureSize});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // LabelSelectedDevice
            // 
            this.LabelSelectedDevice.Name = "LabelSelectedDevice";
            this.LabelSelectedDevice.Size = new System.Drawing.Size(114, 17);
            this.LabelSelectedDevice.Text = "LabelSelectedDevice";
            // 
            // LabelClientPackets
            // 
            this.LabelClientPackets.Name = "LabelClientPackets";
            this.LabelClientPackets.Size = new System.Drawing.Size(107, 17);
            this.LabelClientPackets.Text = "Client Packets: N/a";
            // 
            // LabelServerPackets
            // 
            this.LabelServerPackets.Name = "LabelServerPackets";
            this.LabelServerPackets.Size = new System.Drawing.Size(108, 17);
            this.LabelServerPackets.Text = "Server Packets: N/a";
            // 
            // LabelCaptureSize
            // 
            this.LabelCaptureSize.Name = "LabelCaptureSize";
            this.LabelCaptureSize.Size = new System.Drawing.Size(98, 17);
            this.LabelCaptureSize.Text = "Capture Size: N/a";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ButtonCaptureToggle,
            this.toolStripSeparator1,
            this.ButtonChangeDevice,
            this.toolStripSeparator2,
            this.ButtonConfig,
            this.toolStripSeparator3,
            this.ButtonOpenRaw});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ButtonCaptureToggle
            // 
            this.ButtonCaptureToggle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ButtonCaptureToggle.Image = ((System.Drawing.Image)(resources.GetObject("ButtonCaptureToggle.Image")));
            this.ButtonCaptureToggle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonCaptureToggle.Name = "ButtonCaptureToggle";
            this.ButtonCaptureToggle.Size = new System.Drawing.Size(78, 22);
            this.ButtonCaptureToggle.Text = "Start capture";
            this.ButtonCaptureToggle.ToolTipText = "Start/stop capture";
            this.ButtonCaptureToggle.Click += new System.EventHandler(this.ButtonCaptureToggle_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // ButtonChangeDevice
            // 
            this.ButtonChangeDevice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ButtonChangeDevice.Image = ((System.Drawing.Image)(resources.GetObject("ButtonChangeDevice.Image")));
            this.ButtonChangeDevice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonChangeDevice.Name = "ButtonChangeDevice";
            this.ButtonChangeDevice.Size = new System.Drawing.Size(90, 22);
            this.ButtonChangeDevice.Text = "Change Device";
            this.ButtonChangeDevice.Click += new System.EventHandler(this.ButtonChangeDevice_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // ButtonConfig
            // 
            this.ButtonConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ButtonConfig.Image = ((System.Drawing.Image)(resources.GetObject("ButtonConfig.Image")));
            this.ButtonConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonConfig.Name = "ButtonConfig";
            this.ButtonConfig.Size = new System.Drawing.Size(47, 22);
            this.ButtonConfig.Text = "Config";
            this.ButtonConfig.Click += new System.EventHandler(this.ButtonConfig_Click);
            // 
            // PacketsList
            // 
            this.PacketsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PacketsList.FormattingEnabled = true;
            this.PacketsList.ItemHeight = 15;
            this.PacketsList.Location = new System.Drawing.Point(0, 25);
            this.PacketsList.Name = "PacketsList";
            this.PacketsList.Size = new System.Drawing.Size(800, 403);
            this.PacketsList.TabIndex = 3;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // ButtonOpenRaw
            // 
            this.ButtonOpenRaw.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ButtonOpenRaw.Image = ((System.Drawing.Image)(resources.GetObject("ButtonOpenRaw.Image")));
            this.ButtonOpenRaw.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonOpenRaw.Name = "ButtonOpenRaw";
            this.ButtonOpenRaw.Size = new System.Drawing.Size(65, 22);
            this.ButtonOpenRaw.Text = "Open Raw";
            this.ButtonOpenRaw.Click += new System.EventHandler(this.ButtonOpenRaw_Click);
            // 
            // FMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PacketsList);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "FMain";
            this.Text = "Mir3D Client Packet Sniffer";
            this.Load += new System.EventHandler(this.FMain_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel LabelSelectedDevice;
        private ToolStrip toolStrip1;
        private ToolStripButton ButtonCaptureToggle;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton ButtonChangeDevice;
        private ListBox PacketsList;
        private ToolStripStatusLabel LabelClientPackets;
        private ToolStripStatusLabel LabelServerPackets;
        private ToolStripStatusLabel LabelCaptureSize;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton ButtonConfig;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton ButtonOpenRaw;
    }
}