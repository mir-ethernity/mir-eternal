using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 77, Length = 4, Description = "ReplaceLowLevelInscriptionsPacket")]
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
