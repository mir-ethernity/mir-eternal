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
    public class MainForm : Form
  {
    public static int PacketNumber;
    public static string LoginAccount;
    public static string LoginPassword;
    public static Process GameProgress;
    public static MainForm CurrentForm;
    public static Dictionary<string, IPEndPoint> IPList;
    private IContainer components;
    private TabPage AccountLoginTab;
    private UILinkLabel ForgotPasswordLabel;
    private UISymbolButton RegisterAccountLabel;
    private UISymbolButton LoginAccountLabel;
    private UITextBox AccountPasswordTextBox;
    private UITextBox AccountTextBox;
    private UIAvatar Login_userIcon;
    private TabPage RegistrationTab;
    private TabPage ChangePasswordTab;
    private TabPage StartGameTab;
    private UISymbolButton Register_AccountBtn;
    private UITextBox Register_SecretAnswerTextBox;
    private UITextBox Register_PasswordTextBox;
    private UITextBox Register_QuestionTextBox;
    private UITextBox Register_AccountNameTextBox;
    private UISymbolButton Modify_PasswordBtn;
    private UITextBox Modify_AnswerTextBox;
    private UITextBox Modify_PasswordTextBox;
    private UITextBox Modify_QuestionTextBox;
    private UITextBox Modify_AccountNameTextBox;
    private UIButton Launcher_enterGameBtn;
    private UILabel RegistrationErrorLabel;
    private UILabel Modify_ErrorLabel;
    private ListBox GameServerList;
    private UILinkLabel start_selected_zone;
    private UILinkLabel logoutLabel;
    private UISymbolButton Register_Back_To_LoginBtn;
    private UISymbolButton Modify_Back_To_LoginBtn;
    private System.Windows.Forms.Timer InterfaceUpdateTimer;
    public UITabControl MainTab;
    public UILabel login_error_label;
    private System.Windows.Forms.Timer DataProcessTimer;
    private UILabel selected_tab;
    private UISymbolButton activate_account;
    private NotifyIcon minimizeToTray;
    private ContextMenuStrip TrayRightClickMenu;
    private ToolStripMenuItem OpenToolStripMenuItem;
    private ToolStripMenuItem QuitToolStripMenuItem;
    private System.Windows.Forms.Timer GameProcessTimer;

    public MainForm()
    {
      this.InitializeComponent();
      MainForm.CurrentForm = this;
      Comunication.MainSocket();
      MainForm.IPList = new Dictionary<string, IPEndPoint>();
      this.start_selected_zone.Text = Settings.Default.SaveArea;
      this.AccountTextBox.Text = Settings.Default.SaveAccount;
      if (!System.IO.File.Exists(".\\Binaries\\Win32\\MMOGame-Win32-Shipping.exe"))
      {
        int num = (int) MessageBox.Show("The game exe cannot be found.");
        Environment.Exit(0);
      }
      if (!System.IO.File.Exists("./ServerCfg.txt"))
      {
        int num = (int) MessageBox.Show("The file ./ServerCfg.txt dont exists or cant be loaded.");
        Environment.Exit(0);
      }
      string[] strArray = System.IO.File.ReadAllText("./ServerCfg.txt").Trim('\r', '\n', '\t', ' ').Split(':');
      if (strArray.Length != 2)
      {
        int num = (int) MessageBox.Show("Server information error.");
        Environment.Exit(0);
      }
      Comunication.ip = new IPEndPoint(IPAddress.Parse(strArray[0]), Convert.ToInt32(strArray[1]));
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
      if (Comunication.udpClient == null || Comunication.Packets.IsEmpty || !Comunication.Packets.TryDequeue(out result1))
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
          this.UIUnlock((object) null, (EventArgs) null);
          this.Modify_ErrorLabel.Text = strArray1[2];
          this.Modify_ErrorLabel.Visible = true;
          break;
        case 822911587:
          if (!(s == "4") || strArray1.Length != 4)
            break;
          this.UIUnlock((object) null, (EventArgs) null);
          int num1 = (int) MessageBox.Show("Password reset complete!");
          break;
        case 839689206:
          if (!(s == "7") || strArray1.Length != 3)
            break;
          this.UIUnlock((object) null, (EventArgs) null);
          int num2 = (int) MessageBox.Show("Failed to start the game! " + strArray1[2]);
          break;
        case 856466825:
          if (!(s == "6") || strArray1.Length != 5)
            break;
          if (!System.IO.File.Exists(".\\Binaries\\Win32\\MMOGame-Win32-Shipping.exe"))
          {
            int num3 = (int) MessageBox.Show("The game exe cannot be found.");
            this.InterfaceUpdateTimer.Enabled = false;
            this.UIUnlock((object) null, (EventArgs) null);
            break;
          }
          IPEndPoint ipEndPoint;
          if (!MainForm.IPList.TryGetValue(this.start_selected_zone.Text, out ipEndPoint))
            break;
          string str1 = "-wegame=" + string.Format("1,1,{0},{1},", (object) ipEndPoint.Address, (object) ipEndPoint.Port) + string.Format("1,1,{0},{1},", (object) ipEndPoint.Address, (object) ipEndPoint.Port) + this.start_selected_zone.Text + "  " + string.Format("/ip:1,1,{0} ", (object) ipEndPoint.Address) + string.Format("/port:{0} ", (object) ipEndPoint.Port) + "/ticket:" + strArray1[4] + " /AreaName:" + this.start_selected_zone.Text;
          Settings.Default.SaveArea = this.start_selected_zone.Text;
          Settings.Default.Save();
          MainForm.GameProgress = new Process();
          MainForm.GameProgress.StartInfo.FileName = ".\\Binaries\\Win32\\MMOGame-Win32-Shipping.exe";
          MainForm.GameProgress.StartInfo.Arguments = str1;
          MainForm.GameProgress.Start();
          this.GameProcessTimer.Enabled = true;
          this.TrayHideToTaskBar((object) null, (FormClosingEventArgs) null);
          this.UILock();
          this.InterfaceUpdateTimer.Enabled = false;
          this.minimizeToTray.ShowBalloonTip(1000, "", "Starting the Game, please wait...", ToolTipIcon.Info);
          break;
        case 873244444:
          if (!(s == "1") || strArray1.Length != 3)
            break;
          this.UIUnlock((object) null, (EventArgs) null);
          this.login_error_label.Text = strArray1[2];
          this.login_error_label.Visible = true;
          break;
        case 890022063:
          if (!(s == "0") || strArray1.Length != 5)
            break;
          this.UIUnlock((object) null, (EventArgs) null);
          MainForm.LoginAccount = this.activate_account.Text = strArray1[2];
          MainForm.LoginPassword = strArray1[3];
          this.GameServerList.Items.Clear();
          string str2 = strArray1[4];
          char[] separator1 = new char[2]{ '\r', '\n' };
          foreach (string str3 in str2.Split(separator1, StringSplitOptions.RemoveEmptyEntries))
          {
            char[] separator2 = new char[2]{ ',', '/' };
            string[] strArray2 = str3.Split(separator2, StringSplitOptions.RemoveEmptyEntries);
            if (strArray2.Length != 3)
            {
              int num4 = (int) MessageBox.Show("Server data parsing failed!");
              Environment.Exit(0);
            }
            MainForm.IPList[strArray2[2]] = new IPEndPoint(IPAddress.Parse(strArray2[0]), Convert.ToInt32(strArray2[1]));
            this.GameServerList.Items.Add((object) strArray2[2]);
          }
          this.MainTab.SelectedIndex = 3;
          Settings.Default.SaveAccount = strArray1[2];
          Settings.Default.Save();
          break;
        case 906799682:
          if (!(s == "3") || strArray1.Length != 3)
            break;
          this.UIUnlock((object) null, (EventArgs) null);
          this.RegistrationErrorLabel.Text = strArray1[2];
          this.RegistrationErrorLabel.Visible = true;
          break;
        case 923577301:
          if (!(s == "2") || strArray1.Length != 4)
            break;
          this.UIUnlock((object) null, (EventArgs) null);
          int num5 = (int) MessageBox.Show("Account registration succeful");
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
      this.UIUnlock((object) null, (EventArgs) null);
      this.TrayRestoreFromTaskBar((object) null, (MouseEventArgs) null);
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
        this.login_error_label.Text = "password can not be blank";
        this.login_error_label.Visible = true;
      }
      else if (this.AccountTextBox.Text.IndexOf(' ') >= 0)
      {
        this.login_error_label.Text = "Password cannot contain spaces";
        this.login_error_label.Visible = true;
      }
      else
      {
        if (Comunication.SendPacket(Encoding.UTF8.GetBytes(string.Format("{0} 0 ", (object) ++MainForm.PacketNumber) + this.AccountTextBox.Text + " " + this.AccountPasswordTextBox.Text)))
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
        if (Comunication.SendPacket(Encoding.UTF8.GetBytes(string.Format("{0} 1 ", (object) ++MainForm.PacketNumber) + this.Register_AccountNameTextBox.Text + " " + this.Register_PasswordTextBox.Text + " " + this.Register_QuestionTextBox.Text + " " + this.Register_SecretAnswerTextBox.Text)))
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
        if (Comunication.SendPacket(Encoding.UTF8.GetBytes(string.Format("{0} 2 ", (object) ++MainForm.PacketNumber) + this.Modify_AccountNameTextBox.Text + " " + this.Modify_PasswordTextBox.Text + " " + this.Modify_QuestionTextBox.Text + " " + this.Modify_AnswerTextBox.Text)))
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
        int num1 = (int) MessageBox.Show("please choose the server");
      }
      else if (!MainForm.IPList.ContainsKey(this.start_selected_zone.Text))
      {
        int num2 = (int) MessageBox.Show("Server selection error");
      }
      else
      {
        if (!Comunication.SendPacket(Encoding.UTF8.GetBytes(string.Format("{0} 3 ", (object) ++MainForm.PacketNumber) + MainForm.LoginAccount + " " + MainForm.LoginPassword + " " + this.start_selected_zone.Text + " v1.0")))
          return;
        this.UILock();
        this.InterfaceUpdateTimer.Enabled = true;
      }
    }

    private void LogoutTab_Click(object sender, EventArgs e)
    {
      MainForm.LoginAccount = (string) null;
      MainForm.LoginPassword = (string) null;
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
      e.Graphics.DrawString(this.GameServerList.Items[e.Index].ToString(), e.Font, (Brush) new SolidBrush(e.ForeColor), (RectangleF) e.Bounds, format);
    }

    private void StartupChooseGS_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.GameServerList.SelectedIndex < 0)
        this.start_selected_zone.Text = "";
      else
        this.start_selected_zone.Text = this.GameServerList.Items[this.GameServerList.SelectedIndex].ToString();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (MainForm));
      this.MainTab = new UITabControl();
      this.AccountLoginTab = new TabPage();
      this.Login_userIcon = new UIAvatar();
      this.LoginAccountLabel = new UISymbolButton();
      this.ForgotPasswordLabel = new UILinkLabel();
      this.AccountPasswordTextBox = new UITextBox();
      this.RegisterAccountLabel = new UISymbolButton();
      this.login_error_label = new UILabel();
      this.AccountTextBox = new UITextBox();
      this.RegistrationTab = new TabPage();
      this.Register_Back_To_LoginBtn = new UISymbolButton();
      this.RegistrationErrorLabel = new UILabel();
      this.Register_AccountBtn = new UISymbolButton();
      this.Register_SecretAnswerTextBox = new UITextBox();
      this.Register_PasswordTextBox = new UITextBox();
      this.Register_QuestionTextBox = new UITextBox();
      this.Register_AccountNameTextBox = new UITextBox();
      this.ChangePasswordTab = new TabPage();
      this.Modify_Back_To_LoginBtn = new UISymbolButton();
      this.Modify_ErrorLabel = new UILabel();
      this.Modify_PasswordBtn = new UISymbolButton();
      this.Modify_AnswerTextBox = new UITextBox();
      this.Modify_PasswordTextBox = new UITextBox();
      this.Modify_QuestionTextBox = new UITextBox();
      this.Modify_AccountNameTextBox = new UITextBox();
      this.StartGameTab = new TabPage();
      this.activate_account = new UISymbolButton();
      this.selected_tab = new UILabel();
      this.start_selected_zone = new UILinkLabel();
      this.logoutLabel = new UILinkLabel();
      this.GameServerList = new ListBox();
      this.Launcher_enterGameBtn = new UIButton();
      this.InterfaceUpdateTimer = new System.Windows.Forms.Timer(this.components);
      this.DataProcessTimer = new System.Windows.Forms.Timer(this.components);
      this.minimizeToTray = new NotifyIcon(this.components);
      this.TrayRightClickMenu = new ContextMenuStrip(this.components);
      this.OpenToolStripMenuItem = new ToolStripMenuItem();
      this.QuitToolStripMenuItem = new ToolStripMenuItem();
      this.GameProcessTimer = new System.Windows.Forms.Timer(this.components);
      this.MainTab.SuspendLayout();
      this.AccountLoginTab.SuspendLayout();
      this.RegistrationTab.SuspendLayout();
      this.ChangePasswordTab.SuspendLayout();
      this.StartGameTab.SuspendLayout();
      this.TrayRightClickMenu.SuspendLayout();
      this.SuspendLayout();
      this.MainTab.Controls.Add((Control) this.AccountLoginTab);
      this.MainTab.Controls.Add((Control) this.RegistrationTab);
      this.MainTab.Controls.Add((Control) this.ChangePasswordTab);
      this.MainTab.Controls.Add((Control) this.StartGameTab);
      this.MainTab.DrawMode = TabDrawMode.OwnerDrawFixed;
      this.MainTab.FillColor = Color.FromArgb((int) byte.MaxValue, 244, 240);
      this.MainTab.Font = new Font("Arial", 12f);
      this.MainTab.ItemSize = new Size(260, 28);
      this.MainTab.Location = new Point(0, 0);
      this.MainTab.MainPage = "";
      this.MainTab.Margin = new Padding(3, 2, 3, 2);
      this.MainTab.MenuStyle = UIMenuStyle.Custom;
      this.MainTab.Name = "MainTab";
      this.MainTab.SelectedIndex = 0;
      this.MainTab.Size = new Size(381, 366);
      this.MainTab.SizeMode = TabSizeMode.Fixed;
      this.MainTab.Style = UIStyle.LayuiRed;
      this.MainTab.StyleCustomMode = true;
      this.MainTab.TabIndex = 9;
      this.MainTab.TabSelectedColor = Color.FromArgb(56, 56, 56);
      this.MainTab.TabSelectedForeColor = Color.FromArgb((int) byte.MaxValue, 87, 34);
      this.MainTab.TabSelectedHighColor = Color.FromArgb((int) byte.MaxValue, 87, 34);
      this.MainTab.TabSelectedHighColorSize = 0;
      this.MainTab.TabStop = false;
      this.MainTab.TabUnSelectedForeColor = Color.FromArgb((int) byte.MaxValue, 87, 34);
      this.MainTab.TipsFont = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.AccountLoginTab.BackColor = Color.FromArgb((int) byte.MaxValue, 244, 240);
      this.AccountLoginTab.Controls.Add((Control) this.Login_userIcon);
      this.AccountLoginTab.Controls.Add((Control) this.LoginAccountLabel);
      this.AccountLoginTab.Controls.Add((Control) this.ForgotPasswordLabel);
      this.AccountLoginTab.Controls.Add((Control) this.AccountPasswordTextBox);
      this.AccountLoginTab.Controls.Add((Control) this.RegisterAccountLabel);
      this.AccountLoginTab.Controls.Add((Control) this.login_error_label);
      this.AccountLoginTab.Controls.Add((Control) this.AccountTextBox);
      this.AccountLoginTab.Location = new Point(0, 28);
      this.AccountLoginTab.Margin = new Padding(3, 2, 3, 2);
      this.AccountLoginTab.Name = "AccountLoginTab";
      this.AccountLoginTab.Size = new Size(385, 338);
      this.AccountLoginTab.TabIndex = 0;
      this.AccountLoginTab.Text = "Account Login";
      this.Login_userIcon.Font = new Font("Arial", 12f);
      this.Login_userIcon.ForeColor = Color.FromArgb(230, 80, 80);
      this.Login_userIcon.Location = new Point(104, 13);
      this.Login_userIcon.Margin = new Padding(3, 2, 3, 2);
      this.Login_userIcon.MinimumSize = new Size(1, 1);
      this.Login_userIcon.Name = "Login_userIcon";
      this.Login_userIcon.Size = new Size(45, 45);
      this.Login_userIcon.Style = UIStyle.Red;
      this.Login_userIcon.TabIndex = 10;
      this.Login_userIcon.TabStop = false;
      this.LoginAccountLabel.Cursor = Cursors.Hand;
      this.LoginAccountLabel.FillColor = Color.FromArgb(230, 80, 80);
      this.LoginAccountLabel.FillColor2 = Color.FromArgb(230, 80, 80);
      this.LoginAccountLabel.FillHoverColor = Color.FromArgb(235, 115, 115);
      this.LoginAccountLabel.FillPressColor = Color.FromArgb(184, 64, 64);
      this.LoginAccountLabel.FillSelectedColor = Color.FromArgb(184, 64, 64);
      this.LoginAccountLabel.Font = new Font("Arial", 12f);
      this.LoginAccountLabel.Location = new Point(21, 212);
      this.LoginAccountLabel.Margin = new Padding(3, 2, 3, 2);
      this.LoginAccountLabel.MinimumSize = new Size(1, 1);
      this.LoginAccountLabel.Name = "LoginAccountLabel";
      this.LoginAccountLabel.RectColor = Color.FromArgb(230, 80, 80);
      this.LoginAccountLabel.RectHoverColor = Color.FromArgb(235, 115, 115);
      this.LoginAccountLabel.RectPressColor = Color.FromArgb(184, 64, 64);
      this.LoginAccountLabel.RectSelectedColor = Color.FromArgb(184, 64, 64);
      this.LoginAccountLabel.Size = new Size(267, 29);
      this.LoginAccountLabel.Style = UIStyle.Red;
      this.LoginAccountLabel.TabIndex = 13;
      this.LoginAccountLabel.TabStop = false;
      this.LoginAccountLabel.Text = "Login";
      this.LoginAccountLabel.TipsFont = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.LoginAccountLabel.Click += new EventHandler(this.LoginAccountLabel_Click);
      this.ForgotPasswordLabel.ActiveLinkColor = Color.FromArgb(220, 155, 40);
      this.ForgotPasswordLabel.Font = new Font("Arial", 9f);
      this.ForgotPasswordLabel.LinkBehavior = LinkBehavior.AlwaysUnderline;
      this.ForgotPasswordLabel.LinkColor = Color.FromArgb(230, 80, 80);
      this.ForgotPasswordLabel.Location = new Point(173, 167);
      this.ForgotPasswordLabel.Name = "ForgotPasswordLabel";
      this.ForgotPasswordLabel.Size = new Size(65, 18);
      this.ForgotPasswordLabel.Style = UIStyle.Red;
      this.ForgotPasswordLabel.TabIndex = 16;
      this.ForgotPasswordLabel.TabStop = true;
      this.ForgotPasswordLabel.Text = "Forgot Password?";
      this.ForgotPasswordLabel.VisitedLinkColor = Color.FromArgb(230, 80, 80);
      this.ForgotPasswordLabel.Click += new EventHandler(this.Login_ForgotPassword_Click);
      this.AccountPasswordTextBox.ButtonFillColor = Color.FromArgb(230, 80, 80);
      this.AccountPasswordTextBox.ButtonFillHoverColor = Color.FromArgb(235, 115, 115);
      this.AccountPasswordTextBox.ButtonFillPressColor = Color.FromArgb(184, 64, 64);
      this.AccountPasswordTextBox.ButtonRectColor = Color.FromArgb(230, 80, 80);
      this.AccountPasswordTextBox.ButtonRectHoverColor = Color.FromArgb(235, 115, 115);
      this.AccountPasswordTextBox.ButtonRectPressColor = Color.FromArgb(184, 64, 64);
      this.AccountPasswordTextBox.Cursor = Cursors.IBeam;
      this.AccountPasswordTextBox.FillColor2 = Color.FromArgb(253, 243, 243);
      this.AccountPasswordTextBox.Font = new Font("Arial", 12f);
      this.AccountPasswordTextBox.Location = new Point(21, 101);
      this.AccountPasswordTextBox.Margin = new Padding(3, 4, 3, 4);
      this.AccountPasswordTextBox.MinimumSize = new Size(1, 11);
      this.AccountPasswordTextBox.Name = "AccountPasswordTextBox";
      this.AccountPasswordTextBox.PasswordChar = '*';
      this.AccountPasswordTextBox.RectColor = Color.FromArgb(230, 80, 80);
      this.AccountPasswordTextBox.ScrollBarColor = Color.FromArgb(230, 80, 80);
      this.AccountPasswordTextBox.ShowText = false;
      this.AccountPasswordTextBox.Size = new Size(267, 29);
      this.AccountPasswordTextBox.Style = UIStyle.Red;
      this.AccountPasswordTextBox.Symbol = 61475;
      this.AccountPasswordTextBox.SymbolSize = 22;
      this.AccountPasswordTextBox.TabIndex = 2;
      this.AccountPasswordTextBox.TextAlignment = ContentAlignment.MiddleLeft;
      this.AccountPasswordTextBox.Watermark = "Please enter password";
      this.RegisterAccountLabel.Cursor = Cursors.Hand;
      this.RegisterAccountLabel.FillColor = Color.FromArgb(230, 80, 80);
      this.RegisterAccountLabel.FillColor2 = Color.FromArgb(230, 80, 80);
      this.RegisterAccountLabel.FillHoverColor = Color.FromArgb(235, 115, 115);
      this.RegisterAccountLabel.FillPressColor = Color.FromArgb(184, 64, 64);
      this.RegisterAccountLabel.FillSelectedColor = Color.FromArgb(184, 64, 64);
      this.RegisterAccountLabel.Font = new Font("Arial", 12f);
      this.RegisterAccountLabel.Location = new Point(21, 256);
      this.RegisterAccountLabel.Margin = new Padding(3, 2, 3, 2);
      this.RegisterAccountLabel.MinimumSize = new Size(1, 1);
      this.RegisterAccountLabel.Name = "RegisterAccountLabel";
      this.RegisterAccountLabel.RectColor = Color.FromArgb(230, 80, 80);
      this.RegisterAccountLabel.RectHoverColor = Color.FromArgb(235, 115, 115);
      this.RegisterAccountLabel.RectPressColor = Color.FromArgb(184, 64, 64);
      this.RegisterAccountLabel.RectSelectedColor = Color.FromArgb(184, 64, 64);
      this.RegisterAccountLabel.Size = new Size(267, 29);
      this.RegisterAccountLabel.Style = UIStyle.Red;
      this.RegisterAccountLabel.Symbol = 62004;
      this.RegisterAccountLabel.TabIndex = 14;
      this.RegisterAccountLabel.TabStop = false;
      this.RegisterAccountLabel.Text = "Register";
      this.RegisterAccountLabel.TipsColor = Color.FromArgb(128, (int) byte.MaxValue, 128);
      this.RegisterAccountLabel.TipsFont = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.RegisterAccountLabel.Click += new EventHandler(this.Login_Registertab_Click);
      this.login_error_label.Font = new Font("Arial", 9f);
      this.login_error_label.ForeColor = Color.Red;
      this.login_error_label.Location = new Point(21, 194);
      this.login_error_label.Name = "login_error_label";
      this.login_error_label.Size = new Size(169, 16);
      this.login_error_label.Style = UIStyle.Custom;
      this.login_error_label.TabIndex = 15;
      this.login_error_label.Text = "Error message";
      this.login_error_label.TextAlign = ContentAlignment.MiddleLeft;
      this.login_error_label.Visible = false;
      this.AccountTextBox.ButtonFillColor = Color.FromArgb(230, 80, 80);
      this.AccountTextBox.ButtonFillHoverColor = Color.FromArgb(235, 115, 115);
      this.AccountTextBox.ButtonFillPressColor = Color.FromArgb(184, 64, 64);
      this.AccountTextBox.ButtonRectColor = Color.FromArgb(230, 80, 80);
      this.AccountTextBox.ButtonRectHoverColor = Color.FromArgb(235, 115, 115);
      this.AccountTextBox.ButtonRectPressColor = Color.FromArgb(184, 64, 64);
      this.AccountTextBox.Cursor = Cursors.IBeam;
      this.AccountTextBox.FillColor2 = Color.FromArgb(253, 243, 243);
      this.AccountTextBox.Font = new Font("Arial", 12f);
      this.AccountTextBox.Location = new Point(21, 64);
      this.AccountTextBox.Margin = new Padding(3, 4, 3, 4);
      this.AccountTextBox.MinimumSize = new Size(1, 11);
      this.AccountTextBox.Name = "AccountTextBox";
      this.AccountTextBox.RectColor = Color.FromArgb(230, 80, 80);
      this.AccountTextBox.ScrollBarColor = Color.FromArgb(230, 80, 80);
      this.AccountTextBox.ShowText = false;
      this.AccountTextBox.Size = new Size(267, 29);
      this.AccountTextBox.Style = UIStyle.Red;
      this.AccountTextBox.Symbol = 61447;
      this.AccountTextBox.SymbolSize = 22;
      this.AccountTextBox.TabIndex = 1;
      this.AccountTextBox.TextAlignment = ContentAlignment.MiddleLeft;
      this.AccountTextBox.Watermark = "Please enter a account name";
      this.RegistrationTab.BackColor = Color.FromArgb((int) byte.MaxValue, 244, 240);
      this.RegistrationTab.Controls.Add((Control) this.Register_Back_To_LoginBtn);
      this.RegistrationTab.Controls.Add((Control) this.RegistrationErrorLabel);
      this.RegistrationTab.Controls.Add((Control) this.Register_AccountBtn);
      this.RegistrationTab.Controls.Add((Control) this.Register_SecretAnswerTextBox);
      this.RegistrationTab.Controls.Add((Control) this.Register_PasswordTextBox);
      this.RegistrationTab.Controls.Add((Control) this.Register_QuestionTextBox);
      this.RegistrationTab.Controls.Add((Control) this.Register_AccountNameTextBox);
      this.RegistrationTab.Location = new Point(0, 28);
      this.RegistrationTab.Margin = new Padding(3, 2, 3, 2);
      this.RegistrationTab.Name = "RegistrationTab";
      this.RegistrationTab.Size = new Size(385, 338);
      this.RegistrationTab.TabIndex = 1;
      this.RegistrationTab.Text = "Register Account";
      this.Register_Back_To_LoginBtn.Cursor = Cursors.Hand;
      this.Register_Back_To_LoginBtn.FillColor = Color.FromArgb(230, 80, 80);
      this.Register_Back_To_LoginBtn.FillColor2 = Color.FromArgb(230, 80, 80);
      this.Register_Back_To_LoginBtn.FillHoverColor = Color.FromArgb(235, 115, 115);
      this.Register_Back_To_LoginBtn.FillPressColor = Color.FromArgb(184, 64, 64);
      this.Register_Back_To_LoginBtn.FillSelectedColor = Color.FromArgb(184, 64, 64);
      this.Register_Back_To_LoginBtn.Font = new Font("Arial", 12f);
      this.Register_Back_To_LoginBtn.Location = new Point(21, 263);
      this.Register_Back_To_LoginBtn.Margin = new Padding(3, 2, 3, 2);
      this.Register_Back_To_LoginBtn.MinimumSize = new Size(1, 1);
      this.Register_Back_To_LoginBtn.Name = "Register_Back_To_LoginBtn";
      this.Register_Back_To_LoginBtn.RectColor = Color.FromArgb(230, 80, 80);
      this.Register_Back_To_LoginBtn.RectHoverColor = Color.FromArgb(235, 115, 115);
      this.Register_Back_To_LoginBtn.RectPressColor = Color.FromArgb(184, 64, 64);
      this.Register_Back_To_LoginBtn.RectSelectedColor = Color.FromArgb(184, 64, 64);
      this.Register_Back_To_LoginBtn.Size = new Size(213, 30);
      this.Register_Back_To_LoginBtn.Style = UIStyle.Red;
      this.Register_Back_To_LoginBtn.Symbol = 61730;
      this.Register_Back_To_LoginBtn.TabIndex = 20;
      this.Register_Back_To_LoginBtn.TabStop = false;
      this.Register_Back_To_LoginBtn.Text = "Back to Login";
      this.Register_Back_To_LoginBtn.TipsColor = Color.FromArgb(128, (int) byte.MaxValue, 128);
      this.Register_Back_To_LoginBtn.TipsFont = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.Register_Back_To_LoginBtn.Click += new EventHandler(this.RegisterBackToLogin_Click);
      this.RegistrationErrorLabel.Font = new Font("Arial", 9f);
      this.RegistrationErrorLabel.ForeColor = Color.Red;
      this.RegistrationErrorLabel.Location = new Point(21, 194);
      this.RegistrationErrorLabel.Name = "RegistrationErrorLabel";
      this.RegistrationErrorLabel.Size = new Size(213, 23);
      this.RegistrationErrorLabel.Style = UIStyle.Custom;
      this.RegistrationErrorLabel.TabIndex = 17;
      this.RegistrationErrorLabel.Text = "Error message";
      this.RegistrationErrorLabel.TextAlign = ContentAlignment.MiddleLeft;
      this.RegistrationErrorLabel.Visible = false;
      this.Register_AccountBtn.Cursor = Cursors.Hand;
      this.Register_AccountBtn.FillColor = Color.FromArgb(230, 80, 80);
      this.Register_AccountBtn.FillColor2 = Color.FromArgb(230, 80, 80);
      this.Register_AccountBtn.FillHoverColor = Color.FromArgb(235, 115, 115);
      this.Register_AccountBtn.FillPressColor = Color.FromArgb(184, 64, 64);
      this.Register_AccountBtn.FillSelectedColor = Color.FromArgb(184, 64, 64);
      this.Register_AccountBtn.Font = new Font("Arial", 12f);
      this.Register_AccountBtn.Location = new Point(21, 219);
      this.Register_AccountBtn.Margin = new Padding(3, 2, 3, 2);
      this.Register_AccountBtn.MinimumSize = new Size(1, 1);
      this.Register_AccountBtn.Name = "Register_AccountBtn";
      this.Register_AccountBtn.RectColor = Color.FromArgb(230, 80, 80);
      this.Register_AccountBtn.RectHoverColor = Color.FromArgb(235, 115, 115);
      this.Register_AccountBtn.RectPressColor = Color.FromArgb(184, 64, 64);
      this.Register_AccountBtn.RectSelectedColor = Color.FromArgb(184, 64, 64);
      this.Register_AccountBtn.Size = new Size(213, 30);
      this.Register_AccountBtn.Style = UIStyle.Red;
      this.Register_AccountBtn.Symbol = 62004;
      this.Register_AccountBtn.TabIndex = 16;
      this.Register_AccountBtn.TabStop = false;
      this.Register_AccountBtn.Text = "Register new account";
      this.Register_AccountBtn.TipsColor = Color.FromArgb(128, (int) byte.MaxValue, 128);
      this.Register_AccountBtn.TipsFont = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.Register_AccountBtn.Click += new EventHandler(this.RegisterAccount_Click);
      this.Register_SecretAnswerTextBox.ButtonFillColor = Color.FromArgb(230, 80, 80);
      this.Register_SecretAnswerTextBox.ButtonFillHoverColor = Color.FromArgb(235, 115, 115);
      this.Register_SecretAnswerTextBox.ButtonFillPressColor = Color.FromArgb(184, 64, 64);
      this.Register_SecretAnswerTextBox.ButtonRectColor = Color.FromArgb(230, 80, 80);
      this.Register_SecretAnswerTextBox.ButtonRectHoverColor = Color.FromArgb(235, 115, 115);
      this.Register_SecretAnswerTextBox.ButtonRectPressColor = Color.FromArgb(184, 64, 64);
      this.Register_SecretAnswerTextBox.Cursor = Cursors.IBeam;
      this.Register_SecretAnswerTextBox.FillColor2 = Color.FromArgb(253, 243, 243);
      this.Register_SecretAnswerTextBox.Font = new Font("Arial", 12f);
      this.Register_SecretAnswerTextBox.Location = new Point(21, 121);
      this.Register_SecretAnswerTextBox.Margin = new Padding(3, 4, 3, 4);
      this.Register_SecretAnswerTextBox.MinimumSize = new Size(1, 11);
      this.Register_SecretAnswerTextBox.Name = "Register_SecretAnswerTextBox";
      this.Register_SecretAnswerTextBox.PasswordChar = '*';
      this.Register_SecretAnswerTextBox.RectColor = Color.FromArgb(230, 80, 80);
      this.Register_SecretAnswerTextBox.ScrollBarColor = Color.FromArgb(230, 80, 80);
      this.Register_SecretAnswerTextBox.ShowText = false;
      this.Register_SecretAnswerTextBox.Size = new Size(213, 30);
      this.Register_SecretAnswerTextBox.Style = UIStyle.Red;
      this.Register_SecretAnswerTextBox.Symbol = 61716;
      this.Register_SecretAnswerTextBox.SymbolSize = 22;
      this.Register_SecretAnswerTextBox.TabIndex = 4;
      this.Register_SecretAnswerTextBox.TextAlignment = ContentAlignment.MiddleLeft;
      this.Register_SecretAnswerTextBox.Watermark = "Please enter a secret answer";
      this.Register_PasswordTextBox.ButtonFillColor = Color.FromArgb(230, 80, 80);
      this.Register_PasswordTextBox.ButtonFillHoverColor = Color.FromArgb(235, 115, 115);
      this.Register_PasswordTextBox.ButtonFillPressColor = Color.FromArgb(184, 64, 64);
      this.Register_PasswordTextBox.ButtonRectColor = Color.FromArgb(230, 80, 80);
      this.Register_PasswordTextBox.ButtonRectHoverColor = Color.FromArgb(235, 115, 115);
      this.Register_PasswordTextBox.ButtonRectPressColor = Color.FromArgb(184, 64, 64);
      this.Register_PasswordTextBox.Cursor = Cursors.IBeam;
      this.Register_PasswordTextBox.FillColor2 = Color.FromArgb(253, 243, 243);
      this.Register_PasswordTextBox.Font = new Font("Arial", 12f);
      this.Register_PasswordTextBox.Location = new Point(21, 47);
      this.Register_PasswordTextBox.Margin = new Padding(3, 4, 3, 4);
      this.Register_PasswordTextBox.MinimumSize = new Size(1, 11);
      this.Register_PasswordTextBox.Name = "Register_PasswordTextBox";
      this.Register_PasswordTextBox.PasswordChar = '*';
      this.Register_PasswordTextBox.RectColor = Color.FromArgb(230, 80, 80);
      this.Register_PasswordTextBox.ScrollBarColor = Color.FromArgb(230, 80, 80);
      this.Register_PasswordTextBox.ShowText = false;
      this.Register_PasswordTextBox.Size = new Size(213, 30);
      this.Register_PasswordTextBox.Style = UIStyle.Red;
      this.Register_PasswordTextBox.Symbol = 61475;
      this.Register_PasswordTextBox.SymbolSize = 22;
      this.Register_PasswordTextBox.TabIndex = 2;
      this.Register_PasswordTextBox.TextAlignment = ContentAlignment.MiddleLeft;
      this.Register_PasswordTextBox.Watermark = "Please enter a password";
      this.Register_QuestionTextBox.ButtonFillColor = Color.FromArgb(230, 80, 80);
      this.Register_QuestionTextBox.ButtonFillHoverColor = Color.FromArgb(235, 115, 115);
      this.Register_QuestionTextBox.ButtonFillPressColor = Color.FromArgb(184, 64, 64);
      this.Register_QuestionTextBox.ButtonRectColor = Color.FromArgb(230, 80, 80);
      this.Register_QuestionTextBox.ButtonRectHoverColor = Color.FromArgb(235, 115, 115);
      this.Register_QuestionTextBox.ButtonRectPressColor = Color.FromArgb(184, 64, 64);
      this.Register_QuestionTextBox.Cursor = Cursors.IBeam;
      this.Register_QuestionTextBox.FillColor2 = Color.FromArgb(253, 243, 243);
      this.Register_QuestionTextBox.Font = new Font("Arial", 12f);
      this.Register_QuestionTextBox.Location = new Point(21, 84);
      this.Register_QuestionTextBox.Margin = new Padding(3, 4, 3, 4);
      this.Register_QuestionTextBox.MinimumSize = new Size(1, 11);
      this.Register_QuestionTextBox.Name = "Register_QuestionTextBox";
      this.Register_QuestionTextBox.RectColor = Color.FromArgb(230, 80, 80);
      this.Register_QuestionTextBox.ScrollBarColor = Color.FromArgb(230, 80, 80);
      this.Register_QuestionTextBox.ShowText = false;
      this.Register_QuestionTextBox.Size = new Size(213, 30);
      this.Register_QuestionTextBox.Style = UIStyle.Red;
      this.Register_QuestionTextBox.Symbol = 61563;
      this.Register_QuestionTextBox.SymbolSize = 22;
      this.Register_QuestionTextBox.TabIndex = 3;
      this.Register_QuestionTextBox.TextAlignment = ContentAlignment.MiddleLeft;
      this.Register_QuestionTextBox.Watermark = "Please enter a security question";
      this.Register_AccountNameTextBox.ButtonFillColor = Color.FromArgb(230, 80, 80);
      this.Register_AccountNameTextBox.ButtonFillHoverColor = Color.FromArgb(235, 115, 115);
      this.Register_AccountNameTextBox.ButtonFillPressColor = Color.FromArgb(184, 64, 64);
      this.Register_AccountNameTextBox.ButtonRectColor = Color.FromArgb(230, 80, 80);
      this.Register_AccountNameTextBox.ButtonRectHoverColor = Color.FromArgb(235, 115, 115);
      this.Register_AccountNameTextBox.ButtonRectPressColor = Color.FromArgb(184, 64, 64);
      this.Register_AccountNameTextBox.Cursor = Cursors.IBeam;
      this.Register_AccountNameTextBox.FillColor2 = Color.FromArgb(253, 243, 243);
      this.Register_AccountNameTextBox.Font = new Font("Arial", 12f);
      this.Register_AccountNameTextBox.Location = new Point(21, 10);
      this.Register_AccountNameTextBox.Margin = new Padding(3, 4, 3, 4);
      this.Register_AccountNameTextBox.MinimumSize = new Size(1, 11);
      this.Register_AccountNameTextBox.Name = "Register_AccountNameTextBox";
      this.Register_AccountNameTextBox.RectColor = Color.FromArgb(230, 80, 80);
      this.Register_AccountNameTextBox.ScrollBarColor = Color.FromArgb(230, 80, 80);
      this.Register_AccountNameTextBox.ShowText = false;
      this.Register_AccountNameTextBox.Size = new Size(213, 30);
      this.Register_AccountNameTextBox.Style = UIStyle.Red;
      this.Register_AccountNameTextBox.Symbol = 61447;
      this.Register_AccountNameTextBox.SymbolSize = 22;
      this.Register_AccountNameTextBox.TabIndex = 1;
      this.Register_AccountNameTextBox.TextAlignment = ContentAlignment.MiddleLeft;
      this.Register_AccountNameTextBox.Watermark = "Please enter the account name";
      this.ChangePasswordTab.BackColor = Color.FromArgb((int) byte.MaxValue, 244, 240);
      this.ChangePasswordTab.Controls.Add((Control) this.Modify_Back_To_LoginBtn);
      this.ChangePasswordTab.Controls.Add((Control) this.Modify_ErrorLabel);
      this.ChangePasswordTab.Controls.Add((Control) this.Modify_PasswordBtn);
      this.ChangePasswordTab.Controls.Add((Control) this.Modify_AnswerTextBox);
      this.ChangePasswordTab.Controls.Add((Control) this.Modify_PasswordTextBox);
      this.ChangePasswordTab.Controls.Add((Control) this.Modify_QuestionTextBox);
      this.ChangePasswordTab.Controls.Add((Control) this.Modify_AccountNameTextBox);
      this.ChangePasswordTab.Location = new Point(0, 28);
      this.ChangePasswordTab.Margin = new Padding(3, 2, 3, 2);
      this.ChangePasswordTab.Name = "ChangePasswordTab";
      this.ChangePasswordTab.Size = new Size(385, 338);
      this.ChangePasswordTab.TabIndex = 2;
      this.ChangePasswordTab.Text = "Change Password";
      this.Modify_Back_To_LoginBtn.Cursor = Cursors.Hand;
      this.Modify_Back_To_LoginBtn.FillColor = Color.FromArgb(230, 80, 80);
      this.Modify_Back_To_LoginBtn.FillColor2 = Color.FromArgb(230, 80, 80);
      this.Modify_Back_To_LoginBtn.FillHoverColor = Color.FromArgb(235, 115, 115);
      this.Modify_Back_To_LoginBtn.FillPressColor = Color.FromArgb(184, 64, 64);
      this.Modify_Back_To_LoginBtn.FillSelectedColor = Color.FromArgb(184, 64, 64);
      this.Modify_Back_To_LoginBtn.Font = new Font("Arial", 12f);
      this.Modify_Back_To_LoginBtn.Location = new Point(21, 262);
      this.Modify_Back_To_LoginBtn.Margin = new Padding(3, 2, 3, 2);
      this.Modify_Back_To_LoginBtn.MinimumSize = new Size(1, 1);
      this.Modify_Back_To_LoginBtn.Name = "Modify_Back_To_LoginBtn";
      this.Modify_Back_To_LoginBtn.RectColor = Color.FromArgb(230, 80, 80);
      this.Modify_Back_To_LoginBtn.RectHoverColor = Color.FromArgb(235, 115, 115);
      this.Modify_Back_To_LoginBtn.RectPressColor = Color.FromArgb(184, 64, 64);
      this.Modify_Back_To_LoginBtn.RectSelectedColor = Color.FromArgb(184, 64, 64);
      this.Modify_Back_To_LoginBtn.Size = new Size(213, 30);
      this.Modify_Back_To_LoginBtn.Style = UIStyle.Red;
      this.Modify_Back_To_LoginBtn.Symbol = 61730;
      this.Modify_Back_To_LoginBtn.TabIndex = 24;
      this.Modify_Back_To_LoginBtn.TabStop = false;
      this.Modify_Back_To_LoginBtn.Text = "Back to Login";
      this.Modify_Back_To_LoginBtn.TipsColor = Color.FromArgb(128, (int) byte.MaxValue, 128);
      this.Modify_Back_To_LoginBtn.TipsFont = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.Modify_Back_To_LoginBtn.Click += new EventHandler(this.Modify_BackToLogin_Click);
      this.Modify_ErrorLabel.Font = new Font("Arial", 9f);
      this.Modify_ErrorLabel.ForeColor = Color.Red;
      this.Modify_ErrorLabel.Location = new Point(18, 200);
      this.Modify_ErrorLabel.Name = "Modify_ErrorLabel";
      this.Modify_ErrorLabel.Size = new Size(216, 16);
      this.Modify_ErrorLabel.Style = UIStyle.Custom;
      this.Modify_ErrorLabel.TabIndex = 22;
      this.Modify_ErrorLabel.Text = "Error message";
      this.Modify_ErrorLabel.TextAlign = ContentAlignment.MiddleLeft;
      this.Modify_ErrorLabel.Visible = false;
      this.Modify_PasswordBtn.Cursor = Cursors.Hand;
      this.Modify_PasswordBtn.FillColor = Color.FromArgb(230, 80, 80);
      this.Modify_PasswordBtn.FillColor2 = Color.FromArgb(230, 80, 80);
      this.Modify_PasswordBtn.FillHoverColor = Color.FromArgb(235, 115, 115);
      this.Modify_PasswordBtn.FillPressColor = Color.FromArgb(184, 64, 64);
      this.Modify_PasswordBtn.FillSelectedColor = Color.FromArgb(184, 64, 64);
      this.Modify_PasswordBtn.Font = new Font("Arial", 12f);
      this.Modify_PasswordBtn.Location = new Point(21, 219);
      this.Modify_PasswordBtn.Margin = new Padding(3, 2, 3, 2);
      this.Modify_PasswordBtn.MinimumSize = new Size(1, 1);
      this.Modify_PasswordBtn.Name = "Modify_PasswordBtn";
      this.Modify_PasswordBtn.RectColor = Color.FromArgb(230, 80, 80);
      this.Modify_PasswordBtn.RectHoverColor = Color.FromArgb(235, 115, 115);
      this.Modify_PasswordBtn.RectPressColor = Color.FromArgb(184, 64, 64);
      this.Modify_PasswordBtn.RectSelectedColor = Color.FromArgb(184, 64, 64);
      this.Modify_PasswordBtn.Size = new Size(213, 30);
      this.Modify_PasswordBtn.Style = UIStyle.Red;
      this.Modify_PasswordBtn.Symbol = 61573;
      this.Modify_PasswordBtn.TabIndex = 21;
      this.Modify_PasswordBtn.TabStop = false;
      this.Modify_PasswordBtn.Text = "Change password";
      this.Modify_PasswordBtn.TipsColor = Color.FromArgb(128, (int) byte.MaxValue, 128);
      this.Modify_PasswordBtn.TipsFont = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.Modify_PasswordBtn.Click += new EventHandler(this.Modify_ChangePassword_Click);
      this.Modify_AnswerTextBox.ButtonFillColor = Color.FromArgb(230, 80, 80);
      this.Modify_AnswerTextBox.ButtonFillHoverColor = Color.FromArgb(235, 115, 115);
      this.Modify_AnswerTextBox.ButtonFillPressColor = Color.FromArgb(184, 64, 64);
      this.Modify_AnswerTextBox.ButtonRectColor = Color.FromArgb(230, 80, 80);
      this.Modify_AnswerTextBox.ButtonRectHoverColor = Color.FromArgb(235, 115, 115);
      this.Modify_AnswerTextBox.ButtonRectPressColor = Color.FromArgb(184, 64, 64);
      this.Modify_AnswerTextBox.Cursor = Cursors.IBeam;
      this.Modify_AnswerTextBox.FillColor2 = Color.FromArgb(253, 243, 243);
      this.Modify_AnswerTextBox.Font = new Font("Arial", 12f);
      this.Modify_AnswerTextBox.Location = new Point(21, 121);
      this.Modify_AnswerTextBox.Margin = new Padding(3, 4, 3, 4);
      this.Modify_AnswerTextBox.MinimumSize = new Size(1, 11);
      this.Modify_AnswerTextBox.Name = "Modify_AnswerTextBox";
      this.Modify_AnswerTextBox.PasswordChar = '*';
      this.Modify_AnswerTextBox.RectColor = Color.FromArgb(230, 80, 80);
      this.Modify_AnswerTextBox.ScrollBarColor = Color.FromArgb(230, 80, 80);
      this.Modify_AnswerTextBox.ShowText = false;
      this.Modify_AnswerTextBox.Size = new Size(213, 30);
      this.Modify_AnswerTextBox.Style = UIStyle.Red;
      this.Modify_AnswerTextBox.Symbol = 61716;
      this.Modify_AnswerTextBox.SymbolSize = 22;
      this.Modify_AnswerTextBox.TabIndex = 20;
      this.Modify_AnswerTextBox.TextAlignment = ContentAlignment.MiddleLeft;
      this.Modify_AnswerTextBox.Watermark = "Please enter the secret answer";
      this.Modify_PasswordTextBox.ButtonFillColor = Color.FromArgb(230, 80, 80);
      this.Modify_PasswordTextBox.ButtonFillHoverColor = Color.FromArgb(235, 115, 115);
      this.Modify_PasswordTextBox.ButtonFillPressColor = Color.FromArgb(184, 64, 64);
      this.Modify_PasswordTextBox.ButtonRectColor = Color.FromArgb(230, 80, 80);
      this.Modify_PasswordTextBox.ButtonRectHoverColor = Color.FromArgb(235, 115, 115);
      this.Modify_PasswordTextBox.ButtonRectPressColor = Color.FromArgb(184, 64, 64);
      this.Modify_PasswordTextBox.Cursor = Cursors.IBeam;
      this.Modify_PasswordTextBox.FillColor2 = Color.FromArgb(253, 243, 243);
      this.Modify_PasswordTextBox.Font = new Font("Arial", 12f);
      this.Modify_PasswordTextBox.Location = new Point(21, 47);
      this.Modify_PasswordTextBox.Margin = new Padding(3, 4, 3, 4);
      this.Modify_PasswordTextBox.MinimumSize = new Size(1, 11);
      this.Modify_PasswordTextBox.Name = "Modify_PasswordTextBox";
      this.Modify_PasswordTextBox.PasswordChar = '*';
      this.Modify_PasswordTextBox.RectColor = Color.FromArgb(230, 80, 80);
      this.Modify_PasswordTextBox.ScrollBarColor = Color.FromArgb(230, 80, 80);
      this.Modify_PasswordTextBox.ShowText = false;
      this.Modify_PasswordTextBox.Size = new Size(213, 30);
      this.Modify_PasswordTextBox.Style = UIStyle.Red;
      this.Modify_PasswordTextBox.Symbol = 61475;
      this.Modify_PasswordTextBox.SymbolSize = 22;
      this.Modify_PasswordTextBox.TabIndex = 18;
      this.Modify_PasswordTextBox.TextAlignment = ContentAlignment.MiddleLeft;
      this.Modify_PasswordTextBox.Watermark = "Please enter a new password";
      this.Modify_QuestionTextBox.ButtonFillColor = Color.FromArgb(230, 80, 80);
      this.Modify_QuestionTextBox.ButtonFillHoverColor = Color.FromArgb(235, 115, 115);
      this.Modify_QuestionTextBox.ButtonFillPressColor = Color.FromArgb(184, 64, 64);
      this.Modify_QuestionTextBox.ButtonRectColor = Color.FromArgb(230, 80, 80);
      this.Modify_QuestionTextBox.ButtonRectHoverColor = Color.FromArgb(235, 115, 115);
      this.Modify_QuestionTextBox.ButtonRectPressColor = Color.FromArgb(184, 64, 64);
      this.Modify_QuestionTextBox.Cursor = Cursors.IBeam;
      this.Modify_QuestionTextBox.FillColor2 = Color.FromArgb(253, 243, 243);
      this.Modify_QuestionTextBox.Font = new Font("Arial", 12f);
      this.Modify_QuestionTextBox.Location = new Point(21, 84);
      this.Modify_QuestionTextBox.Margin = new Padding(3, 4, 3, 4);
      this.Modify_QuestionTextBox.MinimumSize = new Size(1, 11);
      this.Modify_QuestionTextBox.Name = "Modify_QuestionTextBox";
      this.Modify_QuestionTextBox.RectColor = Color.FromArgb(230, 80, 80);
      this.Modify_QuestionTextBox.ScrollBarColor = Color.FromArgb(230, 80, 80);
      this.Modify_QuestionTextBox.ShowText = false;
      this.Modify_QuestionTextBox.Size = new Size(213, 30);
      this.Modify_QuestionTextBox.Style = UIStyle.Red;
      this.Modify_QuestionTextBox.Symbol = 61563;
      this.Modify_QuestionTextBox.SymbolSize = 22;
      this.Modify_QuestionTextBox.TabIndex = 19;
      this.Modify_QuestionTextBox.TextAlignment = ContentAlignment.MiddleLeft;
      this.Modify_QuestionTextBox.Watermark = "Please, enter a security question";
      this.Modify_AccountNameTextBox.ButtonFillColor = Color.FromArgb(230, 80, 80);
      this.Modify_AccountNameTextBox.ButtonFillHoverColor = Color.FromArgb(235, 115, 115);
      this.Modify_AccountNameTextBox.ButtonFillPressColor = Color.FromArgb(184, 64, 64);
      this.Modify_AccountNameTextBox.ButtonRectColor = Color.FromArgb(230, 80, 80);
      this.Modify_AccountNameTextBox.ButtonRectHoverColor = Color.FromArgb(235, 115, 115);
      this.Modify_AccountNameTextBox.ButtonRectPressColor = Color.FromArgb(184, 64, 64);
      this.Modify_AccountNameTextBox.Cursor = Cursors.IBeam;
      this.Modify_AccountNameTextBox.FillColor2 = Color.FromArgb(253, 243, 243);
      this.Modify_AccountNameTextBox.Font = new Font("Arial", 12f);
      this.Modify_AccountNameTextBox.Location = new Point(21, 10);
      this.Modify_AccountNameTextBox.Margin = new Padding(3, 4, 3, 4);
      this.Modify_AccountNameTextBox.MinimumSize = new Size(1, 11);
      this.Modify_AccountNameTextBox.Name = "Modify_AccountNameTextBox";
      this.Modify_AccountNameTextBox.RectColor = Color.FromArgb(230, 80, 80);
      this.Modify_AccountNameTextBox.ScrollBarColor = Color.FromArgb(230, 80, 80);
      this.Modify_AccountNameTextBox.ShowText = false;
      this.Modify_AccountNameTextBox.Size = new Size(213, 30);
      this.Modify_AccountNameTextBox.Style = UIStyle.Red;
      this.Modify_AccountNameTextBox.Symbol = 61447;
      this.Modify_AccountNameTextBox.SymbolSize = 22;
      this.Modify_AccountNameTextBox.TabIndex = 17;
      this.Modify_AccountNameTextBox.TextAlignment = ContentAlignment.MiddleLeft;
      this.Modify_AccountNameTextBox.Watermark = "Please enter an existing account";
      this.StartGameTab.BackColor = Color.FromArgb((int) byte.MaxValue, 244, 240);
      this.StartGameTab.Controls.Add((Control) this.activate_account);
      this.StartGameTab.Controls.Add((Control) this.selected_tab);
      this.StartGameTab.Controls.Add((Control) this.start_selected_zone);
      this.StartGameTab.Controls.Add((Control) this.logoutLabel);
      this.StartGameTab.Controls.Add((Control) this.GameServerList);
      this.StartGameTab.Controls.Add((Control) this.Launcher_enterGameBtn);
      this.StartGameTab.Location = new Point(0, 28);
      this.StartGameTab.Margin = new Padding(3, 2, 3, 2);
      this.StartGameTab.Name = "StartGame";
      this.StartGameTab.Size = new Size(385, 338);
      this.StartGameTab.TabIndex = 3;
      this.StartGameTab.Text = "Start Game";
      this.activate_account.Cursor = Cursors.Hand;
      this.activate_account.Enabled = false;
      this.activate_account.FillColor = Color.FromArgb(110, 190, 40);
      this.activate_account.FillColor2 = Color.FromArgb(110, 190, 40);
      this.activate_account.FillHoverColor = Color.FromArgb(139, 203, 83);
      this.activate_account.FillPressColor = Color.FromArgb(88, 152, 32);
      this.activate_account.FillSelectedColor = Color.FromArgb(88, 152, 32);
      this.activate_account.Font = new Font("Arial", 12f);
      this.activate_account.Location = new Point(3, 2);
      this.activate_account.Margin = new Padding(3, 2, 3, 2);
      this.activate_account.MinimumSize = new Size(1, 1);
      this.activate_account.Name = "Activate Account";
      this.activate_account.Radius = 15;
      this.activate_account.RectColor = Color.FromArgb(110, 190, 40);
      this.activate_account.RectHoverColor = Color.FromArgb(139, 203, 83);
      this.activate_account.RectPressColor = Color.FromArgb(88, 152, 32);
      this.activate_account.RectSelectedColor = Color.FromArgb(88, 152, 32);
      this.activate_account.Size = new Size(253, 30);
      this.activate_account.Style = UIStyle.Green;
      this.activate_account.Symbol = 57607;
      this.activate_account.TabIndex = 9;
      this.activate_account.Text = "mistyes";
      this.activate_account.TipsFont = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.selected_tab.Font = new Font("Arial", 9f);
      this.selected_tab.Location = new Point(7, 220);
      this.selected_tab.Name = "Start tab";
      this.selected_tab.Size = new Size(118, 20);
      this.selected_tab.TabIndex = 8;
      this.selected_tab.Text = "Currently Selected Server:";
      this.selected_tab.TextAlign = ContentAlignment.MiddleLeft;
      this.start_selected_zone.ActiveLinkColor = Color.FromArgb(220, 155, 40);
      this.start_selected_zone.Font = new Font("Arial", 12f);
      this.start_selected_zone.ImageAlign = ContentAlignment.MiddleRight;
      this.start_selected_zone.LinkBehavior = LinkBehavior.AlwaysUnderline;
      this.start_selected_zone.LinkColor = Color.FromArgb(192, 64, 0);
      this.start_selected_zone.Location = new Point(131, 214);
      this.start_selected_zone.Name = "Start Selected Zone";
      this.start_selected_zone.Size = new Size(116, 25);
      this.start_selected_zone.Style = UIStyle.Custom;
      this.start_selected_zone.TabIndex = 7;
      this.start_selected_zone.TextAlign = ContentAlignment.MiddleLeft;
      this.start_selected_zone.VisitedLinkColor = Color.FromArgb(230, 80, 80);
      this.logoutLabel.ActiveLinkColor = Color.FromArgb(220, 155, 40);
      this.logoutLabel.Font = new Font("Arial", 9f);
      this.logoutLabel.ImageAlign = ContentAlignment.MiddleRight;
      this.logoutLabel.LinkBehavior = LinkBehavior.AlwaysUnderline;
      this.logoutLabel.LinkColor = Color.Red;
      this.logoutLabel.Location = new Point(216, 34);
      this.logoutLabel.Name = "Logout";
      this.logoutLabel.Size = new Size(40, 17);
      this.logoutLabel.Style = UIStyle.Custom;
      this.logoutLabel.TabIndex = 6;
      this.logoutLabel.TabStop = true;
      this.logoutLabel.Text = "Quit";
      this.logoutLabel.TextAlign = ContentAlignment.MiddleRight;
      this.logoutLabel.VisitedLinkColor = Color.FromArgb(230, 80, 80);
      this.logoutLabel.Click += new EventHandler(this.LogoutTab_Click);
      this.GameServerList.BackColor = Color.Wheat;
      this.GameServerList.DrawMode = DrawMode.OwnerDrawVariable;
      this.GameServerList.Font = new Font("Arial", 10.5f);
      this.GameServerList.ForeColor = Color.Blue;
      this.GameServerList.FormattingEnabled = true;
      this.GameServerList.ItemHeight = 20;
      this.GameServerList.Items.AddRange(new object[2]
      {
        (object) "DragonValley",
        (object) "SadTree"
      });
      this.GameServerList.Location = new Point(73, 40);
      this.GameServerList.Margin = new Padding(3, 2, 3, 2);
      this.GameServerList.Name = "Select server";
      this.GameServerList.Size = new Size(120, 171);
      this.GameServerList.TabIndex = 4;
      this.GameServerList.TabStop = false;
      this.GameServerList.DrawItem += new DrawItemEventHandler(this.StartupChoosegameServer_DrawItem);
      this.GameServerList.SelectedIndexChanged += new EventHandler(this.StartupChooseGS_SelectedIndexChanged);
      this.Launcher_enterGameBtn.Cursor = Cursors.Hand;
      this.Launcher_enterGameBtn.FillColor = Color.FromArgb((int) byte.MaxValue, 87, 34);
      this.Launcher_enterGameBtn.FillColor2 = Color.FromArgb((int) byte.MaxValue, 87, 34);
      this.Launcher_enterGameBtn.FillHoverColor = Color.FromArgb((int) byte.MaxValue, 121, 78);
      this.Launcher_enterGameBtn.FillPressColor = Color.FromArgb(204, 70, 28);
      this.Launcher_enterGameBtn.FillSelectedColor = Color.FromArgb(204, 70, 28);
      this.Launcher_enterGameBtn.Font = new Font("Arial", 12f);
      this.Launcher_enterGameBtn.Location = new Point(3, 241);
      this.Launcher_enterGameBtn.Margin = new Padding(3, 2, 3, 2);
      this.Launcher_enterGameBtn.MinimumSize = new Size(1, 1);
      this.Launcher_enterGameBtn.Name = "Enter Game";
      this.Launcher_enterGameBtn.RectColor = Color.FromArgb((int) byte.MaxValue, 87, 34);
      this.Launcher_enterGameBtn.RectHoverColor = Color.FromArgb((int) byte.MaxValue, 121, 78);
      this.Launcher_enterGameBtn.RectPressColor = Color.FromArgb(204, 70, 28);
      this.Launcher_enterGameBtn.RectSelectedColor = Color.FromArgb(204, 70, 28);
      this.Launcher_enterGameBtn.Size = new Size(253, 30);
      this.Launcher_enterGameBtn.Style = UIStyle.LayuiRed;
      this.Launcher_enterGameBtn.TabIndex = 1;
      this.Launcher_enterGameBtn.TabStop = false;
      this.Launcher_enterGameBtn.Text = "Enter Game";
      this.Launcher_enterGameBtn.TipsFont = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.Launcher_enterGameBtn.Click += new EventHandler(this.Launch_EnterGame_Click);
      this.InterfaceUpdateTimer.Interval = 30000;
      this.InterfaceUpdateTimer.Tick += new EventHandler(this.UIUnlock);
      this.DataProcessTimer.Enabled = true;
      this.DataProcessTimer.Tick += new EventHandler(this.PacketProcess);
      this.minimizeToTray.ContextMenuStrip = this.TrayRightClickMenu;
      this.minimizeToTray.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
      this.minimizeToTray.Text = "Login Launcher";
      this.minimizeToTray.MouseClick += new MouseEventHandler(this.TrayRestoreFromTaskBar);
      this.TrayRightClickMenu.Items.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.OpenToolStripMenuItem,
        (ToolStripItem) this.QuitToolStripMenuItem
      });
      this.TrayRightClickMenu.Name = "TrayRightClickMenu";
      this.TrayRightClickMenu.Size = new Size(101, 48);
      this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
      this.OpenToolStripMenuItem.Size = new Size(100, 22);
      this.OpenToolStripMenuItem.Text = "Open";
      this.OpenToolStripMenuItem.Click += new EventHandler(this.Tray_Restore);
      this.QuitToolStripMenuItem.Name = "QuitToolStripMenuItem";
      this.QuitToolStripMenuItem.Size = new Size(100, 22);
      this.QuitToolStripMenuItem.Text = "Quit";
      this.QuitToolStripMenuItem.Click += new EventHandler(this.TrayCloseLauncher);
      this.GameProcessTimer.Enabled = true;
      this.GameProcessTimer.Tick += new EventHandler(this.GameProgressCheck);
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackgroundImageLayout = ImageLayout.Stretch;
      this.ClientSize = new Size(385, 366);
      this.Controls.Add((Control) this.MainTab);
      this.DoubleBuffered = true;
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Margin = new Padding(3, 2, 3, 2);
      this.MaximizeBox = false;
      this.Name = nameof (MainForm);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Launcher - Translated by DjDarkBoyZ";
      this.FormClosing += new FormClosingEventHandler(this.TrayHideToTaskBar);
      this.MainTab.ResumeLayout(false);
      this.AccountLoginTab.ResumeLayout(false);
      this.RegistrationTab.ResumeLayout(false);
      this.ChangePasswordTab.ResumeLayout(false);
      this.StartGameTab.ResumeLayout(false);
      this.TrayRightClickMenu.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
