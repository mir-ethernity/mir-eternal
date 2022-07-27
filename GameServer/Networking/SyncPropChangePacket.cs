using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 77, 长度 = 7, 注释 = "SyncPropChangePacket")]
	public sealed class SyncPropChangePacket : GamePacket
	{
		
		public SyncPropChangePacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte StatId;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 4)]
		public int Value;
	}
}
