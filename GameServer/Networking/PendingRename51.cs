using System;

namespace GameServer.Networking
{
	// Token: 0x020000DA RID: 218
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 523, 长度 = 6, 注释 = "取消好友关注")]
	public sealed class 取消好友关注 : GamePacket
	{
		// Token: 0x060001C1 RID: 449 RVA: 0x0000344A File Offset: 0x0000164A
		public 取消好友关注()
		{
			
			
		}

		// Token: 0x0400052B RID: 1323
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
