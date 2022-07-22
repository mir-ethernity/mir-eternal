using System;

namespace GameServer.Networking
{
	// Token: 0x020001CE RID: 462
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 531, 长度 = 82, 注释 = "好友上下线")]
	public sealed class 好友上线下线 : GamePacket
	{
		// Token: 0x060002B7 RID: 695 RVA: 0x0000344A File Offset: 0x0000164A
		public 好友上线下线()
		{
			
			
		}

		// Token: 0x0400071D RID: 1821
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		// Token: 0x0400071E RID: 1822
		[WrappingFieldAttribute(下标 = 6, 长度 = 32)]
		public string 对象名字;

		// Token: 0x0400071F RID: 1823
		[WrappingFieldAttribute(下标 = 75, 长度 = 1)]
		public byte 对象职业;

		// Token: 0x04000720 RID: 1824
		[WrappingFieldAttribute(下标 = 76, 长度 = 1)]
		public byte 对象性别;

		// Token: 0x04000721 RID: 1825
		[WrappingFieldAttribute(下标 = 77, 长度 = 1)]
		public byte 上线下线;
	}
}
