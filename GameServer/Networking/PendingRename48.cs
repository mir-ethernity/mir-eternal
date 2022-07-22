using System;

namespace GameServer.Networking
{
	// Token: 0x0200009B RID: 155
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 108, 长度 = 3, 注释 = "取回摊位物品")]
	public sealed class 取回摊位物品 : GamePacket
	{
		// Token: 0x06000182 RID: 386 RVA: 0x0000344A File Offset: 0x0000164A
		public 取回摊位物品()
		{
			
			
		}

		// Token: 0x040004EB RID: 1259
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 取回位置;
	}
}
