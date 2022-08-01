using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 565, 长度 = 6, 注释 = "ExpulsionDoorAnswerPacket")]
	public sealed class ExpulsionDoorAnswerPacket : GamePacket
	{
		
		public ExpulsionDoorAnswerPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
