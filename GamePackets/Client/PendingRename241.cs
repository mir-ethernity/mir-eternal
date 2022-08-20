using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 624, Length = 6, Description = "查看演武排名")]
	public sealed class 查看演武排名 : GamePacket
	{
		
		public 查看演武排名()
		{
			
			
		}
	}
}
