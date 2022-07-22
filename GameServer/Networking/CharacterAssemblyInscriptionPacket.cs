using System;

namespace GameServer.Networking
{
	// Token: 0x02000164 RID: 356
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 101, 长度 = 6, 注释 = "CharacterAssemblyInscriptionPacket")]
	public sealed class CharacterAssemblyInscriptionPacket : GamePacket
	{
		// Token: 0x0600024D RID: 589 RVA: 0x0000344A File Offset: 0x0000164A
		public CharacterAssemblyInscriptionPacket()
		{
			
			
		}

		// Token: 0x04000640 RID: 1600
		[WrappingFieldAttribute(下标 = 2, 长度 = 2)]
		public ushort 技能编号;

		// Token: 0x04000641 RID: 1601
		[WrappingFieldAttribute(下标 = 4, 长度 = 1)]
		public byte 铭文编号;

		// Token: 0x04000642 RID: 1602
		[WrappingFieldAttribute(下标 = 5, 长度 = 1)]
		public byte 技能等级;
	}
}
