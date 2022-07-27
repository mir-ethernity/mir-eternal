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
                LogInTextBox.AppendText("No server configuration file found, please note the configuration\r\n");
            }
            if (!Directory.Exists(DataDirectory))
            {
                LogInTextBox.AppendText("Account configuration folder not found, please note import\r\n");
            }
        }
        public static void UpdateTotalNewAccounts()
        {
            MainForm MainForm = Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                Singleton.lblRegisteredAccounts.Text = string.Format("Total Accounts: {0}", AccountData.Count);
            }));
        }
        public static void UpdateRegisteredAccounts()
        {
            MainForm MainForm = Singleton;
            UpdateTotalNewAccounts();

            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                Singleton.lblNewAccounts.Text = string.Format("New Accounts: {0}", TotalNewAccounts);
            }));
        }
        public static void UpdateTotalTickets()
        {
            MainForm MainForm = Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                Singleton.lblTicketsCount.Text = string.Format("Tickets Generated {0}", TotalTickets);
            }));
        }
        public static void UpdateTotalBytesReceived()
        {
            MainForm MainForm = Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                Singleton.lblBytesReceived.Text = string.Format("Bytes Received: {0}", TotalBytesReceived);
            }));
        }
        public static void UpdateTotalBytesSended()
        {
            MainForm MainForm = Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                Singleton.lblBytesSend.Text = string.Format("Bytes Sent: {0}", TotalBytesSended);
            }));
        }
        public static void AddLog(string contents)
        {
            MainForm MainForm = Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                Singleton.LogInTextBox.AppendText(contents + "\r\n");
                Singleton.LogInTextBox.ScrollToCaret();
            }));
        }
        public static void AddAccount(AccountData account)
        {
            if (!AccountData.ContainsKey(account.Account))
            {
                AccountData[account.Account] = account;
                SaveAccount(account);
            }
        }
        public static void SaveAccount(AccountData account)
        {
            File.WriteAllText(DataDirectory + "\\" + account.Account + ".txt", Serializer.Serialize(account));
        }
        private void Start_Click(object sender, EventArgs e)
        {
            if (ServerData == null || ServerData.Count == 0)
            {
                LoadConfig_Click(sender, e);
            }
            if (ServerData == null || ServerData.Count == 0)
            {
                AddLog("Server Configuration is empty. Start Failed.");
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
            DialogResult result = MessageBox.Show("Click Yes to ShutDown the AccountServer\r\n\nClick No to Minimise to Tool Bar", "Exit Options", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                MinimizeTray.Visible = false;
                Environment.Exit(0);
                return;
            }
            else if (result == DialogResult.No)
            {
                MinimizeTray.Visible = true;
                base.Hide();
                if (e != null)
                {
                    e.Cancel = true;
                }
                MinimizeTray.ShowBalloonTip(1000, "", "AccountServer Moved to Tool Bar.", ToolTipIcon.Info);
            }
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
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
            if (MessageBox.Show("Do you want to ShutDown the AccountServer?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
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
                GameServerArea = File.ReadAllText(".\\server", Encoding.UTF8).Trim('\r', '\n', ' ');
                foreach (string text in GameServerArea.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    string[] array2 = text.Split(new char[] { ',', '/' }, StringSplitOptions.RemoveEmptyEntries);
                    if (array2.Length != 3)
                    {
                        MessageBox.Show("server configuration error, parsing error. Line: " + text);
                        Environment.Exit(0);
                    }
                    ServerData.Add(array2[2], new IPEndPoint(IPAddress.Parse(array2[0]), Convert.ToInt32(array2[1])));
                }
                AddLog("Network Configuration Loaded: "+ GameServerArea);
            }
        }
        private void ViewAccount_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(DataDirectory))
            {
                AddLog("Account Directory does not exist. It has been created automatically.");
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
                AddLog("Account Directory does not exist. It has been created automatically.");
                Directory.CreateDirectory(DataDirectory);
                return;
            }
            object[] array = Serializer.Deserialize(DataDirectory, typeof(AccountData));
            for (int i = 0; i < array.Length; i++)
            {
                AccountData accountData = array[i] as AccountData;
                if (accountData != null)
                {
                    AccountData[accountData.Account] = accountData;
                }
            }
            AddLog(string.Format("Accounts Loaded: {0}", AccountData.Count));
            lblRegisteredAccounts.Text = string.Format("Total Accounts: {0}", AccountData.Count);
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
