using System;

namespace GameServer.Networking
{
	// Token: 0x0200009F RID: 159
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 112, 长度 = 17, 注释 = "购买摊位物品")]
	public sealed class 购买摊位物品 : GamePacket
	{
		// Token: 0x06000186 RID: 390 RVA: 0x0000344A File Offset: 0x0000164A
		public 购买摊位物品()
		{
			
			
		}

		// Token: 0x040004EF RID: 1263
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		// Token: 0x040004F0 RID: 1264
		[WrappingFieldAttribute(下标 = 6, 长度 = 1)]
		public byte 物品位置;

		// Token: 0x040004F1 RID: 1265
		[WrappingFieldAttribute(下标 = 7, 长度 = 2)]
		public ushort 购买数量;
	}
}
