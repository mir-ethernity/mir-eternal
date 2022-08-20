using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 191, Length = 2, Description = "玩家每日签到")]
	public sealed class 玩家每日签到 : GamePacket
	{
		
		public 玩家每日签到()
		{
			
			
		}
	}
}
