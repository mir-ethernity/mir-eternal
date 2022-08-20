using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 659, Length = 0, Description = "TreasureShopJournalPacket")]
	public sealed class TreasureShopJournalPacket : GamePacket
	{
		
		public TreasureShopJournalPacket()
		{
			
			
		}
	}
}
