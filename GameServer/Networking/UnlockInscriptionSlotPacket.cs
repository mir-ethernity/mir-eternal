using System;

namespace GameServer.Networking
{
	// Token: 0x02000165 RID: 357
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 102, 长度 = 3, 注释 = "UnlockInscriptionSlotPacket")]
	public sealed class UnlockInscriptionSlotPacket : GamePacket
	{
		// Token: 0x0600024E RID: 590 RVA: 0x0000344A File Offset: 0x0000164A
		public UnlockInscriptionSlotPacket()
		{
			
			
		}

		// Token: 0x04000643 RID: 1603
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 解锁参数;
	}
}
