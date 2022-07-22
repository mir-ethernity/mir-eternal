using System;

namespace GameServer.Networking
{
	// Token: 0x02000155 RID: 341
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 82, 长度 = 7, 注释 = "玩家名字变灰")]
	public sealed class 玩家名字变灰 : GamePacket
	{
		// Token: 0x0600023E RID: 574 RVA: 0x0000344A File Offset: 0x0000164A
		public 玩家名字变灰()
		{
			
			
		}

		// Token: 0x04000607 RID: 1543
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		// Token: 0x04000608 RID: 1544
		[WrappingFieldAttribute(下标 = 6, 长度 = 1)]
		public bool 是否灰名;
	}
}
