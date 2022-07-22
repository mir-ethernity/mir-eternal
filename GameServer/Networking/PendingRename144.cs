using System;

namespace GameServer.Networking
{
	// Token: 0x02000145 RID: 325
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 65, 长度 = 16, 注释 = "同步Npcc数据")]
	public sealed class 同步Npcc数据 : GamePacket
	{
		// Token: 0x0600022E RID: 558 RVA: 0x000034CD File Offset: 0x000016CD
		public 同步Npcc数据()
		{
			
			this.对象质量 = 3;
			
		}

		// Token: 0x040005DE RID: 1502
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		// Token: 0x040005DF RID: 1503
		[WrappingFieldAttribute(下标 = 6, 长度 = 2)]
		public ushort 对象模板;

		// Token: 0x040005E0 RID: 1504
		[WrappingFieldAttribute(下标 = 10, 长度 = 1)]
		public byte 对象质量;

		// Token: 0x040005E1 RID: 1505
		[WrappingFieldAttribute(下标 = 11, 长度 = 1)]
		public byte 对象等级;

		// Token: 0x040005E2 RID: 1506
		[WrappingFieldAttribute(下标 = 12, 长度 = 4)]
		public int 体力上限;
	}
}
