using System;
using System.Drawing;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 49, 长度 = 17, 注释 = "被动位移")]
	public sealed class ObjectPassiveDisplacementPacket : GamePacket
	{
		
		public ObjectPassiveDisplacementPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 1)]
		public byte 第一标记;

		
		[WrappingFieldAttribute(下标 = 7, 长度 = 4)]
		public Point 位移坐标;

		
		[WrappingFieldAttribute(下标 = 11, 长度 = 2)]
		public ushort 第二标记;

		
		[WrappingFieldAttribute(下标 = 13, 长度 = 2)]
		public ushort 位移朝向;

		
		[WrappingFieldAttribute(下标 = 15, 长度 = 2)]
		public ushort 位移速度;
	}
}
