using GameServer.Data;
using GameServer.Maps;
using GameServer.Networking;
using GameServer.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.PlayerCommands
{
    public class PlayerCommandManageSabak : PlayerCommand
    {
        [Field(Position = 0)]
        public string SabakGuildName;
        public override void Execute()
        {
            var guild = GameDataGateway.GuildData表.DataSheet.Values.OfType<GuildData>().FirstOrDefault(x => x.GuildName.V.Equals(SabakGuildName));

            if (guild == null)
            {
                Player.SendMessage($"Guild {SabakGuildName} not found");
                return;
            };

            SystemData.Data.OccupyGuild.V = guild;
            SystemData.Data.占领时间.V = MainProcess.CurrentTime;

            foreach (var keyValuePair4 in guild.行会成员)
            {
                keyValuePair4.Key.攻沙日期.V = MainProcess.CurrentTime;
            }

            NetworkServiceGateway.SendAnnouncement(string.Format("[{0}] has become the new Shabak Guild", guild), true);
        }
    }
}