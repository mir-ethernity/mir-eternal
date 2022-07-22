using System;

namespace GameServer.Networking
{
	// Token: 0x020001EA RID: 490
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 564, 长度 = 6, 注释 = "离开师门提示")]
	public sealed class 离开师门提示 : GamePacket
	{
		// Token: 0x060002D3 RID: 723 RVA: 0x0000344A File Offset: 0x0000164A
		public 离开师门提示()
		{
			
			
		}

		// Token: 0x04000740 RID: 1856
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
