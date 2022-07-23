using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 119, 长度 = 6, 注释 = "提交选项继续NPC对话")]
	public sealed class 继续Npcc对话 : GamePacket
	{
		
		public 继续Npcc对话()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对话编号;
	}
}
