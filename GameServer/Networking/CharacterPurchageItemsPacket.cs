using System;

namespace GameServer.Networking
{
	// Token: 0x0200007C RID: 124
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 49, 长度 = 12, 注释 = "CharacterPurchageItemsPacket")]
	public sealed class CharacterPurchageItemsPacket : GamePacket
	{
		// Token: 0x06000163 RID: 355 RVA: 0x0000344A File Offset: 0x0000164A
		public CharacterPurchageItemsPacket()
		{
			
			
		}

		// Token: 0x040004AC RID: 1196
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 商店编号;

		// Token: 0x040004AD RID: 1197
		[WrappingFieldAttribute(下标 = 6, 长度 = 6)]
		public int 物品位置;

		// Token: 0x040004AE RID: 1198
		[WrappingFieldAttribute(下标 = 10, 长度 = 2)]
		public ushort 购入数量;
	}
}
