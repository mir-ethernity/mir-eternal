using System;
using System.Collections.Generic;
using GameServer.Templates;

namespace GameServer.Data
{
	// Token: 0x02000252 RID: 594
	public sealed class SkillData : GameData
	{
		// Token: 0x17000048 RID: 72
		// (get) Token: 0x0600043E RID: 1086 RVA: 0x000043E3 File Offset: 0x000025E3
		public int 技能索引
		{
			get
			{
				return (int)(this.技能编号.V * 100 + (ushort)(this.铭文编号 * 10) + (ushort)this.技能等级.V);
			}
		}

		// Token: 0x0600043F RID: 1087 RVA: 0x0000429F File Offset: 0x0000249F
		public SkillData()
		{
			
			
		}

		// Token: 0x06000440 RID: 1088 RVA: 0x00020B0C File Offset: 0x0001ED0C
		public SkillData(ushort 编号)
		{
			
			
			this.快捷栏位.V = 100;
			this.技能编号.V = 编号;
			this.剩余次数.V = this.技能计数;
			GameDataGateway.SkillData表.AddData(this, true);
		}

		// Token: 0x06000441 RID: 1089 RVA: 0x00004409 File Offset: 0x00002609
		public override string ToString()
		{
			铭文技能 铭文模板 = this.铭文模板;
			if (铭文模板 == null)
			{
				return null;
			}
			return 铭文模板.技能名字;
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x06000442 RID: 1090 RVA: 0x0000441C File Offset: 0x0000261C
		public 铭文技能 铭文模板
		{
			get
			{
				return 铭文技能.DataSheet[this.铭文索引];
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x06000443 RID: 1091 RVA: 0x0000442E File Offset: 0x0000262E
		public bool 自动装配
		{
			get
			{
				return this.铭文模板.被动技能;
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000444 RID: 1092 RVA: 0x00020B5C File Offset: 0x0001ED5C
		public byte 升级等级
		{
			get
			{
				if (this.铭文模板.需要角色等级 == null || this.铭文模板.需要角色等级.Length <= (int)(this.技能等级.V + 1))
				{
					return byte.MaxValue;
				}
				if (this.铭文模板.需要角色等级[(int)this.技能等级.V] == 0)
				{
					return byte.MaxValue;
				}
				return this.铭文模板.需要角色等级[(int)this.技能等级.V];
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x06000445 RID: 1093 RVA: 0x0000443B File Offset: 0x0000263B
		public byte 技能计数
		{
			get
			{
				return this.铭文模板.技能计数;
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x06000446 RID: 1094 RVA: 0x00004448 File Offset: 0x00002648
		public ushort 计数周期
		{
			get
			{
				return this.铭文模板.计数周期;
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x06000447 RID: 1095 RVA: 0x00020BD0 File Offset: 0x0001EDD0
		public ushort 升级经验
		{
			get
			{
				if (this.铭文模板.需要技能经验 != null && this.铭文模板.需要技能经验.Length > (int)this.技能等级.V)
				{
					return this.铭文模板.需要技能经验[(int)this.技能等级.V];
				}
				return 0;
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x06000448 RID: 1096 RVA: 0x00004455 File Offset: 0x00002655
		public ushort 铭文索引
		{
			get
			{
				return (ushort)(this.技能编号.V * 10 + (ushort)this.铭文编号);
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x06000449 RID: 1097 RVA: 0x0000446D File Offset: 0x0000266D
		public int 战力加成
		{
			get
			{
				return this.铭文模板.技能战力加成[(int)this.技能等级.V];
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x0600044A RID: 1098 RVA: 0x00004486 File Offset: 0x00002686
		public List<ushort> 技能Buff
		{
			get
			{
				return this.铭文模板.铭文附带Buff;
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x0600044B RID: 1099 RVA: 0x00004493 File Offset: 0x00002693
		public List<ushort> 被动技能
		{
			get
			{
				return this.铭文模板.被动技能列表;
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x0600044C RID: 1100 RVA: 0x00020C20 File Offset: 0x0001EE20
		public Dictionary<GameObjectProperties, int> 属性加成
		{
			get
			{
				if (this.铭文模板.属性加成 != null && this.铭文模板.属性加成.Length > (int)this.技能等级.V)
				{
					return this.铭文模板.属性加成[(int)this.技能等级.V];
				}
				return null;
			}
		}

		// Token: 0x040007DA RID: 2010
		public byte 铭文编号;

		// Token: 0x040007DB RID: 2011
		public DateTime 计数时间;

		// Token: 0x040007DC RID: 2012
		public readonly DataMonitor<ushort> 技能编号;

		// Token: 0x040007DD RID: 2013
		public readonly DataMonitor<ushort> 技能经验;

		// Token: 0x040007DE RID: 2014
		public readonly DataMonitor<byte> 技能等级;

		// Token: 0x040007DF RID: 2015
		public readonly DataMonitor<byte> 快捷栏位;

		// Token: 0x040007E0 RID: 2016
		public readonly DataMonitor<byte> 剩余次数;
	}
}
