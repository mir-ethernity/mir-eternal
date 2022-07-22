using System;

namespace GameServer.Networking
{
	// Token: 0x020001D0 RID: 464
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 533, 长度 = 6, 注释 = "取消关注")]
	public sealed class 玩家取消关注 : GamePacket
	{
		// Token: 0x060002B9 RID: 697 RVA: 0x0000344A File Offset: 0x0000164A
		public 玩家取消关注()
		{
			
			
		}

		// Token: 0x04000725 RID: 1829
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
