using System;
using System.Drawing;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 17, 长度 = 6, 注释 = "角色跑动")]
	public sealed class 客户角色跑动 : GamePacket
	{
		
		public 客户角色跑动()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4, 反向 = true)]
		public Point 坐标;
	}
}
