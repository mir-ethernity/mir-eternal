using System;
using System.Drawing;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 18, Length = 6, Description = "角色走动")]
	public sealed class 客户角色走动 : GamePacket
	{
		
		public 客户角色走动()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public Point 坐标;
	}
}
