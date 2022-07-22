using System;

namespace GameServer.Networking
{
	// Token: 0x020001AA RID: 426
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 258, 长度 = 3, 注释 = "武器升级结果")]
	public sealed class 武器升级结果 : GamePacket
	{
		// Token: 0x06000293 RID: 659 RVA: 0x0000344A File Offset: 0x0000164A
		public 武器升级结果()
		{
			
			
		}

		// Token: 0x040006D2 RID: 1746
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 升级结果;
	}
}
