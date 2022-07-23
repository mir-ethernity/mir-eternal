using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 58, 长度 = 3, 注释 = "CharacterOrganizerBackpackPacket")]
	public sealed class CharacterOrganizerBackpackPacket : GamePacket
	{
		
		public CharacterOrganizerBackpackPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 背包类型;
	}
}
