using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 539, 长度 = 6, 注释 = "同意收徒申请")]
	public sealed class 同意收徒申请 : GamePacket
	{
		
		public 同意收徒申请()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
