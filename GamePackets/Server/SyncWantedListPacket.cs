using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 312, Length = 0, Description = "SyncWantedListPacket")]
	public sealed class SyncWantedListPacket : GamePacket
	{
		
		public SyncWantedListPacket()
		{
			
			
		}
	}
}
