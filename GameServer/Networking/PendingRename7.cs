using System;

namespace GameServer.Networking
{
	// Token: 0x0200006D RID: 109
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 23, 长度 = 6, 注释 = "帧同步, 请求Ping")]
	public sealed class 客户网速测试 : GamePacket
	{
		// Token: 0x06000154 RID: 340 RVA: 0x0000344A File Offset: 0x0000164A
		public 客户网速测试()
		{
			
			
		}

		// Token: 0x0400048F RID: 1167
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 客户时间;
	}
}
