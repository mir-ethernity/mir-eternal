using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 178, Length = 3, Description = "QueryGuildBattleHistoryPacket")]
	public sealed class QueryGuildBattleHistoryPacket : GamePacket
	{
		
		public QueryGuildBattleHistoryPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte PetMode;
	}
}
