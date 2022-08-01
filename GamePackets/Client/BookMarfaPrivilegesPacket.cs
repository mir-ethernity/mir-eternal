using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 217, 长度 = 3, 注释 = "BookMarfaPrivilegesPacket")]
	public sealed class BookMarfaPrivilegesPacket : GamePacket
	{
		
		public BookMarfaPrivilegesPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 特权类型;
	}
}
