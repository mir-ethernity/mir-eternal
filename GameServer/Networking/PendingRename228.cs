using System;

namespace GameServer.Networking
{
	// Token: 0x02000170 RID: 368
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 119, 长度 = 22, 注释 = "BUFF效果")]
	public sealed class 触发状态效果 : GamePacket
	{
		// Token: 0x06000259 RID: 601 RVA: 0x0000344A File Offset: 0x0000164A
		public 触发状态效果()
		{
			
			
		}

		// Token: 0x0400065E RID: 1630
		[WrappingFieldAttribute(下标 = 6, 长度 = 2)]
		public ushort Buff编号;

		// Token: 0x0400065F RID: 1631
		[WrappingFieldAttribute(下标 = 8, 长度 = 4)]
		public int Buff来源;

		// Token: 0x04000660 RID: 1632
		[WrappingFieldAttribute(下标 = 12, 长度 = 4)]
		public int Buff目标;

		// Token: 0x04000661 RID: 1633
		[WrappingFieldAttribute(下标 = 16, 长度 = 4)]
		public int 血量变化;
	}
}
