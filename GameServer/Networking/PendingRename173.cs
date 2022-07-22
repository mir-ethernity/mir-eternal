using System;

namespace GameServer.Networking
{
	// Token: 0x02000157 RID: 343
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 85, 长度 = 8, 注释 = "泡泡提示")]
	public sealed class 同步气泡提示 : GamePacket
	{
		// Token: 0x06000240 RID: 576 RVA: 0x0000344A File Offset: 0x0000164A
		public 同步气泡提示()
		{
			
			
		}

		// Token: 0x0400060B RID: 1547
		[WrappingFieldAttribute(下标 = 2, 长度 = 2)]
		public ushort 泡泡类型;

		// Token: 0x0400060C RID: 1548
		[WrappingFieldAttribute(下标 = 4, 长度 = 4)]
		public int 泡泡参数;
	}
}
