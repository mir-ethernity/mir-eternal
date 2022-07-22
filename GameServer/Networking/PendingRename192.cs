using System;

namespace GameServer.Networking
{
	// Token: 0x020001A6 RID: 422
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 254, 长度 = 3, 注释 = "玩家取下灵石")]
	public sealed class 成功取下灵石 : GamePacket
	{
		// Token: 0x0600028F RID: 655 RVA: 0x0000344A File Offset: 0x0000164A
		public 成功取下灵石()
		{
			
			
		}

		// Token: 0x040006CF RID: 1743
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 灵石状态;
	}
}
