using System;

namespace GameServer.Networking
{
	// Token: 0x02000152 RID: 338
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 79, 长度 = 6, 注释 = "同步mp")]
	public sealed class 同步对象魔力 : GamePacket
	{
		// Token: 0x0600023B RID: 571 RVA: 0x0000344A File Offset: 0x0000164A
		public 同步对象魔力()
		{
			
			
		}

		// Token: 0x04000600 RID: 1536
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 当前魔力;
	}
}
