using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 614, Length = 3, Description = "LoginConsignmentPlatformPacket")]
	public sealed class LoginConsignmentPlatformPacket : GamePacket
	{
		
		public LoginConsignmentPlatformPacket()
		{
			
			
		}
	}
}
