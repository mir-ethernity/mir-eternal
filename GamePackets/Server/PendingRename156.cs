using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 26, Length = 6, Description = "同步角色行会")]
	public sealed class 同步角色行会 : GamePacket
	{
		
		public 同步角色行会()
		{
			
			
		}
	}
}
