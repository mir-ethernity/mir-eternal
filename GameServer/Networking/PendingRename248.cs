using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 160, 长度 = 2, 注释 = "查询师门奖励(师徒通用)")]
	public sealed class 查询师门奖励 : GamePacket
	{
		
		public 查询师门奖励()
		{
			
			
		}
	}
}
