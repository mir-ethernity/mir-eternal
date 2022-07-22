using System;

namespace GameServer.Networking
{
	// Token: 0x02000153 RID: 339
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 80, 长度 = 10, 注释 = "同步PK惩罚值")]
	public sealed class 同步对象惩罚 : GamePacket
	{
		// Token: 0x0600023C RID: 572 RVA: 0x0000344A File Offset: 0x0000164A
		public 同步对象惩罚()
		{
			
			
		}

		// Token: 0x04000601 RID: 1537
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		// Token: 0x04000602 RID: 1538
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int PK值惩罚;
	}
}
