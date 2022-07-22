using System;

namespace GameServer.Networking
{
	// Token: 0x020001B1 RID: 433
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 286, 长度 = 0, 注释 = "查看攻城名单")]
	public sealed class 查看攻城名单 : GamePacket
	{
		// Token: 0x0600029A RID: 666 RVA: 0x0000344A File Offset: 0x0000164A
		public 查看攻城名单()
		{
			
			
		}

		// Token: 0x040006E3 RID: 1763
		[WrappingFieldAttribute(下标 = 4, 长度 = 0)]
		public byte[] 字节描述;
	}
}
