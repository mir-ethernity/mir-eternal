using System;

namespace GameServer.Networking
{
	// Token: 0x0200008C RID: 140
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 74, 长度 = 5, 注释 = "UnlockDoubleInscriptionSlotPacket")]
	public sealed class UnlockDoubleInscriptionSlotPacket : GamePacket
	{
		// Token: 0x06000173 RID: 371 RVA: 0x0000344A File Offset: 0x0000164A
		public UnlockDoubleInscriptionSlotPacket()
		{
			
			
		}

		// Token: 0x040004CF RID: 1231
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 装备类型;

		// Token: 0x040004D0 RID: 1232
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 装备位置;

		// Token: 0x040004D1 RID: 1233
		[WrappingFieldAttribute(下标 = 4, 长度 = 1)]
		public byte 操作参数;
	}
}
