using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 687, Length = 499, Description = "跨服武道排名")]
	public sealed class SyncMartialArtsRankingPacket : GamePacket
	{
		
		public SyncMartialArtsRankingPacket()
		{
			
			
		}
	}
}
