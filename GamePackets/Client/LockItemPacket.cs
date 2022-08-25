using GameServer;
using GameServer.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePackets.Client
{
    [PacketInfo(Source = PacketSource.Client, Id = 97, Length = 5, Description = "LockItemPacket")]
    public class LockItemPacket : GamePacket
    {
        [WrappingField(SubScript = 2, Length = 1)]
        public byte BackpackType;

        [WrappingField(SubScript = 3, Length = 1)]
        public byte Unknown;

        [WrappingField(SubScript = 4, Length = 1)]
        public byte Slot;
    }
}
