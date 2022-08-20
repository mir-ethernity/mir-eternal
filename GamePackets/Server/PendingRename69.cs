using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 550, Length = 6, Description = "申请拜师提示")]
	public sealed class 申请拜师提示 : GamePacket
	{
		
		public 申请拜师提示()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
