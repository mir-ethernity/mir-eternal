using System;

namespace GameServer.Networking
{
	// Token: 0x0200008E RID: 142
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 76, 长度 = 8, 注释 = "ReplaceInscriptionRefinementPacket")]
	public sealed class ReplaceInscriptionRefinementPacket : GamePacket
	{
		// Token: 0x06000175 RID: 373 RVA: 0x0000344A File Offset: 0x0000164A
		public ReplaceInscriptionRefinementPacket()
		{
			
			
		}

		// Token: 0x040004D5 RID: 1237
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 装备类型;

		// Token: 0x040004D6 RID: 1238
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 装备位置;

		// Token: 0x040004D7 RID: 1239
		[WrappingFieldAttribute(下标 = 4, 长度 = 4)]
		public int 物品编号;
	}
}
