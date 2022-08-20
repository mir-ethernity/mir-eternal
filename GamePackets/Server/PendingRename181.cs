using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 638, Length = 0, Description = "QueryGuildBattleHistoryPacket")]
	public sealed class 同步行会战史 : GamePacket
	{
		
		public 同步行会战史()
		{
			
			
		}
	}
}
