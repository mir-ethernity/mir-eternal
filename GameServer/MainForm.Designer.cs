namespace GameServer
{

  public partial class MainForm : global::System.Windows.Forms.Form
  {

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
      {
        this.components.Dispose();
      }
      base.Dispose(disposing);
    }


    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle37 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle38 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle39 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle40 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle41 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle42 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle43 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle44 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle45 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle46 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle47 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle48 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle49 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle50 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle51 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle52 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle53 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle54 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle55 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle56 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle57 = new System.Windows.Forms.DataGridViewCellStyle();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.主选项卡 = new System.Windows.Forms.TabControl();
      this.tabMain = new System.Windows.Forms.TabPage();
      this.清空命令日志 = new System.Windows.Forms.Button();
      this.对象统计 = new System.Windows.Forms.Label();
      this.MainTabs = new System.Windows.Forms.TabControl();
      this.tabSystem = new System.Windows.Forms.TabPage();
      this.系统日志 = new System.Windows.Forms.RichTextBox();
      this.tabChat = new System.Windows.Forms.TabPage();
      this.聊天日志 = new System.Windows.Forms.RichTextBox();
      this.tabCommands = new System.Windows.Forms.TabPage();
      this.命令日志 = new System.Windows.Forms.RichTextBox();
      this.tabPackets = new System.Windows.Forms.TabPage();
      this.rtbPacketsLogs = new System.Windows.Forms.RichTextBox();
      this.清空聊天日志 = new System.Windows.Forms.Button();
      this.保存聊天日志 = new System.Windows.Forms.Button();
      this.已经登录统计 = new System.Windows.Forms.Label();
      this.已经上线统计 = new System.Windows.Forms.Label();
      this.连接总数统计 = new System.Windows.Forms.Label();
      this.发送统计 = new System.Windows.Forms.Label();
      this.接收统计 = new System.Windows.Forms.Label();
      this.清空系统日志 = new System.Windows.Forms.Button();
      this.保存系统日志 = new System.Windows.Forms.Button();
      this.帧数统计 = new System.Windows.Forms.Label();
      this.tabCharacters = new System.Windows.Forms.TabPage();
      this.角色详情选项卡 = new System.Windows.Forms.TabControl();
      this.CharacterData_技能 = new System.Windows.Forms.TabPage();
      this.技能浏览表 = new System.Windows.Forms.DataGridView();
      this.CharacterData_装备 = new System.Windows.Forms.TabPage();
      this.装备浏览表 = new System.Windows.Forms.DataGridView();
      this.CharacterData_背包 = new System.Windows.Forms.TabPage();
      this.背包浏览表 = new System.Windows.Forms.DataGridView();
      this.CharacterData_仓库 = new System.Windows.Forms.TabPage();
      this.仓库浏览表 = new System.Windows.Forms.DataGridView();
      this.dgvCharacters = new System.Windows.Forms.DataGridView();
      this.角色右键菜单 = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.右键菜单_复制CharName = new System.Windows.Forms.ToolStripMenuItem();
      this.右键菜单_复制Account = new System.Windows.Forms.ToolStripMenuItem();
      this.右键菜单_复制网络地址 = new System.Windows.Forms.ToolStripMenuItem();
      this.右键菜单_复制物理地址 = new System.Windows.Forms.ToolStripMenuItem();
      this.tabMaps = new System.Windows.Forms.TabPage();
      this.dgvMaps = new System.Windows.Forms.DataGridView();
      this.tabMonsters = new System.Windows.Forms.TabPage();
      this.掉落浏览表 = new System.Windows.Forms.DataGridView();
      this.怪物浏览表 = new System.Windows.Forms.DataGridView();
      this.tabBans = new System.Windows.Forms.TabPage();
      this.封禁浏览表 = new System.Windows.Forms.DataGridView();
      this.tabAnnouncements = new System.Windows.Forms.TabPage();
      this.开始公告按钮 = new System.Windows.Forms.Button();
      this.停止公告按钮 = new System.Windows.Forms.Button();
      this.删除公告按钮 = new System.Windows.Forms.Button();
      this.添加公告按钮 = new System.Windows.Forms.Button();
      this.公告浏览表 = new System.Windows.Forms.DataGridView();
      this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Interval = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.RemainingTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Content = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.tabConfig = new System.Windows.Forms.TabPage();
      this.S_软件授权分组 = new System.Windows.Forms.GroupBox();
      this.S_软件注册代码 = new System.Windows.Forms.TextBox();
      this.S_GameData分组 = new System.Windows.Forms.GroupBox();
      this.label1 = new System.Windows.Forms.Label();
      this.S_注意事项标签8 = new System.Windows.Forms.Label();
      this.S_注意事项标签7 = new System.Windows.Forms.Label();
      this.S_注意事项标签6 = new System.Windows.Forms.Label();
      this.S_注意事项标签5 = new System.Windows.Forms.Label();
      this.S_注意事项标签4 = new System.Windows.Forms.Label();
      this.S_注意事项标签3 = new System.Windows.Forms.Label();
      this.S_注意事项标签2 = new System.Windows.Forms.Label();
      this.S_注意事项标签1 = new System.Windows.Forms.Label();
      this.S_重载客户数据 = new System.Windows.Forms.Button();
      this.S_重载SystemData = new System.Windows.Forms.Button();
      this.S_浏览合并目录 = new System.Windows.Forms.Button();
      this.S_浏览备份目录 = new System.Windows.Forms.Button();
      this.S_浏览数据目录 = new System.Windows.Forms.Button();
      this.S_合并客户数据 = new System.Windows.Forms.Button();
      this.S_合并数据目录 = new System.Windows.Forms.TextBox();
      this.S_合并目录标签 = new System.Windows.Forms.Label();
      this.S_数据备份目录 = new System.Windows.Forms.TextBox();
      this.S_GameData目录 = new System.Windows.Forms.TextBox();
      this.S_备份目录标签 = new System.Windows.Forms.Label();
      this.S_数据目录标签 = new System.Windows.Forms.Label();
      this.S_游戏设置分组 = new System.Windows.Forms.GroupBox();
      this.L_NoobLevel = new System.Windows.Forms.Label();
      this.S_NoobLevel = new System.Windows.Forms.NumericUpDown();
      this.S_物品归属标签 = new System.Windows.Forms.Label();
      this.S_ItemOwnershipTime = new System.Windows.Forms.NumericUpDown();
      this.S_收益衰减标签 = new System.Windows.Forms.Label();
      this.S_物品清理标签 = new System.Windows.Forms.Label();
      this.S_ItemCleaningTime = new System.Windows.Forms.NumericUpDown();
      this.S_诱惑时长标签 = new System.Windows.Forms.Label();
      this.S_TemptationTime = new System.Windows.Forms.NumericUpDown();
      this.S_LessExpGradeRate = new System.Windows.Forms.NumericUpDown();
      this.S_收益等级标签 = new System.Windows.Forms.Label();
      this.S_LessExpGrade = new System.Windows.Forms.NumericUpDown();
      this.S_经验倍率标签 = new System.Windows.Forms.Label();
      this.S_ExpRate = new System.Windows.Forms.NumericUpDown();
      this.S_特修折扣标签 = new System.Windows.Forms.Label();
      this.S_EquipRepairDto = new System.Windows.Forms.NumericUpDown();
      this.S_怪物爆率标签 = new System.Windows.Forms.Label();
      this.S_ExtraDropRate = new System.Windows.Forms.NumericUpDown();
      this.S_OpenLevelCommand标签 = new System.Windows.Forms.Label();
      this.S_MaxLevel = new System.Windows.Forms.NumericUpDown();
      this.S_网络设置分组 = new System.Windows.Forms.GroupBox();
      this.S_掉线判定标签 = new System.Windows.Forms.Label();
      this.S_DisconnectTime = new System.Windows.Forms.NumericUpDown();
      this.S_限定封包标签 = new System.Windows.Forms.Label();
      this.S_PacketLimit = new System.Windows.Forms.NumericUpDown();
      this.L_AbnormalBlockTime = new System.Windows.Forms.Label();
      this.S_AbnormalBlockTime = new System.Windows.Forms.NumericUpDown();
      this.S_接收端口标签 = new System.Windows.Forms.Label();
      this.S_TSPort = new System.Windows.Forms.NumericUpDown();
      this.S_监听端口标签 = new System.Windows.Forms.Label();
      this.S_GSPort = new System.Windows.Forms.NumericUpDown();
      this.界面定时更新 = new System.Windows.Forms.Timer(this.components);
      this.下方控件页 = new System.Windows.Forms.Panel();
      this.保存按钮 = new System.Windows.Forms.Button();
      this.GMCommand文本 = new System.Windows.Forms.TextBox();
      this.GMCommand标签 = new System.Windows.Forms.Label();
      this.启动按钮 = new System.Windows.Forms.Button();
      this.停止按钮 = new System.Windows.Forms.Button();
      this.保存数据提醒 = new System.Windows.Forms.Timer(this.components);
      this.定时发送公告 = new System.Windows.Forms.Timer(this.components);
      this.重载数据 = new System.Windows.Forms.Button();
      this.主选项卡.SuspendLayout();
      this.tabMain.SuspendLayout();
      this.MainTabs.SuspendLayout();
      this.tabSystem.SuspendLayout();
      this.tabChat.SuspendLayout();
      this.tabCommands.SuspendLayout();
      this.tabPackets.SuspendLayout();
      this.tabCharacters.SuspendLayout();
      this.角色详情选项卡.SuspendLayout();
      this.CharacterData_技能.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.技能浏览表)).BeginInit();
      this.CharacterData_装备.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.装备浏览表)).BeginInit();
      this.CharacterData_背包.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.背包浏览表)).BeginInit();
      this.CharacterData_仓库.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.仓库浏览表)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dgvCharacters)).BeginInit();
      this.角色右键菜单.SuspendLayout();
      this.tabMaps.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvMaps)).BeginInit();
      this.tabMonsters.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.掉落浏览表)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.怪物浏览表)).BeginInit();
      this.tabBans.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.封禁浏览表)).BeginInit();
      this.tabAnnouncements.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.公告浏览表)).BeginInit();
      this.tabConfig.SuspendLayout();
      this.S_软件授权分组.SuspendLayout();
      this.S_GameData分组.SuspendLayout();
      this.S_游戏设置分组.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.S_NoobLevel)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.S_ItemOwnershipTime)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.S_ItemCleaningTime)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.S_TemptationTime)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.S_LessExpGradeRate)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.S_LessExpGrade)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.S_ExpRate)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.S_EquipRepairDto)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.S_ExtraDropRate)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.S_MaxLevel)).BeginInit();
      this.S_网络设置分组.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.S_DisconnectTime)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.S_PacketLimit)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.S_AbnormalBlockTime)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.S_TSPort)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.S_GSPort)).BeginInit();
      this.下方控件页.SuspendLayout();
      this.SuspendLayout();
      // 
      // 主选项卡
      // 
      this.主选项卡.AllowDrop = true;
      this.主选项卡.Controls.Add(this.tabMain);
      this.主选项卡.Controls.Add(this.tabCharacters);
      this.主选项卡.Controls.Add(this.tabMaps);
      this.主选项卡.Controls.Add(this.tabMonsters);
      this.主选项卡.Controls.Add(this.tabBans);
      this.主选项卡.Controls.Add(this.tabAnnouncements);
      this.主选项卡.Controls.Add(this.tabConfig);
      this.主选项卡.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.主选项卡.ItemSize = new System.Drawing.Size(170, 30);
      this.主选项卡.Location = new System.Drawing.Point(4, 5);
      this.主选项卡.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.主选项卡.Name = "主选项卡";
      this.主选项卡.SelectedIndex = 0;
      this.主选项卡.Size = new System.Drawing.Size(1741, 855);
      this.主选项卡.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
      this.主选项卡.TabIndex = 5;
      this.主选项卡.TabStop = false;
      // 
      // tabMain
      // 
      this.tabMain.BackColor = System.Drawing.Color.Gainsboro;
      this.tabMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.tabMain.Controls.Add(this.重载数据);
      this.tabMain.Controls.Add(this.清空命令日志);
      this.tabMain.Controls.Add(this.对象统计);
      this.tabMain.Controls.Add(this.MainTabs);
      this.tabMain.Controls.Add(this.清空聊天日志);
      this.tabMain.Controls.Add(this.保存聊天日志);
      this.tabMain.Controls.Add(this.已经登录统计);
      this.tabMain.Controls.Add(this.已经上线统计);
      this.tabMain.Controls.Add(this.连接总数统计);
      this.tabMain.Controls.Add(this.发送统计);
      this.tabMain.Controls.Add(this.接收统计);
      this.tabMain.Controls.Add(this.清空系统日志);
      this.tabMain.Controls.Add(this.保存系统日志);
      this.tabMain.Controls.Add(this.帧数统计);
      this.tabMain.Location = new System.Drawing.Point(4, 34);
      this.tabMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.tabMain.Name = "tabMain";
      this.tabMain.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.tabMain.Size = new System.Drawing.Size(1733, 817);
      this.tabMain.TabIndex = 0;
      this.tabMain.Text = "Main";
      // 
      // 清空命令日志
      // 
      this.清空命令日志.BackColor = System.Drawing.SystemColors.ActiveCaption;
      this.清空命令日志.Enabled = false;
      this.清空命令日志.Location = new System.Drawing.Point(1068, 558);
      this.清空命令日志.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.清空命令日志.Name = "清空命令日志";
      this.清空命令日志.Size = new System.Drawing.Size(301, 57);
      this.清空命令日志.TabIndex = 18;
      this.清空命令日志.Text = "Clear commands log";
      this.清空命令日志.UseVisualStyleBackColor = false;
      this.清空命令日志.Click += new System.EventHandler(this.清空命令日志_Click);
      // 
      // 对象统计
      // 
      this.对象统计.AutoSize = true;
      this.对象统计.ForeColor = System.Drawing.Color.Blue;
      this.对象统计.Location = new System.Drawing.Point(1068, 219);
      this.对象统计.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.对象统计.Name = "对象统计";
      this.对象统计.Size = new System.Drawing.Size(128, 16);
      this.对象统计.TabIndex = 17;
      this.对象统计.Text = "Objects statistics";
      // 
      // MainTabs
      // 
      this.MainTabs.Controls.Add(this.tabSystem);
      this.MainTabs.Controls.Add(this.tabChat);
      this.MainTabs.Controls.Add(this.tabCommands);
      this.MainTabs.Controls.Add(this.tabPackets);
      this.MainTabs.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.MainTabs.ItemSize = new System.Drawing.Size(230, 20);
      this.MainTabs.Location = new System.Drawing.Point(3, 3);
      this.MainTabs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.MainTabs.Name = "MainTabs";
      this.MainTabs.SelectedIndex = 0;
      this.MainTabs.Size = new System.Drawing.Size(1033, 621);
      this.MainTabs.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
      this.MainTabs.TabIndex = 16;
      // 
      // tabSystem
      // 
      this.tabSystem.BackColor = System.Drawing.Color.Gainsboro;
      this.tabSystem.Controls.Add(this.系统日志);
      this.tabSystem.Location = new System.Drawing.Point(4, 24);
      this.tabSystem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.tabSystem.Name = "tabSystem";
      this.tabSystem.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.tabSystem.Size = new System.Drawing.Size(1025, 593);
      this.tabSystem.TabIndex = 0;
      this.tabSystem.Text = "System logs";
      // 
      // 系统日志
      // 
      this.系统日志.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.系统日志.Dock = System.Windows.Forms.DockStyle.Fill;
      this.系统日志.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.系统日志.Location = new System.Drawing.Point(4, 5);
      this.系统日志.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.系统日志.Name = "系统日志";
      this.系统日志.ReadOnly = true;
      this.系统日志.Size = new System.Drawing.Size(1017, 583);
      this.系统日志.TabIndex = 0;
      this.系统日志.Text = "";
      // 
      // tabChat
      // 
      this.tabChat.BackColor = System.Drawing.Color.Gainsboro;
      this.tabChat.Controls.Add(this.聊天日志);
      this.tabChat.Location = new System.Drawing.Point(4, 24);
      this.tabChat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.tabChat.Name = "tabChat";
      this.tabChat.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.tabChat.Size = new System.Drawing.Size(1025, 593);
      this.tabChat.TabIndex = 1;
      this.tabChat.Text = "Chat Logs";
      // 
      // 聊天日志
      // 
      this.聊天日志.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.聊天日志.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.聊天日志.Location = new System.Drawing.Point(0, 0);
      this.聊天日志.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.聊天日志.Name = "聊天日志";
      this.聊天日志.ReadOnly = true;
      this.聊天日志.Size = new System.Drawing.Size(1020, 573);
      this.聊天日志.TabIndex = 1;
      this.聊天日志.Text = "";
      // 
      // tabCommands
      // 
      this.tabCommands.BackColor = System.Drawing.Color.Gainsboro;
      this.tabCommands.Controls.Add(this.命令日志);
      this.tabCommands.Location = new System.Drawing.Point(4, 24);
      this.tabCommands.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.tabCommands.Name = "tabCommands";
      this.tabCommands.Size = new System.Drawing.Size(1025, 593);
      this.tabCommands.TabIndex = 2;
      this.tabCommands.Text = "Commands logs";
      // 
      // 命令日志
      // 
      this.命令日志.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.命令日志.Dock = System.Windows.Forms.DockStyle.Fill;
      this.命令日志.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.命令日志.Location = new System.Drawing.Point(0, 0);
      this.命令日志.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.命令日志.Name = "命令日志";
      this.命令日志.ReadOnly = true;
      this.命令日志.Size = new System.Drawing.Size(1025, 593);
      this.命令日志.TabIndex = 2;
      this.命令日志.Text = "";
      // 
      // tabPackets
      // 
      this.tabPackets.Controls.Add(this.rtbPacketsLogs);
      this.tabPackets.Location = new System.Drawing.Point(4, 24);
      this.tabPackets.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.tabPackets.Name = "tabPackets";
      this.tabPackets.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.tabPackets.Size = new System.Drawing.Size(1025, 593);
      this.tabPackets.TabIndex = 3;
      this.tabPackets.Text = "Packets";
      this.tabPackets.UseVisualStyleBackColor = true;
      // 
      // rtbPacketsLogs
      // 
      this.rtbPacketsLogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.rtbPacketsLogs.Dock = System.Windows.Forms.DockStyle.Fill;
      this.rtbPacketsLogs.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.rtbPacketsLogs.Location = new System.Drawing.Point(3, 2);
      this.rtbPacketsLogs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.rtbPacketsLogs.Name = "rtbPacketsLogs";
      this.rtbPacketsLogs.ReadOnly = true;
      this.rtbPacketsLogs.Size = new System.Drawing.Size(1019, 589);
      this.rtbPacketsLogs.TabIndex = 2;
      this.rtbPacketsLogs.Text = "";
      // 
      // 清空聊天日志
      // 
      this.清空聊天日志.BackColor = System.Drawing.SystemColors.ActiveCaption;
      this.清空聊天日志.Enabled = false;
      this.清空聊天日志.Location = new System.Drawing.Point(1068, 485);
      this.清空聊天日志.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.清空聊天日志.Name = "清空聊天日志";
      this.清空聊天日志.Size = new System.Drawing.Size(301, 57);
      this.清空聊天日志.TabIndex = 15;
      this.清空聊天日志.Text = "Empty chat logs";
      this.清空聊天日志.UseVisualStyleBackColor = false;
      this.清空聊天日志.Click += new System.EventHandler(this.清空聊天日志_Click);
      // 
      // 保存聊天日志
      // 
      this.保存聊天日志.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
      this.保存聊天日志.Enabled = false;
      this.保存聊天日志.Location = new System.Drawing.Point(1068, 337);
      this.保存聊天日志.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.保存聊天日志.Name = "保存聊天日志";
      this.保存聊天日志.Size = new System.Drawing.Size(301, 57);
      this.保存聊天日志.TabIndex = 14;
      this.保存聊天日志.Text = "Save chat logs";
      this.保存聊天日志.UseVisualStyleBackColor = false;
      this.保存聊天日志.Click += new System.EventHandler(this.保存聊天日志_Click);
      // 
      // 已经登录统计
      // 
      this.已经登录统计.AutoSize = true;
      this.已经登录统计.ForeColor = System.Drawing.Color.Blue;
      this.已经登录统计.Location = new System.Drawing.Point(1068, 63);
      this.已经登录统计.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.已经登录统计.Name = "已经登录统计";
      this.已经登录统计.Size = new System.Drawing.Size(116, 16);
      this.已经登录统计.TabIndex = 13;
      this.已经登录统计.Text = "Already logged:";
      // 
      // 已经上线统计
      // 
      this.已经上线统计.AutoSize = true;
      this.已经上线统计.ForeColor = System.Drawing.Color.Blue;
      this.已经上线统计.Location = new System.Drawing.Point(1068, 94);
      this.已经上线统计.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.已经上线统计.Name = "已经上线统计";
      this.已经上线统计.Size = new System.Drawing.Size(89, 16);
      this.已经上线统计.TabIndex = 12;
      this.已经上线统计.Text = "Now online:";
      // 
      // 连接总数统计
      // 
      this.连接总数统计.AutoSize = true;
      this.连接总数统计.ForeColor = System.Drawing.Color.Blue;
      this.连接总数统计.Location = new System.Drawing.Point(1068, 32);
      this.连接总数统计.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.连接总数统计.Name = "连接总数统计";
      this.连接总数统计.Size = new System.Drawing.Size(135, 16);
      this.连接总数统计.TabIndex = 11;
      this.连接总数统计.Text = "Total connections:";
      // 
      // 发送统计
      // 
      this.发送统计.AutoSize = true;
      this.发送统计.ForeColor = System.Drawing.Color.Blue;
      this.发送统计.Location = new System.Drawing.Point(1068, 188);
      this.发送统计.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.发送统计.Name = "发送统计";
      this.发送统计.Size = new System.Drawing.Size(77, 16);
      this.发送统计.TabIndex = 10;
      this.发送统计.Text = "Data sent:";
      // 
      // 接收统计
      // 
      this.接收统计.AutoSize = true;
      this.接收统计.ForeColor = System.Drawing.Color.Blue;
      this.接收统计.Location = new System.Drawing.Point(1068, 156);
      this.接收统计.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.接收统计.Name = "接收统计";
      this.接收统计.Size = new System.Drawing.Size(77, 16);
      this.接收统计.TabIndex = 9;
      this.接收统计.Text = "Accepted:";
      // 
      // 清空系统日志
      // 
      this.清空系统日志.BackColor = System.Drawing.SystemColors.ActiveCaption;
      this.清空系统日志.Enabled = false;
      this.清空系统日志.Location = new System.Drawing.Point(1068, 411);
      this.清空系统日志.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.清空系统日志.Name = "清空系统日志";
      this.清空系统日志.Size = new System.Drawing.Size(301, 57);
      this.清空系统日志.TabIndex = 8;
      this.清空系统日志.Text = "Empty the system logs";
      this.清空系统日志.UseVisualStyleBackColor = false;
      this.清空系统日志.Visible = false;
      this.清空系统日志.Click += new System.EventHandler(this.清空系统日志_Click);
      // 
      // 保存系统日志
      // 
      this.保存系统日志.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
      this.保存系统日志.Enabled = false;
      this.保存系统日志.Location = new System.Drawing.Point(1068, 263);
      this.保存系统日志.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.保存系统日志.Name = "保存系统日志";
      this.保存系统日志.Size = new System.Drawing.Size(301, 57);
      this.保存系统日志.TabIndex = 7;
      this.保存系统日志.Text = "Save system logs";
      this.保存系统日志.UseVisualStyleBackColor = false;
      this.保存系统日志.Click += new System.EventHandler(this.保存系统日志_Click);
      // 
      // 帧数统计
      // 
      this.帧数统计.AutoSize = true;
      this.帧数统计.ForeColor = System.Drawing.Color.Blue;
      this.帧数统计.Location = new System.Drawing.Point(1068, 126);
      this.帧数统计.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.帧数统计.Name = "帧数统计";
      this.帧数统计.Size = new System.Drawing.Size(91, 16);
      this.帧数统计.TabIndex = 1;
      this.帧数统计.Text = "Framerates:";
      // 
      // tabCharacters
      // 
      this.tabCharacters.BackColor = System.Drawing.Color.Gainsboro;
      this.tabCharacters.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.tabCharacters.Controls.Add(this.角色详情选项卡);
      this.tabCharacters.Controls.Add(this.dgvCharacters);
      this.tabCharacters.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.tabCharacters.Location = new System.Drawing.Point(4, 34);
      this.tabCharacters.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.tabCharacters.Name = "tabCharacters";
      this.tabCharacters.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.tabCharacters.Size = new System.Drawing.Size(1733, 817);
      this.tabCharacters.TabIndex = 4;
      this.tabCharacters.Text = "Characters";
      // 
      // 角色详情选项卡
      // 
      this.角色详情选项卡.Controls.Add(this.CharacterData_技能);
      this.角色详情选项卡.Controls.Add(this.CharacterData_装备);
      this.角色详情选项卡.Controls.Add(this.CharacterData_背包);
      this.角色详情选项卡.Controls.Add(this.CharacterData_仓库);
      this.角色详情选项卡.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.角色详情选项卡.ItemSize = new System.Drawing.Size(85, 20);
      this.角色详情选项卡.Location = new System.Drawing.Point(981, 5);
      this.角色详情选项卡.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.角色详情选项卡.Name = "角色详情选项卡";
      this.角色详情选项卡.SelectedIndex = 0;
      this.角色详情选项卡.Size = new System.Drawing.Size(402, 615);
      this.角色详情选项卡.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
      this.角色详情选项卡.TabIndex = 2;
      // 
      // CharacterData_技能
      // 
      this.CharacterData_技能.BackColor = System.Drawing.Color.Gainsboro;
      this.CharacterData_技能.Controls.Add(this.技能浏览表);
      this.CharacterData_技能.Location = new System.Drawing.Point(4, 24);
      this.CharacterData_技能.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.CharacterData_技能.Name = "CharacterData_技能";
      this.CharacterData_技能.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.CharacterData_技能.Size = new System.Drawing.Size(394, 587);
      this.CharacterData_技能.TabIndex = 0;
      this.CharacterData_技能.Text = "Skills";
      // 
      // 技能浏览表
      // 
      this.技能浏览表.AllowUserToAddRows = false;
      this.技能浏览表.AllowUserToDeleteRows = false;
      this.技能浏览表.AllowUserToResizeRows = false;
      dataGridViewCellStyle31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.技能浏览表.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle31;
      this.技能浏览表.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.技能浏览表.BackgroundColor = System.Drawing.Color.LightGray;
      this.技能浏览表.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.技能浏览表.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
      dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle32.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle32.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      dataGridViewCellStyle32.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle32.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle32.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle32.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.技能浏览表.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle32;
      this.技能浏览表.ColumnHeadersHeight = 29;
      this.技能浏览表.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      dataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle33.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle33.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      dataGridViewCellStyle33.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle33.SelectionBackColor = System.Drawing.SystemColors.ButtonShadow;
      dataGridViewCellStyle33.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle33.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.技能浏览表.DefaultCellStyle = dataGridViewCellStyle33;
      this.技能浏览表.GridColor = System.Drawing.SystemColors.ActiveCaption;
      this.技能浏览表.Location = new System.Drawing.Point(0, 0);
      this.技能浏览表.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.技能浏览表.MultiSelect = false;
      this.技能浏览表.Name = "技能浏览表";
      this.技能浏览表.ReadOnly = true;
      this.技能浏览表.RowHeadersVisible = false;
      this.技能浏览表.RowHeadersWidth = 51;
      this.技能浏览表.RowTemplate.Height = 23;
      this.技能浏览表.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.技能浏览表.ShowCellToolTips = false;
      this.技能浏览表.Size = new System.Drawing.Size(386, 570);
      this.技能浏览表.TabIndex = 3;
      // 
      // CharacterData_装备
      // 
      this.CharacterData_装备.BackColor = System.Drawing.Color.Gainsboro;
      this.CharacterData_装备.Controls.Add(this.装备浏览表);
      this.CharacterData_装备.Location = new System.Drawing.Point(4, 24);
      this.CharacterData_装备.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.CharacterData_装备.Name = "CharacterData_装备";
      this.CharacterData_装备.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.CharacterData_装备.Size = new System.Drawing.Size(394, 587);
      this.CharacterData_装备.TabIndex = 1;
      this.CharacterData_装备.Text = "Equipment";
      // 
      // 装备浏览表
      // 
      this.装备浏览表.AllowUserToAddRows = false;
      this.装备浏览表.AllowUserToDeleteRows = false;
      this.装备浏览表.AllowUserToResizeRows = false;
      dataGridViewCellStyle34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.装备浏览表.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle34;
      this.装备浏览表.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.装备浏览表.BackgroundColor = System.Drawing.Color.LightGray;
      this.装备浏览表.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.装备浏览表.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
      dataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle35.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle35.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      dataGridViewCellStyle35.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle35.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle35.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle35.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.装备浏览表.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle35;
      this.装备浏览表.ColumnHeadersHeight = 29;
      this.装备浏览表.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      dataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle36.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle36.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      dataGridViewCellStyle36.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle36.SelectionBackColor = System.Drawing.SystemColors.ButtonShadow;
      dataGridViewCellStyle36.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle36.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.装备浏览表.DefaultCellStyle = dataGridViewCellStyle36;
      this.装备浏览表.GridColor = System.Drawing.SystemColors.ActiveCaption;
      this.装备浏览表.Location = new System.Drawing.Point(0, 0);
      this.装备浏览表.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.装备浏览表.MultiSelect = false;
      this.装备浏览表.Name = "装备浏览表";
      this.装备浏览表.ReadOnly = true;
      this.装备浏览表.RowHeadersVisible = false;
      this.装备浏览表.RowHeadersWidth = 51;
      this.装备浏览表.RowTemplate.Height = 23;
      this.装备浏览表.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.装备浏览表.ShowCellToolTips = false;
      this.装备浏览表.Size = new System.Drawing.Size(386, 570);
      this.装备浏览表.TabIndex = 4;
      // 
      // CharacterData_背包
      // 
      this.CharacterData_背包.BackColor = System.Drawing.Color.Gainsboro;
      this.CharacterData_背包.Controls.Add(this.背包浏览表);
      this.CharacterData_背包.Location = new System.Drawing.Point(4, 24);
      this.CharacterData_背包.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.CharacterData_背包.Name = "CharacterData_背包";
      this.CharacterData_背包.Size = new System.Drawing.Size(394, 587);
      this.CharacterData_背包.TabIndex = 2;
      this.CharacterData_背包.Text = "Bag";
      // 
      // 背包浏览表
      // 
      this.背包浏览表.AllowUserToAddRows = false;
      this.背包浏览表.AllowUserToDeleteRows = false;
      this.背包浏览表.AllowUserToResizeRows = false;
      dataGridViewCellStyle37.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.背包浏览表.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle37;
      this.背包浏览表.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.背包浏览表.BackgroundColor = System.Drawing.Color.LightGray;
      this.背包浏览表.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.背包浏览表.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
      dataGridViewCellStyle38.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle38.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle38.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      dataGridViewCellStyle38.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle38.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle38.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle38.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.背包浏览表.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle38;
      this.背包浏览表.ColumnHeadersHeight = 29;
      this.背包浏览表.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      dataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle39.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle39.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      dataGridViewCellStyle39.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle39.SelectionBackColor = System.Drawing.SystemColors.ButtonShadow;
      dataGridViewCellStyle39.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle39.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.背包浏览表.DefaultCellStyle = dataGridViewCellStyle39;
      this.背包浏览表.GridColor = System.Drawing.SystemColors.ActiveCaption;
      this.背包浏览表.Location = new System.Drawing.Point(0, 0);
      this.背包浏览表.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.背包浏览表.MultiSelect = false;
      this.背包浏览表.Name = "背包浏览表";
      this.背包浏览表.ReadOnly = true;
      this.背包浏览表.RowHeadersVisible = false;
      this.背包浏览表.RowHeadersWidth = 51;
      this.背包浏览表.RowTemplate.Height = 23;
      this.背包浏览表.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.背包浏览表.ShowCellToolTips = false;
      this.背包浏览表.Size = new System.Drawing.Size(386, 570);
      this.背包浏览表.TabIndex = 4;
      // 
      // CharacterData_仓库
      // 
      this.CharacterData_仓库.BackColor = System.Drawing.Color.Gainsboro;
      this.CharacterData_仓库.Controls.Add(this.仓库浏览表);
      this.CharacterData_仓库.Location = new System.Drawing.Point(4, 24);
      this.CharacterData_仓库.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.CharacterData_仓库.Name = "CharacterData_仓库";
      this.CharacterData_仓库.Size = new System.Drawing.Size(394, 587);
      this.CharacterData_仓库.TabIndex = 3;
      this.CharacterData_仓库.Text = "Store";
      // 
      // 仓库浏览表
      // 
      this.仓库浏览表.AllowUserToAddRows = false;
      this.仓库浏览表.AllowUserToDeleteRows = false;
      this.仓库浏览表.AllowUserToResizeRows = false;
      dataGridViewCellStyle40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.仓库浏览表.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle40;
      this.仓库浏览表.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.仓库浏览表.BackgroundColor = System.Drawing.Color.LightGray;
      this.仓库浏览表.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.仓库浏览表.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
      dataGridViewCellStyle41.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle41.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle41.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      dataGridViewCellStyle41.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle41.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle41.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle41.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.仓库浏览表.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle41;
      this.仓库浏览表.ColumnHeadersHeight = 29;
      this.仓库浏览表.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      dataGridViewCellStyle42.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle42.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle42.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      dataGridViewCellStyle42.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle42.SelectionBackColor = System.Drawing.SystemColors.ButtonShadow;
      dataGridViewCellStyle42.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle42.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.仓库浏览表.DefaultCellStyle = dataGridViewCellStyle42;
      this.仓库浏览表.GridColor = System.Drawing.SystemColors.ActiveCaption;
      this.仓库浏览表.Location = new System.Drawing.Point(0, 0);
      this.仓库浏览表.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.仓库浏览表.MultiSelect = false;
      this.仓库浏览表.Name = "仓库浏览表";
      this.仓库浏览表.ReadOnly = true;
      this.仓库浏览表.RowHeadersVisible = false;
      this.仓库浏览表.RowHeadersWidth = 51;
      this.仓库浏览表.RowTemplate.Height = 23;
      this.仓库浏览表.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.仓库浏览表.ShowCellToolTips = false;
      this.仓库浏览表.Size = new System.Drawing.Size(386, 570);
      this.仓库浏览表.TabIndex = 5;
      // 
      // dgvCharacters
      // 
      this.dgvCharacters.AllowUserToAddRows = false;
      this.dgvCharacters.AllowUserToDeleteRows = false;
      this.dgvCharacters.AllowUserToResizeRows = false;
      dataGridViewCellStyle43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.dgvCharacters.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle43;
      this.dgvCharacters.BackgroundColor = System.Drawing.Color.LightGray;
      this.dgvCharacters.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.dgvCharacters.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
      dataGridViewCellStyle44.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle44.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle44.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      dataGridViewCellStyle44.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle44.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle44.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle44.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.dgvCharacters.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle44;
      this.dgvCharacters.ColumnHeadersHeight = 29;
      this.dgvCharacters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.dgvCharacters.ContextMenuStrip = this.角色右键菜单;
      dataGridViewCellStyle45.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle45.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle45.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      dataGridViewCellStyle45.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle45.SelectionBackColor = System.Drawing.SystemColors.ButtonShadow;
      dataGridViewCellStyle45.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle45.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.dgvCharacters.DefaultCellStyle = dataGridViewCellStyle45;
      this.dgvCharacters.GridColor = System.Drawing.SystemColors.ActiveCaption;
      this.dgvCharacters.Location = new System.Drawing.Point(0, 5);
      this.dgvCharacters.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.dgvCharacters.MultiSelect = false;
      this.dgvCharacters.Name = "dgvCharacters";
      this.dgvCharacters.ReadOnly = true;
      this.dgvCharacters.RowHeadersVisible = false;
      this.dgvCharacters.RowHeadersWidth = 51;
      this.dgvCharacters.RowTemplate.Height = 23;
      this.dgvCharacters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgvCharacters.ShowCellToolTips = false;
      this.dgvCharacters.Size = new System.Drawing.Size(979, 615);
      this.dgvCharacters.TabIndex = 1;
      // 
      // 角色右键菜单
      // 
      this.角色右键菜单.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.角色右键菜单.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.右键菜单_复制CharName,
            this.右键菜单_复制Account,
            this.右键菜单_复制网络地址,
            this.右键菜单_复制物理地址});
      this.角色右键菜单.Name = "角色右键菜单";
      this.角色右键菜单.Size = new System.Drawing.Size(192, 92);
      // 
      // 右键菜单_复制CharName
      // 
      this.右键菜单_复制CharName.Name = "右键菜单_复制CharName";
      this.右键菜单_复制CharName.Size = new System.Drawing.Size(191, 22);
      this.右键菜单_复制CharName.Text = "Copy char name";
      this.右键菜单_复制CharName.Click += new System.EventHandler(this.角色右键菜单_Click);
      // 
      // 右键菜单_复制Account
      // 
      this.右键菜单_复制Account.Name = "右键菜单_复制Account";
      this.右键菜单_复制Account.Size = new System.Drawing.Size(191, 22);
      this.右键菜单_复制Account.Text = "Copy account name";
      this.右键菜单_复制Account.Click += new System.EventHandler(this.角色右键菜单_Click);
      // 
      // 右键菜单_复制网络地址
      // 
      this.右键菜单_复制网络地址.Name = "右键菜单_复制网络地址";
      this.右键菜单_复制网络地址.Size = new System.Drawing.Size(191, 22);
      this.右键菜单_复制网络地址.Text = "Copy IP";
      this.右键菜单_复制网络地址.Click += new System.EventHandler(this.角色右键菜单_Click);
      // 
      // 右键菜单_复制物理地址
      // 
      this.右键菜单_复制物理地址.Name = "右键菜单_复制物理地址";
      this.右键菜单_复制物理地址.Size = new System.Drawing.Size(191, 22);
      this.右键菜单_复制物理地址.Text = "Copy MAC Addr";
      this.右键菜单_复制物理地址.Click += new System.EventHandler(this.角色右键菜单_Click);
      // 
      // tabMaps
      // 
      this.tabMaps.BackColor = System.Drawing.Color.Gainsboro;
      this.tabMaps.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.tabMaps.Controls.Add(this.dgvMaps);
      this.tabMaps.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.tabMaps.Location = new System.Drawing.Point(4, 34);
      this.tabMaps.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.tabMaps.Name = "tabMaps";
      this.tabMaps.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.tabMaps.Size = new System.Drawing.Size(1733, 817);
      this.tabMaps.TabIndex = 1;
      this.tabMaps.Text = "Maps";
      // 
      // dgvMaps
      // 
      this.dgvMaps.AllowUserToAddRows = false;
      this.dgvMaps.AllowUserToDeleteRows = false;
      this.dgvMaps.AllowUserToResizeRows = false;
      dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.dgvMaps.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
      this.dgvMaps.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.dgvMaps.BackgroundColor = System.Drawing.Color.LightGray;
      this.dgvMaps.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.dgvMaps.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
      dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle14.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.dgvMaps.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
      this.dgvMaps.ColumnHeadersHeight = 29;
      this.dgvMaps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle15.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.ButtonShadow;
      dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.dgvMaps.DefaultCellStyle = dataGridViewCellStyle15;
      this.dgvMaps.GridColor = System.Drawing.SystemColors.ActiveCaption;
      this.dgvMaps.Location = new System.Drawing.Point(0, 5);
      this.dgvMaps.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.dgvMaps.MultiSelect = false;
      this.dgvMaps.Name = "dgvMaps";
      this.dgvMaps.ReadOnly = true;
      this.dgvMaps.RowHeadersVisible = false;
      this.dgvMaps.RowHeadersWidth = 51;
      this.dgvMaps.RowTemplate.Height = 23;
      this.dgvMaps.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgvMaps.ShowCellToolTips = false;
      this.dgvMaps.Size = new System.Drawing.Size(1385, 615);
      this.dgvMaps.TabIndex = 2;
      // 
      // tabMonsters
      // 
      this.tabMonsters.BackColor = System.Drawing.Color.Gainsboro;
      this.tabMonsters.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.tabMonsters.Controls.Add(this.掉落浏览表);
      this.tabMonsters.Controls.Add(this.怪物浏览表);
      this.tabMonsters.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.tabMonsters.Location = new System.Drawing.Point(4, 34);
      this.tabMonsters.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.tabMonsters.Name = "tabMonsters";
      this.tabMonsters.Size = new System.Drawing.Size(1733, 817);
      this.tabMonsters.TabIndex = 2;
      this.tabMonsters.Text = "Monsters";
      // 
      // 掉落浏览表
      // 
      this.掉落浏览表.AllowUserToAddRows = false;
      this.掉落浏览表.AllowUserToDeleteRows = false;
      this.掉落浏览表.AllowUserToResizeRows = false;
      dataGridViewCellStyle46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.掉落浏览表.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle46;
      this.掉落浏览表.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.掉落浏览表.BackgroundColor = System.Drawing.Color.LightGray;
      this.掉落浏览表.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.掉落浏览表.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
      dataGridViewCellStyle47.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle47.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle47.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      dataGridViewCellStyle47.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle47.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle47.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle47.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.掉落浏览表.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle47;
      this.掉落浏览表.ColumnHeadersHeight = 29;
      this.掉落浏览表.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      dataGridViewCellStyle48.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle48.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle48.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      dataGridViewCellStyle48.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle48.SelectionBackColor = System.Drawing.SystemColors.ButtonShadow;
      dataGridViewCellStyle48.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle48.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.掉落浏览表.DefaultCellStyle = dataGridViewCellStyle48;
      this.掉落浏览表.GridColor = System.Drawing.SystemColors.ActiveCaption;
      this.掉落浏览表.Location = new System.Drawing.Point(1053, 5);
      this.掉落浏览表.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.掉落浏览表.MultiSelect = false;
      this.掉落浏览表.Name = "掉落浏览表";
      this.掉落浏览表.ReadOnly = true;
      this.掉落浏览表.RowHeadersVisible = false;
      this.掉落浏览表.RowHeadersWidth = 51;
      this.掉落浏览表.RowTemplate.Height = 23;
      this.掉落浏览表.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.掉落浏览表.ShowCellToolTips = false;
      this.掉落浏览表.Size = new System.Drawing.Size(332, 615);
      this.掉落浏览表.TabIndex = 5;
      // 
      // 怪物浏览表
      // 
      this.怪物浏览表.AllowUserToAddRows = false;
      this.怪物浏览表.AllowUserToDeleteRows = false;
      this.怪物浏览表.AllowUserToResizeRows = false;
      dataGridViewCellStyle49.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.怪物浏览表.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle49;
      this.怪物浏览表.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.怪物浏览表.BackgroundColor = System.Drawing.Color.LightGray;
      this.怪物浏览表.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.怪物浏览表.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
      dataGridViewCellStyle50.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle50.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle50.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      dataGridViewCellStyle50.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle50.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle50.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle50.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.怪物浏览表.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle50;
      this.怪物浏览表.ColumnHeadersHeight = 29;
      this.怪物浏览表.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      dataGridViewCellStyle51.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle51.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle51.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      dataGridViewCellStyle51.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle51.SelectionBackColor = System.Drawing.SystemColors.ButtonShadow;
      dataGridViewCellStyle51.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle51.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.怪物浏览表.DefaultCellStyle = dataGridViewCellStyle51;
      this.怪物浏览表.GridColor = System.Drawing.SystemColors.ActiveCaption;
      this.怪物浏览表.Location = new System.Drawing.Point(0, 5);
      this.怪物浏览表.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.怪物浏览表.MultiSelect = false;
      this.怪物浏览表.Name = "怪物浏览表";
      this.怪物浏览表.ReadOnly = true;
      this.怪物浏览表.RowHeadersVisible = false;
      this.怪物浏览表.RowHeadersWidth = 51;
      this.怪物浏览表.RowTemplate.Height = 23;
      this.怪物浏览表.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.怪物浏览表.ShowCellToolTips = false;
      this.怪物浏览表.Size = new System.Drawing.Size(1046, 615);
      this.怪物浏览表.TabIndex = 3;
      // 
      // tabBans
      // 
      this.tabBans.BackColor = System.Drawing.Color.Gainsboro;
      this.tabBans.Controls.Add(this.封禁浏览表);
      this.tabBans.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.tabBans.Location = new System.Drawing.Point(4, 34);
      this.tabBans.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.tabBans.Name = "tabBans";
      this.tabBans.Size = new System.Drawing.Size(1733, 817);
      this.tabBans.TabIndex = 12;
      this.tabBans.Text = "Bans";
      // 
      // 封禁浏览表
      // 
      this.封禁浏览表.AllowUserToAddRows = false;
      this.封禁浏览表.AllowUserToDeleteRows = false;
      this.封禁浏览表.AllowUserToResizeRows = false;
      dataGridViewCellStyle52.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.封禁浏览表.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle52;
      this.封禁浏览表.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.封禁浏览表.BackgroundColor = System.Drawing.Color.LightGray;
      this.封禁浏览表.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.封禁浏览表.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
      dataGridViewCellStyle53.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle53.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle53.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      dataGridViewCellStyle53.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle53.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle53.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle53.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.封禁浏览表.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle53;
      this.封禁浏览表.ColumnHeadersHeight = 29;
      this.封禁浏览表.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      dataGridViewCellStyle54.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle54.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle54.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      dataGridViewCellStyle54.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle54.SelectionBackColor = System.Drawing.SystemColors.ButtonShadow;
      dataGridViewCellStyle54.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle54.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.封禁浏览表.DefaultCellStyle = dataGridViewCellStyle54;
      this.封禁浏览表.GridColor = System.Drawing.SystemColors.ActiveCaption;
      this.封禁浏览表.Location = new System.Drawing.Point(147, 5);
      this.封禁浏览表.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.封禁浏览表.MultiSelect = false;
      this.封禁浏览表.Name = "封禁浏览表";
      this.封禁浏览表.ReadOnly = true;
      this.封禁浏览表.RowHeadersVisible = false;
      this.封禁浏览表.RowHeadersWidth = 51;
      this.封禁浏览表.RowTemplate.Height = 23;
      this.封禁浏览表.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.封禁浏览表.ShowCellToolTips = false;
      this.封禁浏览表.Size = new System.Drawing.Size(1000, 615);
      this.封禁浏览表.TabIndex = 6;
      // 
      // tabAnnouncements
      // 
      this.tabAnnouncements.BackColor = System.Drawing.Color.Gainsboro;
      this.tabAnnouncements.Controls.Add(this.开始公告按钮);
      this.tabAnnouncements.Controls.Add(this.停止公告按钮);
      this.tabAnnouncements.Controls.Add(this.删除公告按钮);
      this.tabAnnouncements.Controls.Add(this.添加公告按钮);
      this.tabAnnouncements.Controls.Add(this.公告浏览表);
      this.tabAnnouncements.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.tabAnnouncements.Location = new System.Drawing.Point(4, 34);
      this.tabAnnouncements.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.tabAnnouncements.Name = "tabAnnouncements";
      this.tabAnnouncements.Size = new System.Drawing.Size(1733, 817);
      this.tabAnnouncements.TabIndex = 13;
      this.tabAnnouncements.Text = "Announcements";
      // 
      // 开始公告按钮
      // 
      this.开始公告按钮.Enabled = false;
      this.开始公告按钮.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.开始公告按钮.Location = new System.Drawing.Point(6, 562);
      this.开始公告按钮.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.开始公告按钮.Name = "开始公告按钮";
      this.开始公告按钮.Size = new System.Drawing.Size(343, 43);
      this.开始公告按钮.TabIndex = 7;
      this.开始公告按钮.Text = "Start selected announces";
      this.开始公告按钮.UseVisualStyleBackColor = true;
      this.开始公告按钮.Click += new System.EventHandler(this.StartAnnouncement_Click);
      // 
      // 停止公告按钮
      // 
      this.停止公告按钮.Enabled = false;
      this.停止公告按钮.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.停止公告按钮.Location = new System.Drawing.Point(349, 562);
      this.停止公告按钮.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.停止公告按钮.Name = "停止公告按钮";
      this.停止公告按钮.Size = new System.Drawing.Size(343, 43);
      this.停止公告按钮.TabIndex = 6;
      this.停止公告按钮.Text = "Stop announcements";
      this.停止公告按钮.UseVisualStyleBackColor = true;
      this.停止公告按钮.Click += new System.EventHandler(this.停止公告按钮_Click);
      // 
      // 删除公告按钮
      // 
      this.删除公告按钮.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.删除公告按钮.Location = new System.Drawing.Point(1035, 562);
      this.删除公告按钮.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.删除公告按钮.Name = "删除公告按钮";
      this.删除公告按钮.Size = new System.Drawing.Size(343, 43);
      this.删除公告按钮.TabIndex = 5;
      this.删除公告按钮.Text = "Delete selected announcement";
      this.删除公告按钮.UseVisualStyleBackColor = true;
      this.删除公告按钮.Click += new System.EventHandler(this.删除公告按钮_Click);
      // 
      // 添加公告按钮
      // 
      this.添加公告按钮.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.添加公告按钮.Location = new System.Drawing.Point(692, 562);
      this.添加公告按钮.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.添加公告按钮.Name = "添加公告按钮";
      this.添加公告按钮.Size = new System.Drawing.Size(343, 43);
      this.添加公告按钮.TabIndex = 4;
      this.添加公告按钮.Text = "Add new announcement";
      this.添加公告按钮.UseVisualStyleBackColor = true;
      this.添加公告按钮.Click += new System.EventHandler(this.添加公告按钮_Click);
      // 
      // 公告浏览表
      // 
      this.公告浏览表.AllowUserToAddRows = false;
      this.公告浏览表.AllowUserToDeleteRows = false;
      this.公告浏览表.AllowUserToResizeColumns = false;
      this.公告浏览表.AllowUserToResizeRows = false;
      this.公告浏览表.BackgroundColor = System.Drawing.SystemColors.ControlLight;
      dataGridViewCellStyle55.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle55.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle55.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      dataGridViewCellStyle55.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle55.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle55.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle55.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.公告浏览表.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle55;
      this.公告浏览表.ColumnHeadersHeight = 29;
      this.公告浏览表.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.公告浏览表.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Status,
            this.Interval,
            this.Count,
            this.RemainingTime,
            this.Time,
            this.Content});
      dataGridViewCellStyle56.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle56.BackColor = System.Drawing.Color.LightGray;
      dataGridViewCellStyle56.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      dataGridViewCellStyle56.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle56.SelectionBackColor = System.Drawing.SystemColors.ActiveBorder;
      dataGridViewCellStyle56.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle56.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.公告浏览表.DefaultCellStyle = dataGridViewCellStyle56;
      this.公告浏览表.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
      this.公告浏览表.Location = new System.Drawing.Point(6, 5);
      this.公告浏览表.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.公告浏览表.MultiSelect = false;
      this.公告浏览表.Name = "公告浏览表";
      dataGridViewCellStyle57.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter;
      dataGridViewCellStyle57.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle57.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      dataGridViewCellStyle57.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle57.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle57.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle57.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.公告浏览表.RowHeadersDefaultCellStyle = dataGridViewCellStyle57;
      this.公告浏览表.RowHeadersVisible = false;
      this.公告浏览表.RowHeadersWidth = 51;
      this.公告浏览表.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
      this.公告浏览表.RowTemplate.Height = 23;
      this.公告浏览表.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.公告浏览表.ShowCellToolTips = false;
      this.公告浏览表.Size = new System.Drawing.Size(1375, 533);
      this.公告浏览表.TabIndex = 3;
      this.公告浏览表.TabStop = false;
      this.公告浏览表.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.公告浏览表_CellEndEdit);
      this.公告浏览表.SelectionChanged += new System.EventHandler(this.公告浏览表_SelectionChanged);
      // 
      // Status
      // 
      this.Status.Frozen = true;
      this.Status.HeaderText = "Status";
      this.Status.MinimumWidth = 6;
      this.Status.Name = "Status";
      this.Status.ReadOnly = true;
      this.Status.Width = 60;
      // 
      // Interval
      // 
      this.Interval.DataPropertyName = "Interval";
      this.Interval.Frozen = true;
      this.Interval.HeaderText = "Interval";
      this.Interval.MinimumWidth = 6;
      this.Interval.Name = "Interval";
      this.Interval.Width = 80;
      // 
      // Count
      // 
      this.Count.DataPropertyName = "Count";
      this.Count.Frozen = true;
      this.Count.HeaderText = "Count";
      this.Count.MinimumWidth = 6;
      this.Count.Name = "Count";
      this.Count.Width = 80;
      // 
      // RemainingTime
      // 
      this.RemainingTime.Frozen = true;
      this.RemainingTime.HeaderText = "Remaining Time";
      this.RemainingTime.MinimumWidth = 6;
      this.RemainingTime.Name = "RemainingTime";
      this.RemainingTime.ReadOnly = true;
      this.RemainingTime.Width = 80;
      // 
      // Time
      // 
      this.Time.Frozen = true;
      this.Time.HeaderText = "Time";
      this.Time.MinimumWidth = 6;
      this.Time.Name = "Time";
      this.Time.ReadOnly = true;
      this.Time.Width = 90;
      // 
      // Content
      // 
      this.Content.DataPropertyName = "Content";
      this.Content.Frozen = true;
      this.Content.HeaderText = "Content";
      this.Content.MinimumWidth = 6;
      this.Content.Name = "Content";
      this.Content.Width = 884;
      // 
      // tabConfig
      // 
      this.tabConfig.BackColor = System.Drawing.Color.Gainsboro;
      this.tabConfig.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.tabConfig.Controls.Add(this.S_软件授权分组);
      this.tabConfig.Controls.Add(this.S_GameData分组);
      this.tabConfig.Controls.Add(this.S_游戏设置分组);
      this.tabConfig.Controls.Add(this.S_网络设置分组);
      this.tabConfig.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.tabConfig.Location = new System.Drawing.Point(4, 34);
      this.tabConfig.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.tabConfig.Name = "tabConfig";
      this.tabConfig.Size = new System.Drawing.Size(1733, 817);
      this.tabConfig.TabIndex = 11;
      this.tabConfig.Text = "Config";
      // 
      // S_软件授权分组
      // 
      this.S_软件授权分组.Controls.Add(this.S_软件注册代码);
      this.S_软件授权分组.Location = new System.Drawing.Point(18, 524);
      this.S_软件授权分组.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.S_软件授权分组.Name = "S_软件授权分组";
      this.S_软件授权分组.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.S_软件授权分组.Size = new System.Drawing.Size(690, 77);
      this.S_软件授权分组.TabIndex = 11;
      this.S_软件授权分组.TabStop = false;
      this.S_软件授权分组.Text = "Registration code";
      // 
      // S_软件注册代码
      // 
      this.S_软件注册代码.Location = new System.Drawing.Point(7, 29);
      this.S_软件注册代码.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.S_软件注册代码.Name = "S_软件注册代码";
      this.S_软件注册代码.Size = new System.Drawing.Size(675, 21);
      this.S_软件注册代码.TabIndex = 11;
      this.S_软件注册代码.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // S_GameData分组
      // 
      this.S_GameData分组.Controls.Add(this.label1);
      this.S_GameData分组.Controls.Add(this.S_注意事项标签8);
      this.S_GameData分组.Controls.Add(this.S_注意事项标签7);
      this.S_GameData分组.Controls.Add(this.S_注意事项标签6);
      this.S_GameData分组.Controls.Add(this.S_注意事项标签5);
      this.S_GameData分组.Controls.Add(this.S_注意事项标签4);
      this.S_GameData分组.Controls.Add(this.S_注意事项标签3);
      this.S_GameData分组.Controls.Add(this.S_注意事项标签2);
      this.S_GameData分组.Controls.Add(this.S_注意事项标签1);
      this.S_GameData分组.Controls.Add(this.S_重载客户数据);
      this.S_GameData分组.Controls.Add(this.S_重载SystemData);
      this.S_GameData分组.Controls.Add(this.S_浏览合并目录);
      this.S_GameData分组.Controls.Add(this.S_浏览备份目录);
      this.S_GameData分组.Controls.Add(this.S_浏览数据目录);
      this.S_GameData分组.Controls.Add(this.S_合并客户数据);
      this.S_GameData分组.Controls.Add(this.S_合并数据目录);
      this.S_GameData分组.Controls.Add(this.S_合并目录标签);
      this.S_GameData分组.Controls.Add(this.S_数据备份目录);
      this.S_GameData分组.Controls.Add(this.S_GameData目录);
      this.S_GameData分组.Controls.Add(this.S_备份目录标签);
      this.S_GameData分组.Controls.Add(this.S_数据目录标签);
      this.S_GameData分组.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.S_GameData分组.Location = new System.Drawing.Point(741, 17);
      this.S_GameData分组.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.S_GameData分组.Name = "S_GameData分组";
      this.S_GameData分组.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.S_GameData分组.Size = new System.Drawing.Size(571, 586);
      this.S_GameData分组.TabIndex = 10;
      this.S_GameData分组.TabStop = false;
      this.S_GameData分组.Text = "GameData";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.label1.ForeColor = System.Drawing.Color.Blue;
      this.label1.Location = new System.Drawing.Point(24, 536);
      this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(425, 15);
      this.label1.TabIndex = 28;
      this.label1.Text = "Incoming % exp defines the amount of less exp received until max lvl exp cap";
      // 
      // S_注意事项标签8
      // 
      this.S_注意事项标签8.AutoSize = true;
      this.S_注意事项标签8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.S_注意事项标签8.ForeColor = System.Drawing.Color.Blue;
      this.S_注意事项标签8.Location = new System.Drawing.Point(24, 507);
      this.S_注意事项标签8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.S_注意事项标签8.Name = "S_注意事项标签8";
      this.S_注意事项标签8.Size = new System.Drawing.Size(432, 15);
      this.S_注意事项标签8.TabIndex = 27;
      this.S_注意事项标签8.Text = "Max Lvl Exp defines the cap level for your exp reduction, after this, you will ge" +
