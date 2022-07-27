using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 595, 长度 = 35, 注释 = "GuildInvitationAnswerPacket")]
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
