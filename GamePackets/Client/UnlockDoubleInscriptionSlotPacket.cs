using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 74, Length = 5, Description = "UnlockDoubleInscriptionSlotPacket")]
	public sealed class UnlockDoubleInscriptionSlotPacket : GamePacket
	{
		
		public UnlockDoubleInscriptionSlotPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 装备类型;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 1)]
		public byte 装备位置;

		
		[WrappingFieldAttribute(SubScript = 4, Length = 1)]
		public byte 操作参数;
	}
}
