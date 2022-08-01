using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 590, 长度 = 6, 注释 = "处理入会申请")]
	public sealed class 入会申请应答 : GamePacket
	{
		
		public 入会申请应答()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
