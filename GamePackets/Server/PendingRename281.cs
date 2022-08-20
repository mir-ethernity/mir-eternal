using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 624, Length = 4, Description = "更新行会福利")]
	public sealed class 更新行会福利 : GamePacket
	{
		
		public 更新行会福利()
		{
			
			
		}
	}
}
