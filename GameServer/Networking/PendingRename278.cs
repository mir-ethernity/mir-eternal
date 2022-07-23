using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 554, 长度 = 2, 注释 = "更多行会信息")]
	public sealed class 更多行会信息 : GamePacket
	{
		
		public 更多行会信息()
		{
			
			
		}
	}
}
