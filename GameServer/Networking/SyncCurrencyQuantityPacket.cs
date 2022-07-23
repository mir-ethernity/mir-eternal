using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 148, 长度 = 0, 注释 = "SyncCurrencyQuantityPacket")]
	public sealed class SyncCurrencyQuantityPacket : GamePacket
	{
		
		public SyncCurrencyQuantityPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 5, 长度 = 0)]
		public byte[] 字节描述;
	}
}
