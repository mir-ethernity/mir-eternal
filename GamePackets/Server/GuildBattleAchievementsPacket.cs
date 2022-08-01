using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 633, 长度 = 0, 注释 = "帮会战斗成就")]
	public sealed class GuildBattleAchievementsPacket : GamePacket
	{
		
		public GuildBattleAchievementsPacket()
		{
			
			
		}
	}
}
