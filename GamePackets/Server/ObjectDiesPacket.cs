using System;

namespace GameServer.Networking
{
	
	[PacketInfo(Source = PacketSource.Server, Id = 55, Length = 7, Description = "对象死亡", Broadcast = true)]
	public sealed class ObjectDiesPacket : GamePacket
	{
		[WrappingField(SubScript = 2, Length = 4)]
		public int ObjectId;
	}
}
