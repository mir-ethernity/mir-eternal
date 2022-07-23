using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 50, 长度 = 6, 注释 = "CharacterSellItemsPacket")]
	public sealed class CharacterSellItemsPacket : GamePacket
	{
		
		public CharacterSellItemsPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 背包类型;

		
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 物品位置;

		
		[WrappingFieldAttribute(下标 = 4, 长度 = 2)]
		public ushort 卖出数量;
	}
}
