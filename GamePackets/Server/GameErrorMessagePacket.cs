using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 9, Length = 14, Description = "服务端提示")]
	public sealed class GameErrorMessagePacket : GamePacket
	{
		
		public GameErrorMessagePacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 错误代码;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int 第一参数;

		
		[WrappingFieldAttribute(SubScript = 10, Length = 4)]
		public int 第二参数;
	}
}
