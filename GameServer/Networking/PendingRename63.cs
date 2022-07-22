using System;

namespace GameServer.Networking
{
	// Token: 0x020001E5 RID: 485
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 557, 长度 = 12, 注释 = "申请收徒提示")]
	public sealed class 申请收徒提示 : GamePacket
	{
		// Token: 0x060002CE RID: 718 RVA: 0x0000344A File Offset: 0x0000164A
		public 申请收徒提示()
		{
			
			
		}

		// Token: 0x04000739 RID: 1849
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 面板类型;

		// Token: 0x0400073A RID: 1850
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public byte 对象等级;

		// Token: 0x0400073B RID: 1851
		[WrappingFieldAttribute(下标 = 4, 长度 = 4)]
		public int 对象编号;

		// Token: 0x0400073C RID: 1852
		[WrappingFieldAttribute(下标 = 8, 长度 = 4)]
		public int 对象声望;
	}
}
