using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 530, Length = 0, Description = "SyncFriendsListPacket")]
	public sealed class SyncFriendsListPacket : GamePacket
	{
		
		public SyncFriendsListPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 0)]
		public byte[] 字节描述;
	}
}
