using System;

namespace GameServer.Networking
{

    [PacketInfoAttribute(Source = PacketSource.Server, Id = 184, Length = 0, Description = "SyncSceneVariablesPacket")]
    public sealed class SyncSceneVariablesPacket : GamePacket
    {
        [WrappingField(SubScript = 4, Length = 6)]
        public byte[] Data = new byte[] { 20, 0, 19, 18, 228, 98 };

    }
}
