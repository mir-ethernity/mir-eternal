using System;

namespace GameServer.Networking
{
	// Token: 0x0200016D RID: 365
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 116, 长度 = 21, 注释 = "添加BUFF")]
	public sealed class ObjectAddStatePacket : GamePacket
	{
		// Token: 0x06000256 RID: 598 RVA: 0x0000344A File Offset: 0x0000164A
		public ObjectAddStatePacket()
		{
			
			
		}

		// Token: 0x04000650 RID: 1616
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		// Token: 0x04000651 RID: 1617
		[WrappingFieldAttribute(下标 = 6, 长度 = 2)]
		public ushort Buff编号;

		// Token: 0x04000652 RID: 1618
		[WrappingFieldAttribute(下标 = 8, 长度 = 4)]
		public int Buff索引;

		// Token: 0x04000653 RID: 1619
		[WrappingFieldAttribute(下标 = 12, 长度 = 4)]
		public int Buff来源;

		// Token: 0x04000654 RID: 1620
		[WrappingFieldAttribute(下标 = 16, 长度 = 4)]
		public int 持续时间;

		// Token: 0x04000655 RID: 1621
		[WrappingFieldAttribute(下标 = 20, 长度 = 1)]
		public byte Buff层数;
	}
}
