using System;

namespace GameServer.Networking
{
	// Token: 0x020001D8 RID: 472
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 542, 长度 = 0, 注释 = "查询线路信息")]
	public sealed class 查询线路信息 : GamePacket
	{
		// Token: 0x060002C1 RID: 705 RVA: 0x0000344A File Offset: 0x0000164A
		public 查询线路信息()
		{
			
			
		}

		// Token: 0x0400072E RID: 1838
		[WrappingFieldAttribute(下标 = 4, 长度 = 0)]
		public byte[] 字节数据;
	}
}
