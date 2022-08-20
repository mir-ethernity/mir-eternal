using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 683, Length = 558, Description = "YanwuArenaChallengeListPacket")]
	public sealed class YanwuArenaChallengeListPacket : GamePacket
	{
		
		public YanwuArenaChallengeListPacket()
		{
			
			
		}
	}
}
