using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 149, 长度 = 6, 注释 = "玩家放入金币")]
	public sealed class 玩家放入金币 : GamePacket
	{
		
		public 玩家放入金币()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int NumberGoldCoins;
	}
}
