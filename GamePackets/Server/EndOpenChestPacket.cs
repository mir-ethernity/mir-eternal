using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 155, Length = 11, Description = "EndOpenChestPacket")]
	public sealed class EndOpenChestPacket : GamePacket
	{
		[WrappingField(SubScript = 2, Length = 4)]
		public int PlayerId;
		[WrappingField(SubScript = 6, Length = 4)]
		public int ObjectId;
		[WrappingField(SubScript = 10, Length = 1)]
		public bool Unknown;
	}
}
