using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 550, 长度 = 6, 注释 = "申请拜师提示")]
	public sealed class 申请拜师提示 : GamePacket
	{
		
		public 申请拜师提示()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
