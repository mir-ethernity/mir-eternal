using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 546, Length = 0, Description = "查询收徒名册应答")]
	public sealed class SyncApprenticeshipRosterPacket : GamePacket
	{
		
		public SyncApprenticeshipRosterPacket()
		{
			
			
		}
	}
}
