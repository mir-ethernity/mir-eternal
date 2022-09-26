using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using GameServer.Maps;
using GameServer.Templates;
using GameServer.Networking;

namespace GameServer.Data
{

    [FastDataReturn(SearchFilder = "CharName")]
    public sealed class CharacterData : GameData
    {

        public int CharId => Index.V;


        public long CharExp
        {
            get => CurrentExp.V;
            set => CurrentExp.V = value;
        }


        public byte CharLevel
        {
            get
            {
                return this.Level.V;
            }
            set
            {
                if (this.Level.V == value)
                {
                    return;
                }
                this.Level.V = value;
                SystemData.Data.更新等级(this);
            }
        }


        public int CharPowerCombat
        {
            get => PowerCombat.V;
            set
            {
                if (PowerCombat.V == value)
                    return;
                PowerCombat.V = value;
                SystemData.Data.UpdatedPowerCombat(this);
            }
        }


        public int CharPKLevel
        {
            get => PkLevel.V;
            set
            {
                if (PkLevel.V == value)
                    return;
                PkLevel.V = value;
                SystemData.Data.UpdatedPKLevel(this);
            }
        }

        public long CharMaxExp => CharacterProgression.MaxExpTable[CharLevel];

        public int Ingots
        {
            get
            {
                if (!Currencies.TryGetValue(GameCurrency.Ingots, out int result))
                    return 0;
                return result;
            }
            set
            {
                Currencies[GameCurrency.Ingots] = value;
                MainForm.UpdatedCharacterData(this, nameof(Ingots), value);
            }
        }


        public int NumberGoldCoins
        {
            get
            {
                int result;
                if (!this.Currencies.TryGetValue(GameCurrency.Gold, out result))
                {
                    return 0;
                }
                return result;
            }
            set
            {
                this.Currencies[GameCurrency.Gold] = value;
                MainForm.UpdatedCharacterData(this, nameof(NumberGoldCoins), value);
            }
        }


        public int MasterRep
        {
            get
            {
                int result;
                if (!this.Currencies.TryGetValue(GameCurrency.FamousTeacherReputation, out result))
                {
                    return 0;
                }
                return result;
            }
            set
            {
                this.Currencies[GameCurrency.FamousTeacherReputation] = value;
                MainForm.UpdatedCharacterData(this, "MasterRep", value);
            }
        }


        public byte CharTeacherParam
        {
            get
            {
                if (CurrentTeacher != null)
                {
                    if (CurrentTeacher.MasterId == CharId)
                        return 2;
                    return 1;
                }
                else
                {
                    if (CharLevel < 30)
                        return 0;
                    return 2;
                }
            }
        }


        public TeamData CurrentTeam
        {
            get
            {
                return this.Team.V;
            }
            set
            {
                if (this.Team.V != value)
                {
                    this.Team.V = value;
                }
            }
        }


        public TeacherData CurrentTeacher
        {
            get
            {
                return this.Teacher.V;
            }
            set
            {
                if (this.Teacher.V != value)
                {
                    this.Teacher.V = value;
                }
            }
        }


        public GuildData CurrentGuild
        {
            get
            {
                return this.Guild.V;
            }
            set
            {
                if (this.Guild.V != value)
                {
                    this.Guild.V = value;
                }
            }
        }

        public SConnection ActiveConnection { get; set; }


        public void GetExperience(int experience)
        {
            if (this.CharLevel >= Config.MaxLevel && this.CharExp >= this.CharMaxExp)
            {
                return;
            }
            if ((this.CharExp += experience) > this.CharMaxExp && this.CharLevel < Config.MaxLevel)
            {
                while (this.CharExp >= this.CharMaxExp)
                {
                    this.CharExp -= this.CharMaxExp;
                    this.CharLevel += 1;
                }
            }
        }


        public void OnCharacterDisconnect()
        {
            this.ActiveConnection.Player = null;
            this.ActiveConnection = null;
            NetworkServiceGateway.ConnectionsOnline -= 1U;
            this.OfflineDate.V = MainProcess.CurrentTime;
            MainForm.UpdatedCharacterData(this, "OfflineDate", this.OfflineDate);
        }


        public void OnCharacterConnect(SConnection connection)
        {
            this.ActiveConnection = connection;
            NetworkServiceGateway.ConnectionsOnline += 1U;
            this.MacAddress.V = connection.MacAddress;
            this.NetAddress.V = connection.NetAddress;
            MainForm.UpdatedCharacterData(this, "OfflineDate", null);
            MainForm.AddSystemLog(string.Format("Player [{0}] [Level {1}] has entered the game", this.CharName, this.Level));
        }


