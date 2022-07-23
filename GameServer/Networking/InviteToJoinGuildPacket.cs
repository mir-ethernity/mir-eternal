using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 559, 长度 = 34, 注释 = "InviteToJoinGuildPacket")]
	public sealed class InviteToJoinGuildPacket : GamePacket
	{
		
		public InviteToJoinGuildPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 32)]
		public string 对象名字;
	}
}
