using System;
using System.Drawing;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 41, 长度 = 23, 注释 = "切换地图(回城/过图/传送)")]
	public sealed class 玩家切换地图 : GamePacket
	{
		
		public 玩家切换地图()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 地图编号;

		
		[WrappingFieldAttribute(下标 = 10, 长度 = 4)]
		public int 路线编号;

		
		[WrappingFieldAttribute(下标 = 14, 长度 = 4)]
		public Point 对象坐标;

		
		[WrappingFieldAttribute(下标 = 18, 长度 = 2)]
		public ushort 对象高度;
	}
}
