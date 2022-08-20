using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 106, Length = 2, Description = "玩家收起摊位")]
	public sealed class 玩家收起摊位 : GamePacket
	{
		
		public 玩家收起摊位()
		{
			
			
		}
	}
}
