using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 86, Length = 5, Description = "CharacterBreakdownItemsPacket")]
	public sealed class CharacterBreakdownItemsPacket : GamePacket
	{
		
		public CharacterBreakdownItemsPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 背包类型;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 1)]
		public byte 物品位置;

		
		[WrappingFieldAttribute(SubScript = 4, Length = 1)]
		public byte 分解数量;
	}
}
