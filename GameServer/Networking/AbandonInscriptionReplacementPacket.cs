using System;

namespace GameServer.Networking
{
	// Token: 0x02000090 RID: 144
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 78, 长度 = 11, 注释 = "AbandonInscriptionReplacementPacket")]
	public sealed class AbandonInscriptionReplacementPacket : GamePacket
	{
		// Token: 0x06000177 RID: 375 RVA: 0x0000344A File Offset: 0x0000164A
		public AbandonInscriptionReplacementPacket()
		{
			
			
		}

		// Token: 0x040004DA RID: 1242
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 装备类型;

		// Token: 0x040004DB RID: 1243
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 装备位置;

		// Token: 0x040004DC RID: 1244
		[WrappingFieldAttribute(下标 = 4, 长度 = 4)]
		public int 物品编号;
	}
}
