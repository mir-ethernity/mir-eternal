using System;

namespace GameServer.Networking
{
	// Token: 0x020001C2 RID: 450
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 514, 长度 = 14, 注释 = "聊天服务器错误提示")]
	public sealed class 社交错误提示 : GamePacket
	{
		// Token: 0x060002AB RID: 683 RVA: 0x0000344A File Offset: 0x0000164A
		public 社交错误提示()
		{
			
			
		}

		// Token: 0x040006F4 RID: 1780
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 错误编号;

		// Token: 0x040006F5 RID: 1781
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 参数一;

		// Token: 0x040006F6 RID: 1782
		[WrappingFieldAttribute(下标 = 10, 长度 = 4)]
		public int 参数二;
	}
}
