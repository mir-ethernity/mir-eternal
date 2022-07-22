using System;

namespace GameServer.Networking
{
	// Token: 0x020000FA RID: 250
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 558, 长度 = 7, 注释 = "处理入会申请")]
	public sealed class 处理入会申请 : GamePacket
	{
		// Token: 0x060001E1 RID: 481 RVA: 0x0000344A File Offset: 0x0000164A
		public 处理入会申请()
		{
			
			
		}

		// Token: 0x04000544 RID: 1348
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 处理类型;

		// Token: 0x04000545 RID: 1349
		[WrappingFieldAttribute(下标 = 3, 长度 = 4)]
		public int 对象编号;
	}
}
