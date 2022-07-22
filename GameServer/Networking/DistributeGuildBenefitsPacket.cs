using System;

namespace GameServer.Networking
{
	// Token: 0x020000BC RID: 188
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 176, 长度 = 0, 注释 = "DistributeGuildBenefitsPacket")]
	public sealed class DistributeGuildBenefitsPacket : GamePacket
	{
		// Token: 0x060001A3 RID: 419 RVA: 0x0000344A File Offset: 0x0000164A
		public DistributeGuildBenefitsPacket()
		{
			
			
		}

		// Token: 0x0400050F RID: 1295
		[WrappingFieldAttribute(下标 = 4, 长度 = 1)]
		public byte 发放方式;

		// Token: 0x04000510 RID: 1296
		[WrappingFieldAttribute(下标 = 5, 长度 = 4)]
		public int 发放总额;

		// Token: 0x04000511 RID: 1297
		[WrappingFieldAttribute(下标 = 13, 长度 = 2)]
		public ushort 发放人数;

		// Token: 0x04000512 RID: 1298
		[WrappingFieldAttribute(下标 = 15, 长度 = 0)]
		public int 对象编号;
	}
}
