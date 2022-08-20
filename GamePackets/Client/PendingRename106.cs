using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 151, Length = 2, Description = "玩家锁定交易")]
	public sealed class 玩家锁定交易 : GamePacket
	{
		
		public 玩家锁定交易()
		{
			
			
		}
	}
}
