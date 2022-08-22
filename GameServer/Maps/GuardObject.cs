using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GameServer.Data;
using GameServer.Templates;
using GameServer.Networking;

namespace GameServer.Maps
{

    public sealed class GuardObject : MapObject
    {

        public bool 尸体消失 { get; set; }


        public DateTime ResurrectionTime { get; set; }


        public DateTime DisappearTime { get; set; }


        public DateTime 转移计时 { get; set; }


        public override int ProcessInterval
        {
            get
            {
                return 10;
            }
        }


        public override DateTime BusyTime
        {
            get
            {
                return base.BusyTime;
            }
            set
            {
                if (base.BusyTime < value)
                {
                    this.HardTime = value;
                    base.BusyTime = value;
                }
            }
        }


        public override DateTime HardTime
        {
            get
            {
                return base.HardTime;
            }
            set
            {
                if (base.HardTime < value)
                {
                    base.HardTime = value;
                }
            }
        }


        public override int CurrentHP
        {
            get
            {
                return base.CurrentHP;
            }
            set
            {
                value = ComputingClass.ValueLimit(0, value, this[GameObjectStats.MaxHP]);
                if (base.CurrentHP != value)
                {
                    base.CurrentHP = value;
                    base.SendPacket(new SyncObjectHP
                    {
                        ObjectId = this.ObjectId,
                        CurrentHP = this.CurrentHP,
                        MaxHP = this[GameObjectStats.MaxHP]
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


        public override GameDirection CurrentDirection
        {
            get
            {
                return base.CurrentDirection;
            }
            set
            {
                if (this.CurrentDirection != value)
                {
                    base.CurrentDirection = value;
                    base.SendPacket(new ObjectRotationDirectionPacket
                    {
                        转向耗时 = 100,
                        对象编号 = this.ObjectId,
                        对象朝向 = (ushort)value
                    });
                }
            }
        }


        public override byte CurrentLevel
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


        public override string ObjectName
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
                return GameObjectType.NPC;
            }
        }


        public override ObjectSize ObjectSize
        {
            get
            {
                return ObjectSize.Single1x1;
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


        public GuardObject(Guards 对应模板, MapInstance 出生地图, GameDirection 出生方向, Point 出生坐标)
        {
            this.对象模板 = 对应模板;
            this.出生地图 = 出生地图;
            this.CurrentMap = 出生地图;
            this.出生方向 = 出生方向;
            this.出生坐标 = 出生坐标;
            this.ObjectId = ++MapGatewayProcess.对象编号;
            Dictionary<object, Dictionary<GameObjectStats, int>> Stat加成 = this.StatsBonus;
            Dictionary<GameObjectStats, int> dictionary = new Dictionary<GameObjectStats, int>();
            dictionary[GameObjectStats.MaxHP] = 9999;
            Stat加成[this] = dictionary;
            string text = this.对象模板.BasicAttackSkills;
            if (text != null && text.Length > 0)
            {
                GameSkills.DataSheet.TryGetValue(this.对象模板.BasicAttackSkills, out this.BasicAttackSkills);
            }
            MapGatewayProcess.添加MapObject(this);
            this.守卫复活处理();
        }


        public override void Process()
        {
            if (MainProcess.CurrentTime < base.ProcessTime)
            {
                return;
            }
            if (this.Died)
            {
                if (!this.尸体消失 && MainProcess.CurrentTime >= this.DisappearTime)
                {
                    base.NotifyNeightborClear();
                    base.UnbindGrid();
                    this.尸体消失 = true;
                }
                if (MainProcess.CurrentTime >= this.ResurrectionTime)
                {
                    base.NotifyNeightborClear();
                    base.UnbindGrid();
                    this.守卫复活处理();
                }
            }
            else
            {
                foreach (KeyValuePair<ushort, BuffData> keyValuePair in this.Buffs.ToList<KeyValuePair<ushort, BuffData>>())
                {
                    base.轮询Buff时处理(keyValuePair.Value);
                }
                foreach (SkillInstance 技能实例 in this.SkillTasks.ToList<SkillInstance>())
                {
                    技能实例.Process();
                }
                if (MainProcess.CurrentTime > base.RecoveryTime)
                {
                    if (!this.CheckStatus(GameObjectState.Poisoned))
                    {
                        this.CurrentHP += 5;
                    }
                    base.RecoveryTime = MainProcess.CurrentTime.AddSeconds(5.0);
                }
                if (this.ActiveAttackTarget && MainProcess.CurrentTime > this.BusyTime && MainProcess.CurrentTime > this.HardTime)
                {
                    if (this.更新HateObject())
                    {
                        this.守卫智能Attack();
                    }
                    else if (this.HateObject.仇恨列表.Count == 0 && this.CanBeTurned())
                    {
                        this.CurrentDirection = this.出生方向;
                    }
                }
                if (this.MobId == 6121 && this.CurrentMap.MapId == 183 && MainProcess.CurrentTime > this.转移计时)
                {
                    base.NotifyNeightborClear();
                    base.UnbindGrid();
                    this.CurrentPosition = this.CurrentMap.传送区域.RandomCoords;
                    base.BindGrid();
                    base.更新邻居时处理();
                    this.转移计时 = MainProcess.CurrentTime.AddMinutes(2.5);
                }
            }
            base.Process();
        }


        public override void Dies(MapObject obj, bool skillKill)
        {
            base.Dies(obj, skillKill);
            this.DisappearTime = MainProcess.CurrentTime.AddMilliseconds(10000.0);
            this.ResurrectionTime = MainProcess.CurrentTime.AddMilliseconds((double)((this.CurrentMap.MapId == 80) ? int.MaxValue : 60000));
            this.Buffs.Clear();
            this.SecondaryObject = true;
            MapGatewayProcess.AddSecondaryObject(this);
            if (this.ActiveObject)
            {
                this.ActiveObject = false;
                MapGatewayProcess.RemoveActiveObject(this);
            }
        }


        public void 守卫沉睡处理()
        {
            if (this.ActiveObject)
            {
                this.ActiveObject = false;
                this.SkillTasks.Clear();
                MapGatewayProcess.RemoveActiveObject(this);
            }
        }


        public void 守卫激活处理()
        {
            if (!this.ActiveObject)
            {
                this.ActiveObject = true;
                MapGatewayProcess.添加激活对象(this);
                int num = (int)Math.Max(0.0, (MainProcess.CurrentTime - base.RecoveryTime).TotalSeconds / 5.0);
                base.CurrentHP = Math.Min(this[GameObjectStats.MaxHP], this.CurrentHP + num * this[GameObjectStats.体力恢复]);
                base.RecoveryTime = base.RecoveryTime.AddSeconds(5.0);
            }
        }


        public void 守卫智能Attack()
        {
            if (CheckStatus(GameObjectState.Paralyzed | GameObjectState.Absence) || BasicAttackSkills == null)
                return;

            if (GetDistance(HateObject.当前目标) > BasicAttackSkills.MaxDistance)
            {
                HateObject.移除仇恨(HateObject.当前目标);
            }
            else
            {
                GameSkills 技能模板 = BasicAttackSkills;
                new SkillInstance(this, 技能模板, null, ActionId++, this.CurrentMap, this.CurrentPosition, this.HateObject.当前目标, this.HateObject.当前目标.CurrentPosition, null, null, false);
            }
        }


        public void 守卫复活处理()
        {
            this.RefreshStats();
            this.SecondaryObject = false;
            this.Died = false;
            this.Blocking = !this.对象模板.Nothingness;
            this.CurrentMap = this.出生地图;
            this.CurrentDirection = this.出生方向;
            this.CurrentPosition = this.出生坐标;
            this.CurrentHP = this[GameObjectStats.MaxHP];
            base.RecoveryTime = MainProcess.CurrentTime.AddMilliseconds((double)MainProcess.RandomNumber.Next(5000));
            this.HateObject = new HateObject();
            base.BindGrid();
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
            else if (base.GetDistance(this.HateObject.当前目标) > this.RangeHate)
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
