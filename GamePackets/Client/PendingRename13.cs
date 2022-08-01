using System;
using System.Drawing;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 17, 长度 = 6, 注释 = "角色跑动")]
	public sealed class 客户角色跑动 : GamePacket
	{
		
		public 客户角色跑动()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4, Reverse = true)]
		public Point 坐标;
	}
}
