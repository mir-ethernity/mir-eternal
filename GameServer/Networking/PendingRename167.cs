using System;

namespace GameServer.Networking
{
	// Token: 0x02000151 RID: 337
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 78, 长度 = 14, 注释 = "同步hp")]
	public sealed class 同步对象体力 : GamePacket
	{
		// Token: 0x0600023A RID: 570 RVA: 0x0000344A File Offset: 0x0000164A
		public 同步对象体力()
		{
			
			
		}

		// Token: 0x040005FD RID: 1533
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		// Token: 0x040005FE RID: 1534
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 当前体力;

		// Token: 0x040005FF RID: 1535
		[WrappingFieldAttribute(下标 = 10, 长度 = 4)]
		public int 体力上限;
	}
}
