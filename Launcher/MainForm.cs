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
            byte[] result1;
            if (Network.UDPClient == null || Network.Packets.IsEmpty || !Network.Packets.TryDequeue(out result1))
                return;
            string[] strArray1 = Encoding.UTF8.GetString(result1, 0, result1.Length).Split(new char[1]
            {
        ' '
            }, StringSplitOptions.RemoveEmptyEntries);
            int result2;
            if (strArray1.Length <= 2 || !int.TryParse(strArray1[0], out result2) || result2 != MainForm.PacketNumber)
                return;
            string s = strArray1[1];
            // ISSUE: reference to a compiler-generated method
            switch (PrivateImplementationDetails.ComputeStringHash(s))
            {
                case 806133968:
                    if (!(s == "5") || strArray1.Length != 3)
                        break;
                    this.UIUnlock((object)null, (EventArgs)null);
                    this.Modify_ErrorLabel.Text = strArray1[2];
                    this.Modify_ErrorLabel.Visible = true;
                    break;
                case 822911587:
                    if (!(s == "4") || strArray1.Length != 4)
                        break;
                    this.UIUnlock((object)null, (EventArgs)null);
                    int num1 = (int)MessageBox.Show("Password reset complete!");
                    break;
                case 839689206:
                    if (!(s == "7") || strArray1.Length != 3)
                        break;
                    this.UIUnlock((object)null, (EventArgs)null);
                    int num2 = (int)MessageBox.Show("Failed to start the game! " + strArray1[2]);
                    break;
                case 856466825:
                    if (!(s == "6") || strArray1.Length != 5)
                        break;
                    if (!System.IO.File.Exists(".\\Binaries\\Win32\\MMOGame-Win32-Shipping.exe"))
                    {
                        int num3 = (int)MessageBox.Show("The game exe cannot be found.");
                        this.InterfaceUpdateTimer.Enabled = false;
                        this.UIUnlock((object)null, (EventArgs)null);
                        break;
                    }
                    IPEndPoint ipEndPoint;
                    if (!MainForm.IPList.TryGetValue(this.start_selected_zone.Text, out ipEndPoint))
                        break;
                    string str1 = "-wegame=" + string.Format("1,1,{0},{1},", (object)ipEndPoint.Address, (object)ipEndPoint.Port) + string.Format("1,1,{0},{1},", (object)ipEndPoint.Address, (object)ipEndPoint.Port) + this.start_selected_zone.Text + "  " + string.Format("/ip:1,1,{0} ", (object)ipEndPoint.Address) + string.Format("/port:{0} ", (object)ipEndPoint.Port) + "/ticket:" + strArray1[4] + " /AreaName:" + this.start_selected_zone.Text;

                    // last chinese connection string
                    // -sdo -ip=1,1,175.24.251.29,8701,175.24.251.29,8701,??

                    Settings.Default.SaveArea = this.start_selected_zone.Text;
                    Settings.Default.Save();
                    MainForm.GameProgress = new Process();
                    MainForm.GameProgress.StartInfo.FileName = ".\\Binaries\\Win32\\MMOGame-Win32-Shipping.exe";
                    MainForm.GameProgress.StartInfo.Arguments = str1;
                    MainForm.GameProgress.Start();
                    this.GameProcessTimer.Enabled = true;
                    this.TrayHideToTaskBar((object)null, (FormClosingEventArgs)null);
                    this.UILock();
                    this.InterfaceUpdateTimer.Enabled = false;
                    this.minimizeToTray.ShowBalloonTip(1000, "", "Starting the Game, please wait...", ToolTipIcon.Info);
                    break;
                case 873244444:
                    if (!(s == "1") || strArray1.Length != 3)
                        break;
                    this.UIUnlock((object)null, (EventArgs)null);
                    this.login_error_label.Text = strArray1[2];
                    this.login_error_label.Visible = true;
                    break;
                case 890022063:
                    if (!(s == "0") || strArray1.Length != 5)
                        break;
                    this.UIUnlock((object)null, (EventArgs)null);
                    MainForm.LoginAccount = this.activate_account.Text = strArray1[2];
                    MainForm.LoginPassword = strArray1[3];
                    this.GameServerList.Items.Clear();
                    string str2 = strArray1[4];
                    char[] separator1 = new char[2] { '\r', '\n' };
                    foreach (string str3 in str2.Split(separator1, StringSplitOptions.RemoveEmptyEntries))
                    {
                        char[] separator2 = new char[2] { ',', '/' };
                        string[] strArray2 = str3.Split(separator2, StringSplitOptions.RemoveEmptyEntries);
                        if (strArray2.Length != 3)
                        {
                            int num4 = (int)MessageBox.Show("Server data parsing failed!");
                            Environment.Exit(0);
                        }
                        MainForm.IPList[strArray2[2]] = new IPEndPoint(IPAddress.Parse(strArray2[0]), Convert.ToInt32(strArray2[1]));
                        this.GameServerList.Items.Add((object)strArray2[2]);
                    }
                    this.MainTab.SelectedIndex = 3;
                    Settings.Default.SaveAccount = strArray1[2];
                    Settings.Default.Save();
                    break;
                case 906799682:
                    if (!(s == "3") || strArray1.Length != 3)
                        break;
                    this.UIUnlock((object)null, (EventArgs)null);
                    this.RegistrationErrorLabel.Text = strArray1[2];
                    this.RegistrationErrorLabel.Visible = true;
                    break;
                case 923577301:
                    if (!(s == "2") || strArray1.Length != 4)
                        break;
                    this.UIUnlock((object)null, (EventArgs)null);
                    int num5 = (int)MessageBox.Show("Account registration successful");
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
