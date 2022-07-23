using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 215, 长度 = 11, 注释 = "TransactionStatusChangePacket")]
	public sealed class TransactionStatusChangePacket : GamePacket
	{
		
		public TransactionStatusChangePacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 1)]
		public byte 交易状态;

		
		[WrappingFieldAttribute(下标 = 7, 长度 = 4)]
		public int 对象等级;
	}
}
