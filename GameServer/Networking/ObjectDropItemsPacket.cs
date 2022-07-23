using System;
using System.Drawing;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 150, 长度 = 24, 注释 = "掉落物品")]
	public sealed class ObjectDropItemsPacket : GamePacket
	{
		
		public ObjectDropItemsPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 地图编号;

		
		[WrappingFieldAttribute(下标 = 10, 长度 = 4)]
		public Point 掉落坐标;

		
		[WrappingFieldAttribute(下标 = 14, 长度 = 2)]
		public ushort 掉落高度;

		
		[WrappingFieldAttribute(下标 = 16, 长度 = 4)]
		public int 物品编号;

		
		[WrappingFieldAttribute(下标 = 20, 长度 = 4)]
		public int 物品数量;
	}
}
