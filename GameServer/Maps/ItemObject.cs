using System;
using System.Collections.Generic;
using System.Drawing;
using GameServer.Data;
using GameServer.Templates;

namespace GameServer.Maps
{
	// Token: 0x020002DE RID: 734
	public sealed class ItemObject : MapObject
	{
		// Token: 0x1700013E RID: 318
		// (get) Token: 0x0600082C RID: 2092 RVA: 0x00006167 File Offset: 0x00004367
		// (set) Token: 0x0600082D RID: 2093 RVA: 0x0000616F File Offset: 0x0000436F
		public override MapInstance 当前地图
		{
			get
			{
				return base.当前地图;
			}
			set
			{
				if (this.当前地图 != value)
				{
					MapInstance 当前地图 = base.当前地图;
					if (当前地图 != null)
					{
						当前地图.移除对象(this);
					}
					base.当前地图 = value;
					base.当前地图.添加对象(this);
				}
			}
		}

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x0600082E RID: 2094 RVA: 0x00006B58 File Offset: 0x00004D58
		public override int 处理间隔
		{
			get
			{
				return 100;
			}
		}

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x0600082F RID: 2095 RVA: 0x00002855 File Offset: 0x00000A55
		public override bool 对象死亡
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x06000830 RID: 2096 RVA: 0x00002855 File Offset: 0x00000A55
		public override bool 阻塞网格
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x06000831 RID: 2097 RVA: 0x00002855 File Offset: 0x00000A55
		public override bool 能被命中
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x06000832 RID: 2098 RVA: 0x00006B5C File Offset: 0x00004D5C
		public override GameObjectType 对象类型
		{
			get
			{
				return GameObjectType.物品;
			}
		}

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x06000833 RID: 2099 RVA: 0x00002855 File Offset: 0x00000A55
		public override 技能范围类型 对象体型
		{
			get
			{
				return 技能范围类型.单体1x1;
			}
		}

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x06000834 RID: 2100 RVA: 0x00006B60 File Offset: 0x00004D60
		public PersistentItemType 持久类型
		{
			get
			{
				return this.物品模板.持久类型;
			}
		}

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x06000835 RID: 2101 RVA: 0x00006B6D File Offset: 0x00004D6D
		public int 默认持久
		{
			get
			{
				return this.物品模板.物品持久;
			}
		}

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x06000836 RID: 2102 RVA: 0x00006B7A File Offset: 0x00004D7A
		public int 物品编号
		{
			get
			{
				游戏物品 游戏物品 = this.物品模板;
				if (游戏物品 == null)
				{
					return 0;
				}
				return 游戏物品.物品编号;
			}
		}

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x06000837 RID: 2103 RVA: 0x00006B8D File Offset: 0x00004D8D
		public int 物品重量
		{
			get
			{
				if (this.物品模板.持久类型 != PersistentItemType.堆叠)
				{
					return this.物品模板.物品重量;
				}
				return this.物品模板.物品重量 * this.堆叠数量;
			}
		}

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x06000838 RID: 2104 RVA: 0x00006BBB File Offset: 0x00004DBB
		public bool 允许堆叠
		{
			get
			{
				return this.物品模板.持久类型 == PersistentItemType.堆叠;
			}
		}

		// Token: 0x06000839 RID: 2105 RVA: 0x0004169C File Offset: 0x0003F89C
		public ItemObject(游戏物品 物品模板, ItemData ItemData, MapInstance 掉落地图, Point 掉落坐标, HashSet<CharacterData> 物品归属, int 堆叠数量 = 0, bool 物品绑定 = false)
		{
			
			
			this.物品归属 = 物品归属;
			this.物品模板 = 物品模板;
			this.ItemData = ItemData;
			this.当前地图 = 掉落地图;
			this.ItemData = ItemData;
			this.堆叠数量 = 堆叠数量;
			this.物品绑定 = (物品模板.是否绑定 || 物品绑定);
			Point 当前坐标 = 掉落坐标;
			int num = int.MaxValue;
			for (int i = 0; i <= 120; i++)
			{
				int num2 = 0;
				Point point = ComputingClass.螺旋坐标(掉落坐标, i);
				if (!掉落地图.地形阻塞(point))
				{
					foreach (MapObject MapObject in 掉落地图[point])
					{
						if (!MapObject.对象死亡)
						{
							GameObjectType 对象类型 = MapObject.对象类型;
							switch (对象类型)
							{
							case GameObjectType.玩家:
								num2 += 10000;
								continue;
							case GameObjectType.宠物:
							case GameObjectType.怪物:
								break;
							case (GameObjectType)3:
								continue;
							default:
								if (对象类型 != GameObjectType.Npcc)
								{
									if (对象类型 != GameObjectType.物品)
									{
										continue;
									}
									num2 += 100;
									continue;
								}
								break;
							}
							num2 += 1000;
						}
					}
					if (num2 == 0)
					{
						当前坐标 = point;
						IL_111:
						this.当前坐标 = 当前坐标;
						this.消失时间 = MainProcess.当前时间.AddMinutes((double)CustomClass.物品清理时间);
						this.归属时间 = MainProcess.当前时间.AddMinutes((double)CustomClass.物品归属时间);
						this.地图编号 = ++MapGatewayProcess.物品编号;
						base.绑定网格();
						base.更新邻居时处理();
						MapGatewayProcess.添加MapObject(this);
						this.次要对象 = true;
						MapGatewayProcess.添加次要对象(this);
						return;
					}
					if (num2 < num)
					{
						当前坐标 = point;
						num = num2;
					}
				}
			}
			//goto IL_111;
		}

		// Token: 0x0600083A RID: 2106 RVA: 0x00006BCB File Offset: 0x00004DCB
		public override void 处理对象数据()
		{
			if (MainProcess.当前时间 > this.消失时间)
			{
				this.物品消失处理();
			}
		}

		// Token: 0x0600083B RID: 2107 RVA: 0x00006BE5 File Offset: 0x00004DE5
		public void 物品消失处理()
		{
			ItemData ItemData = this.ItemData;
			if (ItemData != null)
			{
				ItemData.删除数据();
			}
			base.删除对象();
		}

		// Token: 0x0600083C RID: 2108 RVA: 0x00006B50 File Offset: 0x00004D50
		public void 物品转移处理()
		{
			base.删除对象();
		}

		// Token: 0x04000CF7 RID: 3319
		public ItemData ItemData;

		// Token: 0x04000CF8 RID: 3320
		public 游戏物品 物品模板;

		// Token: 0x04000CF9 RID: 3321
		public int 堆叠数量;

		// Token: 0x04000CFA RID: 3322
		public bool 物品绑定;

		// Token: 0x04000CFB RID: 3323
		public DateTime 消失时间;

		// Token: 0x04000CFC RID: 3324
		public DateTime 归属时间;

		// Token: 0x04000CFD RID: 3325
		public HashSet<CharacterData> 物品归属;
	}
}
