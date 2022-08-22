using System;

namespace GameServer.Networking
{

    [PacketInfoAttribute(Source = PacketSource.Server, Id = 154, Length = 12, Description = "开始操作道具")]
    public sealed class StartOpenChestPacket : GamePacket
    {
        [WrappingField(SubScript = 2, Length = 4)]
        public int PlayerId;

        [WrappingField(SubScript = 6, Length = 4)]
        public int ObjectId;

        [WrappingField(SubScript = 10, Length = 2)]
        public ushort Unknown = 16;
    }
}
