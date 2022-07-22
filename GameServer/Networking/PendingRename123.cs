using System;

namespace GameServer.Networking
{
	// Token: 0x020000AF RID: 175
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 150, 长度 = 6, 注释 = "玩家放入物品")]
	public sealed class 玩家放入物品 : GamePacket
	{
		// Token: 0x06000196 RID: 406 RVA: 0x0000344A File Offset: 0x0000164A
		public 玩家放入物品()
		{
			
			
		}

		// Token: 0x040004FE RID: 1278
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 放入位置;

		// Token: 0x040004FF RID: 1279
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 放入物品;

		// Token: 0x04000500 RID: 1280
		[WrappingFieldAttribute(下标 = 4, 长度 = 1)]
		public byte 物品容器;

		// Token: 0x04000501 RID: 1281
		[WrappingFieldAttribute(下标 = 5, 长度 = 1)]
		public byte 物品位置;
	}
}
