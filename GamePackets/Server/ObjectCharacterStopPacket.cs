using System;
using System.Drawing;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 48, Length = 13, Description = "角色停止")]
	public sealed class ObjectCharacterStopPacket : GamePacket
	{
		
		public ObjectCharacterStopPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		[WrappingFieldAttribute(SubScript = 6, Length = 1)]
		public byte U1 = 1;
		
		[WrappingFieldAttribute(SubScript = 7, Length = 4)]
		public Point 对象坐标;

		
		[WrappingFieldAttribute(SubScript = 11, Length = 2)]
		public ushort 对象高度;
	}
}
