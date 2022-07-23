using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 237, 长度 = 8, 注释 = "回应组队请求")]
	public sealed class 回应组队请求 : GamePacket
	{
		
		public 回应组队请求()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 1)]
		public byte 组队方式;

		
		[WrappingFieldAttribute(下标 = 7, 长度 = 1)]
		public byte 回应方式;
	}
}
