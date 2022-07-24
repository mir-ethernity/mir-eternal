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
				if (this.Buff模板.BindingSkillLevel != 0 && PlayerObject.主体技能表.TryGetValue(this.Buff模板.BindingSkillLevel, out SkillData))
				{
					this.Buff等级.V = SkillData.技能等级.V;
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
				if (this.Buff模板.ExtendedDuration && this.Buff模板.HasSpecificInscriptionDelay && PlayerObject.主体技能表.TryGetValue((ushort)(this.Buff模板.SpecificInscriptionSkills / 10), out SkillData2) && (int)SkillData2.铭文编号 == this.Buff模板.SpecificInscriptionSkills % 10)
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
					if (this.Buff模板.BindingSkillLevel != 0 && PetObject.宠物主人.主体技能表.TryGetValue(this.Buff模板.BindingSkillLevel, out SkillData3))
					{
						this.Buff等级.V = SkillData3.技能等级.V;
					}
					if (this.Buff模板.ExtendedDuration && this.Buff模板.SkillLevelDelay)
					{
						this.持续时间.V += TimeSpan.FromMilliseconds((double)((int)this.Buff等级.V * this.Buff模板.ExtendedTimePerLevel));
					}
					if (this.Buff模板.ExtendedDuration && this.Buff模板.PlayerStatDelay)
					{
						this.持续时间.V += TimeSpan.FromMilliseconds((double)((float)PetObject.宠物主人[this.Buff模板.BoundPlayerStat] * this.Buff模板.StatDelayFactor));
					}
					SkillData SkillData4;
					if (this.Buff模板.ExtendedDuration && this.Buff模板.HasSpecificInscriptionDelay && PetObject.宠物主人.主体技能表.TryGetValue((ushort)(this.Buff模板.SpecificInscriptionSkills / 10), out SkillData4) && (int)SkillData4.铭文编号 == this.Buff模板.SpecificInscriptionSkills % 10)
					{
						this.持续时间.V += TimeSpan.FromMilliseconds((double)this.Buff模板.InscriptionExtendedTime);
					}
				}
			}
			this.剩余时间.V = this.持续时间.V;
			if ((this.Effect & BuffEffectType.造成伤害) != BuffEffectType.技能标志)
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
				if (PlayerObject2 != null && this.Buff模板.StrengthenInscriptionId != 0 && PlayerObject2.主体技能表.TryGetValue((ushort)(this.Buff模板.StrengthenInscriptionId / 10), out SkillData5) && (int)SkillData5.铭文编号 == this.Buff模板.StrengthenInscriptionId % 10)
				{
					num2 += this.Buff模板.StrengthenInscriptionBase;
					num3 += this.Buff模板.StrengthenInscriptionFactor;
				}
				int num4 = 0;
				switch (this.伤害类型)
				{
				case SkillDamageType.Attack:
					num4 = ComputingClass.计算Attack(来源[GameObjectStats.MinAttack], 来源[GameObjectStats.MaxAttack], 来源[GameObjectStats.幸运等级]);
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

		
		// (get) Token: 0x0600042B RID: 1067 RVA: 0x000042BF File Offset: 0x000024BF
		public BuffEffectType Effect
		{
			get
			{
				return this.Buff模板.Effect;
			}
		}

		
		// (get) Token: 0x0600042C RID: 1068 RVA: 0x000042CC File Offset: 0x000024CC
		public SkillDamageType 伤害类型
		{
			get
			{
				return this.Buff模板.DamageType;
			}
		}

		
		// (get) Token: 0x0600042D RID: 1069 RVA: 0x00020AE0 File Offset: 0x0001ECE0
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

		
		// (get) Token: 0x0600042E RID: 1070 RVA: 0x000042D9 File Offset: 0x000024D9
		public bool 增益Buff
		{
			get
			{
				return this.Buff模板.ActionType == BuffActionType.增益类型;
			}
		}

		
		// (get) Token: 0x0600042F RID: 1071 RVA: 0x000042E9 File Offset: 0x000024E9
		public bool Buff同步
		{
			get
			{
				return this.Buff模板.SyncClient;
			}
		}

		
		// (get) Token: 0x06000430 RID: 1072 RVA: 0x000042F6 File Offset: 0x000024F6
		public bool 到期消失
		{
			get
			{
				GameBuffs buff模板 = this.Buff模板;
				return buff模板 != null && buff模板.RemoveOnExpire;
			}
		}

		
		// (get) Token: 0x06000431 RID: 1073 RVA: 0x00004309 File Offset: 0x00002509
		public bool 下线消失
		{
			get
			{
				return this.Buff模板.OnPlayerDisconnectRemove;
			}
		}

		
		// (get) Token: 0x06000432 RID: 1074 RVA: 0x00004316 File Offset: 0x00002516
		public bool 死亡消失
		{
			get
			{
				return this.Buff模板.OnPlayerDiesRemove;
			}
		}

		
		// (get) Token: 0x06000433 RID: 1075 RVA: 0x00004323 File Offset: 0x00002523
		public bool 换图消失
		{
			get
			{
				return this.Buff模板.OnChangeMapRemove;
			}
		}

		
		// (get) Token: 0x06000434 RID: 1076 RVA: 0x00004330 File Offset: 0x00002530
		public bool 绑定武器
		{
			get
			{
				return this.Buff模板.OnChangeWeaponRemove;
			}
		}

		
		// (get) Token: 0x06000435 RID: 1077 RVA: 0x0000433D File Offset: 0x0000253D
		public bool 添加冷却
		{
			get
			{
				return this.Buff模板.RemoveAddCooling;
			}
		}

		
		// (get) Token: 0x06000436 RID: 1078 RVA: 0x0000434A File Offset: 0x0000254A
		public ushort 绑定技能
		{
			get
			{
				return this.Buff模板.BindingSkillLevel;
			}
		}

		
		// (get) Token: 0x06000437 RID: 1079 RVA: 0x00004357 File Offset: 0x00002557
		public ushort Cooldown
		{
			get
			{
				return this.Buff模板.SkillCooldown;
			}
		}

		
		// (get) Token: 0x06000438 RID: 1080 RVA: 0x00004364 File Offset: 0x00002564
		public int 处理延迟
		{
			get
			{
				return this.Buff模板.ProcessDelay;
			}
		}

		
		// (get) Token: 0x06000439 RID: 1081 RVA: 0x00004371 File Offset: 0x00002571
		public int 处理间隔
		{
			get
			{
				return this.Buff模板.ProcessInterval;
			}
		}

		
		// (get) Token: 0x0600043A RID: 1082 RVA: 0x0000437E File Offset: 0x0000257E
		public byte 最大层数
		{
			get
			{
				return this.Buff模板.MaxBuffCount;
			}
		}

		
		// (get) Token: 0x0600043B RID: 1083 RVA: 0x0000438B File Offset: 0x0000258B
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

		
		// (get) Token: 0x0600043C RID: 1084 RVA: 0x000043B1 File Offset: 0x000025B1
		public ushort[] 依存列表
		{
			get
			{
				return this.Buff模板.RequireBuff;
			}
		}

		
		// (get) Token: 0x0600043D RID: 1085 RVA: 0x000043BE File Offset: 0x000025BE
		public Dictionary<GameObjectStats, int> Stat加成
		{
			get
			{
				if ((this.Effect & BuffEffectType.StatsIncOrDec) != BuffEffectType.技能标志)
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
