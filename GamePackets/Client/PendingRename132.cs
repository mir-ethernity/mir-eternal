using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 104, Length = 2, Description = "玩家重整摊位")]
	public sealed class 玩家重整摊位 : GamePacket
	{
		
		public 玩家重整摊位()
		{
			
			
		}
	}
}
