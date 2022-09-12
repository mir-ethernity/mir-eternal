using GameServer;
using GameServer.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePackets.Server
{
    [PacketInfo(Source = PacketSource.Server, Id = 220, Length = 6, Description = "QuestRewardCompletedPacket")]
    public  class QuestRewardCompletedPacket : GamePacket
    {
        [WrappingField(SubScript = 2, Length = 4)]
        public int QuestId;
    }
}
