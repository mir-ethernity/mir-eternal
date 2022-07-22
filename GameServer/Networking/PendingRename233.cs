using System;

namespace GameServer.Networking
{
	// Token: 0x02000209 RID: 521
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 599, 长度 = 7, 注释 = "变更职位公告")]
	public sealed class 变更职位公告 : GamePacket
	{
		// Token: 0x060002F2 RID: 754 RVA: 0x0000344A File Offset: 0x0000164A
		public 变更职位公告()
		{
			
			
		}

		// Token: 0x0400076A RID: 1898
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		// Token: 0x0400076B RID: 1899
		[WrappingFieldAttribute(下标 = 6, 长度 = 1)]
		public byte 对象职位;
	}
}
