using System;

namespace GameServer.Networking
{
	// Token: 0x02000241 RID: 577
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 1002, 长度 = 0, 注释 = "客户端登录成功,同步协议")]
	public sealed class AccountLoginSuccessPacket : GamePacket
	{
		// Token: 0x17000033 RID: 51
		// (get) Token: 0x0600032A RID: 810 RVA: 0x00003569 File Offset: 0x00001769
		// (set) Token: 0x0600032B RID: 811 RVA: 0x00003571 File Offset: 0x00001771
		public override bool 是否加密 { get; set; }

		// Token: 0x0600032C RID: 812 RVA: 0x0000344A File Offset: 0x0000164A
		public AccountLoginSuccessPacket()
		{
			this.是否加密 = false;

		}

		// Token: 0x0400079B RID: 1947
		[WrappingFieldAttribute(下标 = 4, 长度 = 0)]
		public byte[] 协议数据;
	}
}
