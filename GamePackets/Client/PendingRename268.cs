using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 1008, Length = 38, Description = "更改CharName")]
	public sealed class 更改CharName : GamePacket
	{
		
		public 更改CharName()
		{
			
			
		}
	}
}
