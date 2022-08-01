using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 77, 长度 = 4, 注释 = "ReplaceLowLevelInscriptionsPacket")]
	public sealed class ReplaceLowLevelInscriptionsPacket : GamePacket
	{
		
		public ReplaceLowLevelInscriptionsPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 装备类型;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 1)]
		public byte 装备位置;
	}
}
