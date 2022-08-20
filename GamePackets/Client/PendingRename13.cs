using System;
using System.Drawing;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 17, Length = 6, Description = "角色跑动")]
	public sealed class 客户角色跑动 : GamePacket
	{
		
		public 客户角色跑动()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4, Reverse = true)]
		public Point 坐标;
	}
}
