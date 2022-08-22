using System;
using System.Drawing;

namespace GameServer.Networking
{
    [PacketInfo(Source = PacketSource.Server, Id = 153, Length = 0, Description = "ChestComesIntoViewPacket")]
    public sealed class ChestComesIntoViewPacket : GamePacket
    {
        [WrappingField(SubScript = 4, Length = 4)]
        public int ObjectId;

        [WrappingField(SubScript = 8, Length = 4)]
        public int NPCTemplateId;

        [WrappingField(SubScript = 12, Length = 4)]
        public Point Position;

        [WrappingField(SubScript = 16, Length = 2)]
        public ushort Altitude;

        [WrappingField(SubScript = 18, Length = 2)]
        public ushort Direction;

        [WrappingField(SubScript = 20, Length = 1)]
        public bool Interactive = true;
    }
}
