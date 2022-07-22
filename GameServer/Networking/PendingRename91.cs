using System;

namespace GameServer.Networking
{
	// Token: 0x0200019C RID: 412
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 213, 长度 = 7, 注释 = "玩家获得称号")]
	public sealed class 玩家获得称号 : GamePacket
	{
		// Token: 0x06000285 RID: 645 RVA: 0x0000344A File Offset: 0x0000164A
		public 玩家获得称号()
		{
			
			
		}

		// Token: 0x040006BC RID: 1724
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 称号编号;

		// Token: 0x040006BD RID: 1725
		[WrappingFieldAttribute(下标 = 3, 长度 = 4)]
		public int 剩余时间;
	}
}
