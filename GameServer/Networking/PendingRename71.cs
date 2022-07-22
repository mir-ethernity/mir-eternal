using System;

namespace GameServer.Networking
{
	// Token: 0x020000D8 RID: 216
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 521, 长度 = 7, 注释 = "申请创建队伍")]
	public sealed class 申请创建队伍 : GamePacket
	{
		// Token: 0x060001BF RID: 447 RVA: 0x0000344A File Offset: 0x0000164A
		public 申请创建队伍()
		{
			
			
		}

		// Token: 0x04000527 RID: 1319
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		// Token: 0x04000528 RID: 1320
		[WrappingFieldAttribute(下标 = 6, 长度 = 1)]
		public byte 分配方式;
	}
}
