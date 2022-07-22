using System;

namespace GameServer.Networking
{
	// Token: 0x020000FC RID: 252
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 560, 长度 = 7, 注释 = "处理入会邀请")]
	public sealed class 处理入会邀请 : GamePacket
	{
		// Token: 0x060001E3 RID: 483 RVA: 0x0000344A File Offset: 0x0000164A
		public 处理入会邀请()
		{
			
			
		}

		// Token: 0x04000547 RID: 1351
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 处理类型;

		// Token: 0x04000548 RID: 1352
		[WrappingFieldAttribute(下标 = 3, 长度 = 4)]
		public int 对象编号;
	}
}
