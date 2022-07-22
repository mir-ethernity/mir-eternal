using System;

namespace GameServer.Networking
{
	// Token: 0x020000FB RID: 251
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 559, 长度 = 34, 注释 = "InviteToJoinGuildPacket")]
	public sealed class InviteToJoinGuildPacket : GamePacket
	{
		// Token: 0x060001E2 RID: 482 RVA: 0x0000344A File Offset: 0x0000164A
		public InviteToJoinGuildPacket()
		{
			
			
		}

		// Token: 0x04000546 RID: 1350
		[WrappingFieldAttribute(下标 = 2, 长度 = 32)]
		public string 对象名字;
	}
}
