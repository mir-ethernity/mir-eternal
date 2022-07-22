using System;

namespace GameServer.Networking
{
	// Token: 0x02000124 RID: 292
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 1007, 长度 = 6, 注释 = "帧同步, 请求Ping")]
	public sealed class 测试网关网速 : GamePacket
	{
		// Token: 0x0600020D RID: 525 RVA: 0x0000344A File Offset: 0x0000164A
		public 测试网关网速()
		{
			
			
		}

		// Token: 0x0400057A RID: 1402
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 客户时间;
	}
}
