using System;
using System.Drawing;

namespace GameServer.Networking
{
	// Token: 0x02000139 RID: 313
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 46, 长度 = 12, 注释 = "角色走动")]
	public sealed class ObjectCharacterWalkPacket : GamePacket
	{
		// Token: 0x06000222 RID: 546 RVA: 0x0000344A File Offset: 0x0000164A
		public ObjectCharacterWalkPacket()
		{
			
			
		}

		// Token: 0x040005AC RID: 1452
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		// Token: 0x040005AD RID: 1453
		[WrappingFieldAttribute(下标 = 6, 长度 = 2)]
		public ushort 移动速度;

		// Token: 0x040005AE RID: 1454
		[WrappingFieldAttribute(下标 = 8, 长度 = 4)]
		public Point 移动坐标;
	}
}
