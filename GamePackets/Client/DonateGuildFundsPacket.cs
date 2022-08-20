using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 163, Length = 6, Description = "DonateGuildFundsPacket")]
	public sealed class DonateGuildFundsPacket : GamePacket
	{
		
		public DonateGuildFundsPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int NumberGoldCoins;
	}
}
