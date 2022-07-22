using System;
using System.Drawing;

namespace GameServer.Networking
{
	// Token: 0x02000188 RID: 392
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 150, 长度 = 24, 注释 = "掉落物品")]
	public sealed class ObjectDropItemsPacket : GamePacket
	{
		// Token: 0x06000271 RID: 625 RVA: 0x0000344A File Offset: 0x0000164A
		public ObjectDropItemsPacket()
		{
			
			
		}

		// Token: 0x0400069C RID: 1692
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		// Token: 0x0400069D RID: 1693
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 地图编号;

		// Token: 0x0400069E RID: 1694
		[WrappingFieldAttribute(下标 = 10, 长度 = 4)]
		public Point 掉落坐标;

		// Token: 0x0400069F RID: 1695
		[WrappingFieldAttribute(下标 = 14, 长度 = 2)]
		public ushort 掉落高度;

		// Token: 0x040006A0 RID: 1696
		[WrappingFieldAttribute(下标 = 16, 长度 = 4)]
		public int 物品编号;

		// Token: 0x040006A1 RID: 1697
		[WrappingFieldAttribute(下标 = 20, 长度 = 4)]
		public int 物品数量;
	}
}
