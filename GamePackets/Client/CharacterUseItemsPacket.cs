using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 45, 长度 = 4, 注释 = "CharacterUseItemsPacket")]
	public sealed class CharacterUseItemsPacket : GamePacket
	{
		
		public CharacterUseItemsPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 背包类型;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 1)]
		public byte 物品位置;
	}
}
