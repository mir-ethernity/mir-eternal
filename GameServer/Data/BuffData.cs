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
			this.Buff编号.V = 编号;
			this.当前层数.V = this.Buff模板.Buff初始层数;
			this.持续时间.V = TimeSpan.FromMilliseconds((double)this.Buff模板.Buff持续时间);
			this.处理计时.V = TimeSpan.FromMilliseconds((double)this.Buff模板.Buff处理延迟);
			PlayerObject PlayerObject = 来源 as PlayerObject;
			if (PlayerObject != null)
			{
				SkillData SkillData;
				if (this.Buff模板.绑定技能等级 != 0 && PlayerObject.主体技能表.TryGetValue(this.Buff模板.绑定技能等级, out SkillData))
				{
					this.Buff等级.V = SkillData.技能等级.V;
				}
				if (this.Buff模板.持续时间延长 && this.Buff模板.技能等级延时)
				{
					this.持续时间.V += TimeSpan.FromMilliseconds((double)((int)this.Buff等级.V * this.Buff模板.每级延长时间));
				}
				if (this.Buff模板.持续时间延长 && this.Buff模板.角色属性延时)
				{
					this.持续时间.V += TimeSpan.FromMilliseconds((double)((float)PlayerObject[this.Buff模板.绑定角色属性] * this.Buff模板.属性延时系数));
				}
				SkillData SkillData2;
				if (this.Buff模板.持续时间延长 && this.Buff模板.特定铭文延时 && PlayerObject.主体技能表.TryGetValue((ushort)(this.Buff模板.特定铭文技能 / 10), out SkillData2) && (int)SkillData2.铭文编号 == this.Buff模板.特定铭文技能 % 10)
				{
					this.持续时间.V += TimeSpan.FromMilliseconds((double)this.Buff模板.铭文延长时间);
				}
			}
			else
			{
				PetObject PetObject = 来源 as PetObject;
				if (PetObject != null)
				{
					SkillData SkillData3;
					if (this.Buff模板.绑定技能等级 != 0 && PetObject.宠物主人.主体技能表.TryGetValue(this.Buff模板.绑定技能等级, out SkillData3))
					{
						this.Buff等级.V = SkillData3.技能等级.V;
					}
					if (this.Buff模板.持续时间延长 && this.Buff模板.技能等级延时)
					{
						this.持续时间.V += TimeSpan.FromMilliseconds((double)((int)this.Buff等级.V * this.Buff模板.每级延长时间));
					}
					if (this.Buff模板.持续时间延长 && this.Buff模板.角色属性延时)
					{
						this.持续时间.V += TimeSpan.FromMilliseconds((double)((float)PetObject.宠物主人[this.Buff模板.绑定角色属性] * this.Buff模板.属性延时系数));
					}
					SkillData SkillData4;
					if (this.Buff模板.持续时间延长 && this.Buff模板.特定铭文延时 && PetObject.宠物主人.主体技能表.TryGetValue((ushort)(this.Buff模板.特定铭文技能 / 10), out SkillData4) && (int)SkillData4.铭文编号 == this.Buff模板.特定铭文技能 % 10)
					{
						this.持续时间.V += TimeSpan.FromMilliseconds((double)this.Buff模板.铭文延长时间);
					}
				}
			}
			this.剩余时间.V = this.持续时间.V;
			if ((this.Buff效果 & Buff效果类型.造成伤害) != Buff效果类型.技能标志)
			{
				int[] buff伤害基数 = this.Buff模板.Buff伤害基数;
				int? num = (buff伤害基数 != null) ? new int?(buff伤害基数.Length) : null;
				int v = (int)this.Buff等级.V;
				int num2 = (num.GetValueOrDefault() > v & num != null) ? this.Buff模板.Buff伤害基数[(int)this.Buff等级.V] : 0;
				float[] buff伤害系数 = this.Buff模板.Buff伤害系数;
				num = ((buff伤害系数 != null) ? new int?(buff伤害系数.Length) : null);
				v = (int)this.Buff等级.V;
				float num3 = (num.GetValueOrDefault() > v & num != null) ? this.Buff模板.Buff伤害系数[(int)this.Buff等级.V] : 0f;
				PlayerObject PlayerObject2 = 来源 as PlayerObject;
				SkillData SkillData5;
				if (PlayerObject2 != null && this.Buff模板.强化铭文编号 != 0 && PlayerObject2.主体技能表.TryGetValue((ushort)(this.Buff模板.强化铭文编号 / 10), out SkillData5) && (int)SkillData5.铭文编号 == this.Buff模板.强化铭文编号 % 10)
				{
					num2 += this.Buff模板.铭文强化基数;
					num3 += this.Buff模板.铭文强化系数;
				}
				int num4 = 0;
				switch (this.伤害类型)
				{
				case 技能伤害类型.攻击:
					num4 = ComputingClass.计算攻击(来源[GameObjectProperties.MinAttack], 来源[GameObjectProperties.MaxAttack], 来源[GameObjectProperties.幸运等级]);
					break;
				case 技能伤害类型.魔法:
					num4 = ComputingClass.计算攻击(来源[GameObjectProperties.MinMagic], 来源[GameObjectProperties.MaxMagic], 来源[GameObjectProperties.幸运等级]);
					break;
				case 技能伤害类型.道术:
					num4 = ComputingClass.计算攻击(来源[GameObjectProperties.Minimalist], 来源[GameObjectProperties.GreatestTaoism], 来源[GameObjectProperties.幸运等级]);
					break;
				case 技能伤害类型.刺术:
					num4 = ComputingClass.计算攻击(来源[GameObjectProperties.MinNeedle], 来源[GameObjectProperties.MaxNeedle], 来源[GameObjectProperties.幸运等级]);
					break;
				case 技能伤害类型.弓术:
					num4 = ComputingClass.计算攻击(来源[GameObjectProperties.MinBow], 来源[GameObjectProperties.MaxBow], 来源[GameObjectProperties.幸运等级]);
					break;
				case 技能伤害类型.毒性:
					num4 = 来源[GameObjectProperties.GreatestTaoism];
					break;
				case 技能伤害类型.神圣:
					num4 = ComputingClass.计算攻击(来源[GameObjectProperties.最小圣伤], 来源[GameObjectProperties.最大圣伤], 0);
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
			游戏Buff buff模板 = this.Buff模板;
			if (buff模板 == null)
			{
				return null;
			}
			return buff模板.Buff名字;
		}

		
		// (get) Token: 0x0600042B RID: 1067 RVA: 0x000042BF File Offset: 0x000024BF
		public Buff效果类型 Buff效果
		{
			get
			{
				return this.Buff模板.Buff效果;
			}
		}

		
		// (get) Token: 0x0600042C RID: 1068 RVA: 0x000042CC File Offset: 0x000024CC
		public 技能伤害类型 伤害类型
		{
			get
			{
				return this.Buff模板.Buff伤害类型;
			}
		}

		
		// (get) Token: 0x0600042D RID: 1069 RVA: 0x00020AE0 File Offset: 0x0001ECE0
		public 游戏Buff Buff模板
		{
			get
			{
				游戏Buff result;
				if (!游戏Buff.DataSheet.TryGetValue(this.Buff编号.V, out result))
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
				return this.Buff模板.作用类型 == Buff作用类型.增益类型;
			}
		}

		
		// (get) Token: 0x0600042F RID: 1071 RVA: 0x000042E9 File Offset: 0x000024E9
		public bool Buff同步
		{
			get
			{
				return this.Buff模板.同步至客户端;
			}
		}

		
		// (get) Token: 0x06000430 RID: 1072 RVA: 0x000042F6 File Offset: 0x000024F6
		public bool 到期消失
		{
			get
			{
				游戏Buff buff模板 = this.Buff模板;
				return buff模板 != null && buff模板.到期主动消失;
			}
		}

		
		// (get) Token: 0x06000431 RID: 1073 RVA: 0x00004309 File Offset: 0x00002509
		public bool 下线消失
		{
			get
			{
				return this.Buff模板.角色下线消失;
			}
		}

		
		// (get) Token: 0x06000432 RID: 1074 RVA: 0x00004316 File Offset: 0x00002516
		public bool 死亡消失
		{
			get
			{
				return this.Buff模板.角色死亡消失;
			}
		}

		
		// (get) Token: 0x06000433 RID: 1075 RVA: 0x00004323 File Offset: 0x00002523
		public bool 换图消失
		{
			get
			{
				return this.Buff模板.切换地图消失;
			}
		}

		
		// (get) Token: 0x06000434 RID: 1076 RVA: 0x00004330 File Offset: 0x00002530
		public bool 绑定武器
		{
			get
			{
				return this.Buff模板.切换武器消失;
			}
		}

		
		// (get) Token: 0x06000435 RID: 1077 RVA: 0x0000433D File Offset: 0x0000253D
		public bool 添加冷却
		{
			get
			{
				return this.Buff模板.移除添加冷却;
			}
		}

		
		// (get) Token: 0x06000436 RID: 1078 RVA: 0x0000434A File Offset: 0x0000254A
		public ushort 绑定技能
		{
			get
			{
				return this.Buff模板.绑定技能等级;
			}
		}

		
		// (get) Token: 0x06000437 RID: 1079 RVA: 0x00004357 File Offset: 0x00002557
		public ushort Cooldown
		{
			get
			{
				return this.Buff模板.技能Cooldown;
			}
		}

		
		// (get) Token: 0x06000438 RID: 1080 RVA: 0x00004364 File Offset: 0x00002564
		public int 处理延迟
		{
			get
			{
				return this.Buff模板.Buff处理延迟;
			}
		}

		
		// (get) Token: 0x06000439 RID: 1081 RVA: 0x00004371 File Offset: 0x00002571
		public int 处理间隔
		{
			get
			{
				return this.Buff模板.Buff处理间隔;
			}
		}

		
		// (get) Token: 0x0600043A RID: 1082 RVA: 0x0000437E File Offset: 0x0000257E
		public byte 最大层数
		{
			get
			{
				return this.Buff模板.Buff最大层数;
			}
		}

		
		// (get) Token: 0x0600043B RID: 1083 RVA: 0x0000438B File Offset: 0x0000258B
		public ushort Buff分组
		{
			get
			{
				if (this.Buff模板.分组编号 == 0)
				{
					return this.Buff编号.V;
				}
				return this.Buff模板.分组编号;
			}
		}

		
		// (get) Token: 0x0600043C RID: 1084 RVA: 0x000043B1 File Offset: 0x000025B1
		public ushort[] 依存列表
		{
			get
			{
				return this.Buff模板.依存Buff列表;
			}
		}

		
		// (get) Token: 0x0600043D RID: 1085 RVA: 0x000043BE File Offset: 0x000025BE
		public Dictionary<GameObjectProperties, int> 属性加成
		{
			get
			{
				if ((this.Buff效果 & Buff效果类型.属性增减) != Buff效果类型.技能标志)
				{
					return this.Buff模板.基础属性增减[(int)this.Buff等级.V];
				}
				return null;
			}
		}

		
		public MapObject Buff来源;

		
		public readonly DataMonitor<ushort> Buff编号;

		
		public readonly DataMonitor<TimeSpan> 持续时间;

		
		public readonly DataMonitor<TimeSpan> 剩余时间;

		
		public readonly DataMonitor<TimeSpan> 处理计时;

		
		public readonly DataMonitor<byte> 当前层数;

		
		public readonly DataMonitor<byte> Buff等级;

		
		public readonly DataMonitor<int> 伤害基数;
	}
}
