using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 159, 长度 = 39, 注释 = "更改摊位名字")]
	public sealed class 变更摊位名字 : GamePacket
	{
		
		public 变更摊位名字()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 33)]
		public string 摊位名字;
	}
}
