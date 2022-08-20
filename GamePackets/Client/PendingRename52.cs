using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 237, Length = 8, Description = "回应组队请求")]
	public sealed class 回应组队请求 : GamePacket
	{
		
		public 回应组队请求()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 1)]
		public byte 组队方式;

		
		[WrappingFieldAttribute(SubScript = 7, Length = 1)]
		public byte 回应方式;
	}
}
