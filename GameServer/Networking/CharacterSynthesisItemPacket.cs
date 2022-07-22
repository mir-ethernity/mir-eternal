using System;

namespace GameServer.Networking
{
	// Token: 0x02000093 RID: 147
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 87, 长度 = 6, 注释 = "CharacterSynthesisItemPacket")]
	public sealed class CharacterSynthesisItemPacket : GamePacket
	{
		// Token: 0x0600017A RID: 378 RVA: 0x0000344A File Offset: 0x0000164A
		public CharacterSynthesisItemPacket()
		{
			
			
		}

		// Token: 0x040004E2 RID: 1250
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 物品编号;
	}
}
