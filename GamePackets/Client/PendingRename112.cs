using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 153, Length = 2, Description = "玩家解锁交易")]
	public sealed class 玩家解锁交易 : GamePacket
	{
		
		public 玩家解锁交易()
		{
			
			
		}
	}
}
