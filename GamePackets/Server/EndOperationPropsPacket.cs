using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 155, Length = 11, Description = "EndOperationPropsPacket")]
	public sealed class EndOperationPropsPacket : GamePacket
	{
		
		public EndOperationPropsPacket()
		{
			
			
		}
	}
}
