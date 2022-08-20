using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 67, Length = 93, Description = "SyncPlayerData")]
	public sealed class SyncPlayerData : GamePacket
	{
		
		public SyncPlayerData()
		{
			
			
		}
	}
}
