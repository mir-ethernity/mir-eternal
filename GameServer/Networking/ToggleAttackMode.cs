using System;

namespace GameServer.Networking
{
	// Token: 0x02000074 RID: 116
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 38, 长度 = 3, 注释 = "ToggleAttackMode")]
	public sealed class ToggleAttackMode : GamePacket
	{
		// Token: 0x0600015B RID: 347 RVA: 0x0000344A File Offset: 0x0000164A
		public ToggleAttackMode()
		{
			
			
		}

		// Token: 0x04000498 RID: 1176
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte AttackMode;
	}
}
