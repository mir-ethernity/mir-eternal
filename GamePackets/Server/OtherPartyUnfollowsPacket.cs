using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 535, Length = 38, Description = "OtherPartyUnfollowsPacket")]
	public sealed class OtherPartyUnfollowsPacket : GamePacket
	{
		
		public OtherPartyUnfollowsPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 32)]
		public string 对象名字;
	}
}
