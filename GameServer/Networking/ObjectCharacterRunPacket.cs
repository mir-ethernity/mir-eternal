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

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 2)]
		public ushort 移动耗时;

		
		[WrappingFieldAttribute(SubScript = 8, Length = 4)]
		public Point 移动坐标;
	}
}
