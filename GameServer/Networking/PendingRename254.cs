using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 602, 长度 = 2, 注释 = "查询出售信息")]
	public sealed class 查询出售信息 : GamePacket
	{
		
		public 查询出售信息()
		{
			
			
		}
	}
}
