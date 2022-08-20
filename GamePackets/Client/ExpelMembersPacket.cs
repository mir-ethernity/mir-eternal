using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 566, Length = 6, Description = "ExpelMembersPacket")]
	public sealed class ExpelMembersPacket : GamePacket
	{
		
		public ExpelMembersPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
