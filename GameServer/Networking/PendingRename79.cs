using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 628, 长度 = 10, 注释 = "跨服武道排名")]
	public sealed class 跨服武道排名 : GamePacket
	{
		
		public 跨服武道排名()
		{
			
			
		}
	}
}
