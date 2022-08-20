using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 656, Length = 6, Description = "同步Ingots")]
	public sealed class 同步Ingots : GamePacket
	{
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int Ingots;
	}
}
