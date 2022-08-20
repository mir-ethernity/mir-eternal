using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 580, Length = 2, Description = "QueryGuildAchievementsPacket")]
	public sealed class QueryGuildAchievementsPacket : GamePacket
	{
		
		public QueryGuildAchievementsPacket()
		{
			
			
		}
	}
}
