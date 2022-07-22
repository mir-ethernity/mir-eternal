using System;

namespace GameServer.Networking
{
	// Token: 0x02000213 RID: 531
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 609, 长度 = 7, 注释 = "删除外交公告")]
	public sealed class 删除外交公告 : GamePacket
	{
		// Token: 0x060002FC RID: 764 RVA: 0x0000344A File Offset: 0x0000164A
		public 删除外交公告()
		{
			
			
		}

		// Token: 0x0400077B RID: 1915
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 外交类型;

		// Token: 0x0400077C RID: 1916
		[WrappingFieldAttribute(下标 = 3, 长度 = 4)]
		public int 行会编号;
	}
}
