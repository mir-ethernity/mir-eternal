using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 159, Length = 39, Description = "更改摊位名字", Broadcast = true)]
	public sealed class 变更摊位名字 : GamePacket
	{
		
		public 变更摊位名字()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 33)]
		public string 摊位名字;
	}
}
