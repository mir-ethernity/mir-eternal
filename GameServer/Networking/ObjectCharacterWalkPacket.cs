using System;
using System.Drawing;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 46, 长度 = 12, 注释 = "角色走动")]
	public sealed class ObjectCharacterWalkPacket : GamePacket
	{
		
		public ObjectCharacterWalkPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 2)]
		public ushort 移动速度;

		
		[WrappingFieldAttribute(下标 = 8, 长度 = 4)]
		public Point 移动坐标;
	}
}
