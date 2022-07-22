using System;
using System.Drawing;

namespace GameServer.Networking
{
	// Token: 0x02000141 RID: 321
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 60, 长度 = 20, 注释 = "对象出现, 适用于对象主动进入视野")]
	public sealed class ObjectComesIntoViewPacket : GamePacket
	{
		// Token: 0x0600022A RID: 554 RVA: 0x0000344A File Offset: 0x0000164A
		public ObjectComesIntoViewPacket()
		{
			
			
		}

		// Token: 0x040005C2 RID: 1474
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 出现方式;

		// Token: 0x040005C3 RID: 1475
		[WrappingFieldAttribute(下标 = 3, 长度 = 4)]
		public int 对象编号;

		// Token: 0x040005C4 RID: 1476
		[WrappingFieldAttribute(下标 = 7, 长度 = 1)]
		public byte 现身姿态;

		// Token: 0x040005C5 RID: 1477
		[WrappingFieldAttribute(下标 = 8, 长度 = 4)]
		public Point 现身坐标;

		// Token: 0x040005C6 RID: 1478
		[WrappingFieldAttribute(下标 = 12, 长度 = 2)]
		public ushort 现身高度;

		// Token: 0x040005C7 RID: 1479
		[WrappingFieldAttribute(下标 = 14, 长度 = 2)]
		public ushort 现身方向;

		// Token: 0x040005C8 RID: 1480
		[WrappingFieldAttribute(下标 = 16, 长度 = 1)]
		public byte 体力比例;

		// Token: 0x040005C9 RID: 1481
		[WrappingFieldAttribute(下标 = 18, 长度 = 1)]
		public byte 补充参数;
	}
}
