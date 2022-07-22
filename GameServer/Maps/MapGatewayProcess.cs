using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GameServer.Data;
using GameServer.Templates;
using GameServer.Networking;

namespace GameServer.Maps
{
	// Token: 0x020002D1 RID: 721
	public static class MapGatewayProcess
	{
		// Token: 0x06000728 RID: 1832 RVA: 0x00036B38 File Offset: 0x00034D38
		private static void 沙城处理()
		{
			if (MainProcess.当前时间 < MapGatewayProcess.沙城处理计时)
			{
				return;
			}
			MapGatewayProcess.沙城处理计时 = MainProcess.当前时间.AddMilliseconds(50.0);
			if (MapGatewayProcess.沙城地图 == null)
			{
				游戏Buff 游戏Buff;
				游戏怪物 对应模板;
				游戏怪物 对应模板2;
				if (MapGatewayProcess.MapInstance表.TryGetValue(2433, out MapGatewayProcess.沙城地图) && 游戏Buff.DataSheet.TryGetValue(22300, out 游戏Buff) && 游戏怪物.DataSheet.TryGetValue("沙巴克城门", out 对应模板) && 游戏怪物.DataSheet.TryGetValue("沙巴克宫门", out 对应模板2))
				{
					if ((MapGatewayProcess.皇宫随机区域 = MapGatewayProcess.沙城地图.地图区域.FirstOrDefault((地图区域 O) => O.区域名字 == "沙巴克-皇宫随机区域")) != null)
					{
						if ((MapGatewayProcess.外城复活区域 = MapGatewayProcess.沙城地图.地图区域.FirstOrDefault((地图区域 O) => O.区域名字 == "沙巴克-外城复活区域")) != null)
						{
							if ((MapGatewayProcess.内城复活区域 = MapGatewayProcess.沙城地图.地图区域.FirstOrDefault((地图区域 O) => O.区域名字 == "沙巴克-内城复活区域")) != null)
							{
								if ((MapGatewayProcess.守方传送区域 = MapGatewayProcess.沙城地图.地图区域.FirstOrDefault((地图区域 O) => O.区域名字 == "沙巴克-守方传送区域")) != null)
								{
									MapGatewayProcess.沙城城门 = new MonsterObject(对应模板, MapGatewayProcess.沙城地图, int.MaxValue, new Point[]
									{
										MapGatewayProcess.沙城城门坐标
									}, true, true)
									{
										当前方向 = GameDirection.右上,
										存活时间 = DateTime.MaxValue
									};
									MapGatewayProcess.上方宫门 = new MonsterObject(对应模板2, MapGatewayProcess.沙城地图, int.MaxValue, new Point[]
									{
										MapGatewayProcess.皇宫上门坐标
									}, true, true)
									{
										当前方向 = GameDirection.右下,
										存活时间 = DateTime.MaxValue
									};
									MapGatewayProcess.下方宫门 = new MonsterObject(对应模板2, MapGatewayProcess.沙城地图, int.MaxValue, new Point[]
									{
										MapGatewayProcess.皇宫下门坐标
									}, true, true)
									{
										当前方向 = GameDirection.右下,
										存活时间 = DateTime.MaxValue
									};
									MapGatewayProcess.左方宫门 = new MonsterObject(对应模板2, MapGatewayProcess.沙城地图, int.MaxValue, new Point[]
									{
										MapGatewayProcess.皇宫左门坐标
									}, true, true)
									{
										当前方向 = GameDirection.左下,
										存活时间 = DateTime.MaxValue
									};
									MapGatewayProcess.沙城城门.添加Buff时处理(游戏Buff.Buff编号, MapGatewayProcess.沙城城门);
									MapGatewayProcess.上方宫门.添加Buff时处理(游戏Buff.Buff编号, MapGatewayProcess.上方宫门);
									MapGatewayProcess.下方宫门.添加Buff时处理(游戏Buff.Buff编号, MapGatewayProcess.下方宫门);
									MapGatewayProcess.左方宫门.添加Buff时处理(游戏Buff.Buff编号, MapGatewayProcess.左方宫门);
									goto IL_2D4;
								}
							}
						}
					}
				}
				MapGatewayProcess.沙城地图 = null;
				return;
			}
			IL_2D4:
			foreach (MapObject MapObject in MapGatewayProcess.沙城地图[MapGatewayProcess.皇宫下门坐标].ToList<MapObject>())
			{
				if (!MapObject.对象死亡)
				{
					PlayerObject PlayerObject = MapObject as PlayerObject;
					if (PlayerObject != null && MainProcess.当前时间 > PlayerObject.忙碌时间)
					{
						PlayerObject.玩家切换地图(MapGatewayProcess.沙城地图, 地图区域类型.未知区域, MapGatewayProcess.皇宫下门入口);
					}
				}
			}
			foreach (MapObject MapObject2 in MapGatewayProcess.沙城地图[MapGatewayProcess.皇宫上门坐标].ToList<MapObject>())
			{
				if (!MapObject2.对象死亡)
				{
					PlayerObject PlayerObject2 = MapObject2 as PlayerObject;
					if (PlayerObject2 != null && MainProcess.当前时间 > PlayerObject2.忙碌时间)
					{
						PlayerObject2.玩家切换地图(MapGatewayProcess.沙城地图, 地图区域类型.未知区域, MapGatewayProcess.皇宫上门入口);
					}
				}
			}
			foreach (MapObject MapObject3 in MapGatewayProcess.沙城地图[MapGatewayProcess.皇宫左门坐标].ToList<MapObject>())
			{
				if (!MapObject3.对象死亡)
				{
					PlayerObject PlayerObject3 = MapObject3 as PlayerObject;
					if (PlayerObject3 != null && MainProcess.当前时间 > PlayerObject3.忙碌时间)
					{
						PlayerObject3.玩家切换地图(MapGatewayProcess.沙城地图, 地图区域类型.未知区域, MapGatewayProcess.皇宫左门入口);
					}
				}
			}
			foreach (MapObject MapObject4 in MapGatewayProcess.沙城地图[MapGatewayProcess.皇宫出口点一].ToList<MapObject>())
			{
				if (!MapObject4.对象死亡)
				{
					PlayerObject PlayerObject4 = MapObject4 as PlayerObject;
					if (PlayerObject4 != null && MainProcess.当前时间 > PlayerObject4.忙碌时间)
					{
						PlayerObject4.玩家切换地图(MapGatewayProcess.沙城地图, 地图区域类型.未知区域, MapGatewayProcess.皇宫正门出口);
					}
				}
			}
			foreach (MapObject MapObject5 in MapGatewayProcess.沙城地图[MapGatewayProcess.皇宫出口点二].ToList<MapObject>())
			{
				if (!MapObject5.对象死亡)
				{
					PlayerObject PlayerObject5 = MapObject5 as PlayerObject;
					if (PlayerObject5 != null && MainProcess.当前时间 > PlayerObject5.忙碌时间)
					{
						PlayerObject5.玩家切换地图(MapGatewayProcess.沙城地图, 地图区域类型.未知区域, MapGatewayProcess.皇宫正门出口);
					}
				}
			}
			foreach (MapObject MapObject6 in MapGatewayProcess.沙城地图[MapGatewayProcess.皇宫入口点左].ToList<MapObject>())
			{
				if (!MapObject6.对象死亡)
				{
					PlayerObject PlayerObject6 = MapObject6 as PlayerObject;
					if (PlayerObject6 != null && MainProcess.当前时间 > PlayerObject6.忙碌时间 && PlayerObject6.所属行会 != null && PlayerObject6.所属行会 == SystemData.数据.占领行会.V)
					{
						PlayerObject6.玩家切换地图(MapGatewayProcess.沙城地图, 地图区域类型.未知区域, MapGatewayProcess.皇宫正门入口);
					}
				}
			}
			foreach (MapObject MapObject7 in MapGatewayProcess.沙城地图[MapGatewayProcess.皇宫入口点中].ToList<MapObject>())
			{
				if (!MapObject7.对象死亡)
				{
					PlayerObject PlayerObject7 = MapObject7 as PlayerObject;
					if (PlayerObject7 != null && MainProcess.当前时间 > PlayerObject7.忙碌时间 && PlayerObject7.所属行会 != null && PlayerObject7.所属行会 == SystemData.数据.占领行会.V)
					{
						PlayerObject7.玩家切换地图(MapGatewayProcess.沙城地图, 地图区域类型.未知区域, MapGatewayProcess.皇宫正门入口);
					}
				}
			}
			foreach (MapObject MapObject8 in MapGatewayProcess.沙城地图[MapGatewayProcess.皇宫入口点右].ToList<MapObject>())
			{
				if (!MapObject8.对象死亡)
				{
					PlayerObject PlayerObject8 = MapObject8 as PlayerObject;
					if (PlayerObject8 != null && MainProcess.当前时间 > PlayerObject8.忙碌时间 && PlayerObject8.所属行会 != null && PlayerObject8.所属行会 == SystemData.数据.占领行会.V)
					{
						PlayerObject8.玩家切换地图(MapGatewayProcess.沙城地图, 地图区域类型.未知区域, MapGatewayProcess.皇宫正门入口);
					}
				}
			}
			if (MapGatewayProcess.沙城节点 == 0)
			{
				foreach (KeyValuePair<DateTime, GuildData> keyValuePair in SystemData.数据.申请行会.ToList<KeyValuePair<DateTime, GuildData>>())
				{
					if (keyValuePair.Key.Date < MainProcess.当前时间.Date)
					{
						SystemData.数据.申请行会.Remove(keyValuePair.Key);
					}
				}
				if (SystemData.数据.申请行会.Count == 0)
				{
					return;
				}
				if (MainProcess.当前时间.Hour != 19 || MainProcess.当前时间.Minute != 50)
				{
					return;
				}
				using (IEnumerator<KeyValuePair<DateTime, GuildData>> enumerator3 = SystemData.数据.申请行会.GetEnumerator())
				{
					while (enumerator3.MoveNext())
					{
						KeyValuePair<DateTime, GuildData> keyValuePair2 = enumerator3.Current;
						if (keyValuePair2.Key.Date == MainProcess.当前时间.Date)
						{
							NetworkServiceGateway.发送公告("沙巴克攻城战将在十分钟后开始, 请做好准备", true);
							MapGatewayProcess.沙城节点 += 1;
							break;
						}
					}
					return;
				}
			}
			if (MapGatewayProcess.沙城节点 == 1)
			{
				if (MainProcess.当前时间.Hour == 20)
				{
					foreach (KeyValuePair<DateTime, GuildData> keyValuePair3 in SystemData.数据.申请行会.ToList<KeyValuePair<DateTime, GuildData>>())
					{
						if (keyValuePair3.Key.Date == MainProcess.当前时间.Date)
						{
							MapGatewayProcess.攻城行会.Add(keyValuePair3.Value);
							SystemData.数据.申请行会.Remove(keyValuePair3.Key);
						}
					}
					if (MapGatewayProcess.攻城行会.Count == 0)
					{
						MapGatewayProcess.沙城节点 = 0;
						return;
					}
					MapGatewayProcess.沙城城门.移除Buff时处理(22300);
					MapGatewayProcess.下方宫门.移除Buff时处理(22300);
					MapGatewayProcess.上方宫门.移除Buff时处理(22300);
					MapGatewayProcess.左方宫门.移除Buff时处理(22300);
					foreach (PlayerObject PlayerObject9 in MapGatewayProcess.沙城地图.玩家列表)
					{
						if (PlayerObject9.所属行会 == null || PlayerObject9.所属行会 != SystemData.数据.占领行会.V)
						{
							PlayerObject9.玩家切换地图(MapGatewayProcess.沙城地图, 地图区域类型.未知区域, MapGatewayProcess.外城复活区域.随机坐标);
						}
					}
					MapInstance MapInstance;
					if (MapGatewayProcess.MapInstance表.TryGetValue(2849, out MapInstance))
					{
						foreach (PlayerObject PlayerObject10 in MapInstance.玩家列表.ToList<PlayerObject>())
						{
							if (PlayerObject10.所属行会 == null || PlayerObject10.所属行会 != SystemData.数据.占领行会.V)
							{
								PlayerObject10.玩家切换地图(PlayerObject10.复活地图, 地图区域类型.复活区域, default(Point));
							}
						}
					}
					if (SystemData.数据.占领行会.V != null)
					{
						GuildData v = SystemData.数据.占领行会.V;
						foreach (GuildData GuildData in MapGatewayProcess.攻城行会)
						{
							if (GuildData.结盟行会.Remove(v))
							{
								v.结盟行会.Remove(GuildData);
								GuildData.发送封包(new 删除外交公告
								{
									外交类型 = 1,
									行会编号 = v.行会编号
								});
								v.发送封包(new 删除外交公告
								{
									外交类型 = 1,
									行会编号 = GuildData.行会编号
								});
							}
							if (!GuildData.敌对行会.ContainsKey(v))
							{
								GuildData.敌对行会.Add(v, MainProcess.当前时间.AddHours(1.0));
								v.敌对行会.Add(GuildData, MainProcess.当前时间.AddHours(1.0));
								GuildData.发送封包(new AddDiplomaticAnnouncementPacket
								{
									外交类型 = 2,
									行会编号 = v.行会编号,
									行会名字 = v.行会名字.V,
									行会等级 = v.行会等级.V,
									行会人数 = (byte)v.行会成员.Count,
									外交时间 = (int)(GuildData.敌对行会[v] - MainProcess.当前时间).TotalSeconds
								});
								v.发送封包(new AddDiplomaticAnnouncementPacket
								{
									外交类型 = 2,
									行会编号 = GuildData.行会编号,
									行会名字 = GuildData.行会名字.V,
									行会等级 = GuildData.行会等级.V,
									行会人数 = (byte)GuildData.行会成员.Count,
									外交时间 = (int)(v.敌对行会[GuildData] - MainProcess.当前时间).TotalSeconds
								});
							}
							if (GuildData.敌对行会[v] < MainProcess.当前时间.AddHours(1.0))
							{
								GuildData.敌对行会[v] = MainProcess.当前时间.AddHours(1.0);
								v.敌对行会[GuildData] = MainProcess.当前时间.AddHours(1.0);
								GuildData.发送封包(new AddDiplomaticAnnouncementPacket
								{
									外交类型 = 2,
									行会编号 = v.行会编号,
									行会名字 = v.行会名字.V,
									行会等级 = v.行会等级.V,
									行会人数 = (byte)v.行会成员.Count,
									外交时间 = (int)(GuildData.敌对行会[v] - MainProcess.当前时间).TotalSeconds
								});
								v.发送封包(new AddDiplomaticAnnouncementPacket
								{
									外交类型 = 2,
									行会编号 = GuildData.行会编号,
									行会名字 = GuildData.行会名字.V,
									行会等级 = GuildData.行会等级.V,
									行会人数 = (byte)GuildData.行会成员.Count,
									外交时间 = (int)(v.敌对行会[GuildData] - MainProcess.当前时间).TotalSeconds
								});
							}
						}
					}
					NetworkServiceGateway.发送公告("沙巴克攻城战开始", true);
					MapGatewayProcess.沙城节点 += 1;
					return;
				}
			}
			else if (MapGatewayProcess.沙城节点 == 2)
			{
				if (MapGatewayProcess.沙城城门.对象死亡 && MapGatewayProcess.沙城城门.出生地图 != null)
				{
					NetworkServiceGateway.发送公告("沙巴克城门已经被攻破", true);
					MapGatewayProcess.沙城城门.出生地图 = null;
				}
				if (MapGatewayProcess.八卦坛激活行会 == null)
				{
					GuildData GuildData2 = null;
					bool flag = true;
					if (MapGatewayProcess.沙城地图[MapGatewayProcess.八卦坛坐标上].FirstOrDefault((MapObject O) => !O.对象死亡 && O is PlayerObject) == null)
					{
						flag = false;
					}
					if (flag)
					{
						if (MapGatewayProcess.沙城地图[MapGatewayProcess.八卦坛坐标下].FirstOrDefault((MapObject O) => !O.对象死亡 && O is PlayerObject) == null)
						{
							flag = false;
						}
					}
					if (flag)
					{
						if (MapGatewayProcess.沙城地图[MapGatewayProcess.八卦坛坐标左].FirstOrDefault((MapObject O) => !O.对象死亡 && O is PlayerObject) == null)
						{
							flag = false;
						}
					}
					if (flag)
					{
						if (MapGatewayProcess.沙城地图[MapGatewayProcess.八卦坛坐标右].FirstOrDefault((MapObject O) => !O.对象死亡 && O is PlayerObject) == null)
						{
							flag = false;
						}
					}
					if (GuildData2 == null && flag)
					{
						foreach (MapObject MapObject9 in MapGatewayProcess.沙城地图[MapGatewayProcess.八卦坛坐标上])
						{
							if (!MapObject9.对象死亡)
							{
								PlayerObject PlayerObject11 = MapObject9 as PlayerObject;
								if (PlayerObject11 != null)
								{
									if (PlayerObject11.所属行会 == null)
									{
										flag = false;
										break;
									}
									if (!MapGatewayProcess.攻城行会.Contains(PlayerObject11.所属行会))
									{
										flag = false;
										break;
									}
									if (GuildData2 == null)
									{
										GuildData2 = PlayerObject11.所属行会;
									}
									else if (GuildData2 != PlayerObject11.所属行会)
									{
										flag = false;
										break;
									}
								}
							}
						}
					}
					if (GuildData2 != null && flag)
					{
						foreach (MapObject MapObject10 in MapGatewayProcess.沙城地图[MapGatewayProcess.八卦坛坐标下])
						{
							if (!MapObject10.对象死亡)
							{
								PlayerObject PlayerObject12 = MapObject10 as PlayerObject;
								if (PlayerObject12 != null)
								{
									if (PlayerObject12.所属行会 != null)
									{
										if (GuildData2 == PlayerObject12.所属行会)
										{
											continue;
										}
									}
									flag = false;
									break;
								}
							}
						}
					}
					if (GuildData2 != null && flag)
					{
						foreach (MapObject MapObject11 in MapGatewayProcess.沙城地图[MapGatewayProcess.八卦坛坐标左])
						{
							if (!MapObject11.对象死亡)
							{
								PlayerObject PlayerObject13 = MapObject11 as PlayerObject;
								if (PlayerObject13 != null)
								{
									if (PlayerObject13.所属行会 != null)
									{
										if (GuildData2 == PlayerObject13.所属行会)
										{
											continue;
										}
									}
									flag = false;
									break;
								}
							}
						}
					}
					if (GuildData2 != null && flag)
					{
						foreach (MapObject MapObject12 in MapGatewayProcess.沙城地图[MapGatewayProcess.八卦坛坐标右])
						{
							if (!MapObject12.对象死亡)
							{
								PlayerObject PlayerObject14 = MapObject12 as PlayerObject;
								if (PlayerObject14 != null)
								{
									if (PlayerObject14.所属行会 != null)
									{
										if (GuildData2 == PlayerObject14.所属行会)
										{
											continue;
										}
									}
									flag = false;
									break;
								}
							}
						}
					}
					if (GuildData2 != null && flag && MapGatewayProcess.攻城行会.Contains(GuildData2))
					{
						if (MapGatewayProcess.八卦坛激活计时 == DateTime.MaxValue)
						{
							MapGatewayProcess.八卦坛激活计时 = MainProcess.当前时间.AddSeconds(10.0);
						}
						else if (MainProcess.当前时间 > MapGatewayProcess.八卦坛激活计时)
						{
							MapGatewayProcess.八卦坛激活行会 = GuildData2;
							MapGatewayProcess.八卦坛激活法阵 = new GuardInstance(地图守卫.DataSheet[6123], MapGatewayProcess.沙城地图, GameDirection.左方, MapGatewayProcess.八卦坛坐标中);
							NetworkServiceGateway.发送公告(string.Format("沙巴克八卦坛传送点已经被行会[{0}]成功激活", GuildData2), true);
						}
					}
					else
					{
						MapGatewayProcess.八卦坛激活计时 = DateTime.MaxValue;
					}
				}
				bool flag2 = true;
				GuildData GuildData3 = null;
				foreach (Point 坐标 in MapGatewayProcess.皇宫随机区域.范围坐标)
				{
					foreach (MapObject MapObject13 in MapGatewayProcess.沙城地图[坐标])
					{
						if (!MapObject13.对象死亡)
						{
							PlayerObject PlayerObject15 = MapObject13 as PlayerObject;
							if (PlayerObject15 != null)
							{
								if (PlayerObject15.所属行会 == null || !MapGatewayProcess.攻城行会.Contains(PlayerObject15.所属行会))
								{
									flag2 = false;
									break;
								}
								if (GuildData3 == null)
								{
									GuildData3 = PlayerObject15.所属行会;
								}
								else if (GuildData3 != PlayerObject15.所属行会)
								{
									flag2 = false;
									break;
								}
							}
						}
					}
					if (!flag2)
					{
						break;
					}
				}
				if (flag2 && GuildData3 != null)
				{
					NetworkServiceGateway.发送封包(new 同步占领行会
					{
						行会编号 = GuildData3.行会编号
					});
					SystemData.数据.占领行会.V = GuildData3;
					SystemData.数据.占领时间.V = MainProcess.当前时间;
					foreach (KeyValuePair<CharacterData, GuildJobs> keyValuePair4 in GuildData3.行会成员)
					{
						keyValuePair4.Key.攻沙日期.V = MainProcess.当前时间;
					}
					NetworkServiceGateway.发送公告(string.Format("沙巴克攻城战已经结束, [{0}]成为新的沙巴克行会", GuildData3), true);
					MapGatewayProcess.八卦坛激活计时 = MainProcess.当前时间.AddMinutes(5.0);
					MapGatewayProcess.沙城节点 += 1;
					return;
				}
				if (MainProcess.当前时间.Hour >= 21)
				{
					if (SystemData.数据.占领行会.V == null)
					{
						NetworkServiceGateway.发送公告("沙巴克攻城战已经结束, 沙巴克仍然为无主之地", true);
					}
					else
					{
						NetworkServiceGateway.发送公告(string.Format("沙巴克攻城战已经结束, 沙巴克仍然被[{0}]行会占领", SystemData.数据.占领行会.V.行会名字), true);
					}
					if (SystemData.数据.占领行会.V == null)
					{
						foreach (KeyValuePair<CharacterData, GuildJobs> keyValuePair5 in SystemData.数据.占领行会.V.行会成员)
						{
							keyValuePair5.Key.攻沙日期.V = MainProcess.当前时间;
						}
					}
					MapGatewayProcess.八卦坛激活计时 = MainProcess.当前时间.AddMinutes(5.0);
					MapGatewayProcess.沙城节点 += 1;
					return;
				}
			}
			else if (MapGatewayProcess.沙城节点 == 3 && MainProcess.当前时间 > MapGatewayProcess.八卦坛激活计时)
			{
				MonsterObject MonsterObject = MapGatewayProcess.沙城城门;
				if (MonsterObject != null)
				{
					MonsterObject.删除对象();
				}
				MonsterObject MonsterObject2 = MapGatewayProcess.上方宫门;
				if (MonsterObject2 != null)
				{
					MonsterObject2.删除对象();
				}
				MonsterObject MonsterObject3 = MapGatewayProcess.下方宫门;
				if (MonsterObject3 != null)
				{
					MonsterObject3.删除对象();
				}
				MonsterObject MonsterObject4 = MapGatewayProcess.左方宫门;
				if (MonsterObject4 != null)
				{
					MonsterObject4.删除对象();
				}
				MapGatewayProcess.沙城城门 = new MonsterObject(MapGatewayProcess.沙城城门.对象模板, MapGatewayProcess.沙城地图, int.MaxValue, new Point[]
				{
					MapGatewayProcess.沙城城门坐标
				}, true, true)
				{
					当前方向 = GameDirection.右上,
					存活时间 = DateTime.MaxValue
				};
				MapGatewayProcess.上方宫门 = new MonsterObject(MapGatewayProcess.上方宫门.对象模板, MapGatewayProcess.沙城地图, int.MaxValue, new Point[]
				{
					MapGatewayProcess.皇宫上门坐标
				}, true, true)
				{
					当前方向 = GameDirection.右下,
					存活时间 = DateTime.MaxValue
				};
				MapGatewayProcess.下方宫门 = new MonsterObject(MapGatewayProcess.下方宫门.对象模板, MapGatewayProcess.沙城地图, int.MaxValue, new Point[]
				{
					MapGatewayProcess.皇宫下门坐标
				}, true, true)
				{
					当前方向 = GameDirection.右下,
					存活时间 = DateTime.MaxValue
				};
				MapGatewayProcess.左方宫门 = new MonsterObject(MapGatewayProcess.左方宫门.对象模板, MapGatewayProcess.沙城地图, int.MaxValue, new Point[]
				{
					MapGatewayProcess.皇宫左门坐标
				}, true, true)
				{
					当前方向 = GameDirection.左下,
					存活时间 = DateTime.MaxValue
				};
				MapGatewayProcess.沙城城门.添加Buff时处理(22300, MapGatewayProcess.沙城城门);
				MapGatewayProcess.上方宫门.添加Buff时处理(22300, MapGatewayProcess.上方宫门);
				MapGatewayProcess.下方宫门.添加Buff时处理(22300, MapGatewayProcess.下方宫门);
				MapGatewayProcess.左方宫门.添加Buff时处理(22300, MapGatewayProcess.左方宫门);
				MapGatewayProcess.八卦坛激活行会 = null;
				MapGatewayProcess.八卦坛激活计时 = DateTime.MaxValue;
				GuardInstance GuardInstance = MapGatewayProcess.八卦坛激活法阵;
				if (GuardInstance != null)
				{
					GuardInstance.删除对象();
				}
				MapGatewayProcess.八卦坛激活法阵 = null;
				MapGatewayProcess.攻城行会.Clear();
				MapGatewayProcess.沙城节点 = 0;
			}
		}

