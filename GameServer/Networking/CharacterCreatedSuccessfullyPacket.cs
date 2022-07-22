using System;

namespace GameServer.Networking
{
	// Token: 0x02000244 RID: 580
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 1005, 长度 = 96, 注释 = "CharacterCreatedSuccessfullyPacket")]
	public sealed class CharacterCreatedSuccessfullyPacket : GamePacket
	{
		// Token: 0x0600032F RID: 815 RVA: 0x0000344A File Offset: 0x0000164A
		public CharacterCreatedSuccessfullyPacket()
		{
			
			
		}

		// Token: 0x0400079E RID: 1950
		[WrappingFieldAttribute(下标 = 2, 长度 = 94)]
		public byte[] 角色描述;
	}
}
