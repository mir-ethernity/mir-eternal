using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 616, Length = 6, Description = "InquireAboutSpecifiedProductPacket")]
	public sealed class InquireAboutSpecifiedProductPacket : GamePacket
	{
		
		public InquireAboutSpecifiedProductPacket()
		{
			
			
		}
	}
}
