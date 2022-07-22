using System;

namespace GameServer.Networking
{
	// Token: 0x0200006C RID: 108
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 22, 长度 = 6, 注释 = "进入传送门触发")]
	public sealed class 客户进入法阵 : GamePacket
	{
		// Token: 0x06000153 RID: 339 RVA: 0x0000344A File Offset: 0x0000164A
		public 客户进入法阵()
		{
			
			
		}

		// Token: 0x0400048E RID: 1166
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 法阵编号;
	}
}
