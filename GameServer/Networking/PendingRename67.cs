using System;

namespace GameServer.Networking
{
	// Token: 0x0200010E RID: 270
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 582, 长度 = 6, 注释 = "申请解除敌对")]
	public sealed class 申请解除敌对 : GamePacket
	{
		// Token: 0x060001F5 RID: 501 RVA: 0x0000344A File Offset: 0x0000164A
		public 申请解除敌对()
		{
			
			
		}

		// Token: 0x04000560 RID: 1376
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 行会编号;
	}
}
