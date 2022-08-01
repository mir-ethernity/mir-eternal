using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 34, 长度 = 0, 注释 = "SyncPlayerAttributesPacket")]
	public sealed class SyncPlayerAttributesPacket : GamePacket
	{
		
		public SyncPlayerAttributesPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 8, Length = 4)]
		public int Stat数量;
	}
}
