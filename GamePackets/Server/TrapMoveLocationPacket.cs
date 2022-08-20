using System;
using System.Drawing;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 124, Length = 18, Description = "陷阱移动", Broadcast = true)]
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
