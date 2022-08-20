using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 554, Length = 2, Description = "更多行会信息")]
	public sealed class 更多行会信息 : GamePacket
	{
		
		public 更多行会信息()
		{
			
			
		}
	}
}
