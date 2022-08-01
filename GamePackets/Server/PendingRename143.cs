using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 657, 长度 = 0, 注释 = "RequestTreasureDataPacket")]
	public sealed class 同步珍宝数据 : GamePacket
	{
		
		public 同步珍宝数据()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 4)]
		public int 版本编号;

		
		[WrappingFieldAttribute(SubScript = 8, Length = 4)]
		public int 商品数量;

		
		[WrappingFieldAttribute(SubScript = 12, Length = 0)]
		public byte[] 商店数据;
	}
}
