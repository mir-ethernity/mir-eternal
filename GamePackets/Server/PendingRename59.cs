using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 590, Length = 6, Description = "处理入会申请")]
	public sealed class 入会申请应答 : GamePacket
	{
		
		public 入会申请应答()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
