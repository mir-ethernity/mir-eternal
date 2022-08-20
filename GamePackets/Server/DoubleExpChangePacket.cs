using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 76, Length = 6, Description = "DoubleExpChangePacket")]
	public sealed class DoubleExpChangePacket : GamePacket
	{
		
		public DoubleExpChangePacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int DoubleExp;
	}
}
