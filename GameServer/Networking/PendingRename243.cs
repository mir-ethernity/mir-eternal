using System;

namespace GameServer.Networking
{
	// Token: 0x02000116 RID: 278
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 604, 长度 = 10, 注释 = "查询排名榜单")]
	public sealed class 查询排名榜单 : GamePacket
	{
		// Token: 0x060001FD RID: 509 RVA: 0x0000344A File Offset: 0x0000164A
		public 查询排名榜单()
		{
			
			
		}

		// Token: 0x04000569 RID: 1385
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 榜单类型;

		// Token: 0x0400056A RID: 1386
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 起始位置;
	}
}