        public void SendEmail(MailData mail)
        {
            mail.ShippingAddress.V = this;
            Mails.Add(mail);
            UnreadMails.Add(mail);
            ActiveConnection?.SendPacket(new 未读邮件提醒
            {
                邮件数量 = this.UnreadMails.Count
            });
        }


        public bool IsOnline(out SConnection connection)
        {
            connection = ActiveConnection;
            return connection != null;
        }

        public bool TryGetFreeSpaceAtInventory(out byte location)
        {
            for (byte b = 0; b < BackpackSize.V; b += 1)
            {
                if (!Backpack.ContainsKey(b))
                {
                    location = b;
                    return true;
                }
            }
            location = byte.MaxValue;
            return false;
        }

        public bool TryGetFreeSpacesAtInventory(byte count, out byte[] locations)
        {
            var tmp = new List<byte>();

            for (byte b = 0; b < BackpackSize.V && count > tmp.Count; b += 1)
            {
                if (!Backpack.ContainsKey(b))
                    tmp.Add(b);
            }

            locations = tmp.ToArray();

            return tmp.Count == count;
        }

        public CharacterQuest[] GetInProgressQuests()
        {
            return Quests.Where(x => x.CompleteDate.V == DateTime.MinValue).ToArray();
        }

        public CharacterData()
        {
        }

        public CharacterData(AccountData data, string name, GameObjectRace race, GameObjectGender gender, ObjectHairType hairType, ObjectHairColorType hairColor, ObjectFaceType faceType)
        {
            this.Level.V = 1;
            this.BackpackSize.V = 32;
            this.WarehouseSize.V = 16;
            this.ExtraBackpackSize.V = 32;

            this.Account.V = data;
            this.CharName.V = name;
            this.CharRace.V = race;
            this.CharGender.V = gender;
            this.HairType.V = hairType;
            this.HairColor.V = hairColor;
            this.FaceType.V = faceType;
            this.CreatedDate.V = MainProcess.CurrentTime;
            this.CurrentHP.V = CharacterProgression.GetData(race, 1)[GameObjectStats.MaxHP];
            this.CurrentMP.V = CharacterProgression.GetData(race, 1)[GameObjectStats.MaxMP];
            this.CurrentDir.V = ComputingClass.随机方向();
            this.CurrentMap.V = 142;
            this.RebirthMap.V = 142;
            this.CurrentCoords.V = MapGatewayProcess.GetMapInstance(142).ResurrectionArea.RandomCoords;
            this.Settings.SetValue(new uint[128].ToList<uint>());

            AddStarterCurrency();
            AddStarterItems();
            AddStarterSkills();

            GameDataGateway.CharacterDataTable.AddData(this, true);
            data.Characters.Add(this);
            this.OnLoadCompleted();
        }


        public override string ToString()
        {
            DataMonitor<string> DataMonitor = this.CharName;
            if (DataMonitor == null)
            {
                return null;
            }
            return DataMonitor.V;
        }

        private void AddStarterCurrency()
        {
            for (int i = 0; i <= 19; i++)
            {
                var currencyType = (GameCurrency)i;
                switch (currencyType)
                {
                    case GameCurrency.Gold:
                        Currencies[(GameCurrency)i] = 0;
                        break;
                    default:
                        Currencies[(GameCurrency)i] = 0;
                        break;
                }
            }
        }

        public void AddStarterSkills()
        {
            ushort basicInscriptionSkill;

            switch (CharRace.V)
            {
                case GameObjectRace.战士:
                    basicInscriptionSkill = 10300;
                    break;
                case GameObjectRace.法师:
                    basicInscriptionSkill = 25300;
                    break;
                case GameObjectRace.刺客:
                    basicInscriptionSkill = 15300;
                    break;
                case GameObjectRace.弓手:
                    basicInscriptionSkill = 20400;
                    break;
                case GameObjectRace.道士:
                    basicInscriptionSkill = 30000;
                    break;
                case GameObjectRace.龙枪:
                    basicInscriptionSkill = 12000;
                    break;
                default:
                    basicInscriptionSkill = 12000;
                    break;
            }

            if (InscriptionSkill.DataSheet.TryGetValue(basicInscriptionSkill, out InscriptionSkill inscriptionSkill))
            {
                SkillData SkillData = new SkillData(inscriptionSkill.SkillId);
                this.SkillData.Add(SkillData.SkillId.V, SkillData);
                this.ShorcutField[0] = SkillData;
                SkillData.ShorcutField.V = 0;
            }
        }

