using System;

namespace GameServer.Networking
{
	// Token: 0x02000077 RID: 119
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 44, 长度 = 6, 注释 = "物品转移/交换/合并/更换装备")]
	public sealed class CharacterTransferItemPacket : GamePacket
	{
		// Token: 0x0600015E RID: 350 RVA: 0x0000344A File Offset: 0x0000164A
		public CharacterTransferItemPacket()
		{
			
			
		}

		// Token: 0x0400049D RID: 1181
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 当前背包;

		// Token: 0x0400049E RID: 1182
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 原有位置;

		// Token: 0x0400049F RID: 1183
		[WrappingFieldAttribute(下标 = 4, 长度 = 1)]
		public byte 目标背包;

		// Token: 0x040004A0 RID: 1184
		[WrappingFieldAttribute(下标 = 5, 长度 = 1)]
		public byte 目标位置;
	}
}
