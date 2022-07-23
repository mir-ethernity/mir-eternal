using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 595, 长度 = 35, 注释 = "GuildInvitationAnswerPacket")]
	public sealed class GuildInvitationAnswerPacket : GamePacket
	{
		
		public GuildInvitationAnswerPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 应答类型;

		
		[WrappingFieldAttribute(下标 = 3, 长度 = 32)]
		public string 对象名字;
	}
}
