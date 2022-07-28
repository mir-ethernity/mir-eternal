using GameServer.Data;
using GameServer.Maps;
using GameServer.Networking;
using GameServer.Templates;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.GMCommands
{
    public class Move : GMCommand
    {
        public override ExecutionWay ExecutionWay => ExecutionWay.优先后台执行;

        public override void Execute()
        {
            if (!GameDataGateway.CharacterDataTable.Keyword.TryGetValue(Character, out GameData gd))
            {
                MainForm.添加命令日志($"<= @Move Command execution failed, character {Character} does not exist");
                return;
            }

            if (!GameMap.DataSheet.TryGetValue(MapId, out GameMap map))
            {
                MainForm.添加命令日志($"<= @Move Command execution failed, map {MapId} does not exist");
                return;
            }

            var characterData = gd as CharacterData;

            var player = characterData?.ActiveConnection?.Player;

            if (player == null)
            {
                MainForm.添加命令日志($"<= @Move Command execution failed, player {Character} not connected");
                return;
            }

            var mapInstance = MapGatewayProcess.分配地图(map.MapId);
            var mapArea = mapInstance.传送区域 ?? mapInstance.地图区域.First();

            var location = MapX != null && MapY != null
                ? new Point(MapX.Value, MapY.Value)
                : mapArea.RandomCoords;

            player.玩家切换地图(mapInstance, mapArea.AreaType, location);
        }

        [Field(0)]
        public string Character;

        [Field(1)]
        public byte MapId;

        [Field(2, IsOptional = true)]
        public int? MapX;

        [Field(3, IsOptional = true)]
        public int? MapY;
    }
}
