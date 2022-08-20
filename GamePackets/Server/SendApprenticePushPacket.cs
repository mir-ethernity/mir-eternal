using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 544, Length = 7, Description = "SendApprenticePushPacket")]
	public sealed class SendApprenticePushPacket : GamePacket
	{
		
		public SendApprenticePushPacket()
		{
			
			
		}
	}
}
