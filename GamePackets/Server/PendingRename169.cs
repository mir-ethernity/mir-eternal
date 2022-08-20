using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 527, Length = 0, Description = "同步队伍变量")]
	public sealed class 同步队伍变量 : GamePacket
	{
		
		public 同步队伍变量()
		{
			
			
		}
	}
}
