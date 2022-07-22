using System;

namespace GameServer.Networking
{
	// Token: 0x020001CB RID: 459
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 526, 长度 = 43, 注释 = "查询对象队伍信息回应")]
	public sealed class 查询队伍应答 : GamePacket
	{
		// Token: 0x060002B4 RID: 692 RVA: 0x0000344A File Offset: 0x0000164A
		public 查询队伍应答()
		{
			
			
		}

		// Token: 0x04000719 RID: 1817
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 队伍编号;

		// Token: 0x0400071A RID: 1818
		[WrappingFieldAttribute(下标 = 6, 长度 = 32)]
		public string 队伍名字;

		// Token: 0x0400071B RID: 1819
		[WrappingFieldAttribute(下标 = 39, 长度 = 4)]
		public int 队长编号;
	}
}
