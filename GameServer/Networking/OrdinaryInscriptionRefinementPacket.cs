using System;

namespace GameServer.Networking
{
	// Token: 0x02000088 RID: 136
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 70, 长度 = 8, 注释 = "OrdinaryInscriptionRefinementPacket")]
	public sealed class OrdinaryInscriptionRefinementPacket : GamePacket
	{
		// Token: 0x0600016F RID: 367 RVA: 0x0000344A File Offset: 0x0000164A
		public OrdinaryInscriptionRefinementPacket()
		{
			
			
		}

		// Token: 0x040004C3 RID: 1219
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 装备类型;

		// Token: 0x040004C4 RID: 1220
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 装备位置;

		// Token: 0x040004C5 RID: 1221
		[WrappingFieldAttribute(下标 = 4, 长度 = 4)]
		public int 物品编号;
	}
}
