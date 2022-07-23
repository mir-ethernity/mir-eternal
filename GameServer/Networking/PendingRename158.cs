using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 1012, 长度 = 3, 注释 = "返回服务器信息")]
	public sealed class 同步服务状态 : GamePacket
	{
		
		public 同步服务状态()
		{
			
			
		}
	}
}
