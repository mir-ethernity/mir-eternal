using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 1007, Length = 6, Description = "帧同步, 请求Ping", NoDebug = true)]
	public sealed class 测试网关网速 : GamePacket
	{
		
		public 测试网关网速()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 客户时间;
	}
}
