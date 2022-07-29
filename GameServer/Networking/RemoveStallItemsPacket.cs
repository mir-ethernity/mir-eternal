using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 158, 长度 = 3, 注释 = "RemoveStallItemsPacket")]
	public sealed class RemoveStallItemsPacket : GamePacket
	{
		
		public RemoveStallItemsPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 取回位置;
	}
}
