using System;

namespace GameServer.Networking
{
	// Token: 0x02000078 RID: 120
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 45, 长度 = 4, 注释 = "CharacterUseItemsPacket")]
	public sealed class CharacterUseItemsPacket : GamePacket
	{
		// Token: 0x0600015F RID: 351 RVA: 0x0000344A File Offset: 0x0000164A
		public CharacterUseItemsPacket()
		{
			
			
		}

		// Token: 0x040004A1 RID: 1185
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 背包类型;

		// Token: 0x040004A2 RID: 1186
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 物品位置;
	}
}
