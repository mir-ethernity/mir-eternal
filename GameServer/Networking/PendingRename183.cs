using System;

namespace GameServer.Networking
{
	// Token: 0x020000E8 RID: 232
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 539, 长度 = 6, 注释 = "同意收徒申请")]
	public sealed class 同意收徒申请 : GamePacket
	{
		// Token: 0x060001CF RID: 463 RVA: 0x0000344A File Offset: 0x0000164A
		public 同意收徒申请()
		{
			
			
		}

		// Token: 0x04000534 RID: 1332
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
