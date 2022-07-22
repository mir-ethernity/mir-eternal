using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameServer.Properties;
using GameServer.Maps;
using GameServer.Data;
using GameServer.Templates;
using GameServer.Networking;

namespace GameServer
{
    // Token: 0x02000024 RID: 36
    public partial class MainForm : Form
    {
        // Token: 0x06000088 RID: 136 RVA: 0x00011F20 File Offset: 0x00010120
        public static void LoadSystemData()
        {
            MainForm MainForm = MainForm.Singleton;
            MainForm.AddSystemLog("正在加载SystemData...");
            MainForm.MapsDataTable = new DataTable("地图数据表");
            MainForm.MapsDataRow = new Dictionary<游戏地图, DataRow>();
            MainForm.MapsDataTable.Columns.Add("地图编号", typeof(string));
            MainForm.MapsDataTable.Columns.Add("地图名字", typeof(string));
            MainForm.MapsDataTable.Columns.Add("限制等级", typeof(string));
            MainForm.MapsDataTable.Columns.Add("玩家数量", typeof(string));
            MainForm.MapsDataTable.Columns.Add("固定怪物总数", typeof(uint));
            MainForm.MapsDataTable.Columns.Add("存活怪物总数", typeof(uint));
            MainForm.MapsDataTable.Columns.Add("怪物复活次数", typeof(uint));
            MainForm.MapsDataTable.Columns.Add("怪物掉落次数", typeof(long));
            MainForm.MapsDataTable.Columns.Add("金币掉落总数", typeof(long));

            if (MainForm != null)
            {
                MainForm.dgvMaps.BeginInvoke(new MethodInvoker(delegate ()
                {
                    MainForm.Singleton.dgvMaps.DataSource = MainForm.MapsDataTable;
                }));
            }
            MainForm.怪物DataSheet = new DataTable("怪物数据表");
            MainForm.怪物数据行 = new Dictionary<游戏怪物, DataRow>();
            MainForm.数据行怪物 = new Dictionary<DataRow, 游戏怪物>();
            MainForm.怪物DataSheet.Columns.Add("模板编号", typeof(string));
            MainForm.怪物DataSheet.Columns.Add("怪物名字", typeof(string));
            MainForm.怪物DataSheet.Columns.Add("怪物等级", typeof(string));
            MainForm.怪物DataSheet.Columns.Add("怪物经验", typeof(string));
            MainForm.怪物DataSheet.Columns.Add("怪物级别", typeof(string));
            MainForm.怪物DataSheet.Columns.Add("移动间隔", typeof(string));
            MainForm.怪物DataSheet.Columns.Add("漫游间隔", typeof(string));
            MainForm.怪物DataSheet.Columns.Add("仇恨范围", typeof(string));
            MainForm.怪物DataSheet.Columns.Add("仇恨时长", typeof(string));
            MainForm MainForm2 = MainForm.Singleton;
            if (MainForm2 != null)
            {
                MainForm2.怪物浏览表.BeginInvoke(new MethodInvoker(delegate ()
                {
                    MainForm.Singleton.怪物浏览表.DataSource = MainForm.怪物DataSheet;
                }));
            }
            MainForm.掉落DataSheet = new DataTable("掉落数据表");
            MainForm.怪物掉落表 = new Dictionary<游戏怪物, List<KeyValuePair<游戏物品, long>>>();
            MainForm.掉落DataSheet.Columns.Add("物品名字", typeof(string));
            MainForm.掉落DataSheet.Columns.Add("掉落数量", typeof(string));
            MainForm MainForm3 = MainForm.Singleton;
            if (MainForm3 != null)
            {
                MainForm3.掉落浏览表.BeginInvoke(new MethodInvoker(delegate ()
                {
                    MainForm.Singleton.掉落浏览表.DataSource = MainForm.掉落DataSheet;
                }));
            }
            SystemDataService.LoadData();
            MainForm.AddSystemLog("SystemData加载完成");
        }

