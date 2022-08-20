using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 211, Length = 50, Description = "PublishWantedListPacket")]
	public sealed class PublishWantedListPacket : GamePacket
	{
		
		public PublishWantedListPacket()
		{
			
			
		}
	}
}
