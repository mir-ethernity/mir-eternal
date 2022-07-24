using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using GameServer.Data;
using GameServer.Templates;
using GameServer.Networking;

namespace GameServer.Maps
{
    
    public abstract class MapObject
    {
        
        public override string ToString()
        {
            return this.对象名字;
        }

        
        // (get) Token: 0x06000761 RID: 1889 RVA: 0x000064EF File Offset: 0x000046EF
        // (set) Token: 0x06000762 RID: 1890 RVA: 0x000064F7 File Offset: 0x000046F7
        public DateTime 恢复时间 { get; set; }

        
        // (get) Token: 0x06000763 RID: 1891 RVA: 0x00006500 File Offset: 0x00004700
        // (set) Token: 0x06000764 RID: 1892 RVA: 0x00006508 File Offset: 0x00004708
        public DateTime 治疗时间 { get; set; }

        
        // (get) Token: 0x06000765 RID: 1893 RVA: 0x00006511 File Offset: 0x00004711
        // (set) Token: 0x06000766 RID: 1894 RVA: 0x00006519 File Offset: 0x00004719
        public DateTime 脱战时间 { get; set; }

        
        // (get) Token: 0x06000767 RID: 1895 RVA: 0x00006522 File Offset: 0x00004722
        // (set) Token: 0x06000768 RID: 1896 RVA: 0x0000652A File Offset: 0x0000472A
        public DateTime 处理计时 { get; set; }

        
        // (get) Token: 0x06000769 RID: 1897 RVA: 0x00006533 File Offset: 0x00004733
        // (set) Token: 0x0600076A RID: 1898 RVA: 0x0000653B File Offset: 0x0000473B
        public DateTime 预约时间 { get; set; }

        
        // (get) Token: 0x0600076B RID: 1899 RVA: 0x00006544 File Offset: 0x00004744
        public virtual int 处理间隔 { get; }

        
        // (get) Token: 0x0600076C RID: 1900 RVA: 0x0000654C File Offset: 0x0000474C
        // (set) Token: 0x0600076D RID: 1901 RVA: 0x00006554 File Offset: 0x00004754
        public int 治疗次数 { get; set; }

        
        // (get) Token: 0x0600076E RID: 1902 RVA: 0x0000655D File Offset: 0x0000475D
        // (set) Token: 0x0600076F RID: 1903 RVA: 0x00006565 File Offset: 0x00004765
        public int 治疗基数 { get; set; }

        
        // (get) Token: 0x06000770 RID: 1904 RVA: 0x0000656E File Offset: 0x0000476E
        // (set) Token: 0x06000771 RID: 1905 RVA: 0x00006576 File Offset: 0x00004776
        public byte 动作编号 { get; set; }

        
        // (get) Token: 0x06000772 RID: 1906 RVA: 0x0000657F File Offset: 0x0000477F
        // (set) Token: 0x06000773 RID: 1907 RVA: 0x00006587 File Offset: 0x00004787
        public bool 战斗姿态 { get; set; }

        
        // (get) Token: 0x06000774 RID: 1908
        public abstract GameObjectType 对象类型 { get; }

        
        // (get) Token: 0x06000775 RID: 1909
        public abstract MonsterSize 对象体型 { get; }

        
        // (get) Token: 0x06000776 RID: 1910 RVA: 0x00006590 File Offset: 0x00004790
        public ushort 行走速度
        {
            get
            {
                return (ushort)this[GameObjectStats.行走速度];
            }
        }

        
        // (get) Token: 0x06000777 RID: 1911 RVA: 0x0000659B File Offset: 0x0000479B
        public ushort 奔跑速度
        {
            get
            {
                return (ushort)this[GameObjectStats.奔跑速度];
            }
        }

        
        // (get) Token: 0x06000778 RID: 1912 RVA: 0x000065A6 File Offset: 0x000047A6
        public virtual int 行走耗时
        {
            get
            {
                return (int)(this.行走速度 * 60);
            }
        }

        
        // (get) Token: 0x06000779 RID: 1913 RVA: 0x000065B1 File Offset: 0x000047B1
        public virtual int 奔跑耗时
        {
            get
            {
                return (int)(this.奔跑速度 * 60);
            }
        }

        
        // (get) Token: 0x0600077A RID: 1914 RVA: 0x000065BC File Offset: 0x000047BC
        // (set) Token: 0x0600077B RID: 1915 RVA: 0x000065C4 File Offset: 0x000047C4
        public virtual int MapId { get; set; }

        
        // (get) Token: 0x0600077C RID: 1916 RVA: 0x000065CD File Offset: 0x000047CD
        // (set) Token: 0x0600077D RID: 1917 RVA: 0x000065D5 File Offset: 0x000047D5
        public virtual int 当前体力 { get; set; }

        
        // (get) Token: 0x0600077E RID: 1918 RVA: 0x000065DE File Offset: 0x000047DE
        // (set) Token: 0x0600077F RID: 1919 RVA: 0x000065E6 File Offset: 0x000047E6
        public virtual int 当前魔力 { get; set; }

        
        // (get) Token: 0x06000780 RID: 1920 RVA: 0x000065EF File Offset: 0x000047EF
        // (set) Token: 0x06000781 RID: 1921 RVA: 0x000065F7 File Offset: 0x000047F7
        public virtual byte 当前等级 { get; set; }

        
        // (get) Token: 0x06000782 RID: 1922 RVA: 0x00006600 File Offset: 0x00004800
        // (set) Token: 0x06000783 RID: 1923 RVA: 0x00006608 File Offset: 0x00004808
        public virtual bool 对象死亡 { get; set; }

        
        // (get) Token: 0x06000784 RID: 1924 RVA: 0x00006611 File Offset: 0x00004811
        // (set) Token: 0x06000785 RID: 1925 RVA: 0x00006619 File Offset: 0x00004819
        public virtual bool 阻塞网格 { get; set; }

        
        // (get) Token: 0x06000786 RID: 1926 RVA: 0x00006622 File Offset: 0x00004822
        public virtual bool 能被命中
        {
            get
            {
                return !this.对象死亡;
            }
        }

        
        // (get) Token: 0x06000787 RID: 1927 RVA: 0x0000662D File Offset: 0x0000482D
        // (set) Token: 0x06000788 RID: 1928 RVA: 0x00006635 File Offset: 0x00004835
        public virtual string 对象名字 { get; set; }

        
        // (get) Token: 0x06000789 RID: 1929 RVA: 0x0000663E File Offset: 0x0000483E
        // (set) Token: 0x0600078A RID: 1930 RVA: 0x00006646 File Offset: 0x00004846
        public virtual GameDirection 当前方向 { get; set; }

        
        // (get) Token: 0x0600078B RID: 1931 RVA: 0x0000664F File Offset: 0x0000484F
        // (set) Token: 0x0600078C RID: 1932 RVA: 0x00006657 File Offset: 0x00004857
        public virtual MapInstance 当前地图 { get; set; }

        
        // (get) Token: 0x0600078D RID: 1933 RVA: 0x00006660 File Offset: 0x00004860
        // (set) Token: 0x0600078E RID: 1934 RVA: 0x00006668 File Offset: 0x00004868
        public virtual Point 当前坐标 { get; set; }

        
        // (get) Token: 0x0600078F RID: 1935 RVA: 0x00006671 File Offset: 0x00004871
        public virtual ushort 当前高度
        {
            get
            {
                return this.当前地图.地形高度(this.当前坐标);
            }
        }

        
        // (get) Token: 0x06000790 RID: 1936 RVA: 0x00006684 File Offset: 0x00004884
        // (set) Token: 0x06000791 RID: 1937 RVA: 0x0000668C File Offset: 0x0000488C
        public virtual DateTime 忙碌时间 { get; set; }

        
        // (get) Token: 0x06000792 RID: 1938 RVA: 0x00006695 File Offset: 0x00004895
        // (set) Token: 0x06000793 RID: 1939 RVA: 0x0000669D File Offset: 0x0000489D
        public virtual DateTime 硬直时间 { get; set; }

        
        // (get) Token: 0x06000794 RID: 1940 RVA: 0x000066A6 File Offset: 0x000048A6
        // (set) Token: 0x06000795 RID: 1941 RVA: 0x000066AE File Offset: 0x000048AE
        public virtual DateTime 行走时间 { get; set; }

        
        // (get) Token: 0x06000796 RID: 1942 RVA: 0x000066B7 File Offset: 0x000048B7
        // (set) Token: 0x06000797 RID: 1943 RVA: 0x000066BF File Offset: 0x000048BF
        public virtual DateTime 奔跑时间 { get; set; }

        
        public virtual int this[GameObjectStats Stat]
        {
            get
            {
                if (!this.当前Stat.ContainsKey(Stat))
                {
                    return 0;
                }
                return this.当前Stat[Stat];
            }
            set
            {
                this.当前Stat[Stat] = value;
                if (Stat == GameObjectStats.MaxPhysicalStrength)
                {
                    this.当前体力 = Math.Min(this.当前体力, value);
                    return;
                }
                if (Stat == GameObjectStats.MaxMagic2)
                {
                    this.当前魔力 = Math.Min(this.当前魔力, value);
                }
            }
        }

        
        // (get) Token: 0x0600079A RID: 1946 RVA: 0x00006724 File Offset: 0x00004924
        public virtual Dictionary<GameObjectStats, int> 当前Stat { get; }

        
        // (get) Token: 0x0600079B RID: 1947 RVA: 0x0000672C File Offset: 0x0000492C
        public virtual MonitorDictionary<int, DateTime> 冷却记录 { get; }

        
        // (get) Token: 0x0600079C RID: 1948 RVA: 0x00006734 File Offset: 0x00004934
        public virtual MonitorDictionary<ushort, BuffData> Buff列表 { get; }

        
        public virtual void 更新对象Stat()
        {
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            foreach (object obj in Enum.GetValues(typeof(GameObjectStats)))
            {
                int num5 = 0;
                GameObjectStats GameObjectProperties = (GameObjectStats)obj;
                foreach (KeyValuePair<object, Dictionary<GameObjectStats, int>> keyValuePair in this.Stat加成)
                {
                    int num6;
                    if (keyValuePair.Value != null && keyValuePair.Value.TryGetValue(GameObjectProperties, out num6) && num6 != 0)
                    {
                        if (keyValuePair.Key is BuffData)
                        {
                            if (GameObjectProperties == GameObjectStats.行走速度)
                            {
                                num2 = Math.Max(num2, num6);
                                num = Math.Min(num, num6);
                            }
                            else if (GameObjectProperties == GameObjectStats.奔跑速度)
                            {
                                num4 = Math.Max(num4, num6);
                                num3 = Math.Min(num3, num6);
                            }
                            else
                            {
                                num5 += num6;
                            }
                        }
                        else
                        {
                            num5 += num6;
                        }
                    }
                }
                if (GameObjectProperties == GameObjectStats.行走速度)
                {
                    this[GameObjectProperties] = Math.Max(1, num5 + num + num2);
                }
                else if (GameObjectProperties == GameObjectStats.奔跑速度)
                {
                    this[GameObjectProperties] = Math.Max(1, num5 + num3 + num4);
                }
                else if (GameObjectProperties == GameObjectStats.幸运等级)
                {
                    this[GameObjectProperties] = num5;
                }
                else
                {
                    this[GameObjectProperties] = Math.Max(0, num5);
                }
            }
            PlayerObject PlayerObject = this as PlayerObject;
            if (PlayerObject != null)
            {
                foreach (PetObject PetObject in PlayerObject.宠物列表)
                {
                    if (PetObject.对象模板.InheritsStats != null)
                    {
                        Dictionary<GameObjectStats, int> dictionary = new Dictionary<GameObjectStats, int>();
                        foreach (InheritStat InheritStat in PetObject.对象模板.InheritsStats)
                        {
                            dictionary[InheritStat.ConvertStat] = (int)((float)this[InheritStat.InheritsStats] * InheritStat.Ratio);
                        }
                        PetObject.Stat加成[PlayerObject.CharacterData] = dictionary;
                        PetObject.更新对象Stat();
                    }
                }
            }
        }

        
        public virtual void 处理对象数据()
        {
            this.处理计时 = MainProcess.CurrentTime;
            this.预约时间 = MainProcess.CurrentTime.AddMilliseconds((double)this.处理间隔);
        }

        
        public virtual void 自身死亡处理(MapObject 对象, bool 技能击杀)
        {
            this.发送封包(new ObjectCharacterDiesPacket
            {
                对象编号 = this.MapId
            });
            this.技能任务.Clear();
            this.对象死亡 = true;
            this.阻塞网格 = false;
            foreach (MapObject MapObject in this.邻居列表.ToList<MapObject>())
            {
                MapObject.对象死亡时处理(this);
            }
        }

        
        public MapObject()
        {


            this.处理计时 = MainProcess.CurrentTime;
            this.技能任务 = new HashSet<技能实例>();
            this.陷阱列表 = new HashSet<TrapObject>();
            this.重要邻居 = new HashSet<MapObject>();
            this.潜行邻居 = new HashSet<MapObject>();
            this.邻居列表 = new HashSet<MapObject>();
            this.当前Stat = new Dictionary<GameObjectStats, int>();
            this.冷却记录 = new MonitorDictionary<int, DateTime>(null);
            this.Buff列表 = new MonitorDictionary<ushort, BuffData>(null);
            this.Stat加成 = new Dictionary<object, Dictionary<GameObjectStats, int>>();
            this.预约时间 = MainProcess.CurrentTime.AddMilliseconds((double)MainProcess.RandomNumber.Next(this.处理间隔));
        }

        
        public void 解绑网格()
        {
            foreach (Point 坐标 in ComputingClass.技能范围(this.当前坐标, this.当前方向, this.对象体型))
            {
                this.当前地图[坐标].Remove(this);
            }
        }

        
        public void 绑定网格()
        {
            foreach (Point 坐标 in ComputingClass.技能范围(this.当前坐标, this.当前方向, this.对象体型))
            {
                this.当前地图[坐标].Add(this);
            }
        }

        
        public void 删除对象()
        {
            this.清空邻居时处理();
            this.解绑网格();
            this.次要对象 = false;
            MapGatewayProcess.移除MapObject(this);
            this.激活对象 = false;
            MapGatewayProcess.移除激活对象(this);
        }

        
        public int 网格距离(Point 坐标)
        {
            return ComputingClass.网格距离(this.当前坐标, 坐标);
        }

        
        public int 网格距离(MapObject 对象)
        {
            return ComputingClass.网格距离(this.当前坐标, 对象.当前坐标);
        }

        
        public void 发送封包(GamePacket 封包)
        {
            string name = 封包.封包类型.Name;

            switch (name)
            {
                case "ObjectCharacterWalkPacket":
                case "ObjectCharacterRunPacket":
                case "ObjectRotationDirectionPacket":
                case "ObjectTransformTypePacket":
                case "ObjectPassiveDisplacementPacket":
                case "ObjectStateChangePacket":
                case "CharacterLevelUpPacket":
                case "ObjectRemovalStatusPacket":
                case "TrapMoveLocationPacket":
                case "ReceiveChatMessagesNearbyPacket":
                case "SyncPetLevelPacket":
                case "ObjectAddStatePacket":
                case "ObjectCharacterDiesPacket":
                case "同步对象惩罚":
                case "同步装配称号":
                case "摆摊状态改变":
                case "玩家名字变灰":
                case "开始释放技能":
                case "同步角色外形":
                case "变更摊位名字":
                case "触发命中特效":
                case "同步对象体力":
                case "触发技能正常":
                case "同步对象行会":
                case "技能释放中断":
                case "触发状态效果":
                case "触发技能扩展":
                    BroadcastPacket(封包);
                    break;
            }

            PlayerObject PlayerObject2 = this as PlayerObject;
            if (PlayerObject2 != null)
            {
                客户网络 网络连接 = PlayerObject2.网络连接;
                if (网络连接 == null)
                {
                    return;
                }
                网络连接.发送封包(封包);
            }
        }

