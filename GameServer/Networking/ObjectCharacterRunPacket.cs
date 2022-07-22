using System;
using System.Drawing;

namespace GameServer.Networking
{
	// Token: 0x0200013A RID: 314
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 47, 长度 = 12, 注释 = "角色跑动")]
	public sealed class ObjectCharacterRunPacket : GamePacket
	{
		// Token: 0x06000223 RID: 547 RVA: 0x0000344A File Offset: 0x0000164A
		public ObjectCharacterRunPacket()
		{
			
			
		}

		// Token: 0x040005AF RID: 1455
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		// Token: 0x040005B0 RID: 1456
		[WrappingFieldAttribute(下标 = 6, 长度 = 2)]
		public ushort 移动耗时;

		// Token: 0x040005B1 RID: 1457
		[WrappingFieldAttribute(下标 = 8, 长度 = 4)]
		public Point 移动坐标;
	}
}
