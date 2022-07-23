using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 614, 长度 = 3, 注释 = "LoginConsignmentPlatformPacket")]
	public sealed class LoginConsignmentPlatformPacket : GamePacket
	{
		
		public LoginConsignmentPlatformPacket()
		{
			
			
		}
	}
}
