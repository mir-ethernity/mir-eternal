using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 153, Length = 0, Description = "同步道具列表")]
	public sealed class 同步道具列表 : GamePacket
	{
		
		public 同步道具列表()
		{
			
			
		}
	}
}
