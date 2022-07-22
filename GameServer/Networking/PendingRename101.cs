using System;

namespace GameServer.Networking
{
	// Token: 0x020000E4 RID: 228
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 534, 长度 = 6, 注释 = "玩家申请拜师")]
	public sealed class 玩家申请拜师 : GamePacket
	{
		// Token: 0x060001CB RID: 459 RVA: 0x0000344A File Offset: 0x0000164A
		public 玩家申请拜师()
		{
			
			
		}

		// Token: 0x04000530 RID: 1328
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
