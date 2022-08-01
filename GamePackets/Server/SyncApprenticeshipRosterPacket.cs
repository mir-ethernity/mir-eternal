using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 546, 长度 = 0, 注释 = "查询收徒名册应答")]
	public sealed class SyncApprenticeshipRosterPacket : GamePacket
	{
		
		public SyncApprenticeshipRosterPacket()
		{
			
			
		}
	}
}
