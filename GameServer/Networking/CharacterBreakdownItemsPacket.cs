using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 86, 长度 = 5, 注释 = "CharacterBreakdownItemsPacket")]
	public sealed class CharacterBreakdownItemsPacket : GamePacket
	{
		
		public CharacterBreakdownItemsPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 背包类型;

		
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 物品位置;

		
		[WrappingFieldAttribute(下标 = 4, 长度 = 1)]
		public byte 分解数量;
	}
}