		// Token: 0x06000729 RID: 1833 RVA: 0x00038344 File Offset: 0x00036544
		public static void 处理数据()
		{
			foreach (KeyValuePair<int, MapObject> keyValuePair in MapGatewayProcess.激活对象表)
			{
				MapObject value = keyValuePair.Value;
				if (value != null)
				{
					value.处理对象数据();
				}
			}
			if (MapGatewayProcess.对象表计数 >= MapGatewayProcess.次要对象表.Count)
			{
				MapGatewayProcess.对象表计数 = 0;
				MapGatewayProcess.次要对象表 = MapGatewayProcess.对象备份表;
				MapGatewayProcess.对象备份表 = new List<MapObject>();
			}
			int num = 0;
			while (num < 100 && MapGatewayProcess.对象表计数 < MapGatewayProcess.次要对象表.Count)
			{
				if (MapGatewayProcess.次要对象表[MapGatewayProcess.对象表计数].次要对象)
				{
					MapGatewayProcess.次要对象表[MapGatewayProcess.对象表计数].处理对象数据();
					MapGatewayProcess.对象备份表.Add(MapGatewayProcess.次要对象表[MapGatewayProcess.对象表计数]);
				}
				MapGatewayProcess.对象表计数++;
				num++;
			}
			while (!MapGatewayProcess.移除激活表.IsEmpty)
			{
				MapObject MapObject;
				if (MapGatewayProcess.移除激活表.TryDequeue(out MapObject) && !MapObject.激活对象)
				{
					MapGatewayProcess.激活对象表.Remove(MapObject.地图编号);
				}
			}
			while (!MapGatewayProcess.添加激活表.IsEmpty)
			{
				MapObject MapObject2;
				if (MapGatewayProcess.添加激活表.TryDequeue(out MapObject2) && MapObject2.激活对象 && !MapGatewayProcess.激活对象表.ContainsKey(MapObject2.地图编号))
				{
					MapGatewayProcess.激活对象表.Add(MapObject2.地图编号, MapObject2);
				}
			}
			if (MainProcess.当前时间.Minute == 55 && MainProcess.当前时间.Hour != MapGatewayProcess.通知时间.Hour)
			{
				if (MainProcess.当前时间.Hour + 1 == (int)CustomClass.武斗场时间一 || MainProcess.当前时间.Hour + 1 == (int)CustomClass.武斗场时间二)
				{
					NetworkServiceGateway.发送公告("经验武斗场将在五分钟后开启, 想要参加的勇士请做好准备", true);
				}
				MapGatewayProcess.通知时间 = MainProcess.当前时间;
			}
			using (HashSet<MapInstance>.Enumerator enumerator2 = MapGatewayProcess.副本实例表.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					MapInstance MapInstance = enumerator2.Current;
					if (MapInstance.副本关闭)
					{
						MapGatewayProcess.副本移除表.Enqueue(MapInstance);
					}
					else
					{
						MapInstance.处理数据();
					}
				}
				goto IL_226;
			}
			IL_20B:
			MapInstance item;
			if (MapGatewayProcess.副本移除表.TryDequeue(out item))
			{
				MapGatewayProcess.副本实例表.Remove(item);
			}
			IL_226:
			if (MapGatewayProcess.副本移除表.IsEmpty)
			{
				MapGatewayProcess.沙城处理();
				return;
			}
			goto IL_20B;
		}

