using System;
using System.Collections.Generic;
using System.Drawing;
using GameServer.Data;
using GameServer.Templates;

namespace GameServer.Maps
{
	
	public sealed class ItemObject : MapObject
	{
		
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

		
		// (get) Token: 0x0600082E RID: 2094 RVA: 0x00006B58 File Offset: 0x00004D58
		public override int 处理间隔
		{
			get
			{
				return 100;
			}
		}

		
		// (get) Token: 0x0600082F RID: 2095 RVA: 0x00002855 File Offset: 0x00000A55
		public override bool 对象死亡
		{
			get
			{
				return false;
			}
		}

		
		// (get) Token: 0x06000830 RID: 2096 RVA: 0x00002855 File Offset: 0x00000A55
		public override bool 阻塞网格
		{
			get
			{
				return false;
			}
		}

		
		// (get) Token: 0x06000831 RID: 2097 RVA: 0x00002855 File Offset: 0x00000A55
		public override bool 能被命中
		{
			get
			{
				return false;
			}
		}

		
		// (get) Token: 0x06000832 RID: 2098 RVA: 0x00006B5C File Offset: 0x00004D5C
		public override GameObjectType 对象类型
		{
			get
			{
				return GameObjectType.物品;
			}
		}

		
		// (get) Token: 0x06000833 RID: 2099 RVA: 0x00002855 File Offset: 0x00000A55
		public override MonsterSize 对象体型
		{
			get
			{
				return MonsterSize.Single1x1;
			}
		}

		
		// (get) Token: 0x06000834 RID: 2100 RVA: 0x00006B60 File Offset: 0x00004D60
		public PersistentItemType PersistType
		{
			get
			{
				return this.物品模板.PersistType;
			}
		}

		
		// (get) Token: 0x06000835 RID: 2101 RVA: 0x00006B6D File Offset: 0x00004D6D
		public int 默认持久
		{
			get
			{
				return this.物品模板.MaxDura;
			}
		}

		
		// (get) Token: 0x06000836 RID: 2102 RVA: 0x00006B7A File Offset: 0x00004D7A
		public int Id
		{
			get
			{
				GameItems 游戏物品 = this.物品模板;
				if (游戏物品 == null)
				{
					return 0;
				}
				return 游戏物品.Id;
			}
		}

		
		// (get) Token: 0x06000837 RID: 2103 RVA: 0x00006B8D File Offset: 0x00004D8D
		public int Weight
		{
			get
			{
				if (this.物品模板.PersistType != PersistentItemType.堆叠)
				{
					return this.物品模板.Weight;
				}
				return this.物品模板.Weight * this.堆叠数量;
			}
		}

		
		// (get) Token: 0x06000838 RID: 2104 RVA: 0x00006BBB File Offset: 0x00004DBB
		public bool 允许堆叠
		{
			get
			{
				return this.物品模板.PersistType == PersistentItemType.堆叠;
			}
		}

		
		public ItemObject(GameItems 物品模板, ItemData ItemData, MapInstance 掉落地图, Point 掉落坐标, HashSet<CharacterData> 物品归属, int 堆叠数量 = 0, bool 物品绑定 = false)
		{
			
			
			this.物品归属 = 物品归属;
			this.物品模板 = 物品模板;
			this.ItemData = ItemData;
			this.当前地图 = 掉落地图;
			this.ItemData = ItemData;
			this.堆叠数量 = 堆叠数量;
			this.物品绑定 = (物品模板.IsBound || 物品绑定);
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
						this.消失时间 = MainProcess.CurrentTime.AddMinutes((double)Config.物品清理时间);
						this.归属时间 = MainProcess.CurrentTime.AddMinutes((double)Config.物品归属时间);
						this.MapId = ++MapGatewayProcess.Id;
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

		
		public override void 处理对象数据()
		{
			if (MainProcess.CurrentTime > this.消失时间)
			{
				this.物品消失处理();
			}
		}

		
		public void 物品消失处理()
		{
			ItemData ItemData = this.ItemData;
			if (ItemData != null)
			{
				ItemData.Delete();
			}
			base.删除对象();
		}

		
		public void 物品转移处理()
		{
			base.删除对象();
		}

		
		public ItemData ItemData;

		
		public GameItems 物品模板;

		
		public int 堆叠数量;

		
		public bool 物品绑定;

		
		public DateTime 消失时间;

		
		public DateTime 归属时间;

		
		public HashSet<CharacterData> 物品归属;
	}
}
