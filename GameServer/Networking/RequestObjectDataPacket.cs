using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 19, 长度 = 10, 注释 = "RequestObjectDataPacket, 对应服务端0041封包")]
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
