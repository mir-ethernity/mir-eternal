using System;

namespace GameServer.Networking
{
	// Token: 0x0200016F RID: 367
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 118, 长度 = 21, 注释 = "BUFF变动")]
	public sealed class ObjectStateChangePacket : GamePacket
	{
		// Token: 0x06000258 RID: 600 RVA: 0x0000344A File Offset: 0x0000164A
		public ObjectStateChangePacket()
		{
			
			
		}

		// Token: 0x04000658 RID: 1624
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		// Token: 0x04000659 RID: 1625
		[WrappingFieldAttribute(下标 = 6, 长度 = 2)]
		public ushort Buff编号;

		// Token: 0x0400065A RID: 1626
		[WrappingFieldAttribute(下标 = 8, 长度 = 4)]
		public int Buff索引;

		// Token: 0x0400065B RID: 1627
		[WrappingFieldAttribute(下标 = 12, 长度 = 1)]
		public byte 当前层数;

		// Token: 0x0400065C RID: 1628
		[WrappingFieldAttribute(下标 = 13, 长度 = 4)]
		public int 剩余时间;

		// Token: 0x0400065D RID: 1629
		[WrappingFieldAttribute(下标 = 17, 长度 = 4)]
		public int 持续时间;
	}
}
