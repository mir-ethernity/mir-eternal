using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 47, 长度 = 6, 注释 = "CharacterDropsItemsPacket")]
	public sealed class CharacterDropsItemsPacket : GamePacket
	{
		
		public CharacterDropsItemsPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 背包类型;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 1)]
		public byte 物品位置;

		
		[WrappingFieldAttribute(SubScript = 4, Length = 2)]
		public ushort 丢弃数量;
	}
}
