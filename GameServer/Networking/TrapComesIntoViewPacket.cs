using System;
using System.Drawing;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 123, 长度 = 30, 注释 = "陷阱出现")]
	public sealed class TrapComesIntoViewPacket : GamePacket
	{
		
		public TrapComesIntoViewPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 4)]
		public int MapId;

		
		[WrappingFieldAttribute(SubScript = 8, Length = 4)]
		public int 来源编号;

		
		[WrappingFieldAttribute(SubScript = 12, Length = 2)]
		public ushort Id;

		
		[WrappingFieldAttribute(SubScript = 14, Length = 4)]
		public Point 陷阱坐标;

		
		[WrappingFieldAttribute(SubScript = 18, Length = 2)]
		public ushort 陷阱高度;

		
		[WrappingFieldAttribute(SubScript = 20, Length = 2)]
		public ushort 持续时间;

		
		[WrappingFieldAttribute(SubScript = 22, Length = 2)]
		public ushort 未知参数;

		
		[WrappingFieldAttribute(SubScript = 24, Length = 4)]
		public Point 未知坐标;

		
		[WrappingFieldAttribute(SubScript = 28, Length = 2)]
		public ushort 未知高度;
	}
}
