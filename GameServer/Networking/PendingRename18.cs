using System;

namespace GameServer.Networking
{
	// Token: 0x0200006E RID: 110
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 24, 长度 = 3, 注释 = "玩家请求复活")]
	public sealed class 客户请求复活 : GamePacket
	{
		// Token: 0x06000155 RID: 341 RVA: 0x0000344A File Offset: 0x0000164A
		public 客户请求复活()
		{
			
			
		}

		// Token: 0x04000490 RID: 1168
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 复活方式;
	}
}
