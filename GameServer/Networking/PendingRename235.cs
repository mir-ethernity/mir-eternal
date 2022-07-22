using System;

namespace GameServer.Networking
{
	// Token: 0x02000200 RID: 512
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 589, 长度 = 0, 注释 = "查看申请名单")]
	public sealed class 查看申请名单 : GamePacket
	{
		// Token: 0x060002E9 RID: 745 RVA: 0x0000344A File Offset: 0x0000164A
		public 查看申请名单()
		{
			
			
		}

		// Token: 0x04000759 RID: 1881
		[WrappingFieldAttribute(下标 = 4, 长度 = 0)]
		public byte[] 字节描述;
	}
}
