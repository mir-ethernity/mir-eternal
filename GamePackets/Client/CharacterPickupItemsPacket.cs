using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 48, Length = 7, Description = "CharacterPickupItemsPacket")]
	public sealed class CharacterPickupItemsPacket : GamePacket
	{
		
		public CharacterPickupItemsPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int Id;
	}
}
