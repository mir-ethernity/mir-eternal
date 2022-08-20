using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 88, Length = 3, Description = "领取师门奖励(已经弃用, 出师时自动结算)")]
	public sealed class 领取师门奖励 : GamePacket
	{
		
		public 领取师门奖励()
		{
			
			
		}
	}
}
