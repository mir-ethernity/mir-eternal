using System;

namespace GameServer.Networking
{
	// Token: 0x02000236 RID: 566
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 662, 长度 = 10, 注释 = "同步占领行会")]
	public sealed class 同步占领行会 : GamePacket
	{
		// Token: 0x0600031F RID: 799 RVA: 0x0000344A File Offset: 0x0000164A
		public 同步占领行会()
		{
			
			
		}

		// Token: 0x04000795 RID: 1941
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 行会编号;
	}
}
