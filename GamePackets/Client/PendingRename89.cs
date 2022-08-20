using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 105, Length = 2, Description = "玩家开始摆摊")]
	public sealed class 玩家开始摆摊 : GamePacket
	{
		
		public 玩家开始摆摊()
		{
			
			
		}
	}
}
