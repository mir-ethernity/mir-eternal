using System;

namespace GameServer.Networking
{
	// Token: 0x0200014E RID: 334
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 75, 长度 = 46, 注释 = "CharacterExpChangesPacket")]
	public sealed class CharacterExpChangesPacket : GamePacket
	{
		// Token: 0x06000237 RID: 567 RVA: 0x0000344A File Offset: 0x0000164A
		public CharacterExpChangesPacket()
		{
			
			
		}

		// Token: 0x040005F4 RID: 1524
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 经验增加;

		// Token: 0x040005F5 RID: 1525
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 今日增加;

		// Token: 0x040005F6 RID: 1526
		[WrappingFieldAttribute(下标 = 10, 长度 = 4)]
		public int 经验上限;

		// Token: 0x040005F7 RID: 1527
		[WrappingFieldAttribute(下标 = 14, 长度 = 4)]
		public int 双倍经验;

		// Token: 0x040005F8 RID: 1528
		[WrappingFieldAttribute(下标 = 18, 长度 = 4)]
		public int 当前经验;

		// Token: 0x040005F9 RID: 1529
		[WrappingFieldAttribute(下标 = 26, 长度 = 4)]
		public int 升级所需;
	}
}
