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

    [FastDataReturnAttribute(检索字段 = "CharName")]
    public sealed class CharacterData : GameData
    {

        // (get) Token: 0x060005CE RID: 1486 RVA: 0x000054C0 File Offset: 0x000036C0
        public int 角色编号
        {
            get
            {
                return this.数据索引.V;
            }
        }


        // (get) Token: 0x060005CF RID: 1487 RVA: 0x000055DE File Offset: 0x000037DE
        // (set) Token: 0x060005D0 RID: 1488 RVA: 0x000055EB File Offset: 0x000037EB
        public int 角色经验
        {
            get
            {
                return this.当前经验.V;
            }
            set
            {
                this.当前经验.V = value;
            }
        }


        // (get) Token: 0x060005D1 RID: 1489 RVA: 0x000055F9 File Offset: 0x000037F9
        // (set) Token: 0x060005D2 RID: 1490 RVA: 0x00005606 File Offset: 0x00003806
        public byte 角色等级
        {
            get
            {
                return this.当前等级.V;
            }
            set
            {
                if (this.当前等级.V == value)
                {
                    return;
                }
                this.当前等级.V = value;
                SystemData.Data.更新等级(this);
            }
        }


        // (get) Token: 0x060005D3 RID: 1491 RVA: 0x0000562E File Offset: 0x0000382E
        // (set) Token: 0x060005D4 RID: 1492 RVA: 0x0000563B File Offset: 0x0000383B
        public int 角色战力
        {
            get
            {
                return this.当前战力.V;
            }
            set
            {
                if (this.当前战力.V == value)
                {
                    return;
                }
                this.当前战力.V = value;
                SystemData.Data.更新战力(this);
            }
        }


        // (get) Token: 0x060005D5 RID: 1493 RVA: 0x00005663 File Offset: 0x00003863
        // (set) Token: 0x060005D6 RID: 1494 RVA: 0x00005670 File Offset: 0x00003870
        public int 角色PK值
        {
            get
            {
                return this.当前PK值.V;
            }
            set
            {
                if (this.当前PK值.V == value)
                {
                    return;
                }
                this.当前PK值.V = value;
                SystemData.Data.更新PK值(this);
            }
        }


        // (get) Token: 0x060005D7 RID: 1495 RVA: 0x00005698 File Offset: 0x00003898
        public int 所需经验
        {
            get
            {
                return 角色成长.升级所需经验[this.角色等级];
            }
        }


        // (get) Token: 0x060005D8 RID: 1496 RVA: 0x0002C4DC File Offset: 0x0002A6DC
        // (set) Token: 0x060005D9 RID: 1497 RVA: 0x000056AA File Offset: 0x000038AA
        public int 元宝数量
        {
            get
            {
                int result;
                if (!this.角色货币.TryGetValue(GameCurrency.元宝, out result))
                {
                    return 0;
                }
                return result;
            }
            set
            {
                this.角色货币[GameCurrency.元宝] = value;
                MainForm.更新CharacterData(this, "元宝数量", value);
            }
        }


        // (get) Token: 0x060005DA RID: 1498 RVA: 0x0002C4FC File Offset: 0x0002A6FC
        // (set) Token: 0x060005DB RID: 1499 RVA: 0x000056CA File Offset: 0x000038CA
        public int NumberGoldCoins
        {
            get
            {
                int result;
                if (!this.角色货币.TryGetValue(GameCurrency.金币, out result))
                {
                    return 0;
                }
                return result;
            }
            set
            {
                this.角色货币[GameCurrency.金币] = value;
                MainForm.更新CharacterData(this, "NumberGoldCoins", value);
            }
        }


        // (get) Token: 0x060005DC RID: 1500 RVA: 0x0002C51C File Offset: 0x0002A71C
        // (set) Token: 0x060005DD RID: 1501 RVA: 0x000056EA File Offset: 0x000038EA
        public int 师门声望
        {
            get
            {
                int result;
                if (!this.角色货币.TryGetValue(GameCurrency.名师声望, out result))
                {
                    return 0;
                }
                return result;
            }
            set
            {
                this.角色货币[GameCurrency.名师声望] = value;
                MainForm.更新CharacterData(this, "师门声望", value);
            }
        }


        // (get) Token: 0x060005DE RID: 1502 RVA: 0x0000570A File Offset: 0x0000390A
        public byte 师门参数
        {
            get
            {
                if (this.当前师门 != null)
                {
                    if (this.当前师门.师父编号 == this.角色编号)
                    {
                        return 2;
                    }
                    return 1;
                }
                else
                {
                    if (this.角色等级 < 30)
                    {
                        return 0;
                    }
                    return 2;
                }
            }
        }


        // (get) Token: 0x060005DF RID: 1503 RVA: 0x00005738 File Offset: 0x00003938
        // (set) Token: 0x060005E0 RID: 1504 RVA: 0x00005745 File Offset: 0x00003945
        public TeamData 当前队伍
        {
            get
            {
                return this.所属队伍.V;
            }
            set
            {
                if (this.所属队伍.V != value)
                {
                    this.所属队伍.V = value;
                }
            }
        }


        // (get) Token: 0x060005E1 RID: 1505 RVA: 0x00005761 File Offset: 0x00003961
        // (set) Token: 0x060005E2 RID: 1506 RVA: 0x0000576E File Offset: 0x0000396E
        public TeacherData 当前师门
        {
            get
            {
                return this.所属师门.V;
            }
            set
            {
                if (this.所属师门.V != value)
                {
                    this.所属师门.V = value;
                }
            }
        }


        // (get) Token: 0x060005E3 RID: 1507 RVA: 0x0000578A File Offset: 0x0000398A
        // (set) Token: 0x060005E4 RID: 1508 RVA: 0x00005797 File Offset: 0x00003997
        public GuildData 当前行会
        {
            get
            {
                return this.所属行会.V;
            }
            set
            {
                if (this.所属行会.V != value)
                {
                    this.所属行会.V = value;
                }
            }
        }


        // (get) Token: 0x060005E5 RID: 1509 RVA: 0x000057B3 File Offset: 0x000039B3
        // (set) Token: 0x060005E6 RID: 1510 RVA: 0x000057BB File Offset: 0x000039BB
        public SConnection ActiveConnection { get; set; }


        public void 获得经验(int 经验值)
        {
            if (this.角色等级 >= Config.游戏OpenLevelCommand && this.角色经验 >= this.所需经验)
            {
                return;
            }
            if ((this.角色经验 += 经验值) > this.所需经验 && this.角色等级 < Config.游戏OpenLevelCommand)
            {
                while (this.角色经验 >= this.所需经验)
                {
                    this.角色经验 -= this.所需经验;
                    this.角色等级 += 1;
                }
            }
        }


        public void 角色下线()
        {
            this.ActiveConnection.Player = null;
            this.ActiveConnection = null;
            NetworkServiceGateway.ConnectionsOnline -= 1U;
            this.OfflineDate.V = MainProcess.CurrentTime;
            MainForm.更新CharacterData(this, "离线日期", this.OfflineDate);
        }


        public void 角色上线(SConnection 网络)
        {
            this.ActiveConnection = 网络;
            NetworkServiceGateway.ConnectionsOnline += 1U;
            this.物理地址.V = 网络.物理地址;
            this.网络地址.V = 网络.网络地址;
            MainForm.更新CharacterData(this, "离线日期", null);
            MainForm.AddSystemLog(string.Format("Player [{0}] [Level {1}] has entered the game", this.CharName, this.当前等级));
        }


        public void 发送邮件(MailData 邮件)
        {
            邮件.收件地址.V = this;
            this.角色邮件.Add(邮件);
            this.未读邮件.Add(邮件);
            SConnection 网络连接 = this.ActiveConnection;
            if (网络连接 == null)
            {
                return;
            }
            网络连接.发送封包(new 未读邮件提醒
            {
                邮件数量 = this.未读邮件.Count
            });
        }


        public bool 角色在线(out SConnection 网络)
        {
            网络 = this.ActiveConnection;
            return 网络 != null;
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


        public CharacterData()
        {


        }


        public CharacterData(AccountData 账号, string 名字, GameObjectRace 职业, GameObjectGender 性别, ObjectHairType 发型, ObjectHairColorType 发色, ObjectFaceType 脸型)
        {
            this.当前等级.V = 1;
            this.BackpackSize.V = 32;
            this.WarehouseSize.V = 16;
            this.所属账号.V = 账号;
            this.CharName.V = 名字;
            this.角色职业.V = 职业;
            this.角色性别.V = 性别;
            this.角色发型.V = 发型;
            this.角色发色.V = 发色;
            this.角色脸型.V = 脸型;
            this.CreatedDate.V = MainProcess.CurrentTime;
            this.当前血量.V = 角色成长.获取数据(职业, 1)[GameObjectStats.MaxPhysicalStrength];
            this.当前蓝量.V = 角色成长.获取数据(职业, 1)[GameObjectStats.MaxMagic2];
            this.当前朝向.V = ComputingClass.随机方向();
            this.当前地图.V = 142;
            this.重生地图.V = 142;
            this.当前坐标.V = MapGatewayProcess.分配地图(142).复活区域.RandomCoords;

            for (int i = 0; i <= 19; i++)
                角色货币[(GameCurrency)i] = 0;

            this.玩家设置.SetValue(new uint[128].ToList<uint>());

            AddStarterItems();

            InscriptionSkill 铭文技能;
            if (InscriptionSkill.DataSheet.TryGetValue((ushort)((职业 == GameObjectRace.战士) ? 10300 : ((职业 == GameObjectRace.法师) ? 25300 : ((职业 == GameObjectRace.道士) ? 30000 : ((职业 == GameObjectRace.刺客) ? 15300 : ((职业 == GameObjectRace.弓手) ? 20400 : 12000))))), out 铭文技能))
            {
                SkillData SkillData = new SkillData(铭文技能.SkillId);
                this.SkillData.Add(SkillData.SkillId.V, SkillData);
                this.快捷栏位[0] = SkillData;
                SkillData.快捷栏位.V = 0;
            }
            GameDataGateway.CharacterDataTable.AddData(this, true);
            账号.角色列表.Add(this);
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

        public void AddStarterItems()
        {
            foreach (var inscriptionItem in InscriptionItems.AllInscriptionItems)
            {
                if (inscriptionItem.NeedGender != null && inscriptionItem.NeedGender != 角色性别.V)
                    continue;

                if (inscriptionItem.NeedRace?.Length > 0 && !inscriptionItem.NeedRace.Contains(角色职业.V))
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
                                Backpack[inventoryPosition] = new ItemData(item, this, 1, inventoryPosition, 1);
                        break;
                    case ItemBackPack.人物穿戴:
                        var equipment = (EquipmentItem)item;
                        Equipment[equipment.Location] = new EquipmentData(equipment, this, 0, equipment.Location, false);
                        break;
                }
            }

            //GameItems 游戏物品;
            //GameItems 模板;

            //// 金创药(小)包
            //if (GameItems.DataSheetByName.TryGetValue("GoldBag(S)", out 模板))
            //{
            //    this.角色背包[0] = new ItemData(模板, this, 1, 0, 1);
            //    this.角色背包[1] = new ItemData(模板, this, 1, 1, 1);
            //}
            //// Shibori 柴刀 Wooden Sword 木剑
            //if (GameItems.DataSheetByName.TryGetValue((角色职业.V == GameObjectRace.刺客) ? "Shibori" : "Wooden Sword", out 游戏物品))
            //{
            //    EquipmentItem 游戏装备 = 游戏物品 as EquipmentItem;
            //    if (游戏装备 != null)
            //    {
            //        this.角色装备[0] = new EquipmentData(游戏装备, this, 0, 0, false);
            //    }
            //}
            //GameItems 游戏物品2;
            //// Cloth(M) 布衣(男) Cloth(F) 布衣(女)
            //if (GameItems.DataSheetByName.TryGetValue((角色性别.V == GameObjectGender.男性) ? "Cloth(M)" : "Cloth(F)", out 游戏物品2))
            //{
            //    EquipmentItem 游戏装备2 = 游戏物品2 as EquipmentItem;
            //    if (游戏装备2 != null)
            //    {
            //        this.角色装备[1] = new EquipmentData(游戏装备2, this, 0, 1, false);
            //    }
            //}
        }

        public void AttachToEvents()
        {
            this.所属账号.更改事件 += delegate (AccountData O)
            {
                MainForm.更新CharacterData(this, "所属账号", O);
                MainForm.更新CharacterData(this, "账号封禁", (O.封禁日期.V != default(DateTime)) ? O.封禁日期 : null);
            };
            this.所属账号.V.封禁日期.更改事件 += delegate (DateTime O)
            {
                MainForm.更新CharacterData(this, "账号封禁", (O != default(DateTime)) ? O : null);
            };
            this.CharName.更改事件 += delegate (string O)
            {
                MainForm.更新CharacterData(this, "CharName", O);
            };
            this.封禁日期.更改事件 += delegate (DateTime O)
            {
                MainForm.更新CharacterData(this, "角色封禁", (O != default(DateTime)) ? O : null);
            };
            this.FreezeDate.更改事件 += delegate (DateTime O)
            {
                MainForm.更新CharacterData(this, "冻结日期", (O != default(DateTime)) ? O : null);
            };
            this.删除日期.更改事件 += delegate (DateTime O)
            {
                MainForm.更新CharacterData(this, "删除日期", (O != default(DateTime)) ? O : null);
            };
            this.登录日期.更改事件 += delegate (DateTime O)
            {
                MainForm.更新CharacterData(this, "登录日期", (O != default(DateTime)) ? O : null);
            };
            this.OfflineDate.更改事件 += delegate (DateTime O)
            {
                MainForm.更新CharacterData(this, "离线日期", (this.ActiveConnection == null) ? O : null);
            };
            this.网络地址.更改事件 += delegate (string O)
            {
                MainForm.更新CharacterData(this, "网络地址", O);
            };
            this.物理地址.更改事件 += delegate (string O)
            {
                MainForm.更新CharacterData(this, "物理地址", O);
            };
            this.角色职业.更改事件 += delegate (GameObjectRace O)
            {
                MainForm.更新CharacterData(this, "角色职业", O);
            };
            this.角色性别.更改事件 += delegate (GameObjectGender O)
            {
                MainForm.更新CharacterData(this, "角色性别", O);
            };
            this.所属行会.更改事件 += delegate (GuildData O)
            {
                MainForm.更新CharacterData(this, "所属行会", O);
            };
            this.消耗元宝.更改事件 += delegate (long O)
            {
                MainForm.更新CharacterData(this, "消耗元宝", O);
            };
            this.转出金币.更改事件 += delegate (long O)
            {
                MainForm.更新CharacterData(this, "转出金币", O);
            };
            this.BackpackSize.更改事件 += delegate (byte O)
            {
                MainForm.更新CharacterData(this, "背包大小", O);
            };
            this.WarehouseSize.更改事件 += delegate (byte O)
            {
                MainForm.更新CharacterData(this, "仓库大小", O);
            };
            this.本期特权.更改事件 += delegate (byte O)
            {
                MainForm.更新CharacterData(this, "本期特权", O);
            };
            this.本期日期.更改事件 += delegate (DateTime O)
            {
                MainForm.更新CharacterData(this, "本期日期", O);
            };
            this.上期特权.更改事件 += delegate (byte O)
            {
                MainForm.更新CharacterData(this, "上期特权", O);
            };
            this.上期日期.更改事件 += delegate (DateTime O)
            {
                MainForm.更新CharacterData(this, "上期日期", O);
            };
            this.剩余特权.更改事件 += delegate (List<KeyValuePair<byte, int>> O)
            {
                MainForm.更新CharacterData(this, "剩余特权", O.Sum((KeyValuePair<byte, int> X) => X.Value));
            };
            this.当前等级.更改事件 += delegate (byte O)
            {
                MainForm.更新CharacterData(this, "当前等级", O);
            };
            this.当前经验.更改事件 += delegate (int O)
            {
                MainForm.更新CharacterData(this, "当前经验", O);
            };
            this.双倍经验.更改事件 += delegate (int O)
            {
                MainForm.更新CharacterData(this, "双倍经验", O);
            };
            this.当前战力.更改事件 += delegate (int O)
            {
                MainForm.更新CharacterData(this, "当前战力", O);
            };
            this.当前地图.更改事件 += delegate (int O)
            {
                GameMap 游戏地图;
                MainForm.更新CharacterData(this, "当前地图", GameMap.DataSheet.TryGetValue((byte)O, out 游戏地图) ? 游戏地图 : O);
            };
            this.当前坐标.更改事件 += delegate (Point O)
            {
                MainForm.更新CharacterData(this, "当前坐标", string.Format("{0}, {1}", O.X, O.Y));
            };
            this.当前PK值.更改事件 += delegate (int O)
            {
                MainForm.更新CharacterData(this, "当前PK值", O);
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
            this.所属账号.V.角色列表.Remove(this);
            this.所属账号.V.冻结列表.Remove(this);
            this.所属账号.V.删除列表.Remove(this);
            EquipmentData v = this.升级装备.V;
            if (v != null)
            {
                v.Delete();
            }
            foreach (PetData PetData in this.PetData)
            {
                PetData.Delete();
            }
            foreach (MailData MailData in this.角色邮件)
            {
                MailData.Delete();
            }
            foreach (KeyValuePair<byte, ItemData> keyValuePair in this.Backpack)
            {
                keyValuePair.Value.Delete();
            }
            foreach (KeyValuePair<byte, EquipmentData> keyValuePair2 in this.Equipment)
            {
                keyValuePair2.Value.Delete();
            }
            foreach (KeyValuePair<byte, ItemData> keyValuePair3 in this.Warehouse)
            {
                keyValuePair3.Value.Delete();
            }
            foreach (KeyValuePair<ushort, SkillData> keyValuePair4 in this.SkillData)
            {
                keyValuePair4.Value.Delete();
            }
            foreach (KeyValuePair<ushort, BuffData> keyValuePair5 in this.BuffData)
            {
                keyValuePair5.Value.Delete();
            }
            if (this.所属队伍.V != null)
            {
                if (this == this.所属队伍.V.队长数据)
                {
                    this.所属队伍.V.Delete();
                }
                else
                {
                    this.所属队伍.V.队伍成员.Remove(this);
                }
            }
            if (this.所属师门.V != null)
            {
                if (this == this.所属师门.V.师父数据)
                {
                    this.所属师门.V.Delete();
                }
                else
                {
                    this.所属师门.V.移除徒弟(this);
                }
            }
            if (this.所属行会.V != null)
            {
                this.所属行会.V.行会成员.Remove(this);
                this.所属行会.V.行会禁言.Remove(this);
            }
            foreach (CharacterData CharacterData in this.好友列表)
            {
                CharacterData.好友列表.Remove(this);
            }
            foreach (CharacterData CharacterData2 in this.粉丝列表)
            {
                CharacterData2.偶像列表.Remove(this);
            }
            foreach (CharacterData CharacterData3 in this.仇恨列表)
            {
                CharacterData3.仇人列表.Remove(this);
            }
            base.Delete();
        }


        public byte[] 角色描述()
        {
            using var memoryStream = new MemoryStream(new byte[94]);
            using var binaryWriter = new BinaryWriter(memoryStream);

            binaryWriter.Write(数据索引.V);
            binaryWriter.Write(名字描述());
            binaryWriter.Seek(61, SeekOrigin.Begin);
            binaryWriter.Write((byte)角色职业.V);
            binaryWriter.Write((byte)角色性别.V);
            binaryWriter.Write((byte)角色发型.V);
            binaryWriter.Write((byte)角色发色.V);
            binaryWriter.Write((byte)角色脸型.V);
            binaryWriter.Write((byte)0);
            binaryWriter.Write(角色等级);
            binaryWriter.Write(当前地图.V);
            binaryWriter.Write(Equipment[0]?.升级次数.V ?? 0);
            binaryWriter.Write((Equipment[0]?.对应模板.V?.Id).GetValueOrDefault());
            binaryWriter.Write((Equipment[1]?.对应模板.V?.Id).GetValueOrDefault());
            binaryWriter.Write((Equipment[2]?.对应模板.V?.Id).GetValueOrDefault());
            binaryWriter.Write(ComputingClass.TimeShift(OfflineDate.V));
            binaryWriter.Write((!FreezeDate.V.Equals(default(DateTime))) ? ComputingClass.TimeShift(FreezeDate.V) : 0);

            return memoryStream.ToArray();
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
                    foreach (uint value in this.玩家设置)
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
                    binaryWriter.Write((ushort)this.角色邮件.Count);
                    foreach (MailData MailData in this.角色邮件)
                    {
                        binaryWriter.Write(MailData.邮件检索描述());
                    }
                    result = memoryStream.ToArray();
                }
            }
            return result;
        }


        public readonly DataMonitor<string> CharName;


        public readonly DataMonitor<string> 网络地址;


        public readonly DataMonitor<string> 物理地址;


        public readonly DataMonitor<DateTime> CreatedDate;


        public readonly DataMonitor<DateTime> 登录日期;


        public readonly DataMonitor<DateTime> FreezeDate;


        public readonly DataMonitor<DateTime> 删除日期;


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


        public readonly DataMonitor<GameObjectRace> 角色职业;


        public readonly DataMonitor<GameObjectGender> 角色性别;


        public readonly DataMonitor<ObjectHairType> 角色发型;


        public readonly DataMonitor<ObjectHairColorType> 角色发色;


        public readonly DataMonitor<ObjectFaceType> 角色脸型;


        public readonly DataMonitor<int> 当前血量;


        public readonly DataMonitor<int> 当前蓝量;


        public readonly DataMonitor<byte> 当前等级;


        public readonly DataMonitor<int> 当前经验;


        public readonly DataMonitor<int> 双倍经验;


        public readonly DataMonitor<int> 当前战力;


        public readonly DataMonitor<int> 当前PK值;


        public readonly DataMonitor<int> 当前地图;


        public readonly DataMonitor<int> 重生地图;


        public readonly DataMonitor<Point> 当前坐标;


        public readonly DataMonitor<GameDirection> 当前朝向;


        public readonly DataMonitor<AttackMode> AttackMode;


        public readonly DataMonitor<PetMode> PetMode;


        public readonly HashMonitor<PetData> PetData;


        public readonly DataMonitor<byte> BackpackSize;
        public readonly DataMonitor<byte> WarehouseSize;
        public readonly DataMonitor<byte> ExtraBackpackSize;

        public readonly DataMonitor<long> 消耗元宝;


        public readonly DataMonitor<long> 转出金币;


        public readonly ListMonitor<uint> 玩家设置;


        public readonly DataMonitor<EquipmentData> 升级装备;


        public readonly DataMonitor<DateTime> 取回时间;


        public readonly DataMonitor<bool> 升级成功;


        public readonly DataMonitor<byte> 当前称号;


        public readonly MonitorDictionary<byte, int> 历史排名;


        public readonly MonitorDictionary<byte, int> 当前排名;


        public readonly MonitorDictionary<byte, DateTime> 称号列表;


        public readonly MonitorDictionary<GameCurrency, int> 角色货币;


        public readonly MonitorDictionary<byte, ItemData> Backpack;
        public readonly MonitorDictionary<byte, ItemData> Warehouse;
        public readonly MonitorDictionary<byte, ItemData> ExtraBackPack;
        public readonly MonitorDictionary<byte, EquipmentData> Equipment;


        public readonly MonitorDictionary<byte, SkillData> 快捷栏位;


        public readonly MonitorDictionary<ushort, BuffData> BuffData;


        public readonly MonitorDictionary<ushort, SkillData> SkillData;


        public readonly MonitorDictionary<int, DateTime> 冷却数据;


        public readonly HashMonitor<MailData> 角色邮件;


        public readonly HashMonitor<MailData> 未读邮件;


        public readonly DataMonitor<byte> 预定特权;


        public readonly DataMonitor<byte> 本期特权;


        public readonly DataMonitor<byte> 上期特权;


        public readonly DataMonitor<uint> 本期记录;


        public readonly DataMonitor<uint> 上期记录;


        public readonly DataMonitor<DateTime> 本期日期;


        public readonly DataMonitor<DateTime> 上期日期;


        public readonly DataMonitor<DateTime> 补给日期;


        public readonly DataMonitor<DateTime> 战备日期;


        public readonly MonitorDictionary<byte, int> 剩余特权;


        public readonly DataMonitor<AccountData> 所属账号;


        public readonly DataMonitor<TeamData> 所属队伍;


        public readonly DataMonitor<GuildData> 所属行会;


        public readonly DataMonitor<TeacherData> 所属师门;


        public readonly HashMonitor<CharacterData> 好友列表;


        public readonly HashMonitor<CharacterData> 偶像列表;


        public readonly HashMonitor<CharacterData> 粉丝列表;


        public readonly HashMonitor<CharacterData> 仇人列表;


        public readonly HashMonitor<CharacterData> 仇恨列表;


        public readonly HashMonitor<CharacterData> 黑名单表;
    }
}
