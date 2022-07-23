using System;
using System.Drawing;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 124, 长度 = 18, 注释 = "陷阱移动")]
	public sealed class TrapMoveLocationPacket : GamePacket
	{
		
		public TrapMoveLocationPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 陷阱编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 2)]
		public ushort 移动速度;

		
		[WrappingFieldAttribute(下标 = 8, 长度 = 4)]
		public int 未知参数;

		
		[WrappingFieldAttribute(下标 = 12, 长度 = 4)]
		public Point 移动坐标;

		
		[WrappingFieldAttribute(下标 = 16, 长度 = 4)]
		public ushort 移动高度;
	}
}
