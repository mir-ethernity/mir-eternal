using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 17, 长度 = 0, 注释 = "SyncBackpackInfoPacket")]
	public sealed class SyncBackpackInfoPacket : GamePacket
	{
		
		public SyncBackpackInfoPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 0)]
		public byte[] 物品描述;
	}
}
