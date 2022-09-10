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

        public byte 地图状态
        {
            get
            {
                if (this.NrPlayers.Count < 200)
                {
                    return 1;
                }
                if (this.NrPlayers.Count < 500)
                {
                    return 2;
                }
                return 3;
            }
        }


        public int MapId
        {
            get
            {
                return (int)this.地图模板.MapId;
            }
        }


        public byte MinLevel
        {
            get
            {
                return this.地图模板.MinLevel;
            }
        }


        public byte LimitInstances
        {
            get
            {
                return 1;
            }
        }


        public bool NoReconnect
        {
            get
            {
                return this.地图模板.NoReconnect;
            }
        }


        public byte NoReconnectMapId
        {
            get
            {
                return this.地图模板.NoReconnectMapId;
            }
        }


        public bool CopyMap
        {
            get
            {
                return this.地图模板.CopyMap;
            }
        }


        public Point StartPoint
        {
            get
            {
                return this.地形数据.StartPoint;
            }
        }


        public Point EndPoint
        {
            get
            {
                return this.地形数据.EndPoint;
            }
        }


        public Point MapSize
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
            this.Chests = new HashSet<MapChest>();
            this.NrPlayers = new HashSet<PlayerObject>();
            this.宠物列表 = new HashSet<PetObject>();
            this.物品列表 = new HashSet<ItemObject>();
            this.对象列表 = new HashSet<MapObject>();
            this.法阵列表 = new Dictionary<byte, TeleportGates>();

            this.地图模板 = 地图模板;
            this.路线编号 = 路线编号;
        }

        private void ProcessDemonSlayingHall()
        {
            if (this.MapId == 80)
            {
                if (this.NrPlayers.Count == 0)
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
                    if (this.副本守卫.Died)
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
                    if (this.副本守卫.Died)
                    {
                        this.副本节点 = 100;
                        this.节点计时 = MainProcess.CurrentTime;
                        return;
                    }
                    if (this.MobsAlive == 0U)
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
                    foreach (PlayerObject PlayerObject in this.NrPlayers.ToList<PlayerObject>())
                    {
                        if (PlayerObject.Died)
                        {
                            PlayerObject.玩家请求复活();
                        }
                        else
                        {
                            PlayerObject.玩家切换地图(MapGatewayProcess.GetMapInstance(PlayerObject.重生地图), AreaType.复活区域, default(Point));
                        }
                    }
                    foreach (PetObject PetObject in this.宠物列表.ToList<PetObject>())
                    {
                        if (PetObject.Died)
                        {
                            PetObject.Delete();
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
                        MapObject.Delete();
                    }
                    this.副本关闭 = true;
                }
            }
        }

        public void Process()
        {
            ProcessDemonSlayingHall();
        }


        public void 添加对象(MapObject 对象)
        {
            GameObjectType 对象类型 = 对象.ObjectType;
            if (对象类型 == GameObjectType.Player)
            {
                this.NrPlayers.Add(对象 as PlayerObject);
                return;
            }
            if (对象类型 == GameObjectType.Pet)
            {
                this.宠物列表.Add(对象 as PetObject);
                return;
            }
            if (对象类型 != GameObjectType.Item)
            {
                this.对象列表.Add(对象);
                return;
            }
            this.物品列表.Add(对象 as ItemObject);
        }


        public void 移除对象(MapObject 对象)
        {
            GameObjectType 对象类型 = 对象.ObjectType;
            if (对象类型 == GameObjectType.Player)
            {
                this.NrPlayers.Remove(对象 as PlayerObject);
                return;
            }
            if (对象类型 == GameObjectType.Pet)
            {
                this.宠物列表.Remove(对象 as PetObject);
                return;
            }
            if (对象类型 != GameObjectType.Item)
            {
                this.对象列表.Remove(对象);
                return;
            }
            this.物品列表.Remove(对象 as ItemObject);
        }


        public void 地图公告(string 内容)
        {
            if (this.NrPlayers.Count == 0)
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
                    foreach (PlayerObject PlayerObject in this.NrPlayers)
                    {
                        SConnection 网络连接 = PlayerObject.ActiveConnection;
                        if (网络连接 != null)
                        {
                            网络连接.SendPacket(new ReceiveChatMessagesPacket
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
                if (this.MapObject[坐标.X - this.StartPoint.X, 坐标.Y - this.StartPoint.Y] == null)
                {
                    return this.MapObject[坐标.X - this.StartPoint.X, 坐标.Y - this.StartPoint.Y] = new HashSet<MapObject>();
                }
                return this.MapObject[坐标.X - this.StartPoint.X, 坐标.Y - this.StartPoint.Y];
            }
        }


        public Point 随机坐标(AreaType 区域)
        {
            if (区域 == AreaType.复活区域)
            {
                return this.ResurrectionArea.RandomCoords;
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
            return 坐标.X < this.StartPoint.X || 坐标.Y < this.StartPoint.Y || 坐标.X >= this.EndPoint.X || 坐标.Y >= this.EndPoint.Y;
        }


        public bool CellBlocked(Point 坐标)
        {
            if (this.IsSafeZone(坐标))
            {
                return false;
            }

            var objs = this[坐标];

            foreach (var obj in objs)
            {
                if (obj.Blocking)
                    return true;
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
                    if (enumerator.Current.Blocking)
                    {
                        num++;
                    }
                }
            }
            return num;
        }


        public bool IsBlocked(Point 坐标)
        {
            return this.坐标越界(坐标) || (this.地形数据[坐标] & 268435456U) != 268435456U;
        }


        public bool CanPass(Point 坐标)
        {
            return !this.IsBlocked(坐标) && !this.CellBlocked(坐标);
        }


        public ushort GetTerrainHeight(Point 坐标)
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
                if (this.IsBlocked(ComputingClass.GetFrontPosition(起点, 终点, i)))
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


        public bool IsSafeZone(Point 坐标)
        {
            return !this.坐标越界(坐标) && ((this.地形数据[坐标] & 262144U) == 262144U || (this.地形数据[坐标] & 1048576U) == 1048576U);
        }


        public bool 摆摊区内(Point 坐标)
        {
            return !this.坐标越界(坐标) && (this.地形数据[坐标] & 1048576U) == 1048576U;
        }


        public bool 掉落装备(Point 坐标, bool 红名)
        {
            return (MapGatewayProcess.SabakStage < 2 || (this.MapId != 152 && this.MapId != 178)) && !this.坐标越界(坐标) && ((this.地形数据[坐标] & 4194304U) == 4194304U || ((this.地形数据[坐标] & 8388608U) == 8388608U && 红名));
        }


        public readonly int 路线编号;


        public readonly GameMap 地图模板;


        public uint TotalMobs;


        public uint MobsAlive;


        public uint MobsRespawned;


        public long MobsDrops;


        public long MobGoldDrop;


        public bool 副本关闭;


        public byte 副本节点;


        public GuardObject 副本守卫;


        public DateTime 节点计时;


        public int 刷怪记录;


        public List<MonsterSpawns> 怪物波数;


        public HashSet<MapObject>[,] MapObject;


        public Terrains 地形数据;


        public MapAreas ResurrectionArea;


        public MapAreas 红名区域;


        public MapAreas 传送区域;


        public HashSet<MapAreas> 地图区域;


        public HashSet<MonsterSpawns> 怪物区域;


        public HashSet<MapGuards> 守卫区域;

        public HashSet<MapChest> Chests;


        public HashSet<PlayerObject> NrPlayers;


        public HashSet<PetObject> 宠物列表;


        public HashSet<ItemObject> 物品列表;


        public HashSet<MapObject> 对象列表;


        public Dictionary<byte, TeleportGates> 法阵列表;
    }
}
