using System;

namespace GameServer.Networking
{

    [PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 184, 长度 = 0, 注释 = "SyncSceneVariablesPacket")]
    public sealed class SyncSceneVariablesPacket : GamePacket
    {
        [WrappingField(SubScript = 4, Length = 6)]
        public byte[] Data = new byte[] { 20, 0, 19, 18, 228, 98 };

    }
}
