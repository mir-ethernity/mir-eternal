using System;

namespace GameServer.Networking
{
	// Token: 0x02000079 RID: 121
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 46, 长度 = 8, 注释 = "CharacterSplitItemsPacket")]
	public sealed class CharacterSplitItemsPacket : GamePacket
	{
		// Token: 0x06000160 RID: 352 RVA: 0x0000344A File Offset: 0x0000164A
		public CharacterSplitItemsPacket()
		{
			
			
		}

		// Token: 0x040004A3 RID: 1187
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 当前背包;

		// Token: 0x040004A4 RID: 1188
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 物品位置;

		// Token: 0x040004A5 RID: 1189
		[WrappingFieldAttribute(下标 = 4, 长度 = 1)]
		public byte 目标背包;

		// Token: 0x040004A6 RID: 1190
		[WrappingFieldAttribute(下标 = 5, 长度 = 1)]
		public byte 目标位置;

		// Token: 0x040004A7 RID: 1191
		[WrappingFieldAttribute(下标 = 6, 长度 = 2)]
		public ushort 拆分数量;
	}
}