        // Token: 0x06000089 RID: 137 RVA: 0x000122A8 File Offset: 0x000104A8
        public static void LoadUserData()
        {
            MainForm MainForm = MainForm.Singleton;
            MainForm.AddSystemLog("正在加载客户数据...");
            MainForm.CharacterDataTable = new DataTable("CharacterDataTable");
            MainForm.SkillData表 = new DataTable("SkillData表");
            MainForm.EquipmentData表 = new DataTable("EquipmentData表");
            MainForm.背包DataSheet = new DataTable("EquipmentData表");
            MainForm.仓库DataSheet = new DataTable("EquipmentData表");
            MainForm.CharacterData行 = new Dictionary<CharacterData, DataRow>();
            MainForm.数据行角色 = new Dictionary<DataRow, CharacterData>();

            MainForm.CharacterDataTable.Columns.Add("角色名字", typeof(string));
            MainForm.CharacterDataTable.Columns.Add("角色封禁", typeof(string));
            MainForm.CharacterDataTable.Columns.Add("所属账号", typeof(string));
            MainForm.CharacterDataTable.Columns.Add("账号封禁", typeof(string));
            MainForm.CharacterDataTable.Columns.Add("冻结日期", typeof(string));
            MainForm.CharacterDataTable.Columns.Add("删除日期", typeof(string));
            MainForm.CharacterDataTable.Columns.Add("登录日期", typeof(string));
            MainForm.CharacterDataTable.Columns.Add("离线日期", typeof(string));
            MainForm.CharacterDataTable.Columns.Add("网络地址", typeof(string));
            MainForm.CharacterDataTable.Columns.Add("物理地址", typeof(string));
            MainForm.CharacterDataTable.Columns.Add("角色职业", typeof(string));
            MainForm.CharacterDataTable.Columns.Add("角色性别", typeof(string));
            MainForm.CharacterDataTable.Columns.Add("所属行会", typeof(string));
            MainForm.CharacterDataTable.Columns.Add("元宝数量", typeof(string));
            MainForm.CharacterDataTable.Columns.Add("消耗元宝", typeof(string));
            MainForm.CharacterDataTable.Columns.Add("金币数量", typeof(string));
            MainForm.CharacterDataTable.Columns.Add("转出金币", typeof(string));
            MainForm.CharacterDataTable.Columns.Add("背包大小", typeof(string));
            MainForm.CharacterDataTable.Columns.Add("仓库大小", typeof(string));
            MainForm.CharacterDataTable.Columns.Add("师门声望", typeof(string));
            MainForm.CharacterDataTable.Columns.Add("本期特权", typeof(string));
            MainForm.CharacterDataTable.Columns.Add("本期日期", typeof(string));
            MainForm.CharacterDataTable.Columns.Add("上期特权", typeof(string));
            MainForm.CharacterDataTable.Columns.Add("上期日期", typeof(string));
            MainForm.CharacterDataTable.Columns.Add("剩余特权", typeof(string));
            MainForm.CharacterDataTable.Columns.Add("当前等级", typeof(string));
            MainForm.CharacterDataTable.Columns.Add("当前经验", typeof(string));
            MainForm.CharacterDataTable.Columns.Add("双倍经验", typeof(string));
            MainForm.CharacterDataTable.Columns.Add("当前战力", typeof(string));
            MainForm.CharacterDataTable.Columns.Add("当前地图", typeof(string));
            MainForm.CharacterDataTable.Columns.Add("当前坐标", typeof(string));
            MainForm.CharacterDataTable.Columns.Add("当前PK值", typeof(string));

            if (MainForm != null)
            {
                MainForm.BeginInvoke(new MethodInvoker(delegate ()
                {
                    MainForm.Singleton.dgvCharacters.DataSource = MainForm.CharacterDataTable;
                    for (int i = 0; i < MainForm.Singleton.dgvCharacters.Columns.Count; i++)
                    {
                        MainForm.Singleton.dgvCharacters.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                }));
            }
            MainForm.角色技能表 = new Dictionary<CharacterData, List<KeyValuePair<ushort, SkillData>>>();
            MainForm.SkillData表.Columns.Add("技能名字", typeof(string));
            MainForm.SkillData表.Columns.Add("技能编号", typeof(string));
            MainForm.SkillData表.Columns.Add("当前等级", typeof(string));
            MainForm.SkillData表.Columns.Add("当前经验", typeof(string));
            MainForm MainForm2 = MainForm.Singleton;
            if (MainForm2 != null)
            {
                MainForm2.BeginInvoke(new MethodInvoker(delegate ()
                {
                    MainForm.Singleton.技能浏览表.DataSource = MainForm.SkillData表;
                }));
            }
            MainForm.角色装备表 = new Dictionary<CharacterData, List<KeyValuePair<byte, EquipmentData>>>();
            MainForm.EquipmentData表.Columns.Add("穿戴部位", typeof(string));
            MainForm.EquipmentData表.Columns.Add("穿戴装备", typeof(string));
            MainForm MainForm3 = MainForm.Singleton;
            if (MainForm3 != null)
            {
                MainForm3.BeginInvoke(new MethodInvoker(delegate ()
                {
                    MainForm.Singleton.装备浏览表.DataSource = MainForm.EquipmentData表;
                }));
            }
            MainForm.角色背包表 = new Dictionary<CharacterData, List<KeyValuePair<byte, ItemData>>>();
            MainForm.背包DataSheet.Columns.Add("背包位置", typeof(string));
            MainForm.背包DataSheet.Columns.Add("背包物品", typeof(string));
            MainForm MainForm4 = MainForm.Singleton;
            if (MainForm4 != null)
            {
                MainForm4.BeginInvoke(new MethodInvoker(delegate ()
                {
                    MainForm.Singleton.背包浏览表.DataSource = MainForm.背包DataSheet;
                }));
            }
            MainForm.角色仓库表 = new Dictionary<CharacterData, List<KeyValuePair<byte, ItemData>>>();
            MainForm.仓库DataSheet.Columns.Add("仓库位置", typeof(string));
            MainForm.仓库DataSheet.Columns.Add("仓库物品", typeof(string));
            MainForm MainForm5 = MainForm.Singleton;
            if (MainForm5 != null)
            {
                MainForm5.BeginInvoke(new MethodInvoker(delegate ()
                {
                    MainForm.Singleton.仓库浏览表.DataSource = MainForm.仓库DataSheet;
                }));
            }
            MainForm.封禁DataSheet = new DataTable();
            MainForm.封禁数据行 = new Dictionary<string, DataRow>();
            MainForm.封禁DataSheet.Columns.Add("网络地址", typeof(string));
            MainForm.封禁DataSheet.Columns.Add("物理地址", typeof(string));
            MainForm.封禁DataSheet.Columns.Add("到期时间", typeof(string));
            MainForm MainForm6 = MainForm.Singleton;
            if (MainForm6 != null)
            {
                MainForm6.BeginInvoke(new MethodInvoker(delegate ()
                {
                    MainForm.Singleton.封禁浏览表.DataSource = MainForm.封禁DataSheet;
                }));
            }
            GameDataGateway.加载数据();
            MainForm.AddSystemLog("客户数据加载完成");
        }

        // Token: 0x0600008A RID: 138 RVA: 0x00002B15 File Offset: 0x00000D15
        public static void 服务启动回调()
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                MainForm.Singleton.定时发送公告.Enabled = true;
                MainForm.Singleton.保存按钮.BackColor = Color.LightSteelBlue;
                Control control = MainForm.Singleton.停止按钮;
                MainForm.Singleton.界面定时更新.Enabled = true;
                control.Enabled = true;
                Control control2 = MainForm.Singleton.启动按钮;
                Control control3 = MainForm.Singleton.保存按钮;
                MainForm.Singleton.tabConfig.Enabled = false;
                control3.Enabled = false;
                control2.Enabled = false;
            }));
        }

        // Token: 0x0600008B RID: 139 RVA: 0x00002B46 File Offset: 0x00000D46
        public static void 服务停止回调()
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                MainForm.Singleton.定时发送公告.Enabled = true;
                Control control = MainForm.Singleton.启动按钮;
                MainForm.Singleton.tabConfig.Enabled = true;
                control.Enabled = true;
                Control control2 = MainForm.Singleton.停止按钮;
                MainForm.Singleton.界面定时更新.Enabled = false;
                control2.Enabled = false;
                foreach (KeyValuePair<DataGridViewRow, DateTime> keyValuePair in MainForm.公告DataSheet)
                {
                    keyValuePair.Key.ReadOnly = false;
                    keyValuePair.Key.Cells["公告状态"].Value = "";
                    keyValuePair.Key.Cells["公告计时"].Value = "";
                    keyValuePair.Key.Cells["剩余次数"].Value = 0;
                }
                if (MainForm.Singleton.公告浏览表.SelectedRows.Count != 0)
                {
                    MainForm.Singleton.开始公告按钮.Enabled = true;
                    MainForm.Singleton.停止公告按钮.Enabled = false;
                }
                MainForm.公告DataSheet.Clear();
            }));
        }

        // Token: 0x0600008C RID: 140 RVA: 0x00012A0C File Offset: 0x00010C0C
        public static void AddSystemLog(string 内容)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                MainForm.Singleton.系统日志.AppendText(string.Format("[{0}]: {1}", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), 内容) + "\r\n");
                MainForm.Singleton.系统日志.ScrollToCaret();
                Control control = MainForm.Singleton.清空系统日志;
                MainForm.Singleton.保存系统日志.Enabled = true;
                control.Enabled = true;
            }));
        }

        // Token: 0x0600008D RID: 141 RVA: 0x00012A44 File Offset: 0x00010C44
        public static void 添加聊天日志(string 前缀, byte[] 内容)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                MainForm.Singleton.聊天日志.AppendText(string.Format("[{0:F}]: {1}", DateTime.Now, 前缀 + Encoding.UTF8.GetString(内容).Trim(new char[1])) + "\r\n");
                MainForm.Singleton.聊天日志.ScrollToCaret();
                Control control = MainForm.Singleton.清空聊天日志;
                MainForm.Singleton.保存聊天日志.Enabled = true;
                control.Enabled = true;
            }));
        }

        // Token: 0x0600008E RID: 142 RVA: 0x00012A84 File Offset: 0x00010C84
        public static void 添加命令日志(string 内容)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                MainForm.Singleton.命令日志.AppendText(string.Format("[{0:F}]: {1}", DateTime.Now, 内容) + "\r\n");
                MainForm.Singleton.命令日志.ScrollToCaret();
                MainForm.Singleton.清空命令日志.Enabled = true;
            }));
        }

        // Token: 0x0600008F RID: 143 RVA: 0x00012ABC File Offset: 0x00010CBC
        public static void 更新连接总数(uint 内容)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                MainForm.Singleton.连接总数统计.Text = string.Format("连接总数: {0}", 内容);
            }));
        }

        // Token: 0x06000090 RID: 144 RVA: 0x00012AF4 File Offset: 0x00010CF4
        public static void 更新已经登录(uint 内容)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                MainForm.Singleton.已经登录统计.Text = string.Format("已经登录: {0}", 内容);
            }));
        }

        // Token: 0x06000091 RID: 145 RVA: 0x00012B2C File Offset: 0x00010D2C
        public static void 更新已经上线(uint 内容)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                MainForm.Singleton.已经上线统计.Text = string.Format("已经上线: {0}", 内容);
            }));
        }

        // Token: 0x06000092 RID: 146 RVA: 0x00012B64 File Offset: 0x00010D64
        public static void 更新后台帧数(uint 内容)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                MainForm.Singleton.帧数统计.Text = string.Format("后台帧数: {0}", 内容);
            }));
        }

        // Token: 0x06000093 RID: 147 RVA: 0x00012B9C File Offset: 0x00010D9C
        public static void 更新接收字节(long 内容)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                MainForm.Singleton.接收统计.Text = string.Format("已经接收: {0}", 内容);
            }));
        }

        // Token: 0x06000094 RID: 148 RVA: 0x00012BD4 File Offset: 0x00010DD4
        public static void 更新发送字节(long 内容)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                MainForm.Singleton.发送统计.Text = string.Format("已经发送: {0}", 内容);
            }));
        }

        // Token: 0x06000095 RID: 149 RVA: 0x00012C0C File Offset: 0x00010E0C
        public static void 更新对象统计(int 激活对象, int 次要对象, int 对象总数)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                MainForm.Singleton.对象统计.Text = string.Format("对象统计: {0} / {1} / {2}", 激活对象, 次要对象, 对象总数);
            }));
        }

        // Token: 0x06000096 RID: 150 RVA: 0x00002B77 File Offset: 0x00000D77
        public static void 添加数据显示(CharacterData 数据)
        {
            if (!MainForm.CharacterData行.ContainsKey(数据))
            {
                MainForm.CharacterData行[数据] = MainForm.CharacterDataTable.NewRow();
                MainForm.CharacterDataTable.Rows.Add(MainForm.CharacterData行[数据]);
            }
        }

        // Token: 0x06000097 RID: 151 RVA: 0x00002BB5 File Offset: 0x00000DB5
        public static void 修改数据显示(CharacterData 数据, string 表头文本, string 表格内容)
        {
            if (MainForm.CharacterData行.ContainsKey(数据))
            {
                MainForm.CharacterData行[数据][表头文本] = 表格内容;
            }
        }

        // Token: 0x06000098 RID: 152 RVA: 0x00012C50 File Offset: 0x00010E50
        public static void AddCharacterData(CharacterData 角色)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                if (!MainForm.CharacterData行.ContainsKey(角色))
                {
                    DataRow dataRow = MainForm.CharacterDataTable.NewRow();
                    dataRow["角色名字"] = 角色;
                    dataRow["所属账号"] = 角色.所属账号;
                    dataRow["账号封禁"] = ((角色.所属账号.V.封禁日期.V != default(DateTime)) ? 角色.所属账号.V.封禁日期 : null);
                    dataRow["角色封禁"] = ((角色.封禁日期.V != default(DateTime)) ? 角色.封禁日期 : null);
                    dataRow["冻结日期"] = ((角色.冻结日期.V != default(DateTime)) ? 角色.冻结日期 : null);
                    dataRow["删除日期"] = ((角色.删除日期.V != default(DateTime)) ? 角色.删除日期 : null);
                    dataRow["登录日期"] = ((角色.登录日期.V != default(DateTime)) ? 角色.登录日期 : null);
                    dataRow["离线日期"] = ((角色.网络连接 == null) ? 角色.离线日期 : null);
                    dataRow["网络地址"] = 角色.网络地址;
                    dataRow["物理地址"] = 角色.物理地址;
                    dataRow["角色职业"] = 角色.角色职业;
                    dataRow["角色性别"] = 角色.角色性别;
                    dataRow["所属行会"] = 角色.所属行会;
                    dataRow["元宝数量"] = 角色.元宝数量;
                    dataRow["消耗元宝"] = 角色.消耗元宝;
                    dataRow["金币数量"] = 角色.金币数量;
                    dataRow["转出金币"] = 角色.转出金币;
                    dataRow["背包大小"] = 角色.背包大小;
                    dataRow["仓库大小"] = 角色.仓库大小;
                    dataRow["师门声望"] = 角色.师门声望;
                    dataRow["本期特权"] = 角色.本期特权;
                    dataRow["本期日期"] = 角色.本期日期;
                    dataRow["上期特权"] = 角色.上期特权;
                    dataRow["上期日期"] = 角色.上期日期;
                    dataRow["剩余特权"] = 角色.剩余特权;
                    dataRow["当前等级"] = 角色.当前等级;
                    dataRow["当前经验"] = 角色.当前经验;
                    dataRow["双倍经验"] = 角色.双倍经验;
                    dataRow["当前战力"] = 角色.当前战力;
                    游戏地图 游戏地图;
                    dataRow["当前地图"] = (游戏地图.DataSheet.TryGetValue((byte)角色.当前地图.V, out 游戏地图) ? 游戏地图.地图名字 : 角色.当前地图);
                    dataRow["当前PK值"] = 角色.当前PK值;
                    dataRow["当前坐标"] = string.Format("{0}, {1}", 角色.当前坐标.V.X, 角色.当前坐标.V.Y);
                    MainForm.CharacterData行[角色] = dataRow;
                    MainForm.数据行角色[dataRow] = 角色;
                    MainForm.CharacterDataTable.Rows.Add(dataRow);
                }
            }));
        }

        // Token: 0x06000099 RID: 153 RVA: 0x00012C88 File Offset: 0x00010E88
        public static void RemoveCharacter(CharacterData character)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                DataRow dataRow;
                if (MainForm.CharacterData行.TryGetValue(character, out dataRow))
                {
                    MainForm.数据行角色.Remove(dataRow);
                    MainForm.CharacterDataTable.Rows.Remove(dataRow);
                    MainForm.角色技能表.Remove(character);
                    MainForm.角色背包表.Remove(character);
                    MainForm.角色装备表.Remove(character);
                    MainForm.角色仓库表.Remove(character);
                }
            }));
        }

        // Token: 0x0600009A RID: 154 RVA: 0x00012CC0 File Offset: 0x00010EC0
        public static void 界面更新处理(object sender, EventArgs e)
        {
            MainForm.SkillData表.Rows.Clear();
            MainForm.EquipmentData表.Rows.Clear();
            MainForm.背包DataSheet.Rows.Clear();
            MainForm.仓库DataSheet.Rows.Clear();
            MainForm.掉落DataSheet.Rows.Clear();
            if (MainForm.Singleton == null)
            {
                return;
            }
            if (MainForm.Singleton.dgvCharacters.Rows.Count > 0 && MainForm.Singleton.dgvCharacters.SelectedRows.Count > 0)
            {
                DataRow row = (MainForm.Singleton.dgvCharacters.Rows[MainForm.Singleton.dgvCharacters.SelectedRows[0].Index].DataBoundItem as DataRowView).Row;
                CharacterData key;
                if (MainForm.数据行角色.TryGetValue(row, out key))
                {
                    List<KeyValuePair<ushort, SkillData>> list;
                    if (MainForm.角色技能表.TryGetValue(key, out list))
                    {
                        foreach (KeyValuePair<ushort, SkillData> keyValuePair in list)
                        {
                            DataRow dataRow = MainForm.SkillData表.NewRow();
                            dataRow["技能名字"] = keyValuePair.Value.铭文模板.技能名字;
                            dataRow["技能编号"] = keyValuePair.Value.技能编号;
                            dataRow["当前等级"] = keyValuePair.Value.技能等级;
                            dataRow["当前经验"] = keyValuePair.Value.技能经验;
                            MainForm.SkillData表.Rows.Add(dataRow);
                        }
                    }
                    List<KeyValuePair<byte, EquipmentData>> list2;
                    if (MainForm.角色装备表.TryGetValue(key, out list2))
                    {
                        foreach (KeyValuePair<byte, EquipmentData> keyValuePair2 in list2)
                        {
                            DataRow dataRow2 = MainForm.EquipmentData表.NewRow();
                            dataRow2["穿戴部位"] = (EquipmentWearingParts)keyValuePair2.Key;
                            dataRow2["穿戴装备"] = keyValuePair2.Value;
                            MainForm.EquipmentData表.Rows.Add(dataRow2);
                        }
                    }
                    List<KeyValuePair<byte, ItemData>> list3;
                    if (MainForm.角色背包表.TryGetValue(key, out list3))
                    {
                        foreach (KeyValuePair<byte, ItemData> keyValuePair3 in list3)
                        {
                            DataRow dataRow3 = MainForm.背包DataSheet.NewRow();
                            dataRow3["背包位置"] = keyValuePair3.Key;
                            dataRow3["背包物品"] = keyValuePair3.Value;
                            MainForm.背包DataSheet.Rows.Add(dataRow3);
                        }
                    }
                    List<KeyValuePair<byte, ItemData>> list4;
                    if (MainForm.角色仓库表.TryGetValue(key, out list4))
                    {
                        foreach (KeyValuePair<byte, ItemData> keyValuePair4 in list4)
                        {
                            DataRow dataRow4 = MainForm.仓库DataSheet.NewRow();
                            dataRow4["仓库位置"] = keyValuePair4.Key;
                            dataRow4["仓库物品"] = keyValuePair4.Value;
                            MainForm.仓库DataSheet.Rows.Add(dataRow4);
                        }
                    }
                }
            }
            if (MainForm.Singleton.怪物浏览表.Rows.Count > 0 && MainForm.Singleton.怪物浏览表.SelectedRows.Count > 0)
            {
                DataRow row2 = (MainForm.Singleton.怪物浏览表.Rows[MainForm.Singleton.怪物浏览表.SelectedRows[0].Index].DataBoundItem as DataRowView).Row;
                游戏怪物 key2;
                List<KeyValuePair<游戏物品, long>> list5;
                if (MainForm.数据行怪物.TryGetValue(row2, out key2) && MainForm.怪物掉落表.TryGetValue(key2, out list5))
                {
                    foreach (KeyValuePair<游戏物品, long> keyValuePair5 in list5)
                    {
                        DataRow dataRow5 = MainForm.掉落DataSheet.NewRow();
                        dataRow5["物品名字"] = keyValuePair5.Key.物品名字;
                        dataRow5["掉落数量"] = keyValuePair5.Value;
                        MainForm.掉落DataSheet.Rows.Add(dataRow5);
                    }
                }
            }
        }

        // Token: 0x0600009B RID: 155 RVA: 0x00013148 File Offset: 0x00011348
        public static void 更新CharacterData(CharacterData 角色, string 表头, object 内容)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                DataRow dataRow;
                if (MainForm.CharacterData行.TryGetValue(角色, out dataRow))
                {
                    dataRow[表头] = 内容;
                }
            }));
        }

        // Token: 0x0600009C RID: 156 RVA: 0x0001318C File Offset: 0x0001138C
        public static void UpdateCharactersSkills(CharacterData 角色, List<KeyValuePair<ushort, SkillData>> 技能)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                MainForm.角色技能表[角色] = 技能;
            }));
        }

        // Token: 0x0600009D RID: 157 RVA: 0x000131CC File Offset: 0x000113CC
        public static void UpdateCharactersEquipment(CharacterData 角色, List<KeyValuePair<byte, EquipmentData>> 装备)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                MainForm.角色装备表[角色] = 装备;
            }));
        }

        // Token: 0x0600009E RID: 158 RVA: 0x0001320C File Offset: 0x0001140C
        public static void UpdateCharactersBackpack(CharacterData 角色, List<KeyValuePair<byte, ItemData>> 物品)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                MainForm.角色背包表[角色] = 物品;
            }));
        }

        // Token: 0x0600009F RID: 159 RVA: 0x0001324C File Offset: 0x0001144C
        public static void 更新角色仓库(CharacterData 角色, List<KeyValuePair<byte, ItemData>> 物品)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                MainForm.角色仓库表[角色] = 物品;
            }));
        }

        // Token: 0x060000A0 RID: 160 RVA: 0x0001328C File Offset: 0x0001148C
        public static void 添加地图数据(MapInstance 地图)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                if (!MainForm.MapsDataRow.ContainsKey(地图.地图模板))
                {
                    DataRow dataRow = MainForm.MapsDataTable.NewRow();
                    dataRow["地图编号"] = 地图.地图编号;
                    dataRow["地图名字"] = 地图.地图模板;
                    dataRow["限制等级"] = 地图.限制等级;
                    dataRow["玩家数量"] = 地图.玩家列表.Count;
                    dataRow["固定怪物总数"] = 地图.固定怪物总数;
                    dataRow["存活怪物总数"] = 地图.存活怪物总数;
                    dataRow["怪物复活次数"] = 地图.怪物复活次数;
                    dataRow["怪物掉落次数"] = 地图.怪物掉落次数;
                    dataRow["金币掉落总数"] = 地图.金币掉落总数;
                    MainForm.MapsDataRow[地图.地图模板] = dataRow;
                    MainForm.MapsDataTable.Rows.Add(dataRow);
                }
            }));
        }

        // Token: 0x060000A1 RID: 161 RVA: 0x000132C4 File Offset: 0x000114C4
        public static void 更新地图数据(MapInstance 地图, string 表头, object 内容)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                DataRow dataRow;
                if (MainForm.MapsDataRow.TryGetValue(地图.地图模板, out dataRow))
                {
                    string 表头2 = 表头;
                    if (表头2 == "存活怪物总数" || 表头2 == "怪物复活次数")
                    {
                        dataRow[表头] = (long)((ulong)Convert.ToUInt32(dataRow[表头]) + (ulong)((long)((int)内容)));
                        return;
                    }
                    if (表头2 == "金币掉落总数" || 表头2 == "怪物掉落次数")
                    {
                        dataRow[表头] = Convert.ToInt64(dataRow[表头]) + (long)((int)内容);
                        return;
                    }
                    dataRow[表头] = 内容;
                }
            }));
        }

        // Token: 0x060000A2 RID: 162 RVA: 0x00013308 File Offset: 0x00011508
        public static void 添加怪物数据(游戏怪物 怪物)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                if (!MainForm.怪物数据行.ContainsKey(怪物))
                {
                    DataRow dataRow = MainForm.怪物DataSheet.NewRow();
                    dataRow["模板编号"] = 怪物.怪物编号;
                    dataRow["怪物名字"] = 怪物.怪物名字;
                    dataRow["怪物等级"] = 怪物.怪物等级;
                    dataRow["怪物级别"] = 怪物.怪物级别;
                    dataRow["怪物经验"] = 怪物.怪物提供经验;
                    dataRow["移动间隔"] = 怪物.怪物移动间隔;
                    dataRow["仇恨范围"] = 怪物.怪物仇恨范围;
                    dataRow["仇恨时长"] = 怪物.怪物仇恨时间;
                    MainForm.怪物数据行[怪物] = dataRow;
                    MainForm.数据行怪物[dataRow] = 怪物;
                    MainForm.怪物DataSheet.Rows.Add(dataRow);
                }
            }));
        }

        // Token: 0x060000A3 RID: 163 RVA: 0x00013340 File Offset: 0x00011540
        public static void 更新掉落统计(游戏怪物 怪物, List<KeyValuePair<游戏物品, long>> 物品)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                MainForm.怪物掉落表[怪物] = 物品;
            }));
        }

        // Token: 0x060000A4 RID: 164 RVA: 0x00013380 File Offset: 0x00011580
        public static void 添加封禁数据(string 地址, object 时间, bool 网络地址 = true)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                if (!MainForm.封禁数据行.ContainsKey(地址))
                {
                    DataRow dataRow = MainForm.封禁DataSheet.NewRow();
                    dataRow["网络地址"] = (网络地址 ? 地址 : null);
                    dataRow["物理地址"] = (网络地址 ? null : 地址);
                    dataRow["到期时间"] = 时间;
                    MainForm.封禁数据行[地址] = dataRow;
                    MainForm.封禁DataSheet.Rows.Add(dataRow);
                }
            }));
        }

        // Token: 0x060000A5 RID: 165 RVA: 0x000133C4 File Offset: 0x000115C4
        public static void 更新封禁数据(string 地址, object 时间, bool 网络地址 = true)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                DataRow dataRow;
                if (MainForm.封禁数据行.TryGetValue(地址, out dataRow))
                {
                    if (网络地址)
                    {
                        dataRow["网络地址"] = 时间;
                        return;
                    }
                    dataRow["物理地址"] = 时间;
                }
            }));
        }

        // Token: 0x060000A6 RID: 166 RVA: 0x00013408 File Offset: 0x00011608
        public static void 移除封禁数据(string 地址)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                DataRow row;
                if (MainForm.封禁数据行.TryGetValue(地址, out row))
                {
                    MainForm.封禁数据行.Remove(地址);
                    MainForm.封禁DataSheet.Rows.Remove(row);
                }
            }));
        }

        // Token: 0x060000A7 RID: 167 RVA: 0x00013440 File Offset: 0x00011640
        public MainForm()
        {

            this.InitializeComponent();
            MainForm.Singleton = this;
            string 系统公告内容 = Settings.Default.系统公告内容;
            MainForm.公告DataSheet = new Dictionary<DataGridViewRow, DateTime>();
            string[] array = 系统公告内容.Split(new char[]
            {
                '\r',
                '\n'
            }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < array.Length; i++)
            {
                string[] array2 = array[i].Split(new char[]
                {
                    '\t'
                });
                int index = this.公告浏览表.Rows.Add();

                this.公告浏览表.Rows[index].Cells["公告间隔"].Value = array2[0];
                this.公告浏览表.Rows[index].Cells["公告次数"].Value = array2[1];
                this.公告浏览表.Rows[index].Cells["公告内容"].Value = array2[2];

            }
            this.dgvCharacters.ColumnHeadersDefaultCellStyle.Font = (this.dgvMaps.ColumnHeadersDefaultCellStyle.Font = (this.怪物浏览表.ColumnHeadersDefaultCellStyle.Font = (this.掉落浏览表.ColumnHeadersDefaultCellStyle.Font = (this.封禁浏览表.ColumnHeadersDefaultCellStyle.Font = (this.dgvCharacters.DefaultCellStyle.Font = (this.dgvMaps.DefaultCellStyle.Font = (this.怪物浏览表.DefaultCellStyle.Font = (this.封禁浏览表.DefaultCellStyle.Font = (this.掉落浏览表.DefaultCellStyle.Font = new Font("宋体", 9f))))))))));
            this.S_软件注册代码.Text = (CustomClass.软件注册代码 = Settings.Default.软件注册代码);
            this.S_GameData目录.Text = (CustomClass.GameData目录 = Settings.Default.GameData目录);
            this.S_数据备份目录.Text = (CustomClass.数据备份目录 = Settings.Default.数据备份目录);
            this.S_客户连接端口.Value = (CustomClass.客户连接端口 = Settings.Default.客户连接端口);
            this.S_门票接收端口.Value = (CustomClass.门票接收端口 = Settings.Default.门票接收端口);
            this.S_封包限定数量.Value = (CustomClass.封包限定数量 = Settings.Default.封包限定数量);
            this.S_异常屏蔽时间.Value = (CustomClass.异常屏蔽时间 = Settings.Default.异常屏蔽时间);
            this.S_掉线判定时间.Value = (CustomClass.掉线判定时间 = Settings.Default.掉线判定时间);
            this.S_游戏OpenLevelCommand.Value = (CustomClass.游戏OpenLevelCommand = Settings.Default.游戏OpenLevelCommand);
            this.S_NoobSupportCommand等级.Value = (CustomClass.NoobSupportCommand等级 = Settings.Default.NoobSupportCommand等级);
            this.S_装备特修折扣.Value = (CustomClass.装备特修折扣 = Settings.Default.装备特修折扣);
            this.S_怪物额外爆率.Value = (CustomClass.怪物额外爆率 = Settings.Default.怪物额外爆率);
            this.S_怪物经验倍率.Value = (CustomClass.怪物经验倍率 = Settings.Default.怪物经验倍率);
            this.S_减收益等级差.Value = (CustomClass.减收益等级差 = (ushort)Settings.Default.减收益等级差);
            this.S_收益减少比率.Value = (CustomClass.收益减少比率 = Settings.Default.收益减少比率);
            this.S_怪物诱惑时长.Value = (CustomClass.怪物诱惑时长 = Settings.Default.怪物诱惑时长);
            this.S_物品归属时间.Value = (CustomClass.物品归属时间 = (ushort)Settings.Default.物品归属时间);
            this.S_物品清理时间.Value = (CustomClass.物品清理时间 = (ushort)Settings.Default.物品清理时间);
            Task.Run(delegate ()
            {
                Thread.Sleep(100);
                BeginInvoke(new MethodInvoker(delegate ()
                {
                    Control control = this.下方控件页;
                    this.tabConfig.Enabled = false;
                    control.Enabled = false;
                }));
                LoadSystemData();
                LoadUserData();
                base.BeginInvoke(new MethodInvoker(delegate ()
                {
                    this.界面定时更新.Tick += MainForm.界面更新处理;
                    this.dgvCharacters.SelectionChanged += MainForm.界面更新处理;
                    this.怪物浏览表.SelectionChanged += MainForm.界面更新处理;
                    Control control = this.下方控件页;
                    this.tabConfig.Enabled = true;
                    control.Enabled = true;
                }));
            });
        }

        // Token: 0x060000A8 RID: 168 RVA: 0x0001384C File Offset: 0x00011A4C
        private void 保存数据库_Click(object sender, EventArgs e)
        {
            Control control = this.保存按钮;
            Control control2 = this.启动按钮;
            this.停止按钮.Enabled = false;
            control2.Enabled = false;
            control.Enabled = false;
            this.保存按钮.BackColor = Color.LightSteelBlue;
            Task.Run(delegate ()
            {
                MainForm.AddSystemLog("正在保存客户数据...");
                GameDataGateway.保存数据();
                GameDataGateway.导出数据();
                MainForm.AddSystemLog("客户数据已经保存");
                base.BeginInvoke(new MethodInvoker(delegate ()
                {
                    this.启动按钮.Enabled = true;
                }));
            });
        }

        // Token: 0x060000A9 RID: 169 RVA: 0x000138A0 File Offset: 0x00011AA0
        private void 启动服务器_Click(object sender, EventArgs e)
        {
            MainProcess.启动服务();
            CustomClass.软件注册代码 = (Settings.Default.软件注册代码 = this.S_软件注册代码.Text);
            Settings.Default.Save();
            MainForm.MapsDataTable = new DataTable("地图数据表");
            MainForm.MapsDataRow = new Dictionary<游戏地图, DataRow>();
            MainForm.MapsDataTable.Columns.Add("地图编号", typeof(string));
            MainForm.MapsDataTable.Columns.Add("地图名字", typeof(string));
            MainForm.MapsDataTable.Columns.Add("限制等级", typeof(string));
            MainForm.MapsDataTable.Columns.Add("玩家数量", typeof(string));
            MainForm.MapsDataTable.Columns.Add("固定怪物总数", typeof(string));
            MainForm.MapsDataTable.Columns.Add("存活怪物总数", typeof(string));
            MainForm.MapsDataTable.Columns.Add("怪物复活次数", typeof(string));
            MainForm.MapsDataTable.Columns.Add("怪物掉落次数", typeof(string));
            MainForm.MapsDataTable.Columns.Add("金币掉落总数", typeof(string));
            MainForm.Singleton.dgvMaps.DataSource = MainForm.MapsDataTable;
            MainForm.怪物DataSheet = new DataTable("怪物数据表");
            MainForm.怪物数据行 = new Dictionary<游戏怪物, DataRow>();
            MainForm.数据行怪物 = new Dictionary<DataRow, 游戏怪物>();
            MainForm.怪物DataSheet.Columns.Add("模板编号", typeof(string));
            MainForm.怪物DataSheet.Columns.Add("怪物名字", typeof(string));
            MainForm.怪物DataSheet.Columns.Add("怪物等级", typeof(string));
            MainForm.怪物DataSheet.Columns.Add("怪物经验", typeof(string));
            MainForm.怪物DataSheet.Columns.Add("怪物级别", typeof(string));
            MainForm.怪物DataSheet.Columns.Add("移动间隔", typeof(string));
            MainForm.怪物DataSheet.Columns.Add("漫游间隔", typeof(string));
            MainForm.怪物DataSheet.Columns.Add("仇恨范围", typeof(string));
            MainForm.怪物DataSheet.Columns.Add("仇恨时长", typeof(string));
            MainForm.Singleton.怪物浏览表.DataSource = MainForm.怪物DataSheet;
            MainForm.掉落DataSheet = new DataTable("掉落数据表");
            MainForm.怪物掉落表 = new Dictionary<游戏怪物, List<KeyValuePair<游戏物品, long>>>();
            MainForm.掉落DataSheet.Columns.Add("物品名字", typeof(string));
            MainForm.掉落DataSheet.Columns.Add("掉落数量", typeof(string));
            MainForm.Singleton.掉落浏览表.DataSource = MainForm.掉落DataSheet;
            this.主选项卡.SelectedIndex = 0;
            this.保存按钮.BackColor = Color.LightSteelBlue;
            Control control = this.保存按钮;
            Control control2 = this.启动按钮;
            Control control3 = this.停止按钮;
            this.tabConfig.Enabled = false;
            control3.Enabled = false;
            control2.Enabled = false;
            control.Enabled = false;
        }

        // Token: 0x060000AA RID: 170 RVA: 0x00002BD6 File Offset: 0x00000DD6
        private void 停止服务器_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定停止服务器?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                MainProcess.停止服务();
                this.停止按钮.Enabled = false;
            }
        }

        // Token: 0x060000AB RID: 171 RVA: 0x00013C24 File Offset: 0x00011E24
        private void 关闭主界面_Click(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("确定关闭服务器?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                for (; ; )
                {
                    Thread 主线程 = MainProcess.主线程;
                    if (主线程 == null || !主线程.IsAlive)
                    {
                        break;
                    }
                    MainProcess.停止服务();
                    Thread.Sleep(1);
                }
                if (GameDataGateway.已经修改 && MessageBox.Show("客户数据已经修改但尚未保存, 需要保存数据吗?", "保存数据", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    GameDataGateway.保存数据();
                    GameDataGateway.导出数据();
                    return;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        // Token: 0x060000AC RID: 172 RVA: 0x00013C9C File Offset: 0x00011E9C
        private void 保存数据提醒_Tick(object sender, EventArgs e)
        {
            if (this.保存按钮.Enabled && GameDataGateway.已经修改)
            {
                if (this.保存按钮.BackColor == Color.LightSteelBlue)
                {
                    this.保存按钮.BackColor = Color.PaleVioletRed;
                    return;
                }
                this.保存按钮.BackColor = Color.LightSteelBlue;
            }
        }

        // Token: 0x060000AD RID: 173 RVA: 0x00002C03 File Offset: 0x00000E03
        private void 清空系统日志_Click(object sender, EventArgs e)
        {
            this.系统日志.Clear();
            Control control = this.清空系统日志;
            this.保存系统日志.Enabled = false;
            control.Enabled = false;
        }

        // Token: 0x060000AE RID: 174 RVA: 0x00002C28 File Offset: 0x00000E28
        private void 清空聊天日志_Click(object sender, EventArgs e)
        {
            this.聊天日志.Clear();
            Control control = this.清空聊天日志;
            this.保存聊天日志.Enabled = false;
            control.Enabled = false;
        }

        // Token: 0x060000AF RID: 175 RVA: 0x00002C4D File Offset: 0x00000E4D
        private void 清空命令日志_Click(object sender, EventArgs e)
        {
            this.命令日志.Clear();
            this.清空命令日志.Enabled = false;
        }

        // Token: 0x060000B0 RID: 176 RVA: 0x00013CF8 File Offset: 0x00011EF8
        private void 保存系统日志_Click(object sender, EventArgs e)
        {
            if (this.系统日志.Text != null && !(this.系统日志.Text == ""))
            {
                if (!Directory.Exists(".\\Log\\Sys"))
                {
                    Directory.CreateDirectory(".\\Log\\Sys");
                }
                File.WriteAllText(string.Format(".\\Log\\Sys\\{0:yyyy-MM-dd--HH-mm-ss}.txt", DateTime.Now), this.系统日志.Text.Replace("\n", "\r\n"));
                MainForm.AddSystemLog("系统日志已成功保存");
                return;
            }
        }

        // Token: 0x060000B1 RID: 177 RVA: 0x00013D80 File Offset: 0x00011F80
        private void 保存聊天日志_Click(object sender, EventArgs e)
        {
            if (this.聊天日志.Text != null && !(this.聊天日志.Text == ""))
            {
                if (!Directory.Exists(".\\Log\\Chat"))
                {
                    Directory.CreateDirectory(".\\Log\\Chat");
                }
                File.WriteAllText(string.Format(".\\Log\\Chat\\{0:yyyy-MM-dd--HH-mm-ss}.txt", DateTime.Now), this.系统日志.Text);
                MainForm.AddSystemLog("系统日志已成功保存");
                return;
            }
        }

        // Token: 0x060000B2 RID: 178 RVA: 0x00002C66 File Offset: 0x00000E66
        private void 重载SystemData_Click(object sender, EventArgs e)
        {
            Control control = this.下方控件页;
            this.tabConfig.Enabled = false;
            control.Enabled = false;
            Task.Run(delegate ()
            {
                MainForm.LoadSystemData();
                base.BeginInvoke(new MethodInvoker(delegate ()
                {
                    Control control2 = this.下方控件页;
                    this.tabConfig.Enabled = true;
                    control2.Enabled = true;
                }));
            });
        }

        // Token: 0x060000B3 RID: 179 RVA: 0x00002C92 File Offset: 0x00000E92
        private void 重载客户数据_Click(object sender, EventArgs e)
        {
            Control control = this.下方控件页;
            this.tabConfig.Enabled = false;
            control.Enabled = false;
            Task.Run(delegate ()
            {
                MainForm.LoadUserData();
                base.BeginInvoke(new MethodInvoker(delegate ()
                {
                    Control control2 = this.下方控件页;
                    this.tabConfig.Enabled = true;
                    control2.Enabled = true;
                }));
            });
        }

        // Token: 0x060000B4 RID: 180 RVA: 0x00013DF8 File Offset: 0x00011FF8
        private void 选择数据目录_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
            {
                Description = "请选择文件夹"
            };
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                if (sender == this.S_浏览数据目录)
                {
                    CustomClass.GameData目录 = (Settings.Default.GameData目录 = (this.S_GameData目录.Text = folderBrowserDialog.SelectedPath));
                    Settings.Default.Save();
                    return;
                }
                if (sender == this.S_浏览备份目录)
                {
                    CustomClass.数据备份目录 = (Settings.Default.数据备份目录 = (this.S_数据备份目录.Text = folderBrowserDialog.SelectedPath));
                    Settings.Default.Save();
                    return;
                }
                if (sender == this.S_浏览合并目录)
                {
                    this.S_合并数据目录.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        // Token: 0x060000B5 RID: 181 RVA: 0x00013EB0 File Offset: 0x000120B0
        private void 更改设置数值_Value(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = sender as NumericUpDown;
            if (numericUpDown != null)
            {
                string name = numericUpDown.Name;

                switch (name)
                {
                    case "S_收益减少比率":
                        CustomClass.收益减少比率 = (Settings.Default.收益减少比率 = numericUpDown.Value);
                        break;
                    case "S_掉线判定时间":
                        CustomClass.掉线判定时间 = (Settings.Default.掉线判定时间 = (ushort)numericUpDown.Value);
                        break;
                    case "S_游戏OpenLevelCommand":
                        CustomClass.游戏OpenLevelCommand = (Settings.Default.游戏OpenLevelCommand = (byte)numericUpDown.Value);
                        break;
                    case "S_怪物诱惑时长":
                        CustomClass.怪物诱惑时长 = (Settings.Default.怪物诱惑时长 = (ushort)numericUpDown.Value);
                        break;
                    case "S_怪物经验倍率":
                        CustomClass.怪物经验倍率 = (Settings.Default.怪物经验倍率 = numericUpDown.Value);
                        break;
                    case "S_门票接收端口":
                        CustomClass.门票接收端口 = (Settings.Default.门票接收端口 = (ushort)numericUpDown.Value);
                        break;
                    case "S_异常屏蔽时间":
                        CustomClass.异常屏蔽时间 = (Settings.Default.异常屏蔽时间 = (ushort)numericUpDown.Value);
                        break;
                    case "S_减收益等级差":
                        CustomClass.减收益等级差 = (ushort)(Settings.Default.减收益等级差 = (byte)numericUpDown.Value);
                        break;
                    case "S_怪物额外爆率":
                        CustomClass.怪物额外爆率 = (Settings.Default.怪物额外爆率 = numericUpDown.Value);
                        break;
                    case "S_物品归属时间":
                        CustomClass.物品归属时间 = (ushort)(Settings.Default.物品归属时间 = (byte)numericUpDown.Value);
                        break;
                    case "S_NoobSupportCommand等级":
                        CustomClass.NoobSupportCommand等级 = (Settings.Default.NoobSupportCommand等级 = (byte)numericUpDown.Value);
                        break;
                    case "S_装备特修折扣":
                        CustomClass.装备特修折扣 = (Settings.Default.装备特修折扣 = numericUpDown.Value);
                        break;
                    case "S_物品清理时间":
                        CustomClass.物品清理时间 = (ushort)(Settings.Default.物品清理时间 = (byte)numericUpDown.Value);
                        break;
                    case "S_封包限定数量":
                        CustomClass.封包限定数量 = (Settings.Default.封包限定数量 = (ushort)numericUpDown.Value);
                        break;
                    case "S_客户连接端口":
                        CustomClass.客户连接端口 = (Settings.Default.客户连接端口 = (ushort)numericUpDown.Value);
                        break;
                    default:
                        MessageBox.Show("未知变量! " + numericUpDown.Name);
                        break;
                }

                Settings.Default.Save();
            }
        }

        // Token: 0x060000B6 RID: 182 RVA: 0x000142BC File Offset: 0x000124BC
        private void 执行GMCommand行_Press(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(13) && this.GMCommand文本.Text.Length > 0)
            {
                this.主选项卡.SelectedIndex = 0;
                this.日志选项卡.SelectedIndex = 2;
                MainForm.添加命令日志("=> " + this.GMCommand文本.Text);
                GMCommand GMCommand;
                if (this.GMCommand文本.Text[0] != '@')
                {
                    MainForm.添加命令日志("<= 命令解析错误, GMCommand必须以 '@' 开头. 输入 '@ViewCommand' 获取所有受支持的命令格式");
                }
                else if (this.GMCommand文本.Text.Trim(new char[]
                {
                    '@',
                    ' '
                }).Length == 0)
                {
                    MainForm.添加命令日志("<= 命令解析错误, GMCommand不能为空. 输入 '@ViewCommand' 获取所有受支持的命令格式");
                }
                else if (GMCommand.解析命令(this.GMCommand文本.Text, out GMCommand))
                {
                    if (GMCommand.ExecutionWay == ExecutionWay.前台立即执行)
                    {
                        GMCommand.执行命令();
                    }
                    else if (GMCommand.ExecutionWay == ExecutionWay.优先后台执行)
                    {
                        if (MainProcess.已经启动)
                        {
                            MainProcess.外部命令.Enqueue(GMCommand);
                        }
                        else
                        {
                            GMCommand.执行命令();
                        }
                    }
                    else if (GMCommand.ExecutionWay == ExecutionWay.只能后台执行)
                    {
                        if (MainProcess.已经启动)
                        {
                            MainProcess.外部命令.Enqueue(GMCommand);
                        }
                        else
                        {
                            MainForm.添加命令日志("<= 命令执行失败, 当前命令只能在服务器运行时执行, 请先启动服务器");
                        }
                    }
                    else if (GMCommand.ExecutionWay == ExecutionWay.只能空闲执行)
                    {
                        if (!MainProcess.已经启动 && (MainProcess.主线程 == null || !MainProcess.主线程.IsAlive))
                        {
                            GMCommand.执行命令();
                        }
                        else
                        {
                            MainForm.添加命令日志("<= 命令执行失败, 当前命令只能在服务器未运行时执行, 请先关闭服务器");
                        }
                    }
                    e.Handled = true;
                }
                this.GMCommand文本.Clear();
            }
        }

        // Token: 0x060000B7 RID: 183 RVA: 0x0001443C File Offset: 0x0001263C
        private void 合并客户数据_Click(object sender, EventArgs e)
        {
            if (MainProcess.已经启动)
            {
                MessageBox.Show("合并数据只能在服务器未运行时执行");
                return;
            }
            Dictionary<Type, DataTableBase> Data型表 = GameDataGateway.Data型表;
            if (Data型表 == null || Data型表.Count == 0)
            {
                MessageBox.Show("需要先加载当前客户数据后才能与指定客户数据合并");
                return;
            }
            if (!Directory.Exists(this.S_合并数据目录.Text))
            {
                MessageBox.Show("请选择有效的 Data.db 文件目录");
                return;
            }
            if (!File.Exists(this.S_合并数据目录.Text + "\\Data.db"))
            {
                MessageBox.Show("选择的目录中没有找到 Data.db 文件");
                return;
            }
            if (MessageBox.Show("即将执行数据合并操作\r\n\r\n此操作不可逆, 请做好数据备份\r\n\r\n确定要执行吗?", "危险操作", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                GameDataGateway.合并数据(this.S_合并数据目录.Text + "\\Data.db");
            }
        }

        // Token: 0x060000B8 RID: 184 RVA: 0x000144F0 File Offset: 0x000126F0
        private void 角色右键菜单_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
            if (toolStripMenuItem != null && MainForm.Singleton.dgvCharacters.Rows.Count > 0 && MainForm.Singleton.dgvCharacters.SelectedRows.Count > 0)
            {
                DataRow row = (MainForm.Singleton.dgvCharacters.Rows[MainForm.Singleton.dgvCharacters.SelectedRows[0].Index].DataBoundItem as DataRowView).Row;
                if (toolStripMenuItem.Name == "右键菜单_复制账号名字")
                {
                    Clipboard.SetDataObject(row["所属账号"]);
                }
                if (toolStripMenuItem.Name == "右键菜单_复制角色名字")
                {
                    Clipboard.SetDataObject(row["角色名字"]);
                }
                if (toolStripMenuItem.Name == "右键菜单_复制网络地址")
                {
                    Clipboard.SetDataObject(row["网络地址"]);
                }
                if (toolStripMenuItem.Name == "右键菜单_复制物理地址")
                {
                    Clipboard.SetDataObject(row["物理地址"]);
                }
            }
        }

        // Token: 0x060000B9 RID: 185 RVA: 0x00014604 File Offset: 0x00012804
        private void 添加公告按钮_Click(object sender, EventArgs e)
        {
            int index = this.公告浏览表.Rows.Add();
            this.公告浏览表.Rows[index].Cells["公告间隔"].Value = 5;
            this.公告浏览表.Rows[index].Cells["公告次数"].Value = 1;
            this.公告浏览表.Rows[index].Cells["公告内容"].Value = "请输入公告内容";
            string text = null;
            int i = 0;
            while (i < this.公告浏览表.Rows.Count)
            {
                object value = this.公告浏览表.Rows[i].Cells["公告间隔"].Value;
                if (value == null)
                {
                    goto IL_CE;
                }
                string text2;
                if ((text2 = value.ToString()) == null)
                {
                    goto IL_CE;
                }
            IL_D4:
                string text3 = text2;
                object value2 = this.公告浏览表.Rows[i].Cells["公告次数"].Value;
                if (value2 == null)
                {
                    goto IL_109;
                }
                string text4;
                if ((text4 = value2.ToString()) == null)
                {
                    goto IL_109;
                }
            IL_10F:
                string text5 = text4;
                object value3 = this.公告浏览表.Rows[i].Cells["公告内容"].Value;
                if (value3 == null)
                {
                    goto IL_145;
                }
                string text6;
                if ((text6 = value3.ToString()) == null)
                {
                    goto IL_145;
                }
            IL_14B:
                string text7 = text6;
                text = string.Concat(new string[]
                {
                    text,
                    text3,
                    "\t",
                    text5,
                    "\t",
                    text7,
                    "\r\n"
                });
                i++;
                continue;
            IL_145:
                text6 = "";
                goto IL_14B;
            IL_109:
                text4 = "";
                goto IL_10F;
            IL_CE:
                text2 = "";
                goto IL_D4;
            }
            Settings.Default.系统公告内容 = text;
            Settings.Default.Save();
        }

        // Token: 0x060000BA RID: 186 RVA: 0x000147C4 File Offset: 0x000129C4
        private void 删除公告按钮_Click(object sender, EventArgs e)
        {
            if (this.公告浏览表.Rows.Count != 0 && this.公告浏览表.SelectedRows.Count != 0)
            {
                DataGridViewRow key = this.公告浏览表.Rows[this.公告浏览表.SelectedRows[0].Index];
                MainForm.公告DataSheet.Remove(key);
                this.公告浏览表.Rows.RemoveAt(this.公告浏览表.SelectedRows[0].Index);
                string text = null;
                int i = 0;
                while (i < this.公告浏览表.Rows.Count)
                {
                    object value = this.公告浏览表.Rows[i].Cells["公告间隔"].Value;
                    if (value == null)
                    {
                        goto IL_C0;
                    }
                    string text2;
                    if ((text2 = value.ToString()) == null)
                    {
                        goto IL_C0;
                    }
                IL_C6:
                    string text3 = text2;
                    object value2 = this.公告浏览表.Rows[i].Cells["公告次数"].Value;
                    if (value2 == null)
                    {
                        goto IL_FC;
                    }
                    string text4;
                    if ((text4 = value2.ToString()) == null)
                    {
                        goto IL_FC;
                    }
                IL_102:
                    string text5 = text4;
                    object value3 = this.公告浏览表.Rows[i].Cells["公告内容"].Value;
                    if (value3 == null)
                    {
                        goto IL_137;
                    }
                    string text6;
                    if ((text6 = value3.ToString()) == null)
                    {
                        goto IL_137;
                    }
                IL_13D:
                    string text7 = text6;
                    text = string.Concat(new string[]
                    {
                        text,
                        text3,
                        "\t",
                        text5,
                        "\t",
                        text7,
                        "\r\n"
                    });
                    i++;
                    continue;
                IL_137:
                    text6 = "";
                    goto IL_13D;
                IL_FC:
                    text4 = "";
                    goto IL_102;
                IL_C0:
                    text2 = "";
                    goto IL_C6;
                }
                Settings.Default.系统公告内容 = text;
                Settings.Default.Save();
                return;
            }
        }

        // Token: 0x060000BB RID: 187 RVA: 0x00014978 File Offset: 0x00012B78
        private void 开始公告按钮_Click(object sender, EventArgs e)
        {
            if (!MainProcess.已经启动 || !this.停止按钮.Enabled)
            {
                Task.Run(delegate ()
                {
                    MessageBox.Show("服务器未启动, 请先开启服务器");
                });
                return;
            }
            if (this.公告浏览表.Rows.Count == 0 || this.公告浏览表.SelectedRows.Count == 0)
            {
                return;
            }
            DataGridViewRow dataGridViewRow = this.公告浏览表.Rows[this.公告浏览表.SelectedRows[0].Index];
            int num;
            if (!int.TryParse(dataGridViewRow.Cells["公告间隔"].Value.ToString(), out num) || num <= 0)
            {
                Task.Run(delegate ()
                {
                    MessageBox.Show("系统公告未能开启, 公告间隔必须为大于0的整数");
                });
                return;
            }
            int num2;
            if (!int.TryParse(dataGridViewRow.Cells["公告次数"].Value.ToString(), out num2) || num2 <= 0)
            {
                Task.Run(delegate ()
                {
                    MessageBox.Show("系统公告未能开启, 公告次数必须为大于0的整数");
                });
                return;
            }
            if (dataGridViewRow.Cells["公告内容"].Value != null && dataGridViewRow.Cells["公告内容"].Value.ToString().Length > 0)
            {
                dataGridViewRow.ReadOnly = true;
                dataGridViewRow.Cells["公告状态"].Value = "√";
                dataGridViewRow.Cells["剩余次数"].Value = dataGridViewRow.Cells["公告次数"].Value;
                MainForm.公告DataSheet.Add(dataGridViewRow, DateTime.Now);
                this.开始公告按钮.Enabled = false;
                this.停止公告按钮.Enabled = true;
                return;
            }
            Task.Run(delegate ()
            {
                MessageBox.Show("系统公告未能开启, 公告内容不能为空");
            });
        }

        // Token: 0x060000BC RID: 188 RVA: 0x00014B94 File Offset: 0x00012D94
        private void 停止公告按钮_Click(object sender, EventArgs e)
        {
            if (this.公告浏览表.Rows.Count != 0 && this.公告浏览表.SelectedRows.Count != 0)
            {
                DataGridViewRow dataGridViewRow = this.公告浏览表.Rows[this.公告浏览表.SelectedRows[0].Index];
                MainForm.公告DataSheet.Remove(dataGridViewRow);
                dataGridViewRow.ReadOnly = false;
                dataGridViewRow.Cells["公告状态"].Value = "";
                dataGridViewRow.Cells["公告计时"].Value = "";
                dataGridViewRow.Cells["剩余次数"].Value = 0;
                this.开始公告按钮.Enabled = true;
                this.停止公告按钮.Enabled = false;
                return;
            }
        }

        // Token: 0x060000BD RID: 189 RVA: 0x00014C70 File Offset: 0x00012E70
        private void 定时发送公告_Tick(object sender, EventArgs e)
        {
            if (MainProcess.已经启动 && MainForm.公告DataSheet.Count != 0)
            {
                DateTime now = DateTime.Now;
                foreach (KeyValuePair<DataGridViewRow, DateTime> keyValuePair in MainForm.公告DataSheet.ToList<KeyValuePair<DataGridViewRow, DateTime>>())
                {
                    keyValuePair.Key.Cells["公告计时"].Value = (keyValuePair.Value - now).ToString("hh\\:mm\\:ss");
                    if (now > keyValuePair.Value)
                    {
                        NetworkServiceGateway.发送公告(keyValuePair.Key.Cells["公告内容"].Value.ToString(), true);
                        MainForm.公告DataSheet[keyValuePair.Key] = now.AddMinutes((double)Convert.ToInt32(keyValuePair.Key.Cells["公告间隔"].Value));
                        int num = Convert.ToInt32(keyValuePair.Key.Cells["剩余次数"].Value) - 1;
                        keyValuePair.Key.Cells["剩余次数"].Value = num;
                        if (num <= 0)
                        {
                            MainForm.公告DataSheet.Remove(keyValuePair.Key);
                            keyValuePair.Key.ReadOnly = false;
                            keyValuePair.Key.Cells["公告状态"].Value = "";
                            if (keyValuePair.Key.Selected)
                            {
                                this.开始公告按钮.Enabled = true;
                                this.停止公告按钮.Enabled = false;
                            }
                        }
                    }
                }
                return;
            }
        }

        // Token: 0x060000BE RID: 190 RVA: 0x00014E4C File Offset: 0x0001304C
        private void 公告浏览表_SelectionChanged(object sender, EventArgs e)
        {
            if (this.公告浏览表.Rows.Count == 0 || this.公告浏览表.SelectedRows.Count == 0)
            {
                Control control = this.开始公告按钮;
                this.停止公告按钮.Enabled = false;
                control.Enabled = false;
                return;
            }
            DataGridViewRow key = this.公告浏览表.Rows[this.公告浏览表.SelectedRows[0].Index];
            if (MainForm.公告DataSheet.ContainsKey(key))
            {
                this.开始公告按钮.Enabled = false;
                this.停止公告按钮.Enabled = true;
                return;
            }
            this.开始公告按钮.Enabled = true;
            this.停止公告按钮.Enabled = false;
        }

        // Token: 0x060000BF RID: 191 RVA: 0x00014EFC File Offset: 0x000130FC
        private void 公告浏览表_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string text = null;
            int i = 0;
            while (i < this.公告浏览表.Rows.Count)
            {
                object value = this.公告浏览表.Rows[i].Cells["公告间隔"].Value;
                if (value == null)
                {
                    goto IL_3D;
                }
                string text2;
                if ((text2 = value.ToString()) == null)
                {
                    goto IL_3D;
                }
            IL_43:
                string text3 = text2;
                object value2 = this.公告浏览表.Rows[i].Cells["公告次数"].Value;
                if (value2 == null)
                {
                    goto IL_79;
                }
                string text4;
                if ((text4 = value2.ToString()) == null)
                {
                    goto IL_79;
                }
            IL_7F:
                string text5 = text4;
                object value3 = this.公告浏览表.Rows[i].Cells["公告内容"].Value;
                if (value3 == null)
                {
                    goto IL_B4;
                }
                string text6;
                if ((text6 = value3.ToString()) == null)
                {
                    goto IL_B4;
                }
            IL_BA:
                string text7 = text6;
                text = string.Concat(new string[]
                {
                    text,
                    text3,
                    "\t",
                    text5,
                    "\t",
                    text7,
                    "\r\n"
                });
                i++;
                continue;
            IL_B4:
                text6 = "";
                goto IL_BA;
            IL_79:
                text4 = "";
                goto IL_7F;
            IL_3D:
                text2 = "";
                goto IL_43;
            }
            Settings.Default.系统公告内容 = text;
            Settings.Default.Save();
        }

        // Token: 0x0400004B RID: 75
        public static MainForm Singleton;

        // Token: 0x0400004C RID: 76
        private static DataTable CharacterDataTable;

        // Token: 0x0400004D RID: 77
        private static DataTable SkillData表;

        // Token: 0x0400004E RID: 78
        private static DataTable EquipmentData表;

        // Token: 0x0400004F RID: 79
        private static DataTable 背包DataSheet;

        // Token: 0x04000050 RID: 80
        private static DataTable 仓库DataSheet;

        // Token: 0x04000051 RID: 81
        private static DataTable MapsDataTable;

        // Token: 0x04000052 RID: 82
        private static DataTable 怪物DataSheet;

        // Token: 0x04000053 RID: 83
        private static DataTable 掉落DataSheet;

        // Token: 0x04000054 RID: 84
        private static DataTable 封禁DataSheet;

        // Token: 0x04000055 RID: 85
        private static Dictionary<CharacterData, DataRow> CharacterData行;

        // Token: 0x04000056 RID: 86
        private static Dictionary<DataRow, CharacterData> 数据行角色;

        // Token: 0x04000057 RID: 87
        private static Dictionary<游戏地图, DataRow> MapsDataRow;

        // Token: 0x04000058 RID: 88
        private static Dictionary<游戏怪物, DataRow> 怪物数据行;

        // Token: 0x04000059 RID: 89
        private static Dictionary<DataRow, 游戏怪物> 数据行怪物;

        // Token: 0x0400005A RID: 90
        private static Dictionary<string, DataRow> 封禁数据行;

        // Token: 0x0400005B RID: 91
        private static Dictionary<DataGridViewRow, DateTime> 公告DataSheet;

        // Token: 0x0400005C RID: 92
        private static Dictionary<CharacterData, List<KeyValuePair<ushort, SkillData>>> 角色技能表;

        // Token: 0x0400005D RID: 93
        private static Dictionary<CharacterData, List<KeyValuePair<byte, EquipmentData>>> 角色装备表;

        // Token: 0x0400005E RID: 94
        private static Dictionary<CharacterData, List<KeyValuePair<byte, ItemData>>> 角色背包表;

        // Token: 0x0400005F RID: 95
        private static Dictionary<CharacterData, List<KeyValuePair<byte, ItemData>>> 角色仓库表;

        // Token: 0x04000060 RID: 96
        private static Dictionary<游戏怪物, List<KeyValuePair<游戏物品, long>>> 怪物掉落表;
    }
}
