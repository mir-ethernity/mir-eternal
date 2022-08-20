using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 517, Length = 6, Description = "玩家离开队伍")]
	public sealed class 玩家离开队伍 : GamePacket
	{
		
		public 玩家离开队伍()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 队伍编号;
	}
}
