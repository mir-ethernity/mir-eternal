using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 545, Length = 0, Description = "查询拜师名册应答")]
	public sealed class SyncApprenticeshipRosterPacketAnswer : GamePacket
	{
		
		public SyncApprenticeshipRosterPacketAnswer()
		{
			
			
		}
	}
}
