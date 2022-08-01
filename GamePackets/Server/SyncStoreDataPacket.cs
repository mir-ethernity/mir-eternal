using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 142, 长度 = 0, 注释 = "同步商店版本")]
	public sealed class SyncStoreDataPacket : GamePacket
	{
		
		public SyncStoreDataPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 4)]
		public int 版本编号;

		
		[WrappingFieldAttribute(SubScript = 8, Length = 4)]
		public int 商品数量;

		
		[WrappingFieldAttribute(SubScript = 12, Length = 0)]
		public byte[] 文件内容;
	}
}
