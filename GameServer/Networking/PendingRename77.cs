using System;

namespace GameServer.Networking
{
	// Token: 0x02000110 RID: 272
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 584, 长度 = 28, 注释 = "申请行会敌对")]
	public sealed class 申请行会敌对 : GamePacket
	{
		// Token: 0x060001F7 RID: 503 RVA: 0x0000344A File Offset: 0x0000164A
		public 申请行会敌对()
		{
			
			
		}

		// Token: 0x04000563 RID: 1379
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 敌对时间;

		// Token: 0x04000564 RID: 1380
		[WrappingFieldAttribute(下标 = 3, 长度 = 25)]
		public string 行会名字;
	}
}
