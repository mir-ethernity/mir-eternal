using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 559, Length = 34, Description = "InviteToJoinGuildPacket")]
	public sealed class InviteToJoinGuildPacket : GamePacket
	{
		
		public InviteToJoinGuildPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 32)]
		public string 对象名字;
	}
}
