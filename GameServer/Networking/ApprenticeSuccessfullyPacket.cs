using System;

namespace GameServer.Networking
{
	// Token: 0x020001F2 RID: 498
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 572, 长度 = 6, 注释 = "ApprenticeSuccessfullyPacket")]
	public sealed class ApprenticeSuccessfullyPacket : GamePacket
	{
		// Token: 0x060002DB RID: 731 RVA: 0x0000344A File Offset: 0x0000164A
		public ApprenticeSuccessfullyPacket()
		{
			
			
		}

		// Token: 0x04000748 RID: 1864
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
