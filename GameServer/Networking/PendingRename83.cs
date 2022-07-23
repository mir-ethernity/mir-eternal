using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 559, 长度 = 6, 注释 = "RejectionApprenticeshipAppPacket")]
	public sealed class 收徒申请拒绝 : GamePacket
	{
		
		public 收徒申请拒绝()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
