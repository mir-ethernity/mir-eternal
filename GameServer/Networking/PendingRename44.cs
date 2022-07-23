using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 670, 长度 = 134, 注释 = "计费系统错误")]
	public sealed class 计费系统错误 : GamePacket
	{
		
		public 计费系统错误()
		{
			
			
		}
	}
}
