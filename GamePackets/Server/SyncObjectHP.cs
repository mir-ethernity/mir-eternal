using System;

namespace GameServer.Networking
{
	
	[PacketInfo(Source = PacketSource.Server, Id = 78, Length = 14, Description = "SyncObjectHP", Broadcast = true)]
	public sealed class SyncObjectHP : GamePacket
	{
		[WrappingField(SubScript = 2, Length = 4)]
		public int ObjectId;

		
		[WrappingField(SubScript = 6, Length = 4)]
		public int CurrentHP;

		
		[WrappingField(SubScript = 10, Length = 4)]
		public int MaxHP;
	}
}