"t 0";
      this.S_注意事项标签8.Click += new System.EventHandler(this.S_注意事项标签8_Click);
      // 
      // S_注意事项标签7
      // 
      this.S_注意事项标签7.AutoSize = true;
      this.S_注意事项标签7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.S_注意事项标签7.ForeColor = System.Drawing.Color.Blue;
      this.S_注意事项标签7.Location = new System.Drawing.Point(24, 478);
      this.S_注意事项标签7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.S_注意事项标签7.Name = "S_注意事项标签7";
      this.S_注意事项标签7.Size = new System.Drawing.Size(188, 15);
      this.S_注意事项标签7.TabIndex = 26;
      this.S_注意事项标签7.Text = "Max Player it\'s cap level on server";
      // 
      // S_注意事项标签6
      // 
      this.S_注意事项标签6.AutoSize = true;
      this.S_注意事项标签6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.S_注意事项标签6.ForeColor = System.Drawing.Color.Blue;
      this.S_注意事项标签6.Location = new System.Drawing.Point(24, 449);
      this.S_注意事项标签6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.S_注意事项标签6.Name = "S_注意事项标签6";
      this.S_注意事项标签6.Size = new System.Drawing.Size(367, 15);
      this.S_注意事项标签6.TabIndex = 25;
      this.S_注意事项标签6.Text = "Noob Level means get double exp % adquired until lvl on settings ";
      this.S_注意事项标签6.Click += new System.EventHandler(this.S_注意事项标签6_Click);
      // 
      // S_注意事项标签5
      // 
      this.S_注意事项标签5.AutoSize = true;
      this.S_注意事项标签5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.S_注意事项标签5.ForeColor = System.Drawing.Color.Blue;
      this.S_注意事项标签5.Location = new System.Drawing.Point(24, 419);
      this.S_注意事项标签5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.S_注意事项标签5.Name = "S_注意事项标签5";
      this.S_注意事项标签5.Size = new System.Drawing.Size(354, 15);
      this.S_注意事项标签5.TabIndex = 24;
      this.S_注意事项标签5.Text = "Wiz Tame defines the maximum time of a pet with ElectricShock";
      this.S_注意事项标签5.Click += new System.EventHandler(this.S_注意事项标签5_Click);
      // 
      // S_注意事项标签4
      // 
      this.S_注意事项标签4.AutoSize = true;
      this.S_注意事项标签4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.S_注意事项标签4.ForeColor = System.Drawing.Color.Blue;
      this.S_注意事项标签4.Location = new System.Drawing.Point(24, 394);
      this.S_注意事项标签4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.S_注意事项标签4.Name = "S_注意事项标签4";
      this.S_注意事项标签4.Size = new System.Drawing.Size(551, 15);
      this.S_注意事项标签4.TabIndex = 23;
      this.S_注意事项标签4.Text = "The rate of gain reduction is a set rate of experience and rate reduction for eac" +
