using System;

namespace GameServer.Networking
{
	
	[PacketInfo(Source = PacketSource.Server, Id = 135, Length = 0, Description = "拾取物品")]
	public sealed class PlayersPickupItemPacket : GamePacket
	{
		[WrappingFieldAttribute(SubScript = 4, Length = 4)]
		public int ObjectId;

		[WrappingField(SubScript = 8, Length = 0)]
		public byte[] ItemData = Array.Empty<byte>();
	}
}
