using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 70, Length = 11, Description = "同步道具次数")]
	public sealed class 同步道具次数 : GamePacket
	{
		
		public 同步道具次数()
		{
			
			
		}
	}
}
