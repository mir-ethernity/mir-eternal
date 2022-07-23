using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 516, 长度 = 6, 注释 = "SendTeamRequestPacket")]
	public sealed class SendTeamRequestPacket : GamePacket
	{
		
		public SendTeamRequestPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
