using GameServer;
using GameServer.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePackets.Client
{
    [PacketInfo(Source = PacketSource.Client, Id = 116, Length = 6, Description = "OpenChestPacket")]
    public class OpenChestPacket : GamePacket
    {
        [WrappingField(SubScript = 2, Length = 4)]
        public int ObjectId;
    }
}
