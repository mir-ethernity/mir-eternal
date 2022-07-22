using System;

namespace GameServer.Networking
{
	// Token: 0x0200014D RID: 333
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 74, 长度 = 7, 注释 = "CharacterLevelUpPacket")]
	public sealed class CharacterLevelUpPacket : GamePacket
	{
		// Token: 0x06000236 RID: 566 RVA: 0x0000344A File Offset: 0x0000164A
		public CharacterLevelUpPacket()
		{
			
			
		}

		// Token: 0x040005F2 RID: 1522
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		// Token: 0x040005F3 RID: 1523
		[WrappingFieldAttribute(下标 = 6, 长度 = 1)]
		public byte 对象等级;
	}
}
