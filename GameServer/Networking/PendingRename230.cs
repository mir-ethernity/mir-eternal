using System;

namespace GameServer.Networking
{
	// Token: 0x02000166 RID: 358
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 104, 长度 = 10, 注释 = "体力变动飘字")]
	public sealed class 体力变动飘字 : GamePacket
	{
		// Token: 0x0600024F RID: 591 RVA: 0x0000344A File Offset: 0x0000164A
		public 体力变动飘字()
		{
			
			
		}

		// Token: 0x04000644 RID: 1604
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		// Token: 0x04000645 RID: 1605
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 血量变化;
	}
}
