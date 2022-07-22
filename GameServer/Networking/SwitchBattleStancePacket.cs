using System;

namespace GameServer.Networking
{
	// Token: 0x02000167 RID: 359
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 105, 长度 = 8, 注释 = "SwitchBattleStancePacket")]
	public sealed class SwitchBattleStancePacket : GamePacket
	{
		// Token: 0x06000250 RID: 592 RVA: 0x0000344A File Offset: 0x0000164A
		public SwitchBattleStancePacket()
		{
			
			
		}

		// Token: 0x04000646 RID: 1606
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 角色编号;

		// Token: 0x04000647 RID: 1607
		[WrappingFieldAttribute(下标 = 6, 长度 = 1)]
		public bool 切回正常姿态;

		// Token: 0x04000648 RID: 1608
		[WrappingFieldAttribute(下标 = 7, 长度 = 1)]
		public bool 系统自动切换;
	}
}