"h level beyond Level 1";
      // 
      // S_注意事项标签3
      // 
      this.S_注意事项标签3.AutoSize = true;
      this.S_注意事项标签3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.S_注意事项标签3.ForeColor = System.Drawing.Color.Blue;
      this.S_注意事项标签3.Location = new System.Drawing.Point(24, 377);
      this.S_注意事项标签3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.S_注意事项标签3.Name = "S_注意事项标签3";
      this.S_注意事项标签3.Size = new System.Drawing.Size(539, 15);
      this.S_注意事项标签3.TabIndex = 22;
      this.S_注意事项标签3.Text = "Extra Drop Formula: 1/(X - X * Extra Drop Rate), X means how many times randomly " +
"dropped once";
      this.S_注意事项标签3.Click += new System.EventHandler(this.S_注意事项标签3_Click);
      // 
      // S_注意事项标签2
      // 
      this.S_注意事项标签2.AutoSize = true;
      this.S_注意事项标签2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.S_注意事项标签2.ForeColor = System.Drawing.Color.Blue;
      this.S_注意事项标签2.Location = new System.Drawing.Point(24, 355);
      this.S_注意事项标签2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.S_注意事项标签2.Name = "S_注意事项标签2";
      this.S_注意事项标签2.Size = new System.Drawing.Size(369, 15);
      this.S_注意事项标签2.TabIndex = 20;
      this.S_注意事项标签2.Text = "Item Ownership defines the time of an item from mobs on the floor";
      // 
      // S_注意事项标签1
      // 
      this.S_注意事项标签1.AutoSize = true;
      this.S_注意事项标签1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.S_注意事项标签1.ForeColor = System.Drawing.Color.Blue;
      this.S_注意事项标签1.Location = new System.Drawing.Point(20, 328);
      this.S_注意事项标签1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.S_注意事项标签1.Name = "S_注意事项标签1";
      this.S_注意事项标签1.Size = new System.Drawing.Size(458, 15);
      this.S_注意事项标签1.TabIndex = 21;
      this.S_注意事项标签1.Text = "Settings info: All time settings on this page are in minutes, please note the set" +
