using System;

namespace GameServer.Networking
{
	// Token: 0x0200016A RID: 362
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 110, 长度 = 7, 注释 = "同步PK模式")]
	public sealed class 同步对战模式 : GamePacket
	{
		// Token: 0x06000253 RID: 595 RVA: 0x0000344A File Offset: 0x0000164A
		public 同步对战模式()
		{
			
			
		}

		// Token: 0x0400064C RID: 1612
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		// Token: 0x0400064D RID: 1613
		[WrappingFieldAttribute(下标 = 6, 长度 = 1)]
		public byte AttackMode;
	}
}
