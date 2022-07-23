using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 1008, 长度 = 6, 注释 = "DeleteCharacterPacket回应")]
	public sealed class DeleteCharacterPacket : GamePacket
	{
		
		public DeleteCharacterPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 角色编号;
	}
}
