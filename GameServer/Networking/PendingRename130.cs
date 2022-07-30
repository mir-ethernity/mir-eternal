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

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int MapId;

		
		[WrappingFieldAttribute(SubScript = 10, Length = 4)]
		public int 路线编号;

		
		[WrappingFieldAttribute(SubScript = 14, Length = 4)]
		public Point 对象坐标;

		
		[WrappingFieldAttribute(SubScript = 18, Length = 2)]
		public ushort 对象高度;
	}
}
