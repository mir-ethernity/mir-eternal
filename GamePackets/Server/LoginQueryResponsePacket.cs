using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 1010, Length = 6, Description = "Synchronous gateway ping", NoDebug = true)]
	public sealed class LoginQueryResponsePacket : GamePacket
	{
		
		public LoginQueryResponsePacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 当前时间;
	}
}
