using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 40, Length = 2, Description = "离开场景(包括商店/随机卷)")]
	public sealed class 玩家离开场景 : GamePacket
	{
		
		public 玩家离开场景()
		{
			
			
		}
	}
}
