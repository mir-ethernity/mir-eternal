using System;

namespace GameServer.Networking
{
	// Token: 0x020001D9 RID: 473
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 543, 长度 = 3, 注释 = "收徒推送应答")]
	public sealed class 收徒推送应答 : GamePacket
	{
		// Token: 0x060002C2 RID: 706 RVA: 0x0000344A File Offset: 0x0000164A
		public 收徒推送应答()
		{
			
			
		}

		// Token: 0x0400072F RID: 1839
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public bool 收徒推送;
	}
}
