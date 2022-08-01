using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 148, 长度 = 0, 注释 = "SyncCurrencyQuantityPacket")]
	public sealed class SyncCurrencyQuantityPacket : GamePacket
	{
		
		public SyncCurrencyQuantityPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 5, Length = 0)]
		public byte[] 字节描述;
	}
}
