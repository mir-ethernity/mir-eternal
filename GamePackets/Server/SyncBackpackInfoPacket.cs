using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 17, 长度 = 0, 注释 = "SyncBackpackInfoPacket")]
	public sealed class SyncBackpackInfoPacket : GamePacket
	{
		
		public SyncBackpackInfoPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 6, Length = 0)]
		public byte[] 物品描述;
	}
}
