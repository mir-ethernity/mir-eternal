using System;

namespace GameServer.Networking
{
	// Token: 0x02000235 RID: 565
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 661, 长度 = 191, 注释 = "查询排行榜单")]
	public sealed class 查询排行榜单 : GamePacket
	{
		// Token: 0x0600031E RID: 798 RVA: 0x0000344A File Offset: 0x0000164A
		public 查询排行榜单()
		{
			
			
		}

		// Token: 0x04000794 RID: 1940
		[WrappingFieldAttribute(下标 = 2, 长度 = 189)]
		public byte[] 字节数据;
	}
}
