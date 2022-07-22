using System;

namespace GameServer.Networking
{
	// Token: 0x020001DF RID: 479
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 549, 长度 = 6, 注释 = "玩家申请拜师")]
	public sealed class 申请拜师应答 : GamePacket
	{
		// Token: 0x060002C8 RID: 712 RVA: 0x0000344A File Offset: 0x0000164A
		public 申请拜师应答()
		{
			
			
		}

		// Token: 0x04000733 RID: 1843
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
