using System;
using System.Drawing;

namespace GameServer.Networking
{
	// Token: 0x02000174 RID: 372
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 123, 长度 = 30, 注释 = "陷阱出现")]
	public sealed class TrapComesIntoViewPacket : GamePacket
	{
		// Token: 0x0600025D RID: 605 RVA: 0x0000344A File Offset: 0x0000164A
		public TrapComesIntoViewPacket()
		{
			
			
		}

		// Token: 0x0400066B RID: 1643
		[WrappingFieldAttribute(下标 = 4, 长度 = 4)]
		public int 地图编号;

		// Token: 0x0400066C RID: 1644
		[WrappingFieldAttribute(下标 = 8, 长度 = 4)]
		public int 来源编号;

		// Token: 0x0400066D RID: 1645
		[WrappingFieldAttribute(下标 = 12, 长度 = 2)]
		public ushort 陷阱编号;

		// Token: 0x0400066E RID: 1646
		[WrappingFieldAttribute(下标 = 14, 长度 = 4)]
		public Point 陷阱坐标;

		// Token: 0x0400066F RID: 1647
		[WrappingFieldAttribute(下标 = 18, 长度 = 2)]
		public ushort 陷阱高度;

		// Token: 0x04000670 RID: 1648
		[WrappingFieldAttribute(下标 = 20, 长度 = 2)]
		public ushort 持续时间;

		// Token: 0x04000671 RID: 1649
		[WrappingFieldAttribute(下标 = 22, 长度 = 2)]
		public ushort 未知参数;

		// Token: 0x04000672 RID: 1650
		[WrappingFieldAttribute(下标 = 24, 长度 = 4)]
		public Point 未知坐标;

		// Token: 0x04000673 RID: 1651
		[WrappingFieldAttribute(下标 = 28, 长度 = 2)]
		public ushort 未知高度;
	}
}
