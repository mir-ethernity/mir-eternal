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

		
		[WrappingFieldAttribute(下标 = 4, 长度 = 4)]
		public int MapId;

		
		[WrappingFieldAttribute(下标 = 8, 长度 = 4)]
		public int 来源编号;

		
		[WrappingFieldAttribute(下标 = 12, 长度 = 2)]
		public ushort 陷阱编号;

		
		[WrappingFieldAttribute(下标 = 14, 长度 = 4)]
		public Point 陷阱坐标;

		
		[WrappingFieldAttribute(下标 = 18, 长度 = 2)]
		public ushort 陷阱高度;

		
		[WrappingFieldAttribute(下标 = 20, 长度 = 2)]
		public ushort 持续时间;

		
		[WrappingFieldAttribute(下标 = 22, 长度 = 2)]
		public ushort 未知参数;

		
		[WrappingFieldAttribute(下标 = 24, 长度 = 4)]
		public Point 未知坐标;

		
		[WrappingFieldAttribute(下标 = 28, 长度 = 2)]
		public ushort 未知高度;
	}
}
