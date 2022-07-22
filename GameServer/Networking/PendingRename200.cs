using System;

namespace GameServer.Networking
{
	// Token: 0x0200009E RID: 158
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 111, 长度 = 6, 注释 = "打开角色摊位")]
	public sealed class 打开角色摊位 : GamePacket
	{
		// Token: 0x06000185 RID: 389 RVA: 0x0000344A File Offset: 0x0000164A
		public 打开角色摊位()
		{
			
			
		}

		// Token: 0x040004EE RID: 1262
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
