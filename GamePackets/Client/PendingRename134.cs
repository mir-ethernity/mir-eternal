using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 103, Length = 2, Description = "玩家准备摆摊")]
	public sealed class 玩家准备摆摊 : GamePacket
	{
		
		public 玩家准备摆摊()
		{
			
			
		}
	}
}
