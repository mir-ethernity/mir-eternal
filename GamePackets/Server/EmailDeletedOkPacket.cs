using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 576, Length = 14, Description = "EmailDeletedOkPacket")]
	public sealed class EmailDeletedOkPacket : GamePacket
	{
		
		public EmailDeletedOkPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int 邮件编号;
	}
}
