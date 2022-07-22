using System;

namespace GameServer.Networking
{
	// Token: 0x020001E0 RID: 480
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 550, 长度 = 6, 注释 = "申请拜师提示")]
	public sealed class 申请拜师提示 : GamePacket
	{
		// Token: 0x060002C9 RID: 713 RVA: 0x0000344A File Offset: 0x0000164A
		public 申请拜师提示()
		{
			
			
		}

		// Token: 0x04000734 RID: 1844
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
