using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 552, Length = 6, Description = "RefusedApplyApprenticeshipPacket")]
	public sealed class 拜师申请拒绝 : GamePacket
	{
		
		public 拜师申请拒绝()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