        private void AddStarterItems()
        {
            foreach (var inscriptionItem in InscriptionItems.AllInscriptionItems)
            {
                if (inscriptionItem.NeedGender != null && inscriptionItem.NeedGender != CharGender.V)
                    continue;

                if (inscriptionItem.NeedRace?.Length > 0 && !inscriptionItem.NeedRace.Contains(CharRace.V))
                    continue;

                if (!GameItems.DataSheet.TryGetValue(inscriptionItem.ItemId, out GameItems item))
                    continue;

                if (inscriptionItem.Backpack == ItemBackPack.人物穿戴 && item is not EquipmentItem)
                    continue;

                switch (inscriptionItem.Backpack)
                {
                    case ItemBackPack.人物背包:
                        for (var i = 0; i < (inscriptionItem.Quantity ?? 1); i++)
                            if (TryGetFreeSpaceAtInventory(out byte inventoryPosition))
                                Backpack[inventoryPosition] = item is EquipmentItem
                                    ? new EquipmentData((EquipmentItem)item, this, 1, inventoryPosition, false)
                                    : new ItemData(item, this, 1, inventoryPosition, 1);
                        break;
                    case ItemBackPack.人物穿戴:
                        var equipment = (EquipmentItem)item;
                        Equipment[equipment.Location] = new EquipmentData(equipment, this, 0, equipment.Location, false);
                        break;
                }
            }
        }

