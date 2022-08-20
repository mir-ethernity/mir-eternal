using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 45, Length = 6, Description = "同步游戏ping", NoDebug = true)]
	public sealed class InternetSpeedTestPacket : GamePacket
	{
		
		public InternetSpeedTestPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 当前时间;
	}
}
