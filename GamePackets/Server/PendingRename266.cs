using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 1009, Length = 2, Description = "更换角色")]
	public sealed class 更换角色应答 : GamePacket
	{
		
		public 更换角色应答()
		{
			
			
		}
	}
}
