using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GameServer.Data;
using GameServer.Templates;
using GameServer.Networking;
using System.Diagnostics;
using System.Threading.Tasks;

namespace GameServer.Maps
{

  public static class MapGatewayProcess
  {
    private static bool _loadedSabakMonsters = false;

    public static int ObjectsCount;
    public static List<MapObject> SecondaryObjects;
    public static List<MapObject> BackupObjects;
    public static Dictionary<int, MapObject> ActiveObjects;
    public static Dictionary<int, MapObject> Objects;
    public static Dictionary<int, PlayerObject> Players;
    public static Dictionary<int, PetObject> Pets;
    public static Dictionary<int, MonsterObject> Monsters;
    public static Dictionary<int, GuardObject> NPCs;
    public static Dictionary<int, ItemObject> Items;
    public static Dictionary<int, TrapObject> Traps;
    public static Dictionary<int, ChestObject> Chests;
    public static Dictionary<int, MapInstance> MapInstances;
    public static HashSet<MapInstance> ReplicateInstances;
    private static ConcurrentQueue<MapInstance> ReplicasToRemove;
    private static ConcurrentQueue<MapObject> ObjectsToActivate;
    private static ConcurrentQueue<MapObject> ObjectsToDeactivate;

    public static int ObjectId;
    public static int TrapId;
    public static int MapInstanceId;
    private static DateTime SabakCityProcessTime;
    public static Point ShachengGateCoords;
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
    public static byte SabakStage;
    public static DateTime 通知时间;
    public static HashSet<GuildData> 攻城行会;


    private static void ProcessSabakCity()
    {
      if (MainProcess.CurrentTime < SabakCityProcessTime || (沙城地图 == null && _loadedSabakMonsters))
        return;

      SabakCityProcessTime = MainProcess.CurrentTime.AddMilliseconds(50.0);

      if (沙城地图 == null && !LoadSabakMonsters())
        return;

      foreach (var MapObject in 沙城地图[皇宫下门坐标])
      {
        if (!MapObject.Died && MapObject is PlayerObject PlayerObject && MainProcess.CurrentTime > PlayerObject.BusyTime)
          PlayerObject.玩家切换地图(沙城地图, AreaType.未知区域, 皇宫下门入口);
      }

      foreach (MapObject MapObject2 in 沙城地图[皇宫上门坐标])
      {
        if (!MapObject2.Died && MapObject2 is PlayerObject PlayerObject2 && MainProcess.CurrentTime > PlayerObject2.BusyTime)
          PlayerObject2.玩家切换地图(沙城地图, AreaType.未知区域, 皇宫上门入口);
      }

      foreach (MapObject MapObject3 in 沙城地图[皇宫左门坐标])
      {
        if (!MapObject3.Died && MapObject3 is PlayerObject PlayerObject3 && MainProcess.CurrentTime > PlayerObject3.BusyTime)
          PlayerObject3.玩家切换地图(沙城地图, AreaType.未知区域, 皇宫左门入口);
      }

      foreach (MapObject MapObject4 in 沙城地图[皇宫出口点一])
      {
        if (!MapObject4.Died && MapObject4 is PlayerObject PlayerObject4 && MainProcess.CurrentTime > PlayerObject4.BusyTime)
          PlayerObject4.玩家切换地图(沙城地图, AreaType.未知区域, 皇宫正门出口);
      }

      foreach (MapObject MapObject5 in 沙城地图[皇宫出口点二])
      {
        if (!MapObject5.Died && MapObject5 is PlayerObject PlayerObject5 && MainProcess.CurrentTime > PlayerObject5.BusyTime)
          PlayerObject5.玩家切换地图(沙城地图, AreaType.未知区域, 皇宫正门出口);
      }

      foreach (MapObject MapObject6 in 沙城地图[皇宫入口点左])
      {
        if (!MapObject6.Died && MapObject6 is PlayerObject PlayerObject6 && MainProcess.CurrentTime > PlayerObject6.BusyTime && PlayerObject6.Guild != null && PlayerObject6.Guild == SystemData.Data.OccupyGuild.V)
          PlayerObject6.玩家切换地图(沙城地图, AreaType.未知区域, 皇宫正门入口);
      }

      foreach (MapObject MapObject7 in 沙城地图[皇宫入口点中])
      {
        if (!MapObject7.Died && MapObject7 is PlayerObject PlayerObject7 && MainProcess.CurrentTime > PlayerObject7.BusyTime && PlayerObject7.Guild != null && PlayerObject7.Guild == SystemData.Data.OccupyGuild.V)
          PlayerObject7.玩家切换地图(沙城地图, AreaType.未知区域, 皇宫正门入口);
      }

      foreach (MapObject MapObject8 in 沙城地图[皇宫入口点右])
      {
        if (!MapObject8.Died && MapObject8 is PlayerObject PlayerObject8 && MainProcess.CurrentTime > PlayerObject8.BusyTime && PlayerObject8.Guild != null && PlayerObject8.Guild == SystemData.Data.OccupyGuild.V)
          PlayerObject8.玩家切换地图(沙城地图, AreaType.未知区域, 皇宫正门入口);
      }

      switch (SabakStage)
      {
        case 0:
          ProcessSabakStageWaitingToStart();
          break;
        case 1:
          ProcessSabakStage1();
          break;
        case 2:
          ProcessSabakStage2();
          break;
        case 3:
          ProcessSabakStage3();
          break;
      }
    }

