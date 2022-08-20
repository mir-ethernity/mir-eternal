using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 136, Length = 10, Description = "拾取金币")]
	public sealed class 玩家拾取金币 : GamePacket
	{
		
		public 玩家拾取金币()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int NumberGoldCoins;
	}
}
