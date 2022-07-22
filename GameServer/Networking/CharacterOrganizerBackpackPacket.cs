using System;

namespace GameServer.Networking
{
	// Token: 0x02000084 RID: 132
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 58, 长度 = 3, 注释 = "CharacterOrganizerBackpackPacket")]
	public sealed class CharacterOrganizerBackpackPacket : GamePacket
	{
		// Token: 0x0600016B RID: 363 RVA: 0x0000344A File Offset: 0x0000164A
		public CharacterOrganizerBackpackPacket()
		{
			
			
		}

		// Token: 0x040004B9 RID: 1209
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 背包类型;
	}
}
