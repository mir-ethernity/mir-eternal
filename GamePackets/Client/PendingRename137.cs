using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 146, Length = 2, Description = "玩家卸下称号")]
	public sealed class 玩家卸下称号 : GamePacket
	{
		
		public 玩家卸下称号()
		{
			
			
		}
	}
}
