using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 545, 长度 = 0, 注释 = "查询拜师名册应答")]
	public sealed class SyncApprenticeshipRosterPacketAnswer : GamePacket
	{
		
		public SyncApprenticeshipRosterPacketAnswer()
		{
			
			
		}
	}
}
