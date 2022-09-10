using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameServer.Data
{

    public static class GameDataGateway
    {

        public static bool 已经修改
        {
            get
            {
                return GameDataGateway.数据修改;
            }
            set
            {
                GameDataGateway.数据修改 = value;
                if (GameDataGateway.数据修改 && !MainProcess.Running && (MainProcess.MainThread == null || !MainProcess.MainThread.IsAlive))
                {
                    MainForm.Singleton.BeginInvoke(new MethodInvoker(delegate ()
                    {
                        MainForm.Singleton.保存按钮.Enabled = true;
                    }));
                }
            }
        }


        public static string UserFolder
        {
            get
            {
                return Config.GameDataPath + "\\User";
            }
        }


        public static string 备份目录
        {
            get
            {
                return Config.BackupFolder;
            }
        }


        public static string UserPath
        {
            get
            {
                return Config.GameDataPath + "\\User\\Data.db";
            }
        }


        public static string UserTempPath
        {
            get
            {
                return Config.GameDataPath + "\\User\\Temp.db";
            }
        }


        public static string UserBackupPath
        {
            get
            {
                return string.Format("{0}\\User-{1:yyyy-MM-dd-HH-mm-ss-ffff}.db.gz", Config.BackupFolder, MainProcess.CurrentTime);
            }
        }


        public static void 加载数据()
        {
            GameDataGateway.Data型表 = new Dictionary<Type, DataTableBase>();
            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (type.IsSubclassOf(typeof(GameData)))
                {
                    GameDataGateway.Data型表[type] = (DataTableBase)Activator.CreateInstance(typeof(DataTableCrud<>).MakeGenericType(new Type[]
                    {
                        type
                    }));
                }
            }
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
                {
                    binaryWriter.Write(GameDataGateway.Data型表.Count);
                    foreach (KeyValuePair<Type, DataTableBase> keyValuePair in GameDataGateway.Data型表)
                    {
                        keyValuePair.Value.CurrentMappingVersion.保存映射描述(binaryWriter);
                    }
                    GameDataGateway.表头描述 = memoryStream.ToArray();
                }
            }
            if (File.Exists(GameDataGateway.UserPath))
            {
                using (BinaryReader binaryReader = new BinaryReader(File.OpenRead(GameDataGateway.UserPath)))
                {
                    List<DataMapping> list = new List<DataMapping>();
                    int num = binaryReader.ReadInt32();
                    for (int j = 0; j < num; j++)
                    {
                        list.Add(new DataMapping(binaryReader));
                    }
                    List<Task> list2 = new List<Task>();
                    using (List<DataMapping>.Enumerator enumerator2 = list.GetEnumerator())
                    {
                        while (enumerator2.MoveNext())
                        {
                            DataMapping 当前历史映射 = enumerator2.Current;
                            byte[] 历史映射数据 = binaryReader.ReadBytes(binaryReader.ReadInt32());
                            DataTableBase 存表实例;
                            if (!(当前历史映射.DataType == null) && GameDataGateway.Data型表.TryGetValue(当前历史映射.DataType, out 存表实例))
                            {
                                list2.Add(Task.Run(delegate ()
                                {
                                    存表实例.LoadData(历史映射数据, 当前历史映射);
                                }));
                            }
                        }
                    }
                    if (list2.Count > 0)
                    {
                        Task.WaitAll(list2.ToArray());
                    }
                }
            }
            if (GameDataGateway.Data型表[typeof(SystemData)].DataSheet.Count == 0)
            {
                new SystemData(1);
            }
            GameDataGateway.AccountData表 = (GameDataGateway.Data型表[typeof(AccountData)] as DataTableCrud<AccountData>);
            GameDataGateway.CharacterDataTable = (GameDataGateway.Data型表[typeof(CharacterData)] as DataTableCrud<CharacterData>);
            GameDataGateway.CharacterQuestDataTable = (GameDataGateway.Data型表[typeof(CharacterQuest)] as DataTableCrud<CharacterQuest>);
            GameDataGateway.CharacterQuestConstraintDataTable = (GameDataGateway.Data型表[typeof(CharacterQuestMission)] as DataTableCrud<CharacterQuestMission>);
            GameDataGateway.PetDataTable = (GameDataGateway.Data型表[typeof(PetData)] as DataTableCrud<PetData>);
            GameDataGateway.ItemData表 = (GameDataGateway.Data型表[typeof(ItemData)] as DataTableCrud<ItemData>);
            GameDataGateway.EquipmentData表 = (GameDataGateway.Data型表[typeof(EquipmentData)] as DataTableCrud<EquipmentData>);
            GameDataGateway.SkillData表 = (GameDataGateway.Data型表[typeof(SkillData)] as DataTableCrud<SkillData>);
            GameDataGateway.BuffData表 = (GameDataGateway.Data型表[typeof(BuffData)] as DataTableCrud<BuffData>);
            GameDataGateway.TeamData表 = (GameDataGateway.Data型表[typeof(TeamData)] as DataTableCrud<TeamData>);
            GameDataGateway.GuildData表 = (GameDataGateway.Data型表[typeof(GuildData)] as DataTableCrud<GuildData>);
            GameDataGateway.TeacherData表 = (GameDataGateway.Data型表[typeof(TeacherData)] as DataTableCrud<TeacherData>);
            GameDataGateway.MailData表 = (GameDataGateway.Data型表[typeof(MailData)] as DataTableCrud<MailData>);
            
            DataLinkTable.处理任务();
            foreach (KeyValuePair<int, GameData> keyValuePair2 in GameDataGateway.CharacterDataTable.DataSheet)
            {
                keyValuePair2.Value.OnLoadCompleted();
            }
            SystemData.Data.OnLoadCompleted();
        }


        public static void SaveData()
        {
            Parallel.ForEach(Data型表.Values, (DataTableBase x) => x.保存数据());
        }


        public static void 强制保存()
        {
            Parallel.ForEach<DataTableBase>(GameDataGateway.Data型表.Values, delegate (DataTableBase x)
            {
                x.强制保存();
            });
        }

        public static void PersistData()
        {
            if (!Directory.Exists(UserFolder))
                Directory.CreateDirectory(UserFolder);

            using var binaryWriter = new BinaryWriter(File.Create(UserPath));

            binaryWriter.Write(表头描述);
            foreach (KeyValuePair<Type, DataTableBase> keyValuePair in Data型表)
            {
                byte[] array = keyValuePair.Value.SaveData();
                binaryWriter.Write(array.Length);
                binaryWriter.Write(array);
            }
        }

        public static void CleanUp()
        {
            if (!Directory.Exists(UserFolder))
                Directory.CreateDirectory(UserFolder);

            using (BinaryWriter binaryWriter = new BinaryWriter(File.Create(UserTempPath)))
            {
                binaryWriter.Write(表头描述);
                foreach (KeyValuePair<Type, DataTableBase> keyValuePair in Data型表)
                {
                    byte[] array = keyValuePair.Value.SaveData();
                    binaryWriter.Write(array.Length);
                    binaryWriter.Write(array);
                }
            }

            if (!Directory.Exists(Config.BackupFolder))
                Directory.CreateDirectory(Config.BackupFolder);

            if (File.Exists(UserPath))
            {
                using (FileStream fileStream = File.OpenRead(UserPath))
                using (FileStream fileStream2 = File.Create(UserBackupPath))
                using (GZipStream gzipStream = new GZipStream(fileStream2, CompressionMode.Compress))
                {
                    fileStream.CopyTo(gzipStream);
                }
                File.Delete(UserPath);
            }
            File.Move(UserTempPath, UserPath);
            已经修改 = false;
        }


        public static void SortDataCommand(bool 保存数据)
        {
            int num = 0;
            foreach (KeyValuePair<Type, DataTableBase> keyValuePair in GameDataGateway.Data型表)
            {
                int num2 = 0;
                if (keyValuePair.Value.DataType == typeof(GuildData))
                {
                    num2 = 1610612736;
                }
                if (keyValuePair.Value.DataType == typeof(TeamData))
                {
                    num2 = 1879048192;
                }
                List<GameData> list = (from O in keyValuePair.Value.DataSheet.Values
                                       orderby O.Index.V
                                       select O).ToList<GameData>();
                int num3 = 0;
                for (int i = 0; i < list.Count; i++)
                {
                    int num4 = num2 + i + 1;
                    GameData GameData = list[i];
                    if (GameData.Index.V != num4)
                    {
                        if (GameData is CharacterData)
                        {
                            using (Dictionary<int, GameData>.Enumerator enumerator2 = GameDataGateway.GuildData表.DataSheet.GetEnumerator())
                            {
                                while (enumerator2.MoveNext())
                                {
                                    KeyValuePair<int, GameData> keyValuePair2 = enumerator2.Current;
                                    foreach (GuildEvents GuildEvents in ((GuildData)keyValuePair2.Value).GuildEvents)
                                    {
                                        switch (GuildEvents.MemorandumType)
                                        {
                                            case MemorandumType.创建公会:
                                            case MemorandumType.加入公会:
                                            case MemorandumType.离开公会:
                                                if (GuildEvents.第一参数 == GameData.Index.V)
                                                {
                                                    GuildEvents.第一参数 = num4;
                                                }
                                                break;
                                            case MemorandumType.逐出公会:
                                            case MemorandumType.变更职位:
                                            case MemorandumType.会长传位:
                                                if (GuildEvents.第一参数 == GameData.Index.V)
                                                {
                                                    GuildEvents.第一参数 = num4;
                                                }
                                                if (GuildEvents.第二参数 == GameData.Index.V)
                                                {
                                                    GuildEvents.第二参数 = num4;
                                                }
                                                break;
                                        }
                                    }
                                }
                                goto IL_37E;
                            }
                        }
                        if (GameData is GuildData)
                        {
                            using (Dictionary<int, GameData>.Enumerator enumerator2 = GameDataGateway.GuildData表.DataSheet.GetEnumerator())
                            {
                                while (enumerator2.MoveNext())
                                {
                                    KeyValuePair<int, GameData> keyValuePair3 = enumerator2.Current;
                                    foreach (GuildEvents GuildEvents2 in ((GuildData)keyValuePair3.Value).GuildEvents)
                                    {
                                        MemorandumType MemorandumType = GuildEvents2.MemorandumType;
                                        if (MemorandumType - MemorandumType.行会结盟 <= 1 || MemorandumType - MemorandumType.取消结盟 <= 1)
                                        {
                                            if (GuildEvents2.第一参数 == GameData.Index.V)
                                            {
                                                GuildEvents2.第一参数 = num4;
                                            }
                                            if (GuildEvents2.第二参数 == GameData.Index.V)
                                            {
                                                GuildEvents2.第二参数 = num4;
                                            }
                                        }
                                    }
                                }
                                goto IL_37E;
                            }
                            goto IL_2D7;
                        }
                    IL_37E:
                        GameData.Index.V = num4;
                        num3++;
                    }
                IL_2D7:;
                }
                keyValuePair.Value.CurrentIndex = list.Count + num2;
                num += num3;
                keyValuePair.Value.DataSheet = keyValuePair.Value.DataSheet.ToDictionary((KeyValuePair<int, GameData> x) => x.Value.Index.V, (KeyValuePair<int, GameData> x) => x.Value);
                MainForm.AddCommandLog(string.Format("{0} Sorted, Quantity sorted: {1}", keyValuePair.Key.Name, num3));
            }
            MainForm.AddCommandLog(string.Format("The customer data has been collated, and the totals collated: {0}", num));
            if (num > 0 && 保存数据)
            {
                MainForm.AddCommandLog("It may take a while to re-save the collated customer data, please wait...");
                GameDataGateway.强制保存();
                GameDataGateway.CleanUp();
                MainForm.AddCommandLog("Data has been saved to disk");
                MessageBox.Show("Customer data has been collated, application needs to be restarted");
                Environment.Exit(0);
            }
        }


        public static void CleanCharacters(int MinLevel, int 限制天数)
        {
            MainForm.AddCommandLog("Start Clean Characters data...");
            DateTime t = DateTime.Now.AddDays((double)(-(double)限制天数));
            int num = 0;
            foreach (GameData GameData in GameDataGateway.CharacterDataTable.DataSheet.Values.ToList<GameData>())
            {
                CharacterData CharacterData = GameData as CharacterData;
                if (CharacterData != null && (int)CharacterData.Level.V < MinLevel && !(CharacterData.OfflineDate.V > t))
                {
                    if (CharacterData.当前排名.Count > 0)
                    {
                        MainForm.AddCommandLog(string.Format("[{0}]({1}/{2}) In the leaderboard, skipped cleanup", CharacterData, CharacterData.Level, (int)(DateTime.Now - CharacterData.OfflineDate.V).TotalDays));
                    }
                    else if (CharacterData.Ingots > 0)
                    {
                        MainForm.AddCommandLog(string.Format("[{0}]({1}/{2}) There are unspent treasures, cleanup has been skipped", CharacterData, CharacterData.Level, (int)(DateTime.Now - CharacterData.OfflineDate.V).TotalDays));
                    }
                    else
                    {
                        GuildData 当前行会 = CharacterData.CurrentGuild;
                        if (((当前行会 != null) ? 当前行会.会长数据 : null) == CharacterData)
                        {
                            MainForm.AddCommandLog(string.Format("[{0}]({1}/{2}) t's the president of the guild, skipped cleanup", CharacterData, CharacterData.Level, (int)(DateTime.Now - CharacterData.OfflineDate.V).TotalDays));
                        }
                        else
                        {
                            MainForm.AddCommandLog(string.Format("Start cleaning [{0}]({1}/{2})...", CharacterData, CharacterData.Level, (int)(DateTime.Now - CharacterData.OfflineDate.V).TotalDays));
                            CharacterData.Delete();
                            num++;
                            MainForm.RemoveCharacter(CharacterData);
                        }
                    }
                }
            }
            MainForm.AddCommandLog(string.Format("Character Data has been cleaned up, and the total has been cleared: {0}", num));
            if (num > 0)
            {
                MainForm.AddCommandLog("It may take a while to re-save the cleaned customer data, please wait...");
                GameDataGateway.SaveData();
                GameDataGateway.CleanUp();
                GameDataGateway.加载数据();
                MainForm.AddCommandLog("Data has been saved to disk");
            }
        }


        public static void 合并数据(string 数据文件)
        {
            MainForm 主界面 = MainForm.Singleton;
            if (主界面 == null)
            {
                return;
            }
            主界面.BeginInvoke(new MethodInvoker(delegate ()
            {
                TabPage 设置页面 = MainForm.Singleton.tabConfig;
                MainForm.Singleton.下方控件页.Enabled = false;
                设置页面.Enabled = false;
                MainForm.Singleton.主选项卡.SelectedIndex = 0;
                MainForm.Singleton.MainTabs.SelectedIndex = 2;
                MainForm.AddCommandLog("Start collating current customer data...");
                GameDataGateway.SortDataCommand(false);
                Dictionary<Type, DataTableBase> dictionary = GameDataGateway.Data型表;
                MainForm.AddCommandLog("Start loading the specified customer data...");
                GameDataGateway.Data型表 = new Dictionary<Type, DataTableBase>();
                foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
                {
                    if (type.IsSubclassOf(typeof(GameData)))
                    {
                        GameDataGateway.Data型表[type] = (DataTableBase)Activator.CreateInstance(typeof(DataTableCrud<>).MakeGenericType(new Type[]
                        {
                            type
                        }));
                    }
                }
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
                    {
                        binaryWriter.Write(GameDataGateway.Data型表.Count);
                        foreach (KeyValuePair<Type, DataTableBase> keyValuePair in GameDataGateway.Data型表)
                        {
                            keyValuePair.Value.CurrentMappingVersion.保存映射描述(binaryWriter);
                        }
                        GameDataGateway.表头描述 = memoryStream.ToArray();
                    }
                }
                if (File.Exists(数据文件))
                {
                    using (BinaryReader binaryReader = new BinaryReader(File.OpenRead(数据文件)))
                    {
                        List<DataMapping> list = new List<DataMapping>();
                        int num = binaryReader.ReadInt32();
                        for (int j = 0; j < num; j++)
                        {
                            list.Add(new DataMapping(binaryReader));
                        }
                        List<Task> list2 = new List<Task>();
                        using (List<DataMapping>.Enumerator enumerator2 = list.GetEnumerator())
                        {
                            while (enumerator2.MoveNext())
                            {
                                DataMapping 当前历史映射 = enumerator2.Current;
                                byte[] 历史映射数据 = binaryReader.ReadBytes(binaryReader.ReadInt32());
                                DataTableBase 存表实例;
                                if (!(当前历史映射.DataType == null) && GameDataGateway.Data型表.TryGetValue(当前历史映射.DataType, out 存表实例))
                                {
                                    list2.Add(Task.Run(delegate ()
                                    {
                                        存表实例.LoadData(历史映射数据, 当前历史映射);
                                    }));
                                }
                            }
                        }
                        if (list2.Count > 0)
                        {
                            Task.WaitAll(list2.ToArray());
                        }
                    }
                }
                MainForm.AddCommandLog("Start collating specified customer data...");
                DataLinkTable.处理任务();
                GameDataGateway.SortDataCommand(false);
                Dictionary<Type, DataTableBase> dictionary2 = GameDataGateway.Data型表;
                foreach (KeyValuePair<Type, DataTableBase> keyValuePair2 in dictionary)
                {
                    if (dictionary2.ContainsKey(keyValuePair2.Key))
                    {
                        if (keyValuePair2.Key == typeof(AccountData))
                        {
                            DataTableCrud<AccountData> DataTableExample = dictionary[keyValuePair2.Key] as DataTableCrud<AccountData>;
                            using (Dictionary<int, GameData>.Enumerator enumerator3 = (dictionary2[keyValuePair2.Key] as DataTableCrud<AccountData>).DataSheet.GetEnumerator())
                            {
                                while (enumerator3.MoveNext())
                                {
                                    KeyValuePair<int, GameData> keyValuePair3 = enumerator3.Current;
                                    AccountData AccountData = keyValuePair3.Value as AccountData;
                                    GameData GameData;
                                    if (DataTableExample.Keyword.TryGetValue(AccountData.Account.V, out GameData))
                                    {
                                        AccountData AccountData2 = GameData as AccountData;
                                        if (AccountData2 != null)
                                        {
                                            foreach (CharacterData CharacterData in AccountData.Characters)
                                            {
                                                AccountData2.Characters.Add(CharacterData);
                                                CharacterData.Account.V = AccountData2;
                                            }
                                            foreach (CharacterData CharacterData2 in AccountData.冻结列表)
                                            {
                                                AccountData2.冻结列表.Add(CharacterData2);
                                                CharacterData2.Account.V = AccountData2;
                                            }
                                            foreach (CharacterData CharacterData3 in AccountData.删除列表)
                                            {
                                                AccountData2.删除列表.Add(CharacterData3);
                                                CharacterData3.Account.V = AccountData2;
                                            }
                                            AccountData2.封禁日期.V = ((AccountData2.封禁日期.V <= AccountData.封禁日期.V) ? AccountData2.封禁日期.V : AccountData.封禁日期.V);
                                            AccountData2.DateDelete.V = default(DateTime);
                                            continue;
                                        }
                                    }
                                    keyValuePair2.Value.AddData(AccountData, true);
                                }
                                continue;
                            }
                        }
                        if (keyValuePair2.Key == typeof(CharacterData))
                        {
                            DataTableCrud<CharacterData> DataTableExample2 = dictionary[keyValuePair2.Key] as DataTableCrud<CharacterData>;
                            using (Dictionary<int, GameData>.Enumerator enumerator3 = (dictionary2[keyValuePair2.Key] as DataTableCrud<CharacterData>).DataSheet.GetEnumerator())
                            {
                                while (enumerator3.MoveNext())
                                {
                                    KeyValuePair<int, GameData> keyValuePair4 = enumerator3.Current;
                                    CharacterData CharacterData4 = keyValuePair4.Value as CharacterData;
                                    GameData GameData2;
                                    if (DataTableExample2.Keyword.TryGetValue(CharacterData4.CharName.V, out GameData2))
                                    {
                                        CharacterData CharacterData5 = GameData2 as CharacterData;
                                        if (CharacterData5 != null)
                                        {
                                            if (CharacterData5.CreatedDate.V > CharacterData4.CreatedDate.V)
                                            {
                                                DataMonitor<string> CharName = CharacterData5.CharName;
                                                CharName.V += "_";
                                            }
                                            else
                                            {
                                                DataMonitor<string> CharName2 = CharacterData4.CharName;
                                                CharName2.V += "_";
                                            }
                                        }
                                    }
                                    keyValuePair2.Value.AddData(CharacterData4, true);
                                }
                                continue;
                            }
                        }
                        if (keyValuePair2.Key == typeof(GuildData))
                        {
                            DataTableCrud<GuildData> DataTableExample3 = dictionary[keyValuePair2.Key] as DataTableCrud<GuildData>;
                            using (Dictionary<int, GameData>.Enumerator enumerator3 = (dictionary2[keyValuePair2.Key] as DataTableCrud<GuildData>).DataSheet.GetEnumerator())
                            {
                                while (enumerator3.MoveNext())
                                {
                                    KeyValuePair<int, GameData> keyValuePair5 = enumerator3.Current;
                                    GuildData GuildData = keyValuePair5.Value as GuildData;
                                    GameData GameData3;
                                    if (DataTableExample3.Keyword.TryGetValue(GuildData.GuildName.V, out GameData3))
                                    {
                                        GuildData GuildData2 = GameData3 as GuildData;
                                        if (GuildData2 != null)
                                        {
                                            if (GuildData2.CreatedDate.V > GuildData.CreatedDate.V)
                                            {
                                                DataMonitor<string> GuildName = GuildData2.GuildName;
                                                GuildName.V += "_";
                                            }
                                            else
                                            {
                                                DataMonitor<string> GuildName2 = GuildData.GuildName;
                                                GuildName2.V += "_";
                                            }
                                        }
                                    }
                                    keyValuePair2.Value.AddData(GuildData, true);
                                }
                                continue;
                            }
                        }
                        foreach (KeyValuePair<int, GameData> keyValuePair6 in dictionary2[keyValuePair2.Key].DataSheet)
                        {
                            keyValuePair2.Value.AddData(keyValuePair6.Value, true);
                        }
                    }
                }
                dictionary2[typeof(SystemData)].DataSheet.Clear();
                dictionary[typeof(SystemData)].DataSheet.Clear();
                dictionary[typeof(SystemData)].DataSheet[1] = new SystemData(1);
                foreach (KeyValuePair<int, GameData> keyValuePair7 in dictionary[typeof(GuildData)].DataSheet)
                {
                    ((GuildData)keyValuePair7.Value).行会排名.V = 0;
                }
                foreach (KeyValuePair<int, GameData> keyValuePair8 in dictionary[typeof(CharacterData)].DataSheet)
                {
                    ((CharacterData)keyValuePair8.Value).历史排名.Clear();
                    ((CharacterData)keyValuePair8.Value).当前排名.Clear();
                }
                GameDataGateway.Data型表 = dictionary;
                GameDataGateway.强制保存();
                GameDataGateway.CleanUp();
                MainForm.AddCommandLog("The consolidation of customer data is complete");
                MessageBox.Show("Customer data has been merged, application needs to be restarted");
                Environment.Exit(0);
            }));
        }


        private static bool 数据修改;


        private static byte[] 表头描述;


        public static DataTableCrud<AccountData> AccountData表;


        public static DataTableCrud<CharacterData> CharacterDataTable;

        public static DataTableCrud<CharacterQuest> CharacterQuestDataTable;

        public static DataTableCrud<CharacterQuestMission> CharacterQuestConstraintDataTable;


        public static DataTableCrud<PetData> PetDataTable;


        public static DataTableCrud<ItemData> ItemData表;


        public static DataTableCrud<EquipmentData> EquipmentData表;


        public static DataTableCrud<SkillData> SkillData表;


        public static DataTableCrud<BuffData> BuffData表;


        public static DataTableCrud<TeamData> TeamData表;


        public static DataTableCrud<GuildData> GuildData表;


        public static DataTableCrud<TeacherData> TeacherData表;


        public static DataTableCrud<MailData> MailData表;


        public static Dictionary<Type, DataTableBase> Data型表;
    }
}
