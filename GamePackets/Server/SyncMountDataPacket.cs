using GameServer;
using GameServer.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePackets.Server
{
    [PacketInfo(Source = PacketSource.Server, Id = 28, Length = 0, Description = "SyncMountDataPacket")]
    public class SyncMountDataPacket : GamePacket
    {
        [WrappingField(SubScript = 4, Length = 4)]
        public int Unknown1;

        [WrappingField(SubScript = 8, Length = 4)]
        public int Unknown2;

        [WrappingField(SubScript = 12, Length = 2)]
        public ushort Unknown3;

        [WrappingField(SubScript = 14, Length = 0)]
        public byte[] MountData = Array.Empty<byte>();
    }
}
