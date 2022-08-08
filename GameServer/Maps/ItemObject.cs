using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GameServer.Data;
using GameServer.Templates;

namespace GameServer.Maps
{

    public sealed class ItemObject : MapObject
    {

        public override MapInstance CurrentMap
        {
            get
            {
                return base.CurrentMap;
            }
            set
            {
                if (this.CurrentMap != value)
                {
                    MapInstance CurrentMap = base.CurrentMap;
                    if (CurrentMap != null)
                    {
                        CurrentMap.移除对象(this);
                    }
                    base.CurrentMap = value;
                    base.CurrentMap.添加对象(this);
                }
            }
        }


        public override int 处理间隔
        {
            get
            {
                return 100;
            }
        }


        public override bool Died
        {
            get
            {
                return false;
            }
        }


        public override bool 阻塞网格
        {
            get
            {
                return false;
            }
        }


        public override bool CanBeHit
        {
            get
            {
                return false;
            }
        }


        public override GameObjectType ObjectType
        {
            get
            {
                return GameObjectType.物品;
            }
        }


        public override MonsterSize 对象体型
        {
            get
            {
                return MonsterSize.Single1x1;
            }
        }


        public PersistentItemType PersistType
        {
            get
            {
                return this.物品模板.PersistType;
            }
        }


        public int 默认持久
        {
            get
            {
                return this.物品模板.MaxDura;
            }
        }


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


        public bool 允许堆叠
        {
            get
            {
                return this.物品模板.PersistType == PersistentItemType.堆叠;
            }
        }

        public int DropperObjectId
        {
            get
            {
                return DropperObject?.ObjectId ?? ObjectId;
            }
        }

        public ItemObject(GameItems 物品模板, ItemData ItemData, MapInstance 掉落地图, Point 掉落坐标, HashSet<CharacterData> 物品归属, int 堆叠数量 = 0, bool 物品绑定 = false, MapObject dropperObject = null)
        {
            this.DropperObject = dropperObject;
            this.物品归属 = 物品归属;
            this.物品模板 = 物品模板;
            this.ItemData = ItemData;
            this.CurrentMap = 掉落地图;
            this.ItemData = ItemData;
            this.堆叠数量 = 堆叠数量;
            this.物品绑定 = (物品模板.IsBound || 物品绑定);

            int num = int.MaxValue;
            for (int i = 0; i <= 120; i++)
            {
                int num2 = 0;
                Point point = ComputingClass.螺旋坐标(掉落坐标, i);
                if (!掉落地图.地形阻塞(point))
                {
                    foreach (MapObject MapObject in 掉落地图[point])
                    {
                        if (!MapObject.Died)
                        {
                            GameObjectType 对象类型 = MapObject.ObjectType;
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
                        CurrentCoords = point;
                    IL_111:
                        this.CurrentCoords = CurrentCoords;
                        this.消失时间 = MainProcess.CurrentTime.AddMinutes((double)Config.物品清理时间);
                        this.归属时间 = MainProcess.CurrentTime.AddMinutes((double)Config.物品归属时间);
                        this.ObjectId = ++MapGatewayProcess.Id;
                        base.绑定网格();
                        base.更新邻居时处理();
                        MapGatewayProcess.添加MapObject(this);
                        this.次要对象 = true;
                        MapGatewayProcess.添加次要对象(this);
                        return;
                    }
                    if (num2 < num)
                    {
                        CurrentCoords = point;
                        num = num2;
                    }
                }
            }
            //goto IL_111;
        }

        public int GetOwnerPlayerIdForDrop(PlayerObject playerAppearing)
        {
            return 物品归属 == null || 物品归属.Contains(playerAppearing.CharacterData)
                ? playerAppearing.CharacterData.Id
                : 物品归属?.FirstOrDefault()?.Id ?? 0;

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
        public MapObject DropperObject;
        public HashSet<CharacterData> 物品归属;
    }
}
