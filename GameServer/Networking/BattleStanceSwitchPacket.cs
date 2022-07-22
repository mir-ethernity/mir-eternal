using System;

namespace GameServer.Networking
{
	// Token: 0x02000076 RID: 118
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 40, 长度 = 4, 注释 = "BattleStanceSwitchPacket")]
	public sealed class BattleStanceSwitchPacket : GamePacket
	{
		// Token: 0x0600015D RID: 349 RVA: 0x0000344A File Offset: 0x0000164A
		public BattleStanceSwitchPacket()
		{
			
			
		}

		// Token: 0x0400049B RID: 1179
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public bool 切回正常姿态;

		// Token: 0x0400049C RID: 1180
		[WrappingFieldAttribute(下标 = 3, 长度 = 1)]
		public bool 系统自动切换;
	}
}
