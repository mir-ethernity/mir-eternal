using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 1001, 长度 = 162, 注释 = "客户登录")]
	public sealed class 客户账号登录 : GamePacket
	{
		
		// (get) Token: 0x06000205 RID: 517 RVA: 0x00003457 File Offset: 0x00001657
		// (set) Token: 0x06000206 RID: 518 RVA: 0x0000345F File Offset: 0x0000165F
		public override bool 是否加密 { get; set; }

		
		public 客户账号登录()
		{
			this.是否加密 = false;
			
		}

		
		[WrappingFieldAttribute(SubScript = 72, Length = 38)]
		public string 登录门票;

		
		[WrappingFieldAttribute(SubScript = 136, Length = 17)]
		public string 物理地址;
	}
}
