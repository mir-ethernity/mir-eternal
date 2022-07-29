using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 535, 长度 = 6, 注释 = "同意拜师申请")]
	public sealed class 同意拜师申请 : GamePacket
	{
		
		public 同意拜师申请()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
