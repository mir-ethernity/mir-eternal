using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 185, Length = 0, Description = "同步角色变量")]
	public sealed class 同步角色变量 : GamePacket
	{
		
		public 同步角色变量()
		{
			
			
		}
	}
}
