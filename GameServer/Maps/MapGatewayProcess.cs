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
	
	public static class MapGatewayProcess
	{
		
		private static void 沙城处理()
		{
			if (MainProcess.CurrentTime < MapGatewayProcess.沙城处理计时)
			{
				return;
			}
			MapGatewayProcess.沙城处理计时 = MainProcess.CurrentTime.AddMilliseconds(50.0);
			if (MapGatewayProcess.沙城地图 == null)
			{
				GameBuffs 游戏Buff;
				Monsters 对应模板;
				Monsters 对应模板2;
				if (MapGatewayProcess.MapInstance表.TryGetValue(2433, out MapGatewayProcess.沙城地图) && GameBuffs.DataSheet.TryGetValue(22300, out 游戏Buff) && Monsters.DataSheet.TryGetValue("沙巴克城门", out 对应模板) && Monsters.DataSheet.TryGetValue("沙巴克宫门", out 对应模板2))
				{
					if ((MapGatewayProcess.皇宫随机区域 = MapGatewayProcess.沙城地图.地图区域.FirstOrDefault((MapAreas O) => O.RegionName == "沙巴克-皇宫随机区域")) != null)
					{
						if ((MapGatewayProcess.外城复活区域 = MapGatewayProcess.沙城地图.地图区域.FirstOrDefault((MapAreas O) => O.RegionName == "沙巴克-外城复活区域")) != null)
						{
							if ((MapGatewayProcess.内城复活区域 = MapGatewayProcess.沙城地图.地图区域.FirstOrDefault((MapAreas O) => O.RegionName == "沙巴克-内城复活区域")) != null)
							{
								if ((MapGatewayProcess.守方传送区域 = MapGatewayProcess.沙城地图.地图区域.FirstOrDefault((MapAreas O) => O.RegionName == "沙巴克-守方传送区域")) != null)
								{
									MapGatewayProcess.沙城城门 = new MonsterObject(对应模板, MapGatewayProcess.沙城地图, int.MaxValue, new Point[]
									{
										MapGatewayProcess.沙城城门坐标
									}, true, true)
									{
										CurrentDirection = GameDirection.右上,
										存活时间 = DateTime.MaxValue
									};
									MapGatewayProcess.上方宫门 = new MonsterObject(对应模板2, MapGatewayProcess.沙城地图, int.MaxValue, new Point[]
									{
										MapGatewayProcess.皇宫上门坐标
									}, true, true)
									{
										CurrentDirection = GameDirection.右下,
										存活时间 = DateTime.MaxValue
									};
									MapGatewayProcess.下方宫门 = new MonsterObject(对应模板2, MapGatewayProcess.沙城地图, int.MaxValue, new Point[]
									{
										MapGatewayProcess.皇宫下门坐标
									}, true, true)
									{
										CurrentDirection = GameDirection.右下,
										存活时间 = DateTime.MaxValue
									};
									MapGatewayProcess.左方宫门 = new MonsterObject(对应模板2, MapGatewayProcess.沙城地图, int.MaxValue, new Point[]
									{
										MapGatewayProcess.皇宫左门坐标
									}, true, true)
									{
										CurrentDirection = GameDirection.左下,
										存活时间 = DateTime.MaxValue
									};
									MapGatewayProcess.沙城城门.OnAddBuff(游戏Buff.Id, MapGatewayProcess.沙城城门);
									MapGatewayProcess.上方宫门.OnAddBuff(游戏Buff.Id, MapGatewayProcess.上方宫门);
									MapGatewayProcess.下方宫门.OnAddBuff(游戏Buff.Id, MapGatewayProcess.下方宫门);
									MapGatewayProcess.左方宫门.OnAddBuff(游戏Buff.Id, MapGatewayProcess.左方宫门);
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
				if (!MapObject.Died)
				{
					PlayerObject PlayerObject = MapObject as PlayerObject;
					if (PlayerObject != null && MainProcess.CurrentTime > PlayerObject.BusyTime)
					{
						PlayerObject.玩家切换地图(MapGatewayProcess.沙城地图, AreaType.未知区域, MapGatewayProcess.皇宫下门入口);
					}
				}
			}
			foreach (MapObject MapObject2 in MapGatewayProcess.沙城地图[MapGatewayProcess.皇宫上门坐标].ToList<MapObject>())
			{
				if (!MapObject2.Died)
				{
					PlayerObject PlayerObject2 = MapObject2 as PlayerObject;
					if (PlayerObject2 != null && MainProcess.CurrentTime > PlayerObject2.BusyTime)
					{
						PlayerObject2.玩家切换地图(MapGatewayProcess.沙城地图, AreaType.未知区域, MapGatewayProcess.皇宫上门入口);
					}
				}
			}
			foreach (MapObject MapObject3 in MapGatewayProcess.沙城地图[MapGatewayProcess.皇宫左门坐标].ToList<MapObject>())
			{
				if (!MapObject3.Died)
				{
					PlayerObject PlayerObject3 = MapObject3 as PlayerObject;
					if (PlayerObject3 != null && MainProcess.CurrentTime > PlayerObject3.BusyTime)
					{
						PlayerObject3.玩家切换地图(MapGatewayProcess.沙城地图, AreaType.未知区域, MapGatewayProcess.皇宫左门入口);
					}
				}
			}
			foreach (MapObject MapObject4 in MapGatewayProcess.沙城地图[MapGatewayProcess.皇宫出口点一].ToList<MapObject>())
			{
				if (!MapObject4.Died)
				{
					PlayerObject PlayerObject4 = MapObject4 as PlayerObject;
					if (PlayerObject4 != null && MainProcess.CurrentTime > PlayerObject4.BusyTime)
					{
						PlayerObject4.玩家切换地图(MapGatewayProcess.沙城地图, AreaType.未知区域, MapGatewayProcess.皇宫正门出口);
					}
				}
			}
			foreach (MapObject MapObject5 in MapGatewayProcess.沙城地图[MapGatewayProcess.皇宫出口点二].ToList<MapObject>())
			{
				if (!MapObject5.Died)
				{
					PlayerObject PlayerObject5 = MapObject5 as PlayerObject;
					if (PlayerObject5 != null && MainProcess.CurrentTime > PlayerObject5.BusyTime)
					{
						PlayerObject5.玩家切换地图(MapGatewayProcess.沙城地图, AreaType.未知区域, MapGatewayProcess.皇宫正门出口);
					}
				}
			}
			foreach (MapObject MapObject6 in MapGatewayProcess.沙城地图[MapGatewayProcess.皇宫入口点左].ToList<MapObject>())
			{
				if (!MapObject6.Died)
				{
					PlayerObject PlayerObject6 = MapObject6 as PlayerObject;
					if (PlayerObject6 != null && MainProcess.CurrentTime > PlayerObject6.BusyTime && PlayerObject6.Guild != null && PlayerObject6.Guild == SystemData.Data.OccupyGuild.V)
					{
						PlayerObject6.玩家切换地图(MapGatewayProcess.沙城地图, AreaType.未知区域, MapGatewayProcess.皇宫正门入口);
					}
				}
			}
			foreach (MapObject MapObject7 in MapGatewayProcess.沙城地图[MapGatewayProcess.皇宫入口点中].ToList<MapObject>())
			{
				if (!MapObject7.Died)
				{
					PlayerObject PlayerObject7 = MapObject7 as PlayerObject;
					if (PlayerObject7 != null && MainProcess.CurrentTime > PlayerObject7.BusyTime && PlayerObject7.Guild != null && PlayerObject7.Guild == SystemData.Data.OccupyGuild.V)
					{
						PlayerObject7.玩家切换地图(MapGatewayProcess.沙城地图, AreaType.未知区域, MapGatewayProcess.皇宫正门入口);
					}
				}
			}
			foreach (MapObject MapObject8 in MapGatewayProcess.沙城地图[MapGatewayProcess.皇宫入口点右].ToList<MapObject>())
			{
				if (!MapObject8.Died)
				{
					PlayerObject PlayerObject8 = MapObject8 as PlayerObject;
					if (PlayerObject8 != null && MainProcess.CurrentTime > PlayerObject8.BusyTime && PlayerObject8.Guild != null && PlayerObject8.Guild == SystemData.Data.OccupyGuild.V)
					{
						PlayerObject8.玩家切换地图(MapGatewayProcess.沙城地图, AreaType.未知区域, MapGatewayProcess.皇宫正门入口);
					}
				}
			}
			if (MapGatewayProcess.沙城节点 == 0)
			{
				foreach (KeyValuePair<DateTime, GuildData> keyValuePair in SystemData.Data.申请行会.ToList<KeyValuePair<DateTime, GuildData>>())
				{
					if (keyValuePair.Key.Date < MainProcess.CurrentTime.Date)
					{
						SystemData.Data.申请行会.Remove(keyValuePair.Key);
					}
				}
				if (SystemData.Data.申请行会.Count == 0)
				{
					return;
				}
				if (MainProcess.CurrentTime.Hour != 19 || MainProcess.CurrentTime.Minute != 50)
				{
					return;
				}
				using (IEnumerator<KeyValuePair<DateTime, GuildData>> enumerator3 = SystemData.Data.申请行会.GetEnumerator())
				{
					while (enumerator3.MoveNext())
					{
						KeyValuePair<DateTime, GuildData> keyValuePair2 = enumerator3.Current;
						if (keyValuePair2.Key.Date == MainProcess.CurrentTime.Date)
						{
							NetworkServiceGateway.SendAnnouncement("The Shabak Siege will start in 10 minutes, please be ready!", true);
							MapGatewayProcess.沙城节点 += 1;
							break;
						}
					}
					return;
				}
			}
			if (MapGatewayProcess.沙城节点 == 1)
			{
				if (MainProcess.CurrentTime.Hour == 20)
				{
					foreach (KeyValuePair<DateTime, GuildData> keyValuePair3 in SystemData.Data.申请行会.ToList<KeyValuePair<DateTime, GuildData>>())
					{
						if (keyValuePair3.Key.Date == MainProcess.CurrentTime.Date)
						{
							MapGatewayProcess.攻城行会.Add(keyValuePair3.Value);
							SystemData.Data.申请行会.Remove(keyValuePair3.Key);
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
					foreach (PlayerObject PlayerObject9 in MapGatewayProcess.沙城地图.NrPlayers)
					{
						if (PlayerObject9.Guild == null || PlayerObject9.Guild != SystemData.Data.OccupyGuild.V)
						{
							PlayerObject9.玩家切换地图(MapGatewayProcess.沙城地图, AreaType.未知区域, MapGatewayProcess.外城复活区域.RandomCoords);
						}
					}
					MapInstance MapInstance;
					if (MapGatewayProcess.MapInstance表.TryGetValue(2849, out MapInstance))
					{
						foreach (PlayerObject PlayerObject10 in MapInstance.NrPlayers.ToList<PlayerObject>())
						{
							if (PlayerObject10.Guild == null || PlayerObject10.Guild != SystemData.Data.OccupyGuild.V)
							{
								PlayerObject10.玩家切换地图(PlayerObject10.复活地图, AreaType.复活区域, default(Point));
							}
						}
					}
					if (SystemData.Data.OccupyGuild.V != null)
					{
						GuildData v = SystemData.Data.OccupyGuild.V;
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
							if (!GuildData.Hostility行会.ContainsKey(v))
							{
								GuildData.Hostility行会.Add(v, MainProcess.CurrentTime.AddHours(1.0));
								v.Hostility行会.Add(GuildData, MainProcess.CurrentTime.AddHours(1.0));
								GuildData.发送封包(new AddDiplomaticAnnouncementPacket
								{
									外交类型 = 2,
									行会编号 = v.行会编号,
									GuildName = v.GuildName.V,
									行会等级 = v.行会等级.V,
									行会人数 = (byte)v.行会成员.Count,
									外交时间 = (int)(GuildData.Hostility行会[v] - MainProcess.CurrentTime).TotalSeconds
								});
								v.发送封包(new AddDiplomaticAnnouncementPacket
								{
									外交类型 = 2,
									行会编号 = GuildData.行会编号,
									GuildName = GuildData.GuildName.V,
									行会等级 = GuildData.行会等级.V,
									行会人数 = (byte)GuildData.行会成员.Count,
									外交时间 = (int)(v.Hostility行会[GuildData] - MainProcess.CurrentTime).TotalSeconds
								});
							}
							if (GuildData.Hostility行会[v] < MainProcess.CurrentTime.AddHours(1.0))
							{
								GuildData.Hostility行会[v] = MainProcess.CurrentTime.AddHours(1.0);
								v.Hostility行会[GuildData] = MainProcess.CurrentTime.AddHours(1.0);
								GuildData.发送封包(new AddDiplomaticAnnouncementPacket
								{
									外交类型 = 2,
									行会编号 = v.行会编号,
									GuildName = v.GuildName.V,
									行会等级 = v.行会等级.V,
									行会人数 = (byte)v.行会成员.Count,
									外交时间 = (int)(GuildData.Hostility行会[v] - MainProcess.CurrentTime).TotalSeconds
								});
								v.发送封包(new AddDiplomaticAnnouncementPacket
								{
									外交类型 = 2,
									行会编号 = GuildData.行会编号,
									GuildName = GuildData.GuildName.V,
									行会等级 = GuildData.行会等级.V,
									行会人数 = (byte)GuildData.行会成员.Count,
									外交时间 = (int)(v.Hostility行会[GuildData] - MainProcess.CurrentTime).TotalSeconds
								});
							}
						}
					}
					NetworkServiceGateway.SendAnnouncement("The shabak siege starts", true);
					MapGatewayProcess.沙城节点 += 1;
					return;
				}
			}
			else if (MapGatewayProcess.沙城节点 == 2)
			{
				if (MapGatewayProcess.沙城城门.Died && MapGatewayProcess.沙城城门.出生地图 != null)
				{
					NetworkServiceGateway.SendAnnouncement("Shabak City Gate has been breached", true);
					MapGatewayProcess.沙城城门.出生地图 = null;
				}
				if (MapGatewayProcess.八卦坛激活行会 == null)
				{
					GuildData GuildData2 = null;
					bool flag = true;
					if (MapGatewayProcess.沙城地图[MapGatewayProcess.八卦坛坐标上].FirstOrDefault((MapObject O) => !O.Died && O is PlayerObject) == null)
					{
						flag = false;
					}
					if (flag)
					{
						if (MapGatewayProcess.沙城地图[MapGatewayProcess.八卦坛坐标下].FirstOrDefault((MapObject O) => !O.Died && O is PlayerObject) == null)
						{
							flag = false;
						}
					}
					if (flag)
					{
						if (MapGatewayProcess.沙城地图[MapGatewayProcess.八卦坛坐标左].FirstOrDefault((MapObject O) => !O.Died && O is PlayerObject) == null)
						{
							flag = false;
						}
					}
					if (flag)
					{
						if (MapGatewayProcess.沙城地图[MapGatewayProcess.八卦坛坐标右].FirstOrDefault((MapObject O) => !O.Died && O is PlayerObject) == null)
						{
							flag = false;
						}
					}
					if (GuildData2 == null && flag)
					{
						foreach (MapObject MapObject9 in MapGatewayProcess.沙城地图[MapGatewayProcess.八卦坛坐标上])
						{
							if (!MapObject9.Died)
							{
								PlayerObject PlayerObject11 = MapObject9 as PlayerObject;
								if (PlayerObject11 != null)
								{
									if (PlayerObject11.Guild == null)
									{
										flag = false;
										break;
									}
									if (!MapGatewayProcess.攻城行会.Contains(PlayerObject11.Guild))
									{
										flag = false;
										break;
									}
									if (GuildData2 == null)
									{
										GuildData2 = PlayerObject11.Guild;
									}
									else if (GuildData2 != PlayerObject11.Guild)
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
							if (!MapObject10.Died)
							{
								PlayerObject PlayerObject12 = MapObject10 as PlayerObject;
								if (PlayerObject12 != null)
								{
									if (PlayerObject12.Guild != null)
									{
										if (GuildData2 == PlayerObject12.Guild)
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
							if (!MapObject11.Died)
							{
								PlayerObject PlayerObject13 = MapObject11 as PlayerObject;
								if (PlayerObject13 != null)
								{
									if (PlayerObject13.Guild != null)
									{
										if (GuildData2 == PlayerObject13.Guild)
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
							if (!MapObject12.Died)
							{
								PlayerObject PlayerObject14 = MapObject12 as PlayerObject;
								if (PlayerObject14 != null)
								{
									if (PlayerObject14.Guild != null)
									{
										if (GuildData2 == PlayerObject14.Guild)
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
							MapGatewayProcess.八卦坛激活计时 = MainProcess.CurrentTime.AddSeconds(10.0);
						}
						else if (MainProcess.CurrentTime > MapGatewayProcess.八卦坛激活计时)
						{
							MapGatewayProcess.八卦坛激活行会 = GuildData2;
							MapGatewayProcess.八卦坛激活法阵 = new GuardObject(Guards.DataSheet[6123], MapGatewayProcess.沙城地图, GameDirection.左方, MapGatewayProcess.八卦坛坐标中);
							NetworkServiceGateway.SendAnnouncement(string.Format("The Shabak Gossip Altar teleportation point has been successfully activated by guild [{0}]", GuildData2), true);
						}
					}
					else
					{
						MapGatewayProcess.八卦坛激活计时 = DateTime.MaxValue;
					}
				}
				bool flag2 = true;
				GuildData GuildData3 = null;
				foreach (Point 坐标 in MapGatewayProcess.皇宫随机区域.RangeCoords)
				{
					foreach (MapObject MapObject13 in MapGatewayProcess.沙城地图[坐标])
					{
						if (!MapObject13.Died)
						{
							PlayerObject PlayerObject15 = MapObject13 as PlayerObject;
							if (PlayerObject15 != null)
							{
								if (PlayerObject15.Guild == null || !MapGatewayProcess.攻城行会.Contains(PlayerObject15.Guild))
								{
									flag2 = false;
									break;
								}
								if (GuildData3 == null)
								{
									GuildData3 = PlayerObject15.Guild;
								}
								else if (GuildData3 != PlayerObject15.Guild)
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
					SystemData.Data.OccupyGuild.V = GuildData3;
					SystemData.Data.占领时间.V = MainProcess.CurrentTime;
					foreach (KeyValuePair<CharacterData, GuildJobs> keyValuePair4 in GuildData3.行会成员)
					{
						keyValuePair4.Key.攻沙日期.V = MainProcess.CurrentTime;
					}
					NetworkServiceGateway.SendAnnouncement(string.Format("The Battle of Shabak has ended, and [{0}] has become the new Shabak Guild", GuildData3), true);
					MapGatewayProcess.八卦坛激活计时 = MainProcess.CurrentTime.AddMinutes(5.0);
					MapGatewayProcess.沙城节点 += 1;
					return;
				}
				if (MainProcess.CurrentTime.Hour >= 21)
				{
					if (SystemData.Data.OccupyGuild.V == null)
					{
						NetworkServiceGateway.SendAnnouncement("The Battle of Shabak has ended, and Shabak remains without owners", true);
					}
					else
					{
						NetworkServiceGateway.SendAnnouncement(string.Format("The Shabak siege has ended, Shabak is still occupied by [{0}] guild", SystemData.Data.OccupyGuild.V.GuildName), true);
					}
					if (SystemData.Data.OccupyGuild.V == null)
					{
						foreach (KeyValuePair<CharacterData, GuildJobs> keyValuePair5 in SystemData.Data.OccupyGuild.V.行会成员)
						{
							keyValuePair5.Key.攻沙日期.V = MainProcess.CurrentTime;
						}
					}
					MapGatewayProcess.八卦坛激活计时 = MainProcess.CurrentTime.AddMinutes(5.0);
					MapGatewayProcess.沙城节点 += 1;
					return;
				}
			}
			else if (MapGatewayProcess.沙城节点 == 3 && MainProcess.CurrentTime > MapGatewayProcess.八卦坛激活计时)
			{
				MonsterObject MonsterObject = MapGatewayProcess.沙城城门;
				if (MonsterObject != null)
				{
					MonsterObject.Delete();
				}
				MonsterObject MonsterObject2 = MapGatewayProcess.上方宫门;
				if (MonsterObject2 != null)
				{
					MonsterObject2.Delete();
				}
				MonsterObject MonsterObject3 = MapGatewayProcess.下方宫门;
				if (MonsterObject3 != null)
				{
					MonsterObject3.Delete();
				}
				MonsterObject MonsterObject4 = MapGatewayProcess.左方宫门;
				if (MonsterObject4 != null)
				{
					MonsterObject4.Delete();
				}
				MapGatewayProcess.沙城城门 = new MonsterObject(MapGatewayProcess.沙城城门.Template, MapGatewayProcess.沙城地图, int.MaxValue, new Point[]
				{
					MapGatewayProcess.沙城城门坐标
				}, true, true)
				{
					CurrentDirection = GameDirection.右上,
					存活时间 = DateTime.MaxValue
				};
				MapGatewayProcess.上方宫门 = new MonsterObject(MapGatewayProcess.上方宫门.Template, MapGatewayProcess.沙城地图, int.MaxValue, new Point[]
				{
					MapGatewayProcess.皇宫上门坐标
				}, true, true)
				{
					CurrentDirection = GameDirection.右下,
					存活时间 = DateTime.MaxValue
				};
				MapGatewayProcess.下方宫门 = new MonsterObject(MapGatewayProcess.下方宫门.Template, MapGatewayProcess.沙城地图, int.MaxValue, new Point[]
				{
					MapGatewayProcess.皇宫下门坐标
				}, true, true)
				{
					CurrentDirection = GameDirection.右下,
					存活时间 = DateTime.MaxValue
				};
				MapGatewayProcess.左方宫门 = new MonsterObject(MapGatewayProcess.左方宫门.Template, MapGatewayProcess.沙城地图, int.MaxValue, new Point[]
				{
					MapGatewayProcess.皇宫左门坐标
				}, true, true)
				{
					CurrentDirection = GameDirection.左下,
					存活时间 = DateTime.MaxValue
				};
				MapGatewayProcess.沙城城门.OnAddBuff(22300, MapGatewayProcess.沙城城门);
				MapGatewayProcess.上方宫门.OnAddBuff(22300, MapGatewayProcess.上方宫门);
				MapGatewayProcess.下方宫门.OnAddBuff(22300, MapGatewayProcess.下方宫门);
				MapGatewayProcess.左方宫门.OnAddBuff(22300, MapGatewayProcess.左方宫门);
				MapGatewayProcess.八卦坛激活行会 = null;
				MapGatewayProcess.八卦坛激活计时 = DateTime.MaxValue;
				GuardObject GuardInstance = MapGatewayProcess.八卦坛激活法阵;
				if (GuardInstance != null)
				{
					GuardInstance.Delete();
				}
				MapGatewayProcess.八卦坛激活法阵 = null;
				MapGatewayProcess.攻城行会.Clear();
				MapGatewayProcess.沙城节点 = 0;
			}
		}

		
		public static void Process()
		{
			foreach (KeyValuePair<int, MapObject> keyValuePair in MapGatewayProcess.ActiveObjects)
			{
				MapObject value = keyValuePair.Value;
				if (value != null)
				{
					value.Process();
				}
			}
			if (MapGatewayProcess.对象表计数 >= MapGatewayProcess.SecondaryObjects.Count)
			{
				MapGatewayProcess.对象表计数 = 0;
				MapGatewayProcess.SecondaryObjects = MapGatewayProcess.对象备份表;
				MapGatewayProcess.对象备份表 = new List<MapObject>();
			}
			int num = 0;
			while (num < 100 && MapGatewayProcess.对象表计数 < MapGatewayProcess.SecondaryObjects.Count)
			{
				if (MapGatewayProcess.SecondaryObjects[MapGatewayProcess.对象表计数].SecondaryObject)
				{
					MapGatewayProcess.SecondaryObjects[MapGatewayProcess.对象表计数].Process();
					MapGatewayProcess.对象备份表.Add(MapGatewayProcess.SecondaryObjects[MapGatewayProcess.对象表计数]);
				}
				MapGatewayProcess.对象表计数++;
				num++;
			}
			while (!MapGatewayProcess.移除激活表.IsEmpty)
			{
				MapObject MapObject;
				if (MapGatewayProcess.移除激活表.TryDequeue(out MapObject) && !MapObject.ActiveObject)
				{
					MapGatewayProcess.ActiveObjects.Remove(MapObject.ObjectId);
				}
			}
			while (!MapGatewayProcess.添加激活表.IsEmpty)
			{
				MapObject MapObject2;
				if (MapGatewayProcess.添加激活表.TryDequeue(out MapObject2) && MapObject2.ActiveObject && !MapGatewayProcess.ActiveObjects.ContainsKey(MapObject2.ObjectId))
				{
					MapGatewayProcess.ActiveObjects.Add(MapObject2.ObjectId, MapObject2);
				}
			}
			if (MainProcess.CurrentTime.Minute == 55 && MainProcess.CurrentTime.Hour != MapGatewayProcess.通知时间.Hour)
			{
				if (MainProcess.CurrentTime.Hour + 1 == (int)Config.武斗场时间一 || MainProcess.CurrentTime.Hour + 1 == (int)Config.武斗场时间二)
				{
					NetworkServiceGateway.SendAnnouncement("The Experience Arena will open in five minutes, so get ready if you want to participate!", true);
				}
				MapGatewayProcess.通知时间 = MainProcess.CurrentTime;
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

		
		public static void Start()
		{
			MapGatewayProcess.SecondaryObjects = new List<MapObject>();
			MapGatewayProcess.对象备份表 = new List<MapObject>();
			MapGatewayProcess.副本实例表 = new HashSet<MapInstance>();
			MapGatewayProcess.副本移除表 = new ConcurrentQueue<MapInstance>();
			MapGatewayProcess.添加激活表 = new ConcurrentQueue<MapObject>();
			MapGatewayProcess.移除激活表 = new ConcurrentQueue<MapObject>();
			MapGatewayProcess.ActiveObjects = new Dictionary<int, MapObject>();
			MapGatewayProcess.Objects = new Dictionary<int, MapObject>();
			MapGatewayProcess.MapInstance表 = new Dictionary<int, MapInstance>();
			MapGatewayProcess.玩家对象表 = new Dictionary<int, PlayerObject>();
			MapGatewayProcess.怪物对象表 = new Dictionary<int, MonsterObject>();
			MapGatewayProcess.宠物对象表 = new Dictionary<int, PetObject>();
			MapGatewayProcess.守卫对象表 = new Dictionary<int, GuardObject>();
			MapGatewayProcess.物品对象表 = new Dictionary<int, ItemObject>();
			MapGatewayProcess.陷阱对象表 = new Dictionary<int, TrapObject>();
			foreach (GameMap 游戏地图 in GameMap.DataSheet.Values)
			{
				MapGatewayProcess.MapInstance表.Add((int)(游戏地图.MapId * 16 + 1), new MapInstance(游戏地图, 16777217));
			}
			foreach (Terrains 地形数据 in Terrains.DataSheet.Values)
			{
				foreach (MapInstance MapInstance in MapGatewayProcess.MapInstance表.Values)
				{
					if (MapInstance.MapId == (int)地形数据.MapId)
					{
						MapInstance.地形数据 = 地形数据;
						MapInstance.MapObject = new HashSet<MapObject>[MapInstance.MapSize.X, MapInstance.MapSize.Y];
						for (int i = 0; i < MapInstance.MapSize.X; i++)
						{
							for (int j = 0; j < MapInstance.MapSize.Y; j++)
							{
								MapInstance.MapObject[i, j] = new HashSet<MapObject>();
							}
						}
					}
				}
			}
			foreach (MapAreas 地图区域 in MapAreas.DataSheet)
			{
				foreach (MapInstance MapInstance2 in MapGatewayProcess.MapInstance表.Values)
				{
					if (MapInstance2.MapId == (int)地图区域.FromMapId)
					{
						if (地图区域.AreaType == AreaType.复活区域)
						{
							MapInstance2.复活区域 = 地图区域;
						}
						if (地图区域.AreaType == AreaType.红名区域)
						{
							MapInstance2.红名区域 = 地图区域;
						}
						if (地图区域.AreaType == AreaType.传送区域)
						{
							MapInstance2.传送区域 = 地图区域;
						}
						MapInstance2.地图区域.Add(地图区域);
						break;
					}
				}
			}
			foreach (TeleportGates 传送法阵 in TeleportGates.DataSheet)
			{
				foreach (MapInstance MapInstance3 in MapGatewayProcess.MapInstance表.Values)
				{
					if (MapInstance3.MapId == (int)传送法阵.FromMapId)
					{
						MapInstance3.法阵列表.Add(传送法阵.TeleportGateNumber, 传送法阵);
					}
				}
			}
			foreach (MapGuards 守卫刷新 in MapGuards.DataSheet)
			{
				foreach (MapInstance MapInstance4 in MapGatewayProcess.MapInstance表.Values)
				{
					if (MapInstance4.MapId == (int)守卫刷新.FromMapId)
					{
						MapInstance4.守卫区域.Add(守卫刷新);
					}
				}
			}
			foreach (MonsterSpawns 怪物刷新 in MonsterSpawns.DataSheet)
			{
				foreach (MapInstance MapInstance5 in MapGatewayProcess.MapInstance表.Values)
				{
					if (MapInstance5.MapId == (int)怪物刷新.FromMapId)
					{
						MapInstance5.怪物区域.Add(怪物刷新);
					}
				}
			}
			foreach (MapInstance MapInstance6 in MapGatewayProcess.MapInstance表.Values)
			{
				if (!MapInstance6.CopyMap)
				{
					foreach (MonsterSpawns 怪物刷新2 in MapInstance6.怪物区域)
					{
						if (怪物刷新2.Spawns != null)
						{
							Point[] 出生范围 = 怪物刷新2.RangeCoords.ToArray<Point>();
							foreach (MonsterSpawnInfo 刷新信息 in 怪物刷新2.Spawns)
							{
								Monsters 游戏怪物;
								if (Monsters.DataSheet.TryGetValue(刷新信息.MonsterName, out 游戏怪物))
								{
									MainForm.添加怪物数据(游戏怪物);
									int RevivalInterval = 刷新信息.RevivalInterval * 60 * 1000;
									for (int l = 0; l < 刷新信息.SpawnCount; l++)
									{
										new MonsterObject(游戏怪物, MapInstance6, RevivalInterval, 出生范围, false, true);
									}
								}
							}
						}
					}
					using (HashSet<MapGuards>.Enumerator enumerator6 = MapInstance6.守卫区域.GetEnumerator())
					{
						while (enumerator6.MoveNext())
						{
							MapGuards 守卫刷新2 = enumerator6.Current;
							Guards 对应模板;
							if (Guards.DataSheet.TryGetValue(守卫刷新2.GuardNumber, out 对应模板))
							{
								new GuardObject(对应模板, MapInstance6, 守卫刷新2.Direction, 守卫刷新2.FromCoords);
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
				MapInstance6.TotalMobs = (uint)MapInstance6.怪物区域.Sum((MonsterSpawns O) => O.Spawns.Sum((MonsterSpawnInfo X) => X.SpawnCount));
				goto IL_5DE;
			}
		}

		
		public static void CleanUp()
		{
			foreach (ItemObject ItemObject in MapGatewayProcess.物品对象表.Values)
			{
				ItemData ItemData = ItemObject.ItemData;
				if (ItemData != null)
				{
					ItemData.Delete();
				}
			}
			foreach (KeyValuePair<int, GameStore> keyValuePair in GameStore.DataSheet)
			{
				foreach (ItemData ItemData2 in keyValuePair.Value.AvailableItems)
				{
					ItemData2.Delete();
				}
			}
		}

		
		public static void 添加MapObject(MapObject 当前对象)
		{
			MapGatewayProcess.Objects.Add(当前对象.ObjectId, 当前对象);
			GameObjectType 对象类型 = 当前对象.ObjectType;
			if (对象类型 <= GameObjectType.NPC)
			{
				switch (对象类型)
				{
				case GameObjectType.Player:
					MapGatewayProcess.玩家对象表.Add(当前对象.ObjectId, (PlayerObject)当前对象);
					return;
				case GameObjectType.Pet:
					MapGatewayProcess.宠物对象表.Add(当前对象.ObjectId, (PetObject)当前对象);
					return;
				case (GameObjectType)3:
					break;
				case GameObjectType.Monster:
					MapGatewayProcess.怪物对象表.Add(当前对象.ObjectId, (MonsterObject)当前对象);
					return;
				default:
					if (对象类型 != GameObjectType.NPC)
					{
						return;
					}
					MapGatewayProcess.守卫对象表.Add(当前对象.ObjectId, (GuardObject)当前对象);
					return;
				}
			}
			else
			{
				if (对象类型 == GameObjectType.Item)
				{
					MapGatewayProcess.物品对象表.Add(当前对象.ObjectId, (ItemObject)当前对象);
					return;
				}
				if (对象类型 != GameObjectType.Trap)
				{
					return;
				}
				MapGatewayProcess.陷阱对象表.Add(当前对象.ObjectId, (TrapObject)当前对象);
			}
		}

		
		public static void RemoveObject(MapObject 当前对象)
		{
			MapGatewayProcess.Objects.Remove(当前对象.ObjectId);
			GameObjectType 对象类型 = 当前对象.ObjectType;
			if (对象类型 <= GameObjectType.NPC)
			{
				switch (对象类型)
				{
				case GameObjectType.Player:
					MapGatewayProcess.玩家对象表.Remove(当前对象.ObjectId);
					return;
				case GameObjectType.Pet:
					MapGatewayProcess.宠物对象表.Remove(当前对象.ObjectId);
					return;
				case (GameObjectType)3:
					break;
				case GameObjectType.Monster:
					MapGatewayProcess.怪物对象表.Remove(当前对象.ObjectId);
					return;
				default:
					if (对象类型 != GameObjectType.NPC)
					{
						return;
					}
					MapGatewayProcess.守卫对象表.Remove(当前对象.ObjectId);
					return;
				}
			}
			else
			{
				if (对象类型 == GameObjectType.Item)
				{
					MapGatewayProcess.物品对象表.Remove(当前对象.ObjectId);
					return;
				}
				if (对象类型 != GameObjectType.Trap)
				{
					return;
				}
				MapGatewayProcess.陷阱对象表.Remove(当前对象.ObjectId);
			}
		}

		
		public static void 添加激活对象(MapObject 当前对象)
		{
			MapGatewayProcess.添加激活表.Enqueue(当前对象);
		}

		
		public static void RemoveActiveObject(MapObject 当前对象)
		{
			MapGatewayProcess.移除激活表.Enqueue(当前对象);
		}

		
		public static void AddSecondaryObject(MapObject 当前对象)
		{
			MapGatewayProcess.对象备份表.Add(当前对象);
		}

		
		public static MapInstance 分配地图(int MapId)
		{
			MapInstance result;
			if (MapGatewayProcess.MapInstance表.TryGetValue(MapId * 16 + 1, out result))
			{
				return result;
			}
			return null;
		}

		
		static MapGatewayProcess()
		{
			
			MapGatewayProcess.对象编号 = 268435456;
			MapGatewayProcess.TrapId = 1073741824;
			MapGatewayProcess.Id = 1342177280;
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

		
		public static int 对象表计数;

		
		public static List<MapObject> SecondaryObjects;

		
		public static List<MapObject> 对象备份表;

		
		public static Dictionary<int, MapObject> ActiveObjects;

		
		public static Dictionary<int, MapObject> Objects;

		
		public static Dictionary<int, PlayerObject> 玩家对象表;

		
		public static Dictionary<int, PetObject> 宠物对象表;

		
		public static Dictionary<int, MonsterObject> 怪物对象表;

		
		public static Dictionary<int, GuardObject> 守卫对象表;

		
		public static Dictionary<int, ItemObject> 物品对象表;

		
		public static Dictionary<int, TrapObject> 陷阱对象表;

		
		public static Dictionary<int, MapInstance> MapInstance表;

		
		public static HashSet<MapInstance> 副本实例表;

		
		private static ConcurrentQueue<MapInstance> 副本移除表;

		
		private static ConcurrentQueue<MapObject> 添加激活表;

		
		private static ConcurrentQueue<MapObject> 移除激活表;

		
		public static int 对象编号;

		
		public static int TrapId;

		
		public static int Id;

		
		private static DateTime 沙城处理计时;

		
		public static Point 沙城城门坐标;

		
		public static Point 皇宫下门坐标;

		
		public static Point 皇宫下门出口;

		
		public static Point 皇宫下门入口;

		
		public static Point 皇宫左门坐标;

		
		public static Point 皇宫左门出口;

		
		public static Point 皇宫左门入口;

		
		public static Point 皇宫上门坐标;

		
		public static Point 皇宫上门出口;

		
		public static Point 皇宫上门入口;

		
		public static Point 皇宫出口点一;

		
		public static Point 皇宫出口点二;

		
		public static Point 皇宫正门入口;

		
		public static Point 皇宫正门出口;

		
		public static Point 皇宫入口点左;

		
		public static Point 皇宫入口点中;

		
		public static Point 皇宫入口点右;

		
		public static Point 八卦坛坐标上;

		
		public static Point 八卦坛坐标下;

		
		public static Point 八卦坛坐标左;

		
		public static Point 八卦坛坐标右;

		
		public static Point 八卦坛坐标中;

		
		public static MapInstance 沙城地图;

		
		public static MonsterObject 沙城城门;

		
		public static MonsterObject 下方宫门;

		
		public static MonsterObject 上方宫门;

		
		public static MonsterObject 左方宫门;

		
		public static GuardObject 上方法阵;

		
		public static GuardObject 下方法阵;

		
		public static GuardObject 左方法阵;

		
		public static GuardObject 右方法阵;

		
		public static GuardObject 八卦坛激活法阵;

		
		public static GuildData 八卦坛激活行会;

		
		public static DateTime 八卦坛激活计时;

		
		public static MapAreas 皇宫随机区域;

		
		public static MapAreas 外城复活区域;

		
		public static MapAreas 内城复活区域;

		
		public static MapAreas 守方传送区域;

		
		public static byte 沙城节点;

		
		public static DateTime 通知时间;

		
		public static HashSet<GuildData> 攻城行会;
	}
}
