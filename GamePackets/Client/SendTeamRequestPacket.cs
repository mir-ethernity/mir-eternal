using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 516, Length = 6, Description = "SendTeamRequestPacket")]
	public sealed class SendTeamRequestPacket : GamePacket
	{
		
		public SendTeamRequestPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
