using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GameServer.Data;
using GameServer.Templates;
using GameServer.Networking;

namespace GameServer.Maps
{

    public sealed class GuardInstance : MapObject
    {

        // (get) Token: 0x060006FE RID: 1790 RVA: 0x000060F0 File Offset: 0x000042F0
        // (set) Token: 0x060006FF RID: 1791 RVA: 0x000060F8 File Offset: 0x000042F8
        public bool 尸体消失 { get; set; }


        // (get) Token: 0x06000700 RID: 1792 RVA: 0x00006101 File Offset: 0x00004301
        // (set) Token: 0x06000701 RID: 1793 RVA: 0x00006109 File Offset: 0x00004309
        public DateTime 复活时间 { get; set; }


        // (get) Token: 0x06000702 RID: 1794 RVA: 0x00006112 File Offset: 0x00004312
        // (set) Token: 0x06000703 RID: 1795 RVA: 0x0000611A File Offset: 0x0000431A
        public DateTime 消失时间 { get; set; }


        // (get) Token: 0x06000704 RID: 1796 RVA: 0x00006123 File Offset: 0x00004323
        // (set) Token: 0x06000705 RID: 1797 RVA: 0x0000612B File Offset: 0x0000432B
        public DateTime 转移计时 { get; set; }


        // (get) Token: 0x06000706 RID: 1798 RVA: 0x00006134 File Offset: 0x00004334
        public override int 处理间隔
        {
            get
            {
                return 10;
            }
        }


        // (get) Token: 0x06000707 RID: 1799 RVA: 0x00006138 File Offset: 0x00004338
        // (set) Token: 0x06000708 RID: 1800 RVA: 0x00036440 File Offset: 0x00034640
        public override DateTime 忙碌时间
        {
            get
            {
                return base.忙碌时间;
            }
            set
            {
                if (base.忙碌时间 < value)
                {
                    this.硬直时间 = value;
                    base.忙碌时间 = value;
                }
            }
        }


        // (get) Token: 0x06000709 RID: 1801 RVA: 0x00006140 File Offset: 0x00004340
        // (set) Token: 0x0600070A RID: 1802 RVA: 0x00006148 File Offset: 0x00004348
        public override DateTime 硬直时间
        {
            get
            {
                return base.硬直时间;
            }
            set
            {
                if (base.硬直时间 < value)
                {
                    base.硬直时间 = value;
                }
            }
        }


        // (get) Token: 0x0600070B RID: 1803 RVA: 0x0000615F File Offset: 0x0000435F
        // (set) Token: 0x0600070C RID: 1804 RVA: 0x0003646C File Offset: 0x0003466C
        public override int CurrentStamina
        {
            get
            {
                return base.CurrentStamina;
            }
            set
            {
                value = ComputingClass.ValueLimit(0, value, this[GameObjectStats.MaxPhysicalStrength]);
                if (base.CurrentStamina != value)
                {
                    base.CurrentStamina = value;
                    base.发送封包(new 同步对象体力
                    {
                        对象编号 = this.MapId,
                        CurrentStamina = this.CurrentStamina,
                        体力上限 = this[GameObjectStats.MaxPhysicalStrength]
                    });
                }
            }
        }


        // (get) Token: 0x0600070D RID: 1805 RVA: 0x00006167 File Offset: 0x00004367
        // (set) Token: 0x0600070E RID: 1806 RVA: 0x0000616F File Offset: 0x0000436F
        public override MapInstance CurrentMap
        {
            get
            {
                return base.CurrentMap;
            }
            set
            {
                if (this.CurrentMap != value)
                {
                    MapInstance CurrentMap = base.CurrentMap;
                    if (CurrentMap != null)
                    {
                        CurrentMap.移除对象(this);
                    }
                    base.CurrentMap = value;
                    base.CurrentMap.添加对象(this);
                }
            }
        }


        // (get) Token: 0x0600070F RID: 1807 RVA: 0x0000619F File Offset: 0x0000439F
        // (set) Token: 0x06000710 RID: 1808 RVA: 0x000061A7 File Offset: 0x000043A7
        public override GameDirection 当前方向
        {
            get
            {
                return base.当前方向;
            }
            set
            {
                if (this.当前方向 != value)
                {
                    base.当前方向 = value;
                    base.发送封包(new ObjectRotationDirectionPacket
                    {
                        转向耗时 = 100,
                        对象编号 = this.MapId,
                        对象朝向 = (ushort)value
                    });
                }
            }
        }


        // (get) Token: 0x06000711 RID: 1809 RVA: 0x000061E0 File Offset: 0x000043E0
        public override byte CurrentRank
        {
            get
            {
                return this.对象模板.Level;
            }
        }


        // (get) Token: 0x06000712 RID: 1810 RVA: 0x000061ED File Offset: 0x000043ED
        public override bool CanBeHit
        {
            get
            {
                return this.CanBeInjured && !this.Died;
            }
        }


