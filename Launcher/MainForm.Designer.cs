using Sunny.UI;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Launcher
{
    public partial class MainForm : global::System.Windows.Forms.Form
    {

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainTab = new Sunny.UI.UITabControl();
            this.AccountLoginTab = new System.Windows.Forms.TabPage();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LoginAccountLabel = new Sunny.UI.UISymbolButton();
            this.ForgotPasswordLabel = new Sunny.UI.UILinkLabel();
            this.AccountPasswordTextBox = new Sunny.UI.UITextBox();
            this.RegisterAccountLabel = new Sunny.UI.UISymbolButton();
            this.login_error_label = new Sunny.UI.UILabel();
            this.AccountTextBox = new Sunny.UI.UITextBox();
            this.RegistrationTab = new System.Windows.Forms.TabPage();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.Register_Back_To_LoginBtn = new Sunny.UI.UISymbolButton();
            this.RegistrationErrorLabel = new Sunny.UI.UILabel();
            this.Register_AccountBtn = new Sunny.UI.UISymbolButton();
            this.Register_SecretAnswerTextBox = new Sunny.UI.UITextBox();
            this.Register_PasswordTextBox = new Sunny.UI.UITextBox();
            this.Register_QuestionTextBox = new Sunny.UI.UITextBox();
            this.Register_AccountNameTextBox = new Sunny.UI.UITextBox();
            this.ChangePasswordTab = new System.Windows.Forms.TabPage();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.Modify_Back_To_LoginBtn = new Sunny.UI.UISymbolButton();
            this.Modify_ErrorLabel = new Sunny.UI.UILabel();
            this.Modify_PasswordBtn = new Sunny.UI.UISymbolButton();
            this.Modify_AnswerTextBox = new Sunny.UI.UITextBox();
            this.Modify_PasswordTextBox = new Sunny.UI.UITextBox();
            this.Modify_QuestionTextBox = new Sunny.UI.UITextBox();
            this.Modify_AccountNameTextBox = new Sunny.UI.UITextBox();
            this.StartGameTab = new System.Windows.Forms.TabPage();
            this.uiCheckBox2 = new Sunny.UI.UICheckBox();
            this.uiCheckBox1 = new Sunny.UI.UICheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.activate_account = new Sunny.UI.UISymbolButton();
            this.start_selected_zone = new Sunny.UI.UILinkLabel();
            this.GameServerList = new System.Windows.Forms.ListBox();
            this.Launcher_enterGameBtn = new Sunny.UI.UIButton();
            this.InterfaceUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.DataProcessTimer = new System.Windows.Forms.Timer(this.components);
            this.minimizeToTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.TrayRightClickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QuitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GameProcessTimer = new System.Windows.Forms.Timer(this.components);
            this.MainTab.SuspendLayout();
            this.AccountLoginTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.RegistrationTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.ChangePasswordTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.StartGameTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.TrayRightClickMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTab
            // 
            this.MainTab.Controls.Add(this.AccountLoginTab);
            this.MainTab.Controls.Add(this.RegistrationTab);
            this.MainTab.Controls.Add(this.ChangePasswordTab);
            this.MainTab.Controls.Add(this.StartGameTab);
            this.MainTab.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.MainTab.FillColor = System.Drawing.Color.Transparent;
            this.MainTab.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MainTab.ItemSize = new System.Drawing.Size(140, 15);
            this.MainTab.Location = new System.Drawing.Point(0, 0);
            this.MainTab.MainPage = "";
            this.MainTab.Margin = new System.Windows.Forms.Padding(0);
            this.MainTab.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.MainTab.Name = "MainTab";
            this.MainTab.Padding = new System.Drawing.Point(0, 0);
            this.MainTab.SelectedIndex = 0;
            this.MainTab.Size = new System.Drawing.Size(600, 430);
            this.MainTab.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.MainTab.Style = Sunny.UI.UIStyle.Custom;
            this.MainTab.StyleCustomMode = true;
            this.MainTab.TabBackColor = System.Drawing.Color.Transparent;
            this.MainTab.TabIndex = 9;
            this.MainTab.TabSelectedColor = System.Drawing.Color.Transparent;
            this.MainTab.TabSelectedForeColor = System.Drawing.Color.Transparent;
            this.MainTab.TabSelectedHighColor = System.Drawing.Color.Transparent;
            this.MainTab.TabSelectedHighColorSize = 0;
            this.MainTab.TabStop = false;
            this.MainTab.TabUnSelectedForeColor = System.Drawing.Color.Transparent;
            this.MainTab.TipsFont = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MainTab.TipsForeColor = System.Drawing.Color.Transparent;
            this.MainTab.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // AccountLoginTab
            // 
            this.AccountLoginTab.BackColor = System.Drawing.Color.Transparent;
            this.AccountLoginTab.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AccountLoginTab.BackgroundImage")));
            this.AccountLoginTab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.AccountLoginTab.Controls.Add(this.pictureBox2);
            this.AccountLoginTab.Controls.Add(this.pictureBox1);
            this.AccountLoginTab.Controls.Add(this.LoginAccountLabel);
            this.AccountLoginTab.Controls.Add(this.ForgotPasswordLabel);
            this.AccountLoginTab.Controls.Add(this.AccountPasswordTextBox);
            this.AccountLoginTab.Controls.Add(this.RegisterAccountLabel);
            this.AccountLoginTab.Controls.Add(this.login_error_label);
            this.AccountLoginTab.Controls.Add(this.AccountTextBox);
            this.AccountLoginTab.Location = new System.Drawing.Point(0, 15);
            this.AccountLoginTab.Margin = new System.Windows.Forms.Padding(0);
            this.AccountLoginTab.Name = "AccountLoginTab";
            this.AccountLoginTab.Size = new System.Drawing.Size(600, 415);
            this.AccountLoginTab.TabIndex = 0;
            this.AccountLoginTab.Text = "Login";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(553, 23);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(22, 22);
            this.pictureBox2.TabIndex = 18;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(127, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(384, 127);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // LoginAccountLabel
            // 
            this.LoginAccountLabel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LoginAccountLabel.BackgroundImage")));
            this.LoginAccountLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoginAccountLabel.FillColor = System.Drawing.Color.Transparent;
            this.LoginAccountLabel.FillColor2 = System.Drawing.Color.Transparent;
            this.LoginAccountLabel.FillDisableColor = System.Drawing.Color.Transparent;
            this.LoginAccountLabel.FillHoverColor = System.Drawing.Color.Transparent;
            this.LoginAccountLabel.FillPressColor = System.Drawing.Color.Transparent;
            this.LoginAccountLabel.FillSelectedColor = System.Drawing.Color.Transparent;
            this.LoginAccountLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LoginAccountLabel.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.LoginAccountLabel.Location = new System.Drawing.Point(120, 290);
            this.LoginAccountLabel.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.LoginAccountLabel.MinimumSize = new System.Drawing.Size(1, 1);
            this.LoginAccountLabel.Name = "LoginAccountLabel";
            this.LoginAccountLabel.RectColor = System.Drawing.Color.Transparent;
            this.LoginAccountLabel.RectHoverColor = System.Drawing.Color.LightSkyBlue;
            this.LoginAccountLabel.RectPressColor = System.Drawing.Color.DodgerBlue;
            this.LoginAccountLabel.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LoginAccountLabel.Size = new System.Drawing.Size(391, 36);
            this.LoginAccountLabel.Style = Sunny.UI.UIStyle.Custom;
            this.LoginAccountLabel.Symbol = 0;
            this.LoginAccountLabel.SymbolHoverColor = System.Drawing.Color.DodgerBlue;
            this.LoginAccountLabel.TabIndex = 2;
            this.LoginAccountLabel.TabStop = false;
            this.LoginAccountLabel.Text = "Login";
            this.LoginAccountLabel.TipsFont = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LoginAccountLabel.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.LoginAccountLabel.Click += new System.EventHandler(this.LoginAccountLabel_Click);
            // 
            // ForgotPasswordLabel
            // 
            this.ForgotPasswordLabel.ActiveLinkColor = System.Drawing.Color.DodgerBlue;
            this.ForgotPasswordLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForgotPasswordLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.ForgotPasswordLabel.LinkColor = System.Drawing.Color.LightSkyBlue;
            this.ForgotPasswordLabel.Location = new System.Drawing.Point(250, 265);
            this.ForgotPasswordLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ForgotPasswordLabel.Name = "ForgotPasswordLabel";
            this.ForgotPasswordLabel.Size = new System.Drawing.Size(134, 23);
            this.ForgotPasswordLabel.Style = Sunny.UI.UIStyle.Custom;
            this.ForgotPasswordLabel.TabIndex = 16;
            this.ForgotPasswordLabel.TabStop = true;
            this.ForgotPasswordLabel.Text = "Forgot Password?";
            this.ForgotPasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ForgotPasswordLabel.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.ForgotPasswordLabel.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ForgotPasswordLabel.Click += new System.EventHandler(this.Login_ForgotPassword_Click);
            // 
            // AccountPasswordTextBox
            // 
            this.AccountPasswordTextBox.ButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.AccountPasswordTextBox.ButtonFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.AccountPasswordTextBox.ButtonFillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.AccountPasswordTextBox.ButtonRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.AccountPasswordTextBox.ButtonRectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.AccountPasswordTextBox.ButtonRectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.AccountPasswordTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.AccountPasswordTextBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.AccountPasswordTextBox.FillColor2 = System.Drawing.Color.Transparent;
            this.AccountPasswordTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AccountPasswordTextBox.ForeColor = System.Drawing.Color.DodgerBlue;
            this.AccountPasswordTextBox.Location = new System.Drawing.Point(120, 205);
            this.AccountPasswordTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AccountPasswordTextBox.MinimumSize = new System.Drawing.Size(1, 14);
            this.AccountPasswordTextBox.Name = "AccountPasswordTextBox";
            this.AccountPasswordTextBox.PasswordChar = '*';
            this.AccountPasswordTextBox.RectColor = System.Drawing.Color.LightSkyBlue;
            this.AccountPasswordTextBox.ScrollBarBackColor = System.Drawing.Color.Transparent;
            this.AccountPasswordTextBox.ScrollBarColor = System.Drawing.Color.Transparent;
            this.AccountPasswordTextBox.ShowText = false;
            this.AccountPasswordTextBox.Size = new System.Drawing.Size(391, 36);
            this.AccountPasswordTextBox.Style = Sunny.UI.UIStyle.Custom;
            this.AccountPasswordTextBox.Symbol = 61475;
            this.AccountPasswordTextBox.SymbolColor = System.Drawing.Color.LightSkyBlue;
            this.AccountPasswordTextBox.SymbolSize = 22;
            this.AccountPasswordTextBox.TabIndex = 1;
            this.AccountPasswordTextBox.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.AccountPasswordTextBox.Watermark = "Password";
            this.AccountPasswordTextBox.WatermarkActiveColor = System.Drawing.Color.DodgerBlue;
            this.AccountPasswordTextBox.WatermarkColor = System.Drawing.Color.LightSkyBlue;
            this.AccountPasswordTextBox.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.AccountPasswordTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Login_PasswordKeyPress);
            // 
            // RegisterAccountLabel
            // 
            this.RegisterAccountLabel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("RegisterAccountLabel.BackgroundImage")));
            this.RegisterAccountLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RegisterAccountLabel.FillColor = System.Drawing.Color.Transparent;
            this.RegisterAccountLabel.FillColor2 = System.Drawing.Color.Transparent;
            this.RegisterAccountLabel.FillHoverColor = System.Drawing.Color.Transparent;
            this.RegisterAccountLabel.FillPressColor = System.Drawing.Color.Transparent;
            this.RegisterAccountLabel.FillSelectedColor = System.Drawing.Color.Transparent;
            this.RegisterAccountLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RegisterAccountLabel.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.RegisterAccountLabel.Location = new System.Drawing.Point(120, 330);
            this.RegisterAccountLabel.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.RegisterAccountLabel.MinimumSize = new System.Drawing.Size(1, 1);
            this.RegisterAccountLabel.Name = "RegisterAccountLabel";
            this.RegisterAccountLabel.RectColor = System.Drawing.Color.Transparent;
            this.RegisterAccountLabel.RectHoverColor = System.Drawing.Color.LightSkyBlue;
            this.RegisterAccountLabel.RectPressColor = System.Drawing.Color.DodgerBlue;
            this.RegisterAccountLabel.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.RegisterAccountLabel.Size = new System.Drawing.Size(391, 36);
            this.RegisterAccountLabel.Style = Sunny.UI.UIStyle.Custom;
            this.RegisterAccountLabel.Symbol = 0;
            this.RegisterAccountLabel.SymbolHoverColor = System.Drawing.Color.DodgerBlue;
            this.RegisterAccountLabel.TabIndex = 3;
            this.RegisterAccountLabel.TabStop = false;
            this.RegisterAccountLabel.Text = "Create Account";
            this.RegisterAccountLabel.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.RegisterAccountLabel.TipsFont = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RegisterAccountLabel.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.RegisterAccountLabel.Click += new System.EventHandler(this.Login_Registertab_Click);
            // 
            // login_error_label
            // 
            this.login_error_label.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.login_error_label.ForeColor = System.Drawing.Color.DodgerBlue;
            this.login_error_label.Location = new System.Drawing.Point(120, 245);
            this.login_error_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.login_error_label.Name = "login_error_label";
            this.login_error_label.Size = new System.Drawing.Size(391, 20);
            this.login_error_label.Style = Sunny.UI.UIStyle.Custom;
            this.login_error_label.TabIndex = 15;
            this.login_error_label.Text = "Error message";
            this.login_error_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.login_error_label.Visible = false;
            this.login_error_label.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // AccountTextBox
            // 
            this.AccountTextBox.ButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.AccountTextBox.ButtonFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.AccountTextBox.ButtonFillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.AccountTextBox.ButtonForeColor = System.Drawing.Color.Transparent;
            this.AccountTextBox.ButtonForeHoverColor = System.Drawing.Color.Transparent;
            this.AccountTextBox.ButtonForePressColor = System.Drawing.Color.Transparent;
            this.AccountTextBox.ButtonRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.AccountTextBox.ButtonRectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.AccountTextBox.ButtonRectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.AccountTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.AccountTextBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.AccountTextBox.FillColor2 = System.Drawing.Color.Transparent;
            this.AccountTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AccountTextBox.ForeColor = System.Drawing.Color.DodgerBlue;
            this.AccountTextBox.Location = new System.Drawing.Point(120, 159);
            this.AccountTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AccountTextBox.MinimumSize = new System.Drawing.Size(1, 14);
            this.AccountTextBox.Name = "AccountTextBox";
            this.AccountTextBox.RectColor = System.Drawing.Color.LightSkyBlue;
            this.AccountTextBox.RectDisableColor = System.Drawing.Color.White;
            this.AccountTextBox.RectReadOnlyColor = System.Drawing.Color.White;
            this.AccountTextBox.ScrollBarBackColor = System.Drawing.Color.Transparent;
            this.AccountTextBox.ScrollBarColor = System.Drawing.Color.Transparent;
            this.AccountTextBox.ShowText = false;
            this.AccountTextBox.Size = new System.Drawing.Size(391, 36);
            this.AccountTextBox.Style = Sunny.UI.UIStyle.Custom;
            this.AccountTextBox.Symbol = 61447;
            this.AccountTextBox.SymbolColor = System.Drawing.Color.LightSkyBlue;
            this.AccountTextBox.SymbolSize = 22;
            this.AccountTextBox.TabIndex = 0;
            this.AccountTextBox.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.AccountTextBox.Watermark = "Account Name";
            this.AccountTextBox.WatermarkActiveColor = System.Drawing.Color.DodgerBlue;
            this.AccountTextBox.WatermarkColor = System.Drawing.Color.LightSkyBlue;
            this.AccountTextBox.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // RegistrationTab
            // 
            this.RegistrationTab.BackColor = System.Drawing.Color.Transparent;
            this.RegistrationTab.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("RegistrationTab.BackgroundImage")));
            this.RegistrationTab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.RegistrationTab.Controls.Add(this.pictureBox3);
            this.RegistrationTab.Controls.Add(this.Register_Back_To_LoginBtn);
            this.RegistrationTab.Controls.Add(this.RegistrationErrorLabel);
            this.RegistrationTab.Controls.Add(this.Register_AccountBtn);
            this.RegistrationTab.Controls.Add(this.Register_SecretAnswerTextBox);
            this.RegistrationTab.Controls.Add(this.Register_PasswordTextBox);
            this.RegistrationTab.Controls.Add(this.Register_QuestionTextBox);
            this.RegistrationTab.Controls.Add(this.Register_AccountNameTextBox);
            this.RegistrationTab.Location = new System.Drawing.Point(0, 15);
            this.RegistrationTab.Margin = new System.Windows.Forms.Padding(0);
            this.RegistrationTab.Name = "RegistrationTab";
            this.RegistrationTab.Size = new System.Drawing.Size(200, 85);
            this.RegistrationTab.TabIndex = 1;
            this.RegistrationTab.Text = "Create Account";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(553, 23);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(22, 22);
            this.pictureBox3.TabIndex = 21;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox3_MouseClick);
            // 
            // Register_Back_To_LoginBtn
            // 
            this.Register_Back_To_LoginBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Register_Back_To_LoginBtn.BackgroundImage")));
            this.Register_Back_To_LoginBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Register_Back_To_LoginBtn.FillColor = System.Drawing.Color.Transparent;
            this.Register_Back_To_LoginBtn.FillColor2 = System.Drawing.Color.Transparent;
            this.Register_Back_To_LoginBtn.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.Register_Back_To_LoginBtn.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Register_Back_To_LoginBtn.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Register_Back_To_LoginBtn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Register_Back_To_LoginBtn.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.Register_Back_To_LoginBtn.Location = new System.Drawing.Point(120, 330);
            this.Register_Back_To_LoginBtn.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Register_Back_To_LoginBtn.MinimumSize = new System.Drawing.Size(1, 1);
            this.Register_Back_To_LoginBtn.Name = "Register_Back_To_LoginBtn";
            this.Register_Back_To_LoginBtn.RectColor = System.Drawing.Color.Transparent;
            this.Register_Back_To_LoginBtn.RectHoverColor = System.Drawing.Color.LightSkyBlue;
            this.Register_Back_To_LoginBtn.RectPressColor = System.Drawing.Color.DodgerBlue;
            this.Register_Back_To_LoginBtn.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Register_Back_To_LoginBtn.Size = new System.Drawing.Size(391, 36);
            this.Register_Back_To_LoginBtn.Style = Sunny.UI.UIStyle.Custom;
            this.Register_Back_To_LoginBtn.Symbol = 0;
            this.Register_Back_To_LoginBtn.SymbolHoverColor = System.Drawing.Color.DodgerBlue;
            this.Register_Back_To_LoginBtn.TabIndex = 20;
            this.Register_Back_To_LoginBtn.TabStop = false;
            this.Register_Back_To_LoginBtn.Text = "Return To Login";
            this.Register_Back_To_LoginBtn.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Register_Back_To_LoginBtn.TipsFont = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Register_Back_To_LoginBtn.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.Register_Back_To_LoginBtn.Click += new System.EventHandler(this.RegisterBackToLogin_Click);
            // 
            // RegistrationErrorLabel
            // 
            this.RegistrationErrorLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RegistrationErrorLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.RegistrationErrorLabel.Location = new System.Drawing.Point(120, 246);
            this.RegistrationErrorLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RegistrationErrorLabel.Name = "RegistrationErrorLabel";
            this.RegistrationErrorLabel.Size = new System.Drawing.Size(391, 20);
            this.RegistrationErrorLabel.Style = Sunny.UI.UIStyle.Custom;
            this.RegistrationErrorLabel.TabIndex = 17;
            this.RegistrationErrorLabel.Text = "Error message";
            this.RegistrationErrorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RegistrationErrorLabel.Visible = false;
            this.RegistrationErrorLabel.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // Register_AccountBtn
            // 
            this.Register_AccountBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Register_AccountBtn.BackgroundImage")));
            this.Register_AccountBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Register_AccountBtn.FillColor = System.Drawing.Color.Transparent;
            this.Register_AccountBtn.FillColor2 = System.Drawing.Color.Transparent;
            this.Register_AccountBtn.FillDisableColor = System.Drawing.Color.Transparent;
            this.Register_AccountBtn.FillHoverColor = System.Drawing.Color.Transparent;
            this.Register_AccountBtn.FillPressColor = System.Drawing.Color.Transparent;
            this.Register_AccountBtn.FillSelectedColor = System.Drawing.Color.Transparent;
            this.Register_AccountBtn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Register_AccountBtn.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.Register_AccountBtn.Location = new System.Drawing.Point(120, 290);
            this.Register_AccountBtn.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Register_AccountBtn.MinimumSize = new System.Drawing.Size(1, 1);
            this.Register_AccountBtn.Name = "Register_AccountBtn";
            this.Register_AccountBtn.RectColor = System.Drawing.Color.Transparent;
            this.Register_AccountBtn.RectHoverColor = System.Drawing.Color.LightSkyBlue;
            this.Register_AccountBtn.RectPressColor = System.Drawing.Color.DodgerBlue;
            this.Register_AccountBtn.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Register_AccountBtn.Size = new System.Drawing.Size(391, 36);
            this.Register_AccountBtn.Style = Sunny.UI.UIStyle.Custom;
            this.Register_AccountBtn.Symbol = 0;
            this.Register_AccountBtn.SymbolHoverColor = System.Drawing.Color.DodgerBlue;
            this.Register_AccountBtn.TabIndex = 16;
            this.Register_AccountBtn.TabStop = false;
            this.Register_AccountBtn.Text = "Create New Account";
            this.Register_AccountBtn.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Register_AccountBtn.TipsFont = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Register_AccountBtn.TipsForeColor = System.Drawing.Color.LightSkyBlue;
            this.Register_AccountBtn.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.Register_AccountBtn.Click += new System.EventHandler(this.RegisterAccount_Click);
            // 
            // Register_SecretAnswerTextBox
            // 
            this.Register_SecretAnswerTextBox.ButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Register_SecretAnswerTextBox.ButtonFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.Register_SecretAnswerTextBox.ButtonFillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Register_SecretAnswerTextBox.ButtonRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Register_SecretAnswerTextBox.ButtonRectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.Register_SecretAnswerTextBox.ButtonRectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Register_SecretAnswerTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Register_SecretAnswerTextBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Register_SecretAnswerTextBox.FillColor2 = System.Drawing.Color.Transparent;
            this.Register_SecretAnswerTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Register_SecretAnswerTextBox.ForeColor = System.Drawing.Color.DodgerBlue;
            this.Register_SecretAnswerTextBox.Location = new System.Drawing.Point(120, 205);
            this.Register_SecretAnswerTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Register_SecretAnswerTextBox.MinimumSize = new System.Drawing.Size(1, 14);
            this.Register_SecretAnswerTextBox.Name = "Register_SecretAnswerTextBox";
            this.Register_SecretAnswerTextBox.PasswordChar = '*';
            this.Register_SecretAnswerTextBox.RectColor = System.Drawing.Color.LightSkyBlue;
            this.Register_SecretAnswerTextBox.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Register_SecretAnswerTextBox.ShowText = false;
            this.Register_SecretAnswerTextBox.Size = new System.Drawing.Size(391, 36);
            this.Register_SecretAnswerTextBox.Style = Sunny.UI.UIStyle.Custom;
            this.Register_SecretAnswerTextBox.Symbol = 61530;
            this.Register_SecretAnswerTextBox.SymbolColor = System.Drawing.Color.LightSkyBlue;
            this.Register_SecretAnswerTextBox.SymbolSize = 22;
            this.Register_SecretAnswerTextBox.TabIndex = 4;
            this.Register_SecretAnswerTextBox.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.Register_SecretAnswerTextBox.Watermark = "Please Enter a Security Answer";
            this.Register_SecretAnswerTextBox.WatermarkActiveColor = System.Drawing.Color.DodgerBlue;
            this.Register_SecretAnswerTextBox.WatermarkColor = System.Drawing.Color.LightSkyBlue;
            this.Register_SecretAnswerTextBox.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // Register_PasswordTextBox
            // 
            this.Register_PasswordTextBox.ButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Register_PasswordTextBox.ButtonFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.Register_PasswordTextBox.ButtonFillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Register_PasswordTextBox.ButtonRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Register_PasswordTextBox.ButtonRectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.Register_PasswordTextBox.ButtonRectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Register_PasswordTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Register_PasswordTextBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Register_PasswordTextBox.FillColor2 = System.Drawing.Color.Transparent;
            this.Register_PasswordTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Register_PasswordTextBox.ForeColor = System.Drawing.Color.DodgerBlue;
            this.Register_PasswordTextBox.Location = new System.Drawing.Point(120, 113);
            this.Register_PasswordTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Register_PasswordTextBox.MinimumSize = new System.Drawing.Size(1, 14);
            this.Register_PasswordTextBox.Name = "Register_PasswordTextBox";
            this.Register_PasswordTextBox.PasswordChar = '*';
            this.Register_PasswordTextBox.RectColor = System.Drawing.Color.LightSkyBlue;
            this.Register_PasswordTextBox.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Register_PasswordTextBox.ShowText = false;
            this.Register_PasswordTextBox.Size = new System.Drawing.Size(391, 36);
            this.Register_PasswordTextBox.Style = Sunny.UI.UIStyle.Custom;
            this.Register_PasswordTextBox.Symbol = 61475;
            this.Register_PasswordTextBox.SymbolColor = System.Drawing.Color.LightSkyBlue;
            this.Register_PasswordTextBox.SymbolSize = 22;
            this.Register_PasswordTextBox.TabIndex = 2;
            this.Register_PasswordTextBox.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.Register_PasswordTextBox.Watermark = "Please Enter a Password";
            this.Register_PasswordTextBox.WatermarkActiveColor = System.Drawing.Color.DodgerBlue;
            this.Register_PasswordTextBox.WatermarkColor = System.Drawing.Color.LightSkyBlue;
            this.Register_PasswordTextBox.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // Register_QuestionTextBox
            // 
            this.Register_QuestionTextBox.ButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Register_QuestionTextBox.ButtonFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.Register_QuestionTextBox.ButtonFillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Register_QuestionTextBox.ButtonRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Register_QuestionTextBox.ButtonRectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.Register_QuestionTextBox.ButtonRectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Register_QuestionTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Register_QuestionTextBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Register_QuestionTextBox.FillColor2 = System.Drawing.Color.Transparent;
            this.Register_QuestionTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Register_QuestionTextBox.ForeColor = System.Drawing.Color.DodgerBlue;
            this.Register_QuestionTextBox.Location = new System.Drawing.Point(120, 159);
            this.Register_QuestionTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Register_QuestionTextBox.MinimumSize = new System.Drawing.Size(1, 14);
            this.Register_QuestionTextBox.Name = "Register_QuestionTextBox";
            this.Register_QuestionTextBox.RectColor = System.Drawing.Color.LightSkyBlue;
            this.Register_QuestionTextBox.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Register_QuestionTextBox.ShowText = false;
            this.Register_QuestionTextBox.Size = new System.Drawing.Size(391, 36);
            this.Register_QuestionTextBox.Style = Sunny.UI.UIStyle.Custom;
            this.Register_QuestionTextBox.Symbol = 61530;
            this.Register_QuestionTextBox.SymbolColor = System.Drawing.Color.LightSkyBlue;
            this.Register_QuestionTextBox.SymbolSize = 22;
            this.Register_QuestionTextBox.TabIndex = 3;
            this.Register_QuestionTextBox.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.Register_QuestionTextBox.Watermark = "Please Enter a Security Question";
            this.Register_QuestionTextBox.WatermarkActiveColor = System.Drawing.Color.DodgerBlue;
            this.Register_QuestionTextBox.WatermarkColor = System.Drawing.Color.LightSkyBlue;
            this.Register_QuestionTextBox.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // Register_AccountNameTextBox
            // 
            this.Register_AccountNameTextBox.ButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Register_AccountNameTextBox.ButtonFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.Register_AccountNameTextBox.ButtonFillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Register_AccountNameTextBox.ButtonRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Register_AccountNameTextBox.ButtonRectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.Register_AccountNameTextBox.ButtonRectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Register_AccountNameTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Register_AccountNameTextBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Register_AccountNameTextBox.FillColor2 = System.Drawing.Color.Transparent;
            this.Register_AccountNameTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Register_AccountNameTextBox.ForeColor = System.Drawing.Color.DodgerBlue;
            this.Register_AccountNameTextBox.Location = new System.Drawing.Point(120, 67);
            this.Register_AccountNameTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Register_AccountNameTextBox.MinimumSize = new System.Drawing.Size(1, 14);
            this.Register_AccountNameTextBox.Name = "Register_AccountNameTextBox";
            this.Register_AccountNameTextBox.RectColor = System.Drawing.Color.LightSkyBlue;
            this.Register_AccountNameTextBox.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Register_AccountNameTextBox.ShowText = false;
            this.Register_AccountNameTextBox.Size = new System.Drawing.Size(391, 36);
            this.Register_AccountNameTextBox.Style = Sunny.UI.UIStyle.Custom;
            this.Register_AccountNameTextBox.Symbol = 61447;
            this.Register_AccountNameTextBox.SymbolColor = System.Drawing.Color.LightSkyBlue;
            this.Register_AccountNameTextBox.SymbolSize = 22;
            this.Register_AccountNameTextBox.TabIndex = 1;
            this.Register_AccountNameTextBox.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.Register_AccountNameTextBox.Watermark = "Please Enter an Account Name";
            this.Register_AccountNameTextBox.WatermarkActiveColor = System.Drawing.Color.DodgerBlue;
            this.Register_AccountNameTextBox.WatermarkColor = System.Drawing.Color.LightSkyBlue;
            this.Register_AccountNameTextBox.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // ChangePasswordTab
            // 
            this.ChangePasswordTab.BackColor = System.Drawing.Color.Transparent;
            this.ChangePasswordTab.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ChangePasswordTab.BackgroundImage")));
            this.ChangePasswordTab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ChangePasswordTab.Controls.Add(this.pictureBox4);
            this.ChangePasswordTab.Controls.Add(this.Modify_Back_To_LoginBtn);
            this.ChangePasswordTab.Controls.Add(this.Modify_ErrorLabel);
            this.ChangePasswordTab.Controls.Add(this.Modify_PasswordBtn);
            this.ChangePasswordTab.Controls.Add(this.Modify_AnswerTextBox);
            this.ChangePasswordTab.Controls.Add(this.Modify_PasswordTextBox);
            this.ChangePasswordTab.Controls.Add(this.Modify_QuestionTextBox);
            this.ChangePasswordTab.Controls.Add(this.Modify_AccountNameTextBox);
            this.ChangePasswordTab.Location = new System.Drawing.Point(0, 15);
            this.ChangePasswordTab.Margin = new System.Windows.Forms.Padding(0);
            this.ChangePasswordTab.Name = "ChangePasswordTab";
            this.ChangePasswordTab.Size = new System.Drawing.Size(200, 85);
            this.ChangePasswordTab.TabIndex = 2;
            this.ChangePasswordTab.Text = "Change Password";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(553, 23);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(22, 22);
            this.pictureBox4.TabIndex = 25;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // Modify_Back_To_LoginBtn
            // 
            this.Modify_Back_To_LoginBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Modify_Back_To_LoginBtn.BackgroundImage")));
            this.Modify_Back_To_LoginBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Modify_Back_To_LoginBtn.FillColor = System.Drawing.Color.Transparent;
            this.Modify_Back_To_LoginBtn.FillColor2 = System.Drawing.Color.Transparent;
            this.Modify_Back_To_LoginBtn.FillDisableColor = System.Drawing.Color.Transparent;
            this.Modify_Back_To_LoginBtn.FillHoverColor = System.Drawing.Color.Transparent;
            this.Modify_Back_To_LoginBtn.FillPressColor = System.Drawing.Color.Transparent;
            this.Modify_Back_To_LoginBtn.FillSelectedColor = System.Drawing.Color.Transparent;
            this.Modify_Back_To_LoginBtn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Modify_Back_To_LoginBtn.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.Modify_Back_To_LoginBtn.Location = new System.Drawing.Point(120, 330);
            this.Modify_Back_To_LoginBtn.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Modify_Back_To_LoginBtn.MinimumSize = new System.Drawing.Size(1, 1);
            this.Modify_Back_To_LoginBtn.Name = "Modify_Back_To_LoginBtn";
            this.Modify_Back_To_LoginBtn.RectColor = System.Drawing.Color.Transparent;
            this.Modify_Back_To_LoginBtn.RectHoverColor = System.Drawing.Color.LightSkyBlue;
            this.Modify_Back_To_LoginBtn.RectPressColor = System.Drawing.Color.DodgerBlue;
            this.Modify_Back_To_LoginBtn.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Modify_Back_To_LoginBtn.Size = new System.Drawing.Size(391, 36);
            this.Modify_Back_To_LoginBtn.Style = Sunny.UI.UIStyle.Custom;
            this.Modify_Back_To_LoginBtn.Symbol = 0;
            this.Modify_Back_To_LoginBtn.TabIndex = 24;
            this.Modify_Back_To_LoginBtn.TabStop = false;
            this.Modify_Back_To_LoginBtn.Text = "Return To Login";
            this.Modify_Back_To_LoginBtn.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Modify_Back_To_LoginBtn.TipsFont = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Modify_Back_To_LoginBtn.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.Modify_Back_To_LoginBtn.Click += new System.EventHandler(this.Modify_BackToLogin_Click);
            // 
            // Modify_ErrorLabel
            // 
            this.Modify_ErrorLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Modify_ErrorLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.Modify_ErrorLabel.Location = new System.Drawing.Point(120, 246);
            this.Modify_ErrorLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Modify_ErrorLabel.Name = "Modify_ErrorLabel";
            this.Modify_ErrorLabel.Size = new System.Drawing.Size(391, 20);
            this.Modify_ErrorLabel.Style = Sunny.UI.UIStyle.Custom;
            this.Modify_ErrorLabel.TabIndex = 22;
            this.Modify_ErrorLabel.Text = "Error message";
            this.Modify_ErrorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Modify_ErrorLabel.Visible = false;
            this.Modify_ErrorLabel.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // Modify_PasswordBtn
            // 
            this.Modify_PasswordBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Modify_PasswordBtn.BackgroundImage")));
            this.Modify_PasswordBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Modify_PasswordBtn.FillColor = System.Drawing.Color.Transparent;
            this.Modify_PasswordBtn.FillColor2 = System.Drawing.Color.Transparent;
            this.Modify_PasswordBtn.FillDisableColor = System.Drawing.Color.Transparent;
            this.Modify_PasswordBtn.FillHoverColor = System.Drawing.Color.Transparent;
            this.Modify_PasswordBtn.FillPressColor = System.Drawing.Color.Transparent;
            this.Modify_PasswordBtn.FillSelectedColor = System.Drawing.Color.Transparent;
            this.Modify_PasswordBtn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Modify_PasswordBtn.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.Modify_PasswordBtn.Location = new System.Drawing.Point(120, 290);
            this.Modify_PasswordBtn.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Modify_PasswordBtn.MinimumSize = new System.Drawing.Size(1, 1);
            this.Modify_PasswordBtn.Name = "Modify_PasswordBtn";
            this.Modify_PasswordBtn.RectColor = System.Drawing.Color.Transparent;
            this.Modify_PasswordBtn.RectHoverColor = System.Drawing.Color.LightSkyBlue;
            this.Modify_PasswordBtn.RectPressColor = System.Drawing.Color.DodgerBlue;
            this.Modify_PasswordBtn.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Modify_PasswordBtn.Size = new System.Drawing.Size(391, 36);
            this.Modify_PasswordBtn.Style = Sunny.UI.UIStyle.Custom;
            this.Modify_PasswordBtn.Symbol = 0;
            this.Modify_PasswordBtn.TabIndex = 21;
            this.Modify_PasswordBtn.TabStop = false;
            this.Modify_PasswordBtn.Text = "Change Password";
            this.Modify_PasswordBtn.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Modify_PasswordBtn.TipsFont = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Modify_PasswordBtn.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.Modify_PasswordBtn.Click += new System.EventHandler(this.Modify_ChangePassword_Click);
            // 
            // Modify_AnswerTextBox
            // 
            this.Modify_AnswerTextBox.ButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Modify_AnswerTextBox.ButtonFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.Modify_AnswerTextBox.ButtonFillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Modify_AnswerTextBox.ButtonRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Modify_AnswerTextBox.ButtonRectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.Modify_AnswerTextBox.ButtonRectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Modify_AnswerTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Modify_AnswerTextBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Modify_AnswerTextBox.FillColor2 = System.Drawing.Color.Transparent;
            this.Modify_AnswerTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Modify_AnswerTextBox.ForeColor = System.Drawing.Color.DodgerBlue;
            this.Modify_AnswerTextBox.Location = new System.Drawing.Point(120, 205);
            this.Modify_AnswerTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Modify_AnswerTextBox.MinimumSize = new System.Drawing.Size(1, 14);
            this.Modify_AnswerTextBox.Name = "Modify_AnswerTextBox";
            this.Modify_AnswerTextBox.PasswordChar = '*';
            this.Modify_AnswerTextBox.RectColor = System.Drawing.Color.LightSkyBlue;
            this.Modify_AnswerTextBox.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Modify_AnswerTextBox.ShowText = false;
            this.Modify_AnswerTextBox.Size = new System.Drawing.Size(391, 36);
            this.Modify_AnswerTextBox.Style = Sunny.UI.UIStyle.Custom;
            this.Modify_AnswerTextBox.Symbol = 61530;
            this.Modify_AnswerTextBox.SymbolColor = System.Drawing.Color.LightSkyBlue;
            this.Modify_AnswerTextBox.SymbolSize = 22;
            this.Modify_AnswerTextBox.TabIndex = 20;
            this.Modify_AnswerTextBox.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.Modify_AnswerTextBox.Watermark = "Please Enter your Security Answer";
            this.Modify_AnswerTextBox.WatermarkActiveColor = System.Drawing.Color.DodgerBlue;
            this.Modify_AnswerTextBox.WatermarkColor = System.Drawing.Color.LightSkyBlue;
            this.Modify_AnswerTextBox.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // Modify_PasswordTextBox
            // 
            this.Modify_PasswordTextBox.ButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Modify_PasswordTextBox.ButtonFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.Modify_PasswordTextBox.ButtonFillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Modify_PasswordTextBox.ButtonRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Modify_PasswordTextBox.ButtonRectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.Modify_PasswordTextBox.ButtonRectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Modify_PasswordTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Modify_PasswordTextBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Modify_PasswordTextBox.FillColor2 = System.Drawing.Color.Transparent;
            this.Modify_PasswordTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Modify_PasswordTextBox.ForeColor = System.Drawing.Color.DodgerBlue;
            this.Modify_PasswordTextBox.Location = new System.Drawing.Point(120, 113);
            this.Modify_PasswordTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Modify_PasswordTextBox.MinimumSize = new System.Drawing.Size(1, 14);
            this.Modify_PasswordTextBox.Name = "Modify_PasswordTextBox";
            this.Modify_PasswordTextBox.PasswordChar = '*';
            this.Modify_PasswordTextBox.RectColor = System.Drawing.Color.LightSkyBlue;
            this.Modify_PasswordTextBox.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Modify_PasswordTextBox.ShowText = false;
            this.Modify_PasswordTextBox.Size = new System.Drawing.Size(391, 36);
            this.Modify_PasswordTextBox.Style = Sunny.UI.UIStyle.Custom;
            this.Modify_PasswordTextBox.Symbol = 61475;
            this.Modify_PasswordTextBox.SymbolColor = System.Drawing.Color.LightSkyBlue;
            this.Modify_PasswordTextBox.SymbolSize = 22;
            this.Modify_PasswordTextBox.TabIndex = 18;
            this.Modify_PasswordTextBox.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.Modify_PasswordTextBox.Watermark = "Please Enter a New Password";
            this.Modify_PasswordTextBox.WatermarkActiveColor = System.Drawing.Color.DodgerBlue;
            this.Modify_PasswordTextBox.WatermarkColor = System.Drawing.Color.LightSkyBlue;
            this.Modify_PasswordTextBox.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // Modify_QuestionTextBox
            // 
            this.Modify_QuestionTextBox.ButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Modify_QuestionTextBox.ButtonFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.Modify_QuestionTextBox.ButtonFillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Modify_QuestionTextBox.ButtonRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Modify_QuestionTextBox.ButtonRectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.Modify_QuestionTextBox.ButtonRectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Modify_QuestionTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Modify_QuestionTextBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Modify_QuestionTextBox.FillColor2 = System.Drawing.Color.Transparent;
            this.Modify_QuestionTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Modify_QuestionTextBox.ForeColor = System.Drawing.Color.DodgerBlue;
            this.Modify_QuestionTextBox.Location = new System.Drawing.Point(120, 159);
            this.Modify_QuestionTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Modify_QuestionTextBox.MinimumSize = new System.Drawing.Size(1, 14);
            this.Modify_QuestionTextBox.Name = "Modify_QuestionTextBox";
            this.Modify_QuestionTextBox.RectColor = System.Drawing.Color.LightSkyBlue;
            this.Modify_QuestionTextBox.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Modify_QuestionTextBox.ShowText = false;
            this.Modify_QuestionTextBox.Size = new System.Drawing.Size(391, 36);
            this.Modify_QuestionTextBox.Style = Sunny.UI.UIStyle.Custom;
            this.Modify_QuestionTextBox.Symbol = 61530;
            this.Modify_QuestionTextBox.SymbolColor = System.Drawing.Color.LightSkyBlue;
            this.Modify_QuestionTextBox.SymbolSize = 22;
            this.Modify_QuestionTextBox.TabIndex = 19;
            this.Modify_QuestionTextBox.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.Modify_QuestionTextBox.Watermark = "Please Enter your Security Question";
            this.Modify_QuestionTextBox.WatermarkActiveColor = System.Drawing.Color.DodgerBlue;
            this.Modify_QuestionTextBox.WatermarkColor = System.Drawing.Color.LightSkyBlue;
            this.Modify_QuestionTextBox.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // Modify_AccountNameTextBox
            // 
            this.Modify_AccountNameTextBox.ButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Modify_AccountNameTextBox.ButtonFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.Modify_AccountNameTextBox.ButtonFillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Modify_AccountNameTextBox.ButtonRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Modify_AccountNameTextBox.ButtonRectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.Modify_AccountNameTextBox.ButtonRectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Modify_AccountNameTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Modify_AccountNameTextBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Modify_AccountNameTextBox.FillColor2 = System.Drawing.Color.Transparent;
            this.Modify_AccountNameTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Modify_AccountNameTextBox.ForeColor = System.Drawing.Color.DodgerBlue;
            this.Modify_AccountNameTextBox.Location = new System.Drawing.Point(120, 67);
            this.Modify_AccountNameTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Modify_AccountNameTextBox.MinimumSize = new System.Drawing.Size(1, 14);
            this.Modify_AccountNameTextBox.Name = "Modify_AccountNameTextBox";
            this.Modify_AccountNameTextBox.RectColor = System.Drawing.Color.LightSkyBlue;
            this.Modify_AccountNameTextBox.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Modify_AccountNameTextBox.ShowText = false;
            this.Modify_AccountNameTextBox.Size = new System.Drawing.Size(391, 36);
            this.Modify_AccountNameTextBox.Style = Sunny.UI.UIStyle.Custom;
            this.Modify_AccountNameTextBox.Symbol = 61447;
            this.Modify_AccountNameTextBox.SymbolColor = System.Drawing.Color.LightSkyBlue;
            this.Modify_AccountNameTextBox.SymbolSize = 22;
            this.Modify_AccountNameTextBox.TabIndex = 17;
            this.Modify_AccountNameTextBox.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.Modify_AccountNameTextBox.Watermark = "Please Enter your Existing Account Name";
            this.Modify_AccountNameTextBox.WatermarkActiveColor = System.Drawing.Color.DodgerBlue;
            this.Modify_AccountNameTextBox.WatermarkColor = System.Drawing.Color.LightSkyBlue;
            this.Modify_AccountNameTextBox.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // StartGameTab
            // 
            this.StartGameTab.BackColor = System.Drawing.Color.Transparent;
            this.StartGameTab.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("StartGameTab.BackgroundImage")));
            this.StartGameTab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.StartGameTab.Controls.Add(this.uiCheckBox2);
            this.StartGameTab.Controls.Add(this.uiCheckBox1);
            this.StartGameTab.Controls.Add(this.label1);
            this.StartGameTab.Controls.Add(this.pictureBox5);
            this.StartGameTab.Controls.Add(this.activate_account);
            this.StartGameTab.Controls.Add(this.start_selected_zone);
            this.StartGameTab.Controls.Add(this.GameServerList);
            this.StartGameTab.Controls.Add(this.Launcher_enterGameBtn);
            this.StartGameTab.Location = new System.Drawing.Point(0, 15);
            this.StartGameTab.Margin = new System.Windows.Forms.Padding(0);
            this.StartGameTab.Name = "StartGameTab";
            this.StartGameTab.Size = new System.Drawing.Size(200, 85);
            this.StartGameTab.TabIndex = 3;
            this.StartGameTab.Text = "Start Game";
            // 
            // uiCheckBox2
            // 
            this.uiCheckBox2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uiCheckBox2.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.uiCheckBox2.Location = new System.Drawing.Point(399, 296);
            this.uiCheckBox2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiCheckBox2.Name = "uiCheckBox2";
            this.uiCheckBox2.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.uiCheckBox2.Size = new System.Drawing.Size(150, 29);
            this.uiCheckBox2.Style = Sunny.UI.UIStyle.Custom;
            this.uiCheckBox2.TabIndex = 29;
            this.uiCheckBox2.Text = "64Bit";
            this.uiCheckBox2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiCheckBox2.CheckedChanged += new System.EventHandler(this.uiCheckBox2_CheckedChanged);
            // 
            // uiCheckBox1
            // 
            this.uiCheckBox1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uiCheckBox1.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.uiCheckBox1.Location = new System.Drawing.Point(399, 271);
            this.uiCheckBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiCheckBox1.Name = "uiCheckBox1";
            this.uiCheckBox1.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.uiCheckBox1.Size = new System.Drawing.Size(150, 29);
            this.uiCheckBox1.Style = Sunny.UI.UIStyle.Custom;
            this.uiCheckBox1.TabIndex = 28;
            this.uiCheckBox1.Text = "32Bit";
            this.uiCheckBox1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiCheckBox1.CheckedChanged += new System.EventHandler(this.uiCheckBox1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.label1.Location = new System.Drawing.Point(270, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 14);
            this.label1.TabIndex = 27;
            this.label1.Text = "Server Selection";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Location = new System.Drawing.Point(553, 23);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(22, 22);
            this.pictureBox5.TabIndex = 26;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // activate_account
            // 
            this.activate_account.Cursor = System.Windows.Forms.Cursors.Hand;
            this.activate_account.Enabled = false;
            this.activate_account.FillColor = System.Drawing.Color.Transparent;
            this.activate_account.FillColor2 = System.Drawing.Color.Transparent;
            this.activate_account.FillDisableColor = System.Drawing.Color.Transparent;
            this.activate_account.FillHoverColor = System.Drawing.Color.Transparent;
            this.activate_account.FillPressColor = System.Drawing.Color.Transparent;
            this.activate_account.FillSelectedColor = System.Drawing.Color.Transparent;
            this.activate_account.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.activate_account.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.activate_account.ForeDisableColor = System.Drawing.Color.LightSkyBlue;
            this.activate_account.ForeHoverColor = System.Drawing.Color.LightSkyBlue;
            this.activate_account.ForePressColor = System.Drawing.Color.LightSkyBlue;
            this.activate_account.ForeSelectedColor = System.Drawing.Color.LightSkyBlue;
            this.activate_account.Location = new System.Drawing.Point(153, 60);
            this.activate_account.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.activate_account.MinimumSize = new System.Drawing.Size(1, 1);
            this.activate_account.Name = "activate_account";
            this.activate_account.Radius = 15;
            this.activate_account.RectColor = System.Drawing.Color.Transparent;
            this.activate_account.RectDisableColor = System.Drawing.Color.Transparent;
            this.activate_account.RectHoverColor = System.Drawing.Color.Transparent;
            this.activate_account.RectPressColor = System.Drawing.Color.Transparent;
            this.activate_account.RectSelectedColor = System.Drawing.Color.Transparent;
            this.activate_account.Size = new System.Drawing.Size(295, 37);
            this.activate_account.Style = Sunny.UI.UIStyle.Custom;
            this.activate_account.Symbol = 57607;
            this.activate_account.SymbolColor = System.Drawing.Color.LightSkyBlue;
            this.activate_account.SymbolDisableColor = System.Drawing.Color.LightSkyBlue;
            this.activate_account.SymbolHoverColor = System.Drawing.Color.LightSkyBlue;
            this.activate_account.SymbolPressColor = System.Drawing.Color.LightSkyBlue;
            this.activate_account.SymbolSelectedColor = System.Drawing.Color.LightSkyBlue;
            this.activate_account.TabIndex = 9;
            this.activate_account.Text = "Account Name";
            this.activate_account.TipsFont = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.activate_account.TipsForeColor = System.Drawing.Color.LightSkyBlue;
            this.activate_account.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // start_selected_zone
            // 
            this.start_selected_zone.ActiveLinkColor = System.Drawing.Color.DodgerBlue;
            this.start_selected_zone.Enabled = false;
            this.start_selected_zone.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.start_selected_zone.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.start_selected_zone.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.start_selected_zone.LinkColor = System.Drawing.Color.DodgerBlue;
            this.start_selected_zone.Location = new System.Drawing.Point(411, 157);
            this.start_selected_zone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.start_selected_zone.Name = "start_selected_zone";
            this.start_selected_zone.Size = new System.Drawing.Size(138, 31);
            this.start_selected_zone.Style = Sunny.UI.UIStyle.Custom;
            this.start_selected_zone.TabIndex = 7;
            this.start_selected_zone.TabStop = true;
            this.start_selected_zone.Text = "Server";
            this.start_selected_zone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.start_selected_zone.Visible = false;
            this.start_selected_zone.VisitedLinkColor = System.Drawing.Color.DodgerBlue;
            this.start_selected_zone.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // GameServerList
            // 
            this.GameServerList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.GameServerList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.GameServerList.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GameServerList.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.GameServerList.FormattingEnabled = true;
            this.GameServerList.ItemHeight = 20;
            this.GameServerList.Items.AddRange(new object[] {
            "Dragon Server",
            "Phoenix Server"});
            this.GameServerList.Location = new System.Drawing.Point(241, 113);
            this.GameServerList.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.GameServerList.Name = "GameServerList";
            this.GameServerList.Size = new System.Drawing.Size(139, 213);
            this.GameServerList.TabIndex = 4;
            this.GameServerList.TabStop = false;
            this.GameServerList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.StartupChoosegameServer_DrawItem);
            this.GameServerList.SelectedIndexChanged += new System.EventHandler(this.StartupChooseGS_SelectedIndexChanged);
            // 
            // Launcher_enterGameBtn
            // 
            this.Launcher_enterGameBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Launcher_enterGameBtn.BackgroundImage")));
            this.Launcher_enterGameBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Launcher_enterGameBtn.FillColor = System.Drawing.Color.Transparent;
            this.Launcher_enterGameBtn.FillColor2 = System.Drawing.Color.Transparent;
            this.Launcher_enterGameBtn.FillDisableColor = System.Drawing.Color.Transparent;
            this.Launcher_enterGameBtn.FillHoverColor = System.Drawing.Color.Transparent;
            this.Launcher_enterGameBtn.FillPressColor = System.Drawing.Color.Transparent;
            this.Launcher_enterGameBtn.FillSelectedColor = System.Drawing.Color.Transparent;
            this.Launcher_enterGameBtn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Launcher_enterGameBtn.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.Launcher_enterGameBtn.ForeHoverColor = System.Drawing.Color.DodgerBlue;
            this.Launcher_enterGameBtn.Location = new System.Drawing.Point(120, 330);
            this.Launcher_enterGameBtn.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Launcher_enterGameBtn.MinimumSize = new System.Drawing.Size(1, 1);
            this.Launcher_enterGameBtn.Name = "Launcher_enterGameBtn";
            this.Launcher_enterGameBtn.RectColor = System.Drawing.Color.Transparent;
            this.Launcher_enterGameBtn.RectHoverColor = System.Drawing.Color.LightSkyBlue;
            this.Launcher_enterGameBtn.RectPressColor = System.Drawing.Color.DodgerBlue;
            this.Launcher_enterGameBtn.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(70)))), ((int)(((byte)(28)))));
            this.Launcher_enterGameBtn.Size = new System.Drawing.Size(391, 36);
            this.Launcher_enterGameBtn.Style = Sunny.UI.UIStyle.Custom;
            this.Launcher_enterGameBtn.TabIndex = 1;
            this.Launcher_enterGameBtn.TabStop = false;
            this.Launcher_enterGameBtn.Text = "Enter Game";
            this.Launcher_enterGameBtn.TipsFont = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Launcher_enterGameBtn.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.Launcher_enterGameBtn.Click += new System.EventHandler(this.Launch_EnterGame_Click);
            // 
            // InterfaceUpdateTimer
            // 
            this.InterfaceUpdateTimer.Interval = 30000;
            this.InterfaceUpdateTimer.Tick += new System.EventHandler(this.UIUnlock);
            // 
            // DataProcessTimer
            // 
            this.DataProcessTimer.Enabled = true;
            this.DataProcessTimer.Tick += new System.EventHandler(this.PacketProcess);
            // 
            // minimizeToTray
            // 
            this.minimizeToTray.ContextMenuStrip = this.TrayRightClickMenu;
            this.minimizeToTray.Icon = ((System.Drawing.Icon)(resources.GetObject("minimizeToTray.Icon")));
            this.minimizeToTray.Text = "Mir3D Launcher";
            this.minimizeToTray.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TrayRestoreFromTaskBar);
            // 
            // TrayRightClickMenu
            // 
            this.TrayRightClickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenToolStripMenuItem,
            this.QuitToolStripMenuItem});
            this.TrayRightClickMenu.Name = "TrayRightClickMenu";
            this.TrayRightClickMenu.Size = new System.Drawing.Size(104, 48);
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.OpenToolStripMenuItem.Text = "Open";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.Tray_Restore);
            // 
            // QuitToolStripMenuItem
            // 
            this.QuitToolStripMenuItem.Name = "QuitToolStripMenuItem";
            this.QuitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.QuitToolStripMenuItem.Text = "Quit";
            this.QuitToolStripMenuItem.Click += new System.EventHandler(this.TrayCloseLauncher);
            // 
            // GameProcessTimer
            // 
            this.GameProcessTimer.Enabled = true;
            this.GameProcessTimer.Tick += new System.EventHandler(this.GameProgressCheck);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(600, 430);
            this.Controls.Add(this.MainTab);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Transparent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TransparencyKey = System.Drawing.Color.Black;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TrayHideToTaskBar);
            this.MainTab.ResumeLayout(false);
            this.AccountLoginTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.RegistrationTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ChangePasswordTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.StartGameTab.ResumeLayout(false);
            this.StartGameTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.TrayRightClickMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private IContainer components;
        private global::System.Windows.Forms.TabPage AccountLoginTab;
        private UILinkLabel ForgotPasswordLabel;
        private UISymbolButton RegisterAccountLabel;
        private UISymbolButton LoginAccountLabel;
        private UITextBox AccountPasswordTextBox;
        private UITextBox AccountTextBox;
        private global::System.Windows.Forms.TabPage RegistrationTab;
        private global::System.Windows.Forms.TabPage ChangePasswordTab;
        private global::System.Windows.Forms.TabPage StartGameTab;
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
        private global::System.Windows.Forms.ListBox GameServerList;
        private UISymbolButton Register_Back_To_LoginBtn;
        private UISymbolButton Modify_Back_To_LoginBtn;
        private System.Windows.Forms.Timer InterfaceUpdateTimer;
        public UITabControl MainTab;
        public UILabel login_error_label;
        private System.Windows.Forms.Timer DataProcessTimer;
        private UISymbolButton activate_account;
        private global::System.Windows.Forms.NotifyIcon minimizeToTray;
        private global::System.Windows.Forms.ContextMenuStrip TrayRightClickMenu;
        private global::System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private global::System.Windows.Forms.ToolStripMenuItem QuitToolStripMenuItem;
        private System.Windows.Forms.Timer GameProcessTimer;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private UILinkLabel start_selected_zone;
        private PictureBox pictureBox5;
        private Label label1;
        private UICheckBox uiCheckBox2;
        private UICheckBox uiCheckBox1;
    }
}