using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 23, Length = 6, Description = "帧同步, 请求Ping", NoDebug = true)]
	public sealed class 客户网速测试 : GamePacket
	{
		
		public 客户网速测试()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 客户时间;
	}
}