    private static bool LoadSabakMonsters()
    {
      _loadedSabakMonsters = true;

      var loadedOk = false;

      if (MapInstances.TryGetValue(2433, out 沙城地图) && GameBuffs.DataSheet.TryGetValue(22300, out var 游戏Buff) && Templates.Monsters.DataSheet.TryGetValue("沙巴克城门", out var 对应模板) && Templates.Monsters.DataSheet.TryGetValue("沙巴克宫门", out var 对应模板2))
      {
        if ((皇宫随机区域 = 沙城地图.地图区域.FirstOrDefault((MapAreas O) => O.RegionName == "Shabak-Random areas of the Palace")) != null)
        {
          if ((外城复活区域 = 沙城地图.地图区域.FirstOrDefault((MapAreas O) => O.RegionName == "Shabak-Outer Resurrection Area")) != null)
          {
            if ((内城复活区域 = 沙城地图.地图区域.FirstOrDefault((MapAreas O) => O.RegionName == "Shabak-Resurrection Area Town")) != null)
            {
              if ((守方传送区域 = 沙城地图.地图区域.FirstOrDefault((MapAreas O) => O.RegionName == "Shabak-Safe Teleport")) != null)
              {
                沙城城门 = new MonsterObject(对应模板, 沙城地图, int.MaxValue, new Point[] { ShachengGateCoords }, true, true)
                {
                  CurrentDirection = GameDirection.右上,
                  存活时间 = DateTime.MaxValue
                };

                上方宫门 = new MonsterObject(对应模板2, 沙城地图, int.MaxValue, new Point[] { 皇宫上门坐标 }, true, true)
                {
                  CurrentDirection = GameDirection.右下,
                  存活时间 = DateTime.MaxValue
                };

                下方宫门 = new MonsterObject(对应模板2, 沙城地图, int.MaxValue, new Point[] { 皇宫下门坐标 }, true, true)
                {
                  CurrentDirection = GameDirection.右下,
                  存活时间 = DateTime.MaxValue
                };
                左方宫门 = new MonsterObject(对应模板2, 沙城地图, int.MaxValue, new Point[] { 皇宫左门坐标 }, true, true)
                {
                  CurrentDirection = GameDirection.左下,
                  存活时间 = DateTime.MaxValue
                };
                沙城城门.OnAddBuff(游戏Buff.Id, 沙城城门);
                上方宫门.OnAddBuff(游戏Buff.Id, 上方宫门);
                下方宫门.OnAddBuff(游戏Buff.Id, 下方宫门);
                左方宫门.OnAddBuff(游戏Buff.Id, 左方宫门);
                loadedOk = true;
              }
              else
              {
                MainProcess.AddSystemLog("[SABAK] Region 'Shabak-Safe Teleport' not found");
              }
            }
            else
            {
              MainProcess.AddSystemLog("[SABAK] Region 'Shabak-Resurrection Area Town' not found");
            }
          }
          else
          {
            MainProcess.AddSystemLog("[SABAK] Region 'Shabak-Outer Resurrection Area' not found");
          }
        }
        else
        {
          MainProcess.AddSystemLog("[SABAK] Region 'Shabak-Random areas of the Palace' not found");
        }
      }

      if (!loadedOk)
      {
        沙城地图 = null;
        MainProcess.AddSystemLog("Can not be loaded sabak monsters!");
      }

      return loadedOk;
    }

