using System;
using System.Drawing;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 39, 长度 = 17, 注释 = "进入场景(包括商店/随机卷)")]
	public sealed class 玩家进入场景 : GamePacket
	{
		
		public 玩家进入场景()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 地图编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 路线编号;

		
		[WrappingFieldAttribute(下标 = 10, 长度 = 1)]
		public byte RouteStatus;

		
		[WrappingFieldAttribute(下标 = 11, 长度 = 4)]
		public Point 当前坐标;

		
		[WrappingFieldAttribute(下标 = 15, 长度 = 2)]
		public ushort 当前高度;
	}
}
