using System;

namespace GameServer.Networking
{
	// Token: 0x020000FE RID: 254
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 562, 长度 = 0, 注释 = "更改行会公告")]
	public sealed class 更改行会公告 : GamePacket
	{
		// Token: 0x060001E5 RID: 485 RVA: 0x0000344A File Offset: 0x0000164A
		public 更改行会公告()
		{
			
			
		}

		// Token: 0x04000549 RID: 1353
		[WrappingFieldAttribute(下标 = 2, 长度 = 0)]
		public byte[] 行会公告;
	}
}
