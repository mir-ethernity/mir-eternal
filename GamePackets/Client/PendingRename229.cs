using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 1007, 长度 = 6, 注释 = "帧同步, 请求Ping", NoDebug = true)]
	public sealed class 测试网关网速 : GamePacket
	{
		
		public 测试网关网速()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 客户时间;
	}
}
