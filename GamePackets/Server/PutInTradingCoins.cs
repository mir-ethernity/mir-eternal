using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 217, 长度 = 10, 注释 = "PutInTradingCoins")]
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
