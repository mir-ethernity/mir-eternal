using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 152, Length = 2, Description = "玩家确认交易")]
	public sealed class 玩家确认交易 : GamePacket
	{
		
		public 玩家确认交易()
		{
			
			
		}
	}
}
