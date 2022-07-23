using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 48, 长度 = 7, 注释 = "CharacterPickupItemsPacket")]
	public sealed class CharacterPickupItemsPacket : GamePacket
	{
		
		public CharacterPickupItemsPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 物品编号;
	}
}
