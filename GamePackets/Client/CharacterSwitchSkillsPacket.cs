using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 33, Length = 4, Description = "CharacterSwitchSkillsPacket")]
	public sealed class CharacterSwitchSkillsPacket : GamePacket
	{
		
		public CharacterSwitchSkillsPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 2)]
		public ushort SkillId;
	}
}
