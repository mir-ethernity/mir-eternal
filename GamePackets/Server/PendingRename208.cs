using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 552, 长度 = 6, 注释 = "RefusedApplyApprenticeshipPacket")]
	public sealed class 拜师申请拒绝 : GamePacket
	{
		
		public 拜师申请拒绝()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
