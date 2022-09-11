using System;

namespace GameServer.Networking
{

    [PacketInfo(Source = PacketSource.Server, Id = 35, Length = 0, Description = "同步角色装备")]
    public sealed class SyncPlayerEquipPacket : GamePacket
    {
        [WrappingField(SubScript = 4, Length = 4)]
        public int ObjectId;


        [WrappingField(SubScript = 40, Length = 1)]
        public byte EquipmentItemCount;


        [WrappingField(SubScript = 41, Length = 0)]
        public byte[] Info;
    }
}
