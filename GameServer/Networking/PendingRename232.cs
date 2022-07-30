using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 159, 长度 = 39, 注释 = "更改摊位名字")]
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
