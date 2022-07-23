using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 552, 长度 = 6, 注释 = "RefusedApplyApprenticeshipPacket")]
	public sealed class 拜师申请拒绝 : GamePacket
	{
		
		public 拜师申请拒绝()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
