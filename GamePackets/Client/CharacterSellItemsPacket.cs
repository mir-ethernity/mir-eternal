using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 50, Length = 6, Description = "CharacterSellItemsPacket")]
	public sealed class CharacterSellItemsPacket : GamePacket
	{
		
		public CharacterSellItemsPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 背包类型;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 1)]
		public byte 物品位置;

		
		[WrappingFieldAttribute(SubScript = 4, Length = 2)]
		public ushort 卖出数量;
	}
}
