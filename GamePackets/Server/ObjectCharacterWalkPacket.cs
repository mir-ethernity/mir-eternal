using System;
using System.Drawing;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 46, 长度 = 12, 注释 = "角色走动", Broadcast = true)]
	public sealed class ObjectCharacterWalkPacket : GamePacket
	{
		
		public ObjectCharacterWalkPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 2)]
		public ushort 移动速度;

		
		[WrappingFieldAttribute(SubScript = 8, Length = 4)]
		public Point 移动坐标;
	}
}
