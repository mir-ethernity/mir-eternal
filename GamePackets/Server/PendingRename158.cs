using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 1012, Length = 3, Description = "返回服务器信息")]
	public sealed class 同步服务状态 : GamePacket
	{
		
		public 同步服务状态()
		{
			
			
		}
	}
}
