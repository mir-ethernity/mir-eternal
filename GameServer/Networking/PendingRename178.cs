using System;

namespace GameServer.Networking
{
	// Token: 0x02000171 RID: 369
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 120, 长度 = 0, 注释 = "同步BUFF列表")]
	public sealed class 同步状态列表 : GamePacket
	{
		// Token: 0x0600025A RID: 602 RVA: 0x0000344A File Offset: 0x0000164A
		public 同步状态列表()
		{
			
			
		}

		// Token: 0x04000662 RID: 1634
		[WrappingFieldAttribute(下标 = 4, 长度 = 0)]
		public byte[] 字节数据;
	}
}
