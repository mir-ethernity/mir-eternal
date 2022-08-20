using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 551, Length = 6, Description = "同意拜师申请")]
	public sealed class 拜师申请通过 : GamePacket
	{
		
		public 拜师申请通过()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
