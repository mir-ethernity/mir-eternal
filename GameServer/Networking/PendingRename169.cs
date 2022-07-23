using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 527, 长度 = 0, 注释 = "同步队伍变量")]
	public sealed class 同步队伍变量 : GamePacket
	{
		
		public 同步队伍变量()
		{
			
			
		}
	}
}
