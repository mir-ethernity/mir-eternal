using System;

namespace GameServer.Networking
{
	// Token: 0x0200007B RID: 123
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 48, 长度 = 7, 注释 = "CharacterPickupItemsPacket")]
	public sealed class CharacterPickupItemsPacket : GamePacket
	{
		// Token: 0x06000162 RID: 354 RVA: 0x0000344A File Offset: 0x0000164A
		public CharacterPickupItemsPacket()
		{
			
			
		}

		// Token: 0x040004AB RID: 1195
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 物品编号;
	}
}
