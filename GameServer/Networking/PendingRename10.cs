using System;

namespace GameServer.Networking
{
	// Token: 0x02000123 RID: 291
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 1005, 长度 = 6, 注释 = "客户GetBackCharacterPacket")]
	public sealed class 客户GetBackCharacterPacket : GamePacket
	{
		// Token: 0x0600020C RID: 524 RVA: 0x0000344A File Offset: 0x0000164A
		public 客户GetBackCharacterPacket()
		{
			
			
		}

		// Token: 0x04000579 RID: 1401
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 角色编号;
	}
}
