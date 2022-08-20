using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 148, Length = 6, Description = "玩家同意交易")]
	public sealed class 玩家同意交易 : GamePacket
	{
		
		public 玩家同意交易()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
