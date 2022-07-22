using System;

namespace GameServer.Networking
{
	// Token: 0x020001F0 RID: 496
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 570, 长度 = 7, 注释 = "CongratsToApprenticeForUpgradePacket")]
	public sealed class 恭喜徒弟升级 : GamePacket
	{
		// Token: 0x060002D9 RID: 729 RVA: 0x0000344A File Offset: 0x0000164A
		public 恭喜徒弟升级()
		{
			
			
		}

		// Token: 0x04000745 RID: 1861
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 徒弟编号;

		// Token: 0x04000746 RID: 1862
		[WrappingFieldAttribute(下标 = 6, 长度 = 1)]
		public int 祝贺等级;
	}
}
