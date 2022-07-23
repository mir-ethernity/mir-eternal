using System;
using System.Drawing;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 14, 长度 = 10, 注释 = "上传角色位置")]
	public sealed class 上传角色位置 : GamePacket
	{
		
		public 上传角色位置()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 4, 长度 = 4)]
		public Point 坐标;

		
		[WrappingFieldAttribute(下标 = 8, 长度 = 2)]
		public ushort 高度;
	}
}
