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
using AccountServer.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AccountServer
{
    public partial class MainForm : Form
    {
        public MainForm(
            Lazy<Network> network, // TODO: Refactor to remove this dep
            IAppConfiguration config
        )
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _network = network ?? throw new ArgumentNullException(nameof(network));

            InitializeComponent();

            txtTSPort.Value = _config.LoginGatePort;
            txtASPort.Value = _config.AccountServerPort;

            if (!File.Exists(".\\server"))
            {
                LogInTextBox.AppendText("No server configuration file found, please note the configuration\r\n");
            }
            if (!Directory.Exists(DataDirectory))
            {
                LogInTextBox.AppendText("Account configuration folder not found, please note import\r\n");
            }
        }
        public void UpdateTotalAccounts()
        {
            BeginInvoke(new MethodInvoker(delegate ()
            {
                lblRegisteredAccounts.Text = string.Format("Total Accounts: {0}", AccountData.Count);
            }));
        }
        public void UpdateRegisteredAccounts()
        {
            UpdateTotalAccounts();
            BeginInvoke(new MethodInvoker(delegate ()
            {
                lblNewAccounts.Text = string.Format("New Accounts: {0}", TotalNewAccounts);
            }));
        }
        public void UpdateTotalTickets()
        {
            BeginInvoke(new MethodInvoker(delegate ()
            {
                lblTicketsCount.Text = string.Format("Tickets Generated {0}", TotalTickets);
            }));
        }
        public void UpdateTotalBytesReceived()
        {
            BeginInvoke(new MethodInvoker(delegate ()
            {
                lblBytesReceived.Text = string.Format("Bytes Received: {0}", TotalBytesReceived);
            }));
        }
        public void UpdateTotalBytesSended()
        {
            BeginInvoke(new MethodInvoker(delegate ()
            {
                lblBytesSend.Text = string.Format("Bytes Sent: {0}", TotalBytesSended);
            }));
        }
        public void AddLog(string contents)
        {
            BeginInvoke(new MethodInvoker(delegate ()
            {
                LogInTextBox.AppendText(contents + "\r\n");
                LogInTextBox.ScrollToCaret();
            }));
        }
        public void AddAccount(AccountData account)
        {
            if (!AccountData.ContainsKey(account.Account))
            {
                AccountData[account.Account] = account;
                SaveAccount(account);
            }
        }
        public void SaveAccount(AccountData account)
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
            if (_network.Value.Start())
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
            _network.Value.Stop();
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
                _network.Value.Stop();
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
                AddLog("Network Configuration Loaded: " + GameServerArea);
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
        public uint TotalNewAccounts;
        public uint TotalTickets;
        public long TotalBytesReceived;
        public long TotalBytesSended;
        private readonly IAppConfiguration _config;
        private readonly Lazy<Network> _network;
        public string GameServerArea = "";
        public string DataDirectory = ".\\Accounts";
        public Dictionary<string, AccountData> AccountData;
        public Dictionary<string, IPEndPoint> ServerData;
    }
}
