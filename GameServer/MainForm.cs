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
    
    public partial class MainForm : Form
    {
        
        public static void LoadSystemData()
        {
            MainForm MainForm = MainForm.Singleton;
            MainForm.AddSystemLog("Loading system data...");
            MainForm.MapsDataTable = new DataTable("地图数据表");
            MainForm.MapsDataRow = new Dictionary<GameMap, DataRow>();
            MainForm.MapsDataTable.Columns.Add("MapId", typeof(string));
            MainForm.MapsDataTable.Columns.Add("MapName", typeof(string));
            MainForm.MapsDataTable.Columns.Add("MinLevel", typeof(string));
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
            MainForm.怪物数据行 = new Dictionary<Monsters, DataRow>();
            MainForm.数据行怪物 = new Dictionary<DataRow, Monsters>();
            MainForm.怪物DataSheet.Columns.Add("模板编号", typeof(string));
            MainForm.怪物DataSheet.Columns.Add("MonsterName", typeof(string));
            MainForm.怪物DataSheet.Columns.Add("Level", typeof(string));
            MainForm.怪物DataSheet.Columns.Add("怪物经验", typeof(string));
            MainForm.怪物DataSheet.Columns.Add("Category", typeof(string));
            MainForm.怪物DataSheet.Columns.Add("移动间隔", typeof(string));
            MainForm.怪物DataSheet.Columns.Add("漫游间隔", typeof(string));
            MainForm.怪物DataSheet.Columns.Add("RangeHate", typeof(string));
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
            MainForm.怪物掉落表 = new Dictionary<Monsters, List<KeyValuePair<GameItems, long>>>();
            MainForm.掉落DataSheet.Columns.Add("Name", typeof(string));
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
            MainForm.AddSystemLog("System data has been loaded succesful");
        }

        
        public static void LoadUserData()
        {
            MainForm MainForm = MainForm.Singleton;
            MainForm.AddSystemLog("Loading client data...");
            MainForm.CharacterDataTable = new DataTable("CharacterDataTable");
            MainForm.SkillData表 = new DataTable("SkillData表");
            MainForm.EquipmentData表 = new DataTable("EquipmentData表");
            MainForm.背包DataSheet = new DataTable("EquipmentData表");
            MainForm.仓库DataSheet = new DataTable("EquipmentData表");
            MainForm.CharacterData行 = new Dictionary<CharacterData, DataRow>();
            MainForm.数据行角色 = new Dictionary<DataRow, CharacterData>();

            MainForm.CharacterDataTable.Columns.Add("CharName", typeof(string));
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
            MainForm.CharacterDataTable.Columns.Add("NumberGoldCoins", typeof(string));
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
            MainForm.SkillData表.Columns.Add("SkillName", typeof(string));
            MainForm.SkillData表.Columns.Add("SkillId", typeof(string));
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
            MainForm.AddSystemLog("Client data has been loaded successful");
        }

        
        public static void ServerStartedCallback()
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

        
        public static void Stop()
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

        
        public static void AddChatLog(string preffix, byte[] text)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                MainForm.Singleton.聊天日志.AppendText(string.Format("[{0:F}]: {1}", DateTime.Now, preffix + Encoding.UTF8.GetString(text).Trim(new char[1])) + "\r\n");
                MainForm.Singleton.聊天日志.ScrollToCaret();
                Control control = MainForm.Singleton.清空聊天日志;
                MainForm.Singleton.保存聊天日志.Enabled = true;
                control.Enabled = true;
            }));
        }

        
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

        
        public static void UpdateTotalConnections(uint 内容)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                MainForm.Singleton.连接总数统计.Text = string.Format("Total Connections: {0}", 内容);
            }));
        }

        
        public static void UpdateAlreadyLogged(uint 内容)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                MainForm.Singleton.已经登录统计.Text = string.Format("Users logged in: {0}", 内容);
            }));
        }

        
        public static void UpdateConnectionsOnline(uint 内容)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                MainForm.Singleton.已经上线统计.Text = string.Format("Users online: {0}", 内容);
            }));
        }

        
        public static void UpdateLoopCount(uint 内容)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                MainForm.Singleton.帧数统计.Text = string.Format("Backstage Frames: {0}", 内容);
            }));
        }

        
        public static void UpdateReceivedBytes(long 内容)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                MainForm.Singleton.接收统计.Text = string.Format("Received: {0}", 内容);
            }));
        }

        
        public static void UpdateSendedBytes(long 内容)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                MainForm.Singleton.发送统计.Text = string.Format("Sent: {0}", 内容);
            }));
        }

        
        public static void UpdateObjectStatistics(int 激活对象, int 次要对象, int 对象总数)
        {
            MainForm MainForm = MainForm.Singleton;
            if (MainForm == null)
            {
                return;
            }
            MainForm.BeginInvoke(new MethodInvoker(delegate ()
            {
                MainForm.Singleton.对象统计.Text = string.Format("Object Statistics {0} / {1} / {2}", 激活对象, 次要对象, 对象总数);
            }));
        }

        
        public static void 添加数据显示(CharacterData 数据)
        {
            if (!MainForm.CharacterData行.ContainsKey(数据))
            {
                MainForm.CharacterData行[数据] = MainForm.CharacterDataTable.NewRow();
                MainForm.CharacterDataTable.Rows.Add(MainForm.CharacterData行[数据]);
            }
        }

        
        public static void 修改数据显示(CharacterData 数据, string 表头文本, string 表格内容)
        {
            if (MainForm.CharacterData行.ContainsKey(数据))
            {
                MainForm.CharacterData行[数据][表头文本] = 表格内容;
            }
        }

        
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
                    dataRow["CharName"] = 角色;
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
                    dataRow["NumberGoldCoins"] = 角色.NumberGoldCoins;
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
                    GameMap 游戏地图;
                    dataRow["当前地图"] = (GameMap.DataSheet.TryGetValue((byte)角色.当前地图.V, out 游戏地图) ? 游戏地图.MapName : 角色.当前地图);
                    dataRow["当前PK值"] = 角色.当前PK值;
                    dataRow["当前坐标"] = string.Format("{0}, {1}", 角色.当前坐标.V.X, 角色.当前坐标.V.Y);
                    MainForm.CharacterData行[角色] = dataRow;
                    MainForm.数据行角色[dataRow] = 角色;
                    MainForm.CharacterDataTable.Rows.Add(dataRow);
                }
            }));
        }

        
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
                            dataRow["SkillName"] = keyValuePair.Value.铭文模板.SkillName;
                            dataRow["SkillId"] = keyValuePair.Value.SkillId;
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
                Monsters key2;
                List<KeyValuePair<GameItems, long>> list5;
                if (MainForm.数据行怪物.TryGetValue(row2, out key2) && MainForm.怪物掉落表.TryGetValue(key2, out list5))
                {
                    foreach (KeyValuePair<GameItems, long> keyValuePair5 in list5)
                    {
                        DataRow dataRow5 = MainForm.掉落DataSheet.NewRow();
                        dataRow5["Name"] = keyValuePair5.Key.Name;
                        dataRow5["掉落数量"] = keyValuePair5.Value;
                        MainForm.掉落DataSheet.Rows.Add(dataRow5);
                    }
                }
            }
        }

        
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
                    dataRow["MapId"] = 地图.MapId;
                    dataRow["MapName"] = 地图.地图模板;
                    dataRow["MinLevel"] = 地图.MinLevel;
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

        
        public static void 添加怪物数据(Monsters 怪物)
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
                    dataRow["模板编号"] = 怪物.Id;
                    dataRow["MonsterName"] = 怪物.MonsterName;
                    dataRow["Level"] = 怪物.Level;
                    dataRow["Category"] = 怪物.Category;
                    dataRow["怪物经验"] = 怪物.ProvideExperience;
                    dataRow["移动间隔"] = 怪物.MoveInterval;
                    dataRow["RangeHate"] = 怪物.RangeHate;
                    dataRow["仇恨时长"] = 怪物.HateTime;
                    MainForm.怪物数据行[怪物] = dataRow;
                    MainForm.数据行怪物[dataRow] = 怪物;
                    MainForm.怪物DataSheet.Rows.Add(dataRow);
                }
            }));
        }

        
        public static void 更新DropStats(Monsters 怪物, List<KeyValuePair<GameItems, long>> 物品)
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
            this.S_GameData目录.Text = (CustomClass.GameDataPath = Settings.Default.GameData目录);
            this.S_数据备份目录.Text = (CustomClass.数据备份目录 = Settings.Default.数据备份目录);
            this.S_GSPort.Value = (CustomClass.GSPort = Settings.Default.GSPort);
            this.S_TSPort.Value = (CustomClass.TSPort = Settings.Default.TSPort);
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
                MainForm.AddSystemLog("Saving customer data...");
                GameDataGateway.SaveData();
                GameDataGateway.CleanUp();
                MainForm.AddSystemLog("Saving customer data...");
                base.BeginInvoke(new MethodInvoker(delegate ()
                {
                    this.启动按钮.Enabled = true;
                }));
            });
        }

        
        private void 启动服务器_Click(object sender, EventArgs e)
        {
            MainProcess.Start();
            CustomClass.软件注册代码 = (Settings.Default.软件注册代码 = this.S_软件注册代码.Text);
            Settings.Default.Save();
            MainForm.MapsDataTable = new DataTable("地图数据表");
            MainForm.MapsDataRow = new Dictionary<GameMap, DataRow>();
            MainForm.MapsDataTable.Columns.Add("MapId", typeof(string));
            MainForm.MapsDataTable.Columns.Add("MapName", typeof(string));
            MainForm.MapsDataTable.Columns.Add("MinLevel", typeof(string));
            MainForm.MapsDataTable.Columns.Add("玩家数量", typeof(string));
            MainForm.MapsDataTable.Columns.Add("固定怪物总数", typeof(string));
            MainForm.MapsDataTable.Columns.Add("存活怪物总数", typeof(string));
            MainForm.MapsDataTable.Columns.Add("怪物复活次数", typeof(string));
            MainForm.MapsDataTable.Columns.Add("怪物掉落次数", typeof(string));
            MainForm.MapsDataTable.Columns.Add("金币掉落总数", typeof(string));
            MainForm.Singleton.dgvMaps.DataSource = MainForm.MapsDataTable;
            MainForm.怪物DataSheet = new DataTable("怪物数据表");
            MainForm.怪物数据行 = new Dictionary<Monsters, DataRow>();
            MainForm.数据行怪物 = new Dictionary<DataRow, Monsters>();
            MainForm.怪物DataSheet.Columns.Add("模板编号", typeof(string));
            MainForm.怪物DataSheet.Columns.Add("MonsterName", typeof(string));
            MainForm.怪物DataSheet.Columns.Add("Level", typeof(string));
            MainForm.怪物DataSheet.Columns.Add("怪物经验", typeof(string));
            MainForm.怪物DataSheet.Columns.Add("Category", typeof(string));
            MainForm.怪物DataSheet.Columns.Add("移动间隔", typeof(string));
            MainForm.怪物DataSheet.Columns.Add("漫游间隔", typeof(string));
            MainForm.怪物DataSheet.Columns.Add("RangeHate", typeof(string));
            MainForm.怪物DataSheet.Columns.Add("仇恨时长", typeof(string));
            MainForm.Singleton.怪物浏览表.DataSource = MainForm.怪物DataSheet;
            MainForm.掉落DataSheet = new DataTable("掉落数据表");
            MainForm.怪物掉落表 = new Dictionary<Monsters, List<KeyValuePair<GameItems, long>>>();
            MainForm.掉落DataSheet.Columns.Add("Name", typeof(string));
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

        
        private void 停止服务器_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sure to stop the server?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                MainProcess.Stop();
                this.停止按钮.Enabled = false;
            }
        }

        
        private void 关闭主界面_Click(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Sure to shut down the server?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                for (; ; )
                {
                    Thread 主线程 = MainProcess.MainThread;
                    if (主线程 == null || !主线程.IsAlive)
                    {
                        break;
                    }
                    MainProcess.Stop();
                    Thread.Sleep(1);
                }
                if (GameDataGateway.已经修改 && MessageBox.Show("Do I need to save data that has been modified but not yet saved?", "Save Data", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    GameDataGateway.SaveData();
                    GameDataGateway.CleanUp();
                    return;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        
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

        
        private void 清空系统日志_Click(object sender, EventArgs e)
        {
            this.系统日志.Clear();
            Control control = this.清空系统日志;
            this.保存系统日志.Enabled = false;
            control.Enabled = false;
        }

        
        private void 清空聊天日志_Click(object sender, EventArgs e)
        {
            this.聊天日志.Clear();
            Control control = this.清空聊天日志;
            this.保存聊天日志.Enabled = false;
            control.Enabled = false;
        }

        
        private void 清空命令日志_Click(object sender, EventArgs e)
        {
            this.命令日志.Clear();
            this.清空命令日志.Enabled = false;
        }

        
        private void 保存系统日志_Click(object sender, EventArgs e)
        {
            if (this.系统日志.Text != null && !(this.系统日志.Text == ""))
            {
                if (!Directory.Exists(".\\Log\\Sys"))
                {
                    Directory.CreateDirectory(".\\Log\\Sys");
                }
                File.WriteAllText(string.Format(".\\Log\\Sys\\{0:yyyy-MM-dd--HH-mm-ss}.txt", DateTime.Now), this.系统日志.Text.Replace("\n", "\r\n"));
                MainForm.AddSystemLog("The system log has been successfully saved");
                return;
            }
        }

        
        private void 保存聊天日志_Click(object sender, EventArgs e)
        {
            if (this.聊天日志.Text != null && !(this.聊天日志.Text == ""))
            {
                if (!Directory.Exists(".\\Log\\Chat"))
                {
                    Directory.CreateDirectory(".\\Log\\Chat");
                }
                File.WriteAllText(string.Format(".\\Log\\Chat\\{0:yyyy-MM-dd--HH-mm-ss}.txt", DateTime.Now), this.系统日志.Text);
                MainForm.AddSystemLog("The system log has been successfully saved");
                return;
            }
        }

        
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

        
        private void 选择数据目录_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
            {
                Description = "Please select folder"
            };
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                if (sender == this.S_浏览数据目录)
                {
                    CustomClass.GameDataPath = (Settings.Default.GameData目录 = (this.S_GameData目录.Text = folderBrowserDialog.SelectedPath));
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

        
        private void 更改设置Value_Value(object sender, EventArgs e)
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
                    case "S_TSPort":
                        CustomClass.TSPort = (Settings.Default.TSPort = (ushort)numericUpDown.Value);
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
                    case "S_GSPort":
                        CustomClass.GSPort = (Settings.Default.GSPort = (ushort)numericUpDown.Value);
                        break;
                    default:
                        MessageBox.Show("未知变量! " + numericUpDown.Name);
                        break;
                }

                Settings.Default.Save();
            }
        }

        
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
                    MainForm.添加命令日志("<= Command error, GM commands must start with '@' at the start. '@View' to see all available commands");
                }
                else if (this.GMCommand文本.Text.Trim(new char[]
                {
                    '@',
                    ' '
                }).Length == 0)
                {
                    MainForm.添加命令日志("<= Command error, GM commands can not be empty. Type '@View' to see all available commands");
                }
                else if (GMCommand.解析命令(this.GMCommand文本.Text, out GMCommand))
                {
                    if (GMCommand.ExecutionWay == ExecutionWay.前台立即执行)
                    {
                        GMCommand.Execute();
                    }
                    else if (GMCommand.ExecutionWay == ExecutionWay.优先后台执行)
                    {
                        if (MainProcess.Running)
                        {
                            MainProcess.CommandsQueue.Enqueue(GMCommand);
                        }
                        else
                        {
                            GMCommand.Execute();
                        }
                    }
                    else if (GMCommand.ExecutionWay == ExecutionWay.只能后台执行)
                    {
                        if (MainProcess.Running)
                        {
                            MainProcess.CommandsQueue.Enqueue(GMCommand);
                        }
                        else
                        {
                            MainForm.添加命令日志("<= Command execution failed, the current command can only be executed when the server is running, please start the server first");
                        }
                    }
                    else if (GMCommand.ExecutionWay == ExecutionWay.只能空闲执行)
                    {
                        if (!MainProcess.Running && (MainProcess.MainThread == null || !MainProcess.MainThread.IsAlive))
                        {
                            GMCommand.Execute();
                        }
                        else
                        {
                            MainForm.添加命令日志("<= Command execution failed, the current command can only be executed when the server is not running, please shut down the server first");
                        }
                    }
                    e.Handled = true;
                }
                this.GMCommand文本.Clear();
            }
        }

        
        private void 合并客户数据_Click(object sender, EventArgs e)
        {
            if (MainProcess.Running)
            {
                MessageBox.Show("Merging data can only be performed when the server is not running");
                return;
            }
            Dictionary<Type, DataTableBase> Data型表 = GameDataGateway.Data型表;
            if (Data型表 == null || Data型表.Count == 0)
            {
                MessageBox.Show("The current customer data needs to be loaded before it can be merged with the specified customer data");
                return;
            }
            if (!Directory.Exists(this.S_合并数据目录.Text))
            {
                MessageBox.Show("Please select a valid Data.db file directory");
                return;
            }
            if (!File.Exists(this.S_合并数据目录.Text + "\\Data.db"))
            {
                MessageBox.Show("The Data.db file was not found in the selected directory");
                return;
            }
            if (MessageBox.Show("This operation is irreversible, please make a backup of your data \r\n\r\n sure you want to do it?", "Dangerous operations", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                GameDataGateway.合并数据(this.S_合并数据目录.Text + "\\Data.db");
            }
        }

        
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
                if (toolStripMenuItem.Name == "右键菜单_复制CharName")
                {
                    Clipboard.SetDataObject(row["CharName"]);
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

        
        private void 开始公告按钮_Click(object sender, EventArgs e)
        {
            if (!MainProcess.Running || !this.停止按钮.Enabled)
            {
                Task.Run(delegate ()
                {
                    MessageBox.Show("The server is not started, please start the server first");
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
                    MessageBox.Show("System announcement cannot be opened, the announcement interval must be an integer greater than 0");
                });
                return;
            }
            int num2;
            if (!int.TryParse(dataGridViewRow.Cells["公告次数"].Value.ToString(), out num2) || num2 <= 0)
            {
                Task.Run(delegate ()
                {
                    MessageBox.Show("System announcement is not enabled, the number of announcements must be an integer greater than 0");
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
                MessageBox.Show("System announcement cannot be opened, announcement content cannot be empty");
            });
        }

        
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

        
        private void 定时发送公告_Tick(object sender, EventArgs e)
        {
            if (MainProcess.Running && MainForm.公告DataSheet.Count != 0)
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

        
        public static MainForm Singleton;

        
        private static DataTable CharacterDataTable;

        
        private static DataTable SkillData表;

        
        private static DataTable EquipmentData表;

        
        private static DataTable 背包DataSheet;

        
        private static DataTable 仓库DataSheet;

        
        private static DataTable MapsDataTable;

        
        private static DataTable 怪物DataSheet;

        
        private static DataTable 掉落DataSheet;

        
        private static DataTable 封禁DataSheet;

        
        private static Dictionary<CharacterData, DataRow> CharacterData行;

        
        private static Dictionary<DataRow, CharacterData> 数据行角色;

        
        private static Dictionary<GameMap, DataRow> MapsDataRow;

        
        private static Dictionary<Monsters, DataRow> 怪物数据行;

        
        private static Dictionary<DataRow, Monsters> 数据行怪物;

        
        private static Dictionary<string, DataRow> 封禁数据行;

        
        private static Dictionary<DataGridViewRow, DateTime> 公告DataSheet;

        
        private static Dictionary<CharacterData, List<KeyValuePair<ushort, SkillData>>> 角色技能表;

        
        private static Dictionary<CharacterData, List<KeyValuePair<byte, EquipmentData>>> 角色装备表;

        
        private static Dictionary<CharacterData, List<KeyValuePair<byte, ItemData>>> 角色背包表;

        
        private static Dictionary<CharacterData, List<KeyValuePair<byte, ItemData>>> 角色仓库表;

        
        private static Dictionary<Monsters, List<KeyValuePair<GameItems, long>>> 怪物掉落表;
    }
}
