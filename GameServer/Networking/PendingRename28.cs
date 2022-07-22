using System;

namespace GameServer.Networking
{
	// Token: 0x02000082 RID: 130
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 55, 长度 = 4, 注释 = "商店特修单件")]
	public sealed class 商店特修单件 : GamePacket
	{
		// Token: 0x06000169 RID: 361 RVA: 0x0000344A File Offset: 0x0000164A
		public 商店特修单件()
		{
			
			
		}

		// Token: 0x040004B5 RID: 1205
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 物品容器;

		// Token: 0x040004B6 RID: 1206
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 物品位置;
	}
}
