using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 102, Length = 3, Description = "UnlockInscriptionSlotPacket")]
	public sealed class UnlockInscriptionSlotPacket : GamePacket
	{
		
		public UnlockInscriptionSlotPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 解锁参数;
	}
}
