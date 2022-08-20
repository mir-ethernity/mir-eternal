using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 156, Length = 6, Description = "玩家比较成就")]
	public sealed class 玩家比较成就 : GamePacket
	{
		
		public 玩家比较成就()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
