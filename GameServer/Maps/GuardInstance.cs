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

        public bool 尸体消失 { get; set; }


        public DateTime 复活时间 { get; set; }


        public DateTime 消失时间 { get; set; }


        public DateTime 转移计时 { get; set; }


        public override int 处理间隔
        {
            get
            {
                return 10;
            }
        }


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
                    base.SendPacket(new SyncObjectHP
                    {
                        ObjectId = this.ObjectId,
                        CurrentHP = this.CurrentStamina,
                        MaxHP = this[GameObjectStats.MaxPhysicalStrength]
                    });
                }
            }
        }


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
                    base.SendPacket(new ObjectRotationDirectionPacket
                    {
                        转向耗时 = 100,
                        对象编号 = this.ObjectId,
                        对象朝向 = (ushort)value
                    });
                }
            }
        }


        public override byte CurrentRank
        {
            get
            {
                return this.对象模板.Level;
            }
        }


        public override bool CanBeHit
        {
            get
            {
                return this.CanBeInjured && !this.Died;
            }
        }


        public override string 对象名字
        {
            get
            {
                return this.对象模板.Name;
            }
        }


        public override GameObjectType ObjectType
        {
            get
            {
                return GameObjectType.Npcc;
            }
        }


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


        public int RangeHate
        {
            get
            {
                return 10;
            }
        }


        public ushort MobId
        {
            get
            {
                return this.对象模板.GuardNumber;
            }
        }


        public int RevivalInterval
        {
            get
            {
                return this.对象模板.RevivalInterval;
            }
        }


        public int StoreId
        {
            get
            {
                return this.对象模板.StoreId;
            }
        }


        public string InterfaceCode
        {
            get
            {
                return this.对象模板.InterfaceCode;
            }
        }


        public bool CanBeInjured
        {
            get
            {
                return this.对象模板.CanBeInjured;
            }
        }


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
            this.ObjectId = ++MapGatewayProcess.对象编号;
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
