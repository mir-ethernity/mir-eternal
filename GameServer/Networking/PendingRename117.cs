using System;

namespace GameServer.Networking
{
	// Token: 0x020000CD RID: 205
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 241, 长度 = 4, 注释 = "玩家喝修复油")]
	public sealed class 玩家喝修复油 : GamePacket
	{
		// Token: 0x060001B4 RID: 436 RVA: 0x0000344A File Offset: 0x0000164A
		public 玩家喝修复油()
		{
			
			
		}

		// Token: 0x0400051E RID: 1310
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 背包类型;

		// Token: 0x0400051F RID: 1311
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 物品位置;
	}
}
