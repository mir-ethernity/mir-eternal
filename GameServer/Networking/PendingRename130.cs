using System;
using System.Drawing;

namespace GameServer.Networking
{
	// Token: 0x02000137 RID: 311
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 41, 长度 = 23, 注释 = "切换地图(回城/过图/传送)")]
	public sealed class 玩家切换地图 : GamePacket
	{
		// Token: 0x06000220 RID: 544 RVA: 0x0000344A File Offset: 0x0000164A
		public 玩家切换地图()
		{
			
			
		}

		// Token: 0x040005A7 RID: 1447
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 地图编号;

		// Token: 0x040005A8 RID: 1448
		[WrappingFieldAttribute(下标 = 10, 长度 = 4)]
		public int 路线编号;

		// Token: 0x040005A9 RID: 1449
		[WrappingFieldAttribute(下标 = 14, 长度 = 4)]
		public Point 对象坐标;

		// Token: 0x040005AA RID: 1450
		[WrappingFieldAttribute(下标 = 18, 长度 = 2)]
		public ushort 对象高度;
	}
}
