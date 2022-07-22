using System;

namespace GameServer.Networking
{
	// Token: 0x020001FB RID: 507
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 584, 长度 = 0, 注释 = "查看行会列表")]
	public sealed class 同步行会列表 : GamePacket
	{
		// Token: 0x060002E4 RID: 740 RVA: 0x0000344A File Offset: 0x0000164A
		public 同步行会列表()
		{
			
			
		}

		// Token: 0x04000755 RID: 1877
		[WrappingFieldAttribute(下标 = 4, 长度 = 0)]
		public byte[] 字节数据;
	}
}
