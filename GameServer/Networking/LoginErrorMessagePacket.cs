using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 1001, 长度 = 14, 注释 = "登录服务器,错误提示")]
	public sealed class LoginErrorMessagePacket : GamePacket
	{
		
		public LoginErrorMessagePacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public uint 错误代码;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 参数一;

		
		[WrappingFieldAttribute(下标 = 10, 长度 = 4)]
		public int 参数二;
	}
}
