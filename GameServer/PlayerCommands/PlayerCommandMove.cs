using GameServer.Maps;
using GameServer.Templates;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.PlayerCommands
{
    public class PlayerCommandMove : PlayerCommand
    {
        [Field(position: 0)]
        public int MapId;

        [Field(Position = 2, IsOptional = true)]
        public int? MapX;

        [Field(Position = 2, IsOptional = true)]
        public int? MapY;

        public override void Execute()
        {
            var mapInstance = MapGatewayProcess.GetMapInstance(MapId);

            if (mapInstance == null)
            {
                Player.SendMessage($"Unknown map {MapId}");
                return;
            }

            var mapArea = mapInstance.传送区域 ?? mapInstance.地图区域.FirstOrDefault();

            var location = MapX != null && MapY != null
                ? new Point(MapX.Value, MapY.Value)
                : mapArea?.RandomCoords ?? Point.Empty;

            if (location.IsEmpty)
            {
                for (var x = 1; x < mapInstance.MapSize.X; x++)
                    for (var y = 1; y < mapInstance.MapSize.Y; y++)
                        if (mapInstance.CanPass(new Point(x, y)))
                        {
                            location = new Point(x, y);
                            break;
                        }
            }

            Player.玩家切换地图(mapInstance, mapArea?.AreaType ?? AreaType.未知区域, location);
        }
    }
}
