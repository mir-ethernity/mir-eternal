using System;
using System.Drawing;

namespace GameServer.Networking
{
	// Token: 0x02000067 RID: 103
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 17, 长度 = 6, 注释 = "角色跑动")]
	public sealed class 客户角色跑动 : GamePacket
	{
		// Token: 0x0600014E RID: 334 RVA: 0x0000344A File Offset: 0x0000164A
		public 客户角色跑动()
		{
			
			
		}

		// Token: 0x04000488 RID: 1160
		[WrappingFieldAttribute(下标 = 2, 长度 = 4, 反向 = true)]
		public Point 坐标;
	}
}
