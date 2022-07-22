using System;
using System.Drawing;

namespace GameServer.Networking
{
	// Token: 0x02000135 RID: 309
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 39, 长度 = 17, 注释 = "进入场景(包括商店/随机卷)")]
	public sealed class 玩家进入场景 : GamePacket
	{
		// Token: 0x0600021E RID: 542 RVA: 0x0000344A File Offset: 0x0000164A
		public 玩家进入场景()
		{
			
			
		}

		// Token: 0x040005A2 RID: 1442
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 地图编号;

		// Token: 0x040005A3 RID: 1443
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 路线编号;

		// Token: 0x040005A4 RID: 1444
		[WrappingFieldAttribute(下标 = 10, 长度 = 1)]
		public byte RouteStatus;

		// Token: 0x040005A5 RID: 1445
		[WrappingFieldAttribute(下标 = 11, 长度 = 4)]
		public Point 当前坐标;

		// Token: 0x040005A6 RID: 1446
		[WrappingFieldAttribute(下标 = 15, 长度 = 2)]
		public ushort 当前高度;
	}
}
