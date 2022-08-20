using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 585, Length = 7, Description = "更多行会信息")]
	public sealed class 同步行会详情 : GamePacket
	{
		
		public 同步行会详情()
		{
			
			
		}
	}
}
