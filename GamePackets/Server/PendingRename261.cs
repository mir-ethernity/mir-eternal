using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 623, Length = 7, Description = "提升行会福利")]
	public sealed class 提升行会福利 : GamePacket
	{
		
		public 提升行会福利()
		{
			
			
		}
	}
}
