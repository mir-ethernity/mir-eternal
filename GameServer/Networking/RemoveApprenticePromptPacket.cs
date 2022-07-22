using System;

namespace GameServer.Networking
{
	// Token: 0x020001EE RID: 494
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 568, 长度 = 6, 注释 = "RemoveApprenticePromptPacket")]
	public sealed class RemoveApprenticePromptPacket : GamePacket
	{
		// Token: 0x060002D7 RID: 727 RVA: 0x0000344A File Offset: 0x0000164A
		public RemoveApprenticePromptPacket()
		{
			
			
		}

		// Token: 0x04000744 RID: 1860
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
