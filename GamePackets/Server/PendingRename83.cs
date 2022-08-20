using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 559, Length = 6, Description = "RejectionApprenticeshipAppPacket")]
	public sealed class 收徒申请拒绝 : GamePacket
	{
		
		public 收徒申请拒绝()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
