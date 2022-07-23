using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 544, 长度 = 7, 注释 = "SendApprenticePushPacket")]
	public sealed class SendApprenticePushPacket : GamePacket
	{
		
		public SendApprenticePushPacket()
		{
			
			
		}
	}
}
