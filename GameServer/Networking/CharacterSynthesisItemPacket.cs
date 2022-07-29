using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 87, 长度 = 6, 注释 = "CharacterSynthesisItemPacket")]
	public sealed class CharacterSynthesisItemPacket : GamePacket
	{
		
		public CharacterSynthesisItemPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte Id;
	}
}
