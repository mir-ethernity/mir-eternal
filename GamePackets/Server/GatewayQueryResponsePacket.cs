using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 1, Length = 15, Description = "GatewayQueryResponsePacket")]
	public sealed class GatewayQueryResponsePacket : GamePacket
	{
		
		public GatewayQueryResponsePacket()
		{
			
			
		}
	}
}
