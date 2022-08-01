using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 163, 长度 = 6, 注释 = "DonateGuildFundsPacket")]
	public sealed class DonateGuildFundsPacket : GamePacket
	{
		
		public DonateGuildFundsPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int NumberGoldCoins;
	}
}
