using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 1003, 长度 = 6, 注释 = "回应客户端进入游戏请求")]
	public sealed class EnterGameAnswerPacket : GamePacket
	{
		
		public EnterGameAnswerPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 角色编号;
	}
}
