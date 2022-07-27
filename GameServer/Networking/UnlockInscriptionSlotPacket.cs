using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 102, 长度 = 3, 注释 = "UnlockInscriptionSlotPacket")]
	public sealed class UnlockInscriptionSlotPacket : GamePacket
	{
		
		public UnlockInscriptionSlotPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 解锁参数;
	}
}
