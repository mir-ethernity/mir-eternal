using System;

namespace GameServer.Networking
{
	// Token: 0x020000E5 RID: 229
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 535, 长度 = 6, 注释 = "同意拜师申请")]
	public sealed class 同意拜师申请 : GamePacket
	{
		// Token: 0x060001CC RID: 460 RVA: 0x0000344A File Offset: 0x0000164A
		public 同意拜师申请()
		{
			
			
		}

		// Token: 0x04000531 RID: 1329
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
