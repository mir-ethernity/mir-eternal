using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 49, 长度 = 12, 注释 = "CharacterPurchageItemsPacket")]
	public sealed class CharacterPurchageItemsPacket : GamePacket
	{
		
		public CharacterPurchageItemsPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int StoreId;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 6)]
		public int 物品位置;

		
		[WrappingFieldAttribute(SubScript = 10, Length = 2)]
		public ushort 购入数量;
	}
}
