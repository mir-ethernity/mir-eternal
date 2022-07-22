using System;

namespace GameServer.Networking
{
	// Token: 0x02000087 RID: 135
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 69, 长度 = 5, 注释 = "玩家拆除灵石")]
	public sealed class 玩家拆除灵石 : GamePacket
	{
		// Token: 0x0600016E RID: 366 RVA: 0x0000344A File Offset: 0x0000164A
		public 玩家拆除灵石()
		{
			
			
		}

		// Token: 0x040004C0 RID: 1216
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 装备类型;

		// Token: 0x040004C1 RID: 1217
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 装备位置;

		// Token: 0x040004C2 RID: 1218
		[WrappingFieldAttribute(下标 = 4, 长度 = 1)]
		public byte 装备孔位;
	}
}
