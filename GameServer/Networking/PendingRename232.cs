using System;

namespace GameServer.Networking
{
	// Token: 0x02000191 RID: 401
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 159, 长度 = 39, 注释 = "更改摊位名字")]
	public sealed class 变更摊位名字 : GamePacket
	{
		// Token: 0x0600027A RID: 634 RVA: 0x0000344A File Offset: 0x0000164A
		public 变更摊位名字()
		{
			
			
		}

		// Token: 0x040006AA RID: 1706
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		// Token: 0x040006AB RID: 1707
		[WrappingFieldAttribute(下标 = 6, 长度 = 33)]
		public string 摊位名字;
	}
}
