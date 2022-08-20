using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 90, Length = 4, Description = "CharacterRemoveSkillPacket")]
	public sealed class CharacterRemoveSkillPacket : GamePacket
	{
		
		public CharacterRemoveSkillPacket()
		{
			
			
		}
	}
}
