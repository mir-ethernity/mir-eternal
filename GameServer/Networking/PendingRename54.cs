using System;

namespace GameServer.Networking
{
	// Token: 0x02000183 RID: 387
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 141, 长度 = 4, 注释 = "武器幸运变化")]
	public sealed class 武器幸运变化 : GamePacket
	{
		// Token: 0x0600026C RID: 620 RVA: 0x0000344A File Offset: 0x0000164A
		public 武器幸运变化()
		{
			
			
		}

		// Token: 0x04000692 RID: 1682
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public sbyte 幸运变化;
	}
}
