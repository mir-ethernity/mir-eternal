using System;
using System.Drawing;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 60, 长度 = 20, 注释 = "对象出现, 适用于对象主动进入视野")]
	public sealed class ObjectComesIntoViewPacket : GamePacket
	{
		
		public ObjectComesIntoViewPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 出现方式;

		
		[WrappingFieldAttribute(下标 = 3, 长度 = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(下标 = 7, 长度 = 1)]
		public byte 现身姿态;

		
		[WrappingFieldAttribute(下标 = 8, 长度 = 4)]
		public Point 现身坐标;

		
		[WrappingFieldAttribute(下标 = 12, 长度 = 2)]
		public ushort 现身高度;

		
		[WrappingFieldAttribute(下标 = 14, 长度 = 2)]
		public ushort 现身方向;

		
		[WrappingFieldAttribute(下标 = 16, 长度 = 1)]
		public byte 体力比例;

		
		[WrappingFieldAttribute(下标 = 18, 长度 = 1)]
		public byte AdditionalParam;
	}
}
