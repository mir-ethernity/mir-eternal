using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 46, 长度 = 8, 注释 = "CharacterSplitItemsPacket")]
	public sealed class CharacterSplitItemsPacket : GamePacket
	{
		
		public CharacterSplitItemsPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 当前背包;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 1)]
		public byte 物品位置;

		
		[WrappingFieldAttribute(SubScript = 4, Length = 1)]
		public byte 目标背包;

		
		[WrappingFieldAttribute(SubScript = 5, Length = 1)]
		public byte 目标位置;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 2)]
		public ushort 拆分数量;
	}
}