		// Token: 0x0600072A RID: 1834 RVA: 0x000385A4 File Offset: 0x000367A4
		public static void 开启地图()
		{
			MapGatewayProcess.次要对象表 = new List<MapObject>();
			MapGatewayProcess.对象备份表 = new List<MapObject>();
			MapGatewayProcess.副本实例表 = new HashSet<MapInstance>();
			MapGatewayProcess.副本移除表 = new ConcurrentQueue<MapInstance>();
			MapGatewayProcess.添加激活表 = new ConcurrentQueue<MapObject>();
			MapGatewayProcess.移除激活表 = new ConcurrentQueue<MapObject>();
			MapGatewayProcess.激活对象表 = new Dictionary<int, MapObject>();
			MapGatewayProcess.MapObject表 = new Dictionary<int, MapObject>();
			MapGatewayProcess.MapInstance表 = new Dictionary<int, MapInstance>();
			MapGatewayProcess.玩家对象表 = new Dictionary<int, PlayerObject>();
			MapGatewayProcess.怪物对象表 = new Dictionary<int, MonsterObject>();
			MapGatewayProcess.宠物对象表 = new Dictionary<int, PetObject>();
			MapGatewayProcess.守卫对象表 = new Dictionary<int, GuardInstance>();
			MapGatewayProcess.物品对象表 = new Dictionary<int, ItemObject>();
			MapGatewayProcess.陷阱对象表 = new Dictionary<int, TrapObject>();
			foreach (游戏地图 游戏地图 in 游戏地图.DataSheet.Values)
			{
				MapGatewayProcess.MapInstance表.Add((int)(游戏地图.地图编号 * 16 + 1), new MapInstance(游戏地图, 16777217));
			}
			foreach (地形数据 地形数据 in 地形数据.DataSheet.Values)
			{
				foreach (MapInstance MapInstance in MapGatewayProcess.MapInstance表.Values)
				{
					if (MapInstance.地图编号 == (int)地形数据.地图编号)
					{
						MapInstance.地形数据 = 地形数据;
						MapInstance.MapObject = new HashSet<MapObject>[MapInstance.地图大小.X, MapInstance.地图大小.Y];
						for (int i = 0; i < MapInstance.地图大小.X; i++)
						{
							for (int j = 0; j < MapInstance.地图大小.Y; j++)
							{
								MapInstance.MapObject[i, j] = new HashSet<MapObject>();
							}
						}
					}
				}
			}
			foreach (地图区域 地图区域 in 地图区域.DataSheet)
			{
				foreach (MapInstance MapInstance2 in MapGatewayProcess.MapInstance表.Values)
				{
					if (MapInstance2.地图编号 == (int)地图区域.所处地图)
					{
						if (地图区域.区域类型 == 地图区域类型.复活区域)
						{
							MapInstance2.复活区域 = 地图区域;
						}
						if (地图区域.区域类型 == 地图区域类型.红名区域)
						{
							MapInstance2.红名区域 = 地图区域;
						}
						if (地图区域.区域类型 == 地图区域类型.传送区域)
						{
							MapInstance2.传送区域 = 地图区域;
						}
						MapInstance2.地图区域.Add(地图区域);
						break;
					}
				}
			}
			foreach (传送法阵 传送法阵 in 传送法阵.DataSheet)
			{
				foreach (MapInstance MapInstance3 in MapGatewayProcess.MapInstance表.Values)
				{
					if (MapInstance3.地图编号 == (int)传送法阵.所处地图)
					{
						MapInstance3.法阵列表.Add(传送法阵.法阵编号, 传送法阵);
					}
				}
			}
			foreach (守卫刷新 守卫刷新 in 守卫刷新.DataSheet)
			{
				foreach (MapInstance MapInstance4 in MapGatewayProcess.MapInstance表.Values)
				{
					if (MapInstance4.地图编号 == (int)守卫刷新.所处地图)
					{
						MapInstance4.守卫区域.Add(守卫刷新);
					}
				}
			}
			foreach (怪物刷新 怪物刷新 in 怪物刷新.DataSheet)
			{
				foreach (MapInstance MapInstance5 in MapGatewayProcess.MapInstance表.Values)
				{
					if (MapInstance5.地图编号 == (int)怪物刷新.所处地图)
					{
						MapInstance5.怪物区域.Add(怪物刷新);
					}
				}
			}
			foreach (MapInstance MapInstance6 in MapGatewayProcess.MapInstance表.Values)
			{
				if (!MapInstance6.副本地图)
				{
					foreach (怪物刷新 怪物刷新2 in MapInstance6.怪物区域)
					{
						if (怪物刷新2.刷新列表 != null)
						{
							Point[] 出生范围 = 怪物刷新2.范围坐标.ToArray<Point>();
							foreach (刷新信息 刷新信息 in 怪物刷新2.刷新列表)
							{
								游戏怪物 游戏怪物;
								if (游戏怪物.DataSheet.TryGetValue(刷新信息.怪物名字, out 游戏怪物))
								{
									MainForm.添加怪物数据(游戏怪物);
									int 复活间隔 = 刷新信息.复活间隔 * 60 * 1000;
									for (int l = 0; l < 刷新信息.刷新数量; l++)
									{
										new MonsterObject(游戏怪物, MapInstance6, 复活间隔, 出生范围, false, true);
									}
								}
							}
						}
					}
					using (HashSet<守卫刷新>.Enumerator enumerator6 = MapInstance6.守卫区域.GetEnumerator())
					{
						while (enumerator6.MoveNext())
						{
							守卫刷新 守卫刷新2 = enumerator6.Current;
							地图守卫 对应模板;
							if (地图守卫.DataSheet.TryGetValue(守卫刷新2.守卫编号, out 对应模板))
							{
								new GuardInstance(对应模板, MapInstance6, 守卫刷新2.所处方向, 守卫刷新2.所处坐标);
							}
						}
						goto IL_5DE;
					}
					goto IL_5AC;
				}
				goto IL_5AC;
				IL_5DE:
				MainForm.添加地图数据(MapInstance6);
				continue;
				IL_5AC:
				MapInstance6.固定怪物总数 = (uint)MapInstance6.怪物区域.Sum((怪物刷新 O) => O.刷新列表.Sum((刷新信息 X) => X.刷新数量));
				goto IL_5DE;
			}
		}

