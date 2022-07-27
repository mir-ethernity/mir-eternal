using GameServer.Data;
using GameServer.Maps;
using GameServer.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.GMCommands
{
    public class Mob : GMCommand
    {
        public override ExecutionWay ExecutionWay => ExecutionWay.优先后台执行;

        public override void Execute()
        {
            if (!Monsters.DataSheet.TryGetValue(MobName, out Monsters monster))
            {
                MainForm.添加命令日志($"<= @Mob Command execution failed, mob {MobName} does not exist");
                return;
            }

            if (!GameMap.DataSheet.TryGetValue(MapId, out GameMap map))
            {
                MainForm.添加命令日志($"<= @Move Command execution failed, map {MapId} does not exist");
                return;
            }

            var mapInstance = MapGatewayProcess.分配地图(map.MapId);

            new MonsterObject(monster, mapInstance, 0, new System.Drawing.Point[] { new System.Drawing.Point(MapX, MapY) }, true, true);
        }

        [FieldAttribute(0, Position = 0)]
        public string MobName;

        [FieldAttribute(0, Position = 1)]
        public byte MapId;

        [FieldAttribute(0, Position = 2)]
        public int MapX;

        [FieldAttribute(0, Position = 3)]
        public int MapY;
    }
}
