using System;

namespace GameServer.Networking
{
	// Token: 0x02000249 RID: 585
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 1010, 长度 = 6, 注释 = "同步网关ping")]
	public sealed class LoginQueryResponsePacket : GamePacket
	{
		// Token: 0x06000334 RID: 820 RVA: 0x0000344A File Offset: 0x0000164A
		public LoginQueryResponsePacket()
		{
			
			
		}

		// Token: 0x040007A2 RID: 1954
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 当前时间;
	}
}
