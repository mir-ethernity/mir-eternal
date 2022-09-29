
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
    public class PlayerCommandMakeGuild : PlayerCommand
    {
        [Field(Position = 0)]
        public string MakeGuildName;
        public override void Execute()
        {
            if (!GameDataGateway.GuildData表.Keyword.ContainsKey(MakeGuildName) && Player.Guild == null )
            {
                Player.Guild = new GuildData(Player, MakeGuildName, "");
                Player.SendPacket(new 创建行会应答
                {
                    GuildName = MakeGuildName
                });
                Player.SendMessage("Guild has been created.");
                MainForm.AddSystemLog(string.Format("Player [{0}] has created guild [{1}]", Player.ObjectName, MakeGuildName));
                return;
            }
            else
            {
                Player.SendMessage($"Guild already exist or you're in a guild!!");
                MainForm.AddSystemLog(string.Format("Player [{0}] tried to create a guild or join guild: [{1}]", Player.ObjectName, MakeGuildName));
            }
        }
    }
}