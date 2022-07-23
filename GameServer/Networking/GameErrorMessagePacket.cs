using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 9, 长度 = 14, 注释 = "服务端提示")]
	public sealed class GameErrorMessagePacket : GamePacket
	{
		
		public GameErrorMessagePacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 错误代码;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 第一参数;

		
		[WrappingFieldAttribute(下标 = 10, 长度 = 4)]
		public int 第二参数;
	}
}
