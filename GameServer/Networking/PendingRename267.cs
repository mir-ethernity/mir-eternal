using System;

namespace GameServer.Networking
{
	// Token: 0x020000B5 RID: 181
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 158, 长度 = 3, 注释 = "更改收徒推送")]
	public sealed class 更改收徒推送 : GamePacket
	{
		// Token: 0x0600019C RID: 412 RVA: 0x0000344A File Offset: 0x0000164A
		public 更改收徒推送()
		{
			
			
		}

		// Token: 0x04000503 RID: 1283
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public bool 收徒推送;
	}
}
