using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 565, 长度 = 6, 注释 = "ExpulsionDoorAnswerPacket")]
	public sealed class ExpulsionDoorAnswerPacket : GamePacket
	{
		
		public ExpulsionDoorAnswerPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
