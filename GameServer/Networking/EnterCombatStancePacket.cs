using System;

namespace GameServer.Networking
{
	// Token: 0x0200016B RID: 363
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 111, 长度 = 6, 注释 = "EnterCombatStancePacket")]
	public sealed class EnterCombatStancePacket : GamePacket
	{
		// Token: 0x06000254 RID: 596 RVA: 0x0000344A File Offset: 0x0000164A
		public EnterCombatStancePacket()
		{
			
			
		}

		// Token: 0x0400064E RID: 1614
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
