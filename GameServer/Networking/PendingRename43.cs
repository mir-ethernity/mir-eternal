using System;

namespace GameServer.Networking
{
	// Token: 0x020001AD RID: 429
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 265, 长度 = 3, 注释 = "确认替换铭文")]
	public sealed class 确认替换铭文 : GamePacket
	{
		// Token: 0x06000296 RID: 662 RVA: 0x0000344A File Offset: 0x0000164A
		public 确认替换铭文()
		{
			
			
		}

		// Token: 0x040006DE RID: 1758
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public bool 确定替换;
	}
}
