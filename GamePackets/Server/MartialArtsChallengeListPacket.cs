using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 682, Length = 326, Description = "MartialArtsChallengeListPacket")]
	public sealed class MartialArtsChallengeListPacket : GamePacket
	{
		
		public MartialArtsChallengeListPacket()
		{
			
			
		}
	}
}
