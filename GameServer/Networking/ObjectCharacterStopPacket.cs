using System;
using System.Drawing;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 48, 长度 = 13, 注释 = "角色停止")]
	public sealed class ObjectCharacterStopPacket : GamePacket
	{
		
		public ObjectCharacterStopPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(下标 = 7, 长度 = 4)]
		public Point 对象坐标;

		
		[WrappingFieldAttribute(下标 = 11, 长度 = 2)]
		public ushort 对象高度;
	}
}
