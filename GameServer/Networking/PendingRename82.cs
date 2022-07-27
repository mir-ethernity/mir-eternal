using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 558, 长度 = 6, 注释 = "同意收徒申请")]
	public sealed class 收徒申请同意 : GamePacket
	{
		
		public 收徒申请同意()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
