using System;

namespace GameServer.Networking
{
	// Token: 0x0200016C RID: 364
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 112, 长度 = 6, 注释 = "离开战斗姿态")]
	public sealed class 离开战斗姿态 : GamePacket
	{
		// Token: 0x06000255 RID: 597 RVA: 0x0000344A File Offset: 0x0000164A
		public 离开战斗姿态()
		{
			
			
		}

		// Token: 0x0400064F RID: 1615
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
