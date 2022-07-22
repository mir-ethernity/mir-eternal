using System;

namespace GameServer.Networking
{
	// Token: 0x020000B7 RID: 183
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 161, 长度 = 0, 注释 = "申请创建行会")]
	public sealed class 申请创建行会 : GamePacket
	{
		// Token: 0x0600019E RID: 414 RVA: 0x0000344A File Offset: 0x0000164A
		public 申请创建行会()
		{
			
			
		}

		// Token: 0x04000504 RID: 1284
		[WrappingFieldAttribute(下标 = 2, 长度 = 0)]
		public byte[] 字节数据;
	}
}
