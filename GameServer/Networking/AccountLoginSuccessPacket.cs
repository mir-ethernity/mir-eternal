using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 1002, 长度 = 0, 注释 = "客户端登录成功,同步协议")]
	public sealed class AccountLoginSuccessPacket : GamePacket
	{
		
		// (get) Token: 0x0600032A RID: 810 RVA: 0x00003569 File Offset: 0x00001769
		// (set) Token: 0x0600032B RID: 811 RVA: 0x00003571 File Offset: 0x00001771
		public override bool 是否加密 { get; set; }

		
		public AccountLoginSuccessPacket()
		{
			this.是否加密 = false;

		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 协议数据;
	}
}
