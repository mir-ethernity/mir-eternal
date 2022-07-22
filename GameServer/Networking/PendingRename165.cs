using System;

namespace GameServer.Networking
{
	// Token: 0x0200014A RID: 330
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 71, 长度 = 36, 注释 = "同步对象Buff")]
	public sealed class 同步对象Buff : GamePacket
	{
		// Token: 0x06000233 RID: 563 RVA: 0x0000344A File Offset: 0x0000164A
		public 同步对象Buff()
		{
			
			
		}

		// Token: 0x040005ED RID: 1517
		[WrappingFieldAttribute(下标 = 2, 长度 = 34)]
		public byte[] 字节描述;
	}
}
