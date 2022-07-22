using System;

namespace GameServer.Networking
{
	// Token: 0x0200020A RID: 522
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 600, 长度 = 6, 注释 = "脱离行会公告")]
	public sealed class 脱离行会公告 : GamePacket
	{
		// Token: 0x060002F3 RID: 755 RVA: 0x0000344A File Offset: 0x0000164A
		public 脱离行会公告()
		{
			
			
		}

		// Token: 0x0400076C RID: 1900
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
