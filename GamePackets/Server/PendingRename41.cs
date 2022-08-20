using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 160, Length = 7, Description = "升级摊位外观")]
	public sealed class 升级摊位外观 : GamePacket
	{
		
		public 升级摊位外观()
		{
			
			
		}
	}
}
