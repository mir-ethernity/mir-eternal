using System;

namespace GameServer.Networking
{
	// Token: 0x02000230 RID: 560
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 656, 长度 = 6, 注释 = "同步元宝数量")]
	public sealed class 同步元宝数量 : GamePacket
	{
		// Token: 0x06000319 RID: 793 RVA: 0x0000344A File Offset: 0x0000164A
		public 同步元宝数量()
		{
			
			
		}

		// Token: 0x0400078E RID: 1934
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 元宝数量;
	}
}
