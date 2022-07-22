using System;

namespace GameServer.Networking
{
	// Token: 0x02000138 RID: 312
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 45, 长度 = 6, 注释 = "同步游戏ping")]
	public sealed class InternetSpeedTestPacket : GamePacket
	{
		// Token: 0x06000221 RID: 545 RVA: 0x0000344A File Offset: 0x0000164A
		public InternetSpeedTestPacket()
		{
			
			
		}

		// Token: 0x040005AB RID: 1451
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 当前时间;
	}
}