		// Token: 0x0600072B RID: 1835 RVA: 0x00038D08 File Offset: 0x00036F08
		public static void 清理物品()
		{
			foreach (ItemObject ItemObject in MapGatewayProcess.物品对象表.Values)
			{
				ItemData ItemData = ItemObject.ItemData;
				if (ItemData != null)
				{
					ItemData.删除数据();
				}
			}
			foreach (KeyValuePair<int, 游戏商店> keyValuePair in 游戏商店.DataSheet)
			{
				foreach (ItemData ItemData2 in keyValuePair.Value.回购列表)
				{
					ItemData2.删除数据();
				}
			}
		}

		// Token: 0x0600072C RID: 1836 RVA: 0x00038DEC File Offset: 0x00036FEC
		public static void 添加MapObject(MapObject 当前对象)
		{
			MapGatewayProcess.MapObject表.Add(当前对象.地图编号, 当前对象);
			GameObjectType 对象类型 = 当前对象.对象类型;
			if (对象类型 <= GameObjectType.Npcc)
			{
				switch (对象类型)
				{
				case GameObjectType.玩家:
					MapGatewayProcess.玩家对象表.Add(当前对象.地图编号, (PlayerObject)当前对象);
					return;
				case GameObjectType.宠物:
					MapGatewayProcess.宠物对象表.Add(当前对象.地图编号, (PetObject)当前对象);
					return;
				case (GameObjectType)3:
					break;
				case GameObjectType.怪物:
					MapGatewayProcess.怪物对象表.Add(当前对象.地图编号, (MonsterObject)当前对象);
					return;
				default:
					if (对象类型 != GameObjectType.Npcc)
					{
						return;
					}
					MapGatewayProcess.守卫对象表.Add(当前对象.地图编号, (GuardInstance)当前对象);
					return;
				}
			}
			else
			{
				if (对象类型 == GameObjectType.物品)
				{
					MapGatewayProcess.物品对象表.Add(当前对象.地图编号, (ItemObject)当前对象);
					return;
				}
				if (对象类型 != GameObjectType.陷阱)
				{
					return;
				}
				MapGatewayProcess.陷阱对象表.Add(当前对象.地图编号, (TrapObject)当前对象);
			}
		}

