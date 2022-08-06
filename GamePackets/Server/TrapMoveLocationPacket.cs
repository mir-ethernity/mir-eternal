using System;
using System.Drawing;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 124, 长度 = 18, 注释 = "陷阱移动", Broadcast = true)]
	public sealed class TrapMoveLocationPacket : GamePacket
	{
		
		public TrapMoveLocationPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int Id;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 2)]
		public ushort 移动速度;

		
		[WrappingFieldAttribute(SubScript = 8, Length = 4)]
		public int 未知参数;

		
		[WrappingFieldAttribute(SubScript = 12, Length = 4)]
		public Point 移动坐标;

		
		[WrappingFieldAttribute(SubScript = 16, Length = 4)]
		public ushort 移动高度;
	}
}
