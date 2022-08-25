using GameServer;
using GameServer.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePackets.Server
{
    [PacketInfo(Source = PacketSource.Server, Id = 145, Length = 7, Description = "SyncObjectMountPacket")]
    public class SyncObjectMountPacket : GamePacket
    {
        [WrappingField(SubScript = 2, Length = 4)]
        public int ObjectId;

        [WrappingField(SubScript = 6, Length = 1)]
        public byte MountId;
    }
}
