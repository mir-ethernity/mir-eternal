using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Sunny.UI;
using Launcher.Properties;
using 游戏登陆器;

namespace Launcher
{
	// Token: 0x02000003 RID: 3
	public partial class MainForm : Form
	{
		// Token: 0x06000002 RID: 2 RVA: 0x00002178 File Offset: 0x00000378
		public MainForm()
		{
			this.InitializeComponent();
			MainForm.用户界面 = this;
			Network.开始通信();
			this.更新验证图形();
			MainForm.游戏区服 = new Dictionary<string, IPEndPoint>();
			this.启动_选中区服标签.Text = Settings.Default.保存区服;
			this.登录_账号名字输入框.Text = Settings.Default.保存账号;
			if (!File.Exists(".\\Binaries\\Win32\\MMOGame-Win32-Shipping.exe"))
			{
				MessageBox.Show("GamePath not found, Please confirm the login location.");
				Environment.Exit(0);
			}
			if (!File.Exists("./ServerCfg.txt"))
			{
				MessageBox.Show("Please configure the account server IP and port in the ./ServerCfg.txt file");
				Environment.Exit(0);
			}
			string[] array = File.ReadAllText("./ServerCfg.txt").Trim(new char[]
			{
				'\r',
				'\n',
				'\t',
				' '
			}).Split(new char[]
			{
				':'
			});
			if (array.Length != 2)
			{
				MessageBox.Show("Account server configuration error");
				Environment.Exit(0);
			}
			Network.ServerAddress = new IPEndPoint(IPAddress.Parse(array[0]), Convert.ToInt32(array[1]));
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002272 File Offset: 0x00000472
		public void 用户界面锁定()
		{
			this.主选项卡.Enabled = false;
			this.登录_错误提示标签.Visible = false;
			this.注册_错误提示标签.Visible = false;
			this.修改_错误提示标签.Visible = false;
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000022A4 File Offset: 0x000004A4
		public void 更新验证图形()
		{
			this.登录_登录验证输入框.Text = (this.注册_注册验证输入框.Text = (this.修改_修改验证输入框.Text = ""));
			this.登录_登录验证显示框.Image = (this.注册_注册验证显示.Image = (this.修改_修改验证显示.Image = Captcha.生成验证码()));
		}

		// Token: 0x06000005 RID: 5 RVA: 0x0000230C File Offset: 0x0000050C
		public void 数据接收处理(object sender, EventArgs e)
		{
			if (Network.通信实例 == null || Network.接收队列.IsEmpty)
			{
				return;
			}
            if (Network.接收队列.TryDequeue(out byte[] array))
            {
                string[] array2 = Encoding.UTF8.GetString(array, 0, array.Length).Split(new char[]
                {
                    ' '
                }, StringSplitOptions.RemoveEmptyEntries);
                if (array2.Length <= 2 || !int.TryParse(array2[0], out int num) || num != MainForm.封包编号)
                {
                    return;
                }
                string text = array2[1];
                uint num2 = PrivateImplementationDetails.ComputeStringHash(text);
                if (num2 <= 856466825U)
                {
                    if (num2 <= 822911587U)
                    {
                        if (num2 != 806133968U)
                        {
                            if (num2 != 822911587U)
                            {
                                return;
                            }
                            if (!(text == "4"))
                            {
                                return;
                            }
                            if (array2.Length == 4)
                            {
                                this.用户界面解锁(null, null);
                                MessageBox.Show("密码修改成功");
                                return;
                            }
                        }
                        else
                        {
                            if (!(text == "5"))
                            {
                                return;
                            }
                            if (array2.Length == 3)
                            {
                                this.用户界面解锁(null, null);
                                this.修改_错误提示标签.Text = array2[2];
                                this.修改_错误提示标签.Visible = true;
                                return;
                            }
                        }
                    }
                    else if (num2 != 839689206U)
                    {
                        if (num2 != 856466825U)
                        {
                            return;
                        }
                        if (!(text == "6"))
                        {
                            return;
                        }
                        if (array2.Length == 5)
                        {
                            if (!File.Exists(".\\Binaries\\Win32\\MMOGame-Win32-Shipping.exe"))
                            {
                                MessageBox.Show("未找到游戏路径, 请确认登录器位置");
                                this.用户界面计时.Enabled = false;
                                this.用户界面解锁(null, null);
                                return;
                            }
                            if (MainForm.游戏区服.TryGetValue(this.启动_选中区服标签.Text, out IPEndPoint ipendPoint))
                            {
                                string arguments = string.Concat(new string[]
                                {
                                    "-wegame=",
                                    string.Format("1,1,{0},{1},", ipendPoint.Address, ipendPoint.Port),
                                    string.Format("1,1,{0},{1},", ipendPoint.Address, ipendPoint.Port),
                                    this.启动_选中区服标签.Text,
                                    "  ",
                                    string.Format("/ip:1,1,{0} ", ipendPoint.Address),
                                    string.Format("/port:{0} ", ipendPoint.Port),
                                    "/ticket:",
                                    array2[4],
                                    " /AreaName:",
                                    this.启动_选中区服标签.Text
                                });
                                Settings.Default.保存区服 = this.启动_选中区服标签.Text;
                                Settings.Default.Save();
                                MainForm.游戏进程 = new Process();
                                MainForm.游戏进程.StartInfo.FileName = ".\\Binaries\\Win32\\MMOGame-Win32-Shipping.exe";
                                MainForm.游戏进程.StartInfo.Arguments = arguments;
                                MainForm.游戏进程.Start();
                                this.游戏进程监测.Enabled = true;
                                this.托盘_隐藏到托盘区(null, null);
                                this.用户界面锁定();
                                this.用户界面计时.Enabled = false;
                                this.最小化到托盘.ShowBalloonTip(1000, "", "正在启动游戏, 请稍候...", ToolTipIcon.Info);
                                return;
                            }
                        }
                    }
                    else
                    {
                        if (!(text == "7"))
                        {
                            return;
                        }
                        if (array2.Length == 3)
                        {
                            this.用户界面解锁(null, null);
                            MessageBox.Show("启动游戏失败! " + array2[2]);
                        }
                    }
                }
                else if (num2 <= 890022063U)
                {
                    if (num2 != 873244444U)
                    {
                        if (num2 != 890022063U)
                        {
                            return;
                        }
                        if (!(text == "0"))
                        {
                            return;
                        }
                        if (array2.Length == 5)
                        {
                            this.用户界面解锁(null, null);
                            MainForm.登录账号 = (this.启动_当前账号标签.Text = array2[2]);
                            MainForm.登录密码 = array2[3];
                            this.启动_选择游戏区服.Items.Clear();
                            string[] array3 = array2[4].Split(new char[]
                            {
                                '\r',
                                '\n'
                            }, StringSplitOptions.RemoveEmptyEntries);
                            for (int i = 0; i < array3.Length; i++)
                            {
                                string[] array4 = array3[i].Split(new char[]
                                {
                                    ',',
                                    '/'
                                }, StringSplitOptions.RemoveEmptyEntries);
                                if (array4.Length != 3)
                                {
                                    MessageBox.Show("服务器数据解析失败!");
                                    Environment.Exit(0);
                                }
                                MainForm.游戏区服[array4[2]] = new IPEndPoint(IPAddress.Parse(array4[0]), Convert.ToInt32(array4[1]));
                                this.启动_选择游戏区服.Items.Add(array4[2]);
                            }
                            this.主选项卡.SelectedIndex = 3;
                            Settings.Default.保存账号 = array2[2];
                            Settings.Default.Save();
                            return;
                        }
                    }
                    else
                    {
                        if (!(text == "1"))
                        {
                            return;
                        }
                        if (array2.Length == 3)
                        {
                            this.用户界面解锁(null, null);
                            this.登录_错误提示标签.Text = array2[2];
                            this.登录_错误提示标签.Visible = true;
                            return;
                        }
                    }
                }
                else if (num2 != 906799682U)
                {
                    if (num2 != 923577301U)
                    {
                        return;
                    }
                    if (!(text == "2"))
                    {
                        return;
                    }
                    if (array2.Length == 4)
                    {
                        this.用户界面解锁(null, null);
                        MessageBox.Show("账号注册成功");
                        return;
                    }
                }
                else
                {
                    if (!(text == "3"))
                    {
                        return;
                    }
                    if (array2.Length == 3)
                    {
                        this.用户界面解锁(null, null);
                        this.注册_错误提示标签.Text = array2[2];
                        this.注册_错误提示标签.Visible = true;
                        return;
                    }
                }
            }
        }

		// Token: 0x06000006 RID: 6 RVA: 0x0000280A File Offset: 0x00000A0A
		public void 用户界面解锁(object sender, EventArgs e)
		{
			this.主选项卡.Enabled = true;
			this.用户界面计时.Enabled = false;
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002824 File Offset: 0x00000A24
		public void 游戏进程检查(object sender, EventArgs e)
		{
			if (MainForm.游戏进程 == null)
			{
				return;
			}
			if (MainForm.游戏进程.HasExited)
			{
				this.用户界面解锁(null, null);
				this.托盘_恢复到任务栏(null, null);
				this.游戏进程监测.Enabled = false;
			}
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002858 File Offset: 0x00000A58
		private void 登录_登录账号按钮_Click(object sender, EventArgs e)
		{
			if (this.登录_账号名字输入框.Text.Length <= 0)
			{
				this.登录_错误提示标签.Text = "用户名不能为空";
				this.登录_错误提示标签.Visible = true;
				return;
			}
			if (this.登录_账号名字输入框.Text.IndexOf(' ') >= 0)
			{
				this.登录_错误提示标签.Text = "用户名不能包含空格";
				this.登录_错误提示标签.Visible = true;
				return;
			}
			if (this.登录_账号密码输入框.Text.Length <= 0)
			{
				this.登录_错误提示标签.Text = "密码不能为空";
				this.登录_错误提示标签.Visible = true;
				return;
			}
			if (this.登录_账号名字输入框.Text.IndexOf(' ') >= 0)
			{
				this.登录_错误提示标签.Text = "密码不能包含空格";
				this.登录_错误提示标签.Visible = true;
				return;
			}
			if (this.登录_登录验证输入框.Text.Length <= 0)
			{
				this.登录_错误提示标签.Text = "请输入验证码";
				this.登录_错误提示标签.Visible = true;
				return;
			}
			if (this.登录_登录验证输入框.Text.Trim().ToUpper() != Captcha.验证码.ToUpper())
			{
				this.登录_错误提示标签.Text = "验证码不正确";
				this.登录_错误提示标签.Visible = true;
				this.更新验证图形();
				return;
			}
			if (Network.发送数据(Encoding.UTF8.GetBytes(string.Format("{0} 0 ", ++MainForm.封包编号) + this.登录_账号名字输入框.Text + " " + this.登录_账号密码输入框.Text)))
			{
				this.用户界面锁定();
			}
			this.登录_账号密码输入框.Text = "";
			this.更新验证图形();
			this.用户界面计时.Enabled = true;
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002A17 File Offset: 0x00000C17
		private void 登录_忘记密码选项_Click(object sender, EventArgs e)
		{
			this.主选项卡.SelectedIndex = 2;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002A25 File Offset: 0x00000C25
		private void 登录_注册账号按钮_Click(object sender, EventArgs e)
		{
			this.主选项卡.SelectedIndex = 1;
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002A34 File Offset: 0x00000C34
		private void 登录_登录验证显示_Click(object sender, EventArgs e)
		{
			this.登录_登录验证显示框.Image = (this.注册_注册验证显示.Image = (this.修改_修改验证显示.Image = Captcha.生成验证码()));
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002A70 File Offset: 0x00000C70
		public void 登录_账号登录成功(string 账号, string 密码)
		{
			this.用户界面计时.Enabled = false;
			this.登录_错误提示标签.Visible = false;
			this.登录_登录账号按钮.Enabled = false;
			MainForm.登录账号 = 账号;
			MainForm.登录密码 = 密码;
			this.启动_当前账号标签.Text = 账号;
			this.主选项卡.SelectedIndex = 3;
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002AC5 File Offset: 0x00000CC5
		public void 登录_账号登录失败(string 错误)
		{
			this.主选项卡.SelectedIndex = 0;
			this.用户界面计时.Enabled = false;
			this.登录_错误提示标签.Visible = true;
			this.登录_错误提示标签.Text = 错误;
			this.登录_登录账号按钮.Enabled = true;
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002B03 File Offset: 0x00000D03
		private void 托盘_隐藏到托盘区(object sender, FormClosingEventArgs e)
		{
			this.最小化到托盘.Visible = true;
			base.Hide();
			if (e != null)
			{
				e.Cancel = true;
			}
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002B21 File Offset: 0x00000D21
		private void 托盘_恢复到任务栏(object sender, MouseEventArgs e)
		{
			if (e == null || e.Button == MouseButtons.Left)
			{
				base.Visible = true;
				this.最小化到托盘.Visible = false;
			}
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002B46 File Offset: 0x00000D46
		private void 托盘_恢复到任务栏(object sender, EventArgs e)
		{
			base.Visible = true;
			this.最小化到托盘.Visible = false;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002B5B File Offset: 0x00000D5B
		private void 托盘_彻底关闭应用(object sender, EventArgs e)
		{
			this.最小化到托盘.Visible = false;
			Environment.Exit(Environment.ExitCode);
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002B74 File Offset: 0x00000D74
		private void 注册_注册账号按钮_Click(object sender, EventArgs e)
		{
			if (this.注册_账号名字输入框.Text.Length <= 0)
			{
				this.注册_错误提示标签.Text = "用户名不能为空";
				this.注册_错误提示标签.Visible = true;
				return;
			}
			if (this.注册_账号名字输入框.Text.IndexOf(' ') >= 0)
			{
				this.注册_错误提示标签.Text = "用户名不能包含空格";
				this.注册_错误提示标签.Visible = true;
				return;
			}
			if (this.注册_账号名字输入框.Text.Length <= 5 || this.注册_账号名字输入框.Text.Length > 12)
			{
				this.注册_错误提示标签.Text = "用户名长度只能为6-12位";
				this.注册_错误提示标签.Visible = true;
				return;
			}
			if (!Regex.IsMatch(this.注册_账号名字输入框.Text, "^[a-zA-Z]+.*$"))
			{
				this.注册_错误提示标签.Text = "用户名只能以字母开头";
				this.注册_错误提示标签.Visible = true;
				return;
			}
			if (!Regex.IsMatch(this.注册_账号名字输入框.Text, "^[a-zA-Z_][A-Za-z0-9_]*$"))
			{
				this.注册_错误提示标签.Text = "用户名只能包含字母数字和下划线";
				this.注册_错误提示标签.Visible = true;
				return;
			}
			if (this.注册_账号密码输入框.Text.Length <= 0)
			{
				this.注册_错误提示标签.Text = "密码不能为空";
				this.注册_错误提示标签.Visible = true;
				return;
			}
			if (this.注册_账号密码输入框.Text.IndexOf(' ') >= 0)
			{
				this.注册_错误提示标签.Text = "密码不能包含空格";
				this.注册_错误提示标签.Visible = true;
				return;
			}
			if (this.注册_账号密码输入框.Text.Length <= 5 || this.注册_账号密码输入框.Text.Length > 18)
			{
				this.注册_错误提示标签.Text = "密码长度只能为6-18位";
				this.注册_错误提示标签.Visible = true;
				return;
			}
			if (this.注册_密保问题输入框.Text.Length <= 0)
			{
				this.注册_错误提示标签.Text = "密保问题不能为空";
				this.注册_错误提示标签.Visible = true;
				return;
			}
			if (this.注册_密保问题输入框.Text.IndexOf(' ') >= 0)
			{
				this.注册_错误提示标签.Text = "密保问题不能包含空格";
				this.注册_错误提示标签.Visible = true;
				return;
			}
			if (this.注册_密保问题输入框.Text.Length <= 1 || this.注册_密保问题输入框.Text.Length > 18)
			{
				this.注册_错误提示标签.Text = "密保问题只能为2-18位";
				this.注册_错误提示标签.Visible = true;
				return;
			}
			if (this.注册_密保答案输入框.Text.Length <= 0)
			{
				this.注册_错误提示标签.Text = "密保答案不能为空";
				this.注册_错误提示标签.Visible = true;
				return;
			}
			if (this.注册_密保答案输入框.Text.IndexOf(' ') >= 0)
			{
				this.注册_错误提示标签.Text = "密保答案不能包含空格";
				this.注册_错误提示标签.Visible = true;
				return;
			}
			if (this.注册_密保答案输入框.Text.Length <= 1 || this.注册_密保答案输入框.Text.Length > 18)
			{
				this.注册_错误提示标签.Text = "密保问题只能为2-18位";
				this.注册_错误提示标签.Visible = true;
				return;
			}
			if (this.注册_注册验证输入框.Text.Length <= 0)
			{
				this.注册_错误提示标签.Text = "请输入验证码";
				this.注册_错误提示标签.Visible = true;
				return;
			}
			if (this.注册_注册验证输入框.Text.ToUpper() != Captcha.验证码.ToUpper())
			{
				this.注册_错误提示标签.Text = "验证码错误";
				this.注册_错误提示标签.Visible = true;
				this.更新验证图形();
				return;
			}
			if (Network.发送数据(Encoding.UTF8.GetBytes(string.Concat(new string[]
			{
				string.Format("{0} 1 ", ++MainForm.封包编号),
				this.注册_账号名字输入框.Text,
				" ",
				this.注册_账号密码输入框.Text,
				" ",
				this.注册_密保问题输入框.Text,
				" ",
				this.注册_密保答案输入框.Text
			}))))
			{
				this.用户界面锁定();
			}
			this.注册_账号密码输入框.Text = (this.注册_密保答案输入框.Text = "");
			this.更新验证图形();
			this.用户界面计时.Enabled = true;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002FB6 File Offset: 0x000011B6
		private void 注册_返回登录按钮_Click(object sender, EventArgs e)
		{
			this.主选项卡.SelectedIndex = 0;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002FC4 File Offset: 0x000011C4
		private void 修改_修改密码按钮_Click(object sender, EventArgs e)
		{
			if (this.修改_账号名字输入框.Text.Length <= 0)
			{
				this.修改_错误提示标签.Text = "用户名不能为空";
				this.修改_错误提示标签.Visible = true;
				return;
			}
			if (this.修改_账号名字输入框.Text.IndexOf(' ') >= 0)
			{
				this.修改_错误提示标签.Text = "用户名不能包含空格";
				this.修改_错误提示标签.Visible = true;
				return;
			}
			if (this.修改_账号密码输入框.Text.Length <= 0)
			{
				this.修改_错误提示标签.Text = "密码不能为空";
				this.修改_错误提示标签.Visible = true;
				return;
			}
			if (this.修改_账号密码输入框.Text.IndexOf(' ') >= 0)
			{
				this.修改_错误提示标签.Text = "密码不能包含空格";
				this.修改_错误提示标签.Visible = true;
				return;
			}
			if (this.修改_账号密码输入框.Text.Length <= 5 || this.修改_账号密码输入框.Text.Length > 18)
			{
				this.修改_错误提示标签.Text = "密码长度只能为6-18位";
				this.修改_错误提示标签.Visible = true;
				return;
			}
			if (this.修改_密保问题输入框.Text.Length <= 0)
			{
				this.修改_错误提示标签.Text = "密保问题不能为空";
				this.修改_错误提示标签.Visible = true;
				return;
			}
			if (this.修改_密保问题输入框.Text.IndexOf(' ') >= 0)
			{
				this.修改_错误提示标签.Text = "密保问题不能包含空格";
				this.修改_错误提示标签.Visible = true;
				return;
			}
			if (this.修改_密保答案输入框.Text.Length <= 0)
			{
				this.修改_错误提示标签.Text = "密保答案不能为空";
				this.修改_错误提示标签.Visible = true;
				return;
			}
			if (this.修改_密保答案输入框.Text.IndexOf(' ') >= 0)
			{
				this.修改_错误提示标签.Text = "密保答案不能包含空格";
				this.修改_错误提示标签.Visible = true;
				return;
			}
			if (this.修改_修改验证输入框.Text.Length <= 0)
			{
				this.修改_错误提示标签.Text = "请输入验证码";
				this.修改_错误提示标签.Visible = true;
				return;
			}
			if (this.修改_修改验证输入框.Text.ToUpper() != Captcha.验证码.ToUpper())
			{
				this.修改_错误提示标签.Text = "验证码错误";
				this.修改_错误提示标签.Visible = true;
				this.更新验证图形();
				return;
			}
			if (Network.发送数据(Encoding.UTF8.GetBytes(string.Concat(new string[]
			{
				string.Format("{0} 2 ", ++MainForm.封包编号),
				this.修改_账号名字输入框.Text,
				" ",
				this.修改_账号密码输入框.Text,
				" ",
				this.修改_密保问题输入框.Text,
				" ",
				this.修改_密保答案输入框.Text
			}))))
			{
				this.用户界面锁定();
			}
			this.修改_账号密码输入框.Text = (this.修改_密保答案输入框.Text = "");
			this.更新验证图形();
			this.用户界面计时.Enabled = true;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000032D2 File Offset: 0x000014D2
		private void 修改_返回登录按钮_Click(object sender, EventArgs e)
		{
			this.主选项卡.SelectedIndex = 0;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000032E0 File Offset: 0x000014E0
		private void 启动_进入游戏按钮_Click(object sender, EventArgs e)
		{
			if (MainForm.登录账号 == null || MainForm.登录账号 == "")
			{
				this.主选项卡.SelectedIndex = 0;
				return;
			}
			if (this.启动_选中区服标签.Text == null || this.启动_选中区服标签.Text == "")
			{
				MessageBox.Show("请选择服务器");
				return;
			}
			if (!MainForm.游戏区服.ContainsKey(this.启动_选中区服标签.Text))
			{
				MessageBox.Show("服务器选择错误");
				return;
			}
			if (Network.发送数据(Encoding.UTF8.GetBytes(string.Concat(new string[]
			{
				string.Format("{0} 3 ", ++MainForm.封包编号),
				MainForm.登录账号,
				" ",
				MainForm.登录密码,
				" ",
				this.启动_选中区服标签.Text,
				" v1.0"
			}))))
			{
				this.用户界面锁定();
				this.用户界面计时.Enabled = true;
			}
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000033E8 File Offset: 0x000015E8
		private void 启动_注销账号标签_Click(object sender, EventArgs e)
		{
			MainForm.登录账号 = null;
			MainForm.登录密码 = null;
			this.主选项卡.SelectedIndex = 0;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00003404 File Offset: 0x00001604
		private void 启动_选择游戏区服_DrawItem(object sender, DrawItemEventArgs e)
		{
			e.DrawBackground();
			e.DrawFocusRectangle();
            StringFormat stringFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            e.Graphics.DrawString(this.启动_选择游戏区服.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds, stringFormat);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00003474 File Offset: 0x00001674
		private void 启动_选择游戏区服_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.启动_选择游戏区服.SelectedIndex < 0)
			{
				this.启动_选中区服标签.Text = "";
				return;
			}
			this.启动_选中区服标签.Text = this.启动_选择游戏区服.Items[this.启动_选择游戏区服.SelectedIndex].ToString();
		}

		// Token: 0x04000002 RID: 2
		public static int 封包编号;

		// Token: 0x04000003 RID: 3
		public static string 登录账号;

		// Token: 0x04000004 RID: 4
		public static string 登录密码;

		// Token: 0x04000005 RID: 5
		public static Process 游戏进程;

		// Token: 0x04000006 RID: 6
		public static MainForm 用户界面;

		// Token: 0x04000007 RID: 7
		public static Dictionary<string, IPEndPoint> 游戏区服;
	}
}