		// Token: 0x0600072D RID: 1837 RVA: 0x00038EC8 File Offset: 0x000370C8
		public static void 移除MapObject(MapObject 当前对象)
		{
			MapGatewayProcess.MapObject表.Remove(当前对象.地图编号);
			GameObjectType 对象类型 = 当前对象.对象类型;
			if (对象类型 <= GameObjectType.Npcc)
			{
				switch (对象类型)
				{
				case GameObjectType.玩家:
					MapGatewayProcess.玩家对象表.Remove(当前对象.地图编号);
					return;
				case GameObjectType.宠物:
					MapGatewayProcess.宠物对象表.Remove(当前对象.地图编号);
					return;
				case (GameObjectType)3:
					break;
				case GameObjectType.怪物:
					MapGatewayProcess.怪物对象表.Remove(当前对象.地图编号);
					return;
				default:
					if (对象类型 != GameObjectType.Npcc)
					{
						return;
					}
					MapGatewayProcess.守卫对象表.Remove(当前对象.地图编号);
					return;
				}
			}
			else
			{
				if (对象类型 == GameObjectType.物品)
				{
					MapGatewayProcess.物品对象表.Remove(当前对象.地图编号);
					return;
				}
				if (对象类型 != GameObjectType.陷阱)
				{
					return;
				}
				MapGatewayProcess.陷阱对象表.Remove(当前对象.地图编号);
			}
		}

