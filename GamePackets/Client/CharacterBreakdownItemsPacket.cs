using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 86, 长度 = 5, 注释 = "CharacterBreakdownItemsPacket")]
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
