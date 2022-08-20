using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 548, Length = 2, Description = "QueryMailboxContentPacket")]
	public sealed class QueryMailboxContentPacket : GamePacket
	{
		
		public QueryMailboxContentPacket()
		{
			
			
		}
	}
}
