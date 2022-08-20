using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 628, Length = 10, Description = "跨服武道排名")]
	public sealed class 跨服武道排名 : GamePacket
	{
		
		public 跨服武道排名()
		{
			
			
		}
	}
}
