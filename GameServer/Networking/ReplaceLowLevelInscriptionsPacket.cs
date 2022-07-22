using System;

namespace GameServer.Networking
{
	// Token: 0x0200008F RID: 143
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 77, 长度 = 4, 注释 = "ReplaceLowLevelInscriptionsPacket")]
	public sealed class ReplaceLowLevelInscriptionsPacket : GamePacket
	{
		// Token: 0x06000176 RID: 374 RVA: 0x0000344A File Offset: 0x0000164A
		public ReplaceLowLevelInscriptionsPacket()
		{
			
			
		}

		// Token: 0x040004D8 RID: 1240
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 装备类型;

		// Token: 0x040004D9 RID: 1241
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 装备位置;
	}
}
