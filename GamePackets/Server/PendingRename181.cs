using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 638, 长度 = 0, 注释 = "QueryGuildBattleHistoryPacket")]
	public sealed class 同步行会战史 : GamePacket
	{
		
		public 同步行会战史()
		{
			
			
		}
	}
}
