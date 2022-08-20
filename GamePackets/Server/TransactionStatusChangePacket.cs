using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 215, Length = 11, Description = "TransactionStatusChangePacket")]
	public sealed class TransactionStatusChangePacket : GamePacket
	{
		
		public TransactionStatusChangePacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 1)]
		public byte 交易状态;

		
		[WrappingFieldAttribute(SubScript = 7, Length = 4)]
		public int 对象等级;
	}
}
