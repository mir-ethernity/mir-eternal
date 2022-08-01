using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 178, 长度 = 3, 注释 = "QueryGuildBattleHistoryPacket")]
	public sealed class QueryGuildBattleHistoryPacket : GamePacket
	{
		
		public QueryGuildBattleHistoryPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte PetMode;
	}
}
