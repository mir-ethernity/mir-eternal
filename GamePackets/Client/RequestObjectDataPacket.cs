using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 19, Length = 10, Description = "RequestObjectDataPacket, 对应服务端0041封包")]
	public sealed class RequestObjectDataPacket : GamePacket
	{
		
		public RequestObjectDataPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int 状态编号;
	}
}
