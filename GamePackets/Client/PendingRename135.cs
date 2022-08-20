using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 145, Length = 3, Description = "玩家装配称号")]
	public sealed class 玩家装配称号 : GamePacket
	{
		
		public 玩家装配称号()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public byte Id;
	}
}
