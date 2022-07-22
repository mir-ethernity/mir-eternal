using System;

namespace GameServer.Networking
{
	// Token: 0x02000106 RID: 262
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 570, 长度 = 7, 注释 = "处理结盟申请")]
	public sealed class 处理结盟申请 : GamePacket
	{
		// Token: 0x060001ED RID: 493 RVA: 0x0000344A File Offset: 0x0000164A
		public 处理结盟申请()
		{
			
			
		}

		// Token: 0x04000554 RID: 1364
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 处理类型;

		// Token: 0x04000555 RID: 1365
		[WrappingFieldAttribute(下标 = 3, 长度 = 4)]
		public int 行会编号;
	}
}
