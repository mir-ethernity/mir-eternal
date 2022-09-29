using GameServer;
using GameServer.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePackets.Client
{
    [PacketInfo(Source = PacketSource.Client, Id = 225, Length = 3, Description = "ToggleAwekeningExpPacket")]
    public class ToggleAwakeningExpPacket : GamePacket
    {

        public bool Enabled;
    }
}
