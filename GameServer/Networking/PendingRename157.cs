using System;

namespace GameServer.Networking
{
	// Token: 0x02000210 RID: 528
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 606, 长度 = 0, 注释 = "查看结盟申请")]
	public sealed class 同步结盟申请 : GamePacket
	{
		// Token: 0x060002F9 RID: 761 RVA: 0x0000344A File Offset: 0x0000164A
		public 同步结盟申请()
		{
			
			
		}

		// Token: 0x04000773 RID: 1907
		[WrappingFieldAttribute(下标 = 4, 长度 = 0)]
		public byte[] 字节描述;
	}
}
