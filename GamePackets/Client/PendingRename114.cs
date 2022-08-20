using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 154, Length = 2, Description = "玩家结束交易")]
	public sealed class 玩家结束交易 : GamePacket
	{
		
		public 玩家结束交易()
		{
			
			
		}
	}
}