        public void AttachToEvents()
        {
            this.Account.更改事件 += delegate (AccountData O)
            {
                MainForm.UpdatedCharacterData(this, "AccNumber", O);
                MainForm.UpdatedCharacterData(this, "AccBlocking", (O.封禁日期.V != default(DateTime)) ? O.封禁日期 : null);
            };
            this.Account.V.封禁日期.更改事件 += delegate (DateTime O)
            {
                MainForm.UpdatedCharacterData(this, "AccBlocking", (O != default(DateTime)) ? O : null);
            };
            this.CharName.更改事件 += delegate (string O)
            {
                MainForm.UpdatedCharacterData(this, "CharName", O);
            };
            this.封禁日期.更改事件 += delegate (DateTime O)
            {
                MainForm.UpdatedCharacterData(this, "CharacterBlock", (O != default(DateTime)) ? O : null);
            };
            this.FreezeDate.更改事件 += delegate (DateTime O)
            {
                MainForm.UpdatedCharacterData(this, "FreezeDate", (O != default(DateTime)) ? O : null);
            };
            this.DateDelete.更改事件 += delegate (DateTime O)
            {
                MainForm.UpdatedCharacterData(this, "DateDelete", (O != default(DateTime)) ? O : null);
            };
            this.LoginDate.更改事件 += delegate (DateTime O)
            {
                MainForm.UpdatedCharacterData(this, "LoginDate", (O != default(DateTime)) ? O : null);
            };
            this.OfflineDate.更改事件 += delegate (DateTime O)
            {
                MainForm.UpdatedCharacterData(this, "OfflineDate", (this.ActiveConnection == null) ? O : null);
            };
            this.NetAddress.更改事件 += delegate (string O)
            {
                MainForm.UpdatedCharacterData(this, "NetAddress", O);
            };
            this.MacAddress.更改事件 += delegate (string O)
            {
                MainForm.UpdatedCharacterData(this, "MacAddress", O);
            };
            this.CharRace.更改事件 += delegate (GameObjectRace O)
            {
                MainForm.UpdatedCharacterData(this, "CharRole", O);
            };
            this.CharGender.更改事件 += delegate (GameObjectGender O)
            {
                MainForm.UpdatedCharacterData(this, "CharGender", O);
            };
            this.Guild.更改事件 += delegate (GuildData O)
            {
                MainForm.UpdatedCharacterData(this, "Affiliation", O);
            };
            this.DollarConsumption.更改事件 += delegate (long O)
            {
                MainForm.UpdatedCharacterData(this, "DollarConsumption", O);
            };
            this.TransferOutGoldCoins.更改事件 += delegate (long O)
            {
                MainForm.UpdatedCharacterData(this, "TransferOutGoldCoins", O);
            };
            this.BackpackSize.更改事件 += delegate (byte O)
            {
                MainForm.UpdatedCharacterData(this, "BackpackSize", O);
            };
            this.WarehouseSize.更改事件 += delegate (byte O)
            {
                MainForm.UpdatedCharacterData(this, "WarehouseSize", O);
            };
            this.CurrentPrivileges.更改事件 += delegate (byte O)
            {
                MainForm.UpdatedCharacterData(this, "CurrentPrivileges", O);
            };
            this.CurrentIssueDate.更改事件 += delegate (DateTime O)
            {
                MainForm.UpdatedCharacterData(this, "CurrentIssueDate", O);
            };
            this.PreviousPrivilege.更改事件 += delegate (byte O)
            {
                MainForm.UpdatedCharacterData(this, "PreviousPrivilege", O);
            };
            this.DateLastIssue.更改事件 += delegate (DateTime O)
            {
                MainForm.UpdatedCharacterData(this, "DateLastIssue", O);
            };
            this.RemainingPrivileges.更改事件 += delegate (List<KeyValuePair<byte, int>> O)
            {
                MainForm.UpdatedCharacterData(this, "RemainingPrivileges", O.Sum((KeyValuePair<byte, int> X) => X.Value));
            };
            this.Level.更改事件 += delegate (byte O)
            {
                MainForm.UpdatedCharacterData(this, "CurrentRank", O);
            };
            this.CurrentExp.更改事件 += delegate (long O)
            {
                MainForm.UpdatedCharacterData(this, "CurrentExp", O);
            };
            this.DoubleExp.更改事件 += delegate (int O)
            {
                MainForm.UpdatedCharacterData(this, "DoubleExp", O);
            };
            this.PowerCombat.更改事件 += delegate (int O)
            {
                MainForm.UpdatedCharacterData(this, "CurrentBattlePower", O);
            };
            this.CurrentMap.更改事件 += delegate (int O)
            {
                GameMap 游戏地图;
                MainForm.UpdatedCharacterData(this, "CurrentMap", GameMap.DataSheet.TryGetValue((byte)O, out 游戏地图) ? 游戏地图 : O);
            };
            this.CurrentCoords.更改事件 += delegate (Point O)
            {
                MainForm.UpdatedCharacterData(this, "CurrentCoords", string.Format("{0}, {1}", O.X, O.Y));
            };
            this.PkLevel.更改事件 += delegate (int O)
            {
                MainForm.UpdatedCharacterData(this, "PkLevel", O);
            };
            this.SkillData.更改事件 += delegate (List<KeyValuePair<ushort, SkillData>> O)
            {
                MainForm.UpdateCharactersSkills(this, O);
            };
            this.Equipment.更改事件 += delegate (List<KeyValuePair<byte, EquipmentData>> O)
            {
                MainForm.UpdateCharactersEquipment(this, O);
            };
            this.Backpack.更改事件 += delegate (List<KeyValuePair<byte, ItemData>> O)
            {
                MainForm.UpdateCharactersBackpack(this, O);
            };
            this.Warehouse.更改事件 += delegate (List<KeyValuePair<byte, ItemData>> O)
            {
                MainForm.更新角色仓库(this, O);
            };
        }

        public override void OnLoadCompleted()
        {
            AttachToEvents();
            MainForm.AddCharacterData(this);
            MainForm.UpdateCharactersSkills(this, this.SkillData.ToList<KeyValuePair<ushort, SkillData>>());
            MainForm.UpdateCharactersEquipment(this, this.Equipment.ToList<KeyValuePair<byte, EquipmentData>>());
            MainForm.UpdateCharactersBackpack(this, this.Backpack.ToList<KeyValuePair<byte, ItemData>>());
            MainForm.更新角色仓库(this, this.Warehouse.ToList<KeyValuePair<byte, ItemData>>());
        }

