using System;

namespace GameServer.Networking
{
	// Token: 0x020001A4 RID: 420
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 252, 长度 = 3, 注释 = "玩家合成灵石")]
	public sealed class 成功合成灵石 : GamePacket
	{
		// Token: 0x0600028D RID: 653 RVA: 0x0000344A File Offset: 0x0000164A
		public 成功合成灵石()
		{
			
			
		}

		// Token: 0x040006CD RID: 1741
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 灵石状态;
	}
}
