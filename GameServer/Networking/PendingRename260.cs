using System;

namespace GameServer.Networking
{
	// Token: 0x020000F4 RID: 244
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 552, 长度 = 10, 注释 = "查询行会名字")]
	public sealed class 查询行会名字 : GamePacket
	{
		// Token: 0x060001DB RID: 475 RVA: 0x0000344A File Offset: 0x0000164A
		public 查询行会名字()
		{
			
			
		}

		// Token: 0x0400053C RID: 1340
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 行会编号;

		// Token: 0x0400053D RID: 1341
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 状态编号;
	}
}
