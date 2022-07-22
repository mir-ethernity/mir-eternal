using System;

namespace GameServer.Networking
{
	// Token: 0x02000092 RID: 146
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 86, 长度 = 5, 注释 = "CharacterBreakdownItemsPacket")]
	public sealed class CharacterBreakdownItemsPacket : GamePacket
	{
		// Token: 0x06000179 RID: 377 RVA: 0x0000344A File Offset: 0x0000164A
		public CharacterBreakdownItemsPacket()
		{
			
			
		}

		// Token: 0x040004DF RID: 1247
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 背包类型;

		// Token: 0x040004E0 RID: 1248
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 物品位置;

		// Token: 0x040004E1 RID: 1249
		[WrappingFieldAttribute(下标 = 4, 长度 = 1)]
		public byte 分解数量;
	}
}
