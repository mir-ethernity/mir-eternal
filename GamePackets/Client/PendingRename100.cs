using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 147, Length = 6, Description = "玩家申请交易")]
	public sealed class 玩家申请交易 : GamePacket
	{
		
		public 玩家申请交易()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
