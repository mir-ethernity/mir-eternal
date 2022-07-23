using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 74, 长度 = 5, 注释 = "UnlockDoubleInscriptionSlotPacket")]
	public sealed class UnlockDoubleInscriptionSlotPacket : GamePacket
	{
		
		public UnlockDoubleInscriptionSlotPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 装备类型;

		
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 装备位置;

		
		[WrappingFieldAttribute(下标 = 4, 长度 = 1)]
		public byte 操作参数;
	}
}
