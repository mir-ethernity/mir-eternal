using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 58, Length = 3, Description = "CharacterOrganizerBackpackPacket")]
	public sealed class CharacterOrganizerBackpackPacket : GamePacket
	{
		
		public CharacterOrganizerBackpackPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 背包类型;
	}
}
