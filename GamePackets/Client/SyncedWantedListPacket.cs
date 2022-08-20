using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 212, Length = 2, Description = "SyncedWantedListPacket")]
	public sealed class SyncedWantedListPacket : GamePacket
	{
		
		public SyncedWantedListPacket()
		{
			
			
		}
	}
}
