using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 23, 长度 = 6, 注释 = "帧同步, 请求Ping", NoDebug = true)]
	public sealed class 客户网速测试 : GamePacket
	{
		
		public 客户网速测试()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 客户时间;
	}
}
