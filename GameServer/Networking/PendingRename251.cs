using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 233, 长度 = 2, 注释 = "查询奖励找回")]
	public sealed class 查询奖励找回 : GamePacket
	{
		
		public 查询奖励找回()
		{
			
			
		}
	}
}
