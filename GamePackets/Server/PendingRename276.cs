using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 621, Length = 0, Description = "更多资金信息")]
	public sealed class 更多资金信息 : GamePacket
	{
		
		public 更多资金信息()
		{
			
			
		}
	}
}
