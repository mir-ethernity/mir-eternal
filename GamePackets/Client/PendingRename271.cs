using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 109, 长度 = 35, 注释 = "更改摊位名字")]
	public sealed class 更改摊位名字 : GamePacket
	{
		
		public 更改摊位名字()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 33)]
		public string 摊位名字;
	}
}
