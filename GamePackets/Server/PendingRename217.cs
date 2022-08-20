using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 636, Length = 8, Description = "帮会成就回应")]
	public sealed class 帮会成就回应 : GamePacket
	{
		
		public 帮会成就回应()
		{
			
			
		}
	}
}
