using System;

namespace GameServer.Networking
{
	// Token: 0x0200009C RID: 156
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 109, 长度 = 35, 注释 = "更改摊位名字")]
	public sealed class 更改摊位名字 : GamePacket
	{
		// Token: 0x06000183 RID: 387 RVA: 0x0000344A File Offset: 0x0000164A
		public 更改摊位名字()
		{
			
			
		}

		// Token: 0x040004EC RID: 1260
		[WrappingFieldAttribute(下标 = 2, 长度 = 33)]
		public string 摊位名字;
	}
}
