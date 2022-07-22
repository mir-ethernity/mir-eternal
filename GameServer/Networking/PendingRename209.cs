using System;

namespace GameServer.Networking
{
	// Token: 0x020001FA RID: 506
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 583, 长度 = 27, 注释 = "创建行会应答")]
	public sealed class 创建行会应答 : GamePacket
	{
		// Token: 0x060002E3 RID: 739 RVA: 0x0000344A File Offset: 0x0000164A
		public 创建行会应答()
		{
			
			
		}

		// Token: 0x04000754 RID: 1876
		[WrappingFieldAttribute(下标 = 2, 长度 = 25)]
		public string 行会名字;
	}
}
