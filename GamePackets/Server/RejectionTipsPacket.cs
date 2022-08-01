using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 560, 长度 = 6, 注释 = "RejectionTipsPacket")]
	public sealed class RejectionTipsPacket : GamePacket
	{
		
		public RejectionTipsPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
