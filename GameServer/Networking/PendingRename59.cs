using System;

namespace GameServer.Networking
{
	// Token: 0x02000201 RID: 513
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 590, 长度 = 6, 注释 = "处理入会申请")]
	public sealed class 入会申请应答 : GamePacket
	{
		// Token: 0x060002EA RID: 746 RVA: 0x0000344A File Offset: 0x0000164A
		public 入会申请应答()
		{
			
			
		}

		// Token: 0x0400075A RID: 1882
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
