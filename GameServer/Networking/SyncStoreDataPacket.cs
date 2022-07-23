using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 142, 长度 = 0, 注释 = "同步商店版本")]
	public sealed class SyncStoreDataPacket : GamePacket
	{
		
		public SyncStoreDataPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 4, 长度 = 4)]
		public int 版本编号;

		
		[WrappingFieldAttribute(下标 = 8, 长度 = 4)]
		public int 商品数量;

		
		[WrappingFieldAttribute(下标 = 12, 长度 = 0)]
		public byte[] 文件内容;
	}
}
