using System;

namespace GameServer.Networking
{
	
	[PacketInfo(Source = PacketSource.Server, Id = 90, Length = 4, Description = "CharacterRemoveSkillPacket")]
	public sealed class CharacterRemoveSkillPacket : GamePacket
	{
        [WrappingField(SubScript = 2, Length = 2)]
        public ushort SkillId;
    }
}
