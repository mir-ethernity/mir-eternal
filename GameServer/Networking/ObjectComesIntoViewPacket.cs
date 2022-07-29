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

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 出现方式;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 7, Length = 1)]
		public byte 现身姿态;

		
		[WrappingFieldAttribute(SubScript = 8, Length = 4)]
		public Point 现身坐标;

		
		[WrappingFieldAttribute(SubScript = 12, Length = 2)]
		public ushort 现身高度;

		
		[WrappingFieldAttribute(SubScript = 14, Length = 2)]
		public ushort 现身方向;

		
		[WrappingFieldAttribute(SubScript = 16, Length = 1)]
		public byte 体力比例;

		
		[WrappingFieldAttribute(SubScript = 18, Length = 1)]
		public byte AdditionalParam;
	}
}
