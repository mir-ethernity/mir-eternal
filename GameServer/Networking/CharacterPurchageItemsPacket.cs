using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 49, 长度 = 12, 注释 = "CharacterPurchageItemsPacket")]
	public sealed class CharacterPurchageItemsPacket : GamePacket
	{
		
		public CharacterPurchageItemsPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 商店编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 6)]
		public int 物品位置;

		
		[WrappingFieldAttribute(下标 = 10, 长度 = 2)]
		public ushort 购入数量;
	}
}
