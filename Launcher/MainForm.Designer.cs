namespace Launcher
{
	// Token: 0x02000003 RID: 3
	public partial class MainForm : global::System.Windows.Forms.Form
	{
		// Token: 0x0600001A RID: 26 RVA: 0x000034CB File Offset: 0x000016CB
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600001B RID: 27 RVA: 0x000034EC File Offset: 0x000016EC
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.主选项卡 = new Sunny.UI.UITabControl();
            this.账号登录页面 = new System.Windows.Forms.TabPage();
            this.登录_登录验证显示框 = new System.Windows.Forms.PictureBox();
            this.登录_登录验证输入框 = new Sunny.UI.UITextBox();
            this.登录_用户图标 = new Sunny.UI.UIAvatar();
            this.登录_登录账号按钮 = new Sunny.UI.UISymbolButton();
            this.登录_忘记密码选项 = new Sunny.UI.UILinkLabel();
            this.登录_账号密码输入框 = new Sunny.UI.UITextBox();
            this.登录_注册账号按钮 = new Sunny.UI.UISymbolButton();
            this.登录_错误提示标签 = new Sunny.UI.UILabel();
            this.登录_账号名字输入框 = new Sunny.UI.UITextBox();
            this.账号注册页面 = new System.Windows.Forms.TabPage();
            this.注册_注册验证显示 = new System.Windows.Forms.PictureBox();
            this.注册_注册验证输入框 = new Sunny.UI.UITextBox();
            this.注册_返回登录按钮 = new Sunny.UI.UISymbolButton();
            this.注册_错误提示标签 = new Sunny.UI.UILabel();
            this.注册_注册账号按钮 = new Sunny.UI.UISymbolButton();
            this.注册_密保答案输入框 = new Sunny.UI.UITextBox();
            this.注册_账号密码输入框 = new Sunny.UI.UITextBox();
            this.注册_密保问题输入框 = new Sunny.UI.UITextBox();
            this.注册_账号名字输入框 = new Sunny.UI.UITextBox();
            this.密码修改页面 = new System.Windows.Forms.TabPage();
            this.修改_修改验证显示 = new System.Windows.Forms.PictureBox();
            this.修改_修改验证输入框 = new Sunny.UI.UITextBox();
            this.修改_返回登录按钮 = new Sunny.UI.UISymbolButton();
            this.修改_错误提示标签 = new Sunny.UI.UILabel();
            this.修改_修改密码按钮 = new Sunny.UI.UISymbolButton();
            this.修改_密保答案输入框 = new Sunny.UI.UITextBox();
            this.修改_账号密码输入框 = new Sunny.UI.UITextBox();
            this.修改_密保问题输入框 = new Sunny.UI.UITextBox();
            this.修改_账号名字输入框 = new Sunny.UI.UITextBox();
            this.启动游戏页面 = new System.Windows.Forms.TabPage();
            this.启动_当前账号标签 = new Sunny.UI.UISymbolButton();
            this.启动_当前选择标签 = new Sunny.UI.UILabel();
            this.启动_选中区服标签 = new Sunny.UI.UILinkLabel();
            this.启动_注销账号标签 = new Sunny.UI.UILinkLabel();
            this.启动_选择游戏区服 = new System.Windows.Forms.ListBox();
            this.启动_进入游戏按钮 = new Sunny.UI.UIButton();
            this.用户界面计时 = new System.Windows.Forms.Timer(this.components);
            this.数据处理计时 = new System.Windows.Forms.Timer(this.components);
            this.最小化到托盘 = new System.Windows.Forms.NotifyIcon(this.components);
            this.托盘右键菜单 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.游戏进程监测 = new System.Windows.Forms.Timer(this.components);
            this.主选项卡.SuspendLayout();
            this.账号登录页面.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.登录_登录验证显示框)).BeginInit();
            this.账号注册页面.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.注册_注册验证显示)).BeginInit();
            this.密码修改页面.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.修改_修改验证显示)).BeginInit();
            this.启动游戏页面.SuspendLayout();
            this.托盘右键菜单.SuspendLayout();
            this.SuspendLayout();
            // 
            // 主选项卡
            // 
            this.主选项卡.Controls.Add(this.账号登录页面);
            this.主选项卡.Controls.Add(this.账号注册页面);
            this.主选项卡.Controls.Add(this.密码修改页面);
            this.主选项卡.Controls.Add(this.启动游戏页面);
            this.主选项卡.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.主选项卡.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.主选项卡.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.主选项卡.ItemSize = new System.Drawing.Size(260, 28);
            this.主选项卡.Location = new System.Drawing.Point(0, 0);
            this.主选项卡.MainPage = "";
            this.主选项卡.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.主选项卡.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.主选项卡.Name = "主选项卡";
            this.主选项卡.SelectedIndex = 0;
            this.主选项卡.Size = new System.Drawing.Size(441, 488);
            this.主选项卡.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.主选项卡.Style = Sunny.UI.UIStyle.LayuiRed;
            this.主选项卡.StyleCustomMode = true;
            this.主选项卡.TabIndex = 9;
            this.主选项卡.TabSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.主选项卡.TabSelectedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.主选项卡.TabSelectedHighColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.主选项卡.TabSelectedHighColorSize = 0;
            this.主选项卡.TabStop = false;
            this.主选项卡.TabUnSelectedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.主选项卡.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // 账号登录页面
            // 
            this.账号登录页面.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.账号登录页面.Controls.Add(this.登录_登录验证显示框);
            this.账号登录页面.Controls.Add(this.登录_登录验证输入框);
            this.账号登录页面.Controls.Add(this.登录_用户图标);
            this.账号登录页面.Controls.Add(this.登录_登录账号按钮);
            this.账号登录页面.Controls.Add(this.登录_忘记密码选项);
            this.账号登录页面.Controls.Add(this.登录_账号密码输入框);
            this.账号登录页面.Controls.Add(this.登录_注册账号按钮);
            this.账号登录页面.Controls.Add(this.登录_错误提示标签);
            this.账号登录页面.Controls.Add(this.登录_账号名字输入框);
            this.账号登录页面.Location = new System.Drawing.Point(0, 28);
            this.账号登录页面.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.账号登录页面.Name = "账号登录页面";
            this.账号登录页面.Size = new System.Drawing.Size(441, 460);
            this.账号登录页面.TabIndex = 0;
            this.账号登录页面.Text = "账号登录";
            // 
            // 登录_登录验证显示框
            // 
            this.登录_登录验证显示框.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.登录_登录验证显示框.Location = new System.Drawing.Point(177, 181);
            this.登录_登录验证显示框.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.登录_登录验证显示框.Name = "登录_登录验证显示框";
            this.登录_登录验证显示框.Size = new System.Drawing.Size(139, 38);
            this.登录_登录验证显示框.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.登录_登录验证显示框.TabIndex = 20;
            this.登录_登录验证显示框.TabStop = false;
            this.登录_登录验证显示框.Click += new System.EventHandler(this.登录_登录验证显示_Click);
            // 
            // 登录_登录验证输入框
            // 
            this.登录_登录验证输入框.ButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.登录_登录验证输入框.ButtonFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.登录_登录验证输入框.ButtonFillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.登录_登录验证输入框.ButtonRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.登录_登录验证输入框.ButtonRectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.登录_登录验证输入框.ButtonRectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.登录_登录验证输入框.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.登录_登录验证输入框.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.登录_登录验证输入框.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.登录_登录验证输入框.Location = new System.Drawing.Point(28, 181);
            this.登录_登录验证输入框.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.登录_登录验证输入框.MinimumSize = new System.Drawing.Size(1, 15);
            this.登录_登录验证输入框.Name = "登录_登录验证输入框";
            this.登录_登录验证输入框.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.登录_登录验证输入框.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.登录_登录验证输入框.ShowText = false;
            this.登录_登录验证输入框.Size = new System.Drawing.Size(140, 39);
            this.登录_登录验证输入框.Style = Sunny.UI.UIStyle.Red;
            this.登录_登录验证输入框.Symbol = 362139;
            this.登录_登录验证输入框.SymbolSize = 22;
            this.登录_登录验证输入框.TabIndex = 3;
            this.登录_登录验证输入框.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.登录_登录验证输入框.Watermark = "验证码";
            // 
            // 登录_用户图标
            // 
            this.登录_用户图标.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.登录_用户图标.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.登录_用户图标.Location = new System.Drawing.Point(139, 17);
            this.登录_用户图标.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.登录_用户图标.MinimumSize = new System.Drawing.Size(1, 1);
            this.登录_用户图标.Name = "登录_用户图标";
            this.登录_用户图标.Size = new System.Drawing.Size(60, 60);
            this.登录_用户图标.Style = Sunny.UI.UIStyle.Red;
            this.登录_用户图标.TabIndex = 10;
            this.登录_用户图标.TabStop = false;
            // 
            // 登录_登录账号按钮
            // 
            this.登录_登录账号按钮.Cursor = System.Windows.Forms.Cursors.Hand;
            this.登录_登录账号按钮.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.登录_登录账号按钮.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.登录_登录账号按钮.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.登录_登录账号按钮.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.登录_登录账号按钮.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.登录_登录账号按钮.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.登录_登录账号按钮.Location = new System.Drawing.Point(28, 283);
            this.登录_登录账号按钮.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.登录_登录账号按钮.MinimumSize = new System.Drawing.Size(1, 1);
            this.登录_登录账号按钮.Name = "登录_登录账号按钮";
            this.登录_登录账号按钮.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.登录_登录账号按钮.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.登录_登录账号按钮.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.登录_登录账号按钮.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.登录_登录账号按钮.Size = new System.Drawing.Size(289, 39);
            this.登录_登录账号按钮.Style = Sunny.UI.UIStyle.Red;
            this.登录_登录账号按钮.TabIndex = 13;
            this.登录_登录账号按钮.TabStop = false;
            this.登录_登录账号按钮.Text = "登录";
            this.登录_登录账号按钮.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.登录_登录账号按钮.Click += new System.EventHandler(this.登录_登录账号按钮_Click);
            // 
            // 登录_忘记密码选项
            // 
            this.登录_忘记密码选项.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(155)))), ((int)(((byte)(40)))));
            this.登录_忘记密码选项.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.登录_忘记密码选项.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.登录_忘记密码选项.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.登录_忘记密码选项.Location = new System.Drawing.Point(231, 223);
            this.登录_忘记密码选项.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.登录_忘记密码选项.Name = "登录_忘记密码选项";
            this.登录_忘记密码选项.Size = new System.Drawing.Size(87, 24);
            this.登录_忘记密码选项.Style = Sunny.UI.UIStyle.Red;
            this.登录_忘记密码选项.TabIndex = 16;
            this.登录_忘记密码选项.TabStop = true;
            this.登录_忘记密码选项.Text = "忘记密码?";
            this.登录_忘记密码选项.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.登录_忘记密码选项.Click += new System.EventHandler(this.登录_忘记密码选项_Click);
            // 
            // 登录_账号密码输入框
            // 
            this.登录_账号密码输入框.ButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.登录_账号密码输入框.ButtonFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.登录_账号密码输入框.ButtonFillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.登录_账号密码输入框.ButtonRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.登录_账号密码输入框.ButtonRectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.登录_账号密码输入框.ButtonRectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.登录_账号密码输入框.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.登录_账号密码输入框.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.登录_账号密码输入框.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.登录_账号密码输入框.Location = new System.Drawing.Point(28, 135);
            this.登录_账号密码输入框.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.登录_账号密码输入框.MinimumSize = new System.Drawing.Size(1, 15);
            this.登录_账号密码输入框.Name = "登录_账号密码输入框";
            this.登录_账号密码输入框.PasswordChar = '*';
            this.登录_账号密码输入框.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.登录_账号密码输入框.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.登录_账号密码输入框.ShowText = false;
            this.登录_账号密码输入框.Size = new System.Drawing.Size(289, 39);
            this.登录_账号密码输入框.Style = Sunny.UI.UIStyle.Red;
            this.登录_账号密码输入框.Symbol = 61475;
            this.登录_账号密码输入框.SymbolSize = 22;
            this.登录_账号密码输入框.TabIndex = 2;
            this.登录_账号密码输入框.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.登录_账号密码输入框.Watermark = "请输入密码";
            // 
            // 登录_注册账号按钮
            // 
            this.登录_注册账号按钮.Cursor = System.Windows.Forms.Cursors.Hand;
            this.登录_注册账号按钮.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.登录_注册账号按钮.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.登录_注册账号按钮.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.登录_注册账号按钮.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.登录_注册账号按钮.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.登录_注册账号按钮.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.登录_注册账号按钮.Location = new System.Drawing.Point(28, 341);
            this.登录_注册账号按钮.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.登录_注册账号按钮.MinimumSize = new System.Drawing.Size(1, 1);
            this.登录_注册账号按钮.Name = "登录_注册账号按钮";
            this.登录_注册账号按钮.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.登录_注册账号按钮.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.登录_注册账号按钮.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.登录_注册账号按钮.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.登录_注册账号按钮.Size = new System.Drawing.Size(289, 39);
            this.登录_注册账号按钮.Style = Sunny.UI.UIStyle.Red;
            this.登录_注册账号按钮.Symbol = 62004;
            this.登录_注册账号按钮.TabIndex = 14;
            this.登录_注册账号按钮.TabStop = false;
            this.登录_注册账号按钮.Text = "注册";
            this.登录_注册账号按钮.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.登录_注册账号按钮.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.登录_注册账号按钮.Click += new System.EventHandler(this.登录_注册账号按钮_Click);
            // 
            // 登录_错误提示标签
            // 
            this.登录_错误提示标签.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.登录_错误提示标签.ForeColor = System.Drawing.Color.Red;
            this.登录_错误提示标签.Location = new System.Drawing.Point(28, 259);
            this.登录_错误提示标签.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.登录_错误提示标签.Name = "登录_错误提示标签";
            this.登录_错误提示标签.Size = new System.Drawing.Size(225, 21);
            this.登录_错误提示标签.Style = Sunny.UI.UIStyle.Custom;
            this.登录_错误提示标签.TabIndex = 15;
            this.登录_错误提示标签.Text = "错误提示";
            this.登录_错误提示标签.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.登录_错误提示标签.Visible = false;
            // 
            // 登录_账号名字输入框
            // 
            this.登录_账号名字输入框.ButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.登录_账号名字输入框.ButtonFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.登录_账号名字输入框.ButtonFillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.登录_账号名字输入框.ButtonRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.登录_账号名字输入框.ButtonRectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.登录_账号名字输入框.ButtonRectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.登录_账号名字输入框.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.登录_账号名字输入框.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.登录_账号名字输入框.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.登录_账号名字输入框.Location = new System.Drawing.Point(28, 85);
            this.登录_账号名字输入框.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.登录_账号名字输入框.MinimumSize = new System.Drawing.Size(1, 15);
            this.登录_账号名字输入框.Name = "登录_账号名字输入框";
            this.登录_账号名字输入框.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.登录_账号名字输入框.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.登录_账号名字输入框.ShowText = false;
            this.登录_账号名字输入框.Size = new System.Drawing.Size(289, 39);
            this.登录_账号名字输入框.Style = Sunny.UI.UIStyle.Red;
            this.登录_账号名字输入框.Symbol = 61447;
            this.登录_账号名字输入框.SymbolSize = 22;
            this.登录_账号名字输入框.TabIndex = 1;
            this.登录_账号名字输入框.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.登录_账号名字输入框.Watermark = "请输入账号";
            // 
            // 账号注册页面
            // 
            this.账号注册页面.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.账号注册页面.Controls.Add(this.注册_注册验证显示);
            this.账号注册页面.Controls.Add(this.注册_注册验证输入框);
            this.账号注册页面.Controls.Add(this.注册_返回登录按钮);
            this.账号注册页面.Controls.Add(this.注册_错误提示标签);
            this.账号注册页面.Controls.Add(this.注册_注册账号按钮);
            this.账号注册页面.Controls.Add(this.注册_密保答案输入框);
            this.账号注册页面.Controls.Add(this.注册_账号密码输入框);
            this.账号注册页面.Controls.Add(this.注册_密保问题输入框);
            this.账号注册页面.Controls.Add(this.注册_账号名字输入框);
            this.账号注册页面.Location = new System.Drawing.Point(0, 28);
            this.账号注册页面.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.账号注册页面.Name = "账号注册页面";
            this.账号注册页面.Size = new System.Drawing.Size(441, 460);
            this.账号注册页面.TabIndex = 1;
            this.账号注册页面.Text = "账号注册";
            // 
            // 注册_注册验证显示
            // 
            this.注册_注册验证显示.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.注册_注册验证显示.Location = new System.Drawing.Point(173, 211);
            this.注册_注册验证显示.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.注册_注册验证显示.Name = "注册_注册验证显示";
            this.注册_注册验证显示.Size = new System.Drawing.Size(138, 39);
            this.注册_注册验证显示.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.注册_注册验证显示.TabIndex = 22;
            this.注册_注册验证显示.TabStop = false;
            this.注册_注册验证显示.Click += new System.EventHandler(this.登录_登录验证显示_Click);
            // 
            // 注册_注册验证输入框
            // 
            this.注册_注册验证输入框.ButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.注册_注册验证输入框.ButtonFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.注册_注册验证输入框.ButtonFillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.注册_注册验证输入框.ButtonRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.注册_注册验证输入框.ButtonRectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.注册_注册验证输入框.ButtonRectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.注册_注册验证输入框.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.注册_注册验证输入框.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.注册_注册验证输入框.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.注册_注册验证输入框.Location = new System.Drawing.Point(28, 211);
            this.注册_注册验证输入框.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.注册_注册验证输入框.MinimumSize = new System.Drawing.Size(1, 15);
            this.注册_注册验证输入框.Name = "注册_注册验证输入框";
            this.注册_注册验证输入框.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.注册_注册验证输入框.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.注册_注册验证输入框.ShowText = false;
            this.注册_注册验证输入框.Size = new System.Drawing.Size(139, 40);
            this.注册_注册验证输入框.Style = Sunny.UI.UIStyle.Red;
            this.注册_注册验证输入框.Symbol = 362139;
            this.注册_注册验证输入框.SymbolSize = 22;
            this.注册_注册验证输入框.TabIndex = 5;
            this.注册_注册验证输入框.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.注册_注册验证输入框.Watermark = "验证码";
            // 
            // 注册_返回登录按钮
            // 
            this.注册_返回登录按钮.Cursor = System.Windows.Forms.Cursors.Hand;
            this.注册_返回登录按钮.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.注册_返回登录按钮.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.注册_返回登录按钮.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.注册_返回登录按钮.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.注册_返回登录按钮.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.注册_返回登录按钮.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.注册_返回登录按钮.Location = new System.Drawing.Point(28, 351);
            this.注册_返回登录按钮.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.注册_返回登录按钮.MinimumSize = new System.Drawing.Size(1, 1);
            this.注册_返回登录按钮.Name = "注册_返回登录按钮";
            this.注册_返回登录按钮.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.注册_返回登录按钮.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.注册_返回登录按钮.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.注册_返回登录按钮.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.注册_返回登录按钮.Size = new System.Drawing.Size(284, 40);
            this.注册_返回登录按钮.Style = Sunny.UI.UIStyle.Red;
            this.注册_返回登录按钮.Symbol = 61730;
            this.注册_返回登录按钮.TabIndex = 20;
            this.注册_返回登录按钮.TabStop = false;
            this.注册_返回登录按钮.Text = "返回登录";
            this.注册_返回登录按钮.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.注册_返回登录按钮.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.注册_返回登录按钮.Click += new System.EventHandler(this.注册_返回登录按钮_Click);
            // 
            // 注册_错误提示标签
            // 
            this.注册_错误提示标签.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.注册_错误提示标签.ForeColor = System.Drawing.Color.Red;
            this.注册_错误提示标签.Location = new System.Drawing.Point(28, 259);
            this.注册_错误提示标签.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.注册_错误提示标签.Name = "注册_错误提示标签";
            this.注册_错误提示标签.Size = new System.Drawing.Size(284, 31);
            this.注册_错误提示标签.Style = Sunny.UI.UIStyle.Custom;
            this.注册_错误提示标签.TabIndex = 17;
            this.注册_错误提示标签.Text = "错误提示";
            this.注册_错误提示标签.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.注册_错误提示标签.Visible = false;
            // 
            // 注册_注册账号按钮
            // 
            this.注册_注册账号按钮.Cursor = System.Windows.Forms.Cursors.Hand;
            this.注册_注册账号按钮.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.注册_注册账号按钮.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.注册_注册账号按钮.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.注册_注册账号按钮.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.注册_注册账号按钮.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.注册_注册账号按钮.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.注册_注册账号按钮.Location = new System.Drawing.Point(28, 292);
            this.注册_注册账号按钮.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.注册_注册账号按钮.MinimumSize = new System.Drawing.Size(1, 1);
            this.注册_注册账号按钮.Name = "注册_注册账号按钮";
            this.注册_注册账号按钮.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.注册_注册账号按钮.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.注册_注册账号按钮.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.注册_注册账号按钮.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.注册_注册账号按钮.Size = new System.Drawing.Size(284, 40);
            this.注册_注册账号按钮.Style = Sunny.UI.UIStyle.Red;
            this.注册_注册账号按钮.Symbol = 62004;
            this.注册_注册账号按钮.TabIndex = 16;
            this.注册_注册账号按钮.TabStop = false;
            this.注册_注册账号按钮.Text = "注册账号";
            this.注册_注册账号按钮.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.注册_注册账号按钮.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.注册_注册账号按钮.Click += new System.EventHandler(this.注册_注册账号按钮_Click);
            // 
            // 注册_密保答案输入框
            // 
            this.注册_密保答案输入框.ButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.注册_密保答案输入框.ButtonFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.注册_密保答案输入框.ButtonFillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.注册_密保答案输入框.ButtonRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.注册_密保答案输入框.ButtonRectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.注册_密保答案输入框.ButtonRectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.注册_密保答案输入框.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.注册_密保答案输入框.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.注册_密保答案输入框.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.注册_密保答案输入框.Location = new System.Drawing.Point(28, 161);
            this.注册_密保答案输入框.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.注册_密保答案输入框.MinimumSize = new System.Drawing.Size(1, 15);
            this.注册_密保答案输入框.Name = "注册_密保答案输入框";
            this.注册_密保答案输入框.PasswordChar = '*';
            this.注册_密保答案输入框.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.注册_密保答案输入框.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.注册_密保答案输入框.ShowText = false;
            this.注册_密保答案输入框.Size = new System.Drawing.Size(284, 40);
            this.注册_密保答案输入框.Style = Sunny.UI.UIStyle.Red;
            this.注册_密保答案输入框.Symbol = 61716;
            this.注册_密保答案输入框.SymbolSize = 22;
            this.注册_密保答案输入框.TabIndex = 4;
            this.注册_密保答案输入框.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.注册_密保答案输入框.Watermark = "请输入密保答案";
            // 
            // 注册_账号密码输入框
            // 
            this.注册_账号密码输入框.ButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.注册_账号密码输入框.ButtonFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.注册_账号密码输入框.ButtonFillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.注册_账号密码输入框.ButtonRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.注册_账号密码输入框.ButtonRectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.注册_账号密码输入框.ButtonRectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.注册_账号密码输入框.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.注册_账号密码输入框.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.注册_账号密码输入框.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.注册_账号密码输入框.Location = new System.Drawing.Point(28, 63);
            this.注册_账号密码输入框.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.注册_账号密码输入框.MinimumSize = new System.Drawing.Size(1, 15);
            this.注册_账号密码输入框.Name = "注册_账号密码输入框";
            this.注册_账号密码输入框.PasswordChar = '*';
            this.注册_账号密码输入框.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.注册_账号密码输入框.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.注册_账号密码输入框.ShowText = false;
            this.注册_账号密码输入框.Size = new System.Drawing.Size(284, 40);
            this.注册_账号密码输入框.Style = Sunny.UI.UIStyle.Red;
            this.注册_账号密码输入框.Symbol = 61475;
            this.注册_账号密码输入框.SymbolSize = 22;
            this.注册_账号密码输入框.TabIndex = 2;
            this.注册_账号密码输入框.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.注册_账号密码输入框.Watermark = "请输入密码";
            // 
            // 注册_密保问题输入框
            // 
            this.注册_密保问题输入框.ButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.注册_密保问题输入框.ButtonFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.注册_密保问题输入框.ButtonFillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.注册_密保问题输入框.ButtonRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.注册_密保问题输入框.ButtonRectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.注册_密保问题输入框.ButtonRectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.注册_密保问题输入框.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.注册_密保问题输入框.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.注册_密保问题输入框.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.注册_密保问题输入框.Location = new System.Drawing.Point(28, 112);
            this.注册_密保问题输入框.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.注册_密保问题输入框.MinimumSize = new System.Drawing.Size(1, 15);
            this.注册_密保问题输入框.Name = "注册_密保问题输入框";
            this.注册_密保问题输入框.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.注册_密保问题输入框.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.注册_密保问题输入框.ShowText = false;
            this.注册_密保问题输入框.Size = new System.Drawing.Size(284, 40);
            this.注册_密保问题输入框.Style = Sunny.UI.UIStyle.Red;
            this.注册_密保问题输入框.Symbol = 61563;
            this.注册_密保问题输入框.SymbolSize = 22;
            this.注册_密保问题输入框.TabIndex = 3;
            this.注册_密保问题输入框.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.注册_密保问题输入框.Watermark = "请输入密保问题";
            // 
            // 注册_账号名字输入框
            // 
            this.注册_账号名字输入框.ButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.注册_账号名字输入框.ButtonFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.注册_账号名字输入框.ButtonFillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.注册_账号名字输入框.ButtonRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.注册_账号名字输入框.ButtonRectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.注册_账号名字输入框.ButtonRectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.注册_账号名字输入框.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.注册_账号名字输入框.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.注册_账号名字输入框.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.注册_账号名字输入框.Location = new System.Drawing.Point(28, 13);
            this.注册_账号名字输入框.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.注册_账号名字输入框.MinimumSize = new System.Drawing.Size(1, 15);
            this.注册_账号名字输入框.Name = "注册_账号名字输入框";
            this.注册_账号名字输入框.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.注册_账号名字输入框.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.注册_账号名字输入框.ShowText = false;
            this.注册_账号名字输入框.Size = new System.Drawing.Size(284, 40);
            this.注册_账号名字输入框.Style = Sunny.UI.UIStyle.Red;
            this.注册_账号名字输入框.Symbol = 61447;
            this.注册_账号名字输入框.SymbolSize = 22;
            this.注册_账号名字输入框.TabIndex = 1;
            this.注册_账号名字输入框.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.注册_账号名字输入框.Watermark = "请输入账号";
            // 
            // 密码修改页面
            // 
            this.密码修改页面.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.密码修改页面.Controls.Add(this.修改_修改验证显示);
            this.密码修改页面.Controls.Add(this.修改_修改验证输入框);
            this.密码修改页面.Controls.Add(this.修改_返回登录按钮);
            this.密码修改页面.Controls.Add(this.修改_错误提示标签);
            this.密码修改页面.Controls.Add(this.修改_修改密码按钮);
            this.密码修改页面.Controls.Add(this.修改_密保答案输入框);
            this.密码修改页面.Controls.Add(this.修改_账号密码输入框);
            this.密码修改页面.Controls.Add(this.修改_密保问题输入框);
            this.密码修改页面.Controls.Add(this.修改_账号名字输入框);
            this.密码修改页面.Location = new System.Drawing.Point(0, 28);
            this.密码修改页面.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.密码修改页面.Name = "密码修改页面";
            this.密码修改页面.Size = new System.Drawing.Size(441, 460);
            this.密码修改页面.TabIndex = 2;
            this.密码修改页面.Text = "密码修改";
            // 
            // 修改_修改验证显示
            // 
            this.修改_修改验证显示.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.修改_修改验证显示.Location = new System.Drawing.Point(175, 211);
            this.修改_修改验证显示.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.修改_修改验证显示.Name = "修改_修改验证显示";
            this.修改_修改验证显示.Size = new System.Drawing.Size(138, 39);
            this.修改_修改验证显示.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.修改_修改验证显示.TabIndex = 26;
            this.修改_修改验证显示.TabStop = false;
            this.修改_修改验证显示.Click += new System.EventHandler(this.登录_登录验证显示_Click);
            // 
            // 修改_修改验证输入框
            // 
            this.修改_修改验证输入框.ButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.修改_修改验证输入框.ButtonFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.修改_修改验证输入框.ButtonFillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.修改_修改验证输入框.ButtonRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.修改_修改验证输入框.ButtonRectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.修改_修改验证输入框.ButtonRectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.修改_修改验证输入框.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.修改_修改验证输入框.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.修改_修改验证输入框.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.修改_修改验证输入框.Location = new System.Drawing.Point(28, 211);
            this.修改_修改验证输入框.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.修改_修改验证输入框.MinimumSize = new System.Drawing.Size(1, 15);
            this.修改_修改验证输入框.Name = "修改_修改验证输入框";
            this.修改_修改验证输入框.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.修改_修改验证输入框.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.修改_修改验证输入框.ShowText = false;
            this.修改_修改验证输入框.Size = new System.Drawing.Size(139, 40);
            this.修改_修改验证输入框.Style = Sunny.UI.UIStyle.Red;
            this.修改_修改验证输入框.Symbol = 362139;
            this.修改_修改验证输入框.SymbolSize = 22;
            this.修改_修改验证输入框.TabIndex = 25;
            this.修改_修改验证输入框.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.修改_修改验证输入框.Watermark = "验证码";
            // 
            // 修改_返回登录按钮
            // 
            this.修改_返回登录按钮.Cursor = System.Windows.Forms.Cursors.Hand;
            this.修改_返回登录按钮.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.修改_返回登录按钮.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.修改_返回登录按钮.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.修改_返回登录按钮.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.修改_返回登录按钮.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.修改_返回登录按钮.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.修改_返回登录按钮.Location = new System.Drawing.Point(28, 349);
            this.修改_返回登录按钮.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.修改_返回登录按钮.MinimumSize = new System.Drawing.Size(1, 1);
            this.修改_返回登录按钮.Name = "修改_返回登录按钮";
            this.修改_返回登录按钮.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.修改_返回登录按钮.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.修改_返回登录按钮.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.修改_返回登录按钮.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.修改_返回登录按钮.Size = new System.Drawing.Size(284, 40);
            this.修改_返回登录按钮.Style = Sunny.UI.UIStyle.Red;
            this.修改_返回登录按钮.Symbol = 61730;
            this.修改_返回登录按钮.TabIndex = 24;
            this.修改_返回登录按钮.TabStop = false;
            this.修改_返回登录按钮.Text = "返回登录";
            this.修改_返回登录按钮.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.修改_返回登录按钮.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.修改_返回登录按钮.Click += new System.EventHandler(this.修改_返回登录按钮_Click);
            // 
            // 修改_错误提示标签
            // 
            this.修改_错误提示标签.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.修改_错误提示标签.ForeColor = System.Drawing.Color.Red;
            this.修改_错误提示标签.Location = new System.Drawing.Point(24, 267);
            this.修改_错误提示标签.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.修改_错误提示标签.Name = "修改_错误提示标签";
            this.修改_错误提示标签.Size = new System.Drawing.Size(288, 21);
            this.修改_错误提示标签.Style = Sunny.UI.UIStyle.Custom;
            this.修改_错误提示标签.TabIndex = 22;
            this.修改_错误提示标签.Text = "错误提示";
            this.修改_错误提示标签.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.修改_错误提示标签.Visible = false;
            // 
            // 修改_修改密码按钮
            // 
            this.修改_修改密码按钮.Cursor = System.Windows.Forms.Cursors.Hand;
            this.修改_修改密码按钮.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.修改_修改密码按钮.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.修改_修改密码按钮.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.修改_修改密码按钮.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.修改_修改密码按钮.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.修改_修改密码按钮.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.修改_修改密码按钮.Location = new System.Drawing.Point(28, 292);
            this.修改_修改密码按钮.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.修改_修改密码按钮.MinimumSize = new System.Drawing.Size(1, 1);
            this.修改_修改密码按钮.Name = "修改_修改密码按钮";
            this.修改_修改密码按钮.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.修改_修改密码按钮.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.修改_修改密码按钮.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.修改_修改密码按钮.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.修改_修改密码按钮.Size = new System.Drawing.Size(284, 40);
            this.修改_修改密码按钮.Style = Sunny.UI.UIStyle.Red;
            this.修改_修改密码按钮.Symbol = 61573;
            this.修改_修改密码按钮.TabIndex = 21;
            this.修改_修改密码按钮.TabStop = false;
            this.修改_修改密码按钮.Text = "修改密码";
            this.修改_修改密码按钮.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.修改_修改密码按钮.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.修改_修改密码按钮.Click += new System.EventHandler(this.修改_修改密码按钮_Click);
            // 
            // 修改_密保答案输入框
            // 
            this.修改_密保答案输入框.ButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.修改_密保答案输入框.ButtonFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.修改_密保答案输入框.ButtonFillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.修改_密保答案输入框.ButtonRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.修改_密保答案输入框.ButtonRectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.修改_密保答案输入框.ButtonRectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.修改_密保答案输入框.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.修改_密保答案输入框.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.修改_密保答案输入框.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.修改_密保答案输入框.Location = new System.Drawing.Point(28, 161);
            this.修改_密保答案输入框.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.修改_密保答案输入框.MinimumSize = new System.Drawing.Size(1, 15);
            this.修改_密保答案输入框.Name = "修改_密保答案输入框";
            this.修改_密保答案输入框.PasswordChar = '*';
            this.修改_密保答案输入框.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.修改_密保答案输入框.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.修改_密保答案输入框.ShowText = false;
            this.修改_密保答案输入框.Size = new System.Drawing.Size(284, 40);
            this.修改_密保答案输入框.Style = Sunny.UI.UIStyle.Red;
            this.修改_密保答案输入框.Symbol = 61716;
            this.修改_密保答案输入框.SymbolSize = 22;
            this.修改_密保答案输入框.TabIndex = 20;
            this.修改_密保答案输入框.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.修改_密保答案输入框.Watermark = "请输入密保答案";
            // 
            // 修改_账号密码输入框
            // 
            this.修改_账号密码输入框.ButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.修改_账号密码输入框.ButtonFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.修改_账号密码输入框.ButtonFillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.修改_账号密码输入框.ButtonRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.修改_账号密码输入框.ButtonRectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.修改_账号密码输入框.ButtonRectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.修改_账号密码输入框.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.修改_账号密码输入框.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.修改_账号密码输入框.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.修改_账号密码输入框.Location = new System.Drawing.Point(28, 63);
            this.修改_账号密码输入框.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.修改_账号密码输入框.MinimumSize = new System.Drawing.Size(1, 15);
            this.修改_账号密码输入框.Name = "修改_账号密码输入框";
            this.修改_账号密码输入框.PasswordChar = '*';
            this.修改_账号密码输入框.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.修改_账号密码输入框.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.修改_账号密码输入框.ShowText = false;
            this.修改_账号密码输入框.Size = new System.Drawing.Size(284, 40);
            this.修改_账号密码输入框.Style = Sunny.UI.UIStyle.Red;
            this.修改_账号密码输入框.Symbol = 61475;
            this.修改_账号密码输入框.SymbolSize = 22;
            this.修改_账号密码输入框.TabIndex = 18;
            this.修改_账号密码输入框.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.修改_账号密码输入框.Watermark = "请输入新的密码";
            // 
            // 修改_密保问题输入框
            // 
            this.修改_密保问题输入框.ButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.修改_密保问题输入框.ButtonFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.修改_密保问题输入框.ButtonFillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.修改_密保问题输入框.ButtonRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.修改_密保问题输入框.ButtonRectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.修改_密保问题输入框.ButtonRectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.修改_密保问题输入框.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.修改_密保问题输入框.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.修改_密保问题输入框.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.修改_密保问题输入框.Location = new System.Drawing.Point(28, 112);
            this.修改_密保问题输入框.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.修改_密保问题输入框.MinimumSize = new System.Drawing.Size(1, 15);
            this.修改_密保问题输入框.Name = "修改_密保问题输入框";
            this.修改_密保问题输入框.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.修改_密保问题输入框.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.修改_密保问题输入框.ShowText = false;
            this.修改_密保问题输入框.Size = new System.Drawing.Size(284, 40);
            this.修改_密保问题输入框.Style = Sunny.UI.UIStyle.Red;
            this.修改_密保问题输入框.Symbol = 61563;
            this.修改_密保问题输入框.SymbolSize = 22;
            this.修改_密保问题输入框.TabIndex = 19;
            this.修改_密保问题输入框.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.修改_密保问题输入框.Watermark = "请输入密保问题";
            // 
            // 修改_账号名字输入框
            // 
            this.修改_账号名字输入框.ButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.修改_账号名字输入框.ButtonFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.修改_账号名字输入框.ButtonFillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.修改_账号名字输入框.ButtonRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.修改_账号名字输入框.ButtonRectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.修改_账号名字输入框.ButtonRectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.修改_账号名字输入框.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.修改_账号名字输入框.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.修改_账号名字输入框.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.修改_账号名字输入框.Location = new System.Drawing.Point(28, 13);
            this.修改_账号名字输入框.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.修改_账号名字输入框.MinimumSize = new System.Drawing.Size(1, 15);
            this.修改_账号名字输入框.Name = "修改_账号名字输入框";
            this.修改_账号名字输入框.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.修改_账号名字输入框.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.修改_账号名字输入框.ShowText = false;
            this.修改_账号名字输入框.Size = new System.Drawing.Size(284, 40);
            this.修改_账号名字输入框.Style = Sunny.UI.UIStyle.Red;
            this.修改_账号名字输入框.Symbol = 61447;
            this.修改_账号名字输入框.SymbolSize = 22;
            this.修改_账号名字输入框.TabIndex = 17;
            this.修改_账号名字输入框.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.修改_账号名字输入框.Watermark = "请输入已有账号";
            // 
            // 启动游戏页面
            // 
            this.启动游戏页面.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.启动游戏页面.Controls.Add(this.启动_当前账号标签);
            this.启动游戏页面.Controls.Add(this.启动_当前选择标签);
            this.启动游戏页面.Controls.Add(this.启动_选中区服标签);
            this.启动游戏页面.Controls.Add(this.启动_注销账号标签);
            this.启动游戏页面.Controls.Add(this.启动_选择游戏区服);
            this.启动游戏页面.Controls.Add(this.启动_进入游戏按钮);
            this.启动游戏页面.Location = new System.Drawing.Point(0, 28);
            this.启动游戏页面.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.启动游戏页面.Name = "启动游戏页面";
            this.启动游戏页面.Size = new System.Drawing.Size(441, 460);
            this.启动游戏页面.TabIndex = 3;
            this.启动游戏页面.Text = "启动游戏";
            // 
            // 启动_当前账号标签
            // 
            this.启动_当前账号标签.Cursor = System.Windows.Forms.Cursors.Hand;
            this.启动_当前账号标签.Enabled = false;
            this.启动_当前账号标签.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.启动_当前账号标签.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.启动_当前账号标签.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(203)))), ((int)(((byte)(83)))));
            this.启动_当前账号标签.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.启动_当前账号标签.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.启动_当前账号标签.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.启动_当前账号标签.Location = new System.Drawing.Point(4, 3);
            this.启动_当前账号标签.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.启动_当前账号标签.MinimumSize = new System.Drawing.Size(1, 1);
            this.启动_当前账号标签.Name = "启动_当前账号标签";
            this.启动_当前账号标签.Radius = 15;
            this.启动_当前账号标签.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.启动_当前账号标签.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(203)))), ((int)(((byte)(83)))));
            this.启动_当前账号标签.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.启动_当前账号标签.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.启动_当前账号标签.Size = new System.Drawing.Size(337, 40);
            this.启动_当前账号标签.Style = Sunny.UI.UIStyle.Green;
            this.启动_当前账号标签.Symbol = 57607;
            this.启动_当前账号标签.TabIndex = 9;
            this.启动_当前账号标签.Text = "mistyes";
            this.启动_当前账号标签.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // 启动_当前选择标签
            // 
            this.启动_当前选择标签.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.启动_当前选择标签.Location = new System.Drawing.Point(9, 293);
            this.启动_当前选择标签.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.启动_当前选择标签.Name = "启动_当前选择标签";
            this.启动_当前选择标签.Size = new System.Drawing.Size(157, 27);
            this.启动_当前选择标签.TabIndex = 8;
            this.启动_当前选择标签.Text = "当前选择的服务器:";
            this.启动_当前选择标签.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // 启动_选中区服标签
            // 
            this.启动_选中区服标签.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(155)))), ((int)(((byte)(40)))));
            this.启动_选中区服标签.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.启动_选中区服标签.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.启动_选中区服标签.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.启动_选中区服标签.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.启动_选中区服标签.Location = new System.Drawing.Point(175, 285);
            this.启动_选中区服标签.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.启动_选中区服标签.Name = "启动_选中区服标签";
            this.启动_选中区服标签.Size = new System.Drawing.Size(155, 33);
            this.启动_选中区服标签.Style = Sunny.UI.UIStyle.Custom;
            this.启动_选中区服标签.TabIndex = 7;
            this.启动_选中区服标签.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.启动_选中区服标签.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            // 
            // 启动_注销账号标签
            // 
            this.启动_注销账号标签.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(155)))), ((int)(((byte)(40)))));
            this.启动_注销账号标签.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.启动_注销账号标签.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.启动_注销账号标签.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.启动_注销账号标签.LinkColor = System.Drawing.Color.Red;
            this.启动_注销账号标签.Location = new System.Drawing.Point(288, 45);
            this.启动_注销账号标签.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.启动_注销账号标签.Name = "启动_注销账号标签";
            this.启动_注销账号标签.Size = new System.Drawing.Size(53, 23);
            this.启动_注销账号标签.Style = Sunny.UI.UIStyle.Custom;
            this.启动_注销账号标签.TabIndex = 6;
            this.启动_注销账号标签.TabStop = true;
            this.启动_注销账号标签.Text = "退出";
            this.启动_注销账号标签.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.启动_注销账号标签.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.启动_注销账号标签.Click += new System.EventHandler(this.启动_注销账号标签_Click);
            // 
            // 启动_选择游戏区服
            // 
            this.启动_选择游戏区服.BackColor = System.Drawing.Color.Wheat;
            this.启动_选择游戏区服.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.启动_选择游戏区服.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F);
            this.启动_选择游戏区服.ForeColor = System.Drawing.Color.Blue;
            this.启动_选择游戏区服.FormattingEnabled = true;
            this.启动_选择游戏区服.ItemHeight = 20;
            this.启动_选择游戏区服.Items.AddRange(new object[] {
            "魔龙谷",
            "伤心树"});
            this.启动_选择游戏区服.Location = new System.Drawing.Point(97, 53);
            this.启动_选择游戏区服.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.启动_选择游戏区服.Name = "启动_选择游戏区服";
            this.启动_选择游戏区服.Size = new System.Drawing.Size(159, 227);
            this.启动_选择游戏区服.TabIndex = 4;
            this.启动_选择游戏区服.TabStop = false;
            this.启动_选择游戏区服.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.启动_选择游戏区服_DrawItem);
            this.启动_选择游戏区服.SelectedIndexChanged += new System.EventHandler(this.启动_选择游戏区服_SelectedIndexChanged);
            // 
            // 启动_进入游戏按钮
            // 
            this.启动_进入游戏按钮.Cursor = System.Windows.Forms.Cursors.Hand;
            this.启动_进入游戏按钮.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.启动_进入游戏按钮.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.启动_进入游戏按钮.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(121)))), ((int)(((byte)(78)))));
            this.启动_进入游戏按钮.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(70)))), ((int)(((byte)(28)))));
            this.启动_进入游戏按钮.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(70)))), ((int)(((byte)(28)))));
            this.启动_进入游戏按钮.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.启动_进入游戏按钮.Location = new System.Drawing.Point(4, 321);
            this.启动_进入游戏按钮.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.启动_进入游戏按钮.MinimumSize = new System.Drawing.Size(1, 1);
            this.启动_进入游戏按钮.Name = "启动_进入游戏按钮";
            this.启动_进入游戏按钮.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.启动_进入游戏按钮.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(121)))), ((int)(((byte)(78)))));
            this.启动_进入游戏按钮.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(70)))), ((int)(((byte)(28)))));
            this.启动_进入游戏按钮.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(70)))), ((int)(((byte)(28)))));
            this.启动_进入游戏按钮.Size = new System.Drawing.Size(337, 40);
            this.启动_进入游戏按钮.Style = Sunny.UI.UIStyle.LayuiRed;
            this.启动_进入游戏按钮.TabIndex = 1;
            this.启动_进入游戏按钮.TabStop = false;
            this.启动_进入游戏按钮.Text = "进入游戏";
            this.启动_进入游戏按钮.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.启动_进入游戏按钮.Click += new System.EventHandler(this.启动_进入游戏按钮_Click);
            // 
            // 用户界面计时
            // 
            this.用户界面计时.Interval = 30000;
            this.用户界面计时.Tick += new System.EventHandler(this.用户界面解锁);
            // 
            // 数据处理计时
            // 
            this.数据处理计时.Enabled = true;
            this.数据处理计时.Tick += new System.EventHandler(this.数据接收处理);
            // 
            // 最小化到托盘
            // 
            this.最小化到托盘.ContextMenuStrip = this.托盘右键菜单;
            this.最小化到托盘.Icon = ((System.Drawing.Icon)(resources.GetObject("最小化到托盘.Icon")));
            this.最小化到托盘.Text = "登录器";
            this.最小化到托盘.MouseClick += new System.Windows.Forms.MouseEventHandler(this.托盘_恢复到任务栏);
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
            this.打开ToolStripMenuItem.Click += new System.EventHandler(this.托盘_恢复到任务栏);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.托盘_彻底关闭应用);
            // 
            // 游戏进程监测
            // 
            this.游戏进程监测.Enabled = true;
            this.游戏进程监测.Tick += new System.EventHandler(this.游戏进程检查);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(441, 489);
            this.Controls.Add(this.主选项卡);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mir3D Launcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.托盘_隐藏到托盘区);
            this.主选项卡.ResumeLayout(false);
            this.账号登录页面.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.登录_登录验证显示框)).EndInit();
            this.账号注册页面.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.注册_注册验证显示)).EndInit();
            this.密码修改页面.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.修改_修改验证显示)).EndInit();
            this.启动游戏页面.ResumeLayout(false);
            this.托盘右键菜单.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		// Token: 0x04000008 RID: 8
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000009 RID: 9
		private global::System.Windows.Forms.TabPage 账号登录页面;

		// Token: 0x0400000A RID: 10
		private global::Sunny.UI.UILinkLabel 登录_忘记密码选项;

		// Token: 0x0400000B RID: 11
		private global::Sunny.UI.UISymbolButton 登录_注册账号按钮;

		// Token: 0x0400000C RID: 12
		private global::Sunny.UI.UISymbolButton 登录_登录账号按钮;

		// Token: 0x0400000D RID: 13
		private global::Sunny.UI.UITextBox 登录_账号密码输入框;

		// Token: 0x0400000E RID: 14
		private global::Sunny.UI.UITextBox 登录_账号名字输入框;

		// Token: 0x0400000F RID: 15
		private global::Sunny.UI.UIAvatar 登录_用户图标;

		// Token: 0x04000010 RID: 16
		private global::System.Windows.Forms.TabPage 账号注册页面;

		// Token: 0x04000011 RID: 17
		private global::System.Windows.Forms.TabPage 密码修改页面;

		// Token: 0x04000012 RID: 18
		private global::System.Windows.Forms.TabPage 启动游戏页面;

		// Token: 0x04000013 RID: 19
		private global::Sunny.UI.UISymbolButton 注册_注册账号按钮;

		// Token: 0x04000014 RID: 20
		private global::Sunny.UI.UITextBox 注册_密保答案输入框;

		// Token: 0x04000015 RID: 21
		private global::Sunny.UI.UITextBox 注册_账号密码输入框;

		// Token: 0x04000016 RID: 22
		private global::Sunny.UI.UITextBox 注册_密保问题输入框;

		// Token: 0x04000017 RID: 23
		private global::Sunny.UI.UITextBox 注册_账号名字输入框;

		// Token: 0x04000018 RID: 24
		private global::Sunny.UI.UISymbolButton 修改_修改密码按钮;

		// Token: 0x04000019 RID: 25
		private global::Sunny.UI.UITextBox 修改_密保答案输入框;

		// Token: 0x0400001A RID: 26
		private global::Sunny.UI.UITextBox 修改_账号密码输入框;

		// Token: 0x0400001B RID: 27
		private global::Sunny.UI.UITextBox 修改_密保问题输入框;

		// Token: 0x0400001C RID: 28
		private global::Sunny.UI.UITextBox 修改_账号名字输入框;

		// Token: 0x0400001D RID: 29
		private global::Sunny.UI.UIButton 启动_进入游戏按钮;

		// Token: 0x0400001E RID: 30
		private global::Sunny.UI.UILabel 注册_错误提示标签;

		// Token: 0x0400001F RID: 31
		private global::Sunny.UI.UILabel 修改_错误提示标签;

		// Token: 0x04000020 RID: 32
		private global::System.Windows.Forms.ListBox 启动_选择游戏区服;

		// Token: 0x04000021 RID: 33
		private global::Sunny.UI.UILinkLabel 启动_选中区服标签;

		// Token: 0x04000022 RID: 34
		private global::Sunny.UI.UILinkLabel 启动_注销账号标签;

		// Token: 0x04000023 RID: 35
		private global::System.Windows.Forms.PictureBox 登录_登录验证显示框;

		// Token: 0x04000024 RID: 36
		private global::Sunny.UI.UITextBox 登录_登录验证输入框;

		// Token: 0x04000025 RID: 37
		private global::Sunny.UI.UISymbolButton 注册_返回登录按钮;

		// Token: 0x04000026 RID: 38
		private global::Sunny.UI.UISymbolButton 修改_返回登录按钮;

		// Token: 0x04000027 RID: 39
		private global::System.Windows.Forms.PictureBox 注册_注册验证显示;

		// Token: 0x04000028 RID: 40
		private global::Sunny.UI.UITextBox 注册_注册验证输入框;

		// Token: 0x04000029 RID: 41
		private global::System.Windows.Forms.PictureBox 修改_修改验证显示;

		// Token: 0x0400002A RID: 42
		private global::Sunny.UI.UITextBox 修改_修改验证输入框;

		// Token: 0x0400002B RID: 43
		private global::System.Windows.Forms.Timer 用户界面计时;

		// Token: 0x0400002C RID: 44
		public global::Sunny.UI.UITabControl 主选项卡;

		// Token: 0x0400002D RID: 45
		public global::Sunny.UI.UILabel 登录_错误提示标签;

		// Token: 0x0400002E RID: 46
		private global::System.Windows.Forms.Timer 数据处理计时;

		// Token: 0x0400002F RID: 47
		private global::Sunny.UI.UILabel 启动_当前选择标签;

		// Token: 0x04000030 RID: 48
		private global::Sunny.UI.UISymbolButton 启动_当前账号标签;

		// Token: 0x04000031 RID: 49
		private global::System.Windows.Forms.NotifyIcon 最小化到托盘;

		// Token: 0x04000032 RID: 50
		private global::System.Windows.Forms.ContextMenuStrip 托盘右键菜单;

		// Token: 0x04000033 RID: 51
		private global::System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;

		// Token: 0x04000034 RID: 52
		private global::System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;

		// Token: 0x04000035 RID: 53
		private global::System.Windows.Forms.Timer 游戏进程监测;
	}
}
