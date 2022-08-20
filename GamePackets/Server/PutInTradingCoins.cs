using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 217, Length = 10, Description = "PutInTradingCoins")]
	public sealed class PutInTradingCoins : GamePacket
	{
		
		public PutInTradingCoins()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int NumberGoldCoins;
	}
}
