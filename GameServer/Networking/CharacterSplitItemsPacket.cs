using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 46, 长度 = 8, 注释 = "CharacterSplitItemsPacket")]
	public sealed class CharacterSplitItemsPacket : GamePacket
	{
		
		public CharacterSplitItemsPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 当前背包;

		
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 物品位置;

		
		[WrappingFieldAttribute(下标 = 4, 长度 = 1)]
		public byte 目标背包;

		
		[WrappingFieldAttribute(下标 = 5, 长度 = 1)]
		public byte 目标位置;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 2)]
		public ushort 拆分数量;
	}
}
