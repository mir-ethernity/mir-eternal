using System;
using System.Drawing;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 14, Length = 10, Description = "上传角色位置")]
	public sealed class 上传角色位置 : GamePacket
	{
		
		public 上传角色位置()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 4)]
		public Point 坐标;

		
		[WrappingFieldAttribute(SubScript = 8, Length = 2)]
		public ushort 高度;
	}
}
