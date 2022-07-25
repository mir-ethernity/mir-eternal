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
            this.主选项卡 = new System.Windows.Forms.TabControl();
            this.日志选项卡 = new System.Windows.Forms.TabPage();
            this.日志文本框 = new System.Windows.Forms.RichTextBox();
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
            this.托盘右键菜单 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnServerConfig = new System.Windows.Forms.Button();
            this.btnOpenAccount = new System.Windows.Forms.Button();
            this.btnLoadConfig = new System.Windows.Forms.Button();
            this.btnLoadAccount = new System.Windows.Forms.Button();
            this.lblASPort = new System.Windows.Forms.Label();
            this.txtASPort = new System.Windows.Forms.NumericUpDown();
            this.主选项卡.SuspendLayout();
            this.日志选项卡.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTSPort)).BeginInit();
            this.托盘右键菜单.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtASPort)).BeginInit();
            this.SuspendLayout();
            // 
            // 主选项卡
            // 
            this.主选项卡.Controls.Add(this.日志选项卡);
            this.主选项卡.ItemSize = new System.Drawing.Size(535, 22);
            this.主选项卡.Location = new System.Drawing.Point(0, 40);
            this.主选项卡.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.主选项卡.Name = "主选项卡";
            this.主选项卡.SelectedIndex = 0;
            this.主选项卡.Size = new System.Drawing.Size(720, 535);
            this.主选项卡.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.主选项卡.TabIndex = 0;
            // 
            // 日志选项卡
            // 
            this.日志选项卡.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.日志选项卡.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.日志选项卡.Controls.Add(this.日志文本框);
            this.日志选项卡.Location = new System.Drawing.Point(4, 26);
            this.日志选项卡.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.日志选项卡.Name = "日志选项卡";
            this.日志选项卡.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.日志选项卡.Size = new System.Drawing.Size(712, 505);
            this.日志选项卡.TabIndex = 0;
            this.日志选项卡.Text = "Logs";
            // 
            // 日志文本框
            // 
            this.日志文本框.BackColor = System.Drawing.Color.Gainsboro;
            this.日志文本框.Location = new System.Drawing.Point(0, 0);
            this.日志文本框.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.日志文本框.Name = "日志文本框";
            this.日志文本框.ReadOnly = true;
            this.日志文本框.Size = new System.Drawing.Size(705, 487);
            this.日志文本框.TabIndex = 0;
            this.日志文本框.Text = "";
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.YellowGreen;
            this.btnStart.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStart.Location = new System.Drawing.Point(723, 381);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(173, 97);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.Start_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Crimson;
            this.btnStop.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStop.Location = new System.Drawing.Point(721, 477);
            this.btnStop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(173, 97);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // lblRegisteredAccounts
            // 
            this.lblRegisteredAccounts.AutoSize = true;
            this.lblRegisteredAccounts.Location = new System.Drawing.Point(728, 53);
            this.lblRegisteredAccounts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRegisteredAccounts.Name = "lblRegisteredAccounts";
            this.lblRegisteredAccounts.Size = new System.Drawing.Size(145, 16);
            this.lblRegisteredAccounts.TabIndex = 3;
            this.lblRegisteredAccounts.Text = "Registered Accounts: 0";
            // 
            // lblNewAccounts
            // 
            this.lblNewAccounts.AutoSize = true;
            this.lblNewAccounts.Location = new System.Drawing.Point(728, 84);
            this.lblNewAccounts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNewAccounts.Name = "lblNewAccounts";
            this.lblNewAccounts.Size = new System.Drawing.Size(105, 16);
            this.lblNewAccounts.TabIndex = 4;
            this.lblNewAccounts.Text = "New Accounts: 0";
            // 
            // lblTicketsCount
            // 
            this.lblTicketsCount.AutoSize = true;
            this.lblTicketsCount.Location = new System.Drawing.Point(728, 115);
            this.lblTicketsCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTicketsCount.Name = "lblTicketsCount";
            this.lblTicketsCount.Size = new System.Drawing.Size(101, 16);
            this.lblTicketsCount.TabIndex = 5;
            this.lblTicketsCount.Text = "Login Count: 0";
            // 
            // lblBytesSend
            // 
            this.lblBytesSend.AutoSize = true;
            this.lblBytesSend.Location = new System.Drawing.Point(728, 145);
            this.lblBytesSend.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBytesSend.Name = "lblBytesSend";
            this.lblBytesSend.Size = new System.Drawing.Size(89, 16);
            this.lblBytesSend.TabIndex = 6;
            this.lblBytesSend.Text = "Bytes Send: 0";
            // 
            // lblBytesReceived
            // 
            this.lblBytesReceived.AutoSize = true;
            this.lblBytesReceived.Location = new System.Drawing.Point(728, 176);
            this.lblBytesReceived.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBytesReceived.Name = "lblBytesReceived";
            this.lblBytesReceived.Size = new System.Drawing.Size(116, 16);
            this.lblBytesReceived.TabIndex = 7;
            this.lblBytesReceived.Text = "Bytes Received: 0";
            // 
            // lblTSPort
            // 
            this.lblTSPort.AutoSize = true;
            this.lblTSPort.Location = new System.Drawing.Point(218, 12);
            this.lblTSPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTSPort.Name = "lblTSPort";
            this.lblTSPort.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTSPort.Size = new System.Drawing.Size(65, 20);
            this.lblTSPort.TabIndex = 11;
            this.lblTSPort.Text = "TS Port";
            // 
            // txtTSPort
            // 
            this.txtTSPort.Location = new System.Drawing.Point(304, 10);
            this.txtTSPort.Margin = new System.Windows.Forms.Padding(4);
            this.txtTSPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.txtTSPort.Name = "txtTSPort";
            this.txtTSPort.Size = new System.Drawing.Size(116, 22);
            this.txtTSPort.TabIndex = 10;
            this.txtTSPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MinimizeTray
            // 
            this.MinimizeTray.ContextMenuStrip = this.托盘右键菜单;
            this.MinimizeTray.Icon = ((System.Drawing.Icon)(resources.GetObject("MinimizeTray.Icon")));
            this.MinimizeTray.Text = "AccountServer";
            this.MinimizeTray.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RestoreWindow_Click);
            // 
            // 托盘右键菜单
            // 
            this.托盘右键菜单.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.托盘右键菜单.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.托盘右键菜单.Name = "托盘右键菜单";
            this.托盘右键菜单.Size = new System.Drawing.Size(109, 52);
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.打开ToolStripMenuItem.Text = "打开";
            this.打开ToolStripMenuItem.Click += new System.EventHandler(this.RestoreWindow2_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.退出ToolStripMenuItem.Text = "Exit";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.EndProcess_Click);
            // 
            // btnServerConfig
            // 
            this.btnServerConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnServerConfig.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnServerConfig.Location = new System.Drawing.Point(721, 211);
            this.btnServerConfig.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnServerConfig.Name = "btnServerConfig";
            this.btnServerConfig.Size = new System.Drawing.Size(173, 40);
            this.btnServerConfig.TabIndex = 12;
            this.btnServerConfig.Text = "Server Config";
            this.btnServerConfig.UseVisualStyleBackColor = false;
            this.btnServerConfig.Click += new System.EventHandler(this.OpenConfig_Click);
            // 
            // btnOpenAccount
            // 
            this.btnOpenAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnOpenAccount.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOpenAccount.Location = new System.Drawing.Point(721, 296);
            this.btnOpenAccount.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnOpenAccount.Name = "btnOpenAccount";
            this.btnOpenAccount.Size = new System.Drawing.Size(173, 40);
            this.btnOpenAccount.TabIndex = 13;
            this.btnOpenAccount.Text = "Open Account";
            this.btnOpenAccount.UseVisualStyleBackColor = false;
            this.btnOpenAccount.Click += new System.EventHandler(this.ViewAccount_Click);
            // 
            // btnLoadConfig
            // 
            this.btnLoadConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnLoadConfig.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLoadConfig.Location = new System.Drawing.Point(721, 253);
            this.btnLoadConfig.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnLoadConfig.Name = "btnLoadConfig";
            this.btnLoadConfig.Size = new System.Drawing.Size(173, 40);
            this.btnLoadConfig.TabIndex = 14;
            this.btnLoadConfig.Text = "Load Config";
            this.btnLoadConfig.UseVisualStyleBackColor = false;
            this.btnLoadConfig.Click += new System.EventHandler(this.LoadConfig_Click);
            // 
            // btnLoadAccount
            // 
            this.btnLoadAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnLoadAccount.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLoadAccount.Location = new System.Drawing.Point(723, 339);
            this.btnLoadAccount.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnLoadAccount.Name = "btnLoadAccount";
            this.btnLoadAccount.Size = new System.Drawing.Size(173, 40);
            this.btnLoadAccount.TabIndex = 15;
            this.btnLoadAccount.Text = "Load Account";
            this.btnLoadAccount.UseVisualStyleBackColor = false;
            this.btnLoadAccount.Click += new System.EventHandler(this.LoadAccount_Click);
            // 
            // lblASPort
            // 
            this.lblASPort.AutoSize = true;
            this.lblASPort.Location = new System.Drawing.Point(26, 12);
            this.lblASPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblASPort.Name = "lblASPort";
            this.lblASPort.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblASPort.Size = new System.Drawing.Size(52, 16);
            this.lblASPort.TabIndex = 17;
            this.lblASPort.Text = "AS Port";
            // 
            // txtASPort
            // 
            this.txtASPort.Location = new System.Drawing.Point(83, 10);
            this.txtASPort.Margin = new System.Windows.Forms.Padding(4);
            this.txtASPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.txtASPort.Name = "txtASPort";
            this.txtASPort.Size = new System.Drawing.Size(116, 22);
            this.txtASPort.TabIndex = 16;
            this.txtASPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 580);
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
            this.Controls.Add(this.主选项卡);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Account Server - LomCN";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CloseWindow_Click);
            this.主选项卡.ResumeLayout(false);
            this.日志选项卡.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTSPort)).EndInit();
            this.托盘右键菜单.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtASPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		
		private global::System.ComponentModel.IContainer components;

		
		private global::System.Windows.Forms.TabControl 主选项卡;

		
		private global::System.Windows.Forms.Button btnStart;

		
		private global::System.Windows.Forms.Button btnStop;

		
		private global::System.Windows.Forms.TabPage 日志选项卡;

		
		public global::System.Windows.Forms.RichTextBox 日志文本框;

		
		private global::System.Windows.Forms.Label lblRegisteredAccounts;

		
		private global::System.Windows.Forms.Label lblNewAccounts;

		
		private global::System.Windows.Forms.Label lblTicketsCount;

		
		private global::System.Windows.Forms.Label lblBytesSend;

		
		private global::System.Windows.Forms.Label lblBytesReceived;


		
		private global::System.Windows.Forms.Label lblTSPort;


		
		public global::System.Windows.Forms.NumericUpDown txtTSPort;

		
		private global::System.Windows.Forms.NotifyIcon MinimizeTray;

		
		private global::System.Windows.Forms.ContextMenuStrip 托盘右键菜单;

		
		private global::System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;

		
		private global::System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;

		
		private global::System.Windows.Forms.Button btnServerConfig;

		
		private global::System.Windows.Forms.Button btnOpenAccount;

		
		private global::System.Windows.Forms.Button btnLoadConfig;

		
		private global::System.Windows.Forms.Button btnLoadAccount;
        private System.Windows.Forms.Label lblASPort;
        public System.Windows.Forms.NumericUpDown txtASPort;
    }
}
