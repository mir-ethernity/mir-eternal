using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 52, Length = 3, Description = "CharacterRepurchageItemsPacket")]
	public sealed class CharacterRepurchageItemsPacket : GamePacket
	{
		
		public CharacterRepurchageItemsPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 物品位置;
	}
}
