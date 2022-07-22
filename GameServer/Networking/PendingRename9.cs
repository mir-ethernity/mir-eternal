using System;

namespace GameServer.Networking
{
	// Token: 0x0200011E RID: 286
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 1001, 长度 = 162, 注释 = "客户登录")]
	public sealed class 客户账号登录 : GamePacket
	{
		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000205 RID: 517 RVA: 0x00003457 File Offset: 0x00001657
		// (set) Token: 0x06000206 RID: 518 RVA: 0x0000345F File Offset: 0x0000165F
		public override bool 是否加密 { get; set; }

		// Token: 0x06000207 RID: 519 RVA: 0x0000344A File Offset: 0x0000164A
		public 客户账号登录()
		{
			this.是否加密 = false;
			
		}

		// Token: 0x0400056E RID: 1390
		[WrappingFieldAttribute(下标 = 72, 长度 = 38)]
		public string 登录门票;

		// Token: 0x0400056F RID: 1391
		[WrappingFieldAttribute(下标 = 136, 长度 = 17)]
		public string 物理地址;
	}
}
