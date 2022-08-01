using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 191, 长度 = 2, 注释 = "玩家每日签到")]
	public sealed class 玩家每日签到 : GamePacket
	{
		
		public 玩家每日签到()
		{
			
			
		}
	}
}
