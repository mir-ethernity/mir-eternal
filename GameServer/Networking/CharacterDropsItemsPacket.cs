using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 47, 长度 = 6, 注释 = "CharacterDropsItemsPacket")]
	public sealed class CharacterDropsItemsPacket : GamePacket
	{
		
		public CharacterDropsItemsPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 背包类型;

		
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 物品位置;

		
		[WrappingFieldAttribute(下标 = 4, 长度 = 2)]
		public ushort 丢弃数量;
	}
}
