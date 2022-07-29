using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 549, 长度 = 6, 注释 = "玩家申请拜师")]
	public sealed class 申请拜师应答 : GamePacket
	{
		
		public 申请拜师应答()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
