using System;

namespace GameServer.Networking
{
	// Token: 0x020000F5 RID: 245
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 553, 长度 = 7, 注释 = "查看行会列表")]
	public sealed class 查看行会列表 : GamePacket
	{
		// Token: 0x060001DC RID: 476 RVA: 0x0000344A File Offset: 0x0000164A
		public 查看行会列表()
		{
			
			
		}

		// Token: 0x0400053E RID: 1342
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 查看方式;

		// Token: 0x0400053F RID: 1343
		[WrappingFieldAttribute(下标 = 3, 长度 = 4)]
		public int 行会编号;
	}
}
