using System;

namespace GameServer.Networking
{
	// Token: 0x020000D7 RID: 215
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 520, 长度 = 6, 注释 = "查询队伍信息")]
	public sealed class 查询队伍信息 : GamePacket
	{
		// Token: 0x060001BE RID: 446 RVA: 0x0000344A File Offset: 0x0000164A
		public 查询队伍信息()
		{
			
			
		}

		// Token: 0x04000526 RID: 1318
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
