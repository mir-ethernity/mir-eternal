using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 1001, 长度 = 162, 注释 = "客户登录")]
	public sealed class 客户账号登录 : GamePacket
	{
		
		public override bool 是否加密 { get; set; }

		
		public 客户账号登录()
		{
			this.是否加密 = false;
			
		}

		
		[WrappingFieldAttribute(SubScript = 72, Length = 38)]
		public string 登录门票;

		
		[WrappingFieldAttribute(SubScript = 136, Length = 17)]
		public string MacAddress;
	}
}
