using System;

namespace GameServer.Networking
{
	// Token: 0x020000F8 RID: 248
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 556, 长度 = 31, 注释 = "申请加入行会")]
	public sealed class 申请加入行会 : GamePacket
	{
		// Token: 0x060001DF RID: 479 RVA: 0x0000344A File Offset: 0x0000164A
		public 申请加入行会()
		{
			
			
		}

		// Token: 0x04000542 RID: 1346
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 行会编号;

		// Token: 0x04000543 RID: 1347
		[WrappingFieldAttribute(下标 = 6, 长度 = 25)]
		public string 行会名字;
	}
}
