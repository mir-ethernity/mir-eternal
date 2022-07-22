using System;

namespace GameServer.Networking
{
	// Token: 0x020001EB RID: 491
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 565, 长度 = 6, 注释 = "ExpulsionDoorAnswerPacket")]
	public sealed class ExpulsionDoorAnswerPacket : GamePacket
	{
		// Token: 0x060002D4 RID: 724 RVA: 0x0000344A File Offset: 0x0000164A
		public ExpulsionDoorAnswerPacket()
		{
			
			
		}

		// Token: 0x04000741 RID: 1857
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
