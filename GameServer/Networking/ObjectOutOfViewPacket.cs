using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 62, 长度 = 7, 注释 = "对象消失")]
	public sealed class ObjectOutOfViewPacket : GamePacket
	{
		
		public ObjectOutOfViewPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 1)]
		public byte 消失方式;
	}
}
