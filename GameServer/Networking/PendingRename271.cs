using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 109, 长度 = 35, 注释 = "更改摊位名字")]
	public sealed class 更改摊位名字 : GamePacket
	{
		
		public 更改摊位名字()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 33)]
		public string 摊位名字;
	}
}
