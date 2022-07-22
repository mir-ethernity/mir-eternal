using System;

namespace GameServer.Networking
{
	// Token: 0x020000D4 RID: 212
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 516, 长度 = 6, 注释 = "SendTeamRequestPacket")]
	public sealed class SendTeamRequestPacket : GamePacket
	{
		// Token: 0x060001BB RID: 443 RVA: 0x0000344A File Offset: 0x0000164A
		public SendTeamRequestPacket()
		{
			
			
		}

		// Token: 0x04000522 RID: 1314
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
