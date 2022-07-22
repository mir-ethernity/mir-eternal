using System;

namespace GameServer.Networking
{
	// Token: 0x02000207 RID: 519
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 597, 长度 = 0, 注释 = "更改行会公告")]
	public sealed class 变更行会公告 : GamePacket
	{
		// Token: 0x060002F0 RID: 752 RVA: 0x0000344A File Offset: 0x0000164A
		public 变更行会公告()
		{
			
			
		}

		// Token: 0x04000767 RID: 1895
		[WrappingFieldAttribute(下标 = 4, 长度 = 0)]
		public byte[] 字节数据;
	}
}