        public override void Delete()
        {
            this.Account.V.Characters.Remove(this);
            this.Account.V.冻结列表.Remove(this);
            this.Account.V.删除列表.Remove(this);

            this.升级装备.V?.Delete();

            foreach (var pet in PetData)
                pet.Delete();

            foreach (var mail in Mails)
                mail.Delete();

            foreach (var item in Backpack)
                item.Value.Delete();

            foreach (var item in Equipment)
                item.Value.Delete();

            foreach (var item in Warehouse)
                item.Value.Delete();

            foreach (var skill in SkillData)
                skill.Value.Delete();

            foreach (var buff in BuffData)
                buff.Value.Delete();

            foreach (var quest in Quests)
                quest.Delete();

            if (Team.V != null)
            {
                if (this == Team.V.队长数据)
                    Team.V.Delete();
                else
                    Team.V.Members.Remove(this);
            }

            if (Teacher.V != null)
            {
                if (this == Teacher.V.师父数据)
                    Teacher.V.Delete();
                else
                    Teacher.V.移除徒弟(this);
            }

            if (Guild.V != null)
            {
                Guild.V.行会成员.Remove(this);
                Guild.V.行会禁言.Remove(this);
            }

            foreach (CharacterData CharacterData in 好友列表)
                CharacterData.好友列表.Remove(this);

            foreach (CharacterData CharacterData2 in 粉丝列表)
                CharacterData2.偶像列表.Remove(this);

            foreach (CharacterData CharacterData3 in 仇恨列表)
                CharacterData3.仇人列表.Remove(this);

            base.Delete();
        }

        public byte[] 角色描述()
        {
            using var ms = new MemoryStream(new byte[94]);
            using var bw = new BinaryWriter(ms);
            角色描述(bw);
            return ms.ToArray();
        }

        public void 角色描述(BinaryWriter binaryWriter)
        {
            var name = 名字描述();
            var pos = (int)binaryWriter.BaseStream.Position;

            binaryWriter.Write(Index.V);
            binaryWriter.Write(name);
            binaryWriter.Write((byte)0);
            binaryWriter.Seek(pos + 61, SeekOrigin.Begin);
            binaryWriter.Write((byte)CharRace.V);
            binaryWriter.Write((byte)CharGender.V);
            binaryWriter.Write((byte)HairType.V);
            binaryWriter.Write((byte)HairColor.V);
            binaryWriter.Write((byte)FaceType.V);
            binaryWriter.Write((byte)0);
            binaryWriter.Write(CharLevel);
            binaryWriter.Write(CurrentMap.V);
            binaryWriter.Write(Equipment[0]?.升级次数.V ?? 0);
            binaryWriter.Write((Equipment[0]?.对应模板.V?.Id).GetValueOrDefault());
            binaryWriter.Write((Equipment[1]?.对应模板.V?.Id).GetValueOrDefault());
            binaryWriter.Write((Equipment[2]?.对应模板.V?.Id).GetValueOrDefault());
            binaryWriter.Write(ComputingClass.TimeShift(OfflineDate.V));
            binaryWriter.Write((!FreezeDate.V.Equals(default(DateTime))) ? ComputingClass.TimeShift(FreezeDate.V) : 0);

            binaryWriter.BaseStream.Seek(pos + 94, SeekOrigin.Begin);
        }


        public byte[] 名字描述()
        {
            return Encoding.UTF8.GetBytes(this.CharName.V);
        }


        public byte[] 角色设置()
        {
            byte[] result;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
                {
                    foreach (uint value in this.Settings)
                    {
                        binaryWriter.Write(value);
                    }
                    result = memoryStream.ToArray();
                }
            }
            return result;
        }


