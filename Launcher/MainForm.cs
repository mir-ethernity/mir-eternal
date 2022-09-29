using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Launcher.Properties;
using System.IO;
using Sunny.UI;

namespace Launcher
{
    public partial class MainForm : Form
    {
        public static int PacketNumber;
        public static string LoginAccount;
        public static string LoginPassword;
        public static Process GameProgress;
        public static MainForm CurrentForm;
        public static Dictionary<string, IPEndPoint> IPList;
        public bool Is64Bit
        {
            get
            {
                return uiCheckBox2.Checked;
            }
        }
        public bool Is32Bit
        {
            get
            {
                return uiCheckBox1.Checked;
            }
        }
        public MainForm()
        {
            InitializeComponent();
            PreLaunchChecks();
            CurrentForm = this;
            Network.MainSocket();
            IPList = new Dictionary<string, IPEndPoint>();
            start_selected_zone.Text = Settings.Default.SaveArea;
            AccountTextBox.Text = Settings.Default.SaveAccount;
        }
        public void PreLaunchChecks()
        {
            bool ClientFound32Bit = File.Exists(".\\Binaries\\Win32\\MMOGame-Win32-Shipping.exe");
            bool ClientFound64Bit = File.Exists(".\\Binaries\\Win64\\MMOGame-Win64-Shipping.exe");
            bool ServerCfgFound = File.Exists("./ServerCfg.txt");
            if (!ClientFound32Bit && !ClientFound64Bit)
            {
                MessageBox.Show("Client Cannot Be Found!\r\nPlease Read The README.txt");
                Environment.Exit(0);
            }
            if (!ServerCfgFound)
            {
                MessageBox.Show("ServerCfg.txt Cannot Be Found!\r\nPlease Read The README.txt");
                Environment.Exit(0);
            }
            string[] strArray = File.ReadAllText("./ServerCfg.txt").Trim('\r', '\n', '\t', ' ').Split(':');
            if (strArray.Length != 2)
            {
                MessageBox.Show("ServerCfg.txt Configuration Error!\r\nPlease Read The README.txt");
                Environment.Exit(0);
            }
            Network.ASAddress = new IPEndPoint(IPAddress.Parse(strArray[0]), Convert.ToInt32(strArray[1]));

            if (Environment.Is64BitOperatingSystem)
            {
                uiCheckBox1.Enabled = true;
                uiCheckBox1.Checked = false;
                uiCheckBox2.Enabled = true;
                uiCheckBox2.Checked = true;
            }
            else
            {
                uiCheckBox2.Enabled = false;
                uiCheckBox2.Checked = false;
                uiCheckBox1.Enabled = false;
                uiCheckBox1.Checked = true;
            }
        }
        public void UILock()
        {
            MainTab.Enabled = false;
            login_error_label.Visible = false;
            RegistrationErrorLabel.Visible = false;
            Modify_ErrorLabel.Visible = false;
        }
        public void PacketProcess(object sender, EventArgs e)
        {
            if (Network.UDPClient == null || Network.Packets.IsEmpty || !Network.Packets.TryDequeue(out var result))
            {
                return;
            }
            string[] array = Encoding.UTF8.GetString(result, 0, result.Length)
                .Split(' ', 3);

            if (array.Length <= 2 || !int.TryParse(array[0], out var result2) || result2 != PacketNumber)
            {
                return;
            }
            switch (array[1])
            {
                case "4":
                    var data2 = array[2].Split(' ');
                    AccountTextBox.Text = data2[0];
                    AccountPasswordTextBox.Text = data2[1];
                    UIUnlock(null, null);
                    MainTab.SelectedIndex = 0;
                    MessageBox.Show("Password Reset Completed");
                    break;
                case "5":
                    if (array.Length == 3)
                    {
                        UIUnlock(null, null);
                        Modify_ErrorLabel.Text = array[2];
                        Modify_ErrorLabel.Visible = true;
                    }
                    break;
                case "6":
                    var data4 = array[2].Split(' ');

                    IPEndPoint value;
                    if (IPList.TryGetValue(start_selected_zone.Text, out value))
                    {
                        string arguments = "-wegame=" + $"1,1,{value.Address},{value.Port}," + $"1,1,{value.Address},{value.Port}," + start_selected_zone.Text + "  " + $"/ip:1,1,{value.Address} " + $"/port:{value.Port} " + "/ticket:" + data4[2] + " /AreaName:" + start_selected_zone.Text;
                        Settings.Default.SaveArea = start_selected_zone.Text;
                        Settings.Default.Save();
                        GameProgress = new Process();

                        if (Is32Bit && Is64Bit || !Is32Bit && !Is64Bit)
                        {
                            MessageBox.Show("Error Getting OS Version");
                            Environment.Exit(0);
                        }
                        else if (Is32Bit)
                            GameProgress.StartInfo.FileName = ".\\Binaries\\Win32\\MMOGame-Win32-Shipping.exe";
                        else if (Is64Bit)
                            GameProgress.StartInfo.FileName = ".\\Binaries\\Win64\\MMOGame-Win64-Shipping.exe";

                        GameProgress.StartInfo.Arguments = arguments;
                        GameProgress.Start();
                        GameProcessTimer.Enabled = true;
                        TrayHideToTaskBar(null, null);
                        UILock();
                        InterfaceUpdateTimer.Enabled = false;
                        minimizeToTray.ShowBalloonTip(1000, "", "Game Loading Please Wait. . .", ToolTipIcon.Info);
                    }
                    break;
                case "7":
                    if (array.Length == 3)
                    {
                        UIUnlock(null, null);
                        MessageBox.Show("Failed To Start The Game" + array[2]);
                    }
                    break;
                case "0":
                    {
                        var data3 = array[2].Split(' ');
                        UIUnlock(null, null);
                        string text2 = (LoginAccount = (activate_account.Text = data3[0]));
                        LoginPassword = data3[1];
                        GameServerList.Items.Clear();
                        string[] array2 = data3[2].Split(new char[2] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < array2.Length; i++)
                        {
                            string[] array3 = array2[i].Split(new char[2] { ',', '/' }, StringSplitOptions.RemoveEmptyEntries);
                            if (array3.Length != 3)
                            {
                                MessageBox.Show("Server Data Parsing Failed");
                                Environment.Exit(0);
                            }
                            IPList[array3[2]] = new IPEndPoint(IPAddress.Parse(array3[0]), Convert.ToInt32(array3[1]));
                            GameServerList.Items.Add(array3[2]);
                        }
                        MainTab.SelectedIndex = 3;
                        Settings.Default.SaveAccount = array[2];
                        Settings.Default.Save();
                        break;
                    }
                case "1":
                    UIUnlock(null, null);
                    login_error_label.Text = array[2];
                    login_error_label.ForeColor = Color.Red;
                    login_error_label.Visible = true;
                    break;
                case "2":
                    var data = array[2].Split(' ');
                    AccountTextBox.Text = data[0];
                    AccountPasswordTextBox.Text = data[1];
                    UIUnlock(null, null);
                    MainTab.SelectedIndex = 0;
                    MessageBox.Show("Account Created Successfully");
                    break;
                case "3":
                    if (array.Length == 3)
                    {
                        UIUnlock(null, null);
                        RegistrationErrorLabel.Text = array[2];
                        RegistrationErrorLabel.Visible = true;
                        RegistrationErrorLabel.ForeColor = Color.Red;
                    }
                    break;
            }
        }
        public void UIUnlock(object sender, EventArgs e)
        {
            MainTab.Enabled = true;
            InterfaceUpdateTimer.Enabled = false;
        }
        public void GameProgressCheck(object sender, EventArgs e)
        {
            if (GameProgress == null || !MainForm.GameProgress.HasExited)
                return;
            UIUnlock(null, null);
            TrayRestoreFromTaskBar(null, null);
            GameProcessTimer.Enabled = false;
        }
        private void LoginAccountLabel_Click(object sender, EventArgs e)
        {
            if (AccountTextBox.Text.Length <= 0)
            {
                login_error_label.Text = "Account Name Cannot Be Empty";
                login_error_label.Visible = true;
            }
            else if (AccountTextBox.Text.IndexOf(' ') >= 0)
            {
                login_error_label.Text = "Account Name Cannot Contain Spaces";
                login_error_label.Visible = true;
            }
            else if (AccountPasswordTextBox.Text.Length <= 0)
            {
                login_error_label.Text = "Password Cannot Be Blank";
                login_error_label.Visible = true;
            }
            else if (AccountTextBox.Text.IndexOf(' ') >= 0)
            {
                login_error_label.Text = "Password Cannot Contain Spaces";
                login_error_label.Visible = true;
            }
            else
            {
                if (Network.SendPacket(Encoding.UTF8.GetBytes(string.Format("{0} 0 ", ++PacketNumber) + AccountTextBox.Text + " " + AccountPasswordTextBox.Text)))
                    UILock();
                AccountPasswordTextBox.Text = "";
                InterfaceUpdateTimer.Enabled = true;
            }
        }
        private void Login_ForgotPassword_Click(object sender, EventArgs e) => this.MainTab.SelectedIndex = 2;
        private void Login_Registertab_Click(object sender, EventArgs e) => this.MainTab.SelectedIndex = 1;
        public void LoginSuccefully(string loginAccount, string password)
        {
            InterfaceUpdateTimer.Enabled = false;
            login_error_label.Visible = false;
            LoginAccountLabel.Enabled = false;
            LoginAccount = loginAccount;
            LoginPassword = password;
            activate_account.Text = loginAccount;
            MainTab.SelectedIndex = 3;
        }
        public void LoginAccountFailed(string errorMsg)
        {
            MainTab.SelectedIndex = 0;
            InterfaceUpdateTimer.Enabled = false;
            login_error_label.Visible = true;
            login_error_label.Text = errorMsg;
            LoginAccountLabel.Enabled = true;
        }
        private void TrayHideToTaskBar(object sender, FormClosingEventArgs e)
        {
            minimizeToTray.Visible = true;
            Hide();
            if (e == null)
                return;
            e.Cancel = true;
        }
        private void TrayRestoreFromTaskBar(object sender, MouseEventArgs e)
        {
            if (e != null && e.Button != MouseButtons.Left)
                return;
            Visible = true;
            minimizeToTray.Visible = false;
        }
        private void Tray_Restore(object sender, EventArgs e)
        {
            Visible = true;
            minimizeToTray.Visible = false;
        }
        private void TrayCloseLauncher(object sender, EventArgs e)
        {
            minimizeToTray.Visible = false;
            Environment.Exit(Environment.ExitCode);
        }
        private void RegisterAccount_Click(object sender, EventArgs e)
        {
            if (Register_AccountNameTextBox.Text.Length <= 0)
            {
                RegistrationErrorLabel.Text = "Account Name Cannot Be Empty";
                RegistrationErrorLabel.Visible = true;
            }
            else if (Register_AccountNameTextBox.Text.IndexOf(' ') >= 0)
            {
                RegistrationErrorLabel.Text = "Account Name Cannot Contain Spaces";
                RegistrationErrorLabel.Visible = true;
            }
            else if (Register_AccountNameTextBox.Text.Length <= 5 || Register_AccountNameTextBox.Text.Length > 12)
            {
                RegistrationErrorLabel.Text = "Account Name Must Be 6 to 12 Characters Long";
                RegistrationErrorLabel.Visible = true;
            }
            else if (!Regex.IsMatch(Register_AccountNameTextBox.Text, "^[a-zA-Z]+.*$"))
            {
                RegistrationErrorLabel.Text = "Account Name Must Start With A Letter";
                RegistrationErrorLabel.Visible = true;
            }
            else if (!Regex.IsMatch(Register_AccountNameTextBox.Text, "^[a-zA-Z_][A-Za-z0-9_]*$"))
            {
                RegistrationErrorLabel.Text = "Account Name Can Only Contain Alphanumeric and Underscores";
                RegistrationErrorLabel.Visible = true;
            }
            else if (Register_PasswordTextBox.Text.Length <= 0)
            {
                RegistrationErrorLabel.Text = "Password Cannot Be Blank";
                RegistrationErrorLabel.Visible = true;
            }
            else if (Register_PasswordTextBox.Text.IndexOf(' ') >= 0)
            {
                RegistrationErrorLabel.Text = "Password Cannot Contain Spaces";
                RegistrationErrorLabel.Visible = true;
            }
            else if (Register_PasswordTextBox.Text.Length <= 5 || Register_PasswordTextBox.Text.Length > 18)
            {
                RegistrationErrorLabel.Text = "Password Must Be 6 to 18 Characters Long";
                RegistrationErrorLabel.Visible = true;
            }
            else if (Register_QuestionTextBox.Text.Length <= 0)
            {
                RegistrationErrorLabel.Text = "Security Question Cannot Be Empty";
                RegistrationErrorLabel.Visible = true;
            }
            else if (Register_QuestionTextBox.Text.IndexOf(' ') >= 0)
            {
                RegistrationErrorLabel.Text = "Security Question Cannot Contain Spaces";
                RegistrationErrorLabel.Visible = true;
            }
            else if (Register_QuestionTextBox.Text.Length <= 1 || Register_QuestionTextBox.Text.Length > 18)
            {
                RegistrationErrorLabel.Text = "Security Question Must Be 2 to 18 Characters Long";
                RegistrationErrorLabel.Visible = true;
            }
            else if (Register_SecretAnswerTextBox.Text.Length <= 0)
            {
                RegistrationErrorLabel.Text = "Security Answer Cannot Be Empty";
                RegistrationErrorLabel.Visible = true;
            }
            else if (Register_SecretAnswerTextBox.Text.IndexOf(' ') >= 0)
            {
                RegistrationErrorLabel.Text = "Security Answer Cannot Contain Spaces";
                RegistrationErrorLabel.Visible = true;
            }
            else if (Register_SecretAnswerTextBox.Text.Length <= 1 || Register_SecretAnswerTextBox.Text.Length > 18)
            {
                RegistrationErrorLabel.Text = "Security Answer Must Be 2 to 18 Characters Long";
                RegistrationErrorLabel.Visible = true;
            }
            else
            {
                if (Network.SendPacket(Encoding.UTF8.GetBytes(string.Format("{0} 1 ", ++PacketNumber) + Register_AccountNameTextBox.Text + " " + Register_PasswordTextBox.Text + " " + Register_QuestionTextBox.Text + " " + Register_SecretAnswerTextBox.Text)))
                    UILock();
                Register_PasswordTextBox.Text = Register_SecretAnswerTextBox.Text = "";
                InterfaceUpdateTimer.Enabled = true;
            }
        }
        private void RegisterBackToLogin_Click(object sender, EventArgs e) => this.MainTab.SelectedIndex = 0;
        private void Modify_ChangePassword_Click(object sender, EventArgs e)
        {
            if (Modify_AccountNameTextBox.Text.Length <= 0)
            {
                Modify_ErrorLabel.Text = "Account Name Cannot Be Empty";
                Modify_ErrorLabel.Visible = true;
            }
            else if (Modify_AccountNameTextBox.Text.IndexOf(' ') >= 0)
            {
                Modify_ErrorLabel.Text = "Account Name Cannot Contain Spaces";
                Modify_ErrorLabel.Visible = true;
            }
            else if (Modify_PasswordTextBox.Text.Length <= 0)
            {
                Modify_ErrorLabel.Text = "Password Cannot Be Empty";
                Modify_ErrorLabel.Visible = true;
            }
            else if (Modify_PasswordTextBox.Text.IndexOf(' ') >= 0)
            {
                Modify_ErrorLabel.Text = "Password Cannot Contain Spaces";
                Modify_ErrorLabel.Visible = true;
            }
            else if (Modify_PasswordTextBox.Text.Length <= 5 || Modify_PasswordTextBox.Text.Length > 18)
            {
                Modify_ErrorLabel.Text = "Password Must Be 6 to 18 Characters Long";
                Modify_ErrorLabel.Visible = true;
            }
            else if (Modify_QuestionTextBox.Text.Length <= 0)
            {
                Modify_ErrorLabel.Text = "Security Question Cannot Be Empty";
                Modify_ErrorLabel.Visible = true;
            }
            else if (Modify_QuestionTextBox.Text.IndexOf(' ') >= 0)
            {
                Modify_ErrorLabel.Text = "Security Question Cannot Contain Spaces";
                Modify_ErrorLabel.Visible = true;
            }
            else if (Modify_AnswerTextBox.Text.Length <= 0)
            {
                Modify_ErrorLabel.Text = "Security Answer Cannot Be Empty";
                Modify_ErrorLabel.Visible = true;
            }
            else if (Modify_AnswerTextBox.Text.IndexOf(' ') >= 0)
            {
                Modify_ErrorLabel.Text = "Security Answer Cannot Contain Spaces";
                Modify_ErrorLabel.Visible = true;
            }
            else
            {
                if (Network.SendPacket(Encoding.UTF8.GetBytes(string.Format("{0} 2 ", ++PacketNumber) + Modify_AccountNameTextBox.Text + " " + Modify_PasswordTextBox.Text + " " + Modify_QuestionTextBox.Text + " " + Modify_AnswerTextBox.Text)))
                    UILock();
                Modify_PasswordTextBox.Text = Modify_AnswerTextBox.Text = "";
                InterfaceUpdateTimer.Enabled = true;
            }
        }
        private void Modify_BackToLogin_Click(object sender, EventArgs e) => this.MainTab.SelectedIndex = 0;
        private void Launch_EnterGame_Click(object sender, EventArgs e)
        {
            if (LoginAccount == null || LoginAccount == "")
                MainTab.SelectedIndex = 0;
            else if (start_selected_zone.Text == null || start_selected_zone.Text == "")
            {
                MessageBox.Show("You Must Select A Server");
            }
            else if (!IPList.ContainsKey(start_selected_zone.Text))
            {
                MessageBox.Show("Server Selection Error");
            }
            else
            {
                if (!Network.SendPacket(Encoding.UTF8.GetBytes(string.Format("{0} 3 ", ++PacketNumber) + LoginAccount + " " + LoginPassword + " " + start_selected_zone.Text + " v1.0")))
                    return;
                UILock();
                InterfaceUpdateTimer.Enabled = true;
            }
        }
        private void LogoutTab_Click(object sender, EventArgs e)
        {
            LoginAccount = (string)null;
            LoginPassword = (string)null;
            MainTab.SelectedIndex = 0;
        }
        private void StartupChoosegameServer_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
            StringFormat format = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            e.Graphics.DrawString(this.GameServerList.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), (RectangleF)e.Bounds, format);
        }
        private void StartupChooseGS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GameServerList.SelectedIndex < 0)
                start_selected_zone.Text = "";
            else
                start_selected_zone.Text = GameServerList.Items[GameServerList.SelectedIndex].ToString();
        }
        private void Login_PasswordKeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AccountPasswordTextBox.Text)) return;
            if (e.KeyChar != (char)13) return;
            LoginAccountLabel_Click(sender, null);
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void pictureBox3_MouseClick(object sender, MouseEventArgs e)
        {
            Environment.Exit(0);
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void uiCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            uiCheckBox2.Checked = !uiCheckBox1.Checked;
        }

        private void uiCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            uiCheckBox1.Checked = !uiCheckBox2.Checked;
        }
    }
}
