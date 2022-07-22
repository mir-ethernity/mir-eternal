using System;

namespace GameServer.Networking
{
	// Token: 0x0200007A RID: 122
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 47, 长度 = 6, 注释 = "CharacterDropsItemsPacket")]
	public sealed class CharacterDropsItemsPacket : GamePacket
	{
		// Token: 0x06000161 RID: 353 RVA: 0x0000344A File Offset: 0x0000164A
		public CharacterDropsItemsPacket()
		{
			
			
		}

		// Token: 0x040004A8 RID: 1192
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 背包类型;

		// Token: 0x040004A9 RID: 1193
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 物品位置;

		// Token: 0x040004AA RID: 1194
		[WrappingFieldAttribute(下标 = 4, 长度 = 2)]
		public ushort 丢弃数量;
	}
}