"tings";
      // 
      // S_重载客户数据
      // 
      this.S_重载客户数据.Location = new System.Drawing.Point(20, 162);
      this.S_重载客户数据.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.S_重载客户数据.Name = "S_重载客户数据";
      this.S_重载客户数据.Size = new System.Drawing.Size(518, 33);
      this.S_重载客户数据.TabIndex = 13;
      this.S_重载客户数据.Text = "Reload users database";
      this.S_重载客户数据.UseVisualStyleBackColor = true;
      this.S_重载客户数据.Click += new System.EventHandler(this.重载客户数据_Click);
      // 
      // S_重载SystemData
      // 
      this.S_重载SystemData.Location = new System.Drawing.Point(20, 122);
      this.S_重载SystemData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.S_重载SystemData.Name = "S_重载SystemData";
      this.S_重载SystemData.Size = new System.Drawing.Size(518, 33);
      this.S_重载SystemData.TabIndex = 12;
      this.S_重载SystemData.Text = "Reload system data";
      this.S_重载SystemData.UseVisualStyleBackColor = true;
      this.S_重载SystemData.Click += new System.EventHandler(this.重载SystemData_Click);
      // 
      // S_浏览合并目录
      // 
      this.S_浏览合并目录.Location = new System.Drawing.Point(511, 235);
      this.S_浏览合并目录.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.S_浏览合并目录.Name = "S_浏览合并目录";
      this.S_浏览合并目录.Size = new System.Drawing.Size(27, 33);
      this.S_浏览合并目录.TabIndex = 11;
      this.S_浏览合并目录.Text = "S";
      this.S_浏览合并目录.UseVisualStyleBackColor = true;
      this.S_浏览合并目录.Click += new System.EventHandler(this.选择数据目录_Click);
      // 
      // S_浏览备份目录
      // 
      this.S_浏览备份目录.Location = new System.Drawing.Point(511, 77);
      this.S_浏览备份目录.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.S_浏览备份目录.Name = "S_浏览备份目录";
      this.S_浏览备份目录.Size = new System.Drawing.Size(27, 33);
      this.S_浏览备份目录.TabIndex = 10;
      this.S_浏览备份目录.Text = "S";
      this.S_浏览备份目录.UseVisualStyleBackColor = true;
      this.S_浏览备份目录.Click += new System.EventHandler(this.选择数据目录_Click);
      // 
      // S_浏览数据目录
      // 
      this.S_浏览数据目录.Location = new System.Drawing.Point(511, 35);
      this.S_浏览数据目录.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.S_浏览数据目录.Name = "S_浏览数据目录";
      this.S_浏览数据目录.Size = new System.Drawing.Size(27, 33);
      this.S_浏览数据目录.TabIndex = 9;
      this.S_浏览数据目录.Text = "S";
      this.S_浏览数据目录.UseVisualStyleBackColor = true;
      this.S_浏览数据目录.Click += new System.EventHandler(this.选择数据目录_Click);
      // 
      // S_合并客户数据
      // 
      this.S_合并客户数据.Location = new System.Drawing.Point(20, 280);
      this.S_合并客户数据.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.S_合并客户数据.Name = "S_合并客户数据";
      this.S_合并客户数据.Size = new System.Drawing.Size(518, 33);
      this.S_合并客户数据.TabIndex = 8;
      this.S_合并客户数据.Text = "Save users data";
      this.S_合并客户数据.UseVisualStyleBackColor = true;
      this.S_合并客户数据.Click += new System.EventHandler(this.合并客户数据_Click);
      // 
      // S_合并数据目录
      // 
      this.S_合并数据目录.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.S_合并数据目录.Location = new System.Drawing.Point(133, 238);
      this.S_合并数据目录.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.S_合并数据目录.Name = "S_合并数据目录";
      this.S_合并数据目录.Size = new System.Drawing.Size(382, 21);
      this.S_合并数据目录.TabIndex = 7;
      // 
      // S_合并目录标签
      // 
      this.S_合并目录标签.AutoSize = true;
      this.S_合并目录标签.Location = new System.Drawing.Point(20, 246);
      this.S_合并目录标签.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.S_合并目录标签.Name = "S_合并目录标签";
      this.S_合并目录标签.Size = new System.Drawing.Size(82, 15);
      this.S_合并目录标签.TabIndex = 6;
      this.S_合并目录标签.Text = "Data directory";
      // 
      // S_数据备份目录
      // 
      this.S_数据备份目录.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.S_数据备份目录.Location = new System.Drawing.Point(133, 79);
      this.S_数据备份目录.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.S_数据备份目录.Name = "S_数据备份目录";
      this.S_数据备份目录.ReadOnly = true;
      this.S_数据备份目录.Size = new System.Drawing.Size(382, 21);
      this.S_数据备份目录.TabIndex = 5;
      this.S_数据备份目录.Text = ".\\Backup";
      // 
      // S_GameData目录
      // 
      this.S_GameData目录.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.S_GameData目录.Location = new System.Drawing.Point(133, 39);
      this.S_GameData目录.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.S_GameData目录.Name = "S_GameData目录";
      this.S_GameData目录.ReadOnly = true;
      this.S_GameData目录.Size = new System.Drawing.Size(382, 21);
      this.S_GameData目录.TabIndex = 4;
      this.S_GameData目录.Text = ".\\Database";
      // 
      // S_备份目录标签
      // 
      this.S_备份目录标签.AutoSize = true;
      this.S_备份目录标签.Location = new System.Drawing.Point(20, 86);
      this.S_备份目录标签.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.S_备份目录标签.Name = "S_备份目录标签";
      this.S_备份目录标签.Size = new System.Drawing.Size(82, 15);
      this.S_备份目录标签.TabIndex = 3;
      this.S_备份目录标签.Text = "Backup folder";
      // 
      // S_数据目录标签
      // 
      this.S_数据目录标签.AutoSize = true;
      this.S_数据目录标签.Location = new System.Drawing.Point(20, 45);
      this.S_数据目录标签.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.S_数据目录标签.Name = "S_数据目录标签";
      this.S_数据目录标签.Size = new System.Drawing.Size(103, 15);
      this.S_数据目录标签.TabIndex = 1;
      this.S_数据目录标签.Text = "Gamedata Folder";
      // 
      // S_游戏设置分组
      // 
      this.S_游戏设置分组.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
      this.S_游戏设置分组.Controls.Add(this.L_NoobLevel);
      this.S_游戏设置分组.Controls.Add(this.S_NoobLevel);
      this.S_游戏设置分组.Controls.Add(this.S_物品归属标签);
      this.S_游戏设置分组.Controls.Add(this.S_ItemOwnershipTime);
      this.S_游戏设置分组.Controls.Add(this.S_收益衰减标签);
      this.S_游戏设置分组.Controls.Add(this.S_物品清理标签);
      this.S_游戏设置分组.Controls.Add(this.S_ItemCleaningTime);
      this.S_游戏设置分组.Controls.Add(this.S_诱惑时长标签);
      this.S_游戏设置分组.Controls.Add(this.S_TemptationTime);
      this.S_游戏设置分组.Controls.Add(this.S_LessExpGradeRate);
      this.S_游戏设置分组.Controls.Add(this.S_收益等级标签);
      this.S_游戏设置分组.Controls.Add(this.S_LessExpGrade);
      this.S_游戏设置分组.Controls.Add(this.S_经验倍率标签);
      this.S_游戏设置分组.Controls.Add(this.S_ExpRate);
      this.S_游戏设置分组.Controls.Add(this.S_特修折扣标签);
      this.S_游戏设置分组.Controls.Add(this.S_EquipRepairDto);
      this.S_游戏设置分组.Controls.Add(this.S_怪物爆率标签);
      this.S_游戏设置分组.Controls.Add(this.S_ExtraDropRate);
      this.S_游戏设置分组.Controls.Add(this.S_OpenLevelCommand标签);
      this.S_游戏设置分组.Controls.Add(this.S_MaxLevel);
      this.S_游戏设置分组.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.S_游戏设置分组.Location = new System.Drawing.Point(350, 17);
      this.S_游戏设置分组.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.S_游戏设置分组.Name = "S_游戏设置分组";
      this.S_游戏设置分组.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.S_游戏设置分组.Size = new System.Drawing.Size(357, 476);
      this.S_游戏设置分组.TabIndex = 8;
      this.S_游戏设置分组.TabStop = false;
      this.S_游戏设置分组.Text = "Game Settings";
      // 
      // L_NoobLevel
      // 
      this.L_NoobLevel.AutoSize = true;
      this.L_NoobLevel.Location = new System.Drawing.Point(70, 90);
      this.L_NoobLevel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.L_NoobLevel.Name = "L_NoobLevel";
      this.L_NoobLevel.Size = new System.Drawing.Size(69, 15);
      this.L_NoobLevel.TabIndex = 21;
      this.L_NoobLevel.Text = "Noob Level";
      // 
      // S_NoobLevel
      // 
      this.S_NoobLevel.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.S_NoobLevel.Location = new System.Drawing.Point(189, 80);
      this.S_NoobLevel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.S_NoobLevel.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
      this.S_NoobLevel.Name = "S_NoobLevel";
      this.S_NoobLevel.Size = new System.Drawing.Size(127, 24);
      this.S_NoobLevel.TabIndex = 20;
      this.S_NoobLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // S_物品归属标签
      // 
      this.S_物品归属标签.AutoSize = true;
      this.S_物品归属标签.Location = new System.Drawing.Point(41, 419);
      this.S_物品归属标签.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.S_物品归属标签.Name = "S_物品归属标签";
      this.S_物品归属标签.Size = new System.Drawing.Size(125, 15);
      this.S_物品归属标签.TabIndex = 19;
      this.S_物品归属标签.Text = "Item Ownership Time";
      // 
      // S_ItemOwnershipTime
      // 
      this.S_ItemOwnershipTime.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.S_ItemOwnershipTime.Location = new System.Drawing.Point(189, 409);
      this.S_ItemOwnershipTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.S_ItemOwnershipTime.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.S_ItemOwnershipTime.Name = "S_ItemOwnershipTime";
      this.S_ItemOwnershipTime.Size = new System.Drawing.Size(127, 24);
      this.S_ItemOwnershipTime.TabIndex = 18;
      this.S_ItemOwnershipTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.S_ItemOwnershipTime.ValueChanged += new System.EventHandler(this.更改设置Value_Value);
      // 
      // S_收益衰减标签
      // 
      this.S_收益衰减标签.AutoSize = true;
      this.S_收益衰减标签.Location = new System.Drawing.Point(15, 296);
      this.S_收益衰减标签.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.S_收益衰减标签.Name = "S_收益衰减标签";
      this.S_收益衰减标签.Size = new System.Drawing.Size(148, 15);
      this.S_收益衰减标签.TabIndex = 13;
      this.S_收益衰减标签.Text = "Incoming % exp reduction";
      // 
      // S_物品清理标签
      // 
      this.S_物品清理标签.AutoSize = true;
      this.S_物品清理标签.Location = new System.Drawing.Point(70, 377);
      this.S_物品清理标签.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.S_物品清理标签.Name = "S_物品清理标签";
      this.S_物品清理标签.Size = new System.Drawing.Size(90, 15);
      this.S_物品清理标签.TabIndex = 17;
      this.S_物品清理标签.Text = "Item disappear";
      // 
      // S_ItemCleaningTime
      // 
      this.S_ItemCleaningTime.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.S_ItemCleaningTime.Location = new System.Drawing.Point(189, 373);
      this.S_ItemCleaningTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.S_ItemCleaningTime.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.S_ItemCleaningTime.Name = "S_ItemCleaningTime";
      this.S_ItemCleaningTime.Size = new System.Drawing.Size(127, 24);
      this.S_ItemCleaningTime.TabIndex = 16;
      this.S_ItemCleaningTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.S_ItemCleaningTime.ValueChanged += new System.EventHandler(this.更改设置Value_Value);
      // 
      // S_诱惑时长标签
      // 
      this.S_诱惑时长标签.AutoSize = true;
      this.S_诱惑时长标签.Location = new System.Drawing.Point(70, 335);
      this.S_诱惑时长标签.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.S_诱惑时长标签.Name = "S_诱惑时长标签";
      this.S_诱惑时长标签.Size = new System.Drawing.Size(86, 15);
      this.S_诱惑时长标签.TabIndex = 15;
      this.S_诱惑时长标签.Text = "Wiz Tame Skill";
      // 
      // S_TemptationTime
      // 
      this.S_TemptationTime.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.S_TemptationTime.Location = new System.Drawing.Point(189, 328);
      this.S_TemptationTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.S_TemptationTime.Maximum = new decimal(new int[] {
            1200,
            0,
            0,
            0});
      this.S_TemptationTime.Name = "S_TemptationTime";
      this.S_TemptationTime.Size = new System.Drawing.Size(127, 24);
      this.S_TemptationTime.TabIndex = 14;
      this.S_TemptationTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.S_TemptationTime.ValueChanged += new System.EventHandler(this.更改设置Value_Value);
      // 
      // S_LessExpGradeRate
      // 
      this.S_LessExpGradeRate.DecimalPlaces = 2;
      this.S_LessExpGradeRate.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.S_LessExpGradeRate.Location = new System.Drawing.Point(189, 286);
      this.S_LessExpGradeRate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.S_LessExpGradeRate.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.S_LessExpGradeRate.Name = "S_LessExpGradeRate";
      this.S_LessExpGradeRate.Size = new System.Drawing.Size(127, 24);
      this.S_LessExpGradeRate.TabIndex = 12;
      this.S_LessExpGradeRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.S_LessExpGradeRate.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
      this.S_LessExpGradeRate.ValueChanged += new System.EventHandler(this.更改设置Value_Value);
      // 
      // S_收益等级标签
      // 
      this.S_收益等级标签.AutoSize = true;
      this.S_收益等级标签.Location = new System.Drawing.Point(0, 256);
      this.S_收益等级标签.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.S_收益等级标签.Name = "S_收益等级标签";
      this.S_收益等级标签.Size = new System.Drawing.Size(190, 15);
      this.S_收益等级标签.TabIndex = 11;
      this.S_收益等级标签.Text = "Max Lvl Exp Received From mobs";
      // 
      // S_LessExpGrade
      // 
      this.S_LessExpGrade.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.S_LessExpGrade.Location = new System.Drawing.Point(189, 246);
      this.S_LessExpGrade.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.S_LessExpGrade.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
      this.S_LessExpGrade.Name = "S_LessExpGrade";
      this.S_LessExpGrade.Size = new System.Drawing.Size(127, 24);
      this.S_LessExpGrade.TabIndex = 10;
      this.S_LessExpGrade.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.S_LessExpGrade.ValueChanged += new System.EventHandler(this.更改设置Value_Value);
      // 
      // S_经验倍率标签
      // 
      this.S_经验倍率标签.AutoSize = true;
      this.S_经验倍率标签.Location = new System.Drawing.Point(70, 212);
      this.S_经验倍率标签.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.S_经验倍率标签.Name = "S_经验倍率标签";
      this.S_经验倍率标签.Size = new System.Drawing.Size(56, 15);
      this.S_经验倍率标签.TabIndex = 9;
      this.S_经验倍率标签.Text = "Exp Rate";
      // 
      // S_ExpRate
      // 
      this.S_ExpRate.DecimalPlaces = 2;
      this.S_ExpRate.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.S_ExpRate.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
      this.S_ExpRate.Location = new System.Drawing.Point(189, 202);
      this.S_ExpRate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.S_ExpRate.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
      this.S_ExpRate.Name = "S_ExpRate";
      this.S_ExpRate.Size = new System.Drawing.Size(127, 24);
      this.S_ExpRate.TabIndex = 8;
      this.S_ExpRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.S_ExpRate.ValueChanged += new System.EventHandler(this.更改设置Value_Value);
      // 
      // S_特修折扣标签
      // 
      this.S_特修折扣标签.AutoSize = true;
      this.S_特修折扣标签.Location = new System.Drawing.Point(70, 130);
      this.S_特修折扣标签.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.S_特修折扣标签.Name = "S_特修折扣标签";
      this.S_特修折扣标签.Size = new System.Drawing.Size(94, 15);
      this.S_特修折扣标签.TabIndex = 7;
      this.S_特修折扣标签.Text = "Repair discount";
      // 
      // S_EquipRepairDto
      // 
      this.S_EquipRepairDto.DecimalPlaces = 2;
      this.S_EquipRepairDto.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.S_EquipRepairDto.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
      this.S_EquipRepairDto.Location = new System.Drawing.Point(189, 120);
      this.S_EquipRepairDto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.S_EquipRepairDto.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.S_EquipRepairDto.Name = "S_EquipRepairDto";
      this.S_EquipRepairDto.Size = new System.Drawing.Size(127, 24);
      this.S_EquipRepairDto.TabIndex = 6;
      this.S_EquipRepairDto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.S_EquipRepairDto.ValueChanged += new System.EventHandler(this.更改设置Value_Value);
      // 
      // S_怪物爆率标签
      // 
      this.S_怪物爆率标签.AutoSize = true;
      this.S_怪物爆率标签.Location = new System.Drawing.Point(70, 172);
      this.S_怪物爆率标签.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.S_怪物爆率标签.Name = "S_怪物爆率标签";
      this.S_怪物爆率标签.Size = new System.Drawing.Size(93, 15);
      this.S_怪物爆率标签.TabIndex = 5;
      this.S_怪物爆率标签.Text = "Extra Drop Rate";
      // 
      // S_ExtraDropRate
      // 
      this.S_ExtraDropRate.DecimalPlaces = 2;
      this.S_ExtraDropRate.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.S_ExtraDropRate.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
      this.S_ExtraDropRate.Location = new System.Drawing.Point(189, 162);
      this.S_ExtraDropRate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.S_ExtraDropRate.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.S_ExtraDropRate.Name = "S_ExtraDropRate";
      this.S_ExtraDropRate.Size = new System.Drawing.Size(127, 24);
      this.S_ExtraDropRate.TabIndex = 4;
      this.S_ExtraDropRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.S_ExtraDropRate.ValueChanged += new System.EventHandler(this.更改设置Value_Value);
      // 
      // S_OpenLevelCommand标签
      // 
      this.S_OpenLevelCommand标签.AutoSize = true;
      this.S_OpenLevelCommand标签.Location = new System.Drawing.Point(70, 49);
      this.S_OpenLevelCommand标签.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.S_OpenLevelCommand标签.Name = "S_OpenLevelCommand标签";
      this.S_OpenLevelCommand标签.Size = new System.Drawing.Size(97, 15);
      this.S_OpenLevelCommand标签.TabIndex = 3;
      this.S_OpenLevelCommand标签.Text = "Max Player Level";
      // 
      // S_MaxLevel
      // 
      this.S_MaxLevel.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.S_MaxLevel.Location = new System.Drawing.Point(189, 39);
      this.S_MaxLevel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.S_MaxLevel.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
      this.S_MaxLevel.Name = "S_MaxLevel";
      this.S_MaxLevel.Size = new System.Drawing.Size(127, 24);
      this.S_MaxLevel.TabIndex = 2;
      this.S_MaxLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.S_MaxLevel.ValueChanged += new System.EventHandler(this.更改设置Value_Value);
      // 
      // S_网络设置分组
      // 
      this.S_网络设置分组.Controls.Add(this.S_掉线判定标签);
      this.S_网络设置分组.Controls.Add(this.S_DisconnectTime);
      this.S_网络设置分组.Controls.Add(this.S_限定封包标签);
      this.S_网络设置分组.Controls.Add(this.S_PacketLimit);
      this.S_网络设置分组.Controls.Add(this.L_AbnormalBlockTime);
      this.S_网络设置分组.Controls.Add(this.S_AbnormalBlockTime);
      this.S_网络设置分组.Controls.Add(this.S_接收端口标签);
      this.S_网络设置分组.Controls.Add(this.S_TSPort);
      this.S_网络设置分组.Controls.Add(this.S_监听端口标签);
      this.S_网络设置分组.Controls.Add(this.S_GSPort);
      this.S_网络设置分组.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.S_网络设置分组.Location = new System.Drawing.Point(18, 17);
      this.S_网络设置分组.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.S_网络设置分组.Name = "S_网络设置分组";
      this.S_网络设置分组.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.S_网络设置分组.Size = new System.Drawing.Size(298, 476);
      this.S_网络设置分组.TabIndex = 0;
      this.S_网络设置分组.TabStop = false;
      this.S_网络设置分组.Text = "Network Settings";
      // 
      // S_掉线判定标签
      // 
      this.S_掉线判定标签.AutoSize = true;
      this.S_掉线判定标签.Location = new System.Drawing.Point(32, 209);
      this.S_掉线判定标签.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.S_掉线判定标签.Name = "S_掉线判定标签";
      this.S_掉线判定标签.Size = new System.Drawing.Size(100, 15);
      this.S_掉线判定标签.TabIndex = 9;
      this.S_掉线判定标签.Text = "Disconnect Time";
      // 
      // S_DisconnectTime
      // 
      this.S_DisconnectTime.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.S_DisconnectTime.Location = new System.Drawing.Point(144, 204);
      this.S_DisconnectTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.S_DisconnectTime.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.S_DisconnectTime.Name = "S_DisconnectTime";
      this.S_DisconnectTime.Size = new System.Drawing.Size(127, 24);
      this.S_DisconnectTime.TabIndex = 8;
      this.S_DisconnectTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.S_DisconnectTime.ValueChanged += new System.EventHandler(this.更改设置Value_Value);
      // 
      // S_限定封包标签
      // 
      this.S_限定封包标签.AutoSize = true;
      this.S_限定封包标签.Location = new System.Drawing.Point(32, 127);
      this.S_限定封包标签.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.S_限定封包标签.Name = "S_限定封包标签";
      this.S_限定封包标签.Size = new System.Drawing.Size(70, 15);
      this.S_限定封包标签.TabIndex = 7;
      this.S_限定封包标签.Text = "Packet limit";
      // 
      // S_PacketLimit
      // 
      this.S_PacketLimit.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.S_PacketLimit.Location = new System.Drawing.Point(144, 122);
      this.S_PacketLimit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.S_PacketLimit.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
      this.S_PacketLimit.Name = "S_PacketLimit";
      this.S_PacketLimit.Size = new System.Drawing.Size(127, 24);
      this.S_PacketLimit.TabIndex = 6;
      this.S_PacketLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.S_PacketLimit.ValueChanged += new System.EventHandler(this.更改设置Value_Value);
      // 
      // L_AbnormalBlockTime
      // 
      this.L_AbnormalBlockTime.AutoSize = true;
      this.L_AbnormalBlockTime.Location = new System.Drawing.Point(32, 169);
      this.L_AbnormalBlockTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.L_AbnormalBlockTime.Name = "L_AbnormalBlockTime";
      this.L_AbnormalBlockTime.Size = new System.Drawing.Size(64, 15);
      this.L_AbnormalBlockTime.TabIndex = 5;
      this.L_AbnormalBlockTime.Text = "Block time";
      // 
      // S_AbnormalBlockTime
      // 
      this.S_AbnormalBlockTime.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.S_AbnormalBlockTime.Location = new System.Drawing.Point(144, 162);
      this.S_AbnormalBlockTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.S_AbnormalBlockTime.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
      this.S_AbnormalBlockTime.Name = "S_AbnormalBlockTime";
      this.S_AbnormalBlockTime.Size = new System.Drawing.Size(127, 24);
      this.S_AbnormalBlockTime.TabIndex = 4;
      this.S_AbnormalBlockTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.S_AbnormalBlockTime.ValueChanged += new System.EventHandler(this.更改设置Value_Value);
      // 
      // S_接收端口标签
      // 
      this.S_接收端口标签.AutoSize = true;
      this.S_接收端口标签.Location = new System.Drawing.Point(32, 86);
      this.S_接收端口标签.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.S_接收端口标签.Name = "S_接收端口标签";
      this.S_接收端口标签.Size = new System.Drawing.Size(47, 15);
      this.S_接收端口标签.TabIndex = 3;
      this.S_接收端口标签.Text = "TS Port";
      // 
      // S_TSPort
      // 
      this.S_TSPort.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.S_TSPort.Location = new System.Drawing.Point(144, 80);
      this.S_TSPort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.S_TSPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
      this.S_TSPort.Name = "S_TSPort";
      this.S_TSPort.Size = new System.Drawing.Size(127, 24);
      this.S_TSPort.TabIndex = 2;
      this.S_TSPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.S_TSPort.ValueChanged += new System.EventHandler(this.更改设置Value_Value);
      // 
      // S_监听端口标签
      // 
      this.S_监听端口标签.AutoSize = true;
      this.S_监听端口标签.Location = new System.Drawing.Point(32, 45);
      this.S_监听端口标签.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.S_监听端口标签.Name = "S_监听端口标签";
      this.S_监听端口标签.Size = new System.Drawing.Size(67, 15);
      this.S_监听端口标签.TabIndex = 1;
      this.S_监听端口标签.Text = "Server Port";
      // 
      // S_GSPort
      // 
      this.S_GSPort.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.S_GSPort.Location = new System.Drawing.Point(144, 39);
      this.S_GSPort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.S_GSPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
      this.S_GSPort.Name = "S_GSPort";
      this.S_GSPort.Size = new System.Drawing.Size(127, 24);
      this.S_GSPort.TabIndex = 0;
      this.S_GSPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.S_GSPort.ValueChanged += new System.EventHandler(this.更改设置Value_Value);
      // 
      // 界面定时更新
      // 
      this.界面定时更新.Interval = 2500;
      // 
      // 下方控件页
      // 
      this.下方控件页.BackColor = System.Drawing.Color.Transparent;
      this.下方控件页.Controls.Add(this.保存按钮);
      this.下方控件页.Controls.Add(this.GMCommand文本);
      this.下方控件页.Controls.Add(this.GMCommand标签);
      this.下方控件页.Controls.Add(this.启动按钮);
      this.下方控件页.Controls.Add(this.停止按钮);
      this.下方控件页.Location = new System.Drawing.Point(4, 680);
      this.下方控件页.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.下方控件页.Name = "下方控件页";
      this.下方控件页.Size = new System.Drawing.Size(1397, 85);
      this.下方控件页.TabIndex = 6;
      // 
      // 保存按钮
      // 
      this.保存按钮.BackColor = System.Drawing.Color.LightSteelBlue;
      this.保存按钮.Enabled = false;
      this.保存按钮.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.保存按钮.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
      this.保存按钮.Image = global::GameServer.Properties.Resources.Save_Image;
      this.保存按钮.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.保存按钮.Location = new System.Drawing.Point(918, 9);
      this.保存按钮.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.保存按钮.Name = "保存按钮";
      this.保存按钮.Size = new System.Drawing.Size(153, 54);
      this.保存按钮.TabIndex = 17;
      this.保存按钮.Text = "Save Data";
      this.保存按钮.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.保存按钮.UseVisualStyleBackColor = false;
      this.保存按钮.Click += new System.EventHandler(this.保存数据库_Click);
      // 
      // GMCommand文本
      // 
      this.GMCommand文本.BackColor = System.Drawing.SystemColors.InactiveCaption;
      this.GMCommand文本.Location = new System.Drawing.Point(95, 23);
      this.GMCommand文本.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.GMCommand文本.Name = "GMCommand文本";
      this.GMCommand文本.Size = new System.Drawing.Size(815, 23);
      this.GMCommand文本.TabIndex = 16;
      this.GMCommand文本.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.执行GMCommand行_Press);
      // 
      // GMCommand标签
      // 
      this.GMCommand标签.AutoSize = true;
      this.GMCommand标签.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.GMCommand标签.Location = new System.Drawing.Point(21, 29);
      this.GMCommand标签.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.GMCommand标签.Name = "GMCommand标签";
      this.GMCommand标签.Size = new System.Drawing.Size(66, 16);
      this.GMCommand标签.TabIndex = 13;
      this.GMCommand标签.Text = "GM Box:";
      this.GMCommand标签.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
      // 
      // 启动按钮
      // 
      this.启动按钮.BackColor = System.Drawing.Color.LightSteelBlue;
      this.启动按钮.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
      this.启动按钮.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.启动按钮.ForeColor = System.Drawing.Color.Green;
      this.启动按钮.Image = global::GameServer.Properties.Resources.Start_Image;
      this.启动按钮.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.启动按钮.Location = new System.Drawing.Point(1078, 9);
      this.启动按钮.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.启动按钮.Name = "启动按钮";
      this.启动按钮.Size = new System.Drawing.Size(153, 54);
      this.启动按钮.TabIndex = 12;
      this.启动按钮.Text = "Start";
      this.启动按钮.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.启动按钮.UseVisualStyleBackColor = false;
      this.启动按钮.Click += new System.EventHandler(this.启动服务器_Click);
      // 
      // 停止按钮
      // 
      this.停止按钮.BackColor = System.Drawing.Color.LightSteelBlue;
      this.停止按钮.Enabled = false;
      this.停止按钮.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.停止按钮.ForeColor = System.Drawing.Color.Brown;
      this.停止按钮.Image = global::GameServer.Properties.Resources.Stop_Image;
      this.停止按钮.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.停止按钮.Location = new System.Drawing.Point(1238, 9);
      this.停止按钮.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.停止按钮.Name = "停止按钮";
      this.停止按钮.Size = new System.Drawing.Size(153, 54);
      this.停止按钮.TabIndex = 11;
      this.停止按钮.Text = "Stop";
      this.停止按钮.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.停止按钮.UseVisualStyleBackColor = false;
      this.停止按钮.Click += new System.EventHandler(this.停止服务器_Click);
      // 
      // 保存数据提醒
      // 
      this.保存数据提醒.Enabled = true;
      this.保存数据提醒.Interval = 500;
      this.保存数据提醒.Tick += new System.EventHandler(this.保存数据提醒_Tick);
      // 
      // 定时发送公告
      // 
      this.定时发送公告.Tick += new System.EventHandler(this.定时发送公告_Tick);
      // 
      // 重载数据
      // 
      this.重载数据.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
      this.重载数据.Enabled = false;
      this.重载数据.Location = new System.Drawing.Point(1068, 411);
      this.重载数据.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.重载数据.Name = "重载数据";
      this.重载数据.Size = new System.Drawing.Size(301, 57);
      this.重载数据.TabIndex = 15;
      this.重载数据.Text = "Reload Data";
      this.重载数据.UseVisualStyleBackColor = false;
      this.重载数据.Click += new System.EventHandler(this.重载数据_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1397, 749);
      this.Controls.Add(this.下方控件页);
      this.Controls.Add(this.主选项卡);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.MaximizeBox = false;
      this.Name = "MainForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "GameServer - Mir3D LOMCN";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.关闭主界面_Click);
      this.Load += new System.EventHandler(this.MainForm_Load);
      this.主选项卡.ResumeLayout(false);
      this.tabMain.ResumeLayout(false);
      this.tabMain.PerformLayout();
      this.MainTabs.ResumeLayout(false);
      this.tabSystem.ResumeLayout(false);
      this.tabChat.ResumeLayout(false);
      this.tabCommands.ResumeLayout(false);
      this.tabPackets.ResumeLayout(false);
      this.tabCharacters.ResumeLayout(false);
      this.角色详情选项卡.ResumeLayout(false);
      this.CharacterData_技能.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.技能浏览表)).EndInit();
      this.CharacterData_装备.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.装备浏览表)).EndInit();
      this.CharacterData_背包.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.背包浏览表)).EndInit();
      this.CharacterData_仓库.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.仓库浏览表)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dgvCharacters)).EndInit();
      this.角色右键菜单.ResumeLayout(false);
      this.tabMaps.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgvMaps)).EndInit();
      this.tabMonsters.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.掉落浏览表)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.怪物浏览表)).EndInit();
      this.tabBans.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.封禁浏览表)).EndInit();
      this.tabAnnouncements.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.公告浏览表)).EndInit();
      this.tabConfig.ResumeLayout(false);
      this.S_软件授权分组.ResumeLayout(false);
      this.S_软件授权分组.PerformLayout();
      this.S_GameData分组.ResumeLayout(false);
      this.S_GameData分组.PerformLayout();
      this.S_游戏设置分组.ResumeLayout(false);
      this.S_游戏设置分组.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.S_NoobLevel)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.S_ItemOwnershipTime)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.S_ItemCleaningTime)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.S_TemptationTime)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.S_LessExpGradeRate)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.S_LessExpGrade)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.S_ExpRate)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.S_EquipRepairDto)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.S_ExtraDropRate)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.S_MaxLevel)).EndInit();
      this.S_网络设置分组.ResumeLayout(false);
      this.S_网络设置分组.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.S_DisconnectTime)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.S_PacketLimit)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.S_AbnormalBlockTime)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.S_TSPort)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.S_GSPort)).EndInit();
      this.下方控件页.ResumeLayout(false);
      this.下方控件页.PerformLayout();
      this.ResumeLayout(false);

    }


    private global::System.ComponentModel.IContainer components;


    private global::System.Windows.Forms.RichTextBox 系统日志;


    private global::System.Windows.Forms.Label 帧数统计;


    private global::System.Windows.Forms.Button 保存系统日志;


    private global::System.Windows.Forms.Button 清空系统日志;


    private global::System.Windows.Forms.Label 发送统计;


    private global::System.Windows.Forms.Label 接收统计;


    private global::System.Windows.Forms.Label 已经上线统计;


    private global::System.Windows.Forms.Label 连接总数统计;


    private global::System.Windows.Forms.Label 已经登录统计;


    private global::System.Windows.Forms.Button 保存聊天日志;


    private global::System.Windows.Forms.Button 清空聊天日志;


    private global::System.Windows.Forms.TabControl 角色详情选项卡;


    private global::System.Windows.Forms.TabPage CharacterData_技能;


    private global::System.Windows.Forms.TabPage CharacterData_装备;


    private global::System.Windows.Forms.TabPage CharacterData_背包;


    private global::System.Windows.Forms.TabPage CharacterData_仓库;


    public global::System.Windows.Forms.TabControl 主选项卡;


    public global::System.Windows.Forms.DataGridView dgvCharacters;


    public global::System.Windows.Forms.DataGridView 技能浏览表;


    private global::System.Windows.Forms.DataGridView 装备浏览表;


    public global::System.Windows.Forms.DataGridView 背包浏览表;


    public global::System.Windows.Forms.DataGridView 仓库浏览表;


    private global::System.Windows.Forms.Timer 界面定时更新;


    private global::System.Windows.Forms.TabPage tabSystem;


    private global::System.Windows.Forms.TabPage tabChat;


    private global::System.Windows.Forms.RichTextBox 聊天日志;


    public global::System.Windows.Forms.DataGridView dgvMaps;


    public global::System.Windows.Forms.DataGridView 怪物浏览表;


    private global::System.Windows.Forms.DataGridView 掉落浏览表;


    private global::System.Windows.Forms.GroupBox S_网络设置分组;


    private global::System.Windows.Forms.Label S_监听端口标签;


    private global::System.Windows.Forms.NumericUpDown S_GSPort;


    private global::System.Windows.Forms.Label S_接收端口标签;


    private global::System.Windows.Forms.NumericUpDown S_TSPort;


    private global::System.Windows.Forms.Label L_AbnormalBlockTime;


    private global::System.Windows.Forms.NumericUpDown S_AbnormalBlockTime;


    private global::System.Windows.Forms.GroupBox S_游戏设置分组;


    private global::System.Windows.Forms.Label S_特修折扣标签;


    private global::System.Windows.Forms.NumericUpDown S_EquipRepairDto;


    private global::System.Windows.Forms.Label S_怪物爆率标签;


    private global::System.Windows.Forms.Label S_OpenLevelCommand标签;


    private global::System.Windows.Forms.Label S_限定封包标签;


    private global::System.Windows.Forms.NumericUpDown S_PacketLimit;


    private global::System.Windows.Forms.Label S_掉线判定标签;


    private global::System.Windows.Forms.NumericUpDown S_DisconnectTime;


    private global::System.Windows.Forms.Label S_经验倍率标签;


    private global::System.Windows.Forms.Label S_收益等级标签;


    private global::System.Windows.Forms.NumericUpDown S_LessExpGrade;


    private global::System.Windows.Forms.Label S_收益衰减标签;


    private global::System.Windows.Forms.NumericUpDown S_LessExpGradeRate;


    private global::System.Windows.Forms.Label S_诱惑时长标签;


    private global::System.Windows.Forms.NumericUpDown S_TemptationTime;


    private global::System.Windows.Forms.Label S_物品归属标签;


    private global::System.Windows.Forms.NumericUpDown S_ItemOwnershipTime;


    private global::System.Windows.Forms.Label S_物品清理标签;


    private global::System.Windows.Forms.NumericUpDown S_ItemCleaningTime;


    private global::System.Windows.Forms.GroupBox S_GameData分组;


    private global::System.Windows.Forms.TextBox S_数据备份目录;


    private global::System.Windows.Forms.TextBox S_GameData目录;


    private global::System.Windows.Forms.Label S_备份目录标签;


    private global::System.Windows.Forms.Label S_数据目录标签;


    private global::System.Windows.Forms.Button S_合并客户数据;


    private global::System.Windows.Forms.TextBox S_合并数据目录;


    private global::System.Windows.Forms.Label S_合并目录标签;


    private global::System.Windows.Forms.Button S_浏览数据目录;


    private global::System.Windows.Forms.Button S_浏览合并目录;


    private global::System.Windows.Forms.Button S_浏览备份目录;


    private global::System.Windows.Forms.Button S_重载SystemData;


    private global::System.Windows.Forms.TextBox GMCommand文本;


    private global::System.Windows.Forms.Label GMCommand标签;


    public global::System.Windows.Forms.Button 启动按钮;


    public global::System.Windows.Forms.Button 停止按钮;


    private global::System.Windows.Forms.Button S_重载客户数据;


    public global::System.Windows.Forms.Button 保存按钮;


    private global::System.Windows.Forms.Label 对象统计;


    private global::System.Windows.Forms.Label S_注意事项标签2;


    private global::System.Windows.Forms.Label S_注意事项标签1;


    private global::System.Windows.Forms.Label S_注意事项标签5;


    private global::System.Windows.Forms.Label S_注意事项标签4;


    private global::System.Windows.Forms.Label S_注意事项标签3;


    private global::System.Windows.Forms.Label S_注意事项标签6;


    private global::System.Windows.Forms.Label S_注意事项标签8;


    private global::System.Windows.Forms.Label S_注意事项标签7;


    private global::System.Windows.Forms.TabPage tabCommands;


    private global::System.Windows.Forms.RichTextBox 命令日志;


    private global::System.Windows.Forms.Button 清空命令日志;


    private global::System.Windows.Forms.Timer 保存数据提醒;


    public global::System.Windows.Forms.TabPage tabConfig;


    public global::System.Windows.Forms.Panel 下方控件页;


    private global::System.Windows.Forms.ContextMenuStrip 角色右键菜单;


    private global::System.Windows.Forms.ToolStripMenuItem 右键菜单_复制CharName;


    private global::System.Windows.Forms.ToolStripMenuItem 右键菜单_复制Account;


    private global::System.Windows.Forms.ToolStripMenuItem 右键菜单_复制网络地址;


    private global::System.Windows.Forms.ToolStripMenuItem 右键菜单_复制物理地址;


    public global::System.Windows.Forms.TabPage tabBans;


    private global::System.Windows.Forms.TabPage tabAnnouncements;


    public global::System.Windows.Forms.TabPage tabMain;


    public global::System.Windows.Forms.TabPage tabMaps;


    public global::System.Windows.Forms.TabPage tabMonsters;


    public global::System.Windows.Forms.TabPage tabCharacters;


    private global::System.Windows.Forms.DataGridView 封禁浏览表;


    public global::System.Windows.Forms.NumericUpDown S_ExtraDropRate;


    public global::System.Windows.Forms.NumericUpDown S_ExpRate;


    public global::System.Windows.Forms.NumericUpDown S_MaxLevel;


    private global::System.Windows.Forms.Button 删除公告按钮;


    private global::System.Windows.Forms.Button 添加公告按钮;


    public global::System.Windows.Forms.Timer 定时发送公告;


    public global::System.Windows.Forms.DataGridView 公告浏览表;


    public global::System.Windows.Forms.Button 开始公告按钮;


    public global::System.Windows.Forms.Button 停止公告按钮;








    private global::System.Windows.Forms.Label L_NoobLevel;


    public global::System.Windows.Forms.NumericUpDown S_NoobLevel;


    public global::System.Windows.Forms.TabControl MainTabs;


    private global::System.Windows.Forms.GroupBox S_软件授权分组;


    private global::System.Windows.Forms.TextBox S_软件注册代码;
    private System.Windows.Forms.TabPage tabPackets;
    private System.Windows.Forms.RichTextBox rtbPacketsLogs;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.DataGridViewTextBoxColumn Status;
    private System.Windows.Forms.DataGridViewTextBoxColumn Interval;
    private System.Windows.Forms.DataGridViewTextBoxColumn Count;
    private System.Windows.Forms.DataGridViewTextBoxColumn RemainingTime;
    private System.Windows.Forms.DataGridViewTextBoxColumn Time;
    private System.Windows.Forms.DataGridViewTextBoxColumn Content;
    private System.Windows.Forms.Button 重载数据;
  }
}
