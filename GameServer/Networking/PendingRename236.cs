using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 557, 长度 = 2, 注释 = "查看申请列表")]
	public sealed class 查看申请列表 : GamePacket
	{
		
		public 查看申请列表()
		{
			
			
		}
	}
}
