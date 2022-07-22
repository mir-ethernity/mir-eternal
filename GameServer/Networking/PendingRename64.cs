using System;

namespace GameServer.Networking
{
	// Token: 0x020001E4 RID: 484
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 556, 长度 = 6, 注释 = "玩家申请收徒")]
	public sealed class 申请收徒应答 : GamePacket
	{
		// Token: 0x060002CD RID: 717 RVA: 0x0000344A File Offset: 0x0000164A
		public 申请收徒应答()
		{
			
			
		}

		// Token: 0x04000738 RID: 1848
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
