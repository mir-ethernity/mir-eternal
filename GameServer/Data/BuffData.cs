using System;
using System.Collections.Generic;
using GameServer.Maps;
using GameServer.Templates;

namespace GameServer.Data
{

    public sealed class BuffData : GameData
    {

        public BuffData()
        {


        }


        public BuffData(MapObject 来源, MapObject 目标, ushort 编号)
        {


            this.Buff来源 = 来源;
            this.Id.V = 编号;
            this.当前层数.V = this.Template.BuffInitialLayer;
            this.持续时间.V = TimeSpan.FromMilliseconds((double)this.Template.Duration);
            this.处理计时.V = TimeSpan.FromMilliseconds((double)this.Template.ProcessDelay);
            PlayerObject PlayerObject = 来源 as PlayerObject;
            if (PlayerObject != null)
            {
                SkillData SkillData;
                if (this.Template.BindingSkillLevel != 0 && PlayerObject.MainSkills表.TryGetValue(this.Template.BindingSkillLevel, out SkillData))
                {
                    this.Buff等级.V = SkillData.SkillLevel.V;
                }
                if (this.Template.ExtendedDuration && this.Template.SkillLevelDelay)
                {
                    this.持续时间.V += TimeSpan.FromMilliseconds((double)((int)this.Buff等级.V * this.Template.ExtendedTimePerLevel));
                }
                if (this.Template.ExtendedDuration && this.Template.PlayerStatDelay)
                {
                    this.持续时间.V += TimeSpan.FromMilliseconds((double)((float)PlayerObject[this.Template.BoundPlayerStat] * this.Template.StatDelayFactor));
                }
                SkillData SkillData2;
                if (this.Template.ExtendedDuration && this.Template.HasSpecificInscriptionDelay && PlayerObject.MainSkills表.TryGetValue((ushort)(this.Template.SpecificInscriptionSkills / 10), out SkillData2) && (int)SkillData2.Id == this.Template.SpecificInscriptionSkills % 10)
                {
                    this.持续时间.V += TimeSpan.FromMilliseconds((double)this.Template.InscriptionExtendedTime);
                }
            }
            else
            {
                PetObject PetObject = 来源 as PetObject;
                if (PetObject != null)
                {
                    SkillData SkillData3;
                    if (this.Template.BindingSkillLevel != 0 && PetObject.PlayerOwner.MainSkills表.TryGetValue(this.Template.BindingSkillLevel, out SkillData3))
                    {
                        this.Buff等级.V = SkillData3.SkillLevel.V;
                    }
                    if (this.Template.ExtendedDuration && this.Template.SkillLevelDelay)
                    {
                        this.持续时间.V += TimeSpan.FromMilliseconds((double)((int)this.Buff等级.V * this.Template.ExtendedTimePerLevel));
                    }
                    if (this.Template.ExtendedDuration && this.Template.PlayerStatDelay)
                    {
                        this.持续时间.V += TimeSpan.FromMilliseconds((double)((float)PetObject.PlayerOwner[this.Template.BoundPlayerStat] * this.Template.StatDelayFactor));
                    }
                    SkillData SkillData4;
                    if (this.Template.ExtendedDuration && this.Template.HasSpecificInscriptionDelay && PetObject.PlayerOwner.MainSkills表.TryGetValue((ushort)(this.Template.SpecificInscriptionSkills / 10), out SkillData4) && (int)SkillData4.Id == this.Template.SpecificInscriptionSkills % 10)
                    {
                        this.持续时间.V += TimeSpan.FromMilliseconds((double)this.Template.InscriptionExtendedTime);
                    }
                }
            }
            this.剩余时间.V = this.持续时间.V;
            if ((this.Effect & BuffEffectType.CausesSomeDamages) != BuffEffectType.SkillSign)
            {
                int[] DamageBase = this.Template.DamageBase;
                int? num = (DamageBase != null) ? new int?(DamageBase.Length) : null;
                int v = (int)this.Buff等级.V;
                int num2 = (num.GetValueOrDefault() > v & num != null) ? this.Template.DamageBase[(int)this.Buff等级.V] : 0;
                float[] DamageFactor = this.Template.DamageFactor;
                num = ((DamageFactor != null) ? new int?(DamageFactor.Length) : null);
                v = (int)this.Buff等级.V;
                float num3 = (num.GetValueOrDefault() > v & num != null) ? this.Template.DamageFactor[(int)this.Buff等级.V] : 0f;
                PlayerObject PlayerObject2 = 来源 as PlayerObject;
                SkillData SkillData5;
                if (PlayerObject2 != null && this.Template.StrengthenInscriptionId != 0 && PlayerObject2.MainSkills表.TryGetValue((ushort)(this.Template.StrengthenInscriptionId / 10), out SkillData5) && (int)SkillData5.Id == this.Template.StrengthenInscriptionId % 10)
                {
                    num2 += this.Template.StrengthenInscriptionBase;
                    num3 += this.Template.StrengthenInscriptionFactor;
                }
                int num4 = 0;
                switch (this.伤害类型)
                {
                    case SkillDamageType.Attack:
                        num4 = ComputingClass.CalculateAttack(来源[GameObjectStats.MinDC], 来源[GameObjectStats.MaxDC], 来源[GameObjectStats.Luck]);
                        break;
                    case SkillDamageType.Magic:
                        num4 = ComputingClass.CalculateAttack(来源[GameObjectStats.MinMC], 来源[GameObjectStats.MaxMC], 来源[GameObjectStats.Luck]);
                        break;
                    case SkillDamageType.Taoism:
                        num4 = ComputingClass.CalculateAttack(来源[GameObjectStats.MinSC], 来源[GameObjectStats.MaxSC], 来源[GameObjectStats.Luck]);
                        break;
                    case SkillDamageType.Needle:
                        num4 = ComputingClass.CalculateAttack(来源[GameObjectStats.MinNC], 来源[GameObjectStats.MaxNC], 来源[GameObjectStats.Luck]);
                        break;
                    case SkillDamageType.Archery:
                        num4 = ComputingClass.CalculateAttack(来源[GameObjectStats.MinBC], 来源[GameObjectStats.MaxBC], 来源[GameObjectStats.Luck]);
                        break;
                    case SkillDamageType.Toxicity:
                        num4 = 来源[GameObjectStats.MaxSC];
                        break;
                    case SkillDamageType.Sacred:
                        num4 = ComputingClass.CalculateAttack(来源[GameObjectStats.MinHC], 来源[GameObjectStats.MaxHC], 0);
                        break;
                }
                this.伤害基数.V = num2 + (int)((float)num4 * num3);
            }
            if (目标 is PlayerObject)
            {
                GameDataGateway.BuffData表.AddData(this, true);
            }
        }


