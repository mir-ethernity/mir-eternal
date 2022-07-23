using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 580, 长度 = 2, 注释 = "QueryGuildAchievementsPacket")]
	public sealed class QueryGuildAchievementsPacket : GamePacket
	{
		
		public QueryGuildAchievementsPacket()
		{
			
			
		}
	}
}
