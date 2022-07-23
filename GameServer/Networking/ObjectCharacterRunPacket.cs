using System;
using System.Drawing;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 47, 长度 = 12, 注释 = "角色跑动")]
	public sealed class ObjectCharacterRunPacket : GamePacket
	{
		
		public ObjectCharacterRunPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 2)]
		public ushort 移动耗时;

		
		[WrappingFieldAttribute(下标 = 8, 长度 = 4)]
		public Point 移动坐标;
	}
}
