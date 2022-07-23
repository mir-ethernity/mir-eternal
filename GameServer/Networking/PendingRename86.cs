using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 191, 长度 = 2, 注释 = "玩家每日签到")]
	public sealed class 玩家每日签到 : GamePacket
	{
		
		public 玩家每日签到()
		{
			
			
		}
	}
}
