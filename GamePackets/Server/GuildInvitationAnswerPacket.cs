using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 595, Length = 35, Description = "GuildInvitationAnswerPacket")]
	public sealed class GuildInvitationAnswerPacket : GamePacket
	{
		
		public GuildInvitationAnswerPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 应答类型;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 32)]
		public string 对象名字;
	}
}
