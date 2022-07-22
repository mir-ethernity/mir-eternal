using System;

namespace GameServer.Networking
{
	// Token: 0x0200020C RID: 524
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 602, 长度 = 10, 注释 = "会长传位公告")]
	public sealed class 会长传位公告 : GamePacket
	{
		// Token: 0x060002F5 RID: 757 RVA: 0x0000344A File Offset: 0x0000164A
		public 会长传位公告()
		{
			
			
		}

		// Token: 0x0400076E RID: 1902
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 当前编号;

		// Token: 0x0400076F RID: 1903
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 传位编号;
	}
}
