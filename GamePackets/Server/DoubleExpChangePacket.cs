using System;

namespace GameServer.Networking
{
	
	[PacketInfo(Source = PacketSource.Server, Id = 76, Length = 6, Description = "DoubleExpChangePacket")]
	public sealed class DoubleExpChangePacket : GamePacket
	{
		[WrappingField(SubScript = 2, Length = 4)]
		public int DoubleExp;
	}
}
