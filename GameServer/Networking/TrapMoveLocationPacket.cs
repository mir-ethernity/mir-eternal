using System;
using System.Drawing;

namespace GameServer.Networking
{
	// Token: 0x02000175 RID: 373
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 124, 长度 = 18, 注释 = "陷阱移动")]
	public sealed class TrapMoveLocationPacket : GamePacket
	{
		// Token: 0x0600025E RID: 606 RVA: 0x0000344A File Offset: 0x0000164A
		public TrapMoveLocationPacket()
		{
			
			
		}

		// Token: 0x04000674 RID: 1652
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 陷阱编号;

		// Token: 0x04000675 RID: 1653
		[WrappingFieldAttribute(下标 = 6, 长度 = 2)]
		public ushort 移动速度;

		// Token: 0x04000676 RID: 1654
		[WrappingFieldAttribute(下标 = 8, 长度 = 4)]
		public int 未知参数;

		// Token: 0x04000677 RID: 1655
		[WrappingFieldAttribute(下标 = 12, 长度 = 4)]
		public Point 移动坐标;

		// Token: 0x04000678 RID: 1656
		[WrappingFieldAttribute(下标 = 16, 长度 = 4)]
		public ushort 移动高度;
	}
}