		// Token: 0x0600072E RID: 1838 RVA: 0x000062B3 File Offset: 0x000044B3
		public static void 添加激活对象(MapObject 当前对象)
		{
			MapGatewayProcess.添加激活表.Enqueue(当前对象);
		}

		// Token: 0x0600072F RID: 1839 RVA: 0x000062C0 File Offset: 0x000044C0
		public static void 移除激活对象(MapObject 当前对象)
		{
			MapGatewayProcess.移除激活表.Enqueue(当前对象);
		}

		// Token: 0x06000730 RID: 1840 RVA: 0x000062CD File Offset: 0x000044CD
		public static void 添加次要对象(MapObject 当前对象)
		{
			MapGatewayProcess.对象备份表.Add(当前对象);
		}

		// Token: 0x06000731 RID: 1841 RVA: 0x00038F84 File Offset: 0x00037184
		public static MapInstance 分配地图(int 地图编号)
		{
			MapInstance result;
			if (MapGatewayProcess.MapInstance表.TryGetValue(地图编号 * 16 + 1, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x06000732 RID: 1842 RVA: 0x00038FA8 File Offset: 0x000371A8
		static MapGatewayProcess()
		{
			
			MapGatewayProcess.对象编号 = 268435456;
			MapGatewayProcess.陷阱编号 = 1073741824;
			MapGatewayProcess.物品编号 = 1342177280;
			MapGatewayProcess.沙城城门坐标 = new Point(1020, 506);
			MapGatewayProcess.皇宫下门坐标 = new Point(1079, 557);
			MapGatewayProcess.皇宫下门出口 = new Point(1078, 556);
			MapGatewayProcess.皇宫下门入口 = new Point(1265, 773);
			MapGatewayProcess.皇宫左门坐标 = new Point(1082, 557);
			MapGatewayProcess.皇宫左门出口 = new Point(1083, 556);
			MapGatewayProcess.皇宫左门入口 = new Point(1266, 773);
			MapGatewayProcess.皇宫上门坐标 = new Point(1071, 565);
			MapGatewayProcess.皇宫上门出口 = new Point(1070, 564);
			MapGatewayProcess.皇宫上门入口 = new Point(1254, 784);
			MapGatewayProcess.皇宫出口点一 = new Point(1257, 777);
			MapGatewayProcess.皇宫出口点二 = new Point(1258, 776);
			MapGatewayProcess.皇宫正门入口 = new Point(1258, 777);
			MapGatewayProcess.皇宫正门出口 = new Point(1074, 560);
			MapGatewayProcess.皇宫入口点左 = new Point(1076, 560);
			MapGatewayProcess.皇宫入口点中 = new Point(1075, 561);
			MapGatewayProcess.皇宫入口点右 = new Point(1074, 562);
			MapGatewayProcess.八卦坛坐标上 = new Point(1059, 591);
			MapGatewayProcess.八卦坛坐标下 = new Point(1054, 586);
			MapGatewayProcess.八卦坛坐标左 = new Point(1059, 586);
			MapGatewayProcess.八卦坛坐标右 = new Point(1054, 591);
			MapGatewayProcess.八卦坛坐标中 = new Point(1056, 588);
			MapGatewayProcess.八卦坛激活计时 = DateTime.MaxValue;
			MapGatewayProcess.攻城行会 = new HashSet<GuildData>();
		}

		// Token: 0x04000C48 RID: 3144
		public static int 对象表计数;

		// Token: 0x04000C49 RID: 3145
		public static List<MapObject> 次要对象表;

		// Token: 0x04000C4A RID: 3146
		public static List<MapObject> 对象备份表;

		// Token: 0x04000C4B RID: 3147
		public static Dictionary<int, MapObject> 激活对象表;

		// Token: 0x04000C4C RID: 3148
		public static Dictionary<int, MapObject> MapObject表;

		// Token: 0x04000C4D RID: 3149
		public static Dictionary<int, PlayerObject> 玩家对象表;

		// Token: 0x04000C4E RID: 3150
		public static Dictionary<int, PetObject> 宠物对象表;

		// Token: 0x04000C4F RID: 3151
		public static Dictionary<int, MonsterObject> 怪物对象表;

		// Token: 0x04000C50 RID: 3152
		public static Dictionary<int, GuardInstance> 守卫对象表;

		// Token: 0x04000C51 RID: 3153
		public static Dictionary<int, ItemObject> 物品对象表;

		// Token: 0x04000C52 RID: 3154
		public static Dictionary<int, TrapObject> 陷阱对象表;

		// Token: 0x04000C53 RID: 3155
		public static Dictionary<int, MapInstance> MapInstance表;

		// Token: 0x04000C54 RID: 3156
		public static HashSet<MapInstance> 副本实例表;

		// Token: 0x04000C55 RID: 3157
		private static ConcurrentQueue<MapInstance> 副本移除表;

		// Token: 0x04000C56 RID: 3158
		private static ConcurrentQueue<MapObject> 添加激活表;

		// Token: 0x04000C57 RID: 3159
		private static ConcurrentQueue<MapObject> 移除激活表;

		// Token: 0x04000C58 RID: 3160
		public static int 对象编号;

		// Token: 0x04000C59 RID: 3161
		public static int 陷阱编号;

		// Token: 0x04000C5A RID: 3162
		public static int 物品编号;

		// Token: 0x04000C5B RID: 3163
		private static DateTime 沙城处理计时;

		// Token: 0x04000C5C RID: 3164
		public static Point 沙城城门坐标;

		// Token: 0x04000C5D RID: 3165
		public static Point 皇宫下门坐标;

		// Token: 0x04000C5E RID: 3166
		public static Point 皇宫下门出口;

		// Token: 0x04000C5F RID: 3167
		public static Point 皇宫下门入口;

		// Token: 0x04000C60 RID: 3168
		public static Point 皇宫左门坐标;

		// Token: 0x04000C61 RID: 3169
		public static Point 皇宫左门出口;

		// Token: 0x04000C62 RID: 3170
		public static Point 皇宫左门入口;

		// Token: 0x04000C63 RID: 3171
		public static Point 皇宫上门坐标;

		// Token: 0x04000C64 RID: 3172
		public static Point 皇宫上门出口;

		// Token: 0x04000C65 RID: 3173
		public static Point 皇宫上门入口;

		// Token: 0x04000C66 RID: 3174
		public static Point 皇宫出口点一;

		// Token: 0x04000C67 RID: 3175
		public static Point 皇宫出口点二;

		// Token: 0x04000C68 RID: 3176
		public static Point 皇宫正门入口;

		// Token: 0x04000C69 RID: 3177
		public static Point 皇宫正门出口;

		// Token: 0x04000C6A RID: 3178
		public static Point 皇宫入口点左;

		// Token: 0x04000C6B RID: 3179
		public static Point 皇宫入口点中;

		// Token: 0x04000C6C RID: 3180
		public static Point 皇宫入口点右;

		// Token: 0x04000C6D RID: 3181
		public static Point 八卦坛坐标上;

		// Token: 0x04000C6E RID: 3182
		public static Point 八卦坛坐标下;

		// Token: 0x04000C6F RID: 3183
		public static Point 八卦坛坐标左;

		// Token: 0x04000C70 RID: 3184
		public static Point 八卦坛坐标右;

		// Token: 0x04000C71 RID: 3185
		public static Point 八卦坛坐标中;

		// Token: 0x04000C72 RID: 3186
		public static MapInstance 沙城地图;

		// Token: 0x04000C73 RID: 3187
		public static MonsterObject 沙城城门;

		// Token: 0x04000C74 RID: 3188
		public static MonsterObject 下方宫门;

		// Token: 0x04000C75 RID: 3189
		public static MonsterObject 上方宫门;

		// Token: 0x04000C76 RID: 3190
		public static MonsterObject 左方宫门;

		// Token: 0x04000C77 RID: 3191
		public static GuardInstance 上方法阵;

		// Token: 0x04000C78 RID: 3192
		public static GuardInstance 下方法阵;

		// Token: 0x04000C79 RID: 3193
		public static GuardInstance 左方法阵;

		// Token: 0x04000C7A RID: 3194
		public static GuardInstance 右方法阵;

		// Token: 0x04000C7B RID: 3195
		public static GuardInstance 八卦坛激活法阵;

		// Token: 0x04000C7C RID: 3196
		public static GuildData 八卦坛激活行会;

		// Token: 0x04000C7D RID: 3197
		public static DateTime 八卦坛激活计时;

		// Token: 0x04000C7E RID: 3198
		public static 地图区域 皇宫随机区域;

		// Token: 0x04000C7F RID: 3199
		public static 地图区域 外城复活区域;

		// Token: 0x04000C80 RID: 3200
		public static 地图区域 内城复活区域;

		// Token: 0x04000C81 RID: 3201
		public static 地图区域 守方传送区域;

		// Token: 0x04000C82 RID: 3202
		public static byte 沙城节点;

		// Token: 0x04000C83 RID: 3203
		public static DateTime 通知时间;

		// Token: 0x04000C84 RID: 3204
		public static HashSet<GuildData> 攻城行会;
	}
}
