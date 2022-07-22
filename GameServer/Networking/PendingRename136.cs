using System;

namespace GameServer.Networking
{
	// Token: 0x0200017A RID: 378
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 129, 长度 = 6, 注释 = "物品转移或交换")]
	public sealed class 玩家转移物品 : GamePacket
	{
		// Token: 0x06000263 RID: 611 RVA: 0x0000344A File Offset: 0x0000164A
		public 玩家转移物品()
		{
			
			
		}

		// Token: 0x04000681 RID: 1665
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 原有容器;

		// Token: 0x04000682 RID: 1666
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 原有位置;

		// Token: 0x04000683 RID: 1667
		[WrappingFieldAttribute(下标 = 4, 长度 = 1)]
		public byte 目标容器;

		// Token: 0x04000684 RID: 1668
		[WrappingFieldAttribute(下标 = 5, 长度 = 1)]
		public byte 目标位置;
	}
}
