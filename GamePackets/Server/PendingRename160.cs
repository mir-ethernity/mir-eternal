using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 70, Length = 11, Description = "同步道具次数")]
	public sealed class 同步道具次数 : GamePacket
	{
		[WrappingField(SubScript = 2, Length = 4)]
		public int ObjectId;
		[WrappingField(SubScript = 6, Length = 4)]
		public int PlayerId;
		[WrappingField(SubScript = 10, Length = 1)]
		public byte Unknown;
	}
}
