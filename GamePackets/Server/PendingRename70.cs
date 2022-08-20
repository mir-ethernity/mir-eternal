using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 549, Length = 6, Description = "玩家申请拜师")]
	public sealed class 申请拜师应答 : GamePacket
	{
		
		public 申请拜师应答()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
