using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 217, 长度 = 3, 注释 = "BookMarfaPrivilegesPacket")]
	public sealed class BookMarfaPrivilegesPacket : GamePacket
	{
		
		public BookMarfaPrivilegesPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 特权类型;
	}
}
