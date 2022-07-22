using System;

namespace GameServer.Networking
{
	// Token: 0x020001A5 RID: 421
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 253, 长度 = 3, 注释 = "玩家镶嵌灵石")]
	public sealed class 成功镶嵌灵石 : GamePacket
	{
		// Token: 0x0600028E RID: 654 RVA: 0x0000344A File Offset: 0x0000164A
		public 成功镶嵌灵石()
		{
			
			
		}

		// Token: 0x040006CE RID: 1742
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 灵石状态;
	}
}
