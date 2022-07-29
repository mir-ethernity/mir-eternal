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

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 1)]
		public byte 第一标记;

		
		[WrappingFieldAttribute(SubScript = 7, Length = 4)]
		public Point 位移坐标;

		
		[WrappingFieldAttribute(SubScript = 11, Length = 2)]
		public ushort 第二标记;

		
		[WrappingFieldAttribute(SubScript = 13, Length = 2)]
		public ushort 位移朝向;

		
		[WrappingFieldAttribute(SubScript = 15, Length = 2)]
		public ushort 位移速度;
	}
}
