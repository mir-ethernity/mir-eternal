using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 134, Length = 3, Description = "ToggleMapRoutePacket")]
	public sealed class ToggleMapRoutePacket : GamePacket
	{
		
		public ToggleMapRoutePacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 地图路线;
	}
}
