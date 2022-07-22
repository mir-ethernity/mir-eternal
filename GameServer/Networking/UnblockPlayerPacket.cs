using System;

namespace GameServer.Networking
{
	// Token: 0x020001A3 RID: 419
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 251, 长度 = 6, 注释 = "UnblockPlayerPacket")]
	public sealed class UnblockPlayerPacket : GamePacket
	{
		// Token: 0x0600028C RID: 652 RVA: 0x0000344A File Offset: 0x0000164A
		public UnblockPlayerPacket()
		{
			
			
		}

		// Token: 0x040006CC RID: 1740
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
