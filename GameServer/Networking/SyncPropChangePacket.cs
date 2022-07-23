using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 77, 长度 = 7, 注释 = "SyncPropChangePacket")]
	public sealed class SyncPropChangePacket : GamePacket
	{
		
		public SyncPropChangePacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte StatId;

		
		[WrappingFieldAttribute(下标 = 3, 长度 = 4)]
		public int Value;
	}
}
