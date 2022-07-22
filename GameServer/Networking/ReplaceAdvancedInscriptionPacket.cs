using System;

namespace GameServer.Networking
{
	// Token: 0x0200008B RID: 139
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 73, 长度 = 4, 注释 = "ReplaceAdvancedInscriptionPacket")]
	public sealed class ReplaceAdvancedInscriptionPacket : GamePacket
	{
		// Token: 0x06000172 RID: 370 RVA: 0x0000344A File Offset: 0x0000164A
		public ReplaceAdvancedInscriptionPacket()
		{
			
			
		}

		// Token: 0x040004CD RID: 1229
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 装备类型;

		// Token: 0x040004CE RID: 1230
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 装备位置;
	}
}
