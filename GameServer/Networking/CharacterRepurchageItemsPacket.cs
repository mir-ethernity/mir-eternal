using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 52, 长度 = 3, 注释 = "CharacterRepurchageItemsPacket")]
	public sealed class CharacterRepurchageItemsPacket : GamePacket
	{
		
		public CharacterRepurchageItemsPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 物品位置;
	}
}
