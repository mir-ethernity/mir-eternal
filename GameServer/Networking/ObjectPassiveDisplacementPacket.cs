using System;
using System.Drawing;

namespace GameServer.Networking
{
	// Token: 0x0200013C RID: 316
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 49, 长度 = 17, 注释 = "被动位移")]
	public sealed class ObjectPassiveDisplacementPacket : GamePacket
	{
		// Token: 0x06000225 RID: 549 RVA: 0x0000344A File Offset: 0x0000164A
		public ObjectPassiveDisplacementPacket()
		{
			
			
		}

		// Token: 0x040005B5 RID: 1461
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		// Token: 0x040005B6 RID: 1462
		[WrappingFieldAttribute(下标 = 6, 长度 = 1)]
		public byte 第一标记;

		// Token: 0x040005B7 RID: 1463
		[WrappingFieldAttribute(下标 = 7, 长度 = 4)]
		public Point 位移坐标;

		// Token: 0x040005B8 RID: 1464
		[WrappingFieldAttribute(下标 = 11, 长度 = 2)]
		public ushort 第二标记;

		// Token: 0x040005B9 RID: 1465
		[WrappingFieldAttribute(下标 = 13, 长度 = 2)]
		public ushort 位移朝向;

		// Token: 0x040005BA RID: 1466
		[WrappingFieldAttribute(下标 = 15, 长度 = 2)]
		public ushort 位移速度;
	}
}
