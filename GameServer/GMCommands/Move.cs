using GameServer.Data;
using GameServer.Maps;
using GameServer.Networking;
using GameServer.Templates;
using System;
using System.Collections.Generic;
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


            player.玩家切换地图(MapGatewayProcess.分配地图(map.MapId), AreaType.未知区域, new System.Drawing.Point(MapX, MapY));
        }

        [FieldAttribute(0, Position = 0)]
        public string Character;


        [FieldAttribute(0, Position = 1)]
        public byte MapId;

        [FieldAttribute(0, Position = 2)]
        public int MapX;

        [FieldAttribute(0, Position = 3)]
        public int MapY;
    }
}