        public override string ToString()
        {
            GameBuffs buff模板 = this.Template;
            if (buff模板 == null)
            {
                return null;
            }
            return buff模板.Name;
        }


        public BuffEffectType Effect
        {
            get
            {
                return this.Template.Effect;
            }
        }


        public SkillDamageType 伤害类型
        {
            get
            {
                return this.Template.DamageType;
            }
        }


        public GameBuffs Template
        {
            get
            {
                GameBuffs result;
                if (!GameBuffs.DataSheet.TryGetValue(this.Id.V, out result))
                {
                    return null;
                }
                return result;
            }
        }

        public bool OnReleaseSkillRemove => Template.OnReleaseSkillRemove;


        public bool 增益Buff
        {
            get
            {
                return this.Template.ActionType == BuffActionType.Gain;
            }
        }


        public bool Buff同步
        {
            get
            {
                return this.Template.SyncClient;
            }
        }


        public bool 到期消失
        {
            get
            {
                GameBuffs buff模板 = this.Template;
                return buff模板 != null && buff模板.RemoveOnExpire;
            }
        }


        public bool 下线消失
        {
            get
            {
                return this.Template.OnPlayerDisconnectRemove;
            }
        }


        public bool 死亡消失
        {
            get
            {
                return this.Template.OnPlayerDiesRemove;
            }
        }


        public bool 换图消失
        {
            get
            {
                return this.Template.OnChangeMapRemove;
            }
        }


        public bool BoundWeapons
        {
            get
            {
                return this.Template.OnChangeWeaponRemove;
            }
        }


        public bool 添加冷却
        {
            get
            {
                return this.Template.RemoveAddCooling;
            }
        }


        public ushort 绑定技能
        {
            get
            {
                return this.Template.BindingSkillLevel;
            }
        }


        public ushort Cooldown
        {
            get
            {
                return this.Template.SkillCooldown;
            }
        }


        public int 处理延迟
        {
            get
            {
                return this.Template.ProcessDelay;
            }
        }


        public int 处理间隔
        {
            get
            {
                return this.Template.ProcessInterval;
            }
        }


        public byte 最大层数
        {
            get
            {
                return this.Template.MaxBuffCount;
            }
        }


        public ushort Buff分组
        {
            get
            {
                if (this.Template.GroupId == 0)
                {
                    return this.Id.V;
                }
                return this.Template.GroupId;
            }
        }


        public ushort[] 依存列表
        {
            get
            {
                return this.Template.RequireBuff;
            }
        }


        public Dictionary<GameObjectStats, int> Stat加成
        {
            get
            {
                if ((this.Effect & BuffEffectType.StatsIncOrDec) != BuffEffectType.SkillSign)
                {
                    return this.Template.基础StatsIncOrDec[(int)this.Buff等级.V];
                }
                return null;
            }
        }


        public MapObject Buff来源;


        public readonly DataMonitor<ushort> Id;


        public readonly DataMonitor<TimeSpan> 持续时间;


        public readonly DataMonitor<TimeSpan> 剩余时间;


        public readonly DataMonitor<TimeSpan> 处理计时;


        public readonly DataMonitor<byte> 当前层数;


        public readonly DataMonitor<byte> Buff等级;


        public readonly DataMonitor<int> 伤害基数;
    }
}
