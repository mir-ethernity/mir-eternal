namespace AccountServer
{	
	public partial class MainForm : global::System.Windows.Forms.Form
	{		
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}		
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblRegisteredAccounts = new System.Windows.Forms.Label();
            this.lblNewAccounts = new System.Windows.Forms.Label();
            this.lblTicketsCount = new System.Windows.Forms.Label();
            this.lblBytesSend = new System.Windows.Forms.Label();
            this.lblBytesReceived = new System.Windows.Forms.Label();
            this.lblTSPort = new System.Windows.Forms.Label();
            this.txtTSPort = new System.Windows.Forms.NumericUpDown();
            this.MinimizeTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.RightClickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QuitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnServerConfig = new System.Windows.Forms.Button();
            this.btnOpenAccount = new System.Windows.Forms.Button();
            this.btnLoadConfig = new System.Windows.Forms.Button();
            this.btnLoadAccount = new System.Windows.Forms.Button();
            this.lblASPort = new System.Windows.Forms.Label();
            this.txtASPort = new System.Windows.Forms.NumericUpDown();
            this.LogTab = new System.Windows.Forms.TabPage();
            this.LogInTextBox = new System.Windows.Forms.RichTextBox();
            this.MainTab = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtTSPort)).BeginInit();
            this.RightClickMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtASPort)).BeginInit();
            this.LogTab.SuspendLayout();
            this.MainTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Silver;
            this.btnStart.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnStart.Location = new System.Drawing.Point(638, 339);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(151, 91);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.Start_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnStop.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnStop.Location = new System.Drawing.Point(638, 436);
            this.btnStop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(151, 91);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // lblRegisteredAccounts
            // 
            this.lblRegisteredAccounts.AutoSize = true;
            this.lblRegisteredAccounts.Location = new System.Drawing.Point(655, 11);
            this.lblRegisteredAccounts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRegisteredAccounts.Name = "lblRegisteredAccounts";
            this.lblRegisteredAccounts.Size = new System.Drawing.Size(97, 15);
            this.lblRegisteredAccounts.TabIndex = 3;
            this.lblRegisteredAccounts.Text = "Total Accounts: 0";
            // 
            // lblNewAccounts
            // 
            this.lblNewAccounts.AutoSize = true;
            this.lblNewAccounts.Location = new System.Drawing.Point(655, 26);
            this.lblNewAccounts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNewAccounts.Name = "lblNewAccounts";
            this.lblNewAccounts.Size = new System.Drawing.Size(96, 15);
            this.lblNewAccounts.TabIndex = 4;
            this.lblNewAccounts.Text = "New Accounts: 0";
            // 
            // lblTicketsCount
            // 
            this.lblTicketsCount.AutoSize = true;
            this.lblTicketsCount.Location = new System.Drawing.Point(655, 50);
            this.lblTicketsCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTicketsCount.Name = "lblTicketsCount";
            this.lblTicketsCount.Size = new System.Drawing.Size(85, 15);
            this.lblTicketsCount.TabIndex = 5;
            this.lblTicketsCount.Text = "Login Count: 0";
            // 
            // lblBytesSend
            // 
            this.lblBytesSend.AutoSize = true;
            this.lblBytesSend.Location = new System.Drawing.Point(655, 74);
            this.lblBytesSend.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBytesSend.Name = "lblBytesSend";
            this.lblBytesSend.Size = new System.Drawing.Size(73, 15);
            this.lblBytesSend.TabIndex = 6;
            this.lblBytesSend.Text = "Bytes Sent: 0";
            // 
            // lblBytesReceived
            // 
            this.lblBytesReceived.AutoSize = true;
            this.lblBytesReceived.Location = new System.Drawing.Point(655, 89);
            this.lblBytesReceived.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBytesReceived.Name = "lblBytesReceived";
            this.lblBytesReceived.Size = new System.Drawing.Size(97, 15);
            this.lblBytesReceived.TabIndex = 7;
            this.lblBytesReceived.Text = "Bytes Received: 0";
            // 
            // lblTSPort
            // 
            this.lblTSPort.AutoSize = true;
            this.lblTSPort.Location = new System.Drawing.Point(310, 11);
            this.lblTSPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTSPort.Name = "lblTSPort";
            this.lblTSPort.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTSPort.Size = new System.Drawing.Size(194, 15);
            this.lblTSPort.TabIndex = 11;
            this.lblTSPort.Text = "AccountServer -> GameServer Port:";
            // 
            // txtTSPort
            // 
            this.txtTSPort.Location = new System.Drawing.Point(512, 9);
            this.txtTSPort.Margin = new System.Windows.Forms.Padding(4);
            this.txtTSPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.txtTSPort.Name = "txtTSPort";
            this.txtTSPort.Size = new System.Drawing.Size(102, 23);
            this.txtTSPort.TabIndex = 10;
            this.txtTSPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MinimizeTray
            // 
            this.MinimizeTray.ContextMenuStrip = this.RightClickMenu;
            this.MinimizeTray.Icon = ((System.Drawing.Icon)(resources.GetObject("MinimizeTray.Icon")));
            this.MinimizeTray.Text = "AccountServer";
            this.MinimizeTray.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RestoreWindow_Click);
            // 
            // RightClickMenu
            // 
            this.RightClickMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.RightClickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenToolStripMenuItem,
            this.QuitToolStripMenuItem});
            this.RightClickMenu.Name = "RightClickMenu";
            this.RightClickMenu.Size = new System.Drawing.Size(126, 48);
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.OpenToolStripMenuItem.Text = "Maximise";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.RestoreWindow2_Click);
            // 
            // QuitToolStripMenuItem
            // 
            this.QuitToolStripMenuItem.Name = "QuitToolStripMenuItem";
            this.QuitToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.QuitToolStripMenuItem.Text = "Quit";
            this.QuitToolStripMenuItem.Click += new System.EventHandler(this.EndProcess_Click);
            // 
            // btnServerConfig
            // 
            this.btnServerConfig.BackColor = System.Drawing.Color.Silver;
            this.btnServerConfig.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnServerConfig.Location = new System.Drawing.Point(638, 124);
            this.btnServerConfig.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnServerConfig.Name = "btnServerConfig";
            this.btnServerConfig.Size = new System.Drawing.Size(151, 38);
            this.btnServerConfig.TabIndex = 12;
            this.btnServerConfig.Text = "Edit Server Config";
            this.btnServerConfig.UseVisualStyleBackColor = false;
            this.btnServerConfig.Click += new System.EventHandler(this.OpenConfig_Click);
            // 
            // btnOpenAccount
            // 
            this.btnOpenAccount.BackColor = System.Drawing.Color.Silver;
            this.btnOpenAccount.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnOpenAccount.Location = new System.Drawing.Point(638, 229);
            this.btnOpenAccount.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnOpenAccount.Name = "btnOpenAccount";
            this.btnOpenAccount.Size = new System.Drawing.Size(151, 38);
            this.btnOpenAccount.TabIndex = 13;
            this.btnOpenAccount.Text = "Accounts Folder";
            this.btnOpenAccount.UseVisualStyleBackColor = false;
            this.btnOpenAccount.Click += new System.EventHandler(this.ViewAccount_Click);
            // 
            // btnLoadConfig
            // 
            this.btnLoadConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLoadConfig.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLoadConfig.Location = new System.Drawing.Point(638, 168);
            this.btnLoadConfig.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnLoadConfig.Name = "btnLoadConfig";
            this.btnLoadConfig.Size = new System.Drawing.Size(151, 38);
            this.btnLoadConfig.TabIndex = 14;
            this.btnLoadConfig.Text = "Load Server Config";
            this.btnLoadConfig.UseVisualStyleBackColor = false;
            this.btnLoadConfig.Click += new System.EventHandler(this.LoadConfig_Click);
            // 
            // btnLoadAccount
            // 
            this.btnLoadAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLoadAccount.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLoadAccount.Location = new System.Drawing.Point(638, 273);
            this.btnLoadAccount.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnLoadAccount.Name = "btnLoadAccount";
            this.btnLoadAccount.Size = new System.Drawing.Size(151, 38);
            this.btnLoadAccount.TabIndex = 15;
            this.btnLoadAccount.Text = "Load Accounts";
            this.btnLoadAccount.UseVisualStyleBackColor = false;
            this.btnLoadAccount.Click += new System.EventHandler(this.LoadAccount_Click);
            // 
            // lblASPort
            // 
            this.lblASPort.AutoSize = true;
            this.lblASPort.Location = new System.Drawing.Point(27, 11);
            this.lblASPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblASPort.Name = "lblASPort";
            this.lblASPort.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblASPort.Size = new System.Drawing.Size(112, 15);
            this.lblASPort.TabIndex = 17;
            this.lblASPort.Text = "AccountServer Port:";
            // 
            // txtASPort
            // 
            this.txtASPort.Location = new System.Drawing.Point(147, 9);
            this.txtASPort.Margin = new System.Windows.Forms.Padding(4);
            this.txtASPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.txtASPort.Name = "txtASPort";
            this.txtASPort.Size = new System.Drawing.Size(102, 23);
            this.txtASPort.TabIndex = 16;
            this.txtASPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LogTab
            // 
            this.LogTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LogTab.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LogTab.Controls.Add(this.LogInTextBox);
            this.LogTab.Location = new System.Drawing.Point(4, 26);
            this.LogTab.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.LogTab.Name = "LogTab";
            this.LogTab.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.LogTab.Size = new System.Drawing.Size(622, 472);
            this.LogTab.TabIndex = 0;
            this.LogTab.Text = " AccountServer Logs";
            // 
            // LogInTextBox
            // 
            this.LogInTextBox.BackColor = System.Drawing.Color.Gainsboro;
            this.LogInTextBox.Location = new System.Drawing.Point(0, 0);
            this.LogInTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.LogInTextBox.Name = "LogInTextBox";
            this.LogInTextBox.ReadOnly = true;
            this.LogInTextBox.Size = new System.Drawing.Size(617, 457);
            this.LogInTextBox.TabIndex = 0;
            this.LogInTextBox.Text = "";
            // 
            // MainTab
            // 
            this.MainTab.Controls.Add(this.LogTab);
            this.MainTab.ItemSize = new System.Drawing.Size(535, 22);
            this.MainTab.Location = new System.Drawing.Point(0, 38);
            this.MainTab.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MainTab.Name = "MainTab";
            this.MainTab.SelectedIndex = 0;
            this.MainTab.Size = new System.Drawing.Size(630, 502);
            this.MainTab.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.MainTab.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 544);
            this.Controls.Add(this.lblASPort);
            this.Controls.Add(this.txtASPort);
            this.Controls.Add(this.btnLoadAccount);
            this.Controls.Add(this.btnLoadConfig);
            this.Controls.Add(this.btnOpenAccount);
            this.Controls.Add(this.btnServerConfig);
            this.Controls.Add(this.lblTSPort);
            this.Controls.Add(this.txtTSPort);
            this.Controls.Add(this.lblBytesReceived);
            this.Controls.Add(this.lblBytesSend);
            this.Controls.Add(this.lblTicketsCount);
            this.Controls.Add(this.lblNewAccounts);
            this.Controls.Add(this.lblRegisteredAccounts);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.MainTab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Account Server - LOMCN";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CloseWindow_Click);
            ((System.ComponentModel.ISupportInitialize)(this.txtTSPort)).EndInit();
            this.RightClickMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtASPort)).EndInit();
            this.LogTab.ResumeLayout(false);
            this.MainTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}		
		private global::System.ComponentModel.IContainer components;		
		private global::System.Windows.Forms.Button btnStart;		
		private global::System.Windows.Forms.Button btnStop;		
		private global::System.Windows.Forms.Label lblRegisteredAccounts;		
		private global::System.Windows.Forms.Label lblNewAccounts;		
		private global::System.Windows.Forms.Label lblTicketsCount;		
		private global::System.Windows.Forms.Label lblBytesSend;		
		private global::System.Windows.Forms.Label lblBytesReceived;		
		private global::System.Windows.Forms.Label lblTSPort;		
		public global::System.Windows.Forms.NumericUpDown txtTSPort;		
		private global::System.Windows.Forms.NotifyIcon MinimizeTray;		
		private global::System.Windows.Forms.ContextMenuStrip RightClickMenu;		
		private global::System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;		
		private global::System.Windows.Forms.ToolStripMenuItem QuitToolStripMenuItem;		
		private global::System.Windows.Forms.Button btnServerConfig;		
		private global::System.Windows.Forms.Button btnOpenAccount;		
		private global::System.Windows.Forms.Button btnLoadConfig;		
		private global::System.Windows.Forms.Button btnLoadAccount;
        private System.Windows.Forms.Label lblASPort;
        public System.Windows.Forms.NumericUpDown txtASPort;
        private System.Windows.Forms.TabPage LogTab;
        public System.Windows.Forms.RichTextBox LogInTextBox;
        private System.Windows.Forms.TabControl MainTab;
    }
}
