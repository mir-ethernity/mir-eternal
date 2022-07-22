using System;

namespace GameServer.Networking
{
	// Token: 0x02000091 RID: 145
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 79, 长度 = 14, 注释 = "升级武器普通")]
	public sealed class 升级武器普通 : GamePacket
	{
		// Token: 0x06000178 RID: 376 RVA: 0x0000344A File Offset: 0x0000164A
		public 升级武器普通()
		{
			
			
		}

		// Token: 0x040004DD RID: 1245
		[WrappingFieldAttribute(下标 = 2, 长度 = 6)]
		public byte[] 首饰组;

		// Token: 0x040004DE RID: 1246
		[WrappingFieldAttribute(下标 = 8, 长度 = 6)]
		public byte[] 材料组;
	}
}
