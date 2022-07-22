using System;

namespace GameServer.Networking
{
	// Token: 0x0200010B RID: 267
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 579, 长度 = 27, 注释 = "StartGuildWarPacket")]
	public sealed class StartGuildWarPacket : GamePacket
	{
		// Token: 0x060001F2 RID: 498 RVA: 0x0000344A File Offset: 0x0000164A
		public StartGuildWarPacket()
		{
			
			
		}

		// Token: 0x0400055E RID: 1374
		[WrappingFieldAttribute(下标 = 2, 长度 = 25)]
		public string 行会名字;
	}
}
