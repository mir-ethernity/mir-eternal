using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 87, 长度 = 6, 注释 = "CharacterSynthesisItemPacket")]
	public sealed class CharacterSynthesisItemPacket : GamePacket
	{
		
		public CharacterSynthesisItemPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 物品编号;
	}
}
