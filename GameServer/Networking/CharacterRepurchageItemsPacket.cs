using System;

namespace GameServer.Networking
{
	// Token: 0x0200007F RID: 127
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 52, 长度 = 3, 注释 = "CharacterRepurchageItemsPacket")]
	public sealed class CharacterRepurchageItemsPacket : GamePacket
	{
		// Token: 0x06000166 RID: 358 RVA: 0x0000344A File Offset: 0x0000164A
		public CharacterRepurchageItemsPacket()
		{
			
			
		}

		// Token: 0x040004B2 RID: 1202
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 物品位置;
	}
}
