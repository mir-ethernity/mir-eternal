using GameServer;
using GameServer.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePackets.Client
{
    [PacketInfoAttribute(Source = PacketSource.Client, Id = 235, Length = 6, Description = "QuestTeleportPacket")]
    public class QuestTeleportPacket : GamePacket
    {
        [WrappingField(SubScript = 2, Length = 4)]
        public int QuestId;
    }
}
