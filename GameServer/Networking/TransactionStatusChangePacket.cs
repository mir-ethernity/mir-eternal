using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 215, 长度 = 11, 注释 = "TransactionStatusChangePacket")]
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
