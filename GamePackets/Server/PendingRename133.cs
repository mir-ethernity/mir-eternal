using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 293, Length = 14, Description = "玩家重铸装备")]
	public sealed class 玩家重铸装备 : GamePacket
	{
		
		public 玩家重铸装备()
		{
			
			
		}
	}
}
