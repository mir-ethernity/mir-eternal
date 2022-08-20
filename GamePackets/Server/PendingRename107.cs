using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 214, Length = 4, Description = "玩家失去称号")]
	public sealed class 玩家失去称号 : GamePacket
	{
		
		public 玩家失去称号()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte Id;
	}
}
