using System;

namespace GameServer.Networking
{
	// Token: 0x020001F1 RID: 497
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 571, 长度 = 6, 注释 = "CongratsToApprenticeForAnsweringPacket")]
	public sealed class CongratsToApprenticeForAnsweringPacket : GamePacket
	{
		// Token: 0x060002DA RID: 730 RVA: 0x0000344A File Offset: 0x0000164A
		public CongratsToApprenticeForAnsweringPacket()
		{
			
			
		}

		// Token: 0x04000747 RID: 1863
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 徒弟编号;
	}
}
