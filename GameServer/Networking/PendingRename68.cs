using System;

namespace GameServer.Networking
{
	// Token: 0x0200020F RID: 527
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 605, 长度 = 6, 注释 = "申请结盟应答")]
	public sealed class 申请结盟应答 : GamePacket
	{
		// Token: 0x060002F8 RID: 760 RVA: 0x0000344A File Offset: 0x0000164A
		public 申请结盟应答()
		{
			
			
		}

		// Token: 0x04000772 RID: 1906
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 行会编号;
	}
}
