using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 657, 长度 = 0, 注释 = "RequestTreasureDataPacket")]
	public sealed class 同步珍宝数据 : GamePacket
	{
		
		public 同步珍宝数据()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 4, 长度 = 4)]
		public int 版本编号;

		
		[WrappingFieldAttribute(下标 = 8, 长度 = 4)]
		public int 商品数量;

		
		[WrappingFieldAttribute(下标 = 12, 长度 = 0)]
		public byte[] 商店数据;
	}
}
