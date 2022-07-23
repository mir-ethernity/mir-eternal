using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using AccountServer.Properties;

namespace AccountServer
{
	
	public partial class MainForm : Form
	{
		
		public MainForm()
		{
			this.InitializeComponent();
			MainForm.Singleton = this;
			this.txtServerPort.Value = Settings.Default.ServerPort;
			this.txtTicketPort.Value = Settings.Default.TicketsPort;
			if (!File.Exists(".\\server"))
			{
				this.日志文本框.AppendText("No server configuration file found, please note the configuration\r\n");
			}
			if (!Directory.Exists(MainForm.DataDirectory))
			{
				this.日志文本框.AppendText("Account configuration folder not found, please note import\r\n");
			}
		}

		
		public static void UpdateTotalNewAccounts()
		{
			MainForm MainForm = MainForm.Singleton;
			if (MainForm == null)
			{
				return;
			}
			MainForm.BeginInvoke(new MethodInvoker(delegate()
			{
				MainForm.Singleton.lblRegisteredAccounts.Text = string.Format("Registered accounts: {0}", MainForm.AccountData.Count);
			}));
		}

		
		public static void 更新新注册账号数()
		{
			MainForm MainForm = MainForm.Singleton;
			MainForm.UpdateTotalNewAccounts();
			
			if (MainForm == null)
			{
				return;
			}
			MainForm.BeginInvoke(new MethodInvoker(delegate()
			{
				MainForm.Singleton.lblNewAccounts.Text = string.Format("New accounts: {0}", MainForm.TotalNewAccounts);
			}));
		}

		
		public static void UpdateTotalTickets()
		{
			MainForm MainForm = MainForm.Singleton;
			if (MainForm == null)
			{
				return;
			}
			MainForm.BeginInvoke(new MethodInvoker(delegate()
			{
				MainForm.Singleton.lblTicketsCount.Text = string.Format("Tickets generated {0}", MainForm.TotalTickets);
			}));
		}

		
		public static void UpdateTotalBytesReceived()
		{
			MainForm MainForm = MainForm.Singleton;
			if (MainForm == null)
			{
				return;
			}
			MainForm.BeginInvoke(new MethodInvoker(delegate()
			{
				MainForm.Singleton.lblBytesReceived.Text = string.Format("Bytes received: {0}", MainForm.TotalBytesReceived);
			}));
		}

		
		public static void UpdateTotalBytesSended()
		{
			MainForm MainForm = MainForm.Singleton;
			if (MainForm == null)
			{
				return;
			}
			MainForm.BeginInvoke(new MethodInvoker(delegate()
			{
				MainForm.Singleton.lblBytesSend.Text = string.Format("Bytes sent: {0}", MainForm.TotalBytesSended);
			}));
		}

		
		public static void AddLog(string 内容)
		{
			MainForm MainForm = MainForm.Singleton;
			if (MainForm == null)
			{
				return;
			}
			MainForm.BeginInvoke(new MethodInvoker(delegate()
			{
				MainForm.Singleton.日志文本框.AppendText(内容 + "\r\n");
				MainForm.Singleton.日志文本框.ScrollToCaret();
			}));
		}

		
		public static void AddAccount(AccountData 账号)
		{
			if (!MainForm.AccountData.ContainsKey(账号.账号名字))
			{
				MainForm.AccountData[账号.账号名字] = 账号;
				MainForm.SaveAccount(账号);
			}
		}

		
		public static void SaveAccount(AccountData 账号)
		{
			File.WriteAllText(MainForm.DataDirectory + "\\" + 账号.账号名字 + ".txt", Serializer.Serialize(账号));
		}

		
		private void Start_Click(object sender, EventArgs e)
		{
			if (MainForm.ServerData == null || MainForm.ServerData.Count == 0)
			{
				this.LoadConfig_Click(sender, e);
			}
			if (MainForm.ServerData == null || MainForm.ServerData.Count == 0)
			{
				MainForm.AddLog("Server configuration is empty, startup failed");
				return;
			}
			if (MainForm.AccountData == null || MainForm.AccountData.Count == 0)
			{
				this.LoadAccount_Click(sender, e);
			}
			if (Network.Start())
			{
				this.btnStop.Enabled = true;
				this.btnLoadConfig.Enabled = (this.btnLoadAccount.Enabled = false);
				this.btnStart.Enabled = false;
				this.txtServerPort.Enabled = false;
				this.txtTicketPort.Enabled = false;
				Settings.Default.ServerPort = (ushort)this.txtServerPort.Value;
				Settings.Default.TicketsPort = (ushort)this.txtTicketPort.Value;
				Settings.Default.Save();
			}
		}

		
		private void Stop_Click(object sender, EventArgs e)
		{
			Network.Stop();
			this.btnStop.Enabled = false;
			this.btnLoadConfig.Enabled = (this.btnLoadAccount.Enabled = true);
			this.btnStart.Enabled = (this.txtServerPort.Enabled = (this.txtTicketPort.Enabled = true));
		}

		
		private void CloseWindow_Click(object sender, FormClosingEventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to shut down the server?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
			{
				this.MinimizeTray.Visible = false;
				Environment.Exit(0);
				return;
			}
			this.MinimizeTray.Visible = true;
			base.Hide();
			if (e != null)
			{
				e.Cancel = true;
			}
			this.MinimizeTray.ShowBalloonTip(1000, "", "The server has moved to the background.", ToolTipIcon.Info);
		}

		
		private void RestoreWindow_Click(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				base.Visible = true;
				this.MinimizeTray.Visible = false;
			}
		}

		
		private void RestoreWindow2_Click(object sender, EventArgs e)
		{
			base.Visible = true;
			this.MinimizeTray.Visible = false;
		}

		
		private void EndProcess_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to shut down the server?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
			{
				Network.Stop();
				this.MinimizeTray.Visible = false;
				Environment.Exit(0);
			}
		}

		
		private void OpenConfig_Click(object sender, EventArgs e)
		{
			if (!File.Exists(".\\server"))
			{
				MainForm.AddLog("Profile does not exist, it was created automatically");
				File.WriteAllBytes(".\\server", new byte[0]);
			}
			Process.Start("notepad.exe", ".\\server");
		}

		
		private void LoadConfig_Click(object sender, EventArgs e)
		{
			if (File.Exists(".\\server"))
			{
				MainForm.ServerData = new Dictionary<string, IPEndPoint>();
				MainForm.GameServerArea = File.ReadAllText(".\\server", Encoding.Unicode).Trim(new char[]
				{
					'\r',
					'\n',
					' '
				});
				foreach (string text in MainForm.GameServerArea.Split(new char[]
				{
					'\r',
					'\n'
				}, StringSplitOptions.RemoveEmptyEntries))
				{
					string[] array2 = text.Split(new char[]
					{
						',',
						'/'
					}, StringSplitOptions.RemoveEmptyEntries);
					if (array2.Length != 3)
					{
						MessageBox.Show("server configuration error, parsing error. Line: " + text);
						Environment.Exit(0);
					}
					MainForm.ServerData.Add(array2[2], new IPEndPoint(IPAddress.Parse(array2[0]), Convert.ToInt32(array2[1])));
				}
				MainForm.AddLog("Network configuration loaded, current configuration list:\r\n" + MainForm.GameServerArea);
			}
		}

		
		private void ViewAccount_Click(object sender, EventArgs e)
		{
			if (!Directory.Exists(MainForm.DataDirectory))
			{
				MainForm.AddLog("Account directory does not exist, it has been created automatically");
				Directory.CreateDirectory(MainForm.DataDirectory);
				return;
			}
			Process.Start("explorer.exe", MainForm.DataDirectory);
		}

		
		private void LoadAccount_Click(object sender, EventArgs e)
		{
			MainForm.AccountData = new Dictionary<string, AccountData>();
			if (!Directory.Exists(MainForm.DataDirectory))
			{
				MainForm.AddLog("Account directory does not exist, it has been created automatically");
				Directory.CreateDirectory(MainForm.DataDirectory);
				return;
			}
			object[] array = Serializer.Deserialize(MainForm.DataDirectory, typeof(AccountData));
			for (int i = 0; i < array.Length; i++)
			{
				AccountData AccountData = array[i] as AccountData;
				if (AccountData != null)
				{
					MainForm.AccountData[AccountData.账号名字] = AccountData;
				}
			}
			MainForm.AddLog(string.Format("Accounts has been loaded, the current number of accounts: {0}", MainForm.AccountData.Count));
			this.lblRegisteredAccounts.Text = string.Format("Registered account: {0}", MainForm.AccountData.Count);
		}

		
		public static uint TotalNewAccounts;

		
		public static uint TotalTickets;

		
		public static long TotalBytesReceived;

		
		public static long TotalBytesSended;

		
		public static MainForm Singleton;

		
		public static string GameServerArea = "";

		
		public static string DataDirectory = ".\\Accounts";

		
		public static Dictionary<string, AccountData> AccountData;

		
		public static Dictionary<string, IPEndPoint> ServerData;
    }
}
