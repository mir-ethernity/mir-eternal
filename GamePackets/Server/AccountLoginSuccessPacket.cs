using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 1002, 长度 = 0, 注释 = "AccountLoginSuccessPacket")]
	public sealed class AccountLoginSuccessPacket : GamePacket
	{
		
		public override bool 是否加密 { get; set; }

		
		public AccountLoginSuccessPacket()
		{
			this.是否加密 = false;

		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 协议数据;
	}
}
