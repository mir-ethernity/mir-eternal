using System;

namespace GameServer.Networking
{
	// Token: 0x020000A3 RID: 163
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 117, 长度 = 6, 注释 = "点击Npc开始与之对话")]
	public sealed class 开始Npcc对话 : GamePacket
	{
		// Token: 0x0600018A RID: 394 RVA: 0x0000344A File Offset: 0x0000164A
		public 开始Npcc对话()
		{
			
			
		}

		// Token: 0x040004F5 RID: 1269
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
