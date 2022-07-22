using System;

namespace GameServer.Networking
{
	// Token: 0x020001C7 RID: 455
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 520, 长度 = 40, 注释 = "SendTeamRequestBPacket")]
	public sealed class SendTeamRequestBPacket : GamePacket
	{
		// Token: 0x060002B0 RID: 688 RVA: 0x0000344A File Offset: 0x0000164A
		public SendTeamRequestBPacket()
		{
			
			
		}

		// Token: 0x04000701 RID: 1793
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		// Token: 0x04000702 RID: 1794
		[WrappingFieldAttribute(下标 = 6, 长度 = 1)]
		public byte 组队方式;

		// Token: 0x04000703 RID: 1795
		[WrappingFieldAttribute(下标 = 7, 长度 = 1)]
		public byte 对象职业;

		// Token: 0x04000704 RID: 1796
		[WrappingFieldAttribute(下标 = 8, 长度 = 32)]
		public string 对象名字;
	}
}
