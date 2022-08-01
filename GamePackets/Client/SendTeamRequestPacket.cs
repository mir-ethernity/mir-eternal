using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 516, 长度 = 6, 注释 = "SendTeamRequestPacket")]
	public sealed class SendTeamRequestPacket : GamePacket
	{
		
		public SendTeamRequestPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
