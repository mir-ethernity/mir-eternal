using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 52, 长度 = 3, 注释 = "CharacterRepurchageItemsPacket")]
	public sealed class CharacterRepurchageItemsPacket : GamePacket
	{
		
		public CharacterRepurchageItemsPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 物品位置;
	}
}
