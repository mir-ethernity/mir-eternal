using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 1002, Length = 0, Description = "AccountLoginSuccessPacket")]
	public sealed class AccountLoginSuccessPacket : GamePacket
	{
		
		public override bool Encrypted { get; set; }

		
		public AccountLoginSuccessPacket()
		{
			this.Encrypted = false;

		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 协议数据;
	}
}
