using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 1005, 长度 = 96, 注释 = "CharacterCreatedSuccessfullyPacket")]
	public sealed class CharacterCreatedSuccessfullyPacket : GamePacket
	{
		
		public CharacterCreatedSuccessfullyPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 94)]
		public byte[] 角色描述;
	}
}