        // (get) Token: 0x06000713 RID: 1811 RVA: 0x00006202 File Offset: 0x00004402
        public override string 对象名字
        {
            get
            {
                return this.对象模板.Name;
            }
        }


        // (get) Token: 0x06000714 RID: 1812 RVA: 0x0000620F File Offset: 0x0000440F
        public override GameObjectType ObjectType
        {
            get
            {
                return GameObjectType.Npcc;
            }
        }


        // (get) Token: 0x06000715 RID: 1813 RVA: 0x00002855 File Offset: 0x00000A55
        public override MonsterSize 对象体型
        {
            get
            {
                return MonsterSize.Single1x1;
            }
        }


        public override int this[GameObjectStats Stat]
        {
            get
            {
                return base[Stat];
            }
            set
            {
                base[Stat] = value;
            }
        }


        // (get) Token: 0x06000718 RID: 1816 RVA: 0x00006134 File Offset: 0x00004334
        public int RangeHate
        {
            get
            {
                return 10;
            }
        }


        // (get) Token: 0x06000719 RID: 1817 RVA: 0x00006225 File Offset: 0x00004425
        public ushort MobId
        {
            get
            {
                return this.对象模板.GuardNumber;
            }
        }


        // (get) Token: 0x0600071A RID: 1818 RVA: 0x00006232 File Offset: 0x00004432
        public int RevivalInterval
        {
            get
            {
                return this.对象模板.RevivalInterval;
            }
        }


        // (get) Token: 0x0600071B RID: 1819 RVA: 0x0000623F File Offset: 0x0000443F
        public int StoreId
        {
            get
            {
                return this.对象模板.StoreId;
            }
        }


        // (get) Token: 0x0600071C RID: 1820 RVA: 0x0000624C File Offset: 0x0000444C
        public string InterfaceCode
        {
            get
            {
                return this.对象模板.InterfaceCode;
            }
        }


        // (get) Token: 0x0600071D RID: 1821 RVA: 0x00006259 File Offset: 0x00004459
        public bool CanBeInjured
        {
            get
            {
                return this.对象模板.CanBeInjured;
            }
        }


        // (get) Token: 0x0600071E RID: 1822 RVA: 0x00006266 File Offset: 0x00004466
        public bool ActiveAttackTarget
        {
            get
            {
                return this.对象模板.ActiveAttack;
            }
        }


        public GuardInstance(Guards 对应模板, MapInstance 出生地图, GameDirection 出生方向, Point 出生坐标)
        {


            this.对象模板 = 对应模板;
            this.出生地图 = 出生地图;
            this.CurrentMap = 出生地图;
            this.出生方向 = 出生方向;
            this.出生坐标 = 出生坐标;
            this.MapId = ++MapGatewayProcess.对象编号;
            Dictionary<object, Dictionary<GameObjectStats, int>> Stat加成 = this.Stat加成;
            Dictionary<GameObjectStats, int> dictionary = new Dictionary<GameObjectStats, int>();
            dictionary[GameObjectStats.MaxPhysicalStrength] = 9999;
            Stat加成[this] = dictionary;
            string text = this.对象模板.BasicAttackSkills;
            if (text != null && text.Length > 0)
            {
                GameSkills.DataSheet.TryGetValue(this.对象模板.BasicAttackSkills, out this.BasicAttackSkills);
            }
            MapGatewayProcess.添加MapObject(this);
            this.守卫复活处理();
        }


        public override void 处理对象数据()
        {
            if (MainProcess.CurrentTime < base.预约时间)
            {
                return;
            }
            if (this.Died)
            {
                if (!this.尸体消失 && MainProcess.CurrentTime >= this.消失时间)
                {
                    base.清空邻居时处理();
                    base.解绑网格();
                    this.尸体消失 = true;
                }
                if (MainProcess.CurrentTime >= this.复活时间)
                {
                    base.清空邻居时处理();
                    base.解绑网格();
                    this.守卫复活处理();
                }
            }
            else
            {
                foreach (KeyValuePair<ushort, BuffData> keyValuePair in this.Buff列表.ToList<KeyValuePair<ushort, BuffData>>())
                {
                    base.轮询Buff时处理(keyValuePair.Value);
                }
                foreach (SkillInstance 技能实例 in this.SkillTasks.ToList<SkillInstance>())
                {
                    技能实例.Process();
                }
                if (MainProcess.CurrentTime > base.恢复时间)
                {
                    if (!this.CheckStatus(GameObjectState.Poisoned))
                    {
                        this.CurrentStamina += 5;
                    }
                    base.恢复时间 = MainProcess.CurrentTime.AddSeconds(5.0);
                }
                if (this.ActiveAttackTarget && MainProcess.CurrentTime > this.忙碌时间 && MainProcess.CurrentTime > this.硬直时间)
                {
                    if (this.更新HateObject())
                    {
                        this.守卫智能Attack();
                    }
                    else if (this.HateObject.仇恨列表.Count == 0 && this.能否转动())
                    {
                        this.当前方向 = this.出生方向;
                    }
                }
                if (this.MobId == 6121 && this.CurrentMap.MapId == 183 && MainProcess.CurrentTime > this.转移计时)
                {
                    base.清空邻居时处理();
                    base.解绑网格();
                    this.CurrentCoords = this.CurrentMap.传送区域.RandomCoords;
                    base.绑定网格();
                    base.更新邻居时处理();
                    this.转移计时 = MainProcess.CurrentTime.AddMinutes(2.5);
                }
            }
            base.处理对象数据();
        }


