using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 48, 长度 = 7, 注释 = "CharacterPickupItemsPacket")]
	public sealed class CharacterPickupItemsPacket : GamePacket
	{
		
		public CharacterPickupItemsPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int Id;
	}
}
