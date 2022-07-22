using System;

namespace GameServer.Networking
{
	// Token: 0x020001E1 RID: 481
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 551, 长度 = 6, 注释 = "同意拜师申请")]
	public sealed class 拜师申请通过 : GamePacket
	{
		// Token: 0x060002CA RID: 714 RVA: 0x0000344A File Offset: 0x0000164A
		public 拜师申请通过()
		{
			
			
		}

		// Token: 0x04000735 RID: 1845
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
