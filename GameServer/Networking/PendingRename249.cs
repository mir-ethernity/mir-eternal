using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 544, 长度 = 2, 注释 = "查询师门成员(师徒通用)")]
	public sealed class 查询师门成员 : GamePacket
	{
		
		public 查询师门成员()
		{
			
			
		}
	}
}
