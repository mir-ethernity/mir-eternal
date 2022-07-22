using System;

namespace GameServer.Networking
{
	// Token: 0x020001ED RID: 493
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 567, 长度 = 6, 注释 = "收徒成功提示")]
	public sealed class 收徒成功提示 : GamePacket
	{
		// Token: 0x060002D6 RID: 726 RVA: 0x0000344A File Offset: 0x0000164A
		public 收徒成功提示()
		{
			
			
		}

		// Token: 0x04000743 RID: 1859
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
