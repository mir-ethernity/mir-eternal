using System;

namespace GameServer.Networking
{
	// Token: 0x0200017B RID: 379
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 130, 长度 = 4, 注释 = "删除物品")]
	public sealed class 删除玩家物品 : GamePacket
	{
		// Token: 0x06000264 RID: 612 RVA: 0x0000344A File Offset: 0x0000164A
		public 删除玩家物品()
		{
			
			
		}

		// Token: 0x04000685 RID: 1669
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 背包类型;

		// Token: 0x04000686 RID: 1670
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 物品位置;
	}
}
