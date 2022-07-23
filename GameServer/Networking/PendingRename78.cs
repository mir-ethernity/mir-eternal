using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 514, 长度 = 14, 注释 = "聊天服务器错误提示")]
	public sealed class 社交错误提示 : GamePacket
	{
		
		public 社交错误提示()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 错误编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 参数一;

		
		[WrappingFieldAttribute(下标 = 10, 长度 = 4)]
		public int 参数二;
	}
}
