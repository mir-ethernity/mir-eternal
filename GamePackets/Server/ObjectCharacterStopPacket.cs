using System;
using System.Drawing;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 48, 长度 = 13, 注释 = "角色停止")]
	public sealed class ObjectCharacterStopPacket : GamePacket
	{
		
		public ObjectCharacterStopPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 7, Length = 4)]
		public Point 对象坐标;

		
		[WrappingFieldAttribute(SubScript = 11, Length = 2)]
		public ushort 对象高度;
	}
}
