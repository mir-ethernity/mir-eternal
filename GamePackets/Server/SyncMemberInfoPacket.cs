using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 646, Length = 11, Description = "SyncMemberInfoPacket")]
	public sealed class SyncMemberInfoPacket : GamePacket
	{
		
		public SyncMemberInfoPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int 对象信息;

		
		[WrappingFieldAttribute(SubScript = 10, Length = 1)]
		public byte CurrentRank;
	}
}
