using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 563, Length = 2, Description = "离开师门应答")]
	public sealed class 离开师门应答 : GamePacket
	{
		
		public 离开师门应答()
		{
			
			
		}
	}
}
