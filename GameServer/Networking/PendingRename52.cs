using System;

namespace GameServer.Networking
{
	// Token: 0x020000CC RID: 204
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 237, 长度 = 8, 注释 = "回应组队请求")]
	public sealed class 回应组队请求 : GamePacket
	{
		// Token: 0x060001B3 RID: 435 RVA: 0x0000344A File Offset: 0x0000164A
		public 回应组队请求()
		{
			
			
		}

		// Token: 0x0400051B RID: 1307
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		// Token: 0x0400051C RID: 1308
		[WrappingFieldAttribute(下标 = 6, 长度 = 1)]
		public byte 组队方式;

		// Token: 0x0400051D RID: 1309
		[WrappingFieldAttribute(下标 = 7, 长度 = 1)]
		public byte 回应方式;
	}
}
