using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 1005, 长度 = 96, 注释 = "CharacterCreatedSuccessfullyPacket")]
	public sealed class CharacterCreatedSuccessfullyPacket : GamePacket
	{
		
		public CharacterCreatedSuccessfullyPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 94)]
		public byte[] 角色描述;
	}
}
