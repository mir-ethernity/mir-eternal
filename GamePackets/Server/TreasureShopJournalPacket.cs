using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 659, 长度 = 0, 注释 = "TreasureShopJournalPacket")]
	public sealed class TreasureShopJournalPacket : GamePacket
	{
		
		public TreasureShopJournalPacket()
		{
			
			
		}
	}
}
