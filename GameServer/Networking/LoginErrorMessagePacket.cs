using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 1001, 长度 = 14, 注释 = "Logging on to the server, error message")]
	public sealed class LoginErrorMessagePacket : GamePacket
	{
		
		public LoginErrorMessagePacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public uint 错误代码;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int 参数一;

		
		[WrappingFieldAttribute(SubScript = 10, Length = 4)]
		public int 参数二;
	}
}
