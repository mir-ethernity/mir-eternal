using System;

namespace GameServer.Networking
{
	// Token: 0x020000A8 RID: 168
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 137, 长度 = 0, 注释 = "上传游戏设置")]
	public sealed class 上传游戏设置 : GamePacket
	{
		// Token: 0x0600018F RID: 399 RVA: 0x0000344A File Offset: 0x0000164A
		public 上传游戏设置()
		{
			
			
		}

		// Token: 0x040004F9 RID: 1273
		[WrappingFieldAttribute(下标 = 2, 长度 = 0)]
		public byte[] 字节描述;
	}
}
