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
			InitializeComponent();
			Singleton = this;
			txtTSPort.Value = Settings.Default.TSPort;
			txtASPort.Value = Settings.Default.ASPort;

			if (!File.Exists(".\\server"))
			{
				日志文本框.AppendText("No server configuration file found, please note the configuration\r\n");
			}
			if (!Directory.Exists(DataDirectory))
			{
				日志文本框.AppendText("Account configuration folder not found, please note import\r\n");
			}
		}

		
		public static void UpdateTotalNewAccounts()
		{
			MainForm MainForm = Singleton;
			if (MainForm == null)
			{
				return;
			}
			MainForm.BeginInvoke(new MethodInvoker(delegate()
			{
				Singleton.lblRegisteredAccounts.Text = string.Format("Registered accounts: {0}", AccountData.Count);
			}));
		}

		
		public static void 更新新注册账号数()
		{
			MainForm MainForm = Singleton;
			UpdateTotalNewAccounts();
			
			if (MainForm == null)
			{
				return;
			}
			MainForm.BeginInvoke(new MethodInvoker(delegate()
			{
				Singleton.lblNewAccounts.Text = string.Format("New accounts: {0}", TotalNewAccounts);
			}));
		}

		
		public static void UpdateTotalTickets()
		{
			MainForm MainForm = Singleton;
			if (MainForm == null)
			{
				return;
			}
			MainForm.BeginInvoke(new MethodInvoker(delegate()
			{
				Singleton.lblTicketsCount.Text = string.Format("Tickets generated {0}", TotalTickets);
			}));
		}

		
		public static void UpdateTotalBytesReceived()
		{
			MainForm MainForm = Singleton;
			if (MainForm == null)
			{
				return;
			}
			MainForm.BeginInvoke(new MethodInvoker(delegate()
			{
				Singleton.lblBytesReceived.Text = string.Format("Bytes received: {0}", TotalBytesReceived);
			}));
		}

		
		public static void UpdateTotalBytesSended()
		{
			MainForm MainForm = Singleton;
			if (MainForm == null)
			{
				return;
			}
			MainForm.BeginInvoke(new MethodInvoker(delegate()
			{
				Singleton.lblBytesSend.Text = string.Format("Bytes sent: {0}", TotalBytesSended);
			}));
		}

		
		public static void AddLog(string 内容)
		{
			MainForm MainForm = Singleton;
			if (MainForm == null)
			{
				return;
			}
			MainForm.BeginInvoke(new MethodInvoker(delegate()
			{
				Singleton.日志文本框.AppendText(内容 + "\r\n");
				Singleton.日志文本框.ScrollToCaret();
			}));
		}

		
		public static void AddAccount(AccountData 账号)
		{
			if (!AccountData.ContainsKey(账号.账号名字))
			{
				AccountData[账号.账号名字] = 账号;
				SaveAccount(账号);
			}
		}

		
		public static void SaveAccount(AccountData 账号)
		{
			File.WriteAllText(DataDirectory + "\\" + 账号.账号名字 + ".txt", Serializer.Serialize(账号));
		}

		
		private void Start_Click(object sender, EventArgs e)
		{
			if (ServerData == null || ServerData.Count == 0)
			{
				LoadConfig_Click(sender, e);
			}
			if (ServerData == null || ServerData.Count == 0)
			{
				AddLog("Server configuration is empty, startup failed");
				return;
			}
			if (AccountData == null || AccountData.Count == 0)
			{
				LoadAccount_Click(sender, e);
			}
			if (Network.Start())
			{
				btnStop.Enabled = true;
				btnLoadConfig.Enabled = (btnLoadAccount.Enabled = false);
				btnStart.Enabled = false;
				txtASPort.Enabled = false;
				txtTSPort.Enabled = false;
				Settings.Default.ASPort = (ushort)txtASPort.Value;
				Settings.Default.TSPort = (ushort)txtTSPort.Value;
				Settings.Default.Save();
			}
		}

		
		private void Stop_Click(object sender, EventArgs e)
		{
			Network.Stop();
			btnStop.Enabled = false;
			btnLoadConfig.Enabled = (btnLoadAccount.Enabled = true);
			btnStart.Enabled = (txtASPort.Enabled = (txtTSPort.Enabled = true));
		}

		
		private void CloseWindow_Click(object sender, FormClosingEventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to shut down the server?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
			{
				MinimizeTray.Visible = false;
				Environment.Exit(0);
				return;
			}
			MinimizeTray.Visible = true;
			base.Hide();
			if (e != null)
			{
				e.Cancel = true;
			}
			MinimizeTray.ShowBalloonTip(1000, "", "The server has moved to the background.", ToolTipIcon.Info);
		}

		
		private void RestoreWindow_Click(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				base.Visible = true;
				MinimizeTray.Visible = false;
			}
		}

		
		private void RestoreWindow2_Click(object sender, EventArgs e)
		{
			base.Visible = true;
			MinimizeTray.Visible = false;
		}

		
		private void EndProcess_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to shut down the server?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
			{
				Network.Stop();
				MinimizeTray.Visible = false;
				Environment.Exit(0);
			}
		}

		
		private void OpenConfig_Click(object sender, EventArgs e)
		{
			if (!File.Exists(".\\server"))
			{
				AddLog("Profile does not exist, it was created automatically");
				File.WriteAllBytes(".\\server", new byte[0]);
			}
			Process.Start("notepad.exe", ".\\server");
		}

		
		private void LoadConfig_Click(object sender, EventArgs e)
		{
			if (File.Exists(".\\server"))
			{
				ServerData = new Dictionary<string, IPEndPoint>();
				GameServerArea = File.ReadAllText(".\\server", Encoding.Unicode).Trim(new char[]
				{
					'\r',
					'\n',
					' '
				});
				foreach (string text in GameServerArea.Split(new char[]
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
					ServerData.Add(array2[2], new IPEndPoint(IPAddress.Parse(array2[0]), Convert.ToInt32(array2[1])));
				}
				AddLog("Network configuration loaded, current configuration list:\r\n" + GameServerArea);
			}
		}

		
		private void ViewAccount_Click(object sender, EventArgs e)
		{
			if (!Directory.Exists(DataDirectory))
			{
				AddLog("Account directory does not exist, it has been created automatically");
				Directory.CreateDirectory(DataDirectory);
				return;
			}
			Process.Start("explorer.exe", DataDirectory);
		}

		
		private void LoadAccount_Click(object sender, EventArgs e)
		{
			AccountData = new Dictionary<string, AccountData>();
			if (!Directory.Exists(DataDirectory))
			{
				AddLog("Account directory does not exist, it has been created automatically");
				Directory.CreateDirectory(DataDirectory);
				return;
			}
			object[] array = Serializer.Deserialize(DataDirectory, typeof(AccountData));
			for (int i = 0; i < array.Length; i++)
			{
				AccountData accountData = array[i] as AccountData;
				if (accountData != null)
				{
					AccountData[accountData.账号名字] = accountData;
				}
			}
			AddLog(string.Format("Accounts has been loaded, the current number of accounts: {0}", AccountData.Count));
			lblRegisteredAccounts.Text = string.Format("Registered account: {0}", AccountData.Count);
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
