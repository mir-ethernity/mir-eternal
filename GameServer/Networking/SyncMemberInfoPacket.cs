using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 646, 长度 = 11, 注释 = "SyncMemberInfoPacket")]
	public sealed class SyncMemberInfoPacket : GamePacket
	{
		
		public SyncMemberInfoPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 对象信息;

		
		[WrappingFieldAttribute(下标 = 10, 长度 = 1)]
		public byte 当前等级;
	}
}
