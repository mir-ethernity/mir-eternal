using System;

namespace GameServer.Networking
{
	// Token: 0x02000196 RID: 406
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 167, 长度 = 0, 注释 = "Npcc交互结果")]
	public sealed class 同步交互结果 : GamePacket
	{
		// Token: 0x0600027F RID: 639 RVA: 0x0000344A File Offset: 0x0000164A
		public 同步交互结果()
		{
			
			
		}

		// Token: 0x040006B4 RID: 1716
		[WrappingFieldAttribute(下标 = 4, 长度 = 4)]
		public int 对象编号;

		// Token: 0x040006B5 RID: 1717
		[WrappingFieldAttribute(下标 = 8, 长度 = 0)]
		public byte[] 交互文本;
	}
}
