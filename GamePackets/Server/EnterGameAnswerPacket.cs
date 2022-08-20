using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 1003, Length = 6, Description = "回应客户端进入游戏请求")]
	public sealed class EnterGameAnswerPacket : GamePacket
	{
		
		public EnterGameAnswerPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 角色编号;
	}
}