    private static void ProcessSabakStageWaitingToStart()
    {
      foreach (var keyValuePair in SystemData.Data.申请行会)
      {
        if (keyValuePair.Key.Date < MainProcess.CurrentTime.Date)
          SystemData.Data.申请行会.Remove(keyValuePair.Key);
      }

      if (SystemData.Data.申请行会.Count == 0)
        return;

      if (MainProcess.CurrentTime.Hour != 19 || MainProcess.CurrentTime.Minute != 50)
        return;

      foreach (var keyValuePair2 in SystemData.Data.申请行会)
      {
        if (keyValuePair2.Key.Date == MainProcess.CurrentTime.Date)
        {
          NetworkServiceGateway.SendAnnouncement("沙巴克攻城将于10分钟后开始，请各位做好准备!", true);
          SabakStage += 1;
          break;
        }
      }
    }

    private static void ProcessSabakStage1()
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
          MapGatewayProcess.SabakStage = 0;
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
        if (MapGatewayProcess.MapInstances.TryGetValue(2849, out MapInstance))
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
        NetworkServiceGateway.SendAnnouncement("沙巴克攻城开始了", true);
        MapGatewayProcess.SabakStage += 1;
        return;
      }
    }

    private static void ProcessSabakStage2()
    {
      if (MapGatewayProcess.沙城城门.Died && MapGatewayProcess.沙城城门.出生地图 != null)
      {
        NetworkServiceGateway.SendAnnouncement("沙巴克城门被攻破了", true);
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
            NetworkServiceGateway.SendAnnouncement(string.Format("沙巴克八卦祭坛传送点被[{0}]公会成功激活", GuildData2), true);
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
        NetworkServiceGateway.SendAnnouncement(string.Format("沙巴克之战已经结束，[{0}]已经成为新的沙巴克公会", GuildData3), true);
        MapGatewayProcess.八卦坛激活计时 = MainProcess.CurrentTime.AddMinutes(5.0);
        MapGatewayProcess.SabakStage += 1;
        return;
      }
      if (MainProcess.CurrentTime.Hour >= 21)
      {
        if (SystemData.Data.OccupyGuild.V == null)
        {
          NetworkServiceGateway.SendAnnouncement("沙巴克之战已经结束，沙巴克仍然没有主人", true);
        }
        else
        {
          NetworkServiceGateway.SendAnnouncement(string.Format("沙巴克攻城已经结束，沙巴克仍然被公会占领", SystemData.Data.OccupyGuild.V.GuildName), true);
        }
        if (SystemData.Data.OccupyGuild.V == null)
        {
          foreach (KeyValuePair<CharacterData, GuildJobs> keyValuePair5 in SystemData.Data.OccupyGuild.V.行会成员)
          {
            keyValuePair5.Key.攻沙日期.V = MainProcess.CurrentTime;
          }
        }
        MapGatewayProcess.八卦坛激活计时 = MainProcess.CurrentTime.AddMinutes(5.0);
        MapGatewayProcess.SabakStage += 1;
        return;
      }
    }

    private static void ProcessSabakStage3()
    {
      if (八卦坛激活计时 > MainProcess.CurrentTime) return;

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
                    MapGatewayProcess.ShachengGateCoords
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
      MapGatewayProcess.SabakStage = 0;
    }

    public static void Process()
    {
      foreach (var activeObject in ActiveObjects.Values)
        activeObject?.Process();

      if (ObjectsCount >= SecondaryObjects.Count)
      {
        ObjectsCount = 0;
        SecondaryObjects = BackupObjects;
        BackupObjects = new List<MapObject>();
      }

      int num = 0;
      while (num < 100 && ObjectsCount < SecondaryObjects.Count)
      {
        if (SecondaryObjects[ObjectsCount].SecondaryObject)
        {
          SecondaryObjects[ObjectsCount].Process();
          BackupObjects.Add(SecondaryObjects[ObjectsCount]);
        }
        ObjectsCount++;
        num++;
      }
      while (ObjectsToDeactivate.TryDequeue(out var MapObject) && !MapObject.ActiveObject)
        ActiveObjects.Remove(MapObject.ObjectId);

      while (ObjectsToActivate.TryDequeue(out var MapObject2) && MapObject2.ActiveObject && !ActiveObjects.ContainsKey(MapObject2.ObjectId))
        ActiveObjects.Add(MapObject2.ObjectId, MapObject2);

      if (MainProcess.CurrentTime.Minute == 55 && MainProcess.CurrentTime.Hour != 通知时间.Hour)
      {
        if (MainProcess.CurrentTime.Hour + 1 == (int)Config.武斗场时间一 || MainProcess.CurrentTime.Hour + 1 == Config.武斗场时间二)
        {
          NetworkServiceGateway.SendAnnouncement("武斗场将在五分钟后开放，如果您想参与，请做好准备!", true);
        }
        通知时间 = MainProcess.CurrentTime;
      }

      foreach (var MapInstance in ReplicateInstances)
      {
        if (MapInstance.副本关闭)
          ReplicasToRemove.Enqueue(MapInstance);
        else
          MapInstance.Process();
      }

      while (ReplicasToRemove.TryDequeue(out var item))
        ReplicateInstances.Remove(item);

      ProcessSabakCity();
    }

    private static void LoadContentTeleports()
    {
      var watcher = new Stopwatch();
      watcher.Start();

      foreach (TeleportGates 传送法阵 in TeleportGates.DataSheet)
      {
        var mapInstanceId = 传送法阵.FromMapId * 16 + 1;
        if (!MapInstances.ContainsKey(mapInstanceId)) continue;
        var mapInstance = MapInstances[mapInstanceId];

        if (!mapInstance.CopyMap)
          mapInstance.法阵列表.Add(传送法阵.TeleportGateNumber, 传送法阵);
      }

      watcher.Stop();
      MainForm.AddSystemLog($"Loaded teleport gates in {watcher.ElapsedMilliseconds}ms");
    }

    private static void LoadContentGuards()
    {
      var watcher = new Stopwatch();
      watcher.Start();

      foreach (MapGuards 守卫刷新 in MapGuards.DataSheet)
      {
        var mapInstanceId = 守卫刷新.FromMapId * 16 + 1;
        if (!MapInstances.ContainsKey(mapInstanceId)) continue;
        var mapInstance = MapInstances[mapInstanceId];

        mapInstance.守卫区域.Add(守卫刷新);

        if (!mapInstance.CopyMap && Guards.DataSheet.TryGetValue(守卫刷新.GuardNumber, out var 对应模板))
          new GuardObject(对应模板, mapInstance, 守卫刷新.Direction, 守卫刷新.FromCoords);
      }
      watcher.Stop();
      MainForm.AddSystemLog($"Loaded map guards in {watcher.ElapsedMilliseconds}ms");
    }

    private static void LoadContentChests()
    {
      var watcher = new Stopwatch();
      watcher.Start();

      foreach (var chest in MapChest.DataSheet)
      {
        var mapInstanceId = chest.MapId * 16 + 1;
        if (!MapInstances.ContainsKey(mapInstanceId)) continue;
        var map = MapInstances[mapInstanceId];

        map.Chests.Add(chest);

        if (!map.CopyMap && ChestTemplate.DataSheet.TryGetValue(chest.ChestId, out var chestTemplate))
          new ChestObject(chestTemplate, map, chest.Direction, chest.Coords);
      }

      watcher.Stop();
      MainForm.AddSystemLog($"Loaded map chests in {watcher.ElapsedMilliseconds}ms");
    }

    private static void ClearContentTeleports()
    {
      var watcher = new Stopwatch();
      watcher.Start();

      foreach (MapInstance mapInstance in MapInstances.Values)
        mapInstance.法阵列表.Clear();

      watcher.Stop();
      MainForm.AddSystemLog($"Clear teleports in {watcher.ElapsedMilliseconds}ms");
    }

    private static void ClearContentGuards()
    {
      var watcher = new Stopwatch();
      watcher.Start();

      var objs = NPCs.Values.ToArray();

      foreach (var obj in objs)
        obj.Delete();

      foreach (MapInstance mapInstance in MapInstances.Values)
        mapInstance.守卫区域.Clear();

      watcher.Stop();
      MainForm.AddSystemLog($"Clear guards in {watcher.ElapsedMilliseconds}ms");
    }

    private static void ClearContentChests()
    {
      var watcher = new Stopwatch();
      watcher.Start();

      var objs = Chests.Values.ToArray();

      foreach (var obj in objs)
        obj.Delete();

      foreach (MapInstance mapInstance in MapInstances.Values)
        mapInstance.Chests.Clear();

      watcher.Stop();
      MainForm.AddSystemLog($"Clear chests in {watcher.ElapsedMilliseconds}ms");
    }

    private static void ClearContentSpawns()
    {
      var watcher = new Stopwatch();
      watcher.Start();

      var objs = Monsters.Values.ToArray();

      foreach (var obj in objs)
        obj.Delete();

      foreach (MapInstance mapInstance in MapInstances.Values)
      {
        mapInstance.怪物区域.Clear();
        mapInstance.Initialized = false;
      }

      watcher.Stop();
      MainForm.AddSystemLog($"Clear monster spawns in {watcher.ElapsedMilliseconds}ms");
    }

    private static void LoadContentSpawns()
    {
      var watcher = new Stopwatch();
      watcher.Start();

      var instancesToInitialize = new List<MapInstance>();
      foreach (MonsterSpawns spawn in MonsterSpawns.DataSheet)
      {
        var mapInstanceId = spawn.FromMapId * 16 + 1;
        if (!MapInstances.ContainsKey(mapInstanceId)) continue;
        var mapInstance = MapInstances[mapInstanceId];

        mapInstance.怪物区域.Add(spawn);

        if (mapInstance.NrPlayers.Count > 0 && !instancesToInitialize.Contains(mapInstance))
          instancesToInitialize.Add(mapInstance);
      }

      foreach (var instance in instancesToInitialize)
        instance.Initialize();

      watcher.Stop();
      MainForm.AddSystemLog($"Loaded monster spawns in {watcher.ElapsedMilliseconds}ms");
    }

    public static void LoadContent()
    {
      var watcher = new Stopwatch();
      watcher.Start();

      LoadContentTeleports();
      LoadContentGuards();
      LoadContentChests();
      LoadContentSpawns();

      watcher.Stop();
      MainForm.AddSystemLog($"Initialized instances in {watcher.ElapsedMilliseconds}ms");
    }

    public static void ReloadContent()
    {
      NetworkServiceGateway.SendAnnouncement("用新内容更新服务器时，您可能会遇到延迟。", true);

      MainProcess.ReloadTasks.Enqueue(() => ClearContentTeleports());
      MainProcess.ReloadTasks.Enqueue(() => LoadContentTeleports());

      MainProcess.ReloadTasks.Enqueue(() => ClearContentGuards());
      MainProcess.ReloadTasks.Enqueue(() => LoadContentGuards());

      MainProcess.ReloadTasks.Enqueue(() => ClearContentChests());
      MainProcess.ReloadTasks.Enqueue(() => LoadContentChests());

      MainProcess.ReloadTasks.Enqueue(() => ClearContentSpawns());
      MainProcess.ReloadTasks.Enqueue(() => LoadContentSpawns());
    }

    public static void Start()
    {
      MapGatewayProcess.SecondaryObjects = new List<MapObject>();
      MapGatewayProcess.BackupObjects = new List<MapObject>();
      MapGatewayProcess.ReplicateInstances = new HashSet<MapInstance>();
      MapGatewayProcess.ReplicasToRemove = new ConcurrentQueue<MapInstance>();
      MapGatewayProcess.ObjectsToActivate = new ConcurrentQueue<MapObject>();
      MapGatewayProcess.ObjectsToDeactivate = new ConcurrentQueue<MapObject>();
      MapGatewayProcess.ActiveObjects = new Dictionary<int, MapObject>();
      MapGatewayProcess.Objects = new Dictionary<int, MapObject>();
      MapGatewayProcess.MapInstances = new Dictionary<int, MapInstance>();
      MapGatewayProcess.Players = new Dictionary<int, PlayerObject>();
      MapGatewayProcess.Monsters = new Dictionary<int, MonsterObject>();
      MapGatewayProcess.Pets = new Dictionary<int, PetObject>();
      MapGatewayProcess.NPCs = new Dictionary<int, GuardObject>();
      MapGatewayProcess.Items = new Dictionary<int, ItemObject>();
      MapGatewayProcess.Traps = new Dictionary<int, TrapObject>();
      MapGatewayProcess.Chests = new Dictionary<int, ChestObject>();

      var watcher = new Stopwatch();

      watcher.Start();
      foreach (GameMap 游戏地图 in GameMap.DataSheet.Values)
      {
        MapInstances.Add((int)(游戏地图.MapId * 16 + 1), new MapInstance(游戏地图, 16777217));
      }
      watcher.Stop();
      MainForm.AddSystemLog($"Loaded map instances in {watcher.ElapsedMilliseconds}ms");

      watcher.Restart();
      foreach (Terrains 地形数据 in Terrains.DataSheet.Values)
      {
        var istanceId = (int)(地形数据.MapId * 16 + 1);

        if (!MapInstances.TryGetValue(istanceId, out var instance))
          continue;

        instance.地形数据 = 地形数据;
        instance.MapObject = new HashSet<MapObject>[instance.MapSize.X, instance.MapSize.Y];
        for (int i = 0; i < instance.MapSize.X; i++)
        {
          for (int j = 0; j < instance.MapSize.Y; j++)
          {
            instance.MapObject[i, j] = new HashSet<MapObject>();
          }
        }
      }
      watcher.Stop();
      MainForm.AddSystemLog($"Loaded terrains in {watcher.ElapsedMilliseconds}ms");

      watcher.Restart();
      foreach (MapAreas 地图区域 in MapAreas.DataSheet)
      {
        foreach (MapInstance MapInstance2 in MapInstances.Values)
        {
          if (MapInstance2.MapId == (int)地图区域.FromMapId)
          {
            if (地图区域.AreaType == AreaType.复活区域)
            {
              MapInstance2.ResurrectionArea = 地图区域;
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
      watcher.Stop();
      MainForm.AddSystemLog($"Loaded map areas in {watcher.ElapsedMilliseconds}ms");

      LoadContent();
    }


    public static void CleanUp()
    {
      foreach (ItemObject ItemObject in MapGatewayProcess.Items.Values)
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


    public static void AddObject(MapObject obj)
    {
      Objects.Add(obj.ObjectId, obj);

      switch (obj.ObjectType)
      {
        case GameObjectType.Player:
          Players.Add(obj.ObjectId, (PlayerObject)obj);
          return;
        case GameObjectType.Pet:
          Pets.Add(obj.ObjectId, (PetObject)obj);
          return;
        case GameObjectType.Monster:
          Monsters.TryAdd(obj.ObjectId, (MonsterObject)obj);
          return;
        case GameObjectType.NPC:
          NPCs.TryAdd(obj.ObjectId, (GuardObject)obj);
          return;
        case GameObjectType.Item:
          Items.Add(obj.ObjectId, (ItemObject)obj);
          return;
        case GameObjectType.Trap:
          Traps.TryAdd(obj.ObjectId, (TrapObject)obj);
          return;
        case GameObjectType.Chest:
          Chests.TryAdd(obj.ObjectId, (ChestObject)obj);
          return;
        default:
          throw new NotImplementedException();
      }
    }


    public static void RemoveObject(MapObject obj)
    {
      Objects.Remove(obj.ObjectId, out var removed);

      switch (obj.ObjectType)
      {
        case GameObjectType.Player:
          Players.Remove(obj.ObjectId);
          return;
        case GameObjectType.Pet:
          Pets.Remove(obj.ObjectId);
          return;
        case GameObjectType.Monster:
          Monsters.Remove(obj.ObjectId, out var monsterRemoved);
          return;
        case GameObjectType.NPC:
          NPCs.Remove(obj.ObjectId, out var guardRemoved);
          return;
        case GameObjectType.Item:
          Items.Remove(obj.ObjectId);
          return;
        case GameObjectType.Trap:
          Traps.Remove(obj.ObjectId, out var trapRemoved);
          return;
        case GameObjectType.Chest:
          Chests.Remove(obj.ObjectId, out var chestRemoved);
          return;
        default:
          throw new NotImplementedException();
      }
    }


    public static void ActivateObject(MapObject 当前对象) => ObjectsToActivate.Enqueue(当前对象);
    public static void DeactivateObject(MapObject 当前对象) => ObjectsToDeactivate.Enqueue(当前对象);
    public static void AddSecondaryObject(MapObject 当前对象) => BackupObjects.Add(当前对象);

    public static MapInstance GetMapInstance(int MapId)
    {
      if (MapInstances.TryGetValue(MapId * 16 + 1, out var result))
        return result;
      return null;
    }


    static MapGatewayProcess()
    {
      ObjectId = 268435456;
      TrapId = 1073741824;
      MapInstanceId = 1342177280;
      ShachengGateCoords = new Point(1020, 506);
      皇宫下门坐标 = new Point(1079, 557);
      皇宫下门出口 = new Point(1078, 556);
      皇宫下门入口 = new Point(1265, 773);
      皇宫左门坐标 = new Point(1082, 557);
      皇宫左门出口 = new Point(1083, 556);
      皇宫左门入口 = new Point(1266, 773);
      皇宫上门坐标 = new Point(1071, 565);
      皇宫上门出口 = new Point(1070, 564);
      皇宫上门入口 = new Point(1254, 784);
      皇宫出口点一 = new Point(1257, 777);
      皇宫出口点二 = new Point(1258, 776);
      皇宫正门入口 = new Point(1258, 777);
      皇宫正门出口 = new Point(1074, 560);
      皇宫入口点左 = new Point(1076, 560);
      皇宫入口点中 = new Point(1075, 561);
      皇宫入口点右 = new Point(1074, 562);
      八卦坛坐标上 = new Point(1059, 591);
      八卦坛坐标下 = new Point(1054, 586);
      八卦坛坐标左 = new Point(1059, 586);
      八卦坛坐标右 = new Point(1054, 591);
      八卦坛坐标中 = new Point(1056, 588);
      八卦坛激活计时 = DateTime.MaxValue;
      攻城行会 = new HashSet<GuildData>();
    }
  }
}
