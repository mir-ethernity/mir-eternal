using System;
using System.Drawing;

namespace GameServer.Networking
{
	// Token: 0x0200015D RID: 349
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 94, 长度 = 25, 注释 = "开始释放技能(技能信息,目标,坐标,速率)")]
	public sealed class 开始释放技能 : GamePacket
	{
		// Token: 0x06000246 RID: 582 RVA: 0x000034E1 File Offset: 0x000016E1
		public 开始释放技能()
		{
			
			this.加速率一 = 10000;
			this.加速率二 = 10000;
			
		}

		// Token: 0x04000612 RID: 1554
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		// Token: 0x04000613 RID: 1555
		[WrappingFieldAttribute(下标 = 6, 长度 = 2)]
		public ushort 技能编号;

		// Token: 0x04000614 RID: 1556
		[WrappingFieldAttribute(下标 = 8, 长度 = 1)]
		public byte 技能等级;

		// Token: 0x04000615 RID: 1557
		[WrappingFieldAttribute(下标 = 9, 长度 = 1)]
		public byte 技能铭文;

		// Token: 0x04000616 RID: 1558
		[WrappingFieldAttribute(下标 = 10, 长度 = 4)]
		public int 目标编号;

		// Token: 0x04000617 RID: 1559
		[WrappingFieldAttribute(下标 = 14, 长度 = 4)]
		public Point 锚点坐标;

		// Token: 0x04000618 RID: 1560
		[WrappingFieldAttribute(下标 = 18, 长度 = 2)]
		public ushort 锚点高度;

		// Token: 0x04000619 RID: 1561
		[WrappingFieldAttribute(下标 = 20, 长度 = 2)]
		public ushort 加速率一;

		// Token: 0x0400061A RID: 1562
		[WrappingFieldAttribute(下标 = 22, 长度 = 2)]
		public ushort 加速率二;

		// Token: 0x0400061B RID: 1563
		[WrappingFieldAttribute(下标 = 24, 长度 = 1)]
		public byte 动作编号;
	}
}
