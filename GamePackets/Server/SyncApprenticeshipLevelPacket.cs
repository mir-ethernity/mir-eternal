using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 548, 长度 = 7, 注释 = "SyncApprenticeshipLevelPacket")]
	public sealed class SyncApprenticeshipLevelPacket : GamePacket
	{
		
		public SyncApprenticeshipLevelPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 1)]
		public byte 对象等级;
	}
}
