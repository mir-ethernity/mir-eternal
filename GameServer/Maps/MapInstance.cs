using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using GameServer.Templates;
using GameServer.Networking;

namespace GameServer.Maps
{
	
	public sealed class MapInstance
	{
		
		// (get) Token: 0x0600073F RID: 1855 RVA: 0x0000637C File Offset: 0x0000457C
		public byte 地图状态
		{
			get
			{
				if (this.玩家列表.Count < 200)
				{
					return 1;
				}
				if (this.玩家列表.Count < 500)
				{
					return 2;
				}
				return 3;
			}
		}

		
		// (get) Token: 0x06000740 RID: 1856 RVA: 0x000063A7 File Offset: 0x000045A7
		public int MapId
		{
			get
			{
				return (int)this.地图模板.MapId;
			}
		}

		
		// (get) Token: 0x06000741 RID: 1857 RVA: 0x000063B4 File Offset: 0x000045B4
		public byte MinLevel
		{
			get
			{
				return this.地图模板.MinLevel;
			}
		}

		
		// (get) Token: 0x06000742 RID: 1858 RVA: 0x00002865 File Offset: 0x00000A65
		public byte LimitInstances
		{
			get
			{
				return 1;
			}
		}

		
		// (get) Token: 0x06000743 RID: 1859 RVA: 0x000063C1 File Offset: 0x000045C1
		public bool NoReconnect
		{
			get
			{
				return this.地图模板.NoReconnect;
			}
		}

		
		// (get) Token: 0x06000744 RID: 1860 RVA: 0x000063CE File Offset: 0x000045CE
		public byte NoReconnectMapId
		{
			get
			{
				return this.地图模板.NoReconnectMapId;
			}
		}

		
		// (get) Token: 0x06000745 RID: 1861 RVA: 0x000063DB File Offset: 0x000045DB
		public bool CopyMap
		{
			get
			{
				return this.地图模板.CopyMap;
			}
		}

		
		// (get) Token: 0x06000746 RID: 1862 RVA: 0x000063E8 File Offset: 0x000045E8
		public Point 地图起点
		{
			get
			{
				return this.地形数据.StartPoint;
			}
		}

		
		// (get) Token: 0x06000747 RID: 1863 RVA: 0x000063F5 File Offset: 0x000045F5
		public Point 地图终点
		{
			get
			{
				return this.地形数据.EndPoint;
			}
		}

		
		// (get) Token: 0x06000748 RID: 1864 RVA: 0x00006402 File Offset: 0x00004602
		public Point 地图大小
		{
			get
			{
				return this.地形数据.MapSize;
			}
		}

		
		public MapInstance(GameMap 地图模板, int 路线编号 = 1)
		{
			
			this.地图区域 = new HashSet<MapAreas>();
			this.怪物区域 = new HashSet<MonsterSpawns>();
			this.守卫区域 = new HashSet<MapGuards>();
			this.玩家列表 = new HashSet<PlayerObject>();
			this.宠物列表 = new HashSet<PetObject>();
			this.物品列表 = new HashSet<ItemObject>();
			this.对象列表 = new HashSet<MapObject>();
			this.法阵列表 = new Dictionary<byte, TeleportGates>();
			
			this.地图模板 = 地图模板;
			this.路线编号 = 路线编号;
		}

		
		public void 处理数据()
		{
			if (this.MapId == 80)
			{
				if (this.玩家列表.Count == 0)
				{
					this.副本节点 = 110;
					return;
				}
				if (this.副本节点 <= 5)
				{
					if (MainProcess.CurrentTime > this.节点计时)
					{
						this.地图公告(string.Format("The monster will be refreshed in {0} seconds, please be ready", (int)(30 - this.副本节点 * 5)));
						this.副本节点 += 1;
						this.节点计时 = MainProcess.CurrentTime.AddSeconds(5.0);
						return;
					}
				}
				else if ((int)this.副本节点 <= 5 + this.怪物波数.Count)
				{
					if (this.副本守卫.对象死亡)
					{
						this.副本节点 = 100;
						this.节点计时 = MainProcess.CurrentTime;
						return;
					}
					if (MainProcess.CurrentTime > this.节点计时)
					{
						int num = (int)(this.副本节点 - 6);
						MonsterSpawns 怪物刷新 = this.怪物波数[num];
						int num2 = this.刷怪记录 >> 16;
						int num3 = this.刷怪记录 & 65535;
						MonsterSpawnInfo 刷新信息 = 怪物刷新.Spawns[num2];
						if (this.刷怪记录 == 0)
						{
							this.地图公告(string.Format("The {0}th wave of monsters has appeared, please take care of your defences", num + 1));
						}
						Monsters 对应模板;
						if (Monsters.DataSheet.TryGetValue(刷新信息.MonsterName, out 对应模板))
						{
							new MonsterObject(对应模板, this, int.MaxValue, new Point[]
							{
								new Point(995, 283)
							}, true, true).存活时间 = MainProcess.CurrentTime.AddMinutes(30.0);
						}
						if (++num3 >= 刷新信息.SpawnCount)
						{
							num2++;
							num3 = 0;
						}
						if (num2 >= 怪物刷新.Spawns.Length)
						{
							this.副本节点 += 1;
							this.刷怪记录 = 0;
							this.节点计时 = MainProcess.CurrentTime.AddSeconds(60.0);
							return;
						}
						this.刷怪记录 = (num2 << 16) + num3;
						this.节点计时 = MainProcess.CurrentTime.AddSeconds(2.0);
						return;
					}
				}
				else if ((int)this.副本节点 == 6 + this.怪物波数.Count)
				{
					if (this.副本守卫.对象死亡)
					{
						this.副本节点 = 100;
						this.节点计时 = MainProcess.CurrentTime;
						return;
					}
					if (this.存活怪物总数 == 0U)
					{
						this.地图公告("All monsters have been repulsed, the hall will close in 30 seconds");
						this.副本节点 = 110;
						this.节点计时 = MainProcess.CurrentTime.AddSeconds(30.0);
						return;
					}
				}
				else if (this.副本节点 <= 109)
				{
					if (MainProcess.CurrentTime > this.节点计时)
					{
						this.地图公告("The guards are dead, the hall will soon be closed");
						this.副本节点 += 2;
						this.节点计时 = MainProcess.CurrentTime.AddSeconds(2.0);
						return;
					}
				}
				else if (this.副本节点 >= 110 && MainProcess.CurrentTime > this.节点计时)
				{
					foreach (PlayerObject PlayerObject in this.玩家列表.ToList<PlayerObject>())
					{
						if (PlayerObject.对象死亡)
						{
							PlayerObject.玩家请求复活();
						}
						else
						{
							PlayerObject.玩家切换地图(MapGatewayProcess.分配地图(PlayerObject.重生地图), AreaType.复活区域, default(Point));
						}
					}
					foreach (PetObject PetObject in this.宠物列表.ToList<PetObject>())
					{
						if (PetObject.对象死亡)
						{
							PetObject.删除对象();
						}
						else
						{
							PetObject.宠物召回处理();
						}
					}
					foreach (ItemObject ItemObject in this.物品列表)
					{
						ItemObject.物品消失处理();
					}
					foreach (MapObject MapObject in this.对象列表)
					{
						MapObject.删除对象();
					}
					this.副本关闭 = true;
				}
			}
		}

		
		public void 添加对象(MapObject 对象)
		{
			GameObjectType 对象类型 = 对象.对象类型;
			if (对象类型 == GameObjectType.玩家)
			{
				this.玩家列表.Add(对象 as PlayerObject);
				return;
			}
			if (对象类型 == GameObjectType.宠物)
			{
				this.宠物列表.Add(对象 as PetObject);
				return;
			}
			if (对象类型 != GameObjectType.物品)
			{
				this.对象列表.Add(对象);
				return;
			}
			this.物品列表.Add(对象 as ItemObject);
		}

		
		public void 移除对象(MapObject 对象)
		{
			GameObjectType 对象类型 = 对象.对象类型;
			if (对象类型 == GameObjectType.玩家)
			{
				this.玩家列表.Remove(对象 as PlayerObject);
				return;
			}
			if (对象类型 == GameObjectType.宠物)
			{
				this.宠物列表.Remove(对象 as PetObject);
				return;
			}
			if (对象类型 != GameObjectType.物品)
			{
				this.对象列表.Remove(对象);
				return;
			}
			this.物品列表.Remove(对象 as ItemObject);
		}

		
		public void 地图公告(string 内容)
		{
			if (this.玩家列表.Count == 0)
			{
				return;
			}
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write(0);
					binaryWriter.Write(2415919107U);
					binaryWriter.Write(3);
					binaryWriter.Write(0);
					binaryWriter.Write(Encoding.UTF8.GetBytes(内容 + "\0"));
					byte[] 字节描述 = memoryStream.ToArray();
					foreach (PlayerObject PlayerObject in this.玩家列表)
					{
						SConnection 网络连接 = PlayerObject.GetCurrentConnection;
						if (网络连接 != null)
						{
							网络连接.发送封包(new ReceiveChatMessagesPacket
							{
								字节描述 = 字节描述
							});
						}
					}
				}
			}
		}

		
		public override string ToString()
		{
			return this.地图模板.ToString();
		}

		
		public HashSet<MapObject> this[Point 坐标]
		{
			get
			{
				if (this.坐标越界(坐标))
				{
					return new HashSet<MapObject>();
				}
				if (this.MapObject[坐标.X - this.地图起点.X, 坐标.Y - this.地图起点.Y] == null)
				{
					return this.MapObject[坐标.X - this.地图起点.X, 坐标.Y - this.地图起点.Y] = new HashSet<MapObject>();
				}
				return this.MapObject[坐标.X - this.地图起点.X, 坐标.Y - this.地图起点.Y];
			}
		}

		
		public Point 随机坐标(AreaType 区域)
		{
			if (区域 == AreaType.复活区域)
			{
				return this.复活区域.RandomCoords;
			}
			if (区域 == AreaType.红名区域)
			{
				return this.红名区域.RandomCoords;
			}
			if (区域 == AreaType.传送区域)
			{
				return this.传送区域.RandomCoords;
			}
			if (区域 != AreaType.随机区域)
			{
				return default(Point);
			}
			MapAreas 地图区域 = this.地图区域.FirstOrDefault((MapAreas O) => O.AreaType == AreaType.随机区域);
			if (地图区域 == null)
			{
				return default(Point);
			}
			return 地图区域.RandomCoords;
		}

		
		public Point 随机传送(Point 坐标)
		{
			foreach (MapAreas 地图区域 in this.地图区域)
			{
				if (地图区域.RangeCoords.Contains(坐标) && 地图区域.AreaType == AreaType.随机区域)
				{
					return 地图区域.RandomCoords;
				}
			}
			return default(Point);
		}

		
		public bool 坐标越界(Point 坐标)
		{
			return 坐标.X < this.地图起点.X || 坐标.Y < this.地图起点.Y || 坐标.X >= this.地图终点.X || 坐标.Y >= this.地图终点.Y;
		}

		
		public bool 空间阻塞(Point 坐标)
		{
			if (this.安全区内(坐标))
			{
				return false;
			}
			using (HashSet<MapObject>.Enumerator enumerator = this[坐标].GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.阻塞网格)
					{
						return true;
					}
				}
			}
			return false;
		}

		
		public int 阻塞数量(Point 坐标)
		{
			int num = 0;
			using (HashSet<MapObject>.Enumerator enumerator = this[坐标].GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.阻塞网格)
					{
						num++;
					}
				}
			}
			return num;
		}

		
		public bool 地形阻塞(Point 坐标)
		{
			return this.坐标越界(坐标) || (this.地形数据[坐标] & 268435456U) != 268435456U;
		}

		
		public bool 能否通行(Point 坐标)
		{
			return !this.地形阻塞(坐标) && !this.空间阻塞(坐标);
		}

		
		public ushort 地形高度(Point 坐标)
		{
			if (this.坐标越界(坐标))
			{
				return 0;
			}
			return (ushort)((this.地形数据[坐标] & 65535U) - 30U);
		}

		
		public bool 地形遮挡(Point 起点, Point 终点)
		{
			int num = ComputingClass.GridDistance(起点, 终点);
			for (int i = 1; i < num; i++)
			{
				if (this.地形阻塞(ComputingClass.前方坐标(起点, 终点, i)))
				{
					return true;
				}
			}
			return false;
		}

		
		public bool 自由区内(Point 坐标)
		{
			return !this.坐标越界(坐标) && (this.地形数据[坐标] & 131072U) == 131072U;
		}

		
		public bool 安全区内(Point 坐标)
		{
			return !this.坐标越界(坐标) && ((this.地形数据[坐标] & 262144U) == 262144U || (this.地形数据[坐标] & 1048576U) == 1048576U);
		}

		
		public bool 摆摊区内(Point 坐标)
		{
			return !this.坐标越界(坐标) && (this.地形数据[坐标] & 1048576U) == 1048576U;
		}

		
		public bool 掉落装备(Point 坐标, bool 红名)
		{
			return (MapGatewayProcess.沙城节点 < 2 || (this.MapId != 152 && this.MapId != 178)) && !this.坐标越界(坐标) && ((this.地形数据[坐标] & 4194304U) == 4194304U || ((this.地形数据[坐标] & 8388608U) == 8388608U && 红名));
		}

		
		public readonly int 路线编号;

		
		public readonly GameMap 地图模板;

		
		public uint 固定怪物总数;

		
		public uint 存活怪物总数;

		
		public uint 怪物复活次数;

		
		public long 怪物掉落次数;

		
		public long 金币掉落总数;

		
		public bool 副本关闭;

		
		public byte 副本节点;

		
		public GuardInstance 副本守卫;

		
		public DateTime 节点计时;

		
		public int 刷怪记录;

		
		public List<MonsterSpawns> 怪物波数;

		
		public HashSet<MapObject>[,] MapObject;

		
		public Terrains 地形数据;

		
		public MapAreas 复活区域;

		
		public MapAreas 红名区域;

		
		public MapAreas 传送区域;

		
		public HashSet<MapAreas> 地图区域;

		
		public HashSet<MonsterSpawns> 怪物区域;

		
		public HashSet<MapGuards> 守卫区域;

		
		public HashSet<PlayerObject> 玩家列表;

		
		public HashSet<PetObject> 宠物列表;

		
		public HashSet<ItemObject> 物品列表;

		
		public HashSet<MapObject> 对象列表;

		
		public Dictionary<byte, TeleportGates> 法阵列表;
	}
}
