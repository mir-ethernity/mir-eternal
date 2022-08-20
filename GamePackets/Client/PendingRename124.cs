using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 149, Length = 6, Description = "玩家放入金币")]
	public sealed class 玩家放入金币 : GamePacket
	{
		
		public 玩家放入金币()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int NumberGoldCoins;
	}
}
