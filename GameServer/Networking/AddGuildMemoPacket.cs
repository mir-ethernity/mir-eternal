using System;

namespace GameServer.Networking
{
	// Token: 0x0200021B RID: 539
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 617, 长度 = 23, 注释 = "AddGuildMemoPacket")]
	public sealed class AddGuildMemoPacket : GamePacket
	{
		// Token: 0x06000304 RID: 772 RVA: 0x0000344A File Offset: 0x0000164A
		public AddGuildMemoPacket()
		{
			
			
		}

		// Token: 0x0400077E RID: 1918
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte MemorandumType;

		// Token: 0x0400077F RID: 1919
		[WrappingFieldAttribute(下标 = 3, 长度 = 4)]
		public int 第一参数;

		// Token: 0x04000780 RID: 1920
		[WrappingFieldAttribute(下标 = 7, 长度 = 4)]
		public int 第二参数;

		// Token: 0x04000781 RID: 1921
		[WrappingFieldAttribute(下标 = 11, 长度 = 4)]
		public int 第三参数;

		// Token: 0x04000782 RID: 1922
		[WrappingFieldAttribute(下标 = 15, 长度 = 4)]
		public int 第四参数;

		// Token: 0x04000783 RID: 1923
		[WrappingFieldAttribute(下标 = 19, 长度 = 4)]
		public int 事记时间;
	}
}