        public override void ItSelf死亡处理(MapObject 对象, bool 技能击杀)
        {
            base.ItSelf死亡处理(对象, 技能击杀);
            this.消失时间 = MainProcess.CurrentTime.AddMilliseconds(10000.0);
            this.复活时间 = MainProcess.CurrentTime.AddMilliseconds((double)((this.CurrentMap.MapId == 80) ? int.MaxValue : 60000));
            this.Buff列表.Clear();
            this.次要对象 = true;
            MapGatewayProcess.添加次要对象(this);
            if (this.激活对象)
            {
                this.激活对象 = false;
                MapGatewayProcess.移除激活对象(this);
            }
        }


        public void 守卫沉睡处理()
        {
            if (this.激活对象)
            {
                this.激活对象 = false;
                this.SkillTasks.Clear();
                MapGatewayProcess.移除激活对象(this);
            }
        }


        public void 守卫激活处理()
        {
            if (!this.激活对象)
            {
                this.激活对象 = true;
                MapGatewayProcess.添加激活对象(this);
                int num = (int)Math.Max(0.0, (MainProcess.CurrentTime - base.恢复时间).TotalSeconds / 5.0);
                base.CurrentStamina = Math.Min(this[GameObjectStats.MaxPhysicalStrength], this.CurrentStamina + num * this[GameObjectStats.体力恢复]);
                base.恢复时间 = base.恢复时间.AddSeconds(5.0);
            }
        }


        public void 守卫智能Attack()
        {
            if (CheckStatus(GameObjectState.Paralyzed | GameObjectState.Absence) || BasicAttackSkills == null)
                return;

            if (网格距离(HateObject.当前目标) > BasicAttackSkills.MaxDistance)
            {
                HateObject.移除仇恨(HateObject.当前目标);
            }
            else
            {
                GameSkills 技能模板 = BasicAttackSkills;
                new SkillInstance(this, 技能模板, null, 动作编号++, this.CurrentMap, this.CurrentCoords, this.HateObject.当前目标, this.HateObject.当前目标.CurrentCoords, null, null, false);
            }
        }


        public void 守卫复活处理()
        {
            this.更新对象Stat();
            this.次要对象 = false;
            this.Died = false;
            this.阻塞网格 = !this.对象模板.Nothingness;
            this.CurrentMap = this.出生地图;
            this.当前方向 = this.出生方向;
            this.CurrentCoords = this.出生坐标;
            this.CurrentStamina = this[GameObjectStats.MaxPhysicalStrength];
            base.恢复时间 = MainProcess.CurrentTime.AddMilliseconds((double)MainProcess.RandomNumber.Next(5000));
            this.HateObject = new HateObject();
            base.绑定网格();
            base.更新邻居时处理();
        }


        public bool 更新HateObject()
        {
            if (this.HateObject.仇恨列表.Count == 0)
            {
                return false;
            }
            if (this.HateObject.当前目标 == null)
            {
                return this.HateObject.切换仇恨(this);
            }
            if (this.HateObject.当前目标.Died)
            {
                this.HateObject.移除仇恨(this.HateObject.当前目标);
            }
            else if (!this.Neighbors.Contains(this.HateObject.当前目标))
            {
                this.HateObject.移除仇恨(this.HateObject.当前目标);
            }
            else if (!this.HateObject.仇恨列表.ContainsKey(this.HateObject.当前目标))
            {
                this.HateObject.移除仇恨(this.HateObject.当前目标);
            }
            else if (base.网格距离(this.HateObject.当前目标) > this.RangeHate)
            {
                this.HateObject.移除仇恨(this.HateObject.当前目标);
            }
            return this.HateObject.当前目标 != null || this.更新HateObject();
        }


        public void 清空守卫仇恨()
        {
            this.HateObject.当前目标 = null;
            this.HateObject.仇恨列表.Clear();
        }


        public Guards 对象模板;


        public HateObject HateObject;


        public Point 出生坐标;


        public GameDirection 出生方向;


        public MapInstance 出生地图;


        public GameSkills BasicAttackSkills;
    }
}