        public byte[] 邮箱描述()
        {
            byte[] result;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
                {
                    binaryWriter.Write((ushort)this.Mails.Count);
                    foreach (MailData MailData in this.Mails)
                    {
                        binaryWriter.Write(MailData.邮件检索描述());
                    }
                    result = memoryStream.ToArray();
                }
            }
            return result;
        }


        public readonly DataMonitor<string> CharName;


        public readonly DataMonitor<string> NetAddress;


        public readonly DataMonitor<string> MacAddress;


        public readonly DataMonitor<DateTime> CreatedDate;


        public readonly DataMonitor<DateTime> LoginDate;


        public readonly DataMonitor<DateTime> FreezeDate;


        public readonly DataMonitor<DateTime> DateDelete;


        public readonly DataMonitor<DateTime> OfflineDate;


        public readonly DataMonitor<DateTime> 监禁日期;


        public readonly DataMonitor<DateTime> 封禁日期;


        public readonly DataMonitor<TimeSpan> 灰名时间;


        public readonly DataMonitor<TimeSpan> 减PK时间;


        public readonly DataMonitor<DateTime> 武斗日期;


        public readonly DataMonitor<DateTime> 攻沙日期;


        public readonly DataMonitor<DateTime> 领奖日期;


        public readonly DataMonitor<DateTime> 屠魔大厅;


        public readonly DataMonitor<DateTime> 屠魔兑换;


        public readonly DataMonitor<int> 屠魔次数;


        public readonly DataMonitor<DateTime> 分解日期;


        public readonly DataMonitor<int> 分解经验;


        public readonly DataMonitor<GameObjectRace> CharRace;


        public readonly DataMonitor<GameObjectGender> CharGender;


        public readonly DataMonitor<ObjectHairType> HairType;


        public readonly DataMonitor<ObjectHairColorType> HairColor;


        public readonly DataMonitor<ObjectFaceType> FaceType;


        public readonly DataMonitor<int> CurrentHP;


        public readonly DataMonitor<int> CurrentMP;


        public readonly DataMonitor<byte> Level;


        public readonly DataMonitor<long> CurrentExp;


        public readonly DataMonitor<int> DoubleExp;


        public readonly DataMonitor<int> PowerCombat;


        public readonly DataMonitor<int> PkLevel;


        public readonly DataMonitor<int> CurrentMap;


        public readonly DataMonitor<int> RebirthMap;


        public readonly DataMonitor<Point> CurrentCoords;


        public readonly DataMonitor<GameDirection> CurrentDir;


        public readonly DataMonitor<AttackMode> AttackMode;


        public readonly DataMonitor<PetMode> PetMode;


        public readonly HashMonitor<PetData> PetData;


        public readonly DataMonitor<byte> BackpackSize;
        public readonly DataMonitor<byte> WarehouseSize;
        public readonly DataMonitor<byte> ExtraBackpackSize;

        public readonly DataMonitor<long> DollarConsumption;


        public readonly DataMonitor<long> TransferOutGoldCoins;


        public readonly ListMonitor<uint> Settings;


        public readonly DataMonitor<EquipmentData> 升级装备;


        public readonly DataMonitor<DateTime> 取回时间;


        public readonly DataMonitor<bool> 升级成功;


        public readonly DataMonitor<byte> CurrentTitle;


        public readonly MonitorDictionary<byte, int> 历史排名;


        public readonly MonitorDictionary<byte, int> 当前排名;


        public readonly MonitorDictionary<byte, DateTime> 称号列表;


        public readonly MonitorDictionary<GameCurrency, int> Currencies;


        public readonly MonitorDictionary<byte, ItemData> Backpack;
        public readonly MonitorDictionary<byte, ItemData> Warehouse;
        public readonly DataMonitor<bool> WarehouseLocked;
        public readonly MonitorDictionary<byte, ItemData> ExtraBackPack;
        public readonly MonitorDictionary<byte, EquipmentData> Equipment;
        public readonly MonitorDictionary<ushort, AchievementData> Achievements;
        public readonly MonitorDictionary<byte, int> AchievementVariables;


        public readonly MonitorDictionary<byte, SkillData> ShorcutField;


        public readonly MonitorDictionary<ushort, BuffData> BuffData;


        public readonly MonitorDictionary<ushort, SkillData> SkillData;


        public readonly MonitorDictionary<int, DateTime> 冷却数据;


        public readonly HashMonitor<MailData> Mails;


        public readonly HashMonitor<MailData> UnreadMails;


        public readonly DataMonitor<byte> 预定特权;


        public readonly DataMonitor<byte> CurrentPrivileges;


        public readonly DataMonitor<byte> PreviousPrivilege;


        public readonly DataMonitor<uint> 本期记录;


        public readonly DataMonitor<uint> 上期记录;


        public readonly DataMonitor<DateTime> CurrentIssueDate;


        public readonly DataMonitor<DateTime> DateLastIssue;


        public readonly DataMonitor<DateTime> 补给日期;


        public readonly DataMonitor<DateTime> 战备日期;


        public readonly MonitorDictionary<byte, int> RemainingPrivileges;


        public readonly DataMonitor<AccountData> Account;


        public readonly DataMonitor<TeamData> Team;


        public readonly DataMonitor<GuildData> Guild;


        public readonly DataMonitor<TeacherData> Teacher;


        public readonly HashMonitor<CharacterData> 好友列表;


        public readonly HashMonitor<CharacterData> 偶像列表;


        public readonly HashMonitor<CharacterData> 粉丝列表;


        public readonly HashMonitor<CharacterData> 仇人列表;


        public readonly HashMonitor<CharacterData> 仇恨列表;

        public readonly HashMonitor<CharacterData> 黑名单表;

        public readonly ListMonitor<ushort> Mounts;

        public readonly DataMonitor<ushort> CurrentMount;

        public readonly HashMonitor<CharacterQuest> Quests;
    }
}
