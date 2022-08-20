using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 670, Length = 134, Description = "计费系统错误")]
	public sealed class 计费系统错误 : GamePacket
	{
		
		public 计费系统错误()
		{
			
			
		}
	}
}
