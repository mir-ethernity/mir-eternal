using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 163, 长度 = 6, 注释 = "DonateGuildFundsPacket")]
	public sealed class DonateGuildFundsPacket : GamePacket
	{
		
		public DonateGuildFundsPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int NumberGoldCoins;
	}
}
