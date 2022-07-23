using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 77, 长度 = 4, 注释 = "ReplaceLowLevelInscriptionsPacket")]
	public sealed class ReplaceLowLevelInscriptionsPacket : GamePacket
	{
		
		public ReplaceLowLevelInscriptionsPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 装备类型;

		
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 装备位置;
	}
}
