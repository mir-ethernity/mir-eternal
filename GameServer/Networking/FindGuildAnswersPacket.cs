using System;

namespace GameServer.Networking
{
	// Token: 0x020001FD RID: 509
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 586, 长度 = 231, 注释 = "FindGuildAnswersPacket")]
	public sealed class FindGuildAnswersPacket : GamePacket
	{
		// Token: 0x060002E6 RID: 742 RVA: 0x0000344A File Offset: 0x0000164A
		public FindGuildAnswersPacket()
		{
			
			
		}

		// Token: 0x04000756 RID: 1878
		[WrappingFieldAttribute(下标 = 2, 长度 = 229)]
		public byte[] 字节数据;
	}
}