        private void BroadcastPacket(GamePacket packet)
        {
            foreach (MapObject obj in this.邻居列表)
            {
                PlayerObject PlayerObject = obj as PlayerObject;
                if (PlayerObject != null && !PlayerObject.潜行邻居.Contains(this) && PlayerObject != null)
                {
                    PlayerObject.网络连接.发送封包(packet);
                }
            }
        }

        
        public bool 在视线内(MapObject 对象)
        {
            return Math.Abs(this.当前坐标.X - 对象.当前坐标.X) <= 20 && Math.Abs(this.当前坐标.Y - 对象.当前坐标.Y) <= 20;
        }

        
        public bool ActiveAttack(MapObject 对象)
        {
            if (对象.对象死亡)
            {
                return false;
            }
            MonsterObject MonsterObject = this as MonsterObject;
            if (MonsterObject != null)
            {
                if (MonsterObject.ActiveAttackTarget)
                {
                    if (!(对象 is PlayerObject) && !(对象 is PetObject))
                    {
                        GuardInstance GuardInstance = 对象 as GuardInstance;
                        if (GuardInstance == null || !GuardInstance.CanBeInjured)
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
            else
            {
                GuardInstance GuardInstance2 = this as GuardInstance;
                if (GuardInstance2 != null)
                {
                    if (!GuardInstance2.ActiveAttackTarget)
                    {
                        return false;
                    }
                    MonsterObject MonsterObject2 = 对象 as MonsterObject;
                    if (MonsterObject2 != null)
                    {
                        return MonsterObject2.ActiveAttackTarget;
                    }
                    PlayerObject PlayerObject = 对象 as PlayerObject;
                    if (PlayerObject != null)
                    {
                        return PlayerObject.红名玩家;
                    }
                    if (对象 is PetObject)
                    {
                        return GuardInstance2.模板编号 == 6734;
                    }
                }
                else if (this is PetObject)
                {
                    MonsterObject MonsterObject3 = 对象 as MonsterObject;
                    return MonsterObject3 != null && MonsterObject3.ActiveAttackTarget;
                }
            }
            return false;
        }

        
        public bool 邻居类型(MapObject 对象)
        {
            GameObjectType 对象类型 = this.对象类型;
            if (对象类型 <= GameObjectType.Npcc)
            {
                switch (对象类型)
                {
                    case GameObjectType.玩家:
                        return true;
                    case GameObjectType.宠物:
                    case GameObjectType.怪物:
                        {
                            GameObjectType 对象类型2 = 对象.对象类型;
                            if (对象类型2 <= GameObjectType.怪物)
                            {
                                if (对象类型2 - GameObjectType.玩家 <= 1 || 对象类型2 == GameObjectType.怪物)
                                {
                                    return true;
                                }
                            }
                            else
                            {
                                if (对象类型2 == GameObjectType.Npcc)
                                {
                                    return true;
                                }
                                if (对象类型2 == GameObjectType.陷阱)
                                {
                                    return true;
                                }
                            }
                            return false;
                        }
                    case (GameObjectType)3:
                        break;
                    default:
                        if (对象类型 == GameObjectType.Npcc)
                        {
                            GameObjectType 对象类型2 = 对象.对象类型;
                            if (对象类型2 - GameObjectType.玩家 > 1 && 对象类型2 != GameObjectType.怪物)
                            {
                                if (对象类型2 != GameObjectType.陷阱)
                                {
                                    return false;
                                }
                            }
                            return true;
                        }
                        break;
                }
            }
            else
            {
                if (对象类型 == GameObjectType.物品)
                {
                    return 对象.对象类型 == GameObjectType.玩家;
                }
                if (对象类型 == GameObjectType.陷阱)
                {
                    GameObjectType 对象类型2 = 对象.对象类型;
                    if (对象类型2 - GameObjectType.玩家 > 1 && 对象类型2 != GameObjectType.怪物)
                    {
                        if (对象类型2 != GameObjectType.Npcc)
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
            return false;
        }

        
        public 游戏对象关系 对象关系(MapObject 对象)
        {
            TrapObject TrapObject = 对象 as TrapObject;
            if (TrapObject != null)
            {
                对象 = TrapObject.陷阱来源;
            }
            if (this == 对象)
            {
                return 游戏对象关系.自身;
            }
            if (!(this is MonsterObject))
            {
                if (this is GuardInstance)
                {
                    if (对象 is MonsterObject || 对象 is PetObject || 对象 is PlayerObject)
                    {
                        return 游戏对象关系.敌对;
                    }
                }
                else
                {
                    PlayerObject PlayerObject = this as PlayerObject;
                    if (PlayerObject != null)
                    {
                        if (对象 is MonsterObject)
                        {
                            return 游戏对象关系.敌对;
                        }
                        if (对象 is GuardInstance)
                        {
                            if (PlayerObject.AttackMode == AttackMode.全体)
                            {
                                if (this.当前地图.MapId != 80)
                                {
                                    return 游戏对象关系.敌对;
                                }
                            }
                            return 游戏对象关系.友方;
                        }
                        PlayerObject PlayerObject2 = 对象 as PlayerObject;
                        if (PlayerObject2 != null)
                        {
                            if (PlayerObject.AttackMode == AttackMode.和平)
                            {
                                return 游戏对象关系.友方;
                            }
                            if (PlayerObject.AttackMode == AttackMode.行会)
                            {
                                if (PlayerObject.所属行会 != null && PlayerObject2.所属行会 != null && (PlayerObject.所属行会 == PlayerObject2.所属行会 || PlayerObject.所属行会.结盟行会.ContainsKey(PlayerObject2.所属行会)))
                                {
                                    return 游戏对象关系.友方;
                                }
                                return 游戏对象关系.敌对;
                            }
                            else
                            {
                                if (PlayerObject.AttackMode == AttackMode.组队)
                                {
                                    if (PlayerObject.所属队伍 != null && PlayerObject2.所属队伍 != null)
                                    {
                                        if (PlayerObject.所属队伍 == PlayerObject2.所属队伍)
                                        {
                                            return 游戏对象关系.友方;
                                        }
                                    }
                                    return 游戏对象关系.敌对;
                                }
                                if (PlayerObject.AttackMode == AttackMode.全体)
                                {
                                    return 游戏对象关系.敌对;
                                }
                                if (PlayerObject.AttackMode == AttackMode.善恶)
                                {
                                    if (!PlayerObject2.红名玩家 && !PlayerObject2.灰名玩家)
                                    {
                                        return 游戏对象关系.友方;
                                    }
                                    return 游戏对象关系.敌对;
                                }
                                else if (PlayerObject.AttackMode == AttackMode.敌对)
                                {
                                    if (PlayerObject.所属行会 != null && PlayerObject2.所属行会 != null && PlayerObject.所属行会.敌对行会.ContainsKey(PlayerObject2.所属行会))
                                    {
                                        return 游戏对象关系.敌对;
                                    }
                                    return 游戏对象关系.友方;
                                }
                            }
                        }
                        else
                        {
                            PetObject PetObject = 对象 as PetObject;
                            if (PetObject != null)
                            {
                                if (PetObject.宠物主人 == PlayerObject)
                                {
                                    if (PlayerObject.AttackMode != AttackMode.全体)
                                    {
                                        return 游戏对象关系.友方;
                                    }
                                    return 游戏对象关系.友方 | 游戏对象关系.敌对;
                                }
                                else
                                {
                                    if (PlayerObject.AttackMode == AttackMode.和平)
                                    {
                                        return 游戏对象关系.友方;
                                    }
                                    if (PlayerObject.AttackMode == AttackMode.行会)
                                    {
                                        if (PlayerObject.所属行会 != null && PetObject.宠物主人.所属行会 != null && (PlayerObject.所属行会 == PetObject.宠物主人.所属行会 || PlayerObject.所属行会.结盟行会.ContainsKey(PetObject.宠物主人.所属行会)))
                                        {
                                            return 游戏对象关系.友方;
                                        }
                                        return 游戏对象关系.敌对;
                                    }
                                    else
                                    {
                                        if (PlayerObject.AttackMode == AttackMode.组队)
                                        {
                                            if (PlayerObject.所属队伍 != null && PetObject.宠物主人.所属队伍 != null)
                                            {
                                                if (PlayerObject.所属队伍 == PetObject.宠物主人.所属队伍)
                                                {
                                                    return 游戏对象关系.友方;
                                                }
                                            }
                                            return 游戏对象关系.敌对;
                                        }
                                        if (PlayerObject.AttackMode == AttackMode.全体)
                                        {
                                            return 游戏对象关系.敌对;
                                        }
                                        if (PlayerObject.AttackMode == AttackMode.善恶)
                                        {
                                            if (!PetObject.宠物主人.红名玩家 && !PetObject.宠物主人.灰名玩家)
                                            {
                                                return 游戏对象关系.友方;
                                            }
                                            return 游戏对象关系.敌对;
                                        }
                                        else if (PlayerObject.AttackMode == AttackMode.敌对)
                                        {
                                            if (PlayerObject.所属行会 != null && PetObject.宠物主人.所属行会 != null && PlayerObject.所属行会.敌对行会.ContainsKey(PetObject.宠物主人.所属行会))
                                            {
                                                return 游戏对象关系.敌对;
                                            }
                                            return 游戏对象关系.友方;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        PetObject PetObject2 = this as PetObject;
                        if (PetObject2 != null)
                        {
                            if (PetObject2.宠物主人 != 对象)
                            {
                                return PetObject2.宠物主人.对象关系(对象);
                            }
                            return 游戏对象关系.友方;
                        }
                        else
                        {
                            TrapObject TrapObject2 = this as TrapObject;
                            if (TrapObject2 != null)
                            {
                                return TrapObject2.陷阱来源.对象关系(对象);
                            }
                        }
                    }
                }
                return 游戏对象关系.自身;
            }
            if (!(对象 is MonsterObject))
            {
                return 游戏对象关系.敌对;
            }
            return 游戏对象关系.友方;
        }

        
        public bool 特定类型(MapObject 来源, SpecifyTargetType 类型)
        {
            TrapObject TrapObject = 来源 as TrapObject;
            MapObject MapObject = (TrapObject != null) ? TrapObject.陷阱来源 : 来源;
            MonsterObject MonsterObject = this as MonsterObject;
            if (MonsterObject != null)
            {
                if (类型 == SpecifyTargetType.None)
                {
                    return true;
                }
                if ((类型 & SpecifyTargetType.LowLevelTarget) == SpecifyTargetType.LowLevelTarget && this.当前等级 < MapObject.当前等级)
                {
                    return true;
                }
                if ((类型 & SpecifyTargetType.AllMonsters) == SpecifyTargetType.AllMonsters)
                {
                    return true;
                }
                if ((类型 & SpecifyTargetType.LowLevelMonster) == SpecifyTargetType.LowLevelMonster && this.当前等级 < MapObject.当前等级)
                {
                    return true;
                }
                if ((类型 & SpecifyTargetType.LowBloodMonster) == SpecifyTargetType.LowBloodMonster && (float)this.当前体力 / (float)this[GameObjectStats.MaxPhysicalStrength] < 0.4f)
                {
                    return true;
                }
                if ((类型 & SpecifyTargetType.Normal) == SpecifyTargetType.Normal && MonsterObject.Category == MonsterLevelType.Normal)
                {
                    return true;
                }
                if ((类型 & SpecifyTargetType.Undead) == SpecifyTargetType.Undead && MonsterObject.怪物种族 == MonsterRaceType.Undead)
                {
                    return true;
                }
                if ((类型 & SpecifyTargetType.ZergCreature) == SpecifyTargetType.ZergCreature && MonsterObject.怪物种族 == MonsterRaceType.ZergCreature)
                {
                    return true;
                }
                if ((类型 & SpecifyTargetType.WomaMonster) == SpecifyTargetType.WomaMonster && MonsterObject.怪物种族 == MonsterRaceType.WomaMonster)
                {
                    return true;
                }
                if ((类型 & SpecifyTargetType.PigMonster) == SpecifyTargetType.PigMonster && MonsterObject.怪物种族 == MonsterRaceType.PigMonster)
                {
                    return true;
                }
                if ((类型 & SpecifyTargetType.ZumaMonster) == SpecifyTargetType.ZumaMonster && MonsterObject.怪物种族 == MonsterRaceType.ZumaMonster)
                {
                    return true;
                }
                if ((类型 & SpecifyTargetType.DragonMonster) == SpecifyTargetType.DragonMonster && MonsterObject.怪物种族 == MonsterRaceType.DragonMonster)
                {
                    return true;
                }
                if ((类型 & SpecifyTargetType.EliteMonsters) == SpecifyTargetType.EliteMonsters && (MonsterObject.Category == MonsterLevelType.Elite || MonsterObject.Category == MonsterLevelType.Boss))
                {
                    return true;
                }
                if ((类型 & SpecifyTargetType.Backstab) == SpecifyTargetType.Backstab)
                {
                    GameDirection GameDirection = ComputingClass.计算方向(来源.当前坐标, this.当前坐标);
                    GameDirection 当前方向 = this.当前方向;
                    if (当前方向 <= GameDirection.上方)
                    {
                        if (当前方向 != GameDirection.左方)
                        {
                            if (当前方向 != GameDirection.左上)
                            {
                                if (当前方向 == GameDirection.上方)
                                {
                                    if (GameDirection == GameDirection.左上 || GameDirection == GameDirection.上方 || GameDirection == GameDirection.右上)
                                    {
                                        return true;
                                    }
                                    return false;
                                }
                            }
                            else
                            {
                                if (GameDirection == GameDirection.左方 || GameDirection == GameDirection.左上 || GameDirection == GameDirection.上方)
                                {
                                    return true;
                                }
                                return false;
                            }
                        }
                        else
                        {
                            if (GameDirection == GameDirection.左方 || GameDirection == GameDirection.左上 || GameDirection == GameDirection.左下)
                            {
                                return true;
                            }
                            return false;
                        }
                    }
                    else if (当前方向 <= GameDirection.右方)
                    {
                        if (当前方向 != GameDirection.右上)
                        {
                            if (当前方向 == GameDirection.右方)
                            {
                                if (GameDirection == GameDirection.右上 || GameDirection == GameDirection.右方 || GameDirection == GameDirection.右下)
                                {
                                    return true;
                                }
                                return false;
                            }
                        }
                        else
                        {
                            if (GameDirection == GameDirection.上方 || GameDirection == GameDirection.右上 || GameDirection == GameDirection.右方)
                            {
                                return true;
                            }
                            return false;
                        }
                    }
                    else if (当前方向 != GameDirection.下方)
                    {
                        if (当前方向 == GameDirection.左下)
                        {
                            if (GameDirection == GameDirection.左方 || GameDirection == GameDirection.下方 || GameDirection == GameDirection.左下)
                            {
                                return true;
                            }
                            return false;
                        }
                    }
                    else
                    {
                        if (GameDirection == GameDirection.右下 || GameDirection == GameDirection.下方 || GameDirection == GameDirection.左下)
                        {
                            return true;
                        }
                        return false;
                    }
                    if (GameDirection == GameDirection.右方 || GameDirection == GameDirection.右下 || GameDirection == GameDirection.下方)
                    {
                        return true;
                    }
                }
            }
            else if (this is GuardInstance)
            {
                if (类型 == SpecifyTargetType.None)
                {
                    return true;
                }
                if ((类型 & SpecifyTargetType.LowLevelTarget) == SpecifyTargetType.LowLevelTarget && this.当前等级 < MapObject.当前等级)
                {
                    return true;
                }
                if ((类型 & SpecifyTargetType.Backstab) == SpecifyTargetType.Backstab)
                {
                    GameDirection GameDirection2 = ComputingClass.计算方向(来源.当前坐标, this.当前坐标);
                    GameDirection 当前方向 = this.当前方向;
                    if (当前方向 <= GameDirection.上方)
                    {
                        if (当前方向 != GameDirection.左方)
                        {
                            if (当前方向 != GameDirection.左上)
                            {
                                if (当前方向 == GameDirection.上方)
                                {
                                    if (GameDirection2 == GameDirection.左上 || GameDirection2 == GameDirection.上方 || GameDirection2 == GameDirection.右上)
                                    {
                                        return true;
                                    }
                                    return false;
                                }
                            }
                            else
                            {
                                if (GameDirection2 == GameDirection.左方 || GameDirection2 == GameDirection.左上 || GameDirection2 == GameDirection.上方)
                                {
                                    return true;
                                }
                                return false;
                            }
                        }
                        else
                        {
                            if (GameDirection2 == GameDirection.左方 || GameDirection2 == GameDirection.左上 || GameDirection2 == GameDirection.左下)
                            {
                                return true;
                            }
                            return false;
                        }
                    }
                    else if (当前方向 <= GameDirection.右方)
                    {
                        if (当前方向 != GameDirection.右上)
                        {
                            if (当前方向 == GameDirection.右方)
                            {
                                if (GameDirection2 == GameDirection.右上 || GameDirection2 == GameDirection.右方 || GameDirection2 == GameDirection.右下)
                                {
                                    return true;
                                }
                                return false;
                            }
                        }
                        else
                        {
                            if (GameDirection2 == GameDirection.上方 || GameDirection2 == GameDirection.右上 || GameDirection2 == GameDirection.右方)
                            {
                                return true;
                            }
                            return false;
                        }
                    }
                    else if (当前方向 != GameDirection.下方)
                    {
                        if (当前方向 == GameDirection.左下)
                        {
                            if (GameDirection2 == GameDirection.左方 || GameDirection2 == GameDirection.下方 || GameDirection2 == GameDirection.左下)
                            {
                                return true;
                            }
                            return false;
                        }
                    }
                    else
                    {
                        if (GameDirection2 == GameDirection.右下 || GameDirection2 == GameDirection.下方 || GameDirection2 == GameDirection.左下)
                        {
                            return true;
                        }
                        return false;
                    }
                    if (GameDirection2 == GameDirection.右方 || GameDirection2 == GameDirection.右下 || GameDirection2 == GameDirection.下方)
                    {
                        return true;
                    }
                }
            }
            else
            {
                PetObject PetObject = this as PetObject;
                if (PetObject != null)
                {
                    if (类型 == SpecifyTargetType.None)
                    {
                        return true;
                    }
                    if ((类型 & SpecifyTargetType.LowLevelTarget) == SpecifyTargetType.LowLevelTarget && this.当前等级 < MapObject.当前等级)
                    {
                        return true;
                    }
                    if ((类型 & SpecifyTargetType.Undead) == SpecifyTargetType.Undead && PetObject.宠物种族 == MonsterRaceType.Undead)
                    {
                        return true;
                    }
                    if ((类型 & SpecifyTargetType.ZergCreature) == SpecifyTargetType.ZergCreature && PetObject.宠物种族 == MonsterRaceType.ZergCreature)
                    {
                        return true;
                    }
                    if ((类型 & SpecifyTargetType.AllPets) == SpecifyTargetType.AllPets)
                    {
                        return true;
                    }
                    if ((类型 & SpecifyTargetType.Backstab) == SpecifyTargetType.Backstab)
                    {
                        GameDirection GameDirection3 = ComputingClass.计算方向(来源.当前坐标, this.当前坐标);
                        GameDirection 当前方向 = this.当前方向;
                        if (当前方向 <= GameDirection.上方)
                        {
                            if (当前方向 != GameDirection.左方)
                            {
                                if (当前方向 != GameDirection.左上)
                                {
                                    if (当前方向 == GameDirection.上方)
                                    {
                                        if (GameDirection3 == GameDirection.左上 || GameDirection3 == GameDirection.上方 || GameDirection3 == GameDirection.右上)
                                        {
                                            return true;
                                        }
                                        return false;
                                    }
                                }
                                else
                                {
                                    if (GameDirection3 == GameDirection.左方 || GameDirection3 == GameDirection.左上 || GameDirection3 == GameDirection.上方)
                                    {
                                        return true;
                                    }
                                    return false;
                                }
                            }
                            else
                            {
                                if (GameDirection3 == GameDirection.左方 || GameDirection3 == GameDirection.左上 || GameDirection3 == GameDirection.左下)
                                {
                                    return true;
                                }
                                return false;
                            }
                        }
                        else if (当前方向 <= GameDirection.右方)
                        {
                            if (当前方向 != GameDirection.右上)
                            {
                                if (当前方向 == GameDirection.右方)
                                {
                                    if (GameDirection3 == GameDirection.右上 || GameDirection3 == GameDirection.右方 || GameDirection3 == GameDirection.右下)
                                    {
                                        return true;
                                    }
                                    return false;
                                }
                            }
                            else
                            {
                                if (GameDirection3 == GameDirection.上方 || GameDirection3 == GameDirection.右上 || GameDirection3 == GameDirection.右方)
                                {
                                    return true;
                                }
                                return false;
                            }
                        }
                        else if (当前方向 != GameDirection.下方)
                        {
                            if (当前方向 == GameDirection.左下)
                            {
                                if (GameDirection3 == GameDirection.左方 || GameDirection3 == GameDirection.下方 || GameDirection3 == GameDirection.左下)
                                {
                                    return true;
                                }
                                return false;
                            }
                        }
                        else
                        {
                            if (GameDirection3 == GameDirection.右下 || GameDirection3 == GameDirection.下方 || GameDirection3 == GameDirection.左下)
                            {
                                return true;
                            }
                            return false;
                        }
                        if (GameDirection3 == GameDirection.右方 || GameDirection3 == GameDirection.右下 || GameDirection3 == GameDirection.下方)
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    PlayerObject PlayerObject = this as PlayerObject;
                    if (PlayerObject != null)
                    {
                        if (类型 == SpecifyTargetType.None)
                        {
                            return true;
                        }
                        if ((类型 & SpecifyTargetType.LowLevelTarget) == SpecifyTargetType.LowLevelTarget && this.当前等级 < MapObject.当前等级)
                        {
                            return true;
                        }
                        if ((类型 & SpecifyTargetType.ShieldMage) == SpecifyTargetType.ShieldMage && PlayerObject.角色职业 == GameObjectRace.法师 && PlayerObject.Buff列表.ContainsKey(25350))
                        {
                            return true;
                        }
                        if ((类型 & SpecifyTargetType.Backstab) == SpecifyTargetType.Backstab)
                        {
                            GameDirection GameDirection4 = ComputingClass.计算方向(来源.当前坐标, this.当前坐标);
                            GameDirection 当前方向 = this.当前方向;
                            if (当前方向 <= GameDirection.上方)
                            {
                                if (当前方向 != GameDirection.左方)
                                {
                                    if (当前方向 != GameDirection.左上)
                                    {
                                        if (当前方向 == GameDirection.上方)
                                        {
                                            if (GameDirection4 == GameDirection.左上 || GameDirection4 == GameDirection.上方 || GameDirection4 == GameDirection.右上)
                                            {
                                                return true;
                                            }
                                            goto IL_7A8;
                                        }
                                    }
                                    else
                                    {
                                        if (GameDirection4 == GameDirection.左方 || GameDirection4 == GameDirection.左上 || GameDirection4 == GameDirection.上方)
                                        {
                                            return true;
                                        }
                                        goto IL_7A8;
                                    }
                                }
                                else
                                {
                                    if (GameDirection4 == GameDirection.左方 || GameDirection4 == GameDirection.左上 || GameDirection4 == GameDirection.左下)
                                    {
                                        return true;
                                    }
                                    goto IL_7A8;
                                }
                            }
                            else if (当前方向 <= GameDirection.右方)
                            {
                                if (当前方向 != GameDirection.右上)
                                {
                                    if (当前方向 == GameDirection.右方)
                                    {
                                        if (GameDirection4 == GameDirection.右上 || GameDirection4 == GameDirection.右方 || GameDirection4 == GameDirection.右下)
                                        {
                                            return true;
                                        }
                                        goto IL_7A8;
                                    }
                                }
                                else
                                {
                                    if (GameDirection4 == GameDirection.上方 || GameDirection4 == GameDirection.右上 || GameDirection4 == GameDirection.右方)
                                    {
                                        return true;
                                    }
                                    goto IL_7A8;
                                }
                            }
                            else if (当前方向 != GameDirection.下方)
                            {
                                if (当前方向 == GameDirection.左下)
                                {
                                    if (GameDirection4 == GameDirection.左方 || GameDirection4 == GameDirection.下方 || GameDirection4 == GameDirection.左下)
                                    {
                                        return true;
                                    }
                                    goto IL_7A8;
                                }
                            }
                            else
                            {
                                if (GameDirection4 == GameDirection.右下 || GameDirection4 == GameDirection.下方 || GameDirection4 == GameDirection.左下)
                                {
                                    return true;
                                }
                                goto IL_7A8;
                            }
                            if (GameDirection4 == GameDirection.右方 || GameDirection4 == GameDirection.右下 || GameDirection4 == GameDirection.下方)
                            {
                                return true;
                            }
                        }
                    IL_7A8:
                        if ((类型 & SpecifyTargetType.AllPlayers) == SpecifyTargetType.AllPlayers)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        
        public virtual bool 能否走动()
        {
            return !this.对象死亡 && !(MainProcess.CurrentTime < this.忙碌时间) && !(MainProcess.CurrentTime < this.行走时间) && !this.检查状态(GameObjectState.BusyGreen | GameObjectState.Inmobilized | GameObjectState.Paralyzed | GameObjectState.Absence);
        }

        
        public virtual bool 能否跑动()
        {
            return !this.对象死亡 && !(MainProcess.CurrentTime < this.忙碌时间) && !(MainProcess.CurrentTime < this.奔跑时间) && !this.检查状态(GameObjectState.BusyGreen | GameObjectState.Disabled | GameObjectState.Inmobilized | GameObjectState.Paralyzed | GameObjectState.Absence);
        }

        
        public virtual bool 能否转动()
        {
            return !this.对象死亡 && !(MainProcess.CurrentTime < this.忙碌时间) && !(MainProcess.CurrentTime < this.行走时间) && !this.检查状态(GameObjectState.BusyGreen | GameObjectState.Paralyzed | GameObjectState.Absence);
        }

        
        public virtual bool 能被推动(MapObject 来源)
        {
            if (this == 来源)
            {
                return true;
            }
            if (this is GuardInstance)
            {
                return false;
            }
            if (this.当前等级 >= 来源.当前等级)
            {
                return false;
            }
            MonsterObject MonsterObject = this as MonsterObject;
            return (MonsterObject == null || MonsterObject.CanBeDrivenBySkills) && 来源.对象关系(this) == 游戏对象关系.敌对;
        }

        
        public virtual bool 能否位移(MapObject 来源, Point 锚点, int 距离, int 数量, bool 穿墙, out Point 终点, out MapObject[] 目标)
        {
            终点 = this.当前坐标;
            目标 = null;
            if (!(this.当前坐标 == 锚点) && this.能被推动(来源))
            {
                List<MapObject> list = new List<MapObject>();
                for (int i = 1; i <= 距离; i++)
                {
                    if (穿墙)
                    {
                        Point point = ComputingClass.前方坐标(this.当前坐标, 锚点, i);
                        if (this.当前地图.能否通行(point))
                        {
                            终点 = point;
                        }
                    }
                    else
                    {
                        GameDirection 方向 = ComputingClass.计算方向(this.当前坐标, 锚点);
                        Point point2 = ComputingClass.前方坐标(this.当前坐标, 锚点, i);
                        if (this.当前地图.地形阻塞(point2))
                        {
                            break;
                        }
                        bool flag = false;
                        if (!this.当前地图.空间阻塞(point2))
                        {
                            goto IL_168;
                        }
                        using (IEnumerator<MapObject> enumerator = (from O in this.当前地图[point2]
                                                                    where O.阻塞网格
                                                                    select O).GetEnumerator())
                        {
                            while (enumerator.MoveNext())
                            {
                                MapObject MapObject = enumerator.Current;
                                if (list.Count >= 数量)
                                {
                                    flag = true;
                                    break;
                                }
                                Point point3;
                                MapObject[] collection;
                                if (!MapObject.能否位移(来源, ComputingClass.前方坐标(MapObject.当前坐标, 方向, 1), 1, 数量 - list.Count - 1, false, out point3, out collection))
                                {
                                    flag = true;
                                    break;
                                }
                                list.Add(MapObject);
                                list.AddRange(collection);
                            }
                            goto IL_168;
                        }
                    IL_155:
                        终点 = point2;
                        goto IL_15D;
                    IL_168:
                        if (flag)
                        {
                            break;
                        }
                        goto IL_155;
                    }
                IL_15D:;
                }
                目标 = list.ToArray();
                return 终点 != this.当前坐标;
            }
            return false;
        }

        
        public virtual bool 检查状态(GameObjectState 待检状态)
        {
            foreach (BuffData BuffData in this.Buff列表.Values)
            {
                if ((BuffData.Effect & BuffEffectType.状态标志) != BuffEffectType.技能标志 && (BuffData.Buff模板.PlayerState & 待检状态) != GameObjectState.Normal)
                {
                    return true;
                }
            }
            return false;
        }

        
        public void 添加Buff时处理(ushort 编号, MapObject 来源)
        {
            if (!(this is ItemObject) && !(this is TrapObject))
            {
                GuardInstance GuardInstance = this as GuardInstance;
                if (GuardInstance == null || GuardInstance.CanBeInjured)
                {
                    TrapObject TrapObject = 来源 as TrapObject;
                    if (TrapObject != null)
                    {
                        来源 = TrapObject.陷阱来源;
                    }
                    GameBuffs 游戏Buff;
                    if (GameBuffs.DataSheet.TryGetValue(编号, out 游戏Buff))
                    {
                        if ((游戏Buff.Effect & BuffEffectType.状态标志) != BuffEffectType.技能标志)
                        {
                            if (((游戏Buff.PlayerState & GameObjectState.Invisibility) != GameObjectState.Normal || (游戏Buff.PlayerState & GameObjectState.StealthStatus) != GameObjectState.Normal) && this.检查状态(GameObjectState.Exposed))
                            {
                                return;
                            }
                            if ((游戏Buff.PlayerState & GameObjectState.Exposed) != GameObjectState.Normal)
                            {
                                foreach (BuffData BuffData in this.Buff列表.Values.ToList<BuffData>())
                                {
                                    if ((BuffData.Buff模板.PlayerState & GameObjectState.Invisibility) != GameObjectState.Normal || (BuffData.Buff模板.PlayerState & GameObjectState.StealthStatus) != GameObjectState.Normal)
                                    {
                                        this.移除Buff时处理(BuffData.Id.V);
                                    }
                                }
                            }
                        }
                        if ((游戏Buff.Effect & BuffEffectType.造成伤害) != BuffEffectType.技能标志 && 游戏Buff.DamageType == SkillDamageType.Burn && this.Buff列表.ContainsKey(25352))
                        {
                            return;
                        }
                        ushort GroupId = (游戏Buff.GroupId != 0) ? 游戏Buff.GroupId : 游戏Buff.Id;
                        BuffData BuffData2 = null;
                        switch (游戏Buff.OverlayType)
                        {
                            case BuffOverlayType.禁止叠加:
                                if (this.Buff列表.Values.FirstOrDefault((BuffData O) => O.Buff分组 == GroupId) == null)
                                {
                                    BuffData2 = (this.Buff列表[游戏Buff.Id] = new BuffData(来源, this, 游戏Buff.Id));
                                }
                                break;
                            case BuffOverlayType.同类替换:
                                {
                                    IEnumerable<BuffData> values = this.Buff列表.Values;
                                    Func<BuffData, bool> predicate = null;

                                    if (predicate == null)
                                    {
                                        predicate = ((BuffData O) => O.Buff分组 == GroupId);
                                    }
                                    foreach (BuffData BuffData3 in values.Where(predicate).ToList<BuffData>())
                                    {
                                        this.移除Buff时处理(BuffData3.Id.V);
                                    }
                                    BuffData2 = (this.Buff列表[游戏Buff.Id] = new BuffData(来源, this, 游戏Buff.Id));
                                    break;
                                }
                            case BuffOverlayType.同类叠加:
                                {
                                    BuffData BuffData4;
                                    if (this.Buff列表.TryGetValue(编号, out BuffData4))
                                    {
                                        BuffData4.当前层数.V = (byte)Math.Min(BuffData4.当前层数.V + 1, BuffData4.最大层数);
                                        GameBuffs 游戏Buff2;
                                        if (游戏Buff.AllowsSynthesis && BuffData4.当前层数.V >= 游戏Buff.BuffSynthesisLayer && GameBuffs.DataSheet.TryGetValue(游戏Buff.BuffSynthesisId, out 游戏Buff2))
                                        {
                                            this.移除Buff时处理(BuffData4.Id.V);
                                            this.添加Buff时处理(游戏Buff.BuffSynthesisId, 来源);
                                        }
                                        else
                                        {
                                            BuffData4.剩余时间.V = BuffData4.持续时间.V;
                                            if (BuffData4.Buff同步)
                                            {
                                                this.发送封包(new ObjectStateChangePacket
                                                {
                                                    对象编号 = this.MapId,
                                                    Id = BuffData4.Id.V,
                                                    Buff索引 = (int)BuffData4.Id.V,
                                                    当前层数 = BuffData4.当前层数.V,
                                                    剩余时间 = (int)BuffData4.剩余时间.V.TotalMilliseconds,
                                                    持续时间 = (int)BuffData4.持续时间.V.TotalMilliseconds
                                                });
                                            }
                                        }
                                    }
                                    else
                                    {
                                        BuffData2 = (this.Buff列表[游戏Buff.Id] = new BuffData(来源, this, 游戏Buff.Id));
                                    }
                                    break;
                                }
                            case BuffOverlayType.同类延时:
                                {
                                    BuffData BuffData5;
                                    if (this.Buff列表.TryGetValue(编号, out BuffData5))
                                    {
                                        BuffData5.剩余时间.V += BuffData5.持续时间.V;
                                        if (BuffData5.Buff同步)
                                        {
                                            this.发送封包(new ObjectStateChangePacket
                                            {
                                                对象编号 = this.MapId,
                                                Id = BuffData5.Id.V,
                                                Buff索引 = (int)BuffData5.Id.V,
                                                当前层数 = BuffData5.当前层数.V,
                                                剩余时间 = (int)BuffData5.剩余时间.V.TotalMilliseconds,
                                                持续时间 = (int)BuffData5.持续时间.V.TotalMilliseconds
                                            });
                                        }
                                    }
                                    else
                                    {
                                        BuffData2 = (this.Buff列表[游戏Buff.Id] = new BuffData(来源, this, 游戏Buff.Id));
                                    }
                                    break;
                                }
                        }
                        if (BuffData2 != null)
                        {
                            if (BuffData2.Buff同步)
                            {
                                this.发送封包(new ObjectAddStatePacket
                                {
                                    对象编号 = this.MapId,
                                    Buff来源 = 来源.MapId,
                                    Id = BuffData2.Id.V,
                                    Buff索引 = (int)BuffData2.Id.V,
                                    Buff层数 = BuffData2.当前层数.V,
                                    持续时间 = (int)BuffData2.持续时间.V.TotalMilliseconds
                                });
                            }
                            if ((游戏Buff.Effect & BuffEffectType.StatsIncOrDec) != BuffEffectType.技能标志)
                            {
                                this.Stat加成.Add(BuffData2, BuffData2.Stat加成);
                                this.更新对象Stat();
                            }
                            if ((游戏Buff.Effect & BuffEffectType.状态标志) != BuffEffectType.技能标志)
                            {
                                if ((游戏Buff.PlayerState & GameObjectState.Invisibility) != GameObjectState.Normal)
                                {
                                    foreach (MapObject MapObject in this.邻居列表.ToList<MapObject>())
                                    {
                                        MapObject.对象隐身时处理(this);
                                    }
                                }
                                if ((游戏Buff.PlayerState & GameObjectState.StealthStatus) != GameObjectState.Normal)
                                {
                                    foreach (MapObject MapObject2 in this.邻居列表.ToList<MapObject>())
                                    {
                                        MapObject2.对象潜行时处理(this);
                                    }
                                }
                            }
                            if (游戏Buff.AssociatedId != 0)
                            {
                                this.添加Buff时处理(游戏Buff.AssociatedId, 来源);
                            }
                        }
                    }
                    return;
                }
            }
        }

        
        public void 移除Buff时处理(ushort 编号)
        {
            BuffData BuffData;
            if (this.Buff列表.TryGetValue(编号, out BuffData))
            {
                MapObject MapObject;
                if (BuffData.Buff模板.FollowedById != 0 && BuffData.Buff来源 != null && MapGatewayProcess.Objects.TryGetValue(BuffData.Buff来源.MapId, out MapObject) && MapObject == BuffData.Buff来源)
                {
                    this.添加Buff时处理(BuffData.Buff模板.FollowedById, BuffData.Buff来源);
                }
                if (BuffData.依存列表 != null)
                {
                    foreach (ushort 编号2 in BuffData.依存列表)
                    {
                        this.删除Buff时处理(编号2);
                    }
                }
                if (BuffData.添加冷却 && BuffData.绑定技能 != 0 && BuffData.Cooldown != 0)
                {
                    PlayerObject PlayerObject = this as PlayerObject;
                    if (PlayerObject != null && PlayerObject.MainSkills表.ContainsKey(BuffData.绑定技能))
                    {
                        DateTime dateTime = MainProcess.CurrentTime.AddMilliseconds((double)BuffData.Cooldown);
                        DateTime t = this.冷却记录.ContainsKey((int)BuffData.绑定技能 | 16777216) ? this.冷却记录[(int)BuffData.绑定技能 | 16777216] : default(DateTime);
                        if (dateTime > t)
                        {
                            this.冷却记录[(int)BuffData.绑定技能 | 16777216] = dateTime;
                            this.发送封包(new AddedSkillCooldownPacket
                            {
                                冷却编号 = ((int)BuffData.绑定技能 | 16777216),
                                Cooldown = (int)BuffData.Cooldown
                            });
                        }
                    }
                }
                this.Buff列表.Remove(编号);
                BuffData.Delete();
                if (BuffData.Buff同步)
                {
                    this.发送封包(new ObjectRemovalStatusPacket
                    {
                        对象编号 = this.MapId,
                        Buff索引 = (int)编号
                    });
                }
                if ((BuffData.Effect & BuffEffectType.StatsIncOrDec) != BuffEffectType.技能标志)
                {
                    this.Stat加成.Remove(BuffData);
                    this.更新对象Stat();
                }
                if ((BuffData.Effect & BuffEffectType.状态标志) != BuffEffectType.技能标志)
                {
                    if ((BuffData.Buff模板.PlayerState & GameObjectState.Invisibility) != GameObjectState.Normal)
                    {
                        foreach (MapObject MapObject2 in this.邻居列表.ToList<MapObject>())
                        {
                            MapObject2.对象显隐时处理(this);
                        }
                    }
                    if ((BuffData.Buff模板.PlayerState & GameObjectState.StealthStatus) != GameObjectState.Normal)
                    {
                        foreach (MapObject MapObject3 in this.邻居列表.ToList<MapObject>())
                        {
                            MapObject3.对象显行时处理(this);
                        }
                    }
                }
            }
        }

        
        public void 删除Buff时处理(ushort 编号)
        {
            BuffData BuffData;
            if (this.Buff列表.TryGetValue(编号, out BuffData))
            {
                if (BuffData.依存列表 != null)
                {
                    foreach (ushort 编号2 in BuffData.依存列表)
                    {
                        this.删除Buff时处理(编号2);
                    }
                }
                this.Buff列表.Remove(编号);
                BuffData.Delete();
                if (BuffData.Buff同步)
                {
                    this.发送封包(new ObjectRemovalStatusPacket
                    {
                        对象编号 = this.MapId,
                        Buff索引 = (int)编号
                    });
                }
                if ((BuffData.Effect & BuffEffectType.StatsIncOrDec) != BuffEffectType.技能标志)
                {
                    this.Stat加成.Remove(BuffData);
                    this.更新对象Stat();
                }
                if ((BuffData.Effect & BuffEffectType.状态标志) != BuffEffectType.技能标志)
                {
                    if ((BuffData.Buff模板.PlayerState & GameObjectState.Invisibility) != GameObjectState.Normal)
                    {
                        foreach (MapObject MapObject in this.邻居列表.ToList<MapObject>())
                        {
                            MapObject.对象显隐时处理(this);
                        }
                    }
                    if ((BuffData.Buff模板.PlayerState & GameObjectState.StealthStatus) != GameObjectState.Normal)
                    {
                        foreach (MapObject MapObject2 in this.邻居列表.ToList<MapObject>())
                        {
                            MapObject2.对象显行时处理(this);
                        }
                    }
                }
            }
        }

        
        public void 轮询Buff时处理(BuffData 数据)
        {
            if (数据.到期消失 && (数据.剩余时间.V -= MainProcess.CurrentTime - this.处理计时) < TimeSpan.Zero)
            {
                this.移除Buff时处理(数据.Id.V);
                return;
            }
            if ((数据.处理计时.V -= MainProcess.CurrentTime - this.处理计时) < TimeSpan.Zero)
            {
                数据.处理计时.V += TimeSpan.FromMilliseconds((double)数据.处理间隔);
                if ((数据.Effect & BuffEffectType.造成伤害) != BuffEffectType.技能标志)
                {
                    this.被动受伤时处理(数据);
                }
                if ((数据.Effect & BuffEffectType.生命回复) != BuffEffectType.技能标志)
                {
                    this.被动回复时处理(数据);
                }
            }
        }

        
        public void 被技能命中处理(技能实例 技能, C_01_计算命中目标 参数)
        {
            TrapObject TrapObject = 技能.技能来源 as TrapObject;
            MapObject MapObject = (TrapObject != null) ? TrapObject.陷阱来源 : 技能.技能来源;
            if (技能.命中列表.ContainsKey(this.MapId) || !this.能被命中)
            {
                return;
            }
            if (this != MapObject && !this.邻居列表.Contains(MapObject))
            {
                return;
            }
            if (技能.命中列表.Count >= 参数.限定命中数量)
            {
                return;
            }
            if ((参数.限定目标关系 & MapObject.对象关系(this)) == (游戏对象关系)0)
            {
                return;
            }
            if ((参数.限定目标类型 & this.对象类型) == (GameObjectType)0)
            {
                return;
            }
            if (!this.特定类型(技能.技能来源, 参数.限定特定类型))
            {
                return;
            }
            if ((参数.限定目标关系 & 游戏对象关系.敌对) != (游戏对象关系)0)
            {
                if (this.检查状态(GameObjectState.Invencible))
                {
                    return;
                }
                if ((this is PlayerObject || this is PetObject) && (MapObject is PlayerObject || MapObject is PetObject) && (this.当前地图.安全区内(this.当前坐标) || MapObject.当前地图.安全区内(MapObject.当前坐标)))
                {
                    return;
                }
                if (MapObject is MonsterObject && this.当前地图.安全区内(this.当前坐标))
                {
                    return;
                }
            }
            MonsterObject MonsterObject = this as MonsterObject;
            if (MonsterObject != null && (MonsterObject.模板编号 == 8618 || MonsterObject.模板编号 == 8621))
            {
                PlayerObject PlayerObject = MapObject as PlayerObject;
                if (PlayerObject != null && PlayerObject.所属行会 != null && PlayerObject.所属行会 == SystemData.数据.占领行会.V)
                {
                    return;
                }
                PetObject PetObject = MapObject as PetObject;
                if (PetObject != null && PetObject.宠物主人 != null && PetObject.宠物主人.所属行会 != null && PetObject.宠物主人.所属行会 == SystemData.数据.占领行会.V)
                {
                    return;
                }
            }
            int num = 0;
            float num2 = 0f;
            int num3 = 0;
            float num4 = 0f;
            switch (参数.技能闪避方式)
            {
                case 技能闪避类型.技能无法闪避:
                    num = 1;
                    break;
                case 技能闪避类型.可被物理闪避:
                    num3 = this[GameObjectStats.PhysicalAgility];
                    num = MapObject[GameObjectStats.PhysicallyAccurate];
                    if (this is MonsterObject)
                    {
                        num2 += (float)MapObject[GameObjectStats.怪物命中] / 10000f;
                    }
                    if (MapObject is MonsterObject)
                    {
                        num4 += (float)this[GameObjectStats.怪物闪避] / 10000f;
                    }
                    break;
                case 技能闪避类型.可被MagicDodge:
                    num4 = (float)this[GameObjectStats.MagicDodge] / 10000f;
                    if (this is MonsterObject)
                    {
                        num2 += (float)MapObject[GameObjectStats.怪物命中] / 10000f;
                    }
                    if (MapObject is MonsterObject)
                    {
                        num4 += (float)this[GameObjectStats.怪物闪避] / 10000f;
                    }
                    break;
                case 技能闪避类型.可被中毒闪避:
                    num4 = (float)this[GameObjectStats.中毒躲避] / 10000f;
                    break;
                case 技能闪避类型.非怪物可闪避:
                    if (this is MonsterObject)
                    {
                        num = 1;
                    }
                    else
                    {
                        num3 = this[GameObjectStats.PhysicalAgility];
                        num = MapObject[GameObjectStats.PhysicallyAccurate];
                    }
                    break;
            }
            命中详情 value = new 命中详情(this)
            {
                技能反馈 = (ComputingClass.计算命中((float)num, (float)num3, num2, num4) ? 参数.技能命中反馈 : 技能命中反馈.闪避)
            };
            技能.命中列表.Add(this.MapId, value);
        }

        
        public void 被动受伤时处理(技能实例 技能, C_02_计算目标伤害 参数, 命中详情 详情, float 伤害系数)
        {
            TrapObject TrapObject = 技能.技能来源 as TrapObject;
            MapObject MapObject = (TrapObject != null) ? TrapObject.陷阱来源 : 技能.技能来源;
            if (this.对象死亡)
            {
                详情.技能反馈 = 技能命中反馈.丢失;
            }
            else if (!this.邻居列表.Contains(MapObject))
            {
                详情.技能反馈 = 技能命中反馈.丢失;
            }
            else if ((MapObject.对象关系(this) & 游戏对象关系.敌对) == (游戏对象关系)0)
            {
                详情.技能反馈 = 技能命中反馈.丢失;
            }
            else
            {
                MonsterObject MonsterObject = this as MonsterObject;
                if (MonsterObject != null && (MonsterObject.模板编号 == 8618 || MonsterObject.模板编号 == 8621) && this.网格距离(MapObject) >= 4)
                {
                    详情.技能反馈 = 技能命中反馈.丢失;
                }
            }
            if ((详情.技能反馈 & 技能命中反馈.免疫) == 技能命中反馈.正常 && (详情.技能反馈 & 技能命中反馈.丢失) == 技能命中反馈.正常)
            {
                if ((详情.技能反馈 & 技能命中反馈.闪避) == 技能命中反馈.正常)
                {
                    if (参数.技能斩杀类型 != SpecifyTargetType.None && ComputingClass.计算概率(参数.技能斩杀概率) && this.特定类型(MapObject, 参数.技能斩杀类型))
                    {
                        详情.技能伤害 = this.当前体力;
                    }
                    else
                    {
                        int[] 技能伤害基数 = 参数.技能伤害基数;
                        int? num = (技能伤害基数 != null) ? new int?(技能伤害基数.Length) : null;
                        int num2 = (int)技能.技能等级;
                        int num3 = (num.GetValueOrDefault() > num2 & num != null) ? 参数.技能伤害基数[(int)技能.技能等级] : 0;
                        float[] 技能伤害系数 = 参数.技能伤害系数;
                        num = ((技能伤害系数 != null) ? new int?(技能伤害系数.Length) : null);
                        num2 = (int)技能.技能等级;
                        float num4 = (num.GetValueOrDefault() > num2 & num != null) ? 参数.技能伤害系数[(int)技能.技能等级] : 0f;
                        if (this is MonsterObject)
                        {
                            num3 += MapObject[GameObjectStats.怪物伤害];
                        }
                        int num5 = 0;
                        float num6 = 0f;
                        if (参数.技能增伤类型 != SpecifyTargetType.None && this.特定类型(MapObject, 参数.技能增伤类型))
                        {
                            num5 = 参数.技能增伤基数;
                            num6 = 参数.技能增伤系数;
                        }
                        int num7 = 0;
                        float num8 = 0f;
                        if (参数.技能破防概率 > 0f && ComputingClass.计算概率(参数.技能破防概率))
                        {
                            num7 = 参数.技能破防基数;
                            num8 = 参数.技能破防系数;
                        }
                        int num9 = 0;
                        int num10 = 0;
                        switch (参数.技能伤害类型)
                        {
                            case SkillDamageType.Attack:
                                num10 = ComputingClass.计算防御(this[GameObjectStats.MinDef], this[GameObjectStats.MaxDef]);
                                num9 = ComputingClass.计算Attack(MapObject[GameObjectStats.MinAttack], MapObject[GameObjectStats.MaxAttack], MapObject[GameObjectStats.幸运等级]);
                                break;
                            case SkillDamageType.Magic:
                                num10 = ComputingClass.计算防御(this[GameObjectStats.MinMagicDef], this[GameObjectStats.MaxMagicDef]);
                                num9 = ComputingClass.计算Attack(MapObject[GameObjectStats.MinMagic], MapObject[GameObjectStats.MaxMagic], MapObject[GameObjectStats.幸运等级]);
                                break;
                            case SkillDamageType.Taoism:
                                num10 = ComputingClass.计算防御(this[GameObjectStats.MinMagicDef], this[GameObjectStats.MaxMagicDef]);
                                num9 = ComputingClass.计算Attack(MapObject[GameObjectStats.Minimalist], MapObject[GameObjectStats.GreatestTaoism], MapObject[GameObjectStats.幸运等级]);
                                break;
                            case SkillDamageType.Needle:
                                num10 = ComputingClass.计算防御(this[GameObjectStats.MinDef], this[GameObjectStats.MaxDef]);
                                num9 = ComputingClass.计算Attack(MapObject[GameObjectStats.MinNeedle], MapObject[GameObjectStats.MaxNeedle], MapObject[GameObjectStats.幸运等级]);
                                break;
                            case SkillDamageType.Archery:
                                num10 = ComputingClass.计算防御(this[GameObjectStats.MinDef], this[GameObjectStats.MaxDef]);
                                num9 = ComputingClass.计算Attack(MapObject[GameObjectStats.MinBow], MapObject[GameObjectStats.MaxBow], MapObject[GameObjectStats.幸运等级]);
                                break;
                            case SkillDamageType.Toxicity:
                                num9 = MapObject[GameObjectStats.GreatestTaoism];
                                break;
                            case SkillDamageType.Sacred:
                                num9 = ComputingClass.计算Attack(MapObject[GameObjectStats.最小圣伤], MapObject[GameObjectStats.最大圣伤], 0);
                                break;
                        }
                        if (this is MonsterObject)
                        {
                            num10 = Math.Max(0, num10 - (int)((float)(num10 * MapObject[GameObjectStats.怪物破防]) / 10000f));
                        }
                        int num11 = 0;
                        float num12 = 0f;
                        int num13 = int.MaxValue;
                        foreach (BuffData BuffData in MapObject.Buff列表.Values.ToList<BuffData>())
                        {
                            if ((BuffData.Effect & BuffEffectType.伤害增减) != BuffEffectType.技能标志 && (BuffData.Buff模板.HowJudgeEffect == BuffDetherminationMethod.ActiveAttackDamageBoost || BuffData.Buff模板.HowJudgeEffect == BuffDetherminationMethod.ActiveAttackDamageReduction))
                            {
                                bool flag = false;
                                switch (参数.技能伤害类型)
                                {
                                    case SkillDamageType.Attack:
                                    case SkillDamageType.Needle:
                                    case SkillDamageType.Archery:
                                        {
                                            BuffJudgmentType EffectJudgeType = BuffData.Buff模板.EffectJudgeType;
                                            if (EffectJudgeType > BuffJudgmentType.AllPhysicalDamage)
                                            {
                                                if (EffectJudgeType == BuffJudgmentType.AllSpecificInjuries)
                                                {
                                                    HashSet<ushort> SpecificSkillId = BuffData.Buff模板.SpecificSkillId;
                                                    flag = (SpecificSkillId != null && SpecificSkillId.Contains(技能.SkillId));
                                                }
                                            }
                                            else
                                            {
                                                flag = true;
                                            }
                                            break;
                                        }
                                    case SkillDamageType.Magic:
                                    case SkillDamageType.Taoism:
                                        switch (BuffData.Buff模板.EffectJudgeType)
                                        {
                                            case BuffJudgmentType.AllSkillDamage:
                                            case BuffJudgmentType.AllMagicDamage:
                                                flag = true;
                                                break;
                                            case BuffJudgmentType.AllSpecificInjuries:
                                                {
                                                    HashSet<ushort> SpecificSkillId2 = BuffData.Buff模板.SpecificSkillId;
                                                    flag = (SpecificSkillId2 != null && SpecificSkillId2.Contains(技能.SkillId));
                                                    break;
                                                }
                                        }
                                        break;
                                    case SkillDamageType.Toxicity:
                                    case SkillDamageType.Sacred:
                                    case SkillDamageType.Burn:
                                    case SkillDamageType.Tear:
                                        if (BuffData.Buff模板.EffectJudgeType == BuffJudgmentType.AllSpecificInjuries)
                                        {
                                            HashSet<ushort> SpecificSkillId3 = BuffData.Buff模板.SpecificSkillId;
                                            flag = (SpecificSkillId3 != null && SpecificSkillId3.Contains(技能.SkillId));
                                        }
                                        break;
                                }
                                if (flag)
                                {
                                    int v = (int)BuffData.当前层数.V;
                                    int[] DamageIncOrDecBase = BuffData.Buff模板.DamageIncOrDecBase;
                                    num = ((DamageIncOrDecBase != null) ? new int?(DamageIncOrDecBase.Length) : null);
                                    num2 = (int)BuffData.Buff等级.V;
                                    int num14 = v * ((num.GetValueOrDefault() > num2 & num != null) ? BuffData.Buff模板.DamageIncOrDecBase[(int)BuffData.Buff等级.V] : 0);
                                    float num15 = (float)BuffData.当前层数.V;
                                    float[] DamageIncOrDecFactor = BuffData.Buff模板.DamageIncOrDecFactor;
                                    num = ((DamageIncOrDecFactor != null) ? new int?(DamageIncOrDecFactor.Length) : null);
                                    num2 = (int)BuffData.Buff等级.V;
                                    float num16 = num15 * ((num.GetValueOrDefault() > num2 & num != null) ? BuffData.Buff模板.DamageIncOrDecFactor[(int)BuffData.Buff等级.V] : 0f);
                                    num11 += ((BuffData.Buff模板.HowJudgeEffect == BuffDetherminationMethod.ActiveAttackDamageBoost) ? num14 : (-num14));
                                    num12 += ((BuffData.Buff模板.HowJudgeEffect == BuffDetherminationMethod.ActiveAttackDamageBoost) ? num16 : (-num16));
                                    MapObject MapObject2;
                                    if (BuffData.Buff模板.EffectiveFollowedById != 0 && BuffData.Buff来源 != null && MapGatewayProcess.Objects.TryGetValue(BuffData.Buff来源.MapId, out MapObject2) && MapObject2 == BuffData.Buff来源)
                                    {
                                        if (BuffData.Buff模板.FollowUpSkillSource)
                                        {
                                            MapObject.添加Buff时处理(BuffData.Buff模板.EffectiveFollowedById, BuffData.Buff来源);
                                        }
                                        else
                                        {
                                            this.添加Buff时处理(BuffData.Buff模板.EffectiveFollowedById, BuffData.Buff来源);
                                        }
                                    }
                                    if (BuffData.Buff模板.EffectRemoved)
                                    {
                                        MapObject.移除Buff时处理(BuffData.Id.V);
                                    }
                                }
                            }
                        }
                        foreach (BuffData BuffData2 in this.Buff列表.Values.ToList<BuffData>())
                        {
                            if ((BuffData2.Effect & BuffEffectType.伤害增减) != BuffEffectType.技能标志 && (BuffData2.Buff模板.HowJudgeEffect == BuffDetherminationMethod.PassiveInjuryIncrease || BuffData2.Buff模板.HowJudgeEffect == BuffDetherminationMethod.PassiveInjuryReduction))
                            {
                                bool flag2 = false;
                                switch (参数.技能伤害类型)
                                {
                                    case SkillDamageType.Attack:
                                    case SkillDamageType.Needle:
                                    case SkillDamageType.Archery:
                                        {
                                            BuffJudgmentType EffectJudgeType = BuffData2.Buff模板.EffectJudgeType;
                                            if (EffectJudgeType <= BuffJudgmentType.AllSpecificInjuries)
                                            {
                                                if (EffectJudgeType > BuffJudgmentType.AllPhysicalDamage)
                                                {
                                                    if (EffectJudgeType == BuffJudgmentType.AllSpecificInjuries)
                                                    {
                                                        HashSet<ushort> SpecificSkillId4 = BuffData2.Buff模板.SpecificSkillId;
                                                        flag2 = (SpecificSkillId4 != null && SpecificSkillId4.Contains(技能.SkillId));
                                                    }
                                                }
                                                else
                                                {
                                                    flag2 = true;
                                                }
                                            }
                                            else if (EffectJudgeType != BuffJudgmentType.SourceSkillDamage && EffectJudgeType != BuffJudgmentType.SourcePhysicalDamage)
                                            {
                                                if (EffectJudgeType == BuffJudgmentType.SourceSpecificDamage)
                                                {
                                                    bool flag3;
                                                    if (MapObject == BuffData2.Buff来源)
                                                    {
                                                        HashSet<ushort> SpecificSkillId5 = BuffData2.Buff模板.SpecificSkillId;
                                                        flag3 = (SpecificSkillId5 != null && SpecificSkillId5.Contains(技能.SkillId));
                                                    }
                                                    else
                                                    {
                                                        flag3 = false;
                                                    }
                                                    flag2 = flag3;
                                                }
                                            }
                                            else
                                            {
                                                flag2 = (MapObject == BuffData2.Buff来源);
                                            }
                                            break;
                                        }
                                    case SkillDamageType.Magic:
                                    case SkillDamageType.Taoism:
                                        {
                                            BuffJudgmentType EffectJudgeType = BuffData2.Buff模板.EffectJudgeType;
                                            if (EffectJudgeType <= BuffJudgmentType.SourceSkillDamage)
                                            {
                                                switch (EffectJudgeType)
                                                {
                                                    case BuffJudgmentType.AllSkillDamage:
                                                    case BuffJudgmentType.AllMagicDamage:
                                                        flag2 = true;
                                                        goto IL_953;
                                                    case BuffJudgmentType.AllPhysicalDamage:
                                                    case (BuffJudgmentType)3:
                                                        goto IL_953;
                                                    case BuffJudgmentType.AllSpecificInjuries:
                                                        flag2 = BuffData2.Buff模板.SpecificSkillId.Contains(技能.SkillId);
                                                        goto IL_953;
                                                    default:
                                                        if (EffectJudgeType != BuffJudgmentType.SourceSkillDamage)
                                                        {
                                                            goto IL_953;
                                                        }
                                                        break;
                                                }
                                            }
                                            else if (EffectJudgeType != BuffJudgmentType.SourceMagicDamage)
                                            {
                                                if (EffectJudgeType != BuffJudgmentType.SourceSpecificDamage)
                                                {
                                                    break;
                                                }
                                                bool flag4;
                                                if (MapObject == BuffData2.Buff来源)
                                                {
                                                    HashSet<ushort> SpecificSkillId6 = BuffData2.Buff模板.SpecificSkillId;
                                                    flag4 = (SpecificSkillId6 != null && SpecificSkillId6.Contains(技能.SkillId));
                                                }
                                                else
                                                {
                                                    flag4 = false;
                                                }
                                                flag2 = flag4;
                                                break;
                                            }
                                            flag2 = (MapObject == BuffData2.Buff来源);
                                            break;
                                        }
                                    case SkillDamageType.Toxicity:
                                    case SkillDamageType.Sacred:
                                    case SkillDamageType.Burn:
                                    case SkillDamageType.Tear:
                                        {
                                            BuffJudgmentType EffectJudgeType = BuffData2.Buff模板.EffectJudgeType;
                                            if (EffectJudgeType != BuffJudgmentType.AllSpecificInjuries)
                                            {
                                                if (EffectJudgeType == BuffJudgmentType.SourceSpecificDamage)
                                                {
                                                    bool flag5;
                                                    if (MapObject == BuffData2.Buff来源)
                                                    {
                                                        HashSet<ushort> SpecificSkillId7 = BuffData2.Buff模板.SpecificSkillId;
                                                        flag5 = (SpecificSkillId7 != null && SpecificSkillId7.Contains(技能.SkillId));
                                                    }
                                                    else
                                                    {
                                                        flag5 = false;
                                                    }
                                                    flag2 = flag5;
                                                }
                                            }
                                            else
                                            {
                                                HashSet<ushort> SpecificSkillId8 = BuffData2.Buff模板.SpecificSkillId;
                                                flag2 = (SpecificSkillId8 != null && SpecificSkillId8.Contains(技能.SkillId));
                                            }
                                            break;
                                        }
                                }
                            IL_953:
                                if (flag2)
                                {
                                    int v2 = (int)BuffData2.当前层数.V;
                                    int[] DamageIncOrDecBase2 = BuffData2.Buff模板.DamageIncOrDecBase;
                                    num = ((DamageIncOrDecBase2 != null) ? new int?(DamageIncOrDecBase2.Length) : null);
                                    num2 = (int)BuffData2.Buff等级.V;
                                    int num17 = v2 * ((num.GetValueOrDefault() > num2 & num != null) ? BuffData2.Buff模板.DamageIncOrDecBase[(int)BuffData2.Buff等级.V] : 0);
                                    float num18 = (float)BuffData2.当前层数.V;
                                    float[] DamageIncOrDecFactor2 = BuffData2.Buff模板.DamageIncOrDecFactor;
                                    num = ((DamageIncOrDecFactor2 != null) ? new int?(DamageIncOrDecFactor2.Length) : null);
                                    num2 = (int)BuffData2.Buff等级.V;
                                    float num19 = num18 * ((num.GetValueOrDefault() > num2 & num != null) ? BuffData2.Buff模板.DamageIncOrDecFactor[(int)BuffData2.Buff等级.V] : 0f);
                                    num11 += ((BuffData2.Buff模板.HowJudgeEffect == BuffDetherminationMethod.PassiveInjuryIncrease) ? num17 : (-num17));
                                    num12 += ((BuffData2.Buff模板.HowJudgeEffect == BuffDetherminationMethod.PassiveInjuryIncrease) ? num19 : (-num19));
                                    MapObject MapObject3;
                                    if (BuffData2.Buff模板.EffectiveFollowedById != 0 && BuffData2.Buff来源 != null && MapGatewayProcess.Objects.TryGetValue(BuffData2.Buff来源.MapId, out MapObject3) && MapObject3 == BuffData2.Buff来源)
                                    {
                                        if (BuffData2.Buff模板.FollowUpSkillSource)
                                        {
                                            MapObject.添加Buff时处理(BuffData2.Buff模板.EffectiveFollowedById, BuffData2.Buff来源);
                                        }
                                        else
                                        {
                                            this.添加Buff时处理(BuffData2.Buff模板.EffectiveFollowedById, BuffData2.Buff来源);
                                        }
                                    }
                                    if (BuffData2.Buff模板.HowJudgeEffect == BuffDetherminationMethod.PassiveInjuryReduction && BuffData2.Buff模板.LimitedDamage)
                                    {
                                        num13 = Math.Min(num13, BuffData2.Buff模板.LimitedDamageValue);
                                    }
                                    if (BuffData2.Buff模板.EffectRemoved)
                                    {
                                        this.移除Buff时处理(BuffData2.Id.V);
                                    }
                                }
                            }
                        }
                        float num20 = (num4 + num6) * (float)num9 + (float)num3 + (float)num5 + (float)num11;
                        float val = (float)(num10 - num7) - (float)num10 * num8;
                        float val2 = (num20 - Math.Max(0f, val)) * (1f + num12) * 伤害系数;
                        int 技能伤害 = (int)Math.Min((float)num13, Math.Max(0f, val2));
                        详情.技能伤害 = 技能伤害;
                    }
                }
                this.脱战时间 = MainProcess.CurrentTime.AddSeconds(10.0);
                MapObject.脱战时间 = MainProcess.CurrentTime.AddSeconds(10.0);
                if ((详情.技能反馈 & 技能命中反馈.闪避) == 技能命中反馈.正常)
                {
                    foreach (BuffData BuffData3 in this.Buff列表.Values.ToList<BuffData>())
                    {
                        if ((BuffData3.Effect & BuffEffectType.状态标志) != BuffEffectType.技能标志 && (BuffData3.Buff模板.PlayerState & GameObjectState.Absence) != GameObjectState.Normal)
                        {
                            this.移除Buff时处理(BuffData3.Id.V);
                        }
                    }
                }
                MonsterObject MonsterObject2 = this as MonsterObject;
                if (MonsterObject2 != null)
                {
                    MonsterObject2.硬直时间 = MainProcess.CurrentTime.AddMilliseconds((double)参数.目标硬直时间);
                    if (MapObject is PlayerObject || MapObject is PetObject)
                    {
                        MonsterObject2.HateObject.添加仇恨(MapObject, MainProcess.CurrentTime.AddMilliseconds((double)MonsterObject2.仇恨时长), 详情.技能伤害);
                    }
                }
                else
                {
                    PlayerObject PlayerObject = this as PlayerObject;
                    if (PlayerObject != null)
                    {
                        if (详情.技能伤害 > 0)
                        {
                            PlayerObject.装备损失持久(详情.技能伤害);
                        }
                        if (详情.技能伤害 > 0)
                        {
                            PlayerObject.扣除护盾时间(详情.技能伤害);
                        }
                        if (PlayerObject.对象关系(MapObject) == 游戏对象关系.敌对)
                        {
                            foreach (PetObject PetObject in PlayerObject.宠物列表.ToList<PetObject>())
                            {
                                if (PetObject.邻居列表.Contains(MapObject) && !MapObject.检查状态(GameObjectState.Invisibility | GameObjectState.StealthStatus))
                                {
                                    PetObject.HateObject.添加仇恨(MapObject, MainProcess.CurrentTime.AddMilliseconds((double)PetObject.仇恨时长), 0);
                                }
                            }
                        }
                        PlayerObject PlayerObject2 = MapObject as PlayerObject;
                        if (PlayerObject2 != null && !this.当前地图.自由区内(this.当前坐标) && !PlayerObject.灰名玩家 && !PlayerObject.红名玩家)
                        {
                            if (PlayerObject2.红名玩家)
                            {
                                PlayerObject2.减PK时间 = TimeSpan.FromMinutes(1.0);
                            }
                            else
                            {
                                PlayerObject2.灰名时间 = TimeSpan.FromMinutes(1.0);
                            }
                        }
                        else
                        {
                            PetObject PetObject2 = MapObject as PetObject;
                            if (PetObject2 != null && !this.当前地图.自由区内(this.当前坐标) && !PlayerObject.灰名玩家 && !PlayerObject.红名玩家)
                            {
                                if (PetObject2.宠物主人.红名玩家)
                                {
                                    PetObject2.宠物主人.减PK时间 = TimeSpan.FromMinutes(1.0);
                                }
                                else
                                {
                                    PetObject2.宠物主人.灰名时间 = TimeSpan.FromMinutes(1.0);
                                }
                            }
                        }
                    }
                    else
                    {
                        PetObject PetObject3 = this as PetObject;
                        if (PetObject3 != null)
                        {
                            if (MapObject != PetObject3.宠物主人 && PetObject3.对象关系(MapObject) == 游戏对象关系.敌对)
                            {
                                PlayerObject 宠物主人 = PetObject3.宠物主人;
                                foreach (PetObject PetObject4 in ((宠物主人 != null) ? 宠物主人.宠物列表.ToList<PetObject>() : null))
                                {
                                    if (PetObject4.邻居列表.Contains(MapObject) && !MapObject.检查状态(GameObjectState.Invisibility | GameObjectState.StealthStatus))
                                    {
                                        PetObject4.HateObject.添加仇恨(MapObject, MainProcess.CurrentTime.AddMilliseconds((double)PetObject4.仇恨时长), 0);
                                    }
                                }
                            }
                            if (MapObject != PetObject3.宠物主人)
                            {
                                PlayerObject PlayerObject3 = MapObject as PlayerObject;
                                if (PlayerObject3 != null && !this.当前地图.自由区内(this.当前坐标) && !PetObject3.宠物主人.灰名玩家 && !PetObject3.宠物主人.红名玩家)
                                {
                                    PlayerObject3.灰名时间 = TimeSpan.FromMinutes(1.0);
                                }
                            }
                        }
                        else
                        {
                            GuardInstance GuardInstance = this as GuardInstance;
                            if (GuardInstance != null && GuardInstance.对象关系(MapObject) == 游戏对象关系.敌对)
                            {
                                GuardInstance.HateObject.添加仇恨(MapObject, default(DateTime), 0);
                            }
                        }
                    }
                }
                PlayerObject PlayerObject4 = MapObject as PlayerObject;
                if (PlayerObject4 != null)
                {
                    if (PlayerObject4.对象关系(this) == 游戏对象关系.敌对 && !this.检查状态(GameObjectState.Invisibility | GameObjectState.StealthStatus))
                    {
                        foreach (PetObject PetObject5 in PlayerObject4.宠物列表.ToList<PetObject>())
                        {
                            if (PetObject5.邻居列表.Contains(this))
                            {
                                PetObject5.HateObject.添加仇恨(this, MainProcess.CurrentTime.AddMilliseconds((double)PetObject5.仇恨时长), 参数.增加宠物仇恨 ? 详情.技能伤害 : 0);
                            }
                        }
                    }
                    EquipmentData EquipmentData;
                    if (MainProcess.CurrentTime > PlayerObject4.战具计时 && !PlayerObject4.对象死亡 && PlayerObject4.当前体力 < PlayerObject4[GameObjectStats.MaxPhysicalStrength] && PlayerObject4.角色装备.TryGetValue(15, out EquipmentData) && EquipmentData.当前持久.V > 0 && (EquipmentData.Id == 99999106 || EquipmentData.Id == 99999107))
                    {
                        PlayerObject4.当前体力 += ((this is MonsterObject) ? 20 : 10);
                        PlayerObject4.战具损失持久(1);
                        PlayerObject4.战具计时 = MainProcess.CurrentTime.AddMilliseconds(1000.0);
                    }
                }
                if ((this.当前体力 = Math.Max(0, this.当前体力 - 详情.技能伤害)) == 0)
                {
                    详情.技能反馈 |= 技能命中反馈.死亡;
                    this.自身死亡处理(MapObject, true);
                }
                return;
            }
        }

        
        public void 被动受伤时处理(BuffData 数据)
        {
            int num = 0;
            switch (数据.伤害类型)
            {
                case SkillDamageType.Attack:
                case SkillDamageType.Needle:
                case SkillDamageType.Archery:
                    num = ComputingClass.计算防御(this[GameObjectStats.MinDef], this[GameObjectStats.MaxDef]);
                    break;
                case SkillDamageType.Magic:
                case SkillDamageType.Taoism:
                    num = ComputingClass.计算防御(this[GameObjectStats.MinMagicDef], this[GameObjectStats.MaxMagicDef]);
                    break;
            }
            int num2 = Math.Max(0, 数据.伤害基数.V * (int)数据.当前层数.V - num);
            this.当前体力 = Math.Max(0, this.当前体力 - num2);
            触发状态效果 触发状态效果 = new 触发状态效果();
            触发状态效果.Id = 数据.Id.V;
            MapObject buff来源 = 数据.Buff来源;
            触发状态效果.Buff来源 = ((buff来源 != null) ? buff来源.MapId : 0);
            触发状态效果.Buff目标 = this.MapId;
            触发状态效果.血量变化 = -num2;
            this.发送封包(触发状态效果);
            if (this.当前体力 == 0)
            {
                this.自身死亡处理(数据.Buff来源, false);
            }
        }

        
        public void 被动回复时处理(技能实例 技能, C_05_计算目标回复 参数)
        {
            if (!this.对象死亡)
            {
                if (this.当前地图 == 技能.技能来源.当前地图)
                {
                    if (this != 技能.技能来源 && !this.邻居列表.Contains(技能.技能来源))
                    {
                        return;
                    }
                    TrapObject TrapObject = 技能.技能来源 as TrapObject;
                    MapObject MapObject = (TrapObject != null) ? TrapObject.陷阱来源 : 技能.技能来源;
                    int[] 体力回复次数 = 参数.体力回复次数;
                    int? num = (体力回复次数 != null) ? new int?(体力回复次数.Length) : null;
                    int 技能等级 = (int)技能.技能等级;
                    int num2 = (num.GetValueOrDefault() > 技能等级 & num != null) ? 参数.体力回复次数[(int)技能.技能等级] : 0;
                    byte[] PhysicalRecoveryBase = 参数.PhysicalRecoveryBase;
                    num = ((PhysicalRecoveryBase != null) ? new int?(PhysicalRecoveryBase.Length) : null);
                    技能等级 = (int)技能.技能等级;
                    int num3 = (int)((num.GetValueOrDefault() > 技能等级 & num != null) ? 参数.PhysicalRecoveryBase[(int)技能.技能等级] : 0);
                    float[] Taoism叠加次数 = 参数.Taoism叠加次数;
                    num = ((Taoism叠加次数 != null) ? new int?(Taoism叠加次数.Length) : null);
                    技能等级 = (int)技能.技能等级;
                    float num4 = (num.GetValueOrDefault() > 技能等级 & num != null) ? 参数.Taoism叠加次数[(int)技能.技能等级] : 0f;
                    float[] Taoism叠加基数 = 参数.Taoism叠加基数;
                    num = ((Taoism叠加基数 != null) ? new int?(Taoism叠加基数.Length) : null);
                    技能等级 = (int)技能.技能等级;
                    float num5 = (num.GetValueOrDefault() > 技能等级 & num != null) ? 参数.Taoism叠加基数[(int)技能.技能等级] : 0f;
                    int[] 立即回复基数 = 参数.立即回复基数;
                    num = ((立即回复基数 != null) ? new int?(立即回复基数.Length) : null);
                    技能等级 = (int)技能.技能等级;
                    int num6;
                    if (num.GetValueOrDefault() > 技能等级 & num != null)
                    {
                        if (MapObject == this)
                        {
                            num6 = 参数.立即回复基数[(int)技能.技能等级];
                            goto IL_1F1;
                        }
                    }
                    num6 = 0;
                IL_1F1:
                    int num7 = num6;
                    float[] 立即回复系数 = 参数.立即回复系数;
                    num = ((立即回复系数 != null) ? new int?(立即回复系数.Length) : null);
                    技能等级 = (int)技能.技能等级;
                    float num8;
                    if (num.GetValueOrDefault() > 技能等级 & num != null)
                    {
                        if (MapObject == this)
                        {
                            num8 = 参数.立即回复系数[(int)技能.技能等级];
                            goto IL_249;
                        }
                    }
                    num8 = 0f;
                IL_249:
                    float num9 = num8;
                    if (num4 > 0f)
                    {
                        num2 += (int)(num4 * (float)ComputingClass.计算Attack(MapObject[GameObjectStats.Minimalist], MapObject[GameObjectStats.GreatestTaoism], MapObject[GameObjectStats.幸运等级]));
                    }
                    if (num5 > 0f)
                    {
                        num3 += (int)(num5 * (float)ComputingClass.计算Attack(MapObject[GameObjectStats.Minimalist], MapObject[GameObjectStats.GreatestTaoism], MapObject[GameObjectStats.幸运等级]));
                    }
                    if (num7 > 0)
                    {
                        this.当前体力 += num7;
                    }
                    if (num9 > 0f)
                    {
                        this.当前体力 += (int)((float)this[GameObjectStats.MaxPhysicalStrength] * num9);
                    }
                    if (num2 > this.治疗次数 && num3 > 0)
                    {
                        this.治疗次数 = (int)((byte)num2);
                        this.治疗基数 = num3;
                        this.治疗时间 = MainProcess.CurrentTime.AddMilliseconds(500.0);
                    }
                    return;
                }
            }
        }

        
        public void 被动回复时处理(BuffData 数据)
        {
            if (数据.Buff模板.PhysicalRecoveryBase == null)
            {
                return;
            }
            if (数据.Buff模板.PhysicalRecoveryBase.Length <= (int)数据.Buff等级.V)
            {
                return;
            }
            byte b = 数据.Buff模板.PhysicalRecoveryBase[(int)数据.Buff等级.V];
            this.当前体力 += (int)b;
            触发状态效果 触发状态效果 = new 触发状态效果();
            触发状态效果.Id = 数据.Id.V;
            MapObject buff来源 = 数据.Buff来源;
            触发状态效果.Buff来源 = ((buff来源 != null) ? buff来源.MapId : 0);
            触发状态效果.Buff目标 = this.MapId;
            触发状态效果.血量变化 = (int)b;
            this.发送封包(触发状态效果);
        }

        
        public void 自身移动时处理(Point 坐标)
        {
            PlayerObject PlayerObject = this as PlayerObject;
            if (PlayerObject != null)
            {
                PlayerDeals 当前交易 = PlayerObject.当前交易;
                if (当前交易 != null)
                {
                    当前交易.结束交易();
                }
                using (List<BuffData>.Enumerator enumerator = this.Buff列表.Values.ToList<BuffData>().GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        BuffData BuffData = enumerator.Current;
                        技能陷阱 陷阱模板;
                        if ((BuffData.Effect & BuffEffectType.创建陷阱) != BuffEffectType.技能标志 && 技能陷阱.DataSheet.TryGetValue(BuffData.Buff模板.TriggerTrapSkills, out 陷阱模板))
                        {
                            int num = 0;

                            for (; ; )
                            {
                                Point point = ComputingClass.前方坐标(this.当前坐标, 坐标, num);
                                if (point == 坐标)
                                {
                                    break;
                                }
                                foreach (Point 坐标2 in ComputingClass.技能范围(point, this.当前方向, BuffData.Buff模板.NumberTrapsTriggered))
                                {
                                    if (!this.当前地图.地形阻塞(坐标2))
                                    {
                                        IEnumerable<MapObject> source = this.当前地图[坐标2];
                                        Func<MapObject, bool> predicate = null;
                                        if (predicate == null)
                                        {
                                            predicate = delegate (MapObject O)
                                          {
                                              TrapObject TrapObject = O as TrapObject;
                                              return TrapObject != null && TrapObject.陷阱GroupId != 0 && TrapObject.陷阱GroupId == 陷阱模板.GroupId;
                                          };
                                        }
                                        if (source.FirstOrDefault(predicate) == null)
                                        {
                                            this.陷阱列表.Add(new TrapObject(this, 陷阱模板, this.当前地图, 坐标2));
                                        }
                                    }
                                }
                                num++;
                            }
                        }
                        if ((BuffData.Effect & BuffEffectType.状态标志) != BuffEffectType.技能标志 && (BuffData.Buff模板.PlayerState & GameObjectState.Invisibility) != GameObjectState.Normal)
                        {
                            this.移除Buff时处理(BuffData.Id.V);
                        }
                    }
                    goto IL_30E;
                }
            }
            if (this is PetObject)
            {
                foreach (BuffData BuffData2 in this.Buff列表.Values.ToList<BuffData>())
                {
                    技能陷阱 陷阱模板;
                    if ((BuffData2.Effect & BuffEffectType.创建陷阱) != BuffEffectType.技能标志 && 技能陷阱.DataSheet.TryGetValue(BuffData2.Buff模板.TriggerTrapSkills, out 陷阱模板))
                    {
                        int num2 = 0;

                        for (; ; )
                        {
                            Point point2 = ComputingClass.前方坐标(this.当前坐标, 坐标, num2);
                            if (point2 == 坐标)
                            {
                                break;
                            }
                            foreach (Point 坐标3 in ComputingClass.技能范围(point2, this.当前方向, BuffData2.Buff模板.NumberTrapsTriggered))
                            {
                                if (!this.当前地图.地形阻塞(坐标3))
                                {
                                    IEnumerable<MapObject> source2 = this.当前地图[坐标3];
                                    Func<MapObject, bool> predicate2 = null;
                                    if (predicate2 == null)
                                    {
                                        predicate2 = delegate (MapObject O)
                                       {
                                           TrapObject TrapObject = O as TrapObject;
                                           return TrapObject != null && TrapObject.陷阱GroupId != 0 && TrapObject.陷阱GroupId == 陷阱模板.GroupId;
                                       };
                                    }
                                    if (source2.FirstOrDefault(predicate2) == null)
                                    {
                                        this.陷阱列表.Add(new TrapObject(this, 陷阱模板, this.当前地图, 坐标3));
                                    }
                                }
                            }
                            num2++;
                        }
                    }
                    if ((BuffData2.Effect & BuffEffectType.状态标志) != BuffEffectType.技能标志 && (BuffData2.Buff模板.PlayerState & GameObjectState.Invisibility) != GameObjectState.Normal)
                    {
                        this.移除Buff时处理(BuffData2.Id.V);
                    }
                }
            }
        IL_30E:
            this.解绑网格();
            this.当前坐标 = 坐标;
            this.绑定网格();
            this.更新邻居时处理();
            foreach (MapObject MapObject in this.邻居列表.ToList<MapObject>())
            {
                MapObject.对象移动时处理(this);
            }
        }

        
        public void 清空邻居时处理()
        {
            foreach (MapObject MapObject in this.邻居列表.ToList<MapObject>())
            {
                MapObject.对象消失时处理(this);
            }
            this.邻居列表.Clear();
            this.重要邻居.Clear();
            this.潜行邻居.Clear();
        }

        
        public void 更新邻居时处理()
        {
            foreach (MapObject MapObject in this.邻居列表.ToList<MapObject>())
            {
                if (this.当前地图 != MapObject.当前地图 || !this.在视线内(MapObject))
                {
                    MapObject.对象消失时处理(this);
                    this.对象消失时处理(MapObject);
                }
            }
            for (int i = -20; i <= 20; i++)
            {
                for (int j = -20; j <= 20; j++)
                {
                    this.当前地图[new Point(this.当前坐标.X + i, this.当前坐标.Y + j)].ToList<MapObject>();
                    try
                    {
                        foreach (MapObject MapObject2 in this.当前地图[new Point(this.当前坐标.X + i, this.当前坐标.Y + j)])
                        {
                            if (MapObject2 != this)
                            {
                                if (!this.邻居列表.Contains(MapObject2) && this.邻居类型(MapObject2))
                                {
                                    this.对象出现时处理(MapObject2);
                                }
                                if (!MapObject2.邻居列表.Contains(this) && MapObject2.邻居类型(this))
                                {
                                    MapObject2.对象出现时处理(this);
                                }
                            }
                        }
                        goto IL_15C;
                    }
                    catch
                    {
                        goto IL_15C;
                    }
                    break;
                IL_15C:;
                }
            }
        }

        
        public void 对象移动时处理(MapObject 对象)
        {
            if (!(this is ItemObject))
            {
                PetObject PetObject = this as PetObject;
                if (PetObject != null)
                {
                    HateObject.仇恨详情 仇恨详情;
                    if (PetObject.ActiveAttack(对象) && this.网格距离(对象) <= PetObject.RangeHate && !对象.检查状态(GameObjectState.Invisibility | GameObjectState.StealthStatus))
                    {
                        PetObject.HateObject.添加仇恨(对象, default(DateTime), 0);
                    }
                    else if (this.网格距离(对象) > PetObject.RangeHate && PetObject.HateObject.仇恨列表.TryGetValue(对象, out 仇恨详情) && 仇恨详情.仇恨时间 < MainProcess.CurrentTime)
                    {
                        PetObject.HateObject.移除仇恨(对象);
                    }
                }
                else
                {
                    MonsterObject MonsterObject = this as MonsterObject;
                    if (MonsterObject != null)
                    {
                        HateObject.仇恨详情 仇恨详情2;
                        if (this.网格距离(对象) <= MonsterObject.RangeHate && MonsterObject.ActiveAttack(对象) && (MonsterObject.VisibleStealthTargets || !对象.检查状态(GameObjectState.Invisibility | GameObjectState.StealthStatus)))
                        {
                            MonsterObject.HateObject.添加仇恨(对象, default(DateTime), 0);
                        }
                        else if (this.网格距离(对象) > MonsterObject.RangeHate && MonsterObject.HateObject.仇恨列表.TryGetValue(对象, out 仇恨详情2) && 仇恨详情2.仇恨时间 < MainProcess.CurrentTime)
                        {
                            MonsterObject.HateObject.移除仇恨(对象);
                        }
                    }
                    else
                    {
                        TrapObject TrapObject = this as TrapObject;
                        if (TrapObject != null)
                        {
                            if (ComputingClass.技能范围(TrapObject.当前坐标, TrapObject.当前方向, TrapObject.对象体型).Contains(对象.当前坐标))
                            {
                                TrapObject.被动触发陷阱(对象);
                            }
                        }
                        else
                        {
                            GuardInstance GuardInstance = this as GuardInstance;
                            if (GuardInstance != null)
                            {
                                if (GuardInstance.ActiveAttack(对象) && this.网格距离(对象) <= GuardInstance.RangeHate)
                                {
                                    GuardInstance.HateObject.添加仇恨(对象, default(DateTime), 0);
                                }
                                else if (this.网格距离(对象) > GuardInstance.RangeHate)
                                {
                                    GuardInstance.HateObject.移除仇恨(对象);
                                }
                            }
                        }
                    }
                }
            }
            if (!(对象 is ItemObject))
            {
                PetObject PetObject2 = 对象 as PetObject;
                if (PetObject2 != null)
                {
                    if (PetObject2.网格距离(this) <= PetObject2.RangeHate && PetObject2.ActiveAttack(this) && !this.检查状态(GameObjectState.Invisibility | GameObjectState.StealthStatus))
                    {
                        PetObject2.HateObject.添加仇恨(this, default(DateTime), 0);
                        return;
                    }
                    HateObject.仇恨详情 仇恨详情3;
                    if (PetObject2.网格距离(this) > PetObject2.RangeHate && PetObject2.HateObject.仇恨列表.TryGetValue(this, out 仇恨详情3) && 仇恨详情3.仇恨时间 < MainProcess.CurrentTime)
                    {
                        PetObject2.HateObject.移除仇恨(this);
                        return;
                    }
                }
                else
                {
                    MonsterObject MonsterObject2 = 对象 as MonsterObject;
                    if (MonsterObject2 != null)
                    {
                        if (MonsterObject2.网格距离(this) <= MonsterObject2.RangeHate && MonsterObject2.ActiveAttack(this) && (MonsterObject2.VisibleStealthTargets || !this.检查状态(GameObjectState.Invisibility | GameObjectState.StealthStatus)))
                        {
                            MonsterObject2.HateObject.添加仇恨(this, default(DateTime), 0);
                            return;
                        }
                        HateObject.仇恨详情 仇恨详情4;
                        if (MonsterObject2.网格距离(this) > MonsterObject2.RangeHate && MonsterObject2.HateObject.仇恨列表.TryGetValue(this, out 仇恨详情4) && 仇恨详情4.仇恨时间 < MainProcess.CurrentTime)
                        {
                            MonsterObject2.HateObject.移除仇恨(this);
                            return;
                        }
                    }
                    else
                    {
                        TrapObject TrapObject2 = 对象 as TrapObject;
                        if (TrapObject2 != null)
                        {
                            if (ComputingClass.技能范围(TrapObject2.当前坐标, TrapObject2.当前方向, TrapObject2.对象体型).Contains(this.当前坐标))
                            {
                                TrapObject2.被动触发陷阱(this);
                                return;
                            }
                        }
                        else
                        {
                            GuardInstance GuardInstance2 = 对象 as GuardInstance;
                            if (GuardInstance2 != null)
                            {
                                if (GuardInstance2.ActiveAttack(this) && GuardInstance2.网格距离(this) <= GuardInstance2.RangeHate)
                                {
                                    GuardInstance2.HateObject.添加仇恨(this, default(DateTime), 0);
                                    return;
                                }
                                if (GuardInstance2.网格距离(this) > GuardInstance2.RangeHate)
                                {
                                    GuardInstance2.HateObject.移除仇恨(this);
                                }
                            }
                        }
                    }
                }
            }
        }

        
        public void 对象出现时处理(MapObject 对象)
        {
            if (this.潜行邻居.Remove(对象))
            {
                if (!(this is ItemObject))
                {
                    PlayerObject PlayerObject = this as PlayerObject;
                    if (PlayerObject != null)
                    {
                        GameObjectType 对象类型 = 对象.对象类型;
                        if (对象类型 <= GameObjectType.Npcc)
                        {
                            switch (对象类型)
                            {
                                case GameObjectType.玩家:
                                case GameObjectType.怪物:
                                    break;
                                case GameObjectType.宠物:
                                    PlayerObject.网络连接.发送封包(new ObjectCharacterStopPacket
                                    {
                                        对象编号 = 对象.MapId,
                                        对象坐标 = 对象.当前坐标,
                                        对象高度 = 对象.当前高度
                                    });
                                    PlayerObject.网络连接.发送封包(new ObjectComesIntoViewPacket
                                    {
                                        出现方式 = 1,
                                        对象编号 = 对象.MapId,
                                        现身坐标 = 对象.当前坐标,
                                        现身高度 = 对象.当前高度,
                                        现身方向 = (ushort)对象.当前方向,
                                        现身姿态 = ((byte)(对象.对象死亡 ? 13 : 1)),
                                        体力比例 = (byte)(对象.当前体力 * 100 / 对象[GameObjectStats.MaxPhysicalStrength])
                                    });
                                    PlayerObject.网络连接.发送封包(new 同步对象体力
                                    {
                                        对象编号 = 对象.MapId,
                                        当前体力 = 对象.当前体力,
                                        体力上限 = 对象[GameObjectStats.MaxPhysicalStrength]
                                    });
                                    PlayerObject.网络连接.发送封包(new ObjectTransformTypePacket
                                    {
                                        改变类型 = 2,
                                        对象编号 = 对象.MapId
                                    });
                                    goto IL_356;
                                case (GameObjectType)3:
                                    goto IL_356;
                                default:
                                    if (对象类型 != GameObjectType.Npcc)
                                    {
                                        goto IL_356;
                                    }
                                    break;
                            }
                            PlayerObject.网络连接.发送封包(new ObjectCharacterStopPacket
                            {
                                对象编号 = 对象.MapId,
                                对象坐标 = 对象.当前坐标,
                                对象高度 = 对象.当前高度
                            });
                            客户网络 网络连接 = PlayerObject.网络连接;
                            ObjectComesIntoViewPacket ObjectComesIntoViewPacket = new ObjectComesIntoViewPacket();
                            ObjectComesIntoViewPacket.出现方式 = 1;
                            ObjectComesIntoViewPacket.对象编号 = 对象.MapId;
                            ObjectComesIntoViewPacket.现身坐标 = 对象.当前坐标;
                            ObjectComesIntoViewPacket.现身高度 = 对象.当前高度;
                            ObjectComesIntoViewPacket.现身方向 = (ushort)对象.当前方向;
                            ObjectComesIntoViewPacket.现身姿态 = ((byte)(对象.对象死亡 ? 13 : 1));
                            ObjectComesIntoViewPacket.体力比例 = (byte)(对象.当前体力 * 100 / 对象[GameObjectStats.MaxPhysicalStrength]);
                            PlayerObject PlayerObject2 = 对象 as PlayerObject;
                            ObjectComesIntoViewPacket.AdditionalParam = ((byte)((PlayerObject2 == null || !PlayerObject2.灰名玩家) ? 0 : 2));
                            网络连接.发送封包(ObjectComesIntoViewPacket);
                            PlayerObject.网络连接.发送封包(new 同步对象体力
                            {
                                对象编号 = 对象.MapId,
                                当前体力 = 对象.当前体力,
                                体力上限 = 对象[GameObjectStats.MaxPhysicalStrength]
                            });
                        }
                        else if (对象类型 != GameObjectType.物品)
                        {
                            if (对象类型 == GameObjectType.陷阱)
                            {
                                PlayerObject.网络连接.发送封包(new TrapComesIntoViewPacket
                                {
                                    MapId = 对象.MapId,
                                    陷阱坐标 = 对象.当前坐标,
                                    陷阱高度 = 对象.当前高度,
                                    来源编号 = (对象 as TrapObject).陷阱来源.MapId,
                                    陷阱编号 = (对象 as TrapObject).陷阱编号,
                                    持续时间 = (对象 as TrapObject).陷阱剩余时间
                                });
                            }
                        }
                        else
                        {
                            PlayerObject.网络连接.发送封包(new ObjectDropItemsPacket
                            {
                                对象编号 = 对象.MapId,
                                MapId = 对象.MapId,
                                掉落坐标 = 对象.当前坐标,
                                掉落高度 = 对象.当前高度,
                                Id = (对象 as ItemObject).Id,
                                物品数量 = (对象 as ItemObject).堆叠数量
                            });
                        }
                    IL_356:
                        if (对象.Buff列表.Count > 0)
                        {
                            PlayerObject.网络连接.发送封包(new 同步对象Buff
                            {
                                字节描述 = 对象.对象Buff简述()
                            });
                            return;
                        }
                    }
                    else
                    {
                        TrapObject TrapObject = this as TrapObject;
                        if (TrapObject != null)
                        {
                            if (ComputingClass.技能范围(TrapObject.当前坐标, TrapObject.当前方向, TrapObject.对象体型).Contains(对象.当前坐标))
                            {
                                TrapObject.被动触发陷阱(对象);
                                return;
                            }
                        }
                        else
                        {
                            PetObject PetObject = this as PetObject;
                            if (PetObject != null)
                            {
                                if (this.网格距离(对象) <= PetObject.RangeHate && PetObject.ActiveAttack(对象) && !对象.检查状态(GameObjectState.Invisibility | GameObjectState.StealthStatus))
                                {
                                    PetObject.HateObject.添加仇恨(对象, default(DateTime), 0);
                                    return;
                                }
                                HateObject.仇恨详情 仇恨详情;
                                if (this.网格距离(对象) > PetObject.RangeHate && PetObject.HateObject.仇恨列表.TryGetValue(对象, out 仇恨详情) && 仇恨详情.仇恨时间 < MainProcess.CurrentTime)
                                {
                                    PetObject.HateObject.移除仇恨(对象);
                                    return;
                                }
                            }
                            else
                            {
                                MonsterObject MonsterObject = this as MonsterObject;
                                if (MonsterObject != null)
                                {
                                    if (this.网格距离(对象) <= MonsterObject.RangeHate && MonsterObject.ActiveAttack(对象) && (MonsterObject.VisibleStealthTargets || !对象.检查状态(GameObjectState.Invisibility | GameObjectState.StealthStatus)))
                                    {
                                        MonsterObject.HateObject.添加仇恨(对象, default(DateTime), 0);
                                        return;
                                    }
                                    HateObject.仇恨详情 仇恨详情2;
                                    if (this.网格距离(对象) > MonsterObject.RangeHate && MonsterObject.HateObject.仇恨列表.TryGetValue(对象, out 仇恨详情2) && 仇恨详情2.仇恨时间 < MainProcess.CurrentTime)
                                    {
                                        MonsterObject.HateObject.移除仇恨(对象);
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else if (this.邻居列表.Add(对象))
            {
                if (对象 is PlayerObject || 对象 is PetObject)
                {
                    this.重要邻居.Add(对象);
                }
                if (!(this is ItemObject))
                {
                    PlayerObject PlayerObject3 = this as PlayerObject;
                    if (PlayerObject3 != null)
                    {
                        GameObjectType 对象类型 = 对象.对象类型;
                        if (对象类型 <= GameObjectType.Npcc)
                        {
                            switch (对象类型)
                            {
                                case GameObjectType.玩家:
                                case GameObjectType.怪物:
                                    break;
                                case GameObjectType.宠物:
                                    PlayerObject3.网络连接.发送封包(new ObjectCharacterStopPacket
                                    {
                                        对象编号 = 对象.MapId,
                                        对象坐标 = 对象.当前坐标,
                                        对象高度 = 对象.当前高度
                                    });
                                    PlayerObject3.网络连接.发送封包(new ObjectComesIntoViewPacket
                                    {
                                        出现方式 = 1,
                                        对象编号 = 对象.MapId,
                                        现身坐标 = 对象.当前坐标,
                                        现身高度 = 对象.当前高度,
                                        现身方向 = (ushort)对象.当前方向,
                                        现身姿态 = ((byte)(对象.对象死亡 ? 13 : 1)),
                                        体力比例 = (byte)(对象.当前体力 * 100 / 对象[GameObjectStats.MaxPhysicalStrength])
                                    });
                                    PlayerObject3.网络连接.发送封包(new 同步对象体力
                                    {
                                        对象编号 = 对象.MapId,
                                        当前体力 = 对象.当前体力,
                                        体力上限 = 对象[GameObjectStats.MaxPhysicalStrength]
                                    });
                                    PlayerObject3.网络连接.发送封包(new ObjectTransformTypePacket
                                    {
                                        改变类型 = 2,
                                        对象编号 = 对象.MapId
                                    });
                                    goto IL_866;
                                case (GameObjectType)3:
                                    goto IL_866;
                                default:
                                    if (对象类型 != GameObjectType.Npcc)
                                    {
                                        goto IL_866;
                                    }
                                    break;
                            }
                            PlayerObject3.网络连接.发送封包(new ObjectCharacterStopPacket
                            {
                                对象编号 = 对象.MapId,
                                对象坐标 = 对象.当前坐标,
                                对象高度 = 对象.当前高度
                            });
                            客户网络 网络连接2 = PlayerObject3.网络连接;
                            ObjectComesIntoViewPacket ObjectComesIntoViewPacket2 = new ObjectComesIntoViewPacket();
                            ObjectComesIntoViewPacket2.出现方式 = 1;
                            ObjectComesIntoViewPacket2.对象编号 = 对象.MapId;
                            ObjectComesIntoViewPacket2.现身坐标 = 对象.当前坐标;
                            ObjectComesIntoViewPacket2.现身高度 = 对象.当前高度;
                            ObjectComesIntoViewPacket2.现身方向 = (ushort)对象.当前方向;
                            ObjectComesIntoViewPacket2.现身姿态 = ((byte)(对象.对象死亡 ? 13 : 1));
                            ObjectComesIntoViewPacket2.体力比例 = (byte)(对象.当前体力 * 100 / 对象[GameObjectStats.MaxPhysicalStrength]);
                            PlayerObject PlayerObject4 = 对象 as PlayerObject;
                            ObjectComesIntoViewPacket2.AdditionalParam = ((byte)((PlayerObject4 == null || !PlayerObject4.灰名玩家) ? 0 : 2));
                            网络连接2.发送封包(ObjectComesIntoViewPacket2);
                            PlayerObject3.网络连接.发送封包(new 同步对象体力
                            {
                                对象编号 = 对象.MapId,
                                当前体力 = 对象.当前体力,
                                体力上限 = 对象[GameObjectStats.MaxPhysicalStrength]
                            });
                        }
                        else if (对象类型 != GameObjectType.物品)
                        {
                            if (对象类型 == GameObjectType.陷阱)
                            {
                                PlayerObject3.网络连接.发送封包(new TrapComesIntoViewPacket
                                {
                                    MapId = 对象.MapId,
                                    陷阱坐标 = 对象.当前坐标,
                                    陷阱高度 = 对象.当前高度,
                                    来源编号 = (对象 as TrapObject).陷阱来源.MapId,
                                    陷阱编号 = (对象 as TrapObject).陷阱编号,
                                    持续时间 = (对象 as TrapObject).陷阱剩余时间
                                });
                            }
                        }
                        else
                        {
                            PlayerObject3.网络连接.发送封包(new ObjectDropItemsPacket
                            {
                                对象编号 = 对象.MapId,
                                MapId = 对象.MapId,
                                掉落坐标 = 对象.当前坐标,
                                掉落高度 = 对象.当前高度,
                                Id = (对象 as ItemObject).Id,
                                物品数量 = (对象 as ItemObject).堆叠数量
                            });
                        }
                    IL_866:
                        if (对象.Buff列表.Count > 0)
                        {
                            PlayerObject3.网络连接.发送封包(new 同步对象Buff
                            {
                                字节描述 = 对象.对象Buff简述()
                            });
                            return;
                        }
                    }
                    else
                    {
                        TrapObject TrapObject2 = this as TrapObject;
                        if (TrapObject2 != null)
                        {
                            if (ComputingClass.技能范围(TrapObject2.当前坐标, TrapObject2.当前方向, TrapObject2.对象体型).Contains(对象.当前坐标))
                            {
                                TrapObject2.被动触发陷阱(对象);
                                return;
                            }
                        }
                        else
                        {
                            PetObject PetObject2 = this as PetObject;
                            if (PetObject2 != null && !this.对象死亡)
                            {
                                if (this.网格距离(对象) <= PetObject2.RangeHate && PetObject2.ActiveAttack(对象) && !对象.检查状态(GameObjectState.Invisibility | GameObjectState.StealthStatus))
                                {
                                    PetObject2.HateObject.添加仇恨(对象, default(DateTime), 0);
                                    return;
                                }
                                HateObject.仇恨详情 仇恨详情3;
                                if (this.网格距离(对象) > PetObject2.RangeHate && PetObject2.HateObject.仇恨列表.TryGetValue(对象, out 仇恨详情3) && 仇恨详情3.仇恨时间 < MainProcess.CurrentTime)
                                {
                                    PetObject2.HateObject.移除仇恨(对象);
                                    return;
                                }
                            }
                            else
                            {
                                MonsterObject MonsterObject2 = this as MonsterObject;
                                if (MonsterObject2 != null && !this.对象死亡)
                                {
                                    HateObject.仇恨详情 仇恨详情4;
                                    if (this.网格距离(对象) <= MonsterObject2.RangeHate && MonsterObject2.ActiveAttack(对象) && (MonsterObject2.VisibleStealthTargets || !对象.检查状态(GameObjectState.Invisibility | GameObjectState.StealthStatus)))
                                    {
                                        MonsterObject2.HateObject.添加仇恨(对象, default(DateTime), 0);
                                    }
                                    else if (this.网格距离(对象) > MonsterObject2.RangeHate && MonsterObject2.HateObject.仇恨列表.TryGetValue(对象, out 仇恨详情4) && 仇恨详情4.仇恨时间 < MainProcess.CurrentTime)
                                    {
                                        MonsterObject2.HateObject.移除仇恨(对象);
                                    }
                                    if (this.重要邻居.Count != 0)
                                    {
                                        MonsterObject2.怪物激活处理();
                                        return;
                                    }
                                }
                                else
                                {
                                    GuardInstance GuardInstance = this as GuardInstance;
                                    if (GuardInstance != null && !this.对象死亡)
                                    {
                                        if (GuardInstance.ActiveAttack(对象) && this.网格距离(对象) <= GuardInstance.RangeHate)
                                        {
                                            GuardInstance.HateObject.添加仇恨(对象, default(DateTime), 0);
                                        }
                                        else if (this.网格距离(对象) > GuardInstance.RangeHate)
                                        {
                                            GuardInstance.HateObject.移除仇恨(对象);
                                        }
                                        if (this.重要邻居.Count != 0)
                                        {
                                            GuardInstance.守卫激活处理();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        
        public void 对象消失时处理(MapObject 对象)
        {
            if (this.邻居列表.Remove(对象))
            {
                this.潜行邻居.Remove(对象);
                this.重要邻居.Remove(对象);
                if (!(this is ItemObject))
                {
                    PlayerObject PlayerObject = this as PlayerObject;
                    if (PlayerObject != null)
                    {
                        PlayerObject.网络连接.发送封包(new ObjectOutOfViewPacket
                        {
                            对象编号 = 对象.MapId
                        });
                        return;
                    }
                    PetObject PetObject = this as PetObject;
                    if (PetObject != null)
                    {
                        PetObject.HateObject.移除仇恨(对象);
                        return;
                    }
                    MonsterObject MonsterObject = this as MonsterObject;
                    if (MonsterObject != null)
                    {
                        if (!this.对象死亡)
                        {
                            MonsterObject.HateObject.移除仇恨(对象);
                            if (MonsterObject.重要邻居.Count == 0)
                            {
                                MonsterObject.怪物沉睡处理();
                                return;
                            }
                        }
                    }
                    else
                    {
                        GuardInstance GuardInstance = this as GuardInstance;
                        if (GuardInstance != null && !this.对象死亡)
                        {
                            GuardInstance.HateObject.移除仇恨(对象);
                            if (GuardInstance.重要邻居.Count == 0)
                            {
                                GuardInstance.守卫沉睡处理();
                            }
                        }
                    }
                }
            }
        }

        
        public void 对象死亡时处理(MapObject 对象)
        {
            MonsterObject MonsterObject = this as MonsterObject;
            if (MonsterObject != null)
            {
                MonsterObject.HateObject.移除仇恨(对象);
                return;
            }
            PetObject PetObject = this as PetObject;
            if (PetObject != null)
            {
                PetObject.HateObject.移除仇恨(对象);
                return;
            }
            GuardInstance GuardInstance = this as GuardInstance;
            if (GuardInstance != null)
            {
                GuardInstance.HateObject.移除仇恨(对象);
                return;
            }
        }

        
        public void 对象隐身时处理(MapObject 对象)
        {
            PetObject PetObject = this as PetObject;
            if (PetObject != null && PetObject.HateObject.仇恨列表.ContainsKey(对象))
            {
                PetObject.HateObject.移除仇恨(对象);
            }
            MonsterObject MonsterObject = this as MonsterObject;
            if (MonsterObject != null && MonsterObject.HateObject.仇恨列表.ContainsKey(对象) && !MonsterObject.VisibleStealthTargets)
            {
                MonsterObject.HateObject.移除仇恨(对象);
            }
        }

        
        public void 对象潜行时处理(MapObject 对象)
        {
            PetObject PetObject = this as PetObject;
            if (PetObject != null)
            {
                if (PetObject.HateObject.仇恨列表.ContainsKey(对象))
                {
                    PetObject.HateObject.移除仇恨(对象);
                }
                this.潜行邻居.Add(对象);
            }
            MonsterObject MonsterObject = this as MonsterObject;
            if (MonsterObject != null && !MonsterObject.VisibleStealthTargets)
            {
                if (MonsterObject.HateObject.仇恨列表.ContainsKey(对象))
                {
                    MonsterObject.HateObject.移除仇恨(对象);
                }
                this.潜行邻居.Add(对象);
            }
            PlayerObject PlayerObject = this as PlayerObject;
            if (PlayerObject != null && (this.对象关系(对象) == 游戏对象关系.敌对 || 对象.对象关系(this) == 游戏对象关系.敌对))
            {
                this.潜行邻居.Add(对象);
                PlayerObject.网络连接.发送封包(new ObjectOutOfViewPacket
                {
                    对象编号 = 对象.MapId
                });
            }
        }

        
        public void 对象显隐时处理(MapObject 对象)
        {
            PetObject PetObject = this as PetObject;
            if (PetObject != null)
            {
                HateObject.仇恨详情 仇恨详情;
                if (this.网格距离(对象) <= PetObject.RangeHate && PetObject.ActiveAttack(对象) && !对象.检查状态(GameObjectState.Invisibility | GameObjectState.StealthStatus))
                {
                    PetObject.HateObject.添加仇恨(对象, default(DateTime), 0);
                }
                else if (this.网格距离(对象) > PetObject.RangeHate && PetObject.HateObject.仇恨列表.TryGetValue(对象, out 仇恨详情) && 仇恨详情.仇恨时间 < MainProcess.CurrentTime)
                {
                    PetObject.HateObject.移除仇恨(对象);
                }
            }
            MonsterObject MonsterObject = this as MonsterObject;
            if (MonsterObject != null)
            {
                if (this.网格距离(对象) <= MonsterObject.RangeHate && MonsterObject.ActiveAttack(对象) && (MonsterObject.VisibleStealthTargets || !对象.检查状态(GameObjectState.Invisibility | GameObjectState.StealthStatus)))
                {
                    MonsterObject.HateObject.添加仇恨(对象, default(DateTime), 0);
                    return;
                }
                HateObject.仇恨详情 仇恨详情2;
                if (this.网格距离(对象) > MonsterObject.RangeHate && MonsterObject.HateObject.仇恨列表.TryGetValue(对象, out 仇恨详情2) && 仇恨详情2.仇恨时间 < MainProcess.CurrentTime)
                {
                    MonsterObject.HateObject.移除仇恨(对象);
                }
            }
        }

        
        public void 对象显行时处理(MapObject 对象)
        {
            if (this.潜行邻居.Contains(对象))
            {
                this.对象出现时处理(对象);
            }
        }

        
        public byte[] 对象Buff详述()
        {
            byte[] result;
            using (MemoryStream memoryStream = new MemoryStream(34))
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
                {
                    binaryWriter.Write((byte)this.Buff列表.Count);
                    foreach (KeyValuePair<ushort, BuffData> keyValuePair in this.Buff列表)
                    {
                        binaryWriter.Write(keyValuePair.Value.Id.V);
                        binaryWriter.Write((int)keyValuePair.Value.Id.V);
                        binaryWriter.Write(keyValuePair.Value.当前层数.V);
                        binaryWriter.Write((int)keyValuePair.Value.剩余时间.V.TotalMilliseconds);
                        binaryWriter.Write((int)keyValuePair.Value.持续时间.V.TotalMilliseconds);
                    }
                    result = memoryStream.ToArray();
                }
            }
            return result;
        }

        
        public byte[] 对象Buff简述()
        {
            byte[] result;
            using (MemoryStream memoryStream = new MemoryStream(34))
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
                {
                    binaryWriter.Write(this.MapId);
                    int num = 0;
                    foreach (KeyValuePair<ushort, BuffData> keyValuePair in this.Buff列表)
                    {
                        binaryWriter.Write(keyValuePair.Value.Id.V);
                        binaryWriter.Write((int)keyValuePair.Value.Id.V);
                        if (++num >= 5)
                        {
                            break;
                        }
                    }
                    result = memoryStream.ToArray();
                }
            }
            return result;
        }

        
        public bool 次要对象;

        
        public bool 激活对象;

        
        public HashSet<MapObject> 重要邻居;

        
        public HashSet<MapObject> 潜行邻居;

        
        public HashSet<MapObject> 邻居列表;

        
        public HashSet<技能实例> 技能任务;

        
        public HashSet<TrapObject> 陷阱列表;

        
        public Dictionary<object, Dictionary<GameObjectStats, int>> Stat加成;
    }
}
