using System;
using System.Drawing;

namespace GameServer.Networking
{
	// Token: 0x0200013B RID: 315
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 48, 长度 = 13, 注释 = "角色停止")]
	public sealed class ObjectCharacterStopPacket : GamePacket
	{
		// Token: 0x06000224 RID: 548 RVA: 0x0000344A File Offset: 0x0000164A
		public ObjectCharacterStopPacket()
		{
			
			
		}

		// Token: 0x040005B2 RID: 1458
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		// Token: 0x040005B3 RID: 1459
		[WrappingFieldAttribute(下标 = 7, 长度 = 4)]
		public Point 对象坐标;

		// Token: 0x040005B4 RID: 1460
		[WrappingFieldAttribute(下标 = 11, 长度 = 2)]
		public ushort 对象高度;
	}
}
