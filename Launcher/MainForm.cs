using Sunny.UI;
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


        public MainForm()
        {
            this.InitializeComponent();
            MainForm.CurrentForm = this;
            Network.MainSocket();
            MainForm.IPList = new Dictionary<string, IPEndPoint>();
            this.start_selected_zone.Text = Settings.Default.SaveArea;
            this.AccountTextBox.Text = Settings.Default.SaveAccount;
            if (!System.IO.File.Exists(".\\Binaries\\Win32\\MMOGame-Win32-Shipping.exe"))
            {
                int num = (int)MessageBox.Show("The game exe cannot be found.");
                Environment.Exit(0);
            }
            if (!System.IO.File.Exists("./ServerCfg.txt"))
            {
                int num = (int)MessageBox.Show("The file ./ServerCfg.txt dont exists or cant be loaded.");
                Environment.Exit(0);
            }
            string[] strArray = System.IO.File.ReadAllText("./ServerCfg.txt").Trim('\r', '\n', '\t', ' ').Split(':');
            if (strArray.Length != 2)
            {
                int num = (int)MessageBox.Show("Server information error.");
                Environment.Exit(0);
            }
            Network.ASAddress = new IPEndPoint(IPAddress.Parse(strArray[0]), Convert.ToInt32(strArray[1]));
        }

        public void UILock()
        {
            this.MainTab.Enabled = false;
            this.login_error_label.Visible = false;
            this.RegistrationErrorLabel.Visible = false;
            this.Modify_ErrorLabel.Visible = false;
        }

        public void PacketProcess(object sender, EventArgs e)
        {
            if (Network.UDPClient == null || Network.Packets.IsEmpty || !Network.Packets.TryDequeue(out var result))
            {
                return;
            }
            string[] array = Encoding.UTF8.GetString(result, 0, result.Length).Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (array.Length <= 2 || !int.TryParse(array[0], out var result2) || result2 != PacketNumber)
            {
                return;
            }
            switch (array[1])
            {
                case "4":
                    if (array.Length == 4)
                    {
                        UIUnlock(null, null);
                        MessageBox.Show("Password reset complete!");
                    }
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
                    if (array.Length == 5)
                    {
                        IPEndPoint value;
                        if (!File.Exists(".\\Binaries\\Win32\\MMOGame-Win32-Shipping.exe"))
                        {
                            MessageBox.Show("The game exe cannot be found.");
                            InterfaceUpdateTimer.Enabled = false;
                            UIUnlock(null, null);
                        }
                        else if (IPList.TryGetValue(start_selected_zone.Text, out value))
                        {
                            string arguments = "-wegame=" + $"1,1,{value.Address},{value.Port}," + $"1,1,{value.Address},{value.Port}," + start_selected_zone.Text + "  " + $"/ip:1,1,{value.Address} " + $"/port:{value.Port} " + "/ticket:" + array[4] + " /AreaName:" + start_selected_zone.Text;
                            Settings.Default.SaveArea = start_selected_zone.Text;
                            Settings.Default.Save();
                            GameProgress = new Process();
                            GameProgress.StartInfo.FileName = ".\\Binaries\\Win32\\MMOGame-Win32-Shipping.exe";
                            GameProgress.StartInfo.Arguments = arguments;
                            GameProgress.Start();
                            GameProcessTimer.Enabled = true;
                            TrayHideToTaskBar(null, null);
                            UILock();
                            InterfaceUpdateTimer.Enabled = false;
                            minimizeToTray.ShowBalloonTip(1000, "", "Starting the Game, please wait...", ToolTipIcon.Info);
                        }
                    }
                    break;
                case "7":
                    if (array.Length == 3)
                    {
                        UIUnlock(null, null);
                        MessageBox.Show("Failed to start the game! " + array[2]);
                    }
                    break;
                case "0":
                    {
                        if (array.Length != 5)
                        {
                            break;
                        }
                        UIUnlock(null, null);
                        string text2 = (LoginAccount = (activate_account.Text = array[2]));
                        LoginPassword = array[3];
                        GameServerList.Items.Clear();
                        string[] array2 = array[4].Split(new char[2] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < array2.Length; i++)
                        {
                            string[] array3 = array2[i].Split(new char[2] { ',', '/' }, StringSplitOptions.RemoveEmptyEntries);
                            if (array3.Length != 3)
                            {
                                MessageBox.Show("Server data parsing failed!");
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
                    if (array.Length == 3)
                    {
                        UIUnlock(null, null);
                        RegistrationErrorLabel.Text = array[2];
                        RegistrationErrorLabel.Visible = true;
                    }
                    break;
                case "2":
                    if (array.Length == 4)
                    {
                        UIUnlock(null, null);
                        MessageBox.Show("账号注册成功");
                    }
                    break;
                case "3":
                    if (array.Length == 3)
                    {
                        UIUnlock(null, null);
                        RegistrationErrorLabel.Text = array[2];
                        RegistrationErrorLabel.Visible = true;
                    }
                    break;
            }
        }

        public void UIUnlock(object sender, EventArgs e)
        {
            this.MainTab.Enabled = true;
            this.InterfaceUpdateTimer.Enabled = false;
        }

        public void GameProgressCheck(object sender, EventArgs e)
        {
            if (MainForm.GameProgress == null || !MainForm.GameProgress.HasExited)
                return;
            this.UIUnlock((object)null, (EventArgs)null);
            this.TrayRestoreFromTaskBar((object)null, (MouseEventArgs)null);
            this.GameProcessTimer.Enabled = false;
        }

        private void LoginAccountLabel_Click(object sender, EventArgs e)
        {
            if (this.AccountTextBox.Text.Length <= 0)
            {
                this.login_error_label.Text = "Username can not be empty";
                this.login_error_label.Visible = true;
            }
            else if (this.AccountTextBox.Text.IndexOf(' ') >= 0)
            {
                this.login_error_label.Text = "Username cannot contain spaces";
                this.login_error_label.Visible = true;
            }
            else if (this.AccountPasswordTextBox.Text.Length <= 0)
            {
                this.login_error_label.Text = "Password can not be blank";
                this.login_error_label.Visible = true;
            }
            else if (this.AccountTextBox.Text.IndexOf(' ') >= 0)
            {
                this.login_error_label.Text = "Password cannot contain spaces";
                this.login_error_label.Visible = true;
            }
            else
            {
                if (Network.SendPacket(Encoding.UTF8.GetBytes(string.Format("{0} 0 ", (object)++MainForm.PacketNumber) + this.AccountTextBox.Text + " " + this.AccountPasswordTextBox.Text)))
                    this.UILock();
                this.AccountPasswordTextBox.Text = "";
                this.InterfaceUpdateTimer.Enabled = true;
            }
        }

        private void Login_ForgotPassword_Click(object sender, EventArgs e) => this.MainTab.SelectedIndex = 2;

        private void Login_Registertab_Click(object sender, EventArgs e) => this.MainTab.SelectedIndex = 1;

        public void LoginSuccefully(string loginAccount, string password)
        {
            this.InterfaceUpdateTimer.Enabled = false;
            this.login_error_label.Visible = false;
            this.LoginAccountLabel.Enabled = false;
            MainForm.LoginAccount = loginAccount;
            MainForm.LoginPassword = password;
            this.activate_account.Text = loginAccount;
            this.MainTab.SelectedIndex = 3;
        }

        public void LoginAccountFailed(string errorMsg)
        {
            this.MainTab.SelectedIndex = 0;
            this.InterfaceUpdateTimer.Enabled = false;
            this.login_error_label.Visible = true;
            this.login_error_label.Text = errorMsg;
            this.LoginAccountLabel.Enabled = true;
        }

        private void TrayHideToTaskBar(object sender, FormClosingEventArgs e)
        {
            this.minimizeToTray.Visible = true;
            this.Hide();
            if (e == null)
                return;
            e.Cancel = true;
        }

        private void TrayRestoreFromTaskBar(object sender, MouseEventArgs e)
        {
            if (e != null && e.Button != MouseButtons.Left)
                return;
            this.Visible = true;
            this.minimizeToTray.Visible = false;
        }

        private void Tray_Restore(object sender, EventArgs e)
        {
            this.Visible = true;
            this.minimizeToTray.Visible = false;
        }

        private void TrayCloseLauncher(object sender, EventArgs e)
        {
            this.minimizeToTray.Visible = false;
            Environment.Exit(Environment.ExitCode);
        }

        private void RegisterAccount_Click(object sender, EventArgs e)
        {
            if (this.Register_AccountNameTextBox.Text.Length <= 0)
            {
                this.RegistrationErrorLabel.Text = "Username cannot be empty";
                this.RegistrationErrorLabel.Visible = true;
            }
            else if (this.Register_AccountNameTextBox.Text.IndexOf(' ') >= 0)
            {
                this.RegistrationErrorLabel.Text = "Username cannot contain spaces";
                this.RegistrationErrorLabel.Visible = true;
            }
            else if (this.Register_AccountNameTextBox.Text.Length <= 5 || this.Register_AccountNameTextBox.Text.Length > 12)
            {
                this.RegistrationErrorLabel.Text = "Username can be from 6 to 12 characters of length";
                this.RegistrationErrorLabel.Visible = true;
            }
            else if (!Regex.IsMatch(this.Register_AccountNameTextBox.Text, "^[a-zA-Z]+.*$"))
            {
                this.RegistrationErrorLabel.Text = "Username can only start with a letter";
                this.RegistrationErrorLabel.Visible = true;
            }
            else if (!Regex.IsMatch(this.Register_AccountNameTextBox.Text, "^[a-zA-Z_][A-Za-z0-9_]*$"))
            {
                this.RegistrationErrorLabel.Text = "Username can only contain alphanumerics and underscores";
                this.RegistrationErrorLabel.Visible = true;
            }
            else if (this.Register_PasswordTextBox.Text.Length <= 0)
            {
                this.RegistrationErrorLabel.Text = "password can not be blank";
                this.RegistrationErrorLabel.Visible = true;
            }
            else if (this.Register_PasswordTextBox.Text.IndexOf(' ') >= 0)
            {
                this.RegistrationErrorLabel.Text = "Password cannot contain spaces";
                this.RegistrationErrorLabel.Visible = true;
            }
            else if (this.Register_PasswordTextBox.Text.Length <= 5 || this.Register_PasswordTextBox.Text.Length > 18)
            {
                this.RegistrationErrorLabel.Text = "Password can be from 6 to 18 characters of length";
                this.RegistrationErrorLabel.Visible = true;
            }
            else if (this.Register_QuestionTextBox.Text.Length <= 0)
            {
                this.RegistrationErrorLabel.Text = "Security question cannot be empty";
                this.RegistrationErrorLabel.Visible = true;
            }
            else if (this.Register_QuestionTextBox.Text.IndexOf(' ') >= 0)
            {
                this.RegistrationErrorLabel.Text = "Security questions cannot contain spaces";
                this.RegistrationErrorLabel.Visible = true;
            }
            else if (this.Register_QuestionTextBox.Text.Length <= 1 || this.Register_QuestionTextBox.Text.Length > 18)
            {
                this.RegistrationErrorLabel.Text = "The security question can only be 2-18 digits";
                this.RegistrationErrorLabel.Visible = true;
            }
            else if (this.Register_SecretAnswerTextBox.Text.Length <= 0)
            {
                this.RegistrationErrorLabel.Text = "Secret answer cannot be empty";
                this.RegistrationErrorLabel.Visible = true;
            }
            else if (this.Register_SecretAnswerTextBox.Text.IndexOf(' ') >= 0)
            {
                this.RegistrationErrorLabel.Text = "The secret answer cannot contain spaces";
                this.RegistrationErrorLabel.Visible = true;
            }
            else if (this.Register_SecretAnswerTextBox.Text.Length <= 1 || this.Register_SecretAnswerTextBox.Text.Length > 18)
            {
                this.RegistrationErrorLabel.Text = "The security question can only be 2-18 digits";
                this.RegistrationErrorLabel.Visible = true;
            }
            else
            {
                if (Network.SendPacket(Encoding.UTF8.GetBytes(string.Format("{0} 1 ", (object)++MainForm.PacketNumber) + this.Register_AccountNameTextBox.Text + " " + this.Register_PasswordTextBox.Text + " " + this.Register_QuestionTextBox.Text + " " + this.Register_SecretAnswerTextBox.Text)))
                    this.UILock();
                this.Register_PasswordTextBox.Text = this.Register_SecretAnswerTextBox.Text = "";
                this.InterfaceUpdateTimer.Enabled = true;
            }
        }

        private void RegisterBackToLogin_Click(object sender, EventArgs e) => this.MainTab.SelectedIndex = 0;

        private void Modify_ChangePassword_Click(object sender, EventArgs e)
        {
            if (this.Modify_AccountNameTextBox.Text.Length <= 0)
            {
                this.Modify_ErrorLabel.Text = "Username can not be empty";
                this.Modify_ErrorLabel.Visible = true;
            }
            else if (this.Modify_AccountNameTextBox.Text.IndexOf(' ') >= 0)
            {
                this.Modify_ErrorLabel.Text = "Username cannot contain spaces";
                this.Modify_ErrorLabel.Visible = true;
            }
            else if (this.Modify_PasswordTextBox.Text.Length <= 0)
            {
                this.Modify_ErrorLabel.Text = "password can not be blank";
                this.Modify_ErrorLabel.Visible = true;
            }
            else if (this.Modify_PasswordTextBox.Text.IndexOf(' ') >= 0)
            {
                this.Modify_ErrorLabel.Text = "Password cannot contain spaces";
                this.Modify_ErrorLabel.Visible = true;
            }
            else if (this.Modify_PasswordTextBox.Text.Length <= 5 || this.Modify_PasswordTextBox.Text.Length > 18)
            {
                this.Modify_ErrorLabel.Text = "Password length can only be 6-18 characters";
                this.Modify_ErrorLabel.Visible = true;
            }
            else if (this.Modify_QuestionTextBox.Text.Length <= 0)
            {
                this.Modify_ErrorLabel.Text = "Security question cannot be empty";
                this.Modify_ErrorLabel.Visible = true;
            }
            else if (this.Modify_QuestionTextBox.Text.IndexOf(' ') >= 0)
            {
                this.Modify_ErrorLabel.Text = "Security questions cannot contain spaces";
                this.Modify_ErrorLabel.Visible = true;
            }
            else if (this.Modify_AnswerTextBox.Text.Length <= 0)
            {
                this.Modify_ErrorLabel.Text = "Secret answer cannot be empty";
                this.Modify_ErrorLabel.Visible = true;
            }
            else if (this.Modify_AnswerTextBox.Text.IndexOf(' ') >= 0)
            {
                this.Modify_ErrorLabel.Text = "The secret answer cannot contain spaces";
                this.Modify_ErrorLabel.Visible = true;
            }
            else
            {
                if (Network.SendPacket(Encoding.UTF8.GetBytes(string.Format("{0} 2 ", (object)++MainForm.PacketNumber) + this.Modify_AccountNameTextBox.Text + " " + this.Modify_PasswordTextBox.Text + " " + this.Modify_QuestionTextBox.Text + " " + this.Modify_AnswerTextBox.Text)))
                    this.UILock();
                this.Modify_PasswordTextBox.Text = this.Modify_AnswerTextBox.Text = "";
                this.InterfaceUpdateTimer.Enabled = true;
            }
        }

        private void Modify_BackToLogin_Click(object sender, EventArgs e) => this.MainTab.SelectedIndex = 0;

        private void Launch_EnterGame_Click(object sender, EventArgs e)
        {
            if (MainForm.LoginAccount == null || MainForm.LoginAccount == "")
                this.MainTab.SelectedIndex = 0;
            else if (this.start_selected_zone.Text == null || this.start_selected_zone.Text == "")
            {
                int num1 = (int)MessageBox.Show("Please choose the server");
            }
            else if (!MainForm.IPList.ContainsKey(this.start_selected_zone.Text))
            {
                int num2 = (int)MessageBox.Show("Server selection error");
            }
            else
            {
                if (!Network.SendPacket(Encoding.UTF8.GetBytes(string.Format("{0} 3 ", (object)++MainForm.PacketNumber) + MainForm.LoginAccount + " " + MainForm.LoginPassword + " " + this.start_selected_zone.Text + " v1.0")))
                    return;
                this.UILock();
                this.InterfaceUpdateTimer.Enabled = true;
            }
        }

        private void LogoutTab_Click(object sender, EventArgs e)
        {
            MainForm.LoginAccount = (string)null;
            MainForm.LoginPassword = (string)null;
            this.MainTab.SelectedIndex = 0;
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
            e.Graphics.DrawString(this.GameServerList.Items[e.Index].ToString(), e.Font, (Brush)new SolidBrush(e.ForeColor), (RectangleF)e.Bounds, format);
        }

        private void StartupChooseGS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.GameServerList.SelectedIndex < 0)
                this.start_selected_zone.Text = "";
            else
                this.start_selected_zone.Text = this.GameServerList.Items[this.GameServerList.SelectedIndex].ToString();
        }
    }
}
