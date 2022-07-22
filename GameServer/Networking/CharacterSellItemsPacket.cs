using System;

namespace GameServer.Networking
{
	// Token: 0x0200007D RID: 125
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 50, 长度 = 6, 注释 = "CharacterSellItemsPacket")]
	public sealed class CharacterSellItemsPacket : GamePacket
	{
		// Token: 0x06000164 RID: 356 RVA: 0x0000344A File Offset: 0x0000164A
		public CharacterSellItemsPacket()
		{
			
			
		}

		// Token: 0x040004AF RID: 1199
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 背包类型;

		// Token: 0x040004B0 RID: 1200
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 物品位置;

		// Token: 0x040004B1 RID: 1201
		[WrappingFieldAttribute(下标 = 4, 长度 = 2)]
		public ushort 卖出数量;
	}
}
