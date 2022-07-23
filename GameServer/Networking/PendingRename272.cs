using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 110, 长度 = 3, 注释 = "更改摊位外观")]
	public sealed class 更改摊位外观 : GamePacket
	{
		
		public 更改摊位外观()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 外观编号;
	}
}
