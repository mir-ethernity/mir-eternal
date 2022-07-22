using System;

namespace GameServer.Networking
{
	// Token: 0x02000108 RID: 264
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 572, 长度 = 5, 注释 = "更改存储权限")]
	public sealed class 更改存储权限 : GamePacket
	{
		// Token: 0x060001EF RID: 495 RVA: 0x0000344A File Offset: 0x0000164A
		public 更改存储权限()
		{
			
			
		}

		// Token: 0x04000557 RID: 1367
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte GuildJobs;

		// Token: 0x04000558 RID: 1368
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 原有位置;

		// Token: 0x04000559 RID: 1369
		[WrappingFieldAttribute(下标 = 4, 长度 = 1)]
		public byte 目标页面;
	}
}
