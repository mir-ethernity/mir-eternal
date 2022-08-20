using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 1001, Length = 162, Description = "客户登录")]
	public sealed class AcountLoginPacket : GamePacket
	{
		[WrappingFieldAttribute(SubScript = 72, Length = 38)]
		public string Ticket;

		[WrappingFieldAttribute(SubScript = 136, Length = 17)]
		public string MacAddress;

		public AcountLoginPacket()
		{
			Encrypted = false;
		}
	}
}
