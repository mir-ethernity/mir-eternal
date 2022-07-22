using System;

namespace GameServer.Networking
{
	// Token: 0x02000107 RID: 263
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 571, 长度 = 6, 注释 = "申请解除结盟")]
	public sealed class 申请解除结盟 : GamePacket
	{
		// Token: 0x060001EE RID: 494 RVA: 0x0000344A File Offset: 0x0000164A
		public 申请解除结盟()
		{
			
			
		}

		// Token: 0x04000556 RID: 1366
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 行会编号;
	}
}
