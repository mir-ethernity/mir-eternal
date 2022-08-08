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
			this.当前层数.V = this.Buff模板.BuffInitialLayer;
			this.持续时间.V = TimeSpan.FromMilliseconds((double)this.Buff模板.Duration);
			this.处理计时.V = TimeSpan.FromMilliseconds((double)this.Buff模板.ProcessDelay);
			PlayerObject PlayerObject = 来源 as PlayerObject;
			if (PlayerObject != null)
			{
				SkillData SkillData;
				if (this.Buff模板.BindingSkillLevel != 0 && PlayerObject.MainSkills表.TryGetValue(this.Buff模板.BindingSkillLevel, out SkillData))
				{
					this.Buff等级.V = SkillData.SkillLevel.V;
				}
				if (this.Buff模板.ExtendedDuration && this.Buff模板.SkillLevelDelay)
				{
					this.持续时间.V += TimeSpan.FromMilliseconds((double)((int)this.Buff等级.V * this.Buff模板.ExtendedTimePerLevel));
				}
				if (this.Buff模板.ExtendedDuration && this.Buff模板.PlayerStatDelay)
				{
					this.持续时间.V += TimeSpan.FromMilliseconds((double)((float)PlayerObject[this.Buff模板.BoundPlayerStat] * this.Buff模板.StatDelayFactor));
				}
				SkillData SkillData2;
				if (this.Buff模板.ExtendedDuration && this.Buff模板.HasSpecificInscriptionDelay && PlayerObject.MainSkills表.TryGetValue((ushort)(this.Buff模板.SpecificInscriptionSkills / 10), out SkillData2) && (int)SkillData2.Id == this.Buff模板.SpecificInscriptionSkills % 10)
				{
					this.持续时间.V += TimeSpan.FromMilliseconds((double)this.Buff模板.InscriptionExtendedTime);
				}
			}
			else
			{
				PetObject PetObject = 来源 as PetObject;
				if (PetObject != null)
				{
					SkillData SkillData3;
					if (this.Buff模板.BindingSkillLevel != 0 && PetObject.PlayerOwner.MainSkills表.TryGetValue(this.Buff模板.BindingSkillLevel, out SkillData3))
					{
						this.Buff等级.V = SkillData3.SkillLevel.V;
					}
					if (this.Buff模板.ExtendedDuration && this.Buff模板.SkillLevelDelay)
					{
						this.持续时间.V += TimeSpan.FromMilliseconds((double)((int)this.Buff等级.V * this.Buff模板.ExtendedTimePerLevel));
					}
					if (this.Buff模板.ExtendedDuration && this.Buff模板.PlayerStatDelay)
					{
						this.持续时间.V += TimeSpan.FromMilliseconds((double)((float)PetObject.PlayerOwner[this.Buff模板.BoundPlayerStat] * this.Buff模板.StatDelayFactor));
					}
					SkillData SkillData4;
					if (this.Buff模板.ExtendedDuration && this.Buff模板.HasSpecificInscriptionDelay && PetObject.PlayerOwner.MainSkills表.TryGetValue((ushort)(this.Buff模板.SpecificInscriptionSkills / 10), out SkillData4) && (int)SkillData4.Id == this.Buff模板.SpecificInscriptionSkills % 10)
					{
						this.持续时间.V += TimeSpan.FromMilliseconds((double)this.Buff模板.InscriptionExtendedTime);
					}
				}
			}
			this.剩余时间.V = this.持续时间.V;
			if ((this.Effect & BuffEffectType.CausesSomeDamages) != BuffEffectType.SkillSign)
			{
				int[] DamageBase = this.Buff模板.DamageBase;
				int? num = (DamageBase != null) ? new int?(DamageBase.Length) : null;
				int v = (int)this.Buff等级.V;
				int num2 = (num.GetValueOrDefault() > v & num != null) ? this.Buff模板.DamageBase[(int)this.Buff等级.V] : 0;
				float[] DamageFactor = this.Buff模板.DamageFactor;
				num = ((DamageFactor != null) ? new int?(DamageFactor.Length) : null);
				v = (int)this.Buff等级.V;
				float num3 = (num.GetValueOrDefault() > v & num != null) ? this.Buff模板.DamageFactor[(int)this.Buff等级.V] : 0f;
				PlayerObject PlayerObject2 = 来源 as PlayerObject;
				SkillData SkillData5;
				if (PlayerObject2 != null && this.Buff模板.StrengthenInscriptionId != 0 && PlayerObject2.MainSkills表.TryGetValue((ushort)(this.Buff模板.StrengthenInscriptionId / 10), out SkillData5) && (int)SkillData5.Id == this.Buff模板.StrengthenInscriptionId % 10)
				{
					num2 += this.Buff模板.StrengthenInscriptionBase;
					num3 += this.Buff模板.StrengthenInscriptionFactor;
				}
				int num4 = 0;
				switch (this.伤害类型)
				{
				case SkillDamageType.Attack:
					num4 = ComputingClass.计算Attack(来源[GameObjectStats.MinAC], 来源[GameObjectStats.MaxAC], 来源[GameObjectStats.幸运等级]);
					break;
				case SkillDamageType.Magic:
					num4 = ComputingClass.计算Attack(来源[GameObjectStats.MinMagic], 来源[GameObjectStats.MaxMagic], 来源[GameObjectStats.幸运等级]);
					break;
				case SkillDamageType.Taoism:
					num4 = ComputingClass.计算Attack(来源[GameObjectStats.Minimalist], 来源[GameObjectStats.GreatestTaoism], 来源[GameObjectStats.幸运等级]);
					break;
				case SkillDamageType.Needle:
					num4 = ComputingClass.计算Attack(来源[GameObjectStats.MinNeedle], 来源[GameObjectStats.MaxNeedle], 来源[GameObjectStats.幸运等级]);
					break;
				case SkillDamageType.Archery:
					num4 = ComputingClass.计算Attack(来源[GameObjectStats.MinBow], 来源[GameObjectStats.MaxBow], 来源[GameObjectStats.幸运等级]);
					break;
				case SkillDamageType.Toxicity:
					num4 = 来源[GameObjectStats.GreatestTaoism];
					break;
				case SkillDamageType.Sacred:
					num4 = ComputingClass.计算Attack(来源[GameObjectStats.最小圣伤], 来源[GameObjectStats.最大圣伤], 0);
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
			GameBuffs buff模板 = this.Buff模板;
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
				return this.Buff模板.Effect;
			}
		}

		
		public SkillDamageType 伤害类型
		{
			get
			{
				return this.Buff模板.DamageType;
			}
		}

		
		public GameBuffs Buff模板
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

		
		public bool 增益Buff
		{
			get
			{
				return this.Buff模板.ActionType == BuffActionType.Gain;
			}
		}

		
		public bool Buff同步
		{
			get
			{
				return this.Buff模板.SyncClient;
			}
		}

		
		public bool 到期消失
		{
			get
			{
				GameBuffs buff模板 = this.Buff模板;
				return buff模板 != null && buff模板.RemoveOnExpire;
			}
		}

		
		public bool 下线消失
		{
			get
			{
				return this.Buff模板.OnPlayerDisconnectRemove;
			}
		}

		
		public bool 死亡消失
		{
			get
			{
				return this.Buff模板.OnPlayerDiesRemove;
			}
		}

		
		public bool 换图消失
		{
			get
			{
				return this.Buff模板.OnChangeMapRemove;
			}
		}

		
		public bool BoundWeapons
		{
			get
			{
				return this.Buff模板.OnChangeWeaponRemove;
			}
		}

		
		public bool 添加冷却
		{
			get
			{
				return this.Buff模板.RemoveAddCooling;
			}
		}

		
		public ushort 绑定技能
		{
			get
			{
				return this.Buff模板.BindingSkillLevel;
			}
		}

		
		public ushort Cooldown
		{
			get
			{
				return this.Buff模板.SkillCooldown;
			}
		}

		
		public int 处理延迟
		{
			get
			{
				return this.Buff模板.ProcessDelay;
			}
		}

		
		public int 处理间隔
		{
			get
			{
				return this.Buff模板.ProcessInterval;
			}
		}

		
		public byte 最大层数
		{
			get
			{
				return this.Buff模板.MaxBuffCount;
			}
		}

		
		public ushort Buff分组
		{
			get
			{
				if (this.Buff模板.GroupId == 0)
				{
					return this.Id.V;
				}
				return this.Buff模板.GroupId;
			}
		}

		
		public ushort[] 依存列表
		{
			get
			{
				return this.Buff模板.RequireBuff;
			}
		}

		
		public Dictionary<GameObjectStats, int> Stat加成
		{
			get
			{
				if ((this.Effect & BuffEffectType.StatsIncOrDec) != BuffEffectType.SkillSign)
				{
					return this.Buff模板.基础StatsIncOrDec[(int)this.Buff等级.V];
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
