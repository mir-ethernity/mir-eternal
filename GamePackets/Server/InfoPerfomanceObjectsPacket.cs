using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 681, Length = 38, Description = "InfoPerfomanceObjectsPacket")]
	public sealed class InfoPerfomanceObjectsPacket : GamePacket
	{
		
		public InfoPerfomanceObjectsPacket()
		{
			
			
		}
	}
}
