using System;

namespace GameServer.Networking
{
	// Token: 0x0200010F RID: 271
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 583, 长度 = 7, 注释 = "处理解敌申请")]
	public sealed class 处理解敌申请 : GamePacket
	{
		// Token: 0x060001F6 RID: 502 RVA: 0x0000344A File Offset: 0x0000164A
		public 处理解敌申请()
		{
			
			
		}

		// Token: 0x04000561 RID: 1377
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 回应类型;

		// Token: 0x04000562 RID: 1378
		[WrappingFieldAttribute(下标 = 3, 长度 = 4)]
		public int 行会编号;
	}
}
