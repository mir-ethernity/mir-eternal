using System;

namespace GameServer.Networking
{
	// Token: 0x02000127 RID: 295
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 9, 长度 = 14, 注释 = "服务端提示")]
	public sealed class GameErrorMessagePacket : GamePacket
	{
		// Token: 0x06000210 RID: 528 RVA: 0x0000344A File Offset: 0x0000164A
		public GameErrorMessagePacket()
		{
			
			
		}

		// Token: 0x0400057B RID: 1403
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 错误代码;

		// Token: 0x0400057C RID: 1404
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 第一参数;

		// Token: 0x0400057D RID: 1405
		[WrappingFieldAttribute(下标 = 10, 长度 = 4)]
		public int 第二参数;
	}
}
