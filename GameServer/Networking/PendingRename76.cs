using System;

namespace GameServer.Networking
{
	// Token: 0x02000104 RID: 260
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 568, 长度 = 29, 注释 = "申请行会外交")]
	public sealed class 申请行会外交 : GamePacket
	{
		// Token: 0x060001EB RID: 491 RVA: 0x0000344A File Offset: 0x0000164A
		public 申请行会外交()
		{
			
			
		}

		// Token: 0x04000551 RID: 1361
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 外交类型;

		// Token: 0x04000552 RID: 1362
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 外交时间;

		// Token: 0x04000553 RID: 1363
		[WrappingFieldAttribute(下标 = 4, 长度 = 25)]
		public string 行会名字;
	}
}
