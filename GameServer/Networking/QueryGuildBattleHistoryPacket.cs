using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 178, 长度 = 3, 注释 = "QueryGuildBattleHistoryPacket")]
	public sealed class QueryGuildBattleHistoryPacket : GamePacket
	{
		
		public QueryGuildBattleHistoryPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte PetMode;
	}
}
