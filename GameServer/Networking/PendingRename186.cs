using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 601, 长度 = 3, 注释 = "脱离行会应答")]
	public sealed class 脱离行会应答 : GamePacket
	{
		
		public 脱离行会应答()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public byte 脱离方式;
	}
}
