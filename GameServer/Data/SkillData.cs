using System;
using System.Collections.Generic;
using GameServer.Templates;

namespace GameServer.Data
{
	
	public sealed class SkillData : GameData
	{
		
		// (get) Token: 0x0600043E RID: 1086 RVA: 0x000043E3 File Offset: 0x000025E3
		public int 技能索引
		{
			get
			{
				return (int)(this.SkillId.V * 100 + (ushort)(this.Id * 10) + (ushort)this.SkillLevel.V);
			}
		}

		
		public SkillData()
		{
			
			
		}

		
		public SkillData(ushort 编号)
		{
			
			
			this.ShorcutField.V = 100;
			this.SkillId.V = 编号;
			this.RemainingTimeLeft.V = this.SkillCount;
			GameDataGateway.SkillData表.AddData(this, true);
		}

		
		public override string ToString()
		{
			InscriptionSkill 铭文模板 = this.铭文模板;
			if (铭文模板 == null)
			{
				return null;
			}
			return 铭文模板.SkillName;
		}

		
		// (get) Token: 0x06000442 RID: 1090 RVA: 0x0000441C File Offset: 0x0000261C
		public InscriptionSkill 铭文模板
		{
			get
			{
				return InscriptionSkill.DataSheet[this.Index];
			}
		}

		
		// (get) Token: 0x06000443 RID: 1091 RVA: 0x0000442E File Offset: 0x0000262E
		public bool 自动装配
		{
			get
			{
				return this.铭文模板.PassiveSkill;
			}
		}

		
		// (get) Token: 0x06000444 RID: 1092 RVA: 0x00020B5C File Offset: 0x0001ED5C
		public byte 升级等级
		{
			get
			{
				if (this.铭文模板.MinPlayerLevel == null || this.铭文模板.MinPlayerLevel.Length <= (int)(this.SkillLevel.V + 1))
				{
					return byte.MaxValue;
				}
				if (this.铭文模板.MinPlayerLevel[(int)this.SkillLevel.V] == 0)
				{
					return byte.MaxValue;
				}
				return this.铭文模板.MinPlayerLevel[(int)this.SkillLevel.V];
			}
		}

		
		// (get) Token: 0x06000445 RID: 1093 RVA: 0x0000443B File Offset: 0x0000263B
		public byte SkillCount
		{
			get
			{
				return this.铭文模板.SkillCount;
			}
		}

		
		// (get) Token: 0x06000446 RID: 1094 RVA: 0x00004448 File Offset: 0x00002648
		public ushort PeriodCount
		{
			get
			{
				return this.铭文模板.PeriodCount;
			}
		}

		
		// (get) Token: 0x06000447 RID: 1095 RVA: 0x00020BD0 File Offset: 0x0001EDD0
		public ushort 升级经验
		{
			get
			{
				if (this.铭文模板.MinSkillExp != null && this.铭文模板.MinSkillExp.Length > (int)this.SkillLevel.V)
				{
					return this.铭文模板.MinSkillExp[(int)this.SkillLevel.V];
				}
				return 0;
			}
		}

		
		// (get) Token: 0x06000448 RID: 1096 RVA: 0x00004455 File Offset: 0x00002655
		public ushort Index
		{
			get
			{
				return (ushort)(this.SkillId.V * 10 + (ushort)this.Id);
			}
		}

		
		// (get) Token: 0x06000449 RID: 1097 RVA: 0x0000446D File Offset: 0x0000266D
		public int CombatBonus
		{
			get
			{
				return this.铭文模板.SkillCombatBonus[(int)this.SkillLevel.V];
			}
		}

		
		// (get) Token: 0x0600044A RID: 1098 RVA: 0x00004486 File Offset: 0x00002686
		public List<ushort> 技能Buff
		{
			get
			{
				return this.铭文模板.ComesWithBuff;
			}
		}

		
		// (get) Token: 0x0600044B RID: 1099 RVA: 0x00004493 File Offset: 0x00002693
		public List<ushort> PassiveSkill
		{
			get
			{
				return this.铭文模板.PassiveSkills;
			}
		}

		
		// (get) Token: 0x0600044C RID: 1100 RVA: 0x00020C20 File Offset: 0x0001EE20
		public Dictionary<GameObjectStats, int> Stat加成
		{
			get
			{
				if (this.铭文模板.StatsBonusDictionary != null && this.铭文模板.StatsBonusDictionary.Length > (int)this.SkillLevel.V)
				{
					return this.铭文模板.StatsBonusDictionary[(int)this.SkillLevel.V];
				}
				return null;
			}
		}

		
		public byte Id;

		
		public DateTime 计数时间;

		
		public readonly DataMonitor<ushort> SkillId;

		
		public readonly DataMonitor<ushort> SkillExp;

		
		public readonly DataMonitor<byte> SkillLevel;

		
		public readonly DataMonitor<byte> ShorcutField;

		
		public readonly DataMonitor<byte> RemainingTimeLeft;
	}
}
