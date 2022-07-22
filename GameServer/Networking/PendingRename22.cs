using System;
using System.Drawing;

namespace GameServer.Networking
{
	// Token: 0x02000064 RID: 100
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 14, 长度 = 10, 注释 = "上传角色位置")]
	public sealed class 上传角色位置 : GamePacket
	{
		// Token: 0x0600014B RID: 331 RVA: 0x0000344A File Offset: 0x0000164A
		public 上传角色位置()
		{
			
			
		}

		// Token: 0x04000484 RID: 1156
		[WrappingFieldAttribute(下标 = 4, 长度 = 4)]
		public Point 坐标;

		// Token: 0x04000485 RID: 1157
		[WrappingFieldAttribute(下标 = 8, 长度 = 2)]
		public ushort 高度;
	}
}
