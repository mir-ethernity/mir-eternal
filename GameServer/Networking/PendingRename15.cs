using System;
using System.Drawing;

namespace GameServer.Networking
{
	// Token: 0x02000068 RID: 104
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 18, 长度 = 6, 注释 = "角色走动")]
	public sealed class 客户角色走动 : GamePacket
	{
		// Token: 0x0600014F RID: 335 RVA: 0x0000344A File Offset: 0x0000164A
		public 客户角色走动()
		{
			
			
		}

		// Token: 0x04000489 RID: 1161
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public Point 坐标;
	}
}
