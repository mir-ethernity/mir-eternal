using System;

namespace GameServer.Networking
{
	// Token: 0x020001A1 RID: 417
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 223, 长度 = 10, 注释 = "同步对象行会")]
	public sealed class 同步对象行会 : GamePacket
	{
		// Token: 0x0600028A RID: 650 RVA: 0x0000344A File Offset: 0x0000164A
		public 同步对象行会()
		{
			
			
		}

		// Token: 0x040006C8 RID: 1736
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		// Token: 0x040006C9 RID: 1737
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 行会编号;
	}
}
