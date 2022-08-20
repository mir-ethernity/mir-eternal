using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 266, Length = 2, Description = "铭文传承应答")]
	public sealed class 铭文传承应答 : GamePacket
	{
		
		public 铭文传承应答()
		{
			
			
		}
	}
}
