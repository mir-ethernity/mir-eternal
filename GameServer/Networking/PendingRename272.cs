using System;

namespace GameServer.Networking
{
	// Token: 0x0200009D RID: 157
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 110, 长度 = 3, 注释 = "更改摊位外观")]
	public sealed class 更改摊位外观 : GamePacket
	{
		// Token: 0x06000184 RID: 388 RVA: 0x0000344A File Offset: 0x0000164A
		public 更改摊位外观()
		{
			
			
		}

		// Token: 0x040004ED RID: 1261
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 外观编号;
	}
}
