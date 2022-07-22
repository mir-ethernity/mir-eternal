using System;

namespace GameServer.Networking
{
	// Token: 0x020001E6 RID: 486
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 558, 长度 = 6, 注释 = "同意收徒申请")]
	public sealed class 收徒申请同意 : GamePacket
	{
		// Token: 0x060002CF RID: 719 RVA: 0x0000344A File Offset: 0x0000164A
		public 收徒申请同意()
		{
			
			
		}

		// Token: 0x0400073D RID: 1853
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
