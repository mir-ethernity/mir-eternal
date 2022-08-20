using System;
using System.Drawing;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 47, Length = 12, Description = "角色跑动", Broadcast = true)]
	public sealed class ObjectCharacterRunPacket : GamePacket
	{
		
		public ObjectCharacterRunPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 2)]
		public ushort 移动耗时;

		
		[WrappingFieldAttribute(SubScript = 8, Length = 4)]
		public Point 移动坐标;
	}
}
