using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 567, 长度 = 6, 注释 = "TransferPresidentPositionPacket")]
	public sealed class TransferPresidentPositionPacket : GamePacket
	{
		
		public TransferPresidentPositionPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
