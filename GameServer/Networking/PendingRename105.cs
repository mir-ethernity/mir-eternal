using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 136, 长度 = 10, 注释 = "拾取金币")]
	public sealed class 玩家拾取金币 : GamePacket
	{
		
		public 玩家拾取金币()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int NumberGoldCoins;
	}
}
