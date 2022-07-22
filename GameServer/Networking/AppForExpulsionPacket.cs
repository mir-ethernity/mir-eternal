using System;

namespace GameServer.Networking
{
	// Token: 0x020000EB RID: 235
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 543, 长度 = 6, 注释 = "AppForExpulsionPacket")]
	public sealed class AppForExpulsionPacket : GamePacket
	{
		// Token: 0x060001D2 RID: 466 RVA: 0x0000344A File Offset: 0x0000164A
		public AppForExpulsionPacket()
		{
			
			
		}

		// Token: 0x04000536 RID: 1334
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
