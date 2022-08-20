using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 611, Length = 5, Description = "更改存取权限")]
	public sealed class 更改存取权限 : GamePacket
	{
		
		public 更改存取权限()
		{
			
			
		}
	}
}
