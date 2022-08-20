using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 1005, Length = 96, Description = "CharacterCreatedSuccessfullyPacket")]
	public sealed class CharacterCreatedSuccessfullyPacket : GamePacket
	{
		
		public CharacterCreatedSuccessfullyPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 94)]
		public byte[] 角色描述;
	}
}
